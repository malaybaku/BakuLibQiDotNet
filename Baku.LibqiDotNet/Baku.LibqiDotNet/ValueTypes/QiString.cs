
namespace Baku.LibqiDotNet
{
    /// <summary>文字列型を表します。</summary>
    public class QiString : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiString(string value)
        {
            var val = QiValue.Create(QiSignatures.TypeString);
            val.SetValue(value);
            QiValue = val;
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeString;

        public string Value
        {
            get { return (string)QiValue.Value; }
            set { QiValue.SetValue(value); }
        }

    }
}
