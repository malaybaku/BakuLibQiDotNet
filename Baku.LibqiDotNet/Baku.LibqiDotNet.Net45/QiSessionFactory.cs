using Baku.Websocket.Client;
using Baku.LibqiDotNet.WebSocketImpl;

namespace Baku.LibqiDotNet
{
    public class QiSessionFactory : QiSessionFactoryBase
    {
        protected override IWebSocket GetWebSocket()
            => new WebSocket();
    }

}
