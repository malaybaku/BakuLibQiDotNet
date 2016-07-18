
namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>文字列型を表します。</summary>
    public sealed class QiString : QiInputValue
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

        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }

        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeString;

        /// <summary>格納したデータを取得、設定します。</summary>
        public string Value
        {
            get { return QiValue.ToString(); }
            set { QiValue.SetValue(value); }
        }

        /// <summary>指定した文字列を、その文字列を保持する<see cref="QiString"/>に変換します。</summary>
        /// <param name="v">実際のデータとなる文字列</param>
        public static implicit operator QiString(string v) => new QiString(v);

    }
}
