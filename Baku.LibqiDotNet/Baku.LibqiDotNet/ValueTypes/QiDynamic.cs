using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baku.LibqiDotNet
{
    public class QiDynamic : QiAnyValue
    {
        public QiDynamic(QiValue value)
        {
            if (value.ValueKind == QiValueKind.QiDynamic)
            {
                QiValue = value;
            }
            else
            {
                QiValue = QiValue.Create(QiSignatures.TypeDynamic);
                QiValue.SetValue(value);
            }
        }
        public QiDynamic(QiAnyValue v) : this(v.QiValue) { }


        public override QiValue QiValue { get; }
        public override string Signature { get; } = QiSignatures.TypeDynamic;

        public QiValue Value
        {
            get { return QiValue.Value as QiValue; }
        }
    }

    public static class QiDynamicExtension
    {
        public static QiDynamic ToDynamic(this QiAnyValue v) => new QiDynamic(v);

    }
}
