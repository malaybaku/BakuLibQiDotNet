using System;
using Baku.Websocket.Client;
using SuperSocket.ClientEngine;

namespace Baku.LibqiDotNet.WebSocketImpl
{
    /// <summary>WebSocket4NetによるWebSocketクライアントの実装を表します。</summary>
    public class WebSocket : IWebSocket
    {
        //default constructor is enough
        //public WebSocket() { }

        private WebSocket4Net.WebSocket _ws;

        /// <summary>信頼されていない接続先を許可するかを取得、設定します。</summary>
        public bool AllowUnstrustedCertificate
        {
            get { return _ws?.AllowUnstrustedCertificate ?? false; }
            set
            {
                if (_ws != null)
                {
                    _ws.AllowUnstrustedCertificate = value;
                }
            }
        }

        /// <summary>自動でpingを送信するかを取得、設定します。</summary>
        public bool EnableAutoSendPing
        {
            get { return _ws?.EnableAutoSendPing ?? false; }
            set
            {
                if (_ws != null)
                {
                    _ws.EnableAutoSendPing = value;
                }
            }
        }

        //NOTE: 列挙型の数値をWebSocket4Netのものと合わせてあるのでコレで済むという小技
        /// <summary>WebSocketの現在の接続状態を取得します。</summary>
        public WebSocketState State
            => (WebSocketState)((int)(_ws?.State ?? WebSocket4Net.WebSocketState.None));

        /// <summary>接続が確立されると発生します。</summary>
        public event EventHandler Opened;
        /// <summary>メッセージを受信すると発生します。</summary>
        public event EventHandler Closed;
        /// <summary>通信にエラーが生じると発生します。</summary>
        public event EventHandler<WebSocketErrorEventArgs> Error;
        /// <summary>接続が切断すると発生します。</summary>
        public event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;

        /// <summary>接続先のURLを指定して初期化します。</summary>
        /// <param name="url">接続先URL</param>
        public void InitializeUrl(string url)
        {
            _ws = new WebSocket4Net.WebSocket(url, "", WebSocket4Net.WebSocketVersion.Rfc6455);
            SubscribeWebSocket();
        }

        /// <summary>初期化時に指定したURLへ接続します。</summary>
        public void Open()
        {
            if (_ws == null)
            {
                throw new InvalidOperationException("Websocket is not initialized");
            }
            _ws.Open();
        }

        /// <summary>メッセージを送信します。</summary>
        /// <param name="msg">送信するメッセージ</param>
        public void Send(string msg)
        {
            if (_ws == null)
            {
                throw new InvalidOperationException("Websocket is not initialized");
            }
            _ws.Send(msg);
        }

        /// <summary>接続を切断します。</summary>
        public void Close()
        {
            if (_ws != null)
            {
                _ws.Close();
                UnsubscribeWebSocket();
                _ws = null;
            }
        }

        private void SubscribeWebSocket()
        {
            _ws.Opened += OnWebSocketOpened;
            _ws.Closed += OnWebSocketClosed;
            _ws.Error += OnWebSocketError;
            _ws.MessageReceived += OnWebSocketMessageReceived;
        }

        private void UnsubscribeWebSocket()
        {
            _ws.Opened -= OnWebSocketOpened;
            _ws.Closed -= OnWebSocketClosed;
            _ws.Error -= OnWebSocketError;
            _ws.MessageReceived -= OnWebSocketMessageReceived;
        }

        private void OnWebSocketMessageReceived(object sender, WebSocket4Net.MessageReceivedEventArgs e)
            => MessageReceived?.Invoke(this, new WebSocketMessageReceivedEventArgs(e.Message));

        private void OnWebSocketError(object sender, ErrorEventArgs e)
            => Error?.Invoke(this, new WebSocketErrorEventArgs(e.Exception));

        private void OnWebSocketOpened(object sender, EventArgs e)
            => Opened?.Invoke(this, e);

        private void OnWebSocketClosed(object sender, EventArgs e)
            => Closed?.Invoke(this, e);

    }
}