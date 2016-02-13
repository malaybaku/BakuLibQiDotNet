using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baku.LibqiDotNet.Utils
{
    public class ReadOnlyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public ReadOnlyDictionary(IDictionary<TKey, TValue> source)
        {
            _source = source;
        }

        private readonly IDictionary<TKey, TValue> _source;

        public int Count => _source.Count;

        public bool Contains(KeyValuePair<TKey, TValue> pair) => _source.Contains(pair);

        public bool ContainsKey(TKey key) => _source.ContainsKey(key);

        public TValue this[TKey key] => _source[key];

        public ICollection<TKey> Keys => _source.Keys;

        public ICollection<TValue> Values => _source.Values;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();

    }
}
