
namespace SocketIOClient.Messages
{
    /// <summary>プレーンなテキストメッセージを表します。</summary>
    public class TextMessage : Message
    {
        /// <summary>既定の内容でインスタンスを初期化します。</summary>
        public TextMessage()
        {
            MessageType = SocketIOMessageTypes.Message;
        }
        /// <summary>送信するメッセージを指定してインスタンスを初期化します。</summary>
        /// <param name="textMessage">送信するメッセージ</param>
		public TextMessage(string textMessage) : this()
		{
            MessageText = textMessage;
		}

        /// <summary>イベント文字列を取得します。</summary>
        public override string Event => "message";

        /// <summary>生のSocket.IO文字列から対応するテキストメッセージを取得します。</summary>
        /// <param name="rawMessage">Socket.IOのプロトコルに従った文字列</param>
        /// <returns>デシリアライズされたメッセージ</returns>
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
