namespace Baku.LibqiDotNet
{
    /// <summary>Qiのセッションからロード出来る、関数一覧を保持するオブジェクトを表します。</summary>
    public interface IQiObject
    {
        /// <summary>メソッド名を指定し、メソッドを取得します。</summary>
        IQiMethod this[string methodName] { get; }

        /// <summary>サービスの名前を取得します。</summary>
        string Name { get; }

        /// <summary>サービスの機能に関する説明文を取得します。</summary>
        string Description { get; }

        /// <summary>オブジェクトのプロパティ名を指定して値を取得します。</summary>
        IQiFuture<T> GetProperty<T>(string pname);

        /// <summary>オブジェクトの指定したプロパティに指定した値を設定します。</summary>
        IQiFuture SetProperty(string pname, object v);
    }
}
