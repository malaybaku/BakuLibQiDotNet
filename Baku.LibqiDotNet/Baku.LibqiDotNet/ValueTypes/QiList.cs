using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>一般的な配列型を表します。</summary>
    public abstract class QiListBase : QiAnyValue
    {
        /// <summary>要素数を取得します。</summary>
        public int Count => QiValue.Count;

        /// <summary>インデクスを指定して要素を取得、設定します。</summary>
        /// <param name="i">インデックス</param>
        /// <returns>インデックスで指定した要素</returns>
        public abstract QiValue this[int i] { get; set; }
    }

    /// <summary>可変な配列型を表します。配列は単調に伸びる処理だけが許可されています。</summary>
    public sealed class QiList<T> : QiListBase where T : QiAnyValue
    {
        private QiList(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; }

        /// <summary>インデクスを指定して要素を取得、設定します。</summary>
        /// <param name="i">インデックス</param>
        /// <returns>インデックスで指定した要素</returns>
        public override QiValue this[int i]
        {
            get { return this.QiValue[i]; }
            set { this.QiValue[i] = value; }
        }

        /// <summary>
        /// 列挙された<see cref="QiAnyValue"/>派生型から、それに対応したリストを生成します。
        /// </summary>
        /// <param name="values">何かしらの値の列挙</param>
        /// <returns></returns>
        public static QiList<T> Create(IEnumerable<T> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("values length must be greater than 0");
            }

            //リストは中身のシグネチャ揃ってないとアウト(ダイナミックリストの場合は例外)
            string elemSig = values.First().Signature;
            if (values.Any(v => v.Signature != elemSig))
            {
                throw new InvalidOperationException("values kind is not same");
            }

            string sig = QiSignatures.TypeListBegin + elemSig + QiSignatures.TypeListEnd;

            var list = QiValue.Create(sig);
            foreach (var v in values)
            {
                list.AddElement(v.QiValue);
            }

            return new QiList<T>(list, sig);
        }

    }

    /// <summary><see cref="QiList{T}"/>のファクトリメソッドを定義します。</summary>
    public static class QiList
    {
        /// <summary>
        /// 列挙された<see cref="QiAnyValue"/>派生型から、それに対応したリストを生成します。
        /// </summary>
        /// <param name="values">何かしらの値の列挙</param>
        /// <returns></returns>
        public static QiList<T> Create<T>(IEnumerable<T> values) where T : QiAnyValue
            => QiList<T>.Create(values);

        /// <summary>
        /// <see cref="QiAnyValue"/>の派生型ではない型(基本的に組み込み型を想定)の型変換をしつつ配列を取得します。
        /// </summary>
        /// <typeparam name="T">一般的な組み込み型、または組み込み型の列挙<see cref="IEnumerable{T}"/></typeparam>
        /// <param name="values">格納する値の一覧</param>
        /// <returns>指定した値と等価な内容を含むQi Frameworkの配列</returns>
        public static QiListBase CreateFrom<T>(IEnumerable<T> values)
        {
            var type = typeof(T);
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return Create(values.Select(v=> new QiBool((bool)Convert.ChangeType(v, TypeCode.Boolean))));
                case TypeCode.Byte: return Create(values.Select(v => new QiUInt8((byte)Convert.ChangeType(v, TypeCode.Byte))));
                case TypeCode.UInt16: return Create(values.Select(v => new QiUInt16((ushort)Convert.ChangeType(v, TypeCode.UInt16))));
                case TypeCode.UInt32: return Create(values.Select(v => new QiUInt32((uint)Convert.ChangeType(v, TypeCode.UInt32))));
                case TypeCode.UInt64: return Create(values.Select(v => new QiUInt64((ulong)Convert.ChangeType(v, TypeCode.UInt64))));
                case TypeCode.SByte: return Create(values.Select(v => new QiInt8((sbyte)Convert.ChangeType(v, TypeCode.SByte))));
                case TypeCode.Int16: return Create(values.Select(v => new QiInt16((short)Convert.ChangeType(v, TypeCode.Int16))));
                case TypeCode.Int32: return Create(values.Select(v => new QiInt32((int)Convert.ChangeType(v, TypeCode.Int32))));
                case TypeCode.Int64: return Create(values.Select(v => new QiInt64((long)Convert.ChangeType(v, TypeCode.Int64))));
                case TypeCode.String: return Create(values.Select(v => new QiString((string)Convert.ChangeType(v, TypeCode.String))));
                case TypeCode.Single: return Create(values.Select(v => new QiFloat((float)Convert.ChangeType(v, TypeCode.Single))));
                case TypeCode.Double: return Create(values.Select(v => new QiDouble((double)Convert.ChangeType(v, TypeCode.Double))));
                default: break;
            }

            //バイトデータの配列ってAPIで見かけてない気がするのでサポートしない方針を取る
            //if (type == typeof(byte[])) return new QiByteData(v as byte[]);


            throw new InvalidOperationException($"Given type is not supported, {type}");
        }

        #region ひじょーにモッサリしてるが組み込み型からの

        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiBool> Create(IEnumerable<bool> values) => Create(values.Select(v => new QiBool(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiUInt8> Create(IEnumerable<byte> values) => Create(values.Select(v => new QiUInt8(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiUInt16> Create(IEnumerable<ushort> values) => Create(values.Select(v => new QiUInt16(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiUInt32> Create(IEnumerable<uint> values) => Create(values.Select(v => new QiUInt32(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiUInt64> Create(IEnumerable<ulong> values) => Create(values.Select(v => new QiUInt64(v)));    
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiInt8> Create(IEnumerable<sbyte> values) => Create(values.Select(v => new QiInt8(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiInt16> Create(IEnumerable<short> values) => Create(values.Select(v => new QiInt16(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiInt32> Create(IEnumerable<int> values) => Create(values.Select(v => new QiInt32(v)));
        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiInt64> Create(IEnumerable<long> values) => Create(values.Select(v => new QiInt64(v)));

        #endregion
    }


    /// <summary><see cref="QiList"/>を扱いやすくするための拡張メソッドを定義します。</summary>
    public static class QiListExtension
    {
        /// <summary>
        /// IEnumerableを対応する<see cref="QiList"/>に変換します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static QiList<T> ToQiList<T>(this IEnumerable<T> values) where T : QiAnyValue
            => QiList<T>.Create(values);

    }

}
