using System;
using Newtonsoft.Json.Linq;

namespace SocketIOClient
{
    public interface IEndPointClient
	{
		void On(string eventName, Action<Messages.IMessage> action);
		void Emit(string eventName, object payload, Action<JToken> callBack);

		void Send(Messages.IMessage msg);
	}
}
