
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
        /// <summary>イベント名を取得します。</summary>
        public override string Event => "disconnect";

        /// <summary>既定の設定でインスタンスを初期化します。</summary>
		public DisconnectMessage() : base()
		{
            MessageType = SocketIOMessageTypes.Disconnect;
		}
        /// <summary>エンドポイントを指定してインスタンスを初期化します。</summary>
        /// <param name="endPoint">エンドポイント</param>
		public DisconnectMessage(string endPoint) : this()
		{
            Endpoint = endPoint;
		}

        /// <summary>受信したメッセージから対応する切断メッセージを取得します。</summary>
        /// <param name="rawMessage">受信したsocket.ioプロトコル準拠なメッセージ</param>
        /// <returns>対応する切断メッセージ</returns>
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

        /// <summary>切断メッセージを取得します。</summary>
        public override string Encoded => $"0::{Endpoint}";

    }
}
