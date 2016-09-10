
namespace SocketIOClient.Messages
{
    /// <summary>
    /// Signals a connection to the endpoint. Once the server receives it, it's echoed back to the client
    /// </summary>
    /// <remarks>If the client is trying to connect to the endpoint /test, a message like this will be delivered:
    ///		'1::' [path] [query]
    /// </remarks>
    public class ConnectMessage : Message
	{
        /// <summary>接続時のクエリ文字列を取得します。</summary>
		public string Query { get; private set; }

        /// <summary>イベント名を取得します。</summary>
        public override string Event => "connect";

        /// <summary>既定の設定でインスタンスを初期化します。</summary>
		public ConnectMessage() : base()
		{
            MessageType = SocketIOMessageTypes.Connect;
		}
        /// <summary>エンドポイントを指定してインスタンスを初期化します。</summary>
        /// <param name="endPoint">エンドポイント</param>
		public ConnectMessage(string endPoint) : this()
		{
            Endpoint = endPoint;
		}

        /// <summary>受信したメッセージから対応する接続メッセージを生成します。</summary>
        /// <param name="rawMessage">受信時のsocket.ioプロトコル準拠なメッセージ</param>
        /// <returns>対応するメッセージ</returns>
		public static ConnectMessage Deserialize(string rawMessage)
		{
            //  1:: [path] [query]
            //  1::/test?my=param
            var msg = new ConnectMessage() { RawMessage = rawMessage };

			string[] args = rawMessage.Split(SPLITCHARS, 3);
			if (args.Length == 3)
			{
				string[] pq = args[2].Split('?');

				if (pq.Length > 0)
                {
                    msg.Endpoint = pq[0];
                }

                if (pq.Length > 1)
                {
                    msg.Query = pq[1];
                }
            }
			return msg;
		}

        /// <summary>設定をもとにした送信時のメッセージ文字列を取得します。</summary>
        public override string Encoded
		{
			get
			{
				return string.Format("1::{0}{1}", 
                    Endpoint, 
                    string.IsNullOrEmpty(Query) ? "" : "?" + Query
                    );
			}
		}
	}
}
