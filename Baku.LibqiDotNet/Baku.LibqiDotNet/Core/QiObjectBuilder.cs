using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{

    /// <summary>
    /// <see cref="QiObject"/>のビルダークラスです。
    /// サービスを作る場合以外使わないハズなので実装は最低限です。
    /// </summary>
    public class QiObjectBuilder
    {
        internal QiObjectBuilder(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }

        public void Destroy() => QiApiObjectBuilder.DestroyBuilder(this);

        public uint AdvertiseMethod(string signature, QiObjectMethod function, IntPtr userdata)
            => QiApiObjectBuilder.AdvertiseMethod(this, signature, function, userdata);

        public uint AdvertiseSignal(string name, string signature)
            => QiApiObjectBuilder.AdvertiseSignal(this, name, signature);

        public uint AdvertiseProperty(string name, string signature)
            => QiApiObjectBuilder.AdvertiseProperty(this, name, signature);

        public QiObject GetObject() => QiApiObjectBuilder.GetObject(this);

        public static QiObjectBuilder Create() => QiApiObjectBuilder.CreateBuilder();

    }
}
