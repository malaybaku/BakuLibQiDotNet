
namespace Baku.LibqiDotNet
{
    /// <summary>Qiの値型の基底</summary>
    public abstract class QiAnyValue
    {
        /// <summary>実際の値を取得します。</summary>
        public abstract QiValue QiValue { get; }

        /// <summary>値の種類を表すシグネチャを取得します。</summary>
        public abstract string Signature { get; }

        /// <summary>値の情報をデバッグ用文字列として取得します。</summary>
        /// <returns>値をあらわすデバッグ用の文字列</returns>
        public string Dump() => QiValue.Dump();

    }
}
