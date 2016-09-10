namespace SocketIOClient.Messages
{
    /// <summary>エラー通知メッセージを表します。</summary>
    public class ErrorMessage : Message
    {
        /// <summary>エラーの理由を表す文字列を取得、設定します。</summary>
		public string Reason { get; set; }
        /// <summary>エラーの対策などを表す文字列を取得、設定します。</summary>
		public string Advice { get; set; }
        /// <summary>イベント名を取得します。</summary>
		public override string Event => "error";

        /// <summary>既定の設定でインスタンスを初期化します。</summary>
		public ErrorMessage()
        {
            MessageType = SocketIOMessageTypes.Error;
        }

		/// <summary>メッセージ文字列から対応するメッセージを取得します。</summary>
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
