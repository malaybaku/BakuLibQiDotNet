using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>通信セッションを表します。</summary>
    public class QiSession
    {
        internal QiSession(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>セッションが接続済みであるかを取得します。</summary>
        public bool IsConnected => QiApiSession.IsConnected(this);

        /// <summary>
        /// 非接続状態で新しくセッションを生成します。
        /// </summary>
        /// <returns></returns>
        public static QiSession Create() => QiApiSession.Create();

        /// <summary>
        /// 接続先アドレスを指定し、接続が完了した状態のセッションを取得します。
        /// </summary>
        /// <param name="address">接続先のアドレス</param>
        /// <returns>接続済みのセッション</returns>
        public static QiSession Create(string address)
        {
            var result = Create();
            result.Connect(address).Wait();
            return result;
        }

        /// <summary>
        /// 指定したアドレスへの接続を試みます。
        /// </summary>
        /// <param name="address">接続先アドレス</param>
        /// <returns>接続結果への取得予約</returns>
        public QiFuture Connect(string address) => QiApiSession.Connect(this, address);

        /// <summary>
        /// サービス名の一覧を取得します。
        /// </summary>
        /// <returns>サービス一覧</returns>
        public QiFuture GetServices()
        {
            ThrowIfNotConnected();
            return QiApiSession.GetServices(this);
        }

        /// <summary>
        /// サービス名を指定してサービスを取得します。
        /// </summary>
        /// <param name="name">サービス名</param>
        /// <returns>サービス名に対応した<see cref="QiObject"/>の取得予約</returns>
        public QiFuture GetService(string name)
        {
            ThrowIfNotConnected();
            return QiApiSession.GetService(this, name);
        }

        /// <summary>
        /// セッションを閉じます。
        /// </summary>
        /// <returns>未確認</returns>
        public QiFuture Close() => QiApiSession.Close(this);

        /// <summary>セッションを破棄します。</summary>
        public void Destroy() => QiApiSession.Destroy(this);

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

        /// <summary>
        /// (動作未確認)セッションをリスンします。
        /// </summary>
        /// <param name="address"></param>
        /// <param name="standAlone"></param>
        /// <returns></returns>
        public QiFuture Listen(string address, bool standAlone = false)
        {
            ThrowIfNotConnected();
            return QiApiSession.Listen(this, address, standAlone);
        }

        /// <summary>
        /// サービスに名前を付けて登録します。
        /// </summary>
        /// <param name="name">サービス名</param>
        /// <param name="obj">サービスの実体</param>
        /// <returns>未確認(たぶんサービスのID)</returns>
        public QiFuture RegisterService(string name, QiObject obj)
        {
            ThrowIfNotConnected();
            return QiApiSession.RegisterService(this, name, obj);
        }

        /// <summary>
        /// IDを指定してサービスを登録解除します。
        /// </summary>
        /// <param name="idx">解除の対象となるサービスのID</param>
        /// <returns>未確認</returns>
        public QiFuture UnregisterService(uint idx)
        {
            ThrowIfNotConnected();
            return QiApiSession.UnregisterService(this, idx);
        }

        /// <summary>
        /// セッションのエンドポイントを取得します。
        /// </summary>
        /// <returns>エンドポイント情報</returns>
        public QiValue GetEndpoints() => QiApiSession.GetEndpoints(this);

        private void ThrowIfNotConnected()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Connection is not established");
            }
        }
    }


}
