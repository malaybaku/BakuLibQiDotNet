using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SocketIOClient
{
    internal static class JsonTextSerialization
    {
        /// <summary>Serialize object to JSON-like string by default setting</summary>
        public static string Serialize(object value)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            using (var jw = new JsonTextWriter(sw))
            {
                _serializer.Serialize(jw, value);
            }
            return sb.ToString();
        }

        private readonly static JsonSerializer _serializer = JsonSerializer.CreateDefault();
    }
}
