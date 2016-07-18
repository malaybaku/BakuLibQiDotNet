
namespace Baku.LibqiDotNet
{
    /// <summary>Qiのアプリケーション(サーバ的処理の担当オブジェクト)を表します。</summary>
    public interface IQiApplication
    {
        /// <summary>サーバとしてアプリケーションを実行します。クライアントでは呼び出しは必要ありません。</summary>
        void Run();

        /// <summary>アプリケーションを停止します。</summary>
        void Stop();
    }
}
