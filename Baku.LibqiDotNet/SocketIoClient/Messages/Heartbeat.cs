
namespace SocketIOClient.Messages
{
    public class Heartbeat : Message
    {
        public static readonly string HEARTBEAT = "2::";

        private Heartbeat()
        {
            MessageType = SocketIOMessageTypes.Heartbeat;
        }

        public override string Encoded => HEARTBEAT;

        public static Heartbeat Instance { get; } = new Heartbeat();
    }
}
