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

        internal IntPtr Handle { get; }

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiObjectBuilder.DestroyBuilder(this);

        /// <summary>
        /// 関数を登録します。
        /// </summary>
        /// <param name="signature">関数のフルシグネチャ</param>
        /// <param name="function">実際の関数</param>
        /// <param name="userdata">ユーザデータ(特殊な事情が無い限り<see cref="IntPtr.Zero"/>を用いる)</param>
        /// <returns>メソッドに割り振ったID</returns>
        public uint AdvertiseMethod(string signature, QiObjectMethod function, IntPtr userdata)
            => QiApiObjectBuilder.AdvertiseMethod(this, signature, function, userdata);

        /// <summary>
        /// シグナルを登録します。
        /// </summary>
        /// <param name="name">シグナル名</param>
        /// <param name="signature">シグネチャ</param>
        /// <returns>シグナルに割り振ったID</returns>
        public uint AdvertiseSignal(string name, string signature)
            => QiApiObjectBuilder.AdvertiseSignal(this, name, signature);

        /// <summary>
        /// プロパティを登録します。
        /// </summary>
        /// <param name="name">プロパティ名</param>
        /// <param name="signature">プロパティのシグネチャ</param>
        /// <returns>プロパティに割り振ったID</returns>
        public uint AdvertiseProperty(string name, string signature)
            => QiApiObjectBuilder.AdvertiseProperty(this, name, signature);

        /// <summary>
        /// 登録情報に基づき、オブジェクトを生成します。
        /// </summary>
        /// <returns>生成されたオブジェクト</returns>
        public QiObject GetObject() => QiApiObjectBuilder.GetObject(this);

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <returns>生成されたインスタンス</returns>
        public static QiObjectBuilder Create() => QiApiObjectBuilder.CreateBuilder();

    }
}
