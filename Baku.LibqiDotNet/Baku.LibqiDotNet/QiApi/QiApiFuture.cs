using System;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiFuture"/>に関するもの</summary>
    internal static class QiApiFuture
    {
        #region dllimport 

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_future_destroy(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_future_clone(IntPtr future);

        //TODO: 関数ポインタのマーシャリング忘れたので後で調べて書いて
        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_future_add_callback(IntPtr future, QiApiFutureCallback cb, IntPtr userdata);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_future_wait(IntPtr future, int timeout);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_future_has_error(IntPtr future, int timeout);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_future_has_value(IntPtr future, int timeout);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_future_is_running(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_future_is_finished(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_future_is_canceled(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_future_cancel(IntPtr future);


        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_future_get_value(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern string qi_future_get_error(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern long qi_future_get_int64_default(IntPtr future, long def);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong qi_future_get_uint64_default(IntPtr future, ulong def);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern string qi_future_get_string(IntPtr future);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_future_get_object(IntPtr future);

        #endregion

        internal static void Destroy(QiFuture future) => qi_future_destroy(future.Handle);

        internal static QiFuture Clone(QiFuture future) => new QiFuture(qi_future_clone(future.Handle));

        internal static void AddCallback(QiFuture future, QiApiFutureCallback cb, IntPtr userData)
            => qi_future_add_callback(future.Handle, cb, userData);

        internal static void Wait(QiFuture future, int timeout)
            => qi_future_wait(future.Handle, timeout);

        internal static bool HasError(QiFuture future, int timeout)
            => Convert.ToBoolean(qi_future_has_error(future.Handle, timeout));

        internal static bool HasValue(QiFuture future, int timeout)
            => Convert.ToBoolean(qi_future_has_value(future.Handle, timeout));

        internal static bool IsRunning(QiFuture future)
            => Convert.ToBoolean(qi_future_is_running(future.Handle));

        internal static bool IsFinished(QiFuture future)
            => Convert.ToBoolean(qi_future_is_finished(future.Handle));

        internal static bool IsCanceled(QiFuture future)
            => Convert.ToBoolean(qi_future_is_canceled(future.Handle));

        internal static void Cancel(QiFuture future) => qi_future_cancel(future.Handle);


        internal static QiValue GetValue(QiFuture future) => new QiValue(qi_future_get_value(future.Handle));

        internal static string GetError(QiFuture future) => qi_future_get_error(future.Handle);

        internal static long GetInt64Default(QiFuture future, long defaultValue)
            => qi_future_get_int64_default(future.Handle, defaultValue);

        internal static ulong GetUInt64Default(QiFuture future, ulong defaultValue)
            => qi_future_get_uint64_default(future.Handle, defaultValue);

        internal static string GetString(QiFuture future) => qi_future_get_string(future.Handle);

        internal static QiObject GetObject(QiFuture future) => new QiObject(qi_future_get_object(future.Handle));
    }

    internal delegate void QiApiFutureCallback(IntPtr future, IntPtr userdata);

}
