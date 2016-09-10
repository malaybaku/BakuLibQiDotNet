
namespace SocketIOClient.Messages
{
    /// <summary>一定時間ごとに通信の生存を通知するためのハートビートメッセージを表します。</summary>
    public class Heartbeat : Message
    {
        /// <summary>ハートビートの定型メッセージです。</summary>
        public static readonly string HEARTBEAT = "2::";

        private Heartbeat()
        {
            MessageType = SocketIOMessageTypes.Heartbeat;
        }
        /// <summary>ハートビートのメッセージ文字列を取得します。</summary>
        public override string Encoded => HEARTBEAT;
        /// <summary>ハートビートメッセージのシングルトンインスタンスを取得します。</summary>
        public static Heartbeat Instance { get; } = new Heartbeat();
    }
}
