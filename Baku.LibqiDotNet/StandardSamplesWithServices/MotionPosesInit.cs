using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamplesWithServices
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
            var motion = ALMotion.CreateService(session);
            var posture = ALRobotPosture.CreateService(session);

            motion.WakeUp();
            posture.GoToPosture("StandInit", 0.5f);
            motion.Rest();
        }
    }
}
