using System;
using System.Collections;
using System.Collections.Generic;

//名前空間をBaku.LibqiDotNetにすると汚染感が高いので注意
namespace Baku.LibqiDotNet.Utils
{
    /// <summary>値の読み取りのみが許可されているリストを表します。</summary>
    /// <typeparam name="T">要素の型</typeparam>
    public sealed class ReadOnlyList<T> : IEnumerable<T>
    {
        /// <summary>データ元となるリストによりインスタンスを初期化します。</summary>
        /// <param name="source">データ元のリスト</param>
        public ReadOnlyList(IList<T> source)
        {
            _source = source;
        }

        private readonly IList<T> _source;

        /// <summary>要素の個数を取得します。</summary>
        public int Count => _source.Count;

        /// <summary>インデクスを指定して要素を取得します。</summary>
        /// <param name="index">取得する要素のインデックス</param>
        /// <returns>指定したインデックスの要素</returns>
        /// <exception cref="IndexOutOfRangeException"/>
        public T this[int index] => _source[index];

        /// <summary>リストを走査する列挙子を取得します。</summary>
        /// <returns>リストを走査する列挙子</returns>
        public IEnumerator<T> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();
    }
}
