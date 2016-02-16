
namespace Baku.LibqiDotNet.ValueTypes
{
    /// <summary>バイナリデータを表します。</summary>
    public class QiByteData : QiAnyValue
    {
        /// <summary>格納する値を指定してインスタンスを初期化します。</summary>
        /// <param name="data">格納する値</param>
        public QiByteData(byte[] data)
        {
            QiValue = QiValue.Create(QiSignatures.TypeRaw);
            QiValue.SetValue(data);
        }

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeRaw;

        /// <summary>格納しているデータを取得、設定します。</summary>
        public byte[] Value
        {
            get { return QiValue.GetRaw(); }
            set { QiValue.SetValue(value); }
        }

    }
}
