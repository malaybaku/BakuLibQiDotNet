using System;
using System.Collections.Generic;

namespace Baku.LibqiDotNet
{
    /// <summary>内部的に組み込み型を扱うため、TypeCodeに相当する機能を提供します。</summary>
    public enum LibqiTypeCode
    {
        /// <summary>論理値</summary>
        Boolean,
        /// <summary>符号なし1バイト整数</summary>
        Byte,
        /// <summary>文字</summary>
        Char,
        //DateTime,
        //DBNull,
        //Decimal,
        /// <summary>倍精度小数</summary>
        Double,
        /// <summary>空のデータ</summary>
        Empty,
        /// <summary>符号あり2バイト整数</summary>
        Int16,
        /// <summary>符号あり4バイト整数</summary>
        Int32,
        /// <summary>符号あり8バイト整数</summary>
        Int64,
        /// <summary>オブジェクト型</summary>
        Object,
        /// <summary>符号あり1バイト整数</summary>
        SByte,
        /// <summary>単精度小数</summary>
        Single,
        /// <summary>文字列</summary>
        String,
        /// <summary>符号なし2バイト整数</summary>
        UInt16,
        /// <summary>符号なし4バイト整数</summary>
        UInt32,
        /// <summary>符号なし8バイト整数</summary>
        UInt64
    }

    /// <summary>タイプコードの取得処理を提供します。</summary>
    public static class LibqiTypeCodeGetter
    {
        /// <summary>型を指定して対応するタイプコードを取得します。</summary>
        /// <param name="t">型情報</param>
        /// <returns>
        /// 型に対応したタイプコード。
        /// 特に該当するものがない場合は<see cref="LibqiTypeCode.Object"/>が返されます。
        /// </returns>
        public static LibqiTypeCode GetTypeCode(Type t)
        {
            return (t == null) ? LibqiTypeCode.Empty :
                _codes.ContainsKey(t) ? _codes[t] :
                LibqiTypeCode.Object;
        }

        private static readonly Dictionary<Type, LibqiTypeCode> _codes = new Dictionary<Type, LibqiTypeCode>
        {
            [typeof(bool)] = LibqiTypeCode.Boolean,
            [typeof(byte)] = LibqiTypeCode.Byte,
            [typeof(char)] = LibqiTypeCode.Char,
            [typeof(double)] = LibqiTypeCode.Double,
            [typeof(short)] = LibqiTypeCode.Int16,
            [typeof(int)] = LibqiTypeCode.Int32,
            [typeof(long)] = LibqiTypeCode.Int64,
            [typeof(sbyte)] = LibqiTypeCode.SByte,
            [typeof(float)] = LibqiTypeCode.Single,
            [typeof(string)] = LibqiTypeCode.String,
            [typeof(ushort)] = LibqiTypeCode.UInt16,
            [typeof(uint)] = LibqiTypeCode.UInt32,
            [typeof(ulong)] = LibqiTypeCode.UInt64
        };
            
    }
}
