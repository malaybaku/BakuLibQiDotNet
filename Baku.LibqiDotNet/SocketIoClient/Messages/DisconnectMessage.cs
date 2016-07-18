
namespace SocketIOClient.Messages
{
    /// <summary>
    /// Signals disconnection. If no endpoint is specified, disconnects the entire socket.
    /// </summary>
    /// <remarks>Disconnect a socket connected to the /test endpoint:
    ///		0::/test
    /// </remarks>
    public class DisconnectMessage : Message
	{
        public override string Event => "disconnect";

		public DisconnectMessage() : base()
		{
            MessageType = SocketIOMessageTypes.Disconnect;
		}
		public DisconnectMessage(string endPoint) : this()
		{
            Endpoint = endPoint;
		}

		public static DisconnectMessage Deserialize(string rawMessage)
		{
            //  0::
            //  0::/test
            var msg = new DisconnectMessage() { RawMessage = rawMessage };

			string[] args = rawMessage.Split(SPLITCHARS, 3);
			if (args.Length == 3 && !string.IsNullOrEmpty(args[2]))
            {
                msg.Endpoint = args[2];
            }
			return msg;
		}

        public override string Encoded => $"0::{Endpoint}";

    }
}
