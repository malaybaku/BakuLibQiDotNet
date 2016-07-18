namespace SocketIOClient
{
    public enum SocketIOMessageTypes
    {
        /// <summary>Signals disconnection. If no endpoint is specified, disconnects the entire socket.</summary>
        Disconnect = 0,
        /// <summary>Only used for multiple sockets. Signals a connection to the endpoint. Once the server receives it, it's echoed back to the client.</summary> 
        Connect = 1,
        Heartbeat = 2,
        /// <summary>A regular message</summary>
        Message = 3,
        /// <summary>A JSON message</summary>
        JSONMessage = 4,
        /// <summary>An event is like a JSON message, but has mandatory name and args fields.</summary>
        Event = 5,
        /// <summary>An acknowledgment contains the message id as the message data. If a + sign follows the message id, it's treated as an event message packet.</summary>
        ACK = 6,
        /// <summary>Error</summary>
        Error = 7,
        /// <summary>No operation</summary>
        Noop = 8
    }
}
