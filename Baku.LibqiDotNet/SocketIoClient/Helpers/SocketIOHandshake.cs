using System;
using System.Collections.Generic;

namespace SocketIOClient
{
    /// <summary>通信開始時のハンドシェーク処理設定を表します。</summary>
    public class SocketIOHandshake
    {
        /// <summary>既定の状態でハンドシェークインスタンスを初期化します。</summary>
        public SocketIOHandshake()
        {
            //do nothing
        }

        /// <summary>接続IDを取得、設定します。</summary>
        public string SID { get; set; }

        /// <summary>接続タイムアウトを取得、設定します。</summary>
        public int ConnectionTimeout { get; set; }

        /// <summary>Heart beatのタイムアウトを取得、設定します。</summary>
        public int HeartbeatTimeout { get; set; }

        /// <summary>The Interval will be approxamately 20% faster than the Socket.IO service indicated was required</summary>
        public TimeSpan HeartbeatInterval => new TimeSpan(0, 0, HeartbeatTimeout);

        /// <summary>HTTPレスポンス文字列の一部を取得します。</summary>
        public List<string> Transports { get; } = new List<string>();

        /// <summary>エラーメッセージを取得、設定します。</summary>
        public string ErrorMessage { get; set; }

        /// <summary>エラーの有無を取得します。</summary>
        public bool HadError => !string.IsNullOrEmpty(ErrorMessage);
        /// <summary>HTTPのレスポンス文字列からハンドシェークインスタンスを生成します。</summary>
        /// <param name="value">レスポンス文字列</param>
        /// <returns>レスポンスに基づいて初期化されたハンドシェークインスタンス</returns>
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
