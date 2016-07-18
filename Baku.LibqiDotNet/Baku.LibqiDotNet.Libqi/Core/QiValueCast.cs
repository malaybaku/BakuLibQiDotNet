//using System.Linq;

//namespace Baku.LibqiDotNet.Libqi
//{
//    partial class QiValue
//    {
//        /// <summary>保持しているデータが論理値である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator bool(QiValue v) => v.ToBool();

//        /// <summary>保持しているデータが符号なし1バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator byte(QiValue v) => v.ToByte();

//        /// <summary>保持しているデータが符号なし2バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator ushort(QiValue v) => v.ToUInt16();

//        /// <summary>保持しているデータが符号なし4バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator uint(QiValue v) => v.ToUInt32();

//        /// <summary>保持しているデータが符号なし8バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator ulong(QiValue v) => v.ToUInt64();

//        /// <summary>保持しているデータが符号あり1バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator sbyte(QiValue v) => v.ToSByte();

//        /// <summary>保持しているデータが符号あり2バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator short(QiValue v) => v.ToInt16();

//        /// <summary>保持しているデータが符号あり4バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator int(QiValue v) => v.ToInt32();

//        /// <summary>保持しているデータが符号あり8バイト整数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator long(QiValue v) => v.ToInt64();


//        /// <summary>保持しているデータが単精度小数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator float(QiValue v) => v.ToFloat();

//        /// <summary>保持しているデータが倍精度小数である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator double(QiValue v) => v.ToDouble();

//        /// <summary>保持しているデータが文字列である想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator string(QiValue v) => v.ToString();

//        /// <summary>保持しているデータがバイナリデータである想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator byte[](QiValue v) => v.ToBytes();

//        /// <summary>保持しているデータが整数リストである想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator int[] (QiValue v)
//        {
//            return Enumerable.Range(0, v.Count)
//                .Select(i => v[i].ToInt32())
//                .ToArray();
//        }

//        /// <summary>保持しているデータが小数リストである想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator double[] (QiValue v)
//        {
//            return Enumerable.Range(0, v.Count)
//                .Select(i => v[i].ToDouble())
//                .ToArray();
//        }

//        /// <summary>保持しているデータが小数リストである想定で値を変換します。</summary>
//        /// <param name="v">変換元となるデータ</param>
//        public static explicit operator string[] (QiValue v)
//        {
//            return Enumerable.Range(0, v.Count)
//                .Select(i => v[i].ToString())
//                .ToArray();
//        }

//    }
//}
