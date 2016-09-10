using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamples
{

    /// <summary>
    /// Choregraphe 2.4付属ドキュメントのPythonサンプルで
    /// Motion -> Poses -> Init に相当する部分
    /// (Motion -> Poses -> Zero)というのも掲載されてるがほぼ同じため省略
    /// </summary>
    class MotionPosesInit : ILibqiDotNetSample
    {
        public string Description { get; } = "Initialize robot's pose using ALMotion/ALRobotPosture functionality.";

        public void Execute(IQiSession session)
        {
            var motion = ALMotion.CreateService(session);
            var posture = ALRobotPosture.CreateService(session);

            motion.WakeUp();
            posture.GoToPosture("StandInit", 0.5f);
            motion.Rest();
        }

    }
}
