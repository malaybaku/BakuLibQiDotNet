using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>Socket.ioで送受信するJSONに基づいた非同期処理データを表します。</summary>
    public class QiValue : IQiResult
    {
        /// <summary>指定したJTokenでインスタンスを初期化します。</summary>
        /// <param name="token">実際のデータを表すJSONトークンデータ</param>
        public QiValue(JToken token)
        {
            _token = token;
        }

        private readonly JToken _token;

        //地味に難しいうえに需要が低い。
        //(とはいえ書かないとQiMap相当の処理でコケるのでナメちゃダメだよ)
        /// <summary>
        /// データが辞書型データであると想定し、キー指定によって値を取得します。
        /// </summary>
        /// <param name="key">キーとなるデータ</param>
        /// <returns>キーに対応した値</returns>
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

        /// <summary>
        /// データがリストまたはタプル型であると想定し、インデクス指定で要素を取得します。
        /// リストまたはタプルの要素数を得るには<see cref="Count"/>値を取得してください。
        /// </summary>
        /// <param name="index">リストまたはタプルのインデクス(0以上の値)。境界値チェックは行われません。</param>
        /// <returns>指定したインデクスでの要素の値</returns>
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

        /// <summary>
        /// データがリスト、タプル、辞書型データのいずれかであると想定して要素数を取得します。
        /// これらの型ではない場合、要素数として0を返します。
        /// </summary>
        public int Count => (_token as JArray)?.Count ?? 0;

        /// <summary>データが辞書型データであると想定してキーの一覧を取得します。</summary>
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

        /// <summary>データが辞書型データであると想定してキー/値のペア一覧を取得します。</summary>
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
        /// <summary>データがバイト配列の場合そのデータを取得し、そうでなければ要素数0のバイト配列を取得します。</summary>
        /// <returns>バイト配列に変換されたデータ</returns>
        public byte[] ToBytes() => ((byte[])_token) ?? new byte[0];
        /// <summary>データがブール値と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public bool ToBool() => (bool)_token;
        /// <summary>データが符号あり1バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public sbyte ToSByte() => (sbyte)_token;
        /// <summary>データが符号あり2バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public short ToInt16() => (short)_token;
        /// <summary>データが符号あり4バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public int ToInt32() => (int)_token;
        /// <summary>データが符号あり8バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public long ToInt64() => (long)_token;
        /// <summary>データが符号なし1バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public byte ToByte() => (byte)_token;
        /// <summary>データが符号なし2バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public ushort ToUInt16() => (ushort)_token;
        /// <summary>データが符号なし4バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public uint ToUInt32() => (uint)_token;
        /// <summary>データが符号なし8バイト整数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public ulong ToUInt64() => (ulong)_token;
        /// <summary>データが単精度小数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public float ToFloat() => (float)_token;
        /// <summary>データが倍精度小数と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public double ToDouble() => (double)_token;
        /// <summary>データが文字列と想定してデータを取得します。</summary>
        /// <returns>取得したデータ</returns>
        public string ToQiString() => (string)_token ?? "";

    }
}
