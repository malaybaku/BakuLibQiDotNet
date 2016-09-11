using System;
using SocketIOClient.Messages;
using Newtonsoft.Json.Linq;
using Baku.Websocket.Client;

namespace SocketIOClient
{
    /// <summary>C# Socket.IO client interface</summary>
    public interface IClient
	{
        /// <summary>通信が確立すると発生します。</summary>
		event EventHandler Opened;
        /// <summary>メッセージを受信すると発生します。</summary>
		event EventHandler<MessageEventArgs> ReceivedMessage;
        /// <summary>通信が切断すると発生します。</summary>
		event EventHandler Closed;
        /// <summary>通信時にエラーが起きると発生します。</summary>
		event EventHandler<ErrorEventArgs> Error;

        /// <summary>ハンドシェーク処理設定を取得します、</summary>
		SocketIOHandshake HandShake { get; }
        /// <summary>接続済みかどうかを取得します。</summary>
		bool IsConnected { get; }
        /// <summary>接続時のパスを取得、設定します。</summary>
        string Path { get; set; }

        /// <summary>URLを指定して接続します。</summary>
        /// <param name="url">接続先URL</param>
        /// <param name="ws">接続の元となるWebSocketの実装</param>
		void Connect(string url, IWebSocket ws);

        /// <summary>接続を切断します。</summary>
		void Close();
        /// <summary>接続を切断し、リソースを解放します。</summary>
		void Dispose();

        /// <summary>イベント発生時のハンドラ処理を登録します。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="action">コールバック処理</param>
		void On(string eventName, Action<IMessage> action);
        /// <summary>イベント発生時のハンドラ処理を登録します。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="endPoint">エンドポイント</param>
        /// <param name="action">コールバック処理</param>
		void On(string eventName, string endPoint, Action<IMessage> action);

        /// <summary>イベントを発生させます。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="payload">イベントに付随させるデータ</param>
		void Emit(string eventName, object payload);
        /// <summary>イベントを発生させます。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="payload">イベントに付随させるデータ</param>
        /// <param name="endPoint">エンドポイント</param>
        /// <param name="callBack">コールバック処理</param>
		void Emit(string eventName, object payload, string endPoint, Action<JToken> callBack);

		/// <summary>メッセージを送信します。</summary>
        /// <param name="msg">メッセージ</param>
		void Send(IMessage msg);

	}
}
