using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiValue : IQiResult
    {
        //TODO: jobjだけじゃなくてJValueとか、あるいはJTokenに一般対応すべきなのか？
        public QiValue(JToken token)
        {
            _token = token;
        }

        private readonly JToken _token;

        //地味に難しいうえに需要が低い。
        //(とはいえ書かないとQiMap相当の処理でコケるのでナメちゃダメだよ)
        public IQiResult this[IQiResult key]
        {
            get
            {
                var jobj = _token as JObject;
                string keyStr = key.ToQiString();
                if (jobj != null)
                {
                    return new QiValue(jobj[keyStr]);
                }
                else
                {
                    throw new InvalidOperationException($"Could not get value by key '{keyStr}'");
                }
            }

            set
            {
                var v = value as QiValue;
                var jobj = _token as JObject;
                string keyStr = key.ToQiString();
                if (v != null && jobj != null)
                {
                    jobj[keyStr] = v._token;
                }
                else
                {
                    throw new InvalidOperationException($"Could not get value by key '{keyStr}'");
                }

                throw new NotImplementedException();
            }
        }

        public IQiResult this[int index]
        {
            get
            {
                //TODO: nullってどう思いますか。
                return new QiValue((_token as JArray)?[index]);
            }

            set
            {
                var qv = value as QiValue;
                var jarr = _token as JArray;
                if (jarr != null && qv != null)
                {
                    jarr[index] = qv._token;
                }
            }
        }

        public int Count => (_token as JArray)?.Count ?? 0;

        public IEnumerable<IQiResult> Keys
        {
            get
            {
                var jobj = _token as JObject;
                if (jobj == null) return new QiValue[0];

                return jobj.Properties()
                    .Select(p => new QiValue(p.Name) as IQiResult);
            }
        }

        public IEnumerable<KeyValuePair<IQiResult, IQiResult>> MapItems
        {
            get
            {
                var jobj = _token as JObject;
                if (jobj == null) return new KeyValuePair<IQiResult, IQiResult>[0];

                return jobj.Properties()
                    .ToDictionary(
                        p => new QiValue(p.Name) as IQiResult,
                        p => new QiValue(p.Value) as IQiResult
                        );
            }
        }

        /// <summary>ラクにJSONを吐く</summary>
        /// <returns></returns>
        public string Dump() => _token.ToString();

        /// <summary>実態がJTokenに皮ペラ一枚被せたものであることを認めて潔く、ね。</summary>
        /// <returns>内部表現であるJSONの文字列版</returns>
        public override string ToString() => ((string)_token) ?? _token.ToString();

        //TODO: バイナリは受け取れるハズだがどう受け取っているかは要チェック(多分b64文字列か)
        public byte[] ToBytes() => ((byte[])_token) ?? new byte[0];

        public bool ToBool() => (bool)_token;
        public sbyte ToSByte() => (sbyte)_token;
        public short ToInt16() => (short)_token;
        public int ToInt32() => (int)_token;
        public long ToInt64() => (long)_token;
        public byte ToByte() => (byte)_token;
        public ushort ToUInt16() => (ushort)_token;
        public uint ToUInt32() => (uint)_token;
        public ulong ToUInt64() => (ulong)_token;

        public float ToFloat() => (float)_token;
        public double ToDouble() => (double)_token;

        public string ToQiString() => (string)_token ?? "";

    }
}
