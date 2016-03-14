using System;
using System.Threading.Tasks;

using Baku.LibqiDotNet;

namespace StandardSamples
{
    static class VisionVideoRecording
    {
        public static void Execute(QiSession session)
        {
            var recorder = session.GetService("ALVideoRecorder");

            string savePath = "/home/nao/recordings/cameras";

            //Motion JPEGのaviにするパターン
            recorder["setResolution"].Call(1);
            recorder["setFramerate"].Call(10);
            recorder["setVideoFormat"].Call("MJPG");
            recorder["startRecording"].Call(savePath, "myvideo");

            Task.Delay(5000).Wait();

            recorder["stopRecording"].Call();

            Console.WriteLine($"If test succeeded, video was saved in {savePath} on the robot");

        }
    }
}
