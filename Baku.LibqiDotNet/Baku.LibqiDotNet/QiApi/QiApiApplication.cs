using System;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiApplication"/>に関するもの</summary>
    internal static class QiApiApplication
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_application_create(ref int argc, [In]string[] argv);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_application_initialized();

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_application_destroy(IntPtr app);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_application_run(IntPtr app);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_application_stop(IntPtr app);

        #endregion

        internal static QiApplication Create(string[] args)
        {
            int argc = args.Length;
            IntPtr handle = qi_application_create(ref argc, args);
            return new QiApplication(handle);
        }

        internal static bool CheckInitialized()
            => Convert.ToBoolean(qi_application_initialized());

        internal static void Destroy(QiApplication app)
            => qi_application_destroy(app.Handle);

        internal static void Run(QiApplication app)
            => qi_application_run(app.Handle);

        internal static void Stop(QiApplication app)
            => qi_application_stop(app.Handle);

    }
}
