using Baku.Websocket.Client;

namespace Baku.LibqiDotNet
{
    /// <summary>UWPのWebSocket実装を提供するQiSessionのファクトリを表します。</summary>
    public class QiSessionFactory : QiSessionFactoryBase
    {
        /// <summary>UWPのWebSocketライブラリによるWebSocket実装を取得します。</summary>
        /// <returns>WebSocketの実装</returns>
        protected override IWebSocket GetWebSocket()
            => new UWP.LibqiWebSocket();
    }
}
