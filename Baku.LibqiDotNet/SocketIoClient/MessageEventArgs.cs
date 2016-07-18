using System;
using SocketIOClient.Messages;

namespace SocketIOClient
{
    public class MessageEventArgs : EventArgs
	{
		public IMessage Message { get; }

		public MessageEventArgs(IMessage msg)
		{
            Message = msg;
		}
	}
}
