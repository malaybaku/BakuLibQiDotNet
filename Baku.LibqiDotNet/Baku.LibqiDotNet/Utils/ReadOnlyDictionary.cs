using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baku.LibqiDotNet.Utils
{
    /// <summary>値の読み取りのみが許可された辞書データを表します。</summary>
    /// <typeparam name="TKey">キーの型</typeparam>
    /// <typeparam name="TValue">値の型</typeparam>
    public class ReadOnlyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>データ元となる辞書によってインスタンスを初期化します。</summary>
        /// <param name="source">データ元の辞書</param>
        public ReadOnlyDictionary(IDictionary<TKey, TValue> source)
        {
            _source = source;
        }

        private readonly IDictionary<TKey, TValue> _source;

        /// <summary>要素数を取得します。</summary>
        public int Count => _source.Count;

        /// <summary>指定したキー、値のペアが含まれているかを取得します。</summary>
        /// <param name="pair">含まれるかどうかを検証するキーおよび値のペア</param>
        /// <returns>ペアが含まれる場合はtrue</returns>
        public bool Contains(KeyValuePair<TKey, TValue> pair) => _source.Contains(pair);

        /// <summary>指定したキーが含まれるかを取得します。</summary>
        /// <param name="key">探索対象のキー</param>
        /// <returns>キーが含まれる場合はtrue</returns>
        public bool ContainsKey(TKey key) => _source.ContainsKey(key);
        
        /// <summary>キーを指定して対応する値を取得します。</summary>
        /// <param name="key">キー</param>
        /// <returns>キーに対応づけられた値</returns>
        /// <exception cref="KeyNotFoundException"/>
        public TValue this[TKey key] => _source[key];

        /// <summary>キーの一覧を取得します。</summary>
        public ICollection<TKey> Keys => _source.Keys;

        /// <summary>値の一覧を取得します。</summary>
        public ICollection<TValue> Values => _source.Values;

        /// <summary>データに対応した列挙子を取得します。</summary>
        /// <returns>データを操作する列挙子</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();

    }
}
