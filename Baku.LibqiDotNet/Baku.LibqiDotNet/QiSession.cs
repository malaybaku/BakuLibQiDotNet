using System;

namespace Baku.LibqiDotNet
{
    /// <summary>プラットフォームに合わせた適切な通信セッション<see cref="IQiSession"/>を生成する機能を提供します。</summary>
    public class QiSession : IQiSession
    {
        private QiSession(IQiSession session, int port, string protocol)
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


        /// <summary>プラットフォームに応じて適切な方式のセッションを選択、生成します。</summary>
        public static QiSession CreateSession()
        {
            //本当にやりたいこと: プラットフォーム判定(Windows && 32bit / Mac && 64bitのときだけLibqiを尊重)
            //…なのだが、Windows Phoneとかでうまく捌けないことを考えて苦肉の策をやるんですねえ。

#if UNITY_STANDALONE_WIN
            if (IntPtr.Size == 4)
            {
            }
            else
            {
            }
#elif UNITY_STANDALONE_OSX
            if (IntPtr.Size == 8)
            {
            }
            else
            {
            }
#else
            //純.NET版もこのケースに含むものとする
            string osVer = Environment.OSVersion.ToString(); 
            if ((osVer.Contains("Windows") && IntPtr.Size == 4) ||
                (osVer.Contains("OSX") && IntPtr.Size == 8))
            {
                return CreateLibqiSession();
            }
            else
            {
                return CreateSocketIoSession();
            }
#endif
        }

        /// <summary>
        /// 明示的にLibqi実装のセッションを作成します。
        /// 実行中のプラットフォームによってはLibqi実装が利用できないことに十分注意して使用してください。
        /// </summary>
        /// <returns>セッション。</returns>
        public static QiSession CreateLibqiSession()
        {
            return new QiSession(Libqi.QiSession.Create(), DefaultTcpPort, TcpProtocolPrefix);
        }

        /// <summary>
        /// 明示的にSocket.IO実装のセッションを作成します。
        /// SocketIoでは一部機能が利用できないことに十分注意して使用してください。
        /// </summary>
        /// <returns>セッション。</returns>
        public static QiSession CreateSocketIoSession()
        {
            return new QiSession(new SocketIo.QiSession(), DefaultHttpPort, HttpProtocolPrefix);
        }


    }
}
