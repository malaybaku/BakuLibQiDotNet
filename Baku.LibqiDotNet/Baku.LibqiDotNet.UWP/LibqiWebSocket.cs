using System;
using Windows.Networking.Sockets;
using Baku.Websocket.Client;
using Windows.Storage.Streams;

namespace Baku.LibqiDotNet.UWP
{
    /// <summary>UWPのWebSocketをラップしたWebSocketクライアントを表します。</summary>
    public class LibqiWebSocket : Baku.Websocket.Client.IWebSocket
    {
        /// <summary>既定の設定でインスタンスを初期化します。</summary>
        public LibqiWebSocket()
        {
            _ws = new MessageWebSocket();
            _ws.Control.MessageType = SocketMessageType.Utf8;
            _ws.Closed += OnWebSocketClosed;
            _ws.MessageReceived += OnWebSocketMessageReceived;
        }

        private void OnWebSocketMessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
        {
            if (args.MessageType != SocketMessageType.Utf8)
            {
                return;
            }

            DataReader dataReader = args.GetDataReader();
            dataReader.UnicodeEncoding = UnicodeEncoding.Utf8;
            string message = dataReader.ReadString(dataReader.UnconsumedBufferLength);
            MessageReceived?.Invoke(this, new WebSocketMessageReceivedEventArgs(message));
        }

        private void OnWebSocketClosed(Windows.Networking.Sockets.IWebSocket sender, WebSocketClosedEventArgs args)
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        private MessageWebSocket _ws;

        /// <summary>
        /// 信頼されていない接続先への接続許可を取得、設定します。
        /// この実装では常に接続は許可されます。
        /// </summary>
        public bool AllowUnstrustedCertificate
        {
            get { return true; }
            set
            {
                //do nothing
            }
        }

        /// <summary>
        /// 自動でのping送信許可を取得、設定します。
        /// この実装では自動ping送信は常に行われません。
        /// </summary>
        public bool EnableAutoSendPing
        {
            get { return false; }
            set
            {
                //do nothing
            }
        }

        private object _stateLock = new object();
        private WebSocketState _state = WebSocketState.Closed;
        /// <summary>WebSocketの通信状態を取得、設定します。</summary>
        public WebSocketState State
        {
            get { lock(_stateLock) { return _state; } }
            private set { lock (_stateLock) { _state = value; } }
        }

        /// <summary>通信が切断すると発生します。</summary>
        public event EventHandler Closed;
        /// <summary>通信エラー時に発生します。</summary>
        public event EventHandler<WebSocketErrorEventArgs> Error;
        /// <summary>メッセージ受信時に発生します。</summary>
        public event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;
        /// <summary>接続が確立すると発生します。</summary>
        public event EventHandler Opened;

        private Uri _uri;

        /// <summary>接続を切断します。</summary>
        public void Close()
        {
            State = WebSocketState.Closing;
            _ws.Close(0, "");
            State = WebSocketState.Closed;
        }

        /// <summary>接続先URLを指定して初期化を行います。</summary>
        /// <param name="url">接続先URL</param>
        public void InitializeUrl(string url)
        {
            _uri = new Uri(url);
        }

        /// <summary><see cref="InitializeUrl(string)"/>で指定した接続先に接続します。</summary>
        public void Open()
        {
            if (State == WebSocketState.Open || State == WebSocketState.Connecting)
            {
                return;
            }

            State = WebSocketState.Connecting;
            _ws.ConnectAsync(_uri).AsTask().Wait();
            State = WebSocketState.Open;
        }

        /// <summary>メッセージを送信します。</summary>
        /// <param name="msg">送信するメッセージテキスト</param>
        public void Send(string msg)
        {
            if (State != WebSocketState.Open)
            {
                throw new InvalidOperationException("WebSocket is not open");
            }

            var dataWriter = new DataWriter(_ws.OutputStream);
            dataWriter.WriteString(msg);
            dataWriter.StoreAsync().AsTask().Wait();
            dataWriter.DetachStream();
        }
    }
}
