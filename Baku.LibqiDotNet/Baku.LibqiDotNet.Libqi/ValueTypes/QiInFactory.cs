using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Baku.LibqiDotNet.Libqi
{
    public static class QiInFactory
    {
        /// <summary>引数の辞書、IE、クラスのプロパティの深さ上限を取得、設定します。</summary>
        public static int RecurseParseDepthLimit { get; set; } = 6;

        public static QiInputValue Create(object value)
        {
            return CreateSub(value, RecurseParseDepthLimit);
        }

        /// <summary>一般の値(組み込み型/IDic/IE/一般クラス)を入力値へ変換するが、再帰深度を使い果たした場合はそこで例外停止する</summary>
        public static QiInputValue CreateSub(object value, int recurseDepthRemaining)
        {
            if (value == null) throw new ArgumentNullException("QiInFactory.Create method cannot handle null value");
            if (recurseDepthRemaining <= 0) throw new InvalidOperationException("Too deep recursive call was detected");

            Type t = value.GetType();

            //直の組み込み型
            if (IsEmbeddedType(t))
            {
                return GetEmbeddedTypeValue(value, Type.GetTypeCode(t));
            }

            //バイナリデータ
            if (t == typeof(byte[]))
            {
                return new QiByteData(value as byte[]);
            }

            //IE<組み込み型>
            Type ieArgType = GetIEnumerableEmbeddedArgType(t);
            if (ieArgType != null)
            {
                return GetIEnumerableEmbedded(value, Type.GetTypeCode(ieArgType));
            }

            //IDic
            if (ImplementsIDictcionary(t))
            {
                return CreateDic(value, recurseDepthRemaining);
            }

            //IE
            if (GetIEnumerableArgType(t) != null)
            {
                return CreateList(value, recurseDepthRemaining);
            }

            throw new InvalidOperationException("invalid data was given");
        }

        private static QiInputValue CreateDic(object value, int recurseDepthRemaining)
        {
            var keys = new List<QiInputValue>();
            var values = new List<QiInputValue>();

            Type pType = null;
            PropertyInfo keyProp = null;
            PropertyInfo valueProp = null;
            //IDic<TK, TV> : IEなのでIEとしてobject値(実際はKeyValuePair<TK, TV>型)を拾いに行く
            foreach (object pair in (value as IEnumerable))
            {
                if (pType == null)
                {
                    pType = pair.GetType();
                    keyProp = pType.GetProperty(nameof(KeyValuePair<int, int>.Key));
                    valueProp = pType.GetProperty(nameof(KeyValuePair<int, int>.Value));
                }

                object pKey = keyProp.GetValue(pair, new object[0]);
                object pValue = valueProp.GetValue(pair, new object[0]);
                keys.Add(CreateSub(pKey, recurseDepthRemaining - 1));
                values.Add(CreateSub(pValue, recurseDepthRemaining - 1));
            }

            return QiMap.Create(keys, values);
        }

        private static QiInputValue CreateList(object value, int recurseDepthRemaining)
        {
            var list = new List<QiInputValue>();
            foreach (object v in (value as IEnumerable))
            {
                list.Add(CreateSub(v, recurseDepthRemaining - 1));
            }
            return QiList.Create(list);
        }

        /// <summary>指定された値が組み込み型かどうか判定します。</summary>
        private static bool IsEmbeddedType(Type t)
            => _embeddedTypeCodes.Contains(Type.GetTypeCode(t));

        /// <summary>指定された型が組み込み型の<see cref="IEnumerable{T}"/>である場合IEnumerableの中身の型、そうでない場合nullを返します。</summary>
        private static Type GetIEnumerableEmbeddedArgType(Type t)
        {
            Type ieArgType = GetIEnumerableArgType(t);

            if (ieArgType != null && _embeddedTypeCodes.Contains(Type.GetTypeCode(ieArgType)))
            {
                return ieArgType;
            }
            else
            {
                return null;
            }
        }

        /// <summary>指定された型が<see cref="IEnumerable{T}"/>である場合IEnumerableの中身の型、そうでない場合nullを返します。</summary>
        private static Type GetIEnumerableArgType(Type t)
        {
            return t.GetInterfaces()
                .FirstOrDefault(
                    itf => itf.IsGenericType &&
                    itf.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                ?.GetGenericArguments()[0];
        }

        private static bool ImplementsIDictcionary(Type t)
            => t.GetInterfaces()
                .Any(itf => 
                    itf.IsGenericType &&
                    itf.GetGenericTypeDefinition() == typeof(IDictionary<,>)
                );

        /// <summary>組み込み型の値を対応する<see cref="QiInputValue"/>派生型に変換します。</summary>
        private static QiInputValue GetEmbeddedTypeValue(object value, TypeCode tCode)
        {
            switch (tCode)
            {
                case TypeCode.Boolean: return new QiBool((bool)value);
                case TypeCode.Byte: return new QiUInt8((byte)value);
                case TypeCode.UInt16: return new QiUInt16((ushort)value);
                case TypeCode.UInt32: return new QiUInt32((uint)value);
                case TypeCode.UInt64: return new QiUInt64((ulong)value);
                case TypeCode.SByte: return new QiInt8((sbyte)value);
                case TypeCode.Int16: return new QiInt16((short)value);
                case TypeCode.Int32: return new QiInt32((int)value);
                case TypeCode.Int64: return new QiInt64((long)value);
                case TypeCode.String: return new QiString((string)value);
                case TypeCode.Single: return new QiFloat((float)value);
                case TypeCode.Double: return new QiDouble((double)value);
                default:
                    throw new ArgumentException("Given type is not supported as an embedded type in Qi Framework");
            }
        }

        /// <summary>IEnumerable&lt;(組み込み型)&gt;の形式をした値を適切な<see cref="QiList{T}"/>に変換します。</summary>
        private static QiInputValue GetIEnumerableEmbedded(object value, TypeCode contentTypeCode)
        {
            switch (contentTypeCode)
            {
                case TypeCode.Boolean: return QiList.Create(value as IEnumerable<bool>);
                case TypeCode.UInt16: return QiList.Create(value as IEnumerable<ushort>);
                case TypeCode.UInt32: return QiList.Create(value as IEnumerable<uint>);
                case TypeCode.UInt64: return QiList.Create(value as IEnumerable<ulong>);
                case TypeCode.SByte: return QiList.Create(value as IEnumerable<sbyte>);
                case TypeCode.Int16: return QiList.Create(value as IEnumerable<short>);
                case TypeCode.Int32: return QiList.Create(value as IEnumerable<int>);
                case TypeCode.Int64: return QiList.Create(value as IEnumerable<long>);
                case TypeCode.String: return QiList.Create(value as IEnumerable<string>);
                case TypeCode.Single: return QiList.Create(value as IEnumerable<float>);
                case TypeCode.Double: return QiList.Create(value as IEnumerable<double>);
                default:
                    throw new ArgumentException("Given type is not supported as an embedded type in Qi Framework");
            }
        }

        private static readonly TypeCode[] _embeddedTypeCodes = new[]
        {
            TypeCode.Boolean,
            TypeCode.Byte,
            TypeCode.UInt16,
            TypeCode.UInt32,
            TypeCode.UInt64,
            TypeCode.SByte,
            TypeCode.Int16,
            TypeCode.Int32,
            TypeCode.Int64,
            TypeCode.String,
            TypeCode.Single,
            TypeCode.Double
        };
    }
}
