using System;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiPromise"/>に関するもの</summary>
    internal static class QiApiPromise
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_promise_create(int asyncCallback);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_promise_cancelable_create(int async, QiFutureCancel callback, IntPtr userdata);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_promise_destroy(IntPtr promise);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_promise_set_value(IntPtr promise, IntPtr value);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_promise_set_error(IntPtr promise, string error);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_promise_set_canceled(IntPtr promise);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_promise_get_future(IntPtr promise);

        #endregion

        internal static QiPromise Create(bool asyncCallback) 
            => new QiPromise(qi_promise_create(Convert.ToInt32(asyncCallback)));

        internal static QiPromise CreateCancelable(bool isAsync, QiFutureCancel callback, IntPtr userdata)
            => new QiPromise(qi_promise_cancelable_create(Convert.ToInt32(isAsync), callback, userdata));

        internal static void Destroy(QiPromise promise) => qi_promise_destroy(promise.Handle);

        internal static void SetValue(QiPromise promise, QiValue value)
            => qi_promise_set_value(promise.Handle, value.Handle);

        internal static void SetError(QiPromise promise, string error)
            => qi_promise_set_error(promise.Handle, error);

        internal static void SetCanceled(QiPromise promise)
            => qi_promise_set_canceled(promise.Handle);

        internal static QiFuture GetFuture(QiPromise promise)
            => new QiFuture(qi_promise_get_future(promise.Handle));

    }

}
