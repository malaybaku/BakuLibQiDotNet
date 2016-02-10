using System;

namespace Baku.LibqiDotNet
{

    public class QiFloat : QiAnyValue
    {
        public QiFloat(float value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeFloat);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeFloat;

        public float Value
        {
            get { return (float)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    public class QiDouble : QiAnyValue
    {
        public QiDouble(double value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeFloat);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeDouble;

        public double Value
        {
            get { return (double)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }
}
