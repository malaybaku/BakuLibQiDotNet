
namespace SocketIOClient.Messages
{
    public class TextMessage : Message
    {
        public TextMessage()
        {
            MessageType = SocketIOMessageTypes.Message;
        }
		public TextMessage(string textMessage) : this()
		{
            MessageText = textMessage;
		}

        public override string Event => "message";

        public static TextMessage Deserialize(string rawMessage)
        {
            //  '3:' [message id ('+')] ':' [message endpoint] ':' [data]
            //   3:1::blabla
            var msg = new TextMessage() { RawMessage = rawMessage };

            string[] args = rawMessage.Split(SPLITCHARS, 4);
			if (args.Length == 4)
			{
				int id;
				if (int.TryParse(args[1], out id))
                {
                    msg.AckId = id;
                }
                msg.Endpoint = args[2];
				msg.MessageText = args[3];
			}
			else
            {
                msg.MessageText = rawMessage;
            }

            return msg;
        }
    }
}
