using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>連想配列(辞書)型を表します。</summary>
    public class QiMap<K, V> : QiAnyValue
        where K : QiAnyValue
        where V : QiAnyValue
    {
        public QiMap(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; }

        //NOTE: 機構上値の型をVにするのがちょっと難しいので妥協
        public QiValue this[K key]
        {
            get { return QiValue[key.QiValue]; }
            set { QiValue[key.QiValue] = value; }
        }

        public static QiMap<K, V> Create(IEnumerable<KeyValuePair<K, V>> values)
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("values length must be greater than 0");
            }

            //中身のシグネチャ揃ってるかどうか検証
            var pf = values.First();
            var ksig = pf.Key.Signature;
            var vsig = pf.Value.Signature;

            if (values.Any(pair => (pair.Key.Signature != ksig || pair.Value.Signature != vsig)))
            {
                throw new InvalidOperationException("key or values type is inconsistent");
            }

            string sig = QiSignatures.TypeMapBegin + ksig + vsig + QiSignatures.TypeMapEnd;

            var map = QiValue.Create(sig);
            foreach (var pair in values)
            {
                map[pair.Key.QiValue] = pair.Value.QiValue;
            }
            return new QiMap<K, V>(map, sig);
        }

    }
}
