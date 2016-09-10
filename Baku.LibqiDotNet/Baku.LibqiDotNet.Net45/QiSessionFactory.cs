using Baku.Websocket.Client;
using Baku.LibqiDotNet.WebSocketImpl;

namespace Baku.LibqiDotNet
{
    /// <summary>実際のWebSocket実装が導入されたQiSessionのファクトリを表します。</summary>
    public class QiSessionFactory : QiSessionFactoryBase
    {
        /// <summary>実際のWebSocket実装を取得します。</summary>
        /// <returns>実装されたWebSocket</returns>
        protected override IWebSocket GetWebSocket()
            => new WebSocket();
    }

}
