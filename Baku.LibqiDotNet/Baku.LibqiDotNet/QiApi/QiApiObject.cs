using System;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiObject"/>に関するもの</summary>
    internal static class QiApiObject
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_create();

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_object_destroy(IntPtr qiObj);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_get_metaobject(IntPtr qiObj);

        //FIXME: QiValueは相互運用だと絶対渡せないのでは。
        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_call(IntPtr qiObj, string signature, IntPtr qiTuple);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_object_post(IntPtr qiObj, string signature, IntPtr qiTuple);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_signal_connect(
            IntPtr qiObj, string signature, QiApiObjectSignalCallback cb, IntPtr userdata
            );

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_signal_disconnect(IntPtr qiObj, ulong id);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_get_property(IntPtr qiObj, string propName);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_object_set_property(IntPtr qiObj, string propName, QiValue value);

        #endregion


        internal static QiObject Create() => new QiObject(qi_object_create());

        internal static void Destroy(QiObject obj) => qi_object_destroy(obj.Handle);

        internal static QiValue GetMetaObject(QiObject obj)
            => new QiValue(qi_object_get_metaobject(obj.Handle));

        internal static QiFuture Call(QiObject obj, string signature, QiValue qiTuple)
        {
            return new QiFuture(qi_object_call(obj.Handle, signature, qiTuple.Handle));
        }

        internal static int Post(QiObject obj, string signature, QiValue qiTuple)
            => qi_object_post(obj.Handle, signature, qiTuple.Handle);

        internal static QiFuture SignalConnect(
            QiObject obj, string signature, QiApiObjectSignalCallback callback, IntPtr userdata
            )
            => new QiFuture(qi_object_signal_connect(obj.Handle, signature, callback, userdata));

        internal static QiFuture SignalDisconnect(QiObject obj, ulong id)
            => new QiFuture(qi_object_signal_disconnect(obj.Handle, id));

        internal static QiFuture GetProperty(QiObject obj, string pname)
            => new QiFuture(qi_object_get_property(obj.Handle, pname));

        internal static QiFuture SetProperty(QiObject obj, string pname, QiValue value)
            => new QiFuture(qi_object_set_property(obj.Handle, pname, value));

    }

    internal delegate void QiApiObjectSignalCallback(IntPtr parameters, IntPtr userdata);

}
