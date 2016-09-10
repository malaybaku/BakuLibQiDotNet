using System.Text.RegularExpressions;

namespace SocketIOClient.Messages
{
    /// <summary>
    /// All Socket.IO messages have to be encoded before they're sent, and decoded when they're received.
    /// They all have the format of: [message type] ':' [message id ('+')] ':' [message endpoint] (':' [message data])
    /// </summary>
    public abstract class Message : IMessage
    {
        private static readonly Regex re = new Regex(@"\d:\d?:\w?:");
        /// <summary>Socket.ioでデータを区切る文字です。</summary>
        public  static readonly char[] SPLITCHARS = new[] { ':' };

        /// <summary>受信時の状態から加工していないそのままの文字列を取得します。</summary>
		public string RawMessage { get; protected set; }

		/// <summary>
		/// The message type represents a single digit integer [0-8].
		/// </summary>
        public SocketIOMessageTypes MessageType { get; protected set; }

		/// <summary>
		/// The message id is an incremental integer, required for ACKs (can be ommitted). 
		/// If the message id is followed by a +, the ACK is not handled by socket.io, but by the user instead.
		/// </summary>
		public int? AckId { get; set; }

		/// <summary>
		/// Socket.IO has built-in support for multiple channels of communication (which we call "multiple sockets"). 
		/// Each socket is identified by an endpoint (can be omitted).
		/// </summary>
		public string Endpoint { get; set; }

		/// <summary>
		/// String value of the message
		/// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// String value of the Event
        /// </summary>
        public virtual string Event { get; set; }

        /// <summary>
        /// <para>Messages have to be encoded before they're sent. The structure of a message is as follows:</para>
        /// <para>[message type] ':' [message id ('+')] ':' [message endpoint] (':' [message data])</para>
        /// <para>All message payloads are sent as strings</para>
        /// </summary>
        public virtual string Encoded 
        {
            get
            {
                return string.Format("{0}:{1}:{2}:{3}", 
                    (int)MessageType, 
                    AckId.HasValue ? AckId.Value.ToString() : "", 
                    Endpoint, 
                    MessageText);
            }
        }
       
        /// <summary>メッセージインスタンスを初期化します。</summary>
        public Message() 
        {
            MessageType = SocketIOMessageTypes.Message;
        }

        /// <summary>生のメッセージ文字列を用いてインスタンスを初期化します。</summary>
        /// <param name="rawMessage">メッセージ文字列</param>
        public Message(string rawMessage) : this()
        {
            RawMessage = rawMessage;

            string[] args = rawMessage.Split(SPLITCHARS, 4);
            if (args.Length == 4)
            {
                int id;
                if (int.TryParse(args[1], out id))
                {
                    AckId = id;
                }
                Endpoint = args[2];
                MessageText = args[3];
            }
        }

		private static readonly Regex _reMessageType = new Regex("^[0-8]{1}:", RegexOptions.IgnoreCase);
        /// <summary>生のメッセージをもとに対応する種類のメッセージを生成します。</summary>
        /// <param name="rawMessage">Socket.ioプロトコル準拠な生の文字列</param>
        /// <returns>対応するメッセージ</returns>
        public static IMessage Factory(string rawMessage)
		{
            //bad format message
            if (!_reMessageType.IsMatch(rawMessage))
            {
                return new NoopMessage();
            }

            char id = rawMessage[0]; 
			switch (id)
			{
				case '0':
					return DisconnectMessage.Deserialize(rawMessage);
				case '1':
					return ConnectMessage.Deserialize(rawMessage);
				case '2':
					return Heartbeat.Instance;
				case '3':
					return TextMessage.Deserialize(rawMessage);
				case '4':
					return JSONMessage.Deserialize(rawMessage);
				case '5':
					return EventMessage.Deserialize(rawMessage);
				case '6':
					return AckMessage.Deserialize(rawMessage);
				case '7':
					return ErrorMessage.Deserialize(rawMessage);
				case '8':
					return new NoopMessage();
				default:
                    //must not come here
					return new TextMessage();
			}
		}
    }
}
