using System;
using System.Text.RegularExpressions;

namespace SocketIOClient.Messages
{
    /// <summary>Ackメッセージを表します。</summary>
    public sealed class AckMessage : Message
	{
		private static Regex reAckId = new Regex(@"^(\d{1,})");
 		private static Regex reAckPayload = new Regex(@"(?:[\d\+]*)(?<data>.*)$");
		private static Regex reAckComplex = new Regex(@"^\[(?<payload>.*)\]$");

		private static object ackLock = new object();
		private static int _akid = 0;
        /// <summary>Ack IDとして使用可能な次の値を取得します。</summary>
		public static int NextAckID
		{
			get
			{
				lock (ackLock)
				{
					_akid++;
					if (_akid < 0)
                    {
                        _akid = 0;
                    }
                    return _akid;
				}
			}
		}

        /// <summary>コールバック処理を取得、設定します。</summary>
		public Action Callback;

        /// <summary>既定の設定でインスタンスを初期化します。</summary>
		public AckMessage() : base()
        {
            MessageType = SocketIOMessageTypes.ACK;
        }
		
        /// <summary>受信メッセージから対応するAckメッセージを生成します。</summary>
        /// <param name="rawMessage">socket.ioプロトコル準拠なメッセージ</param>
        /// <returns>対応するメッセージ</returns>
		public static AckMessage Deserialize(string rawMessage)
        {
            //  '6:::' [message id] '+' [data]
            //   6:::4
            //	 6:::4+["A","B"]
            var msg = new AckMessage() { RawMessage = rawMessage };

            //TODO: これだと'+'が無いとき(たぶん空のイベントってそういうフォーマットだと思うのだけど)
            //      イベントのAckIdが拾えないのでは。
            string[] args = rawMessage.Split(SPLITCHARS, 4);
            if (args.Length == 4)
            {
				msg.Endpoint = args[2];
                //restrict max to 2, because for example, ack result value may contains str "+"
				string[] parts = args[3].Split(new char[] {'+'}, 2);
				if (parts.Length > 1)
				{
                    int id;
                    if (int.TryParse(parts[0], out id))
					{
						msg.AckId = id;
						Match payloadMatch = reAckComplex.Match(parts[1]);
						if (payloadMatch.Success)
						{
                            msg.MessageText = payloadMatch.Groups["payload"].Value;
						}
					}
				}
            }
			return msg;
        }

        /// <summary>設定をもとに送信メッセージを取得します。</summary>
		public override string Encoded
		{
			get
			{
				int msgId = (int)MessageType;
				if (AckId.HasValue)
				{
					if (Callback == null)
                    {
                        return string.Format("{0}:{1}:{2}:{3}", msgId, AckId.Value, Endpoint, MessageText);
                    }
                    else
                    {
                        return string.Format("{0}:{1}+:{2}:{3}", msgId, AckId.Value, Endpoint, MessageText);
                    }
                }
				else
                {
                    return string.Format("{0}::{1}:{2}", msgId, Endpoint, MessageText);
                }
            }
		}
	}
}
