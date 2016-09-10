using Baku.LibqiDotNet;

namespace StandardSamples
{
    internal interface ILibqiDotNetSample
    {
        string Description { get; }

        void Execute(IQiSession session);
    }
}
