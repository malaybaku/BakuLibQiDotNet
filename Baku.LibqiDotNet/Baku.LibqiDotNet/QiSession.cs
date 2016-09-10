using System;
using Baku.Websocket.Client;

namespace Baku.LibqiDotNet
{
    /// <summary>2種類の異なる通信セッション<see cref="IQiSession"/>をあまり区別せずに扱うためのクラスです。</summary>
    public class QiSession : IQiSession
    {
        internal QiSession(IQiSession session, int port, string protocol)
        {
            _session = session;
            Port = port;
            Protocol = protocol;
        }

        private IQiSession _session;

        /// <summary>接続先のポート番号を取得、設定します。</summary>
        public int Port { get; set; }

        /// <summary>初期接続時に用いるプロトコル文字列("tcp://"または"http://")を取得、設定します。</summary>
        public string Protocol { get; set; }

        #region IQiSession

        /// <summary>指定したアドレスへの接続を試みます。</summary>
        /// <param name="address">接続したいアドレス(IPアドレスで"192.168.xxx.xx"のような形で指定)</param>
        public IQiFuture ConnectAsync(string address)
            => _session.ConnectAsync(Protocol + address + ":" + Port.ToString());

        /// <summary>セッションが接続済みであるかを取得します。</summary>
        public bool IsConnected => _session.IsConnected;

        /// <summary>セッションを閉じます。</summary>
        public void Close() => _session.Close();

        /// <summary>サービス名を指定してサービスを取得します。</summary>
        public IQiFuture<IQiObject> GetServiceAsync(string name)
            => _session.GetServiceAsync(name);

        /// <summary>実際のインスタンスがサービス登録/解除をサポートしているかを取得します。</summary>
        public bool IsServiceRegistrationSupported
            => _session.IsServiceRegistrationSupported;

        /// <summary>セッションをリスンします。</summary>
        /// <param name="address">リスン先アドレスです。例えばアクセスを制限しない場合は"tcp://0.0.0.0:0"を指定します。</param>
        /// <param name="standAlone">アプリケーションがスタンドアロンである場合はtrueにします。通常は設定する必要はありません。</param>
        /// <returns>リスン結果への予約</returns>
        public IQiFuture ListenAsync(string address, bool standAlone) 
            => _session.ListenAsync(address, standAlone);

        /// <summary>サービスに名前を付けて登録します。</summary>
        /// <param name="name">登録するサービス名</param>
        /// <param name="obj">登録するサービス本体</param>
        /// <returns><see cref="UnregisterServiceAsync(uint)"/>の引数で渡すためのIDをGetUInt64で取得してください。</returns>
        public IQiFuture<uint> RegisterServiceAsync(string name, IQiObject obj)
            => _session.RegisterServiceAsync(name, obj);

        /// <summary>IDを指定し、サービスの登録を解除します。</summary>
        /// <param name="idx">解除したいサービスにつけられたID</param>
        public IQiFuture UnregisterServiceAsync(uint idx) => _session.UnregisterServiceAsync(idx);

        /// <summary>
        /// セッションのエンドポイント情報を取得します。
        /// [TODO]エンドポイントの型情報が分かったら内容をI/F化すること
        /// </summary>
        public IQiResult GetEndpoints() => _session.GetEndpoints();

        #endregion

        /// <summary>直接TCP接続する場合の既定の接続ポート番号です。</summary>
        public static readonly int DefaultTcpPort = 9559;

        /// <summary>HTTPで接続する場合の既定の接続ポート番号です。</summary>
        public static readonly int DefaultHttpPort = 8002;

        /// <summary>直接TCP接続する場合のプロトコル文字列です。URLの指定時に用います。</summary>
        public static readonly string TcpProtocolPrefix = "tcp://";

        /// <summary>HTTPで接続する場合のプロトコル文字列です。URLの指定時に用います。</summary>
        public static readonly string HttpProtocolPrefix = "http://";

    }

    public abstract class QiSessionFactoryBase
    {
        /// <summary>
        /// ネイティブライブラリをラップした実装のセッションを作成します。
        /// 実行中のプラットフォームによってはサポートされていないことに注意して使用してください。
        /// </summary>
        /// <returns>セッション</returns>
        public QiSession CreateLibqiSession()
        {
            return new QiSession(Libqi.QiSession.Create(), QiSession.DefaultTcpPort, QiSession.TcpProtocolPrefix);
        }

        /// <summary>
        /// Socket.IOクライアントベースで実装されたセッションを作成します。
        /// この実装ではLibqiの一部機能が利用できないことに注意して使用してください。
        /// </summary>
        /// <returns>セッション</returns>
        public QiSession CreateSocketIoSession()
        {
            var ws = GetWebSocket();
            return new QiSession(new SocketIo.QiSession(ws), QiSession.DefaultHttpPort, QiSession.HttpProtocolPrefix);
        }

        /// <summary>
        /// サブクラスでオーバーライドすることでWebSocketの実装を提供します。
        /// オーバーライドされない場合WebSocketによる接続はできないことに注意してください。
        /// </summary>
        /// <returns></returns>
        protected abstract IWebSocket GetWebSocket();
    }
}
