using System;

namespace Baku.Websocket.Client
{
    public interface IWebSocket
    {

        bool AllowUnstrustedCertificate { get; set; }
        bool EnableAutoSendPing { get; set; }

        event EventHandler Opened;
        event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;
        event EventHandler<WebSocketErrorEventArgs> Error;
        event EventHandler Closed;

        void InitializeUrl(string url);

        void Open();
        void Close();
        void Send(string msg);

        WebSocketState State { get; }
    }

    public class WebSocketMessageReceivedEventArgs : EventArgs
    {
        public WebSocketMessageReceivedEventArgs(string msg)
        {
            Message = msg;
        }

        public string Message { get; }
    }

    public class WebSocketErrorEventArgs : EventArgs
    {
        public WebSocketErrorEventArgs(Exception ex)
        {
            Exception = ex;
        }

        public Exception Exception { get; }
    }

    public enum WebSocketState
    {
        None = -1,
        Connecting = 0,
        Open = 1,
        Closing = 2,
        Closed = 3
    }
}
