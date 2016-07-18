using System;
using System.Collections.Generic;

namespace SocketIOClient
{
    public class SocketIOHandshake
    {
        public SocketIOHandshake()
        {
            //do nothing
        }

        public string SID { get; set; }
        public int ConnectionTimeout { get; set; }
        public int HeartbeatTimeout { get; set; }
        /// <summary>The Interval will be approxamately 20% faster than the Socket.IO service indicated was required</summary>
        public TimeSpan HeartbeatInterval => new TimeSpan(0, 0, HeartbeatTimeout);

        public List<string> Transports { get; } = new List<string>();
        public string ErrorMessage { get; set; }
        public bool HadError => !string.IsNullOrEmpty(ErrorMessage);

        public static SocketIOHandshake LoadFromString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            string[] items = value.Split(':');
            if (items.Length != 4)
            {
                return null;
            }

            var result = new SocketIOHandshake();
            int hb = 0;
            int ct = 0;
            result.SID = items[0];

            if (int.TryParse(items[1], out hb))
            { 
                // setup client time to occure 25% faster than needed
                var pct = (int)(hb * .75);  
                result.HeartbeatTimeout = pct;
            }
            if (int.TryParse(items[2], out ct))
            {
                result.ConnectionTimeout = ct;
            }
            result.Transports.AddRange(items[3].Split(','));
            return result;
        }
    }
}
