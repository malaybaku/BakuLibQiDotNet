using System;
using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>Qiのオブジェクト(基本的にサービスモジュールと同じ)を表します。</summary>
    public sealed class QiObject : IQiObject, IQiSignal
    {
        internal QiObject(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        //NOTE: ObjectBuilderとGetServiceの戻り値以外でインスタンス生成する必要ないのでこれを呼び出すケースはほぼない
        internal static QiObject Create() => QiApiObject.Create();

        #region IQiObject

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        private string _description = null;
        public string Description
        {
            get
            {
                if (_description == null)
                {
                    var mObj = MetaObject;
                    //NOTE: mObj[3]にモジュールのDescription文字列が入るというのは観察から得た知見
                    _description = (mObj.Count > 3) ? mObj[3].ToString() : "";
                }
                return _description;
            }
        }

        public IQiMethod this[string methodName] => Methods[methodName];

        /// <summary>(動作未確認)オブジェクトのプロパティ値を取得します。</summary>
        /// <param name="pname">取得対象となるプロパティの名前</param>
        /// <returns>対応するプロパティ値への予約</returns>
        public IQiFuture<T> GetProperty<T>(string pname) => QiApiObject.GetProperty(this, pname).WillReturns<T>();

        /// <summary>(動作未確認)オブジェクトのプロパティに値を設定します。</summary>
        /// <param name="pname">プロパティ名</param>
        /// <param name="v">プロパティへ代入する値</param>
        /// <returns>代入結果への予約</returns>
        public IQiFuture SetProperty(string pname, object v)
        {
            //TODO: この実装ではQiValue型以外許可しないので動作が非常に厳しい
            var qv = v as QiValue;
            if (qv != null)
            {
                return QiApiObject.SetProperty(this, pname, qv);
            }
            else
            {
                var p = QiPromise.Create();
                p.SetError("arg type is not 'Baku.LibqiDotNet.Libqi.QiValue'");
                return p.GetFuture();
            }
        }

        #endregion

        #region IQiSignal

        private static readonly string signalName = "signal";

        private event EventHandler<QiSignalEventArgs> _received;
        public event EventHandler<QiSignalEventArgs> Received
        {
            add
            {
                if (_received == null)
                {
                    ConnectSignal(signalName, OnSignalReceived);
                }
                _received += value;
            }
            remove
            {
                _received -= value;
                if (_received == null)
                {
                    DisconnectSignal();
                }
            }
        }

        private void OnSignalReceived(QiValue qv)
            => _received?.Invoke(this, new QiSignalEventArgs(qv));

        #endregion

        #region API Wrapper 

        private QiValue _metaObject;
        internal QiValue MetaObject => _metaObject ?? (_metaObject = QiApiObject.GetMetaObject(this));

        /// <summary>サービスの内部情報を表すメタオブジェクトを取得します。</summary>
        /// <returns>
        /// サービスの内部情報を表すメタオブジェクト。
        /// 含まれる内部情報を見たい場合は<see cref="QiValue.Dump(int, int)"/>を用いて確認して下さい。
        /// </returns>
        public QiValue GetMetaObject() => QiApiObject.GetMetaObject(this);

        private QiMethods _methods;
        private QiMethods Methods => _methods ?? (_methods = new QiMethods(this));

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を呼び出します。
        /// ラッパーの動作不良に備えて公開されており、通常は<see cref="this[string]"/>で選択したメソッドを用いてください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>戻り値の非同期取得に使えるfuture型</returns>
        public QiFuture CallDirect(string signature, QiValue argsTuple)
            => QiApiObject.Call(this, signature, argsTuple);

        //廃止: 元からFutureベースで非同期が完成してんだからこんな小細工に頼るな
        ///// <summary>
        ///// 自力でシグネチャを正しく定義してタプルを渡し、関数を非同期で呼び出します。
        ///// デバッグ目的で公開されており、普通は<see cref="this[string]"/>で選択した<see cref="QiMethod"/>で
        ///// <see cref="QiMethod.Post(QiInputValue[])"/>を使用してください。
        ///// </summary>
        ///// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        ///// <param name="argsTuple">引数の入ってるタプル</param>
        ///// <returns>非同期呼び出しの状態確認を行うために使われるID</returns>
        //public int PostDirect(string signature, QiValue argsTuple)
        //    => QiApiObject.Post(this, signature, argsTuple);


        /// <summary>シグナル(イベント)にハンドラを登録します。</summary>
        /// <param name="signature">シグナルの名前("signal"など)</param>
        /// <param name="callback">そのシグナルに対するコールバック関数</param>
        /// <returns>
        /// コールバックへの対応を表した整数。<see cref="DisconnectSignal(ulong)"/>でハンドラを解除する場合は必要ですが、
        /// <see cref="DisconnectSignal(Action{QiValue})"/>を用いる場合は不要です。
        /// </returns>
        private void ConnectSignal(string signature, Action<QiValue> callback)
        {
            if (_handler != null)
            {
                throw new InvalidOperationException("handler is aldeady set");
            }

            _handler = new QiSignalHandler(callback);
            var f = QiApiObject
                .SignalConnect(this, signature, _handler.ApiCallback, IntPtr.Zero)
                .WillReturns<ulong>();
            f.Wait();
            _subscribeId = f.Get();
        }

        /// <summary>識別IDを指定してシグナルの登録を解除します。</summary>
        private QiFuture DisconnectSignal()
        {
            if (_handler != null && _subscribeId.HasValue)
            {
                QiFuture f = QiApiObject.SignalDisconnect(this, _subscribeId.Value);

                _handler = null;
                _subscribeId = null;

                return f;
            }
            else
            {
                var p = QiPromise.Create();
                p.SetValue(QiValue.Void);
                return p.GetFuture();
            }
        }

        private ulong? _subscribeId = null;
        private QiSignalHandler _handler = null;

        #endregion

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
