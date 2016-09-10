using Baku.LibqiDotNet;

namespace Test.Baku.LibqiDotNet
{
    public static class ConnectionSetting
    {
        internal static readonly string LibqiIP = "192.168.1.4";
        internal static readonly int LibqiPort = QiSession.DefaultTcpPort;

        internal static readonly string SocketIP = "192.168.1.4";
        internal static readonly int SocketIOPort = QiSession.DefaultHttpPort; 
    }
}

