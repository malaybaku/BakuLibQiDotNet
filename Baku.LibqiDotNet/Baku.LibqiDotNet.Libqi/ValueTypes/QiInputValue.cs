
using System.Linq;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>Qiの値型の基底</summary>
    public abstract class QiInputValue
    {
        /// <summary>実際の値を取得します。</summary>
        public abstract QiValue QiValue { get; }

        /// <summary>値の種類を表すシグネチャを取得します。</summary>
        public abstract string Signature { get; }

        /// <summary>値の情報をデバッグ用文字列として取得します。</summary>
        /// <returns>値をあらわすデバッグ用の文字列</returns>
        public string Dump() => QiValue.Dump();


        #region implicit casts

        /// <summary>論理値を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の論理値</param>
        public static implicit operator QiInputValue(bool x) => new QiBool(x);

        /// <summary>符号なし1バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号なし1バイト整数</param>
        public static implicit operator QiInputValue(byte x) => new QiUInt8(x);
        /// <summary>符号なし2バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号なし2バイト整数</param>
        public static implicit operator QiInputValue(ushort x) => new QiUInt16(x);
        /// <summary>符号なし4バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号なし4バイト整数</param>
        public static implicit operator QiInputValue(uint x) => new QiUInt32(x);
        /// <summary>符号なし8バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号なし8バイト整数</param>
        public static implicit operator QiInputValue(ulong x) => new QiUInt64(x);

        /// <summary>符号あり1バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号あり1バイト整数</param>
        public static implicit operator QiInputValue(sbyte x) => new QiInt8(x);
        /// <summary>符号あり2バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号あり2バイト整数</param>
        public static implicit operator QiInputValue(short x) => new QiInt16(x);
        /// <summary>符号あり4バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号あり4バイト整数</param>
        public static implicit operator QiInputValue(int x) => new QiInt32(x);
        /// <summary>符号あり8バイト整数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の符号あり8バイト整数</param>
        public static implicit operator QiInputValue(long x) => new QiInt64(x);
        /// <summary>単精度小数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の小数値</param>
        public static implicit operator QiInputValue(float x) => new QiFloat(x);
        /// <summary>倍精度小数を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の小数値</param>
        public static implicit operator QiInputValue(double x) => new QiDouble(x);

        /// <summary>文字列を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の文字列</param>
        public static implicit operator QiInputValue(string x) => new QiString(x);

        /// <summary>バイト配列を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元のバイト配列</param>
        public static implicit operator QiInputValue(byte[] x) => new QiByteData(x);

        /// <summary>整数の配列を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の整数配列</param>
        public static implicit operator QiInputValue(int[] x) => x.Select(v => new QiInt32(v)).ToQiList();

        /// <summary>小数の配列を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の小数配列</param>
        public static implicit operator QiInputValue(double[] x) => x.Select(v => new QiDouble(v)).ToQiList();

        /// <summary>文字列の配列を適切な<see cref="QiInputValue"/>の派生型インスタンスに変換します。</summary>
        /// <param name="x">入力元の文字列配列</param>
        public static implicit operator QiInputValue(string[] x) => x.Select(v => new QiString(v)).ToQiList();

        #endregion
    }
}
