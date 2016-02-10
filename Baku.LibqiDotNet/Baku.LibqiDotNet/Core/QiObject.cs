using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのオブジェクト(基本的にサービスモジュールと同じ)を表します。</summary>
    public class QiObject
    {
        public QiObject(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }

        public void Destroy() => QiApiObject.Destroy(this);

        public QiValue GetMetaObject() => QiApiObject.GetMetaObject(this);

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を呼び出します。
        /// デバッグ目的で公開されており、普通は<see cref="Call"/>を使用してください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>戻り値の取得に使えるfuture型</returns>
        public QiFuture CallDirect(string signature, QiValue argsTuple)
            => QiApiObject.Call(this, signature, argsTuple);

        public int Post(string signature, QiValue argsTuple)
            => QiApiObject.Post(this, signature, argsTuple);

        public QiFuture ConnectSignal(string signature, QiObjectSignalCallbackHolder cbHolder, IntPtr userdata)
            => QiApiObject.SignalConnect(this, signature, cbHolder, userdata);

        public QiFuture DisconnectSignal(ulong id)
            => QiApiObject.SignalDisconnect(this, id);

        public QiFuture GetProperty(string pname) => QiApiObject.GetProperty(this, pname);
        public QiFuture SetProperty(string pname, QiValue v) => QiApiObject.SetProperty(this, pname, v);


        public static QiObject Create() => QiApiObject.Create();

        public QiFuture Call(string methodName, params QiAnyValue[] args)
        {
            var argTuple = QiTuple.Create(args);
            string signature = methodName + QiSignatures.MethodNameSuffix + argTuple.Signature;

            return CallDirect(signature, argTuple.QiValue);
        }

    }

    public delegate QiValue QiObjectMethod(string completeSignature, QiValue msg, IntPtr userdata);
    public delegate void QiObjectSignalCallback(QiValue parameter, IntPtr userdata);

}
