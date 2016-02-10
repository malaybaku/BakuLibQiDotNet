using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>通信セッションを表します。</summary>
    public class QiSession
    {
        internal QiSession(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        public void Destroy() => QiApiSession.Destroy(this);

        public QiFuture Connect(string address) => QiApiSession.Connect(this, address);

        public string GetUrl() => QiApiSession.GetUrl(this);

        public int SetIdentity(string key, string crt) => QiApiSession.SetIdentity(this, key, crt);

        public bool CheckIsConnected() => QiApiSession.IsConnected(this);

        public QiFuture Listen(string address, bool standAlone = false)
            => QiApiSession.Listen(this, address, standAlone);

        public QiFuture RegisterService(string name, QiObject obj)
            => QiApiSession.RegisterService(this, name, obj);

        public QiFuture UnregisterService(uint idx) => QiApiSession.UnregisterService(this, idx);

        public QiValue GetEndpoints() => QiApiSession.GetEndpoints(this);

        public QiFuture GetService(string name) => QiApiSession.GetService(this, name);

        public QiFuture GetServices() => QiApiSession.GetServices(this);

        public QiFuture Close() => QiApiSession.Close(this);


        public static QiSession Create() => QiApiSession.Create();
    }


}
