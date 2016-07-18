namespace Baku.LibqiDotNet
{
    /// <summary>接続先との接続を表します。</summary>
    public interface IQiSession
    {
        /// <summary>指定したアドレスへの接続を試みます。</summary>
        IQiFuture ConnectAsync(string address);

        /// <summary>セッションが接続済みになっているかを取得します。</summary>
        bool IsConnected { get; }

        /// <summary>セッションを閉じます。</summary>
        void Close();

        /// <summary>サービス名を指定してサービスを取得します。</summary>
        IQiFuture<IQiObject> GetServiceAsync(string name);

        //NOTE: ここから下はsocket.ioではサポートしないでよい

        /// <summary>セッションをリスンします。</summary>
        /// <param name="address">リスン先アドレスです。例えばアクセスを制限しない場合は"tcp://0.0.0.0:0"を指定します。</param>
        /// <param name="standAlone">アプリケーションがスタンドアロンである場合はtrueにします。通常は設定する必要はありません。</param>
        /// <returns>リスン結果への予約</returns>
        IQiFuture ListenAsync(string address, bool standAlone);

        /// <summary>サービスに名前を付けて登録します。</summary>
        /// <param name="name">登録するサービス名</param>
        /// <param name="obj">登録するサービス本体</param>
        /// <returns><see cref="UnregisterServiceAsync(uint)"/>の引数で渡すためのIDをGetUInt64で取得してください。</returns>
        IQiFuture<uint> RegisterServiceAsync(string name, IQiObject obj);

        /// <summary>IDを指定し、サービスの登録を解除します。</summary>
        /// <param name="idx">解除したいサービスにつけられたID</param>
        IQiFuture UnregisterServiceAsync(uint idx);

        /// <summary>
        /// セッションのエンドポイント情報を取得します。
        /// [TODO]エンドポイントの型情報が分かったら内容をI/F化すること
        /// </summary>
        IQiResult GetEndpoints();
    }

    /// <summary><see cref="IQiSession"/>の拡張メソッドを提供します。</summary>
    public static class IQiSessionExtensions
    {
        /// <summary>指定したアドレスへの接続を試みます。</summary>
        public static void Connect(this IQiSession session, string address)
            => session.ConnectAsync(address).Wait();

        /// <summary>サービス名を指定してサービスを取得します。</summary>
        public static IQiObject GetService(this IQiSession session, string name)
            => session.GetServiceAsync(name).Get();

        /// <summary>セッションをリスンします。</summary>
        /// <param name="session">処理を行うセッション</param>
        /// <param name="address">リスン先アドレスです。例えばアクセスを制限しない場合は"tcp://0.0.0.0:0"を指定します。</param>
        /// <param name="standAlone">アプリケーションがスタンドアロンである場合はtrueにします。通常は設定する必要はありません。</param>
        /// <returns>リスン結果への予約</returns>
        public static void Listen(this IQiSession session, string address, bool standAlone = false)
            => session.ListenAsync(address, standAlone).Wait();

        /// <summary>サービスに名前を付けて登録します。</summary>
        /// <param name="session">処理を行うセッション</param>
        /// <param name="name">登録するサービス名</param>
        /// <param name="obj">登録するサービス本体</param>
        /// <returns><see cref="IQiSession.UnregisterServiceAsync(uint)"/>の引数で渡すためのID</returns>
        public static uint RegisterService(this IQiSession session, string name, IQiObject obj)
            => session.RegisterServiceAsync(name, obj).Get();

        /// <summary>IDを指定し、サービスの登録を解除します。</summary>
        /// <param name="session">処理を行うセッション</param>
        /// <param name="idx">解除したいサービスにつけられたID</param>
        public static void UnregisterService(this IQiSession session, uint idx)
            => session.UnregisterServiceAsync(idx).Wait();
    }
}
