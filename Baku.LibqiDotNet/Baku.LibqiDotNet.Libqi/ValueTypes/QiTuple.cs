using System.Linq;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>複数の要素を一括りにして扱うタプル型を表します。</summary>
    public sealed class QiTuple : QiInputValue
    {
        private QiTuple(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; }

        /// <summary>要素の個数を取得します。</summary>
        public int Count => QiValue.Count;

        /// <summary>内容として用いる値を指定してタプルを生成します。</summary>
        /// <param name="values">タプルに含む値</param>
        /// <returns>指定した値を順に格納したタプル</returns>
        public static QiTuple Create(params QiInputValue[] values)
        {
            string sig = 
                QiSignatures.TypeTupleBegin +
                string.Join("", values.Select(v => v.Signature).ToArray()) + 
                QiSignatures.TypeTupleEnd;

            var tuple = QiValue.Create(sig);

            for (int i = 0; i < values.Length; i++)
            {
                //Dynamicはそのまま渡すと想定外の入れ子構造を取るので中身を渡す
                if(values[i].Signature == QiSignatures.TypeDynamic)
                {
                    tuple[i] = (values[i] as QiDynamic).Value;
                }
                else
                {
                    tuple[i] = values[i].QiValue;
                }
            }
            return new QiTuple(tuple, sig);
        }

        /// <summary>
        /// 全ての要素が<see cref="QiDynamic"/>であるようなタプルを生成します。
        /// このようなタプルは<see cref="QiMethod.Call"/>の引数として渡す処理に適しています。
        /// </summary>
        /// <param name="values">タプルの要素</param>
        /// <returns>生成されたタプル</returns>
        public static QiTuple CreateDynamic(params QiInputValue[] values)
        {
            string sig = QiSignatures.TypeTupleBegin +
                new string(QiSignatures.TypeDynamic[0], values.Length) +
                QiSignatures.TypeTupleEnd;

            var tuple = QiValue.Create(sig);

            for (int i = 0; i < values.Length; i++)
            {
                tuple[i] = values[i].QiValue;
            }
            return new QiTuple(tuple, sig);

        }

    }
}
