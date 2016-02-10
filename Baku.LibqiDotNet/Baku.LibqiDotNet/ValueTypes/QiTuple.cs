using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>複数の要素を一括りにして扱うタプル型を表します。</summary>
    public class QiTuple : QiAnyValue
    {
        private QiTuple(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; }

        public static QiTuple Create(params QiAnyValue[] values)
        {
            string sig = 
                QiSignatures.TypeTupleBegin + 
                string.Concat(values.Select(v => v.Signature)) + 
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



    }
}
