using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SocketIOClient.Messages
{
    /// <summary>JSONデータからなるメッセージを表します。</summary>
    public class JSONMessage : Message
    {
        /// <summary>既定値でインスタンスを初期化します。</summary>
        public JSONMessage()
        {
            MessageType = SocketIOMessageTypes.JSONMessage;
        }
        /// <summary>JSONオブジェクトを指定してインスタンスを初期化します、。</summary>
        /// <param name="jsonObject">JSONオブジェクト</param>
        public JSONMessage(object jsonObject) : this()
        {
            SetMessage(jsonObject);
        }
        /// <summary>JSONオブジェクトとAck Idおよびエンドポイントを指定してインスタンスを初期化します、。</summary>
        /// <param name="jsonObject">JSONオブジェクト</param>
        /// <param name="ackId">ACK ID</param>
        /// <param name="endpoint">エンドポイント</param>
        public JSONMessage(object jsonObject, int? ackId, string endpoint) : this()
        {
            AckId = ackId;
            Endpoint = endpoint;
            SetMessage(jsonObject);
        }

        /// <summary>JSONオブジェクトと考えられるデータを用いてメッセージを設定します。</summary>
        /// <param name="value">JSONオブジェクト</param>
        public void SetMessage(object value)
        {
            MessageText = Serialize(value);
        }
        /// <summary>デシリアライズする型を指定してメッセージをデシリアライズします。</summary>
        /// <typeparam name="T">デシリアライズ先の型</typeparam>
        /// <returns>指定した型のデータ</returns>
        public virtual T Message<T>()
        {
            //FIXME: no error handling!
            return DeserializeFrom<T>(MessageText);
        }

        /// <summary>Socket.ioのメッセージ文字列から対応するメッセージを生成します。</summary>
        /// <param name="rawMessage">生のsocket.io文字列</param>
        /// <returns>対応するメッセージ</returns>
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

        /// <summary>JSONオブジェクトからメッセージを生成します。</summary>
        /// <param name="jobj">JSONオブジェクト</param>
        /// <returns>JSONオブジェクトをメッセージとしたメッセージ</returns>
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
