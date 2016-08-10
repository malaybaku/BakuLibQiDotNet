using Baku.Websocket.Client;

namespace Baku.LibqiDotNet
{
    public class QiSessionFactory : QiSessionFactoryBase
    {
        protected override IWebSocket GetWebSocket()
        {
            return new UWP.LibqiWebSocket();
        }
    }
}
