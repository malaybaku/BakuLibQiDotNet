using System;
using System.Threading.Tasks;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamplesWithServices
{
    static class VisionVideoRecording
    {
        public static void Execute(QiSession session)
        {
            var recorder = new ALVideoRecorder(session);

            string savePath = "/home/nao/recordings/cameras";

            //Motion JPEGのaviにするパターン
            recorder.SetResolution(1);
            recorder.SetFrameRate(10);
            recorder.SetVideoFormat("MJPG");
            recorder.StartRecording(savePath, "myvideo");

            Task.Delay(5000).Wait();

            recorder.StopRecording();

            Console.WriteLine($"If test succeeded, video was saved in {savePath} on the robot");

        }
    }
}
