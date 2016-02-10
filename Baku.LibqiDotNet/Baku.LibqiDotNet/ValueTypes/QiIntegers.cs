using System;

namespace Baku.LibqiDotNet
{
    /// <summary>ブール型を表します。</summary>
    public class QiBool : QiAnyValue
    {
        private QiBool(QiValue value)
        {
            QiValue = value;
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeBool;

        //TODO:boolってIOどうだったか確認してないよね確か。バイト割り当て数含めて要チェック
        public bool Value
        {
            get { return (bool)QiValue.Value; }
            set { QiValue.SetValue(Convert.ToByte(value)); }
        }

        public static QiBool Create(QiValue value)
        {
            if (value.GetSignature() != QiSignatures.TypeBool)
            {
                throw new InvalidOperationException();
            }
            return new QiBool(value);
        }

        public static QiBool Create(bool value)
        {
            var val = QiValue.Create(QiSignatures.TypeBool);
            val.SetValue(Convert.ToByte(value));
            return new QiBool(val);
        }

    }

    /// <summary>符号あり1バイト整数を表します。</summary>
    public class QiInt8 : QiAnyValue
    {
        private QiInt8(QiValue value)
        {
            QiValue = value;
        }
        public QiInt8 (sbyte value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt8);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeInt8;

        public sbyte Value
        {
            get { return (sbyte)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号あり2バイト整数を表します。</summary>
    public class QiInt16 : QiAnyValue
    {
        public QiInt16(QiValue value)
        {
            QiValue = value;
        }
        public QiInt16(short value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt16);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeInt16;

        public short Value
        {
            get { return (short)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号あり4バイト整数を表します。</summary>
    public class QiInt32 : QiAnyValue
    {
        public QiInt32(QiValue value)
        {
            QiValue = value;
        }
        public QiInt32(int value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt32);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeInt32;

        public int Value
        {
            get { return (int)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }
    }

    /// <summary>符号あり8バイト整数を表します。</summary>
    public class QiInt64 : QiAnyValue
    {
        public QiInt64(QiValue value)
        {
            QiValue = value;
        }
        public QiInt64(long value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt64);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeInt64;

        public long Value
        {
            get { return (long)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号なし1バイト整数を表します。</summary>
    public class QiUInt8 : QiAnyValue
    {
        public QiUInt8(QiValue value)
        {
            QiValue = value;
        }
        public QiUInt8(byte value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt8);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeUInt8;

        public byte Value
        {
            get { return (byte)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号なし2バイト整数を表します。</summary>
    public class QiUInt16 : QiAnyValue
    {
        public QiUInt16(QiValue value)
        {
            QiValue = value;
        }
        public QiUInt16(ushort value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt16);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeUInt16;

        public ushort Value
        {
            get { return (ushort)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }


    }

    /// <summary>符号なし4バイト整数を表します。</summary>
    public class QiUInt32 : QiAnyValue
    {
        public QiUInt32(QiValue value)
        {
            QiValue = value;
        }
        public QiUInt32(uint value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt32);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeUInt32;

        public uint Value
        {
            get { return (uint)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }
    }

    /// <summary>符号なし8バイト整数を表します。</summary>
    public class QiUInt64 : QiAnyValue
    {
        public QiUInt64(QiValue value)
        {
            QiValue = value;
        }
        public QiUInt64(ulong value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt64);
            QiValue.SetValue(value);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeUInt64;

        public ulong Value
        {
            get { return (ulong)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

}
