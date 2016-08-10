using System;
using System.Collections.Generic;

namespace Baku.LibqiDotNet
{
    /// <summary>内部的に組み込み型を扱うため、TypeCodeに相当する機能を提供します。</summary>
    public enum LibqiTypeCode
    {
        Boolean,
        Byte,
        Char,
        //DateTime,
        //DBNull,
        //Decimal,
        Double,
        Empty,
        Int16,
        Int32,
        Int64,
        Object,
        SByte,
        Single,
        String,
        UInt16,
        UInt32,
        UInt64
    }

    public static class LibqiTypeCodeGetter
    {
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
