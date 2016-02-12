
namespace Baku.LibqiDotNet.ValueTypes
{
    /// <summary>バイナリデータを表します。</summary>
    public class QiByteData : QiAnyValue
    {
        /// <summary>
        /// 格納する値を指定してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">格納する値</param>
        public QiByteData(byte[] data)
        {
            QiValue = QiValue.Create(QiSignatures.TypeRaw);
            QiValue.SetValue(data);
        }

        public override QiValue QiValue { get; }

        public override string Signature { get; } = QiSignatures.TypeRaw;

        public byte[] Value
        {
            get { return QiValue.GetRaw(); }
            set { QiValue.SetValue(value); }
        }

    }
}
