using System;
using Baku.Websocket.Client;
using SuperSocket.ClientEngine;

namespace Baku.LibqiDotNet.WebSocketImpl
{
    public class WebSocket : IWebSocket
    {
        public WebSocket()
        {
            //do nothing;
        }

        private WebSocket4Net.WebSocket _ws;


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

        //NOTE: —ñ‹“Œ^‚Ì”’l‚ðWebSocket4Net‚Ì‚à‚Ì‚Æ‡‚í‚¹‚Ä‚ ‚é‚Ì‚ÅƒRƒŒ‚ÅÏ‚Þ‚Æ‚¢‚¤¬‹Z
        public WebSocketState State
            => (WebSocketState)((int)(_ws?.State ?? WebSocket4Net.WebSocketState.None));

        public event EventHandler Opened;
        public event EventHandler Closed;
        public event EventHandler<WebSocketErrorEventArgs> Error;
        public event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;

        public void InitializeUrl(string url)
        {
            _ws = new WebSocket4Net.WebSocket(url, "", WebSocket4Net.WebSocketVersion.Rfc6455);
            SubscribeWebSocket();
        }

        public void Open()
        {
            if (_ws == null)
            {
                throw new InvalidOperationException("Websocket is not initialized");
            }
            _ws.Open();
        }

        public void Send(string msg)
        {
            if (_ws == null)
            {
                throw new InvalidOperationException("Websocket is not initialized");
            }
            _ws.Send(msg);
        }

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