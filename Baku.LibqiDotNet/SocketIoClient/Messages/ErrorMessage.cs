namespace SocketIOClient.Messages
{
    public class ErrorMessage : Message
    {
		public string Reason { get; set; }
		public string Advice { get; set; }

		public override string Event => "error";

		public ErrorMessage()
        {
            MessageType = SocketIOMessageTypes.Error;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rawMessage">'7::' [endpoint] ':' [reason] '+' [advice]</param>
		/// <returns>ErrorMessage</returns>
		public static ErrorMessage Deserialize(string rawMessage)
		{
            var msg = new ErrorMessage() { RawMessage = rawMessage };

			string[] args = rawMessage.Split(':');
			if (args.Length == 4)
			{
				msg.Endpoint = args[2];
				msg.MessageText = args[3];
				string[] complex = args[3].Split('+');
				if (complex.Length > 1)
				{
					msg.Advice = complex[1];
					msg.Reason = complex[0];
				}
			}
			return msg;
		}
    }
}
