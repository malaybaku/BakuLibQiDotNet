using System;

namespace Baku.LibqiDotNet
{

    public class QiFloat : QiAnyValue
    {
        public QiFloat(QiValue value)
        {
            if (value.ValueKind != QiValueKind.QiFloat)
            {
                throw new InvalidOperationException();
            }

            QiValue = value;
        }

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
        public QiDouble(QiValue value)
        {
            if (value.ValueKind != QiValueKind.QiFloat)
            {
                throw new InvalidOperationException();
            }

            QiValue = value;
        }

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
