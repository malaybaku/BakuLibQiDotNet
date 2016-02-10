using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{

    /// <summary>
    /// <see cref="QiFuture"/>に対応するPromise処理を表します。
    /// サービスの自作をしない限り必要なさそうなため実装は最低限になっています。
    /// </summary>
    public class QiPromise
    {

        internal QiPromise(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        public void Destroy() => QiApiPromise.Destroy(this);

        public void SetValue(QiValue value) => QiApiPromise.SetValue(this, value);
        public void SetError(string error) => QiApiPromise.SetError(this, error);
        public void SetCanceled() => QiApiPromise.SetCanceled(this);

        public QiFuture GetFuture() => QiApiPromise.GetFuture(this);

        public static QiPromise Create(int asyncCallback) => QiApiPromise.Create(asyncCallback);

        public static QiPromise Create(int asyncCallback, QiFutureCancel cb, IntPtr userdata)
            => QiApiPromise.CreateCancelable(asyncCallback, cb, userdata);

    }

    public delegate void QiFutureCancel(IntPtr promise, IntPtr userdata);


}
