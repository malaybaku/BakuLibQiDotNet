using System;
using System.Linq;
using System.Collections.Generic;

using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのオブジェクト(基本的にサービスモジュールと同じ)を表します。</summary>
    public sealed class QiObject
    {
        internal QiObject(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        //NOTE: ObjectBuilderとGetServiceの戻り値以外でインスタンス生成する必要ないのでそもそも実装要るの？ってレベル
        internal static QiObject Create() => QiApiObject.Create();

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiObject.Destroy(this);

        private QiValue _metaObject;
        internal QiValue MetaObject => _metaObject ?? (_metaObject = QiApiObject.GetMetaObject(this));

        /// <summary>サービスの内部情報を表すメタオブジェクトを取得します。</summary>
        /// <returns>
        /// サービスの内部情報を表すメタオブジェクト。
        /// とりあえず内容一覧を見たい場合などは<see cref="QiValue.Dump(int, int)"/>を用いる
        /// </returns>
        public QiValue GetMetaObject() => QiApiObject.GetMetaObject(this);

        private string _description = null;
        /// <summary>サービスの機能に関する説明文を取得します。</summary>
        public string Description
        {
            get
            {
                if (_description == null)
                {
                    var mObj = MetaObject;
                    //NOTE: mObj[3]にモジュールのDescription文字列が入るというのは観察から得た知見
                    _description = (mObj.Count > 3) ?
                        mObj[3].ToString() :
                        "";
                }
                return _description;
            }
        }

        private QiMethods _methods;
        private QiMethods Methods => _methods ?? (_methods = new QiMethods(this));

        /// <summary>メソッド名を指定してモジュールのメソッドを取得します。</summary>
        /// <param name="methodName">メソッドの名前</param>
        /// <returns>対応するメソッド</returns>
        public QiMethod this[string methodName] => Methods[methodName];

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を呼び出します。
        /// ラッパーの動作不良に備えて公開されており、通常は<see cref="this[string]"/>で選択したメソッドを用いてください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>戻り値の非同期取得に使えるfuture型</returns>
        public QiFuture CallDirect(string signature, QiValue argsTuple)
            => QiApiObject.Call(this, signature, argsTuple);

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を非同期で呼び出します。
        /// デバッグ目的で公開されており、普通は<see cref="this[string]"/>で選択した<see cref="QiMethod"/>で
        /// <see cref="QiMethod.Post(QiAnyValue[])"/>を使用してください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>非同期呼び出しの状態確認を行うために使われるID</returns>
        public int PostDirect(string signature, QiValue argsTuple)
            => QiApiObject.Post(this, signature, argsTuple);


        /// <summary>シグナル(イベント)にハンドラを登録します。</summary>
        /// <param name="signature">シグナルの名前("signal"など)</param>
        /// <param name="callback">そのシグナルに対するコールバック関数</param>
        /// <returns>
        /// コールバックへの対応を表した整数。<see cref="DisconnectSignal(ulong)"/>でハンドラを解除する場合は必要ですが、
        /// <see cref="DisconnectSignal(Action{QiValue})"/>を用いる場合は不要です。
        /// </returns>
        public ulong ConnectSignal(string signature, Action<QiValue> callback)
        {
            var handler = new QiSignalHandler(callback);
            var result = QiApiObject
                .SignalConnect(this, signature, handler.ApiCallback, IntPtr.Zero)
                .GetUInt64(0UL);

            _handlers[result] = handler;
            return result;
        }

        /// <summary>
        /// 識別IDを師弟してシグナルの登録を解除します。
        /// </summary>
        /// <param name="id"><see cref="ConnectSignal(string, Action{QiValue})"/>の戻り値として受け取ったID</param>
        /// <returns>解除に成功した場合は非nullの戻り値、存在しないIDを指定した場合などはnull</returns>
        public QiFuture DisconnectSignal(ulong id)
        {
            if(_handlers.ContainsKey(id))
            {
                _handlers.Remove(id);
                return QiApiObject.SignalDisconnect(this, id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>ハンドラーを指定してシグナルへの登録を解除します。</summary>
        /// <param name="callback"><see cref="ConnectSignal(string, Action{QiValue})"/>で指定したコールバック関数</param>
        /// <returns>解除に成功した場合は非nullの戻り値、不正な値を指定した場合などはnull</returns>
        public QiFuture DisconnectSignal(Action<QiValue> callback)
        {
            var disconnectTargetPair = _handlers.FirstOrDefault(pair => pair.Value.TargetAction.Equals(callback));
            if(disconnectTargetPair.Value != null)
            {
                return DisconnectSignal(disconnectTargetPair.Key);
            }
            else
            {
                return null;
            }
        }

        /// <summary>(動作未確認)オブジェクトのプロパティ値を取得します。</summary>
        /// <param name="pname">取得対象となるプロパティの名前</param>
        /// <returns>対応するプロパティ値への予約</returns>
        public QiFuture GetProperty(string pname) => QiApiObject.GetProperty(this, pname);

        /// <summary>(動作未確認)オブジェクトのプロパティに値を設定します。</summary>
        /// <param name="pname">プロパティ名</param>
        /// <param name="v">プロパティへ代入する値</param>
        /// <returns>代入結果への予約</returns>
        public QiFuture SetProperty(string pname, QiValue v) => QiApiObject.SetProperty(this, pname, v);


        //ID、マネージドハンドラ、アンマネージドハンドラをまとめるためのキャッシュ
        //キャッシュを持たないと関数オブジェクトがGCで回収される可能性があるので注意
        private readonly Dictionary<ulong, QiSignalHandler> _handlers = new Dictionary<ulong, QiSignalHandler>();

        /// <summary>マネージドハンドラとアンマネージドハンドラを両方持っておくためのホルダー</summary>
        class QiSignalHandler
        {
            internal QiSignalHandler(Action<QiValue> action)
            {
                TargetAction = action;
                ApiCallback = (qiValueHandle, userdata) => action(new QiValue(qiValueHandle));
            }

            /// <summary>ユーザが指定したイベントハンドラ</summary>
            internal Action<QiValue> TargetAction { get; }
            /// <summary><see cref="TargetAction"/>をAPIに通す形に変形して得たハンドラ</summary>
            internal ApiSignalCallback ApiCallback { get; }
        }

    }

}
