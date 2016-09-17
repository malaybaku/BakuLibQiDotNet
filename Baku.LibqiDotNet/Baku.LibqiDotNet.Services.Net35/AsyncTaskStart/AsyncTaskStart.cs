using System;
using System.Threading;

namespace Baku.LibqiDotNet.Services
{
    internal static class AsyncTaskStart
    {
        internal static void Start(Action action) => new Thread(() => action()).Start();
    }
}
