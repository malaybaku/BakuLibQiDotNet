//using System;
//using System.Diagnostics;
//using Newtonsoft.Json.Linq;

//namespace SocketIOClient.Messages
//{
//    public class JsonEncodedEventMessage
//    {
//        public JsonEncodedEventMessage()
//        {
//            _jobj = new JObject();
//        }
//        public JsonEncodedEventMessage(JObject jobj)
//        {
//            _jobj = jobj;
//        }
//        public JsonEncodedEventMessage(string name, object[] args)
//        {
//            var jarr = new JArray();
//            for (int i = 0; i < args.Length; i++)
//            {
//                jarr.Add(args[i]);
//            }

//            if (string.IsNullOrEmpty(name))
//            {
//                _jobj = new JObject(new JProperty("args", jarr));
//            }
//            else
//            {
//                _jobj = new JObject(
//                    new JProperty("name", name),
//                    new JProperty("args", jarr)
//                    );
//            }
//        }

//        public string Name => ((string)_jobj["name"]) ?? "";

//        public string ToJsonString() => _jobj["args"]?.ToString() ?? "";

//        public static JsonEncodedEventMessage Deserialize(string jsonString)
//        {
//            try
//            {
//                return new JsonEncodedEventMessage(JObject.Parse(jsonString));
//            }
//            catch (Exception ex)
//            {
//                Trace.WriteLine(ex);
//                return null;
//            }
//        }

//        private JObject _jobj;
//    }
//}
