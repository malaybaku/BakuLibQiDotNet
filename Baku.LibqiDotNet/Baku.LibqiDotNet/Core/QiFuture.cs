using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>非同期的にリクエストの戻り値を受け取るコンテナを表します。</summary>
    public class QiFuture
    {
        internal QiFuture(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle { get; }

        public QiFuture Wait(int timeout)
        {
            QiApiFuture.Wait(this, timeout);
            return this;
        }
        public QiFuture Wait() => Wait(InfiniteTimeout);

        public bool CheckHasError(int timeout) => QiApiFuture.HasError(this, timeout);
        public bool CheckHasError() => CheckHasError(InfiniteTimeout);

        public bool CheckHasValue(int timeout) => QiApiFuture.HasValue(this, timeout);
        public bool CheckHasValue() => CheckHasValue(InfiniteTimeout);

        public void Cancel() => QiApiFuture.IsCanceled(this);

        public void Destroy() => QiApiFuture.Destroy(this);

        public bool IsRunning => QiApiFuture.IsRunning(this);

        public bool IsFinished => QiApiFuture.IsFinished(this);

        public bool IsCanceled => QiApiFuture.IsCanceled(this);

        public QiFuture CloneFuture() => QiApiFuture.Clone(this);



        public QiValue GetValue() => QiApiFuture.GetValue(this);

        public string GetError() => QiApiFuture.GetError(this);

        public long GetInt64(long def) => QiApiFuture.GetInt64Default(this, def);

        public ulong GetUInt64(ulong def) => QiApiFuture.GetUInt64Default(this, def);

        public string GetString() => QiApiFuture.GetString(this);

        public QiObject GetObject() => QiApiFuture.GetObject(this);


        public void AddCallback(QiFutureCallback cb, IntPtr userData)
        {
            var apiCallback = new QiApiFutureCallback((fut, udata) => cb(new QiFuture(fut), udata));
            QiApiFuture.AddCallback(this, apiCallback, userData);
        }

        public static int NoneTimeout => 0;
        public static int InfiniteTimeout => 0x7fffffff;

    }

    public delegate void QiFutureCallback(QiFuture future, IntPtr userdata);


}
