using System;
using SocketIOClient.Messages;
using Newtonsoft.Json.Linq;
using Baku.Websocket.Client;

namespace SocketIOClient
{
    /// <summary>C# Socket.IO client interface</summary>
    public interface IClient
	{
		event EventHandler Opened;
		event EventHandler<MessageEventArgs> ReceivedMessage;
		event EventHandler Closed;
		event EventHandler<ErrorEventArgs> Error;

		SocketIOHandshake HandShake { get; }
		bool IsConnected { get; }
        string Path { get; set; }

		void Connect(string url, IWebSocket ws);

		void Close();
		void Dispose();

		void On(string eventName, Action<IMessage> action);
		void On(string eventName, string endPoint, Action<IMessage> action);

		void Emit(string eventName, object payload);
		void Emit(string eventName, object payload, string endPoint, Action<JToken> callBack);
		
		void Send(IMessage msg);
	}
}
