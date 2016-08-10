using System;
using Windows.Networking.Sockets;
using Baku.Websocket.Client;
using Windows.Storage.Streams;

namespace Baku.LibqiDotNet.UWP
{
    public class LibqiWebSocket : Baku.Websocket.Client.IWebSocket
    {
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

        public bool AllowUnstrustedCertificate
        {
            get { return true; }
            set
            {
                //do nothing
            }
        }

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
        public WebSocketState State
        {
            get { lock(_stateLock) { return _state; } }
            set { lock (_stateLock) { _state = value; } }
        }

        public event EventHandler Closed;
        public event EventHandler<WebSocketErrorEventArgs> Error;
        public event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;
        public event EventHandler Opened;

        private Uri _uri;

        public void Close()
        {
            State = WebSocketState.Closing;
            _ws.Close(0, "");
            State = WebSocketState.Closed;
        }

        public void InitializeUrl(string url)
        {
            _uri = new Uri(url);
        }

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

        public void Send(string msg)
        {
            if (State != WebSocketState.Open)
            {
                throw new InvalidOperationException("WebSocket is not open");
            }

            var dataWriter = new DataWriter(_ws.OutputStream);
            dataWriter.WriteString(msg);
            dataWriter.StoreAsync().AsTask().Wait();
        }
    }
}
