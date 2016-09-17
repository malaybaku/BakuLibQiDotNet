using System;
using System.Threading.Tasks;

namespace Baku.LibqiDotNet.Services
{
    internal static class AsyncTaskStart
    {
        internal static void Start(Action action) => Task.Run(action);
    }
}
