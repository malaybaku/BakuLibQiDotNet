using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>可変な配列型を表します。配列は単調に伸びる処理だけが許可されています。</summary>
    public sealed class QiList<T> : QiAnyValue 
        where T : QiAnyValue
    {
        private QiList(IEnumerable<T> values, string sig)//QiValue value, string sig)
        {
            var list = QiValue.Create(sig);
            foreach (var v in values)
            {
                list.AddElement(v.QiValue);
            }
            QiValue = list;
            Values = values.Select(v => v);

            Signature = sig;
        }

        /// <summary>要素数を取得します。</summary>
        public int Count => QiValue.Count;

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; }

        /// <summary>インデクスを指定して要素を取得、設定します。</summary>
        /// <param name="i">インデックス</param>
        /// <returns>インデックスで指定した要素</returns>
        public QiValue this[int i]
        {
            get { return this.QiValue[i]; }
            set { this.QiValue[i] = value; }
        }

        /// <summary>インスタンスの生成時に用いたデータを取得します。</summary>
        public IEnumerable<T> Values { get; }

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

            return new QiList<T>(values, sig);
        }

        /// <summary>
        /// 列挙された<see cref="QiAnyValue"/>派生型を要素として含む、動的型の内容からなるリストを生成します。
        /// </summary>
        /// <param name="values">何かしらの値の列挙</param>
        /// <returns>指定した値を保持する動的型のリスト</returns>
        public static QiList<QiDynamic> CreateDynamic(IEnumerable<QiAnyValue> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("values length must be greater than 0");
            }

            string sig = QiSignatures.TypeListBegin + QiSignatures.TypeDynamic + QiSignatures.TypeListEnd;

            return new QiList<QiDynamic>(values.Select(v => v.ToDynamic()), sig);
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
        public static QiList<T> Create<T>(IEnumerable<T> values) 
            where T : QiAnyValue
            => QiList<T>.Create(values);

        /// <summary>
        /// 列挙された<see cref="QiAnyValue"/>派生型を要素として含む、動的型の内容からなるリストを生成します。
        /// </summary>
        /// <param name="values">何かしらの値の列挙</param>
        /// <returns>指定した値を保持する動的型のリスト</returns>
        public static QiList<QiDynamic> CreateDynamic(IEnumerable<QiAnyValue> values)
            => QiList<QiAnyValue>.CreateDynamic(values);

        #region ひじょーにモッサリしてるが組み込み型からの配列生成をサポートしとく

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

        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiFloat> Create(IEnumerable<float> values) => Create(values.Select(v => new QiFloat(v)));

        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiDouble> Create(IEnumerable<double> values) => Create(values.Select(v => new QiDouble(v)));

        /// <summary>値の一覧からQi Frameworkで利用可能な配列を生成します。</summary>
        /// <param name="values">入力値の一覧</param>
        /// <returns>入力と等価な配列</returns>
        public static QiList<QiString> Create(IEnumerable<string> values) => Create(values.Select(v => new QiString(v)));


        #endregion
    }

    /// <summary><see cref="QiList"/>を扱いやすくするための拡張メソッドを定義します。</summary>
    public static class QiListExtension
    {
        /// <summary>
        /// IEnumerableを対応する<see cref="QiList"/>に変換します。
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="values">実際の要素の列挙</param>
        /// <returns>指定したデータを保持する配列</returns>
        public static QiList<T> ToQiList<T>(this IEnumerable<T> values)
            where T : QiAnyValue
            => QiList<T>.Create(values);

        /// <summary>
        /// 動的型(<see cref="QiDynamic"/>)でパックした配列への変換を行います。
        /// </summary>
        /// <param name="values">何かしらの値の列挙</param>
        /// <returns>指定した値を保持する動的型のリスト</returns>
        public static QiList<QiDynamic> ToQiDynamicList<T>(this IEnumerable<T> values)
            where T : QiAnyValue
            => QiList.CreateDynamic(values.Cast<QiAnyValue>());


    }

}
