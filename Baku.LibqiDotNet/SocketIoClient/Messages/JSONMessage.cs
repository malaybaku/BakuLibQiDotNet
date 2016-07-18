using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SocketIOClient.Messages
{
    public class JSONMessage : Message
    {
        public JSONMessage()
        {
            MessageType = SocketIOMessageTypes.JSONMessage;
        }
        public JSONMessage(object jsonObject) : this()
        {
            SetMessage(jsonObject);
        }		
        public JSONMessage(object jsonObject, int? ackId, string endpoint) : this()
        {
            AckId = ackId;
            Endpoint = endpoint;
            SetMessage(jsonObject);
        }

        public void SetMessage(object value)
        {
            MessageText = Serialize(value);
        }
        public virtual T Message<T>()
        {
            //FIXME: no error handling!
            return DeserializeFrom<T>(MessageText);
        }

        public static JSONMessage Deserialize(string rawMessage)
        {
            //  '4:' [message id ('+')] ':' [message endpoint] ':' [json]
            //   4:1::{"a":"b"}
            var jsonMsg = new JSONMessage() { RawMessage = rawMessage };

            // limit the number of ':'
            string[] args = rawMessage.Split(SPLITCHARS, 4); 
            if (args.Length == 4)
            {
                int id;
                if (int.TryParse(args[1], out id))
                {
                    jsonMsg.AckId = id;
                }
                jsonMsg.Endpoint = args[2];
				jsonMsg.MessageText = args[3];
            }
			return jsonMsg;
        }

        public static JSONMessage CreateFromJObject(JObject jobj)
        {
            return new JSONMessage
            {
                RawMessage = jobj.ToString(),
                MessageText = jobj.ToString()
            };
        }

        private static object _serializerLock = new object();
        private static readonly JsonSerializer _serializer = JsonSerializer.CreateDefault();
        private static string Serialize(object obj)
        {
            lock (_serializerLock)
            {
                using (var tw = new StringWriter())
                {
                    _serializer.Serialize(tw, obj);
                    return tw.ToString();
                }
            }
        }

        private static T DeserializeFrom<T>(string jsonString)
        {
            lock (_serializerLock)
            {
                using (var sr = new StringReader(jsonString))
                using (var jtr = new JsonTextReader(sr))
                {
                    return _serializer.Deserialize<T>(jtr);
                }
            }
        }
    }
}
