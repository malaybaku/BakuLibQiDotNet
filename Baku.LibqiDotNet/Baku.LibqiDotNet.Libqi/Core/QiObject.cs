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

        /// <summary>[NOT SUPPORTED]実装された場合はサービス名を取得します。</summary>
        public string Name
        {
            get { throw new NotSupportedException(); }
        }

        private string _description = null;
        /// <summary>サービスの説明文を取得します。</summary>
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

        /// <summary>メソッド名を指定して対応するメソッドを取得します。</summary>
        /// <param name="methodName">メソッド名</param>
        /// <returns>名称を指定されたメソッド</returns>
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

        private event Action<IQiResult> _received;
        private void OnSignalReceived(QiValue qv) => _received?.Invoke(qv);

        /// <summary>シグナル受信時の処理を登録します。</summary>
        /// <param name="handler">受信時に呼ばれるハンドラ関数</param>
        /// <returns>登録の非同期処理状態</returns>
        public IQiFuture ConnectAsync(Action<IQiResult> handler)
        {
            if (_received == null)
            {
                _received += handler;
                return RegisterSignalAsync(signalName, OnSignalReceived);
            }
            else
            {
                _received += handler;
                return QiPromise.AlreadyFinished;
            }
        }

        /// <summary>シグナル受信時の処理を登録解除します。</summary>
        /// <param name="handler"><see cref="ConnectAsync(Action{IQiResult})"/>で登録したハンドラ関数</param>
        /// <returns>登録解除の非同期処理状態</returns>
        public IQiFuture DisconnectAsync(Action<IQiResult> handler)
        {
            _received -= handler;
            if (_received == null)
            {
                return UnregisterSignalAsync();
            }
            else
            {
                return QiPromise.AlreadyFinished;
            }
        }

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

        /// <summary>シグナル(イベント)にハンドラを登録します。</summary>
        /// <param name="signature">シグナルの名前("signal"など)</param>
        /// <param name="callback">そのシグナルに対するコールバック関数</param>
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

        private IQiFuture RegisterSignalAsync(string signature, Action<QiValue> callback)
        {
            if (_handler != null)
            {
                throw new InvalidOperationException("handler is aldeady set");
            }

            _handler = new QiSignalHandler(callback);
            var f = QiApiObject.SignalConnect(this, signature, _handler.ApiCallback, IntPtr.Zero);

            f.AddCallback(result =>
            {
                var qv = (result as QiValue);
                if (qv != null)
                {
                    _subscribeId = qv.ToUInt64();
                }
            });

            return f;
        }

        /// <summary>識別IDを指定してシグナルの登録を解除します。</summary>
        private IQiFuture UnregisterSignalAsync()
        {
            //FIXME: この実装だとRegisterSignalAsync完了前にUnregisterSignalAsync呼び出した場合の挙動がちょっと悪い
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
