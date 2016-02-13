using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//名前空間をBaku.LibqiDotNetにすると汚染感が高いので注意
namespace Baku.LibqiDotNet.Utils
{
    public class ReadOnlyList<T> : IEnumerable<T>
    {
        public ReadOnlyList(IList<T> source)
        {
            _source = source;
        }

        private readonly IList<T> _source;

        public int Count => _source.Count;

        public T this[int index] => _source[index];

        public IEnumerator<T> GetEnumerator() => _source.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _source.GetEnumerator();
    }
}
