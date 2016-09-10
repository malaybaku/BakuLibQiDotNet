using System;

namespace Baku.Websocket.Client
{
    /// <summary>
    /// WebSocketクライアントに必要な処理を定義します。
    /// この定義はNuGetで公開されているパッケージであるWebSocket4Netに準じています。
    /// </summary>
    public interface IWebSocket
    {

        /// <summary>信頼されていない接続先を許可するかを取得、設定します。</summary>
        bool AllowUnstrustedCertificate { get; set; }
        /// <summary>自動でpingを送信するかを取得、設定します。</summary>
        bool EnableAutoSendPing { get; set; }

        /// <summary>接続が確立されると発生します。</summary>
        event EventHandler Opened;
        /// <summary>メッセージを受信すると発生します。</summary>
        event EventHandler<WebSocketMessageReceivedEventArgs> MessageReceived;
        /// <summary>通信にエラーが生じると発生します。</summary>
        event EventHandler<WebSocketErrorEventArgs> Error;
        /// <summary>接続が切断すると発生します。</summary>
        event EventHandler Closed;

        /// <summary>接続先のURLを指定して初期化します。</summary>
        /// <param name="url">接続先URL</param>
        void InitializeUrl(string url);

        /// <summary>初期化時に指定したURLへ接続します。</summary>
        void Open();
        /// <summary>接続を切断します。</summary>
        void Close();
        /// <summary>メッセージを送信します。</summary>
        /// <param name="msg">送信するメッセージ</param>
        void Send(string msg);

        /// <summary>WebSocketの現在の接続状態を取得します。</summary>
        WebSocketState State { get; }
    }

    /// <summary>WebSocketによりメッセージを受信した際のイベントデータを表します。</summary>
    public class WebSocketMessageReceivedEventArgs : EventArgs
    {
        /// <summary>受信したメッセージの内容でイベントデータを初期化します。</summary>
        /// <param name="msg">受信したメッセージ</param>
        public WebSocketMessageReceivedEventArgs(string msg)
        {
            Message = msg;
        }

        /// <summary>受信したメッセージを取得します。</summary>
        public string Message { get; }
    }

    /// <summary>通信にエラーが生じた際のイベントデータを表します。</summary>
    public class WebSocketErrorEventArgs : EventArgs
    {
        /// <summary>エラーの内容を表す例外インスタンスでイベントデータを初期化します。</summary>
        /// <param name="ex">エラー内容</param>
        public WebSocketErrorEventArgs(Exception ex)
        {
            Exception = ex;
        }

        /// <summary>エラーの内容を取得します。</summary>
        public Exception Exception { get; }
    }

    /// <summary>WebSocketの状態を表します。</summary>
    public enum WebSocketState
    {
        /// <summary>WebSocketが未使用の状態</summary>
        None = -1,
        /// <summary>WebSocketが接続を試みている状態</summary>
        Connecting = 0,
        /// <summary>WebSocketの接続が確立された状態</summary>
        Open = 1,
        /// <summary>WebSocketを切断中の状態</summary>
        Closing = 2,
        /// <summary>WebSocketが切断済みの状態</summary>
        Closed = 3
    }
}
