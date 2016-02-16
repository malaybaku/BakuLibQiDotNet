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
            recorder.Call("setResolution", new QiInt32(1));
            recorder.Call("setFramerate", new QiInt32(10));
            recorder.Call("setVideoFormat", new QiString("MJPG"));
            recorder.Call("startRecording", new QiString(savePath), new QiString("myvideo"));

            Task.Delay(5000).Wait();

            recorder.Call("stopRecording");

            Console.WriteLine($"If test succeeded, video was saved in {savePath} on the robot");

        }
    }
}
