using System;
using System.Threading.Tasks;

using Baku.LibqiDotNet;

namespace StandardSamples
{

    /// <summary>
    /// Choregraphe 2.4付属ドキュメントのPythonサンプルで
    /// Motion -> Stiffness -> Stiffness on に相当する部分
    /// NAOでしか動作しないと書いてあるがにわかに信じがたいので実装しておく。
    /// </summary>
    static class MotionStiffnessOn
    {
        public static void Execute(QiSession session)
        {

            var motion = session.GetService("ALMotion");
            motion.Call("stiffnessInterpolation", new QiString("Body"), new QiFloat(1.0f), new QiFloat(1.0f));

            Console.WriteLine(motion.Call("getSummary").GetString());

            //なぜか知らないが状態が落ち着くまで待つらしい?
            Task.Delay(2000).Wait();

            motion.Call("rest");
        }
    }
}
