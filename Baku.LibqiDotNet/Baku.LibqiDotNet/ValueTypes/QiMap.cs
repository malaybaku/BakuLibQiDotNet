using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>連想配列(辞書)型を表します。</summary>
    public sealed class QiMap<K, V> : QiAnyValue
        where K : QiAnyValue
        where V : QiAnyValue
    {
        private QiMap(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; }

        /// <summary>キーを指定して対応する値を取得します。</summary>
        /// <param name="key">キー</param>
        /// <returns>キーに対応した値</returns>
        public QiValue this[K key]
        {
            get { return QiValue[key.QiValue]; }
            set { QiValue[key.QiValue] = value; }
        }

        /// <summary>キーと値のペアを用いてマップ型変数を生成します。</summary>
        /// <param name="values">キーと値のペア</param>
        /// <returns>入力データに対応するマップ型変数</returns>
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

    /// <summary>ジェネリック型である<see cref="QiMap{K, V}"/>のインスタンスを生成するファクトリメソッドを提供します。</summary>
    public static class QiMap
    {
        /// <summary>指定されたキー、値ペアの一覧を用いて辞書型データを生成します。</summary>
        /// <typeparam name="K">キーの型</typeparam>
        /// <typeparam name="V">値の型</typeparam>
        /// <param name="items">データの内容となる値の一覧</param>
        /// <returns>指定したデータを保持する辞書型データ</returns>
        public static QiMap<K, V> ToQiMap<K, V>(this IEnumerable<KeyValuePair<K, V>> items)
            where K : QiAnyValue
            where V : QiAnyValue
        {
            return QiMap<K, V>.Create(items);
        }

        /// <summary>指定されたキー、値ペアの一覧を用いて辞書型データを生成します。</summary>
        /// <typeparam name="K">キーの型</typeparam>
        /// <typeparam name="V">値の型</typeparam>
        /// <param name="items">データの内容となる値の一覧</param>
        /// <returns>指定したデータを保持する辞書型データ</returns>
        public static QiMap<K, V> Create<K, V>(params KeyValuePair<K, V>[] items)
            where K : QiAnyValue
            where V : QiAnyValue
        {
            return items.ToQiMap();
        }

    }
}
