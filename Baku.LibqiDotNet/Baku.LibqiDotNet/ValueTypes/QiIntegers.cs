﻿using System;

namespace Baku.LibqiDotNet
{
    /// <summary>ブール型を表します。</summary>
    public sealed class QiBool : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiBool(bool value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeBool);
            QiValue.SetValue(Convert.ToInt64(value));
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeBool;

        /// <summary>格納される値を取得、設定します。</summary>
        public bool Value
        {
            get { return QiValue.ToBool(); }
            set { QiValue.SetValue(Convert.ToByte(value)); }
        }

    }

    /// <summary>符号あり1バイト整数を表します。</summary>
    public sealed class QiInt8 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiInt8 (sbyte value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt8);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeInt8;

        /// <summary>格納される値を取得、設定します。</summary>
        public sbyte Value
        {
            get { return QiValue.ToSByte(); }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号あり2バイト整数を表します。</summary>
    public sealed class QiInt16 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiInt16(short value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt16);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeInt16;

        /// <summary>格納される値を取得、設定します。</summary>
        public short Value
        {
            get { return QiValue.ToInt16(); }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号あり4バイト整数を表します。</summary>
    public sealed class QiInt32 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiInt32(int value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt32);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeInt32;

        /// <summary>格納される値を取得、設定します。</summary>
        public int Value
        {
            get { return QiValue.ToInt32(); }
            set { QiValue.SetValue(value); }
        }
    }

    /// <summary>符号あり8バイト整数を表します。</summary>
    public sealed class QiInt64 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiInt64(long value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeInt64);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeInt64;

        /// <summary>格納される値を取得、設定します。</summary>
        public long Value
        {
            get { return QiValue.ToInt64(); }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号なし1バイト整数を表します。</summary>
    public sealed class QiUInt8 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiUInt8(byte value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt8);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeUInt8;

        /// <summary>格納される値を取得、設定します。</summary>
        public byte Value
        {
            get { return QiValue.ToByte(); }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>符号なし2バイト整数を表します。</summary>
    public sealed class QiUInt16 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiUInt16(ushort value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt16);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeUInt16;

        /// <summary>格納される値を取得、設定します。</summary>
        public ushort Value
        {
            get { return QiValue.ToUInt16(); }
            set { QiValue.SetValue(value); }
        }


    }

    /// <summary>符号なし4バイト整数を表します。</summary>
    public sealed class QiUInt32 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiUInt32(uint value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt32);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeUInt32;

        /// <summary>格納される値を取得、設定します。</summary>
        public uint Value
        {
            get { return QiValue.ToUInt32(); }
            set { QiValue.SetValue(value); }
        }
    }

    /// <summary>符号なし8バイト整数を表します。</summary>
    public sealed class QiUInt64 : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiUInt64(ulong value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeUInt64);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeUInt64;

        /// <summary>格納される値を取得、設定します。</summary>
        public ulong Value
        {
            get { return QiValue.ToUInt64(); }
            set { QiValue.SetValue(value); }
        }

    }

}
