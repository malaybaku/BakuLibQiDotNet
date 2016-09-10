
namespace SocketIOClient.Messages
{
    /// <summary>Defined as No operation. Used for example to close a poll after the polling duration times out.</summary>
    public class NoopMessage : Message
    {
        /// <summary>既定のデータでメッセージの内容を初期化します。</summary>
        public NoopMessage()
        {
            MessageType = SocketIOMessageTypes.Noop;
        }

        /// <summary>取得した文字列に関係なく何もしないメッセージを生成します。</summary>
        /// <param name="rawMessage">受信したSocket.ioのプロトコル準拠な文字列</param>
        /// <returns>何もしないメッセージ</returns>
        public static NoopMessage Deserialize(string rawMessage) => new NoopMessage();
    }
}
