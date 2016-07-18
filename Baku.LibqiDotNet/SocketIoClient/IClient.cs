using Newtonsoft.Json.Linq;
using SocketIOClient.Messages;
using System;
using WebSocket4Net;

namespace SocketIOClient
{
	/// <summary>C# Socket.IO client interface</summary>
	interface IClient
	{
		event EventHandler Opened;
		event EventHandler<MessageEventArgs> ReceivedMessage;
		event EventHandler Closed;
		event EventHandler<ErrorEventArgs> Error;

		SocketIOHandshake HandShake { get; }
		bool IsConnected { get; }
        WebSocketState ReadyState { get; }

		void Connect();
		IEndPointClient Connect(string endPoint);

		void Close();
		void Dispose();

		void On(string eventName, Action<IMessage> action);
		void On(string eventName, string endPoint, Action<IMessage> action);

		void Emit(string eventName, object payload);
		void Emit(string eventName, object payload, string endPoint, Action<JToken> callBack);
		
		void Send(IMessage msg);
	}
}
