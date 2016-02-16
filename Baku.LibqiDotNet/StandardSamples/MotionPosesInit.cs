using Baku.LibqiDotNet;

namespace StandardSamples
{

    /// <summary>
    /// Choregraphe 2.4付属ドキュメントのPythonサンプルで
    /// Motion -> Poses -> Init に相当する部分
    /// (Motion -> Poses -> Zero)というのも掲載されてるがほぼ同じため省略
    /// </summary>
    static class MotionPosesInit
    {
        public static void Execute(QiSession session)
        {

            var motion = session.GetService("ALMotion");
            var posture = session.GetService("ALRobotPosture");

            motion.Call("wakeUp");
            posture.Call("goToPosture", new QiString("StandInit"), new QiFloat(0.5f));
            motion.Call("rest");
        }

    }
}
