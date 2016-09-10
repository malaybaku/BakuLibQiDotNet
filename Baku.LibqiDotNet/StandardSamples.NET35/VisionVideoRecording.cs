using System;
using System.Threading;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamples
{
    class VisionVideoRecording : ILibqiDotNetSample
    {
        public string Description { get; } = "Record and save the video, using ALVideoRecorder.";

        public void Execute(IQiSession session)
        {
            //var recorder = session.GetService("ALVideoRecorder");
            var videoRecorder = ALVideoRecorder.CreateService(session);

            //save path in the robot, use Linux style as Robot's OS is Gentoo.
            string savePath = "/home/nao/recordings/cameras";

            //Choose Motion JPEG Avi, 10 fps and normal resolution by the option below
            videoRecorder.SetResolution(1);
            videoRecorder.SetFrameRate(10);
            videoRecorder.SetVideoFormat("MJPG");

            //Start
            videoRecorder.StartRecording(savePath, "myvideo");

            //Wait for video recording...
            Thread.Sleep(5000);

            //Stop
            videoRecorder.StopRecording();

            Console.WriteLine($"If test succeeded, video was saved in {savePath} on the robot");
        }
    }
}
