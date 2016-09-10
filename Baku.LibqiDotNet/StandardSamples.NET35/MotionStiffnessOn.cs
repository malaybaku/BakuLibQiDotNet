using System;
using System.Threading;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamples
{

    /// <summary>
    /// Choregraphe 2.4付属ドキュメントのPythonサンプルで
    /// Motion -> Stiffness -> Stiffness on に相当する部分
    /// NAOでしか動作しないと書いてあるがにわかに信じがたいので実装しておく。
    /// </summary>
    class MotionStiffnessOn : ILibqiDotNetSample
    {
        public string Description { get; } = "Change motion stiffness, using ALMotion functionality.";

        public void Execute(IQiSession session)
        {
            ALMotion motion = ALMotion.CreateService(session);

            float stiffness = 1.0f;
            float timeSec = 1.0f;
            motion.StiffnessInterpolation("Body", stiffness, timeSec);

            Console.WriteLine(motion.GetSummary());

            //いちおう状態が落ち着くまで待機
            Thread.Sleep(2000);

            motion.Rest();
        }
    }
}
