using System;
using Newtonsoft.Json.Linq;

namespace SocketIOClient.Messages
{
    public class EventMessage : Message
    {
        public EventMessage()
        {
            MessageType = SocketIOMessageTypes.Event;
        }
        public EventMessage(string eventName, object jsonObject, string endpoint, Action<JToken> callBack) : this()
        {
            Event = eventName;
            Callback = callBack;
            Endpoint = endpoint;

            if (callBack != null)
            {
                AckId = NextAckID;
            }

            //JToken -> JSONize by Newtonsoft, others -> serialization.
            if (jsonObject is string)
            {
                MessageText = $"{{\"name\":\"{eventName}\", \"args\":[\"{(string)jsonObject}\"]}}";
            }
            else if ((jsonObject as JToken) != null)
            {
                MessageText = new JObject(
                    new JProperty("name", eventName),
                    new JProperty("args", new JArray(new object[] { jsonObject }))
                    ).ToString(Newtonsoft.Json.Formatting.None);
            }
            else
            {
                MessageText = $"{{\"name\":\"{eventName}\", \"args\":[{JsonTextSerialization.Serialize(jsonObject)}]}}";
            }
            _jtoken = (jsonObject as JToken) ?? JToken.Parse(MessageText);
        }
        public EventMessage(string eventName, object jsonObject) : this(eventName, jsonObject, null, null)
        {
        }

        private JToken _jtoken;

        private static object ackLock = new object();
		private static int _akid = 0;
		private static int NextAckID
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

        public Action<JToken> Callback { get; private set; }

        public JObject Args => _jtoken["args"] as JObject;

        public static EventMessage Deserialize(string rawMessage)
        {
            //  '5:' [message id ('+')] ':' [message endpoint] ':' [json encoded event]
            //   5:1::{"a":"b"}

            // limit the number of pieces (almost all JSON contain colon character(':')!!)
            string[] args = rawMessage.Split(SPLITCHARS, 4);
            if (args.Length != 4)
            {
                throw new ArgumentException("Message string does not not follow EventMessage's format");
            }

            JObject jobj = JObject.Parse(args[3]);
            if (jobj["name"] == null || jobj["args"] == null)
            {
                throw new ArgumentException("Text does not follow Event Message format");
            }

            var evtMsg = new EventMessage()
            {
                RawMessage = rawMessage,
                Endpoint = args[2],
                Event = (string)(jobj["name"]),
                MessageText = jobj.ToString()
            };
            int id;
            if (int.TryParse(args[1], out id))
            {
                evtMsg.AckId = id;
            }
            evtMsg._jtoken = jobj;
            return evtMsg;

        }

		public override string Encoded
		{
			get
			{
                //例
                //"5:(id):(endpoint):text"
                //"5:(id)+:(endpoint):text
                return string.Format("{0}:{1}{2}:{3}:{4}",
                    (int)MessageType,
                    AckId.HasValue ? AckId.Value.ToString() : "",
                    (AckId.HasValue && Callback != null) ? "+" : "",
                    Endpoint,
                    MessageText);
            }
		}
        
    }
}
