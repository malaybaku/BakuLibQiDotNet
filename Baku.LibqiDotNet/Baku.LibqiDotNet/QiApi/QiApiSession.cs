using System;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiSession"/>に関するもの</summary>
    internal static class QiApiSession
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_create();

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_session_destroy(IntPtr session);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_connect(IntPtr session, string address);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern string qi_session_url(IntPtr session);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_session_set_identity(IntPtr session, string key, string crt);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_session_is_connected(IntPtr session);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_listen(IntPtr session, string address);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_listen_standalone(IntPtr session, string address);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_register_service(IntPtr session, string name, IntPtr qiObject);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_unregister_service(IntPtr session, uint idx);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_endpoints(IntPtr session);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_get_service(IntPtr session, string name);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_close(IntPtr session);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_session_get_services(IntPtr session);

        #endregion

        internal static QiSession Create() => new QiSession(qi_session_create());

        internal static void Destroy(QiSession session) => qi_session_destroy(session.Handle);

        internal static QiFuture Connect(QiSession session, string address)
            => new QiFuture(qi_session_connect(session.Handle, address));

        internal static string GetUrl(QiSession session)
            => qi_session_url(session.Handle);

        internal static int SetIdentity(QiSession session, string key, string crt)
            => qi_session_set_identity(session.Handle, key, crt);

        internal static bool IsConnected(QiSession session)
            => Convert.ToBoolean(qi_session_is_connected(session.Handle));

        internal static QiFuture Listen(QiSession session, string address, bool standAlone = false)
            => standAlone ?
            new QiFuture(qi_session_listen_standalone(session.Handle, address)) :
            new QiFuture(qi_session_listen(session.Handle, address));

        internal static QiFuture RegisterService(QiSession session, string name, QiObject obj)
            => new QiFuture(qi_session_register_service(session.Handle, name, obj.Handle));

        internal static QiFuture UnregisterService(QiSession session, uint idx)
            => new QiFuture(qi_session_unregister_service(session.Handle, idx));

        internal static QiValue GetEndpoints(QiSession session)
            => new QiValue(qi_session_endpoints(session.Handle));

        internal static QiFuture GetService(QiSession session, string name)
            => new QiFuture(qi_session_get_service(session.Handle, name));

        internal static QiFuture Close(QiSession session)
            => new QiFuture(qi_session_close(session.Handle));

        internal static QiFuture GetServices(QiSession session)
            => new QiFuture(qi_session_get_services(session.Handle));
    }

}
