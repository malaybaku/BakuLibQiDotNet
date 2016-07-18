using Baku.LibqiDotNet;

namespace StandardSamples
{

    /// <summary>
    /// Choregraphe 2.4付属ドキュメントのPythonサンプルで
    /// Motion -> Poses -> Init に相当する部分
    /// (Motion -> Poses -> Zero)というのも掲載されてるがほぼ同じため省略
    /// </summary>
    public static class MotionPosesInit
    {
        public static void Execute(IQiSession session)
        {

            var motion = session.GetService("ALMotion");
            var posture = session.GetService("ALRobotPosture");

            motion["wakeUp"].Call();
            posture["goToPosture"].Call("StandInit", 0.5f);
            motion["rest"].Call();
        }

    }
}
