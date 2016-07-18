namespace Baku.LibqiDotNet
{
    /// <summary>メソッドの一覧を表します。</summary>
    public interface IQiMethods
    {
        /// <summary>利用可能なメソッドをメソッド名で取得します。</summary>
        IQiMethod this[string methodName] { get; }
    }
}
