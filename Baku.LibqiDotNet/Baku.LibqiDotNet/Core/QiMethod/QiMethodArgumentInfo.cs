namespace Baku.LibqiDotNet
{
    /// <summary>Qiの関数引数に関する情報を表します。</summary>
    public sealed class QiMethodArgumentInfo
    {
        internal QiMethodArgumentInfo(QiValue argInfo)
        {
            Name = argInfo[0].ToString();
            Description = argInfo[1].ToString();
        }

        /// <summary>引数の名前を取得します。</summary>
        public string Name { get; }
        /// <summary>引数の意味について要約文を取得します。</summary>
        public string Description { get; }
    }
}
