using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>可変な配列型を表します。配列は単調に伸びる処理だけが許可されています。</summary>
    public class QiList : QiAnyValue
    {
        private QiList(QiValue value, string sig)
        {
            QiValue = value;
            Signature = sig;
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; }

        public static QiList Create<T>(IEnumerable<T> values, bool createDynamicList=false)
            where T : QiAnyValue
        {
            if (!values.Any())
            {
                throw new InvalidOperationException("values length must be greater than 0");
            }

            //リストは中身のシグネチャ揃ってないとアウト(ダイナミックリストの場合は例外)
            string elemSig = QiSignatures.TypeDynamic;
            if(!createDynamicList)
            {
                elemSig = values.First().Signature;
                if (values.Any(v => v.Signature != elemSig))
                {
                    throw new InvalidOperationException("values kind is not same");
                }
            }

            string sig = QiSignatures.TypeListBegin + elemSig + QiSignatures.TypeListEnd;

            var list = QiValue.Create(sig);
            foreach (var v in values)
            {
                list.AddElement(v.QiValue);
            }
            return new QiList(list, sig);
        }

    }

    public static class QiListExtension
    {
        public static QiList ToQiList<T>(this IEnumerable<T> values)
            where T : QiAnyValue
            => QiList.Create(values, false);

        public static QiList ToDynamicQiList<T>(this IEnumerable<T> values)
            where T : QiAnyValue
            => QiList.Create(values, true);
    }
}
