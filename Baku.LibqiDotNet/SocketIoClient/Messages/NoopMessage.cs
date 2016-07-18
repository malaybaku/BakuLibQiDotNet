
namespace SocketIOClient.Messages
{
    /// <summary>Defined as No operation. Used for example to close a poll after the polling duration times out.</summary>
    public class NoopMessage : Message
    {
        public NoopMessage()
        {
            MessageType = SocketIOMessageTypes.Noop;
        }

        public static NoopMessage Deserialize(string rawMessage) => new NoopMessage();
    }
}
