using System;
using System.Linq;
using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>通信セッションを表します。</summary>
    public sealed class QiSession : IQiSession
    {
        //GetServicesの仕様で一つのサービスは6要素タプルからなり、第0要素にサービス名が入っている
        const int ServiceNameIndexInServicesObject = 0;

        internal QiSession(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>セッションが接続済みであるかを取得します。</summary>
        public bool IsConnected => QiApiSession.IsConnected(this);

        /// <summary>非接続状態のセッションを新たに生成します。</summary>
        /// <returns>新規生成されたセッション</returns>
        public static IQiSession Create() => QiApiSession.Create();

        /// <summary>接続先アドレスを指定し、接続が完了した状態のセッションを取得します。</summary>
        /// <param name="address">接続先のアドレス</param>
        /// <returns>接続済みのセッション</returns>
        public static IQiSession Create(string address)
        {
            var result = Create();
            result.Connect(address);
            return result;
        }

        /// <summary>指定したアドレスへの接続を試みます。</summary>
        /// <param name="address">接続先アドレス</param>
        /// <returns>接続結果への取得予約</returns>
        public IQiFuture ConnectAsync(string address) => QiApiSession.Connect(this, address);

        /// <summary>サービス名の一覧を取得します。</summary>
        /// <returns>サービス一覧</returns>
        public IQiFuture<IQiResult> GetServicesAsync()
        {
            ThrowIfNotConnected();
            return QiApiSession.GetServices(this).WillReturns<IQiResult>();
        }

        /// <summary>サービス一覧を文字列の配列として取得します。</summary>
        /// <returns>サービスの一覧</returns>
        public string[] GetServices()
        {
            IQiResult sList = GetServicesAsync().Get();
            return Enumerable
                .Range(0, sList.Count)
                .Select(i => sList[i][ServiceNameIndexInServicesObject].ToString())
                .ToArray();
        }

        /// <summary>サービス名を指定してサービスを取得します。</summary>
        /// <param name="name">サービス名</param>
        /// <returns>サービス名に対応した<see cref="IQiObject"/>の取得予約</returns>
        public IQiFuture<IQiObject> GetServiceAsync(string name)
        {
            ThrowIfNotConnected();
            return QiApiSession.GetService(this, name).WillReturns<IQiObject>();
        }

        /// <summary>セッションを閉じます。</summary>
        public void Close() => CloseAsync().Wait();

        /// <summary>セッションを閉じます。</summary>
        /// <returns>未確認</returns>
        public QiFuture CloseAsync() => QiApiSession.Close(this);

        /// <summary>
        /// (動作未確認)セッションに対応したURLを取得します。
        /// </summary>
        /// <returns></returns>
        public string GetUrl() => QiApiSession.GetUrl(this);

        /// <summary>
        /// (動作未確認)セッションの一意識別子を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="crt"></param>
        /// <returns></returns>
        public int SetIdentity(string key, string crt) => QiApiSession.SetIdentity(this, key, crt);

        /// <summary>セッションをリスンします。</summary>
        /// <param name="address">リスン先アドレスです。例えばアクセスを制限しない場合は"tcp://0.0.0.0:0"を指定します。</param>
        /// <param name="standAlone">アプリケーションがスタンドアロンである場合はtrueにします。通常は設定する必要はありません。</param>
        /// <returns>リスン結果への予約</returns>
        public IQiFuture ListenAsync(string address, bool standAlone = false) 
            => QiApiSession.Listen(this, address, standAlone);

        /// <summary>サービスに名前を付けて登録します。</summary>
        /// <param name="name">サービス名</param>
        /// <param name="obj">サービスの実体</param>
        /// <returns>未確認(たぶんサービスのID)</returns>
        public IQiFuture<uint> RegisterServiceAsync(string name, IQiObject obj)
        {
            ThrowIfNotConnected();

            var qiObj = obj as QiObject;
            if (qiObj == null)
            {
                throw new InvalidOperationException("obj arg was not Baku.LibqiDotNet.Libqi.QiObject");
            }

            return QiApiSession.RegisterService(this, name, qiObj).WillReturns<uint>();
        }

        /// <summary>
        /// IDを指定してサービスを登録解除します。
        /// </summary>
        /// <param name="idx">解除の対象となるサービスのID</param>
        /// <returns>未確認</returns>
        public IQiFuture UnregisterServiceAsync(uint idx)
        {
            ThrowIfNotConnected();
            return QiApiSession.UnregisterService(this, idx);
        }

        /// <summary>セッションのエンドポイントを取得します。</summary>
        /// <returns>エンドポイント情報</returns>
        public IQiResult GetEndpoints() => QiApiSession.GetEndpoints(this);

        private void ThrowIfNotConnected()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Connection is not established");
            }
        }
    }


}
