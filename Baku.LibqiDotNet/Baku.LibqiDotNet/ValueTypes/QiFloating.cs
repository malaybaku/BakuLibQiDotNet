
namespace Baku.LibqiDotNet
{
    /// <summary>4バイトデータからなる単精度浮動小数点数を表します。</summary>
    public class QiFloat : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiFloat(float value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeFloat);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeFloat;

        /// <summary>格納される値を取得、設定します。</summary>
        public float Value
        {
            get { return (float)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }

    /// <summary>8バイトデータからなる倍精度浮動小数点数を表します。</summary>
    public class QiDouble : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiDouble(double value)
        {
            QiValue = QiValue.Create(QiSignatures.TypeFloat);
            QiValue.SetValue(value);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeDouble;

        /// <summary>格納される値を取得、設定します。</summary>
        public double Value
        {
            get { return (double)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }
}
