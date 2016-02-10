using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>アプリケーションを表します。初期化処理等を行うために用います</summary>
    public class QiApplication
    {
        internal QiApplication(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }

        public void Destroy() => QiApiApplication.Destroy(this);

        public void Run() => QiApiApplication.Run(this);

        public void Stop() => QiApiApplication.Stop(this);

        public static bool IsApplicationInitialized => QiApiApplication.CheckInitialized();


        public static QiApplication Create(string[] args) => QiApiApplication.Create(args);


    }


}
