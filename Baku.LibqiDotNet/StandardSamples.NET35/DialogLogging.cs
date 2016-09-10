using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamples
{
    class DialogLogging : ILibqiDotNetSample
    {
        public string Description { get; } = "Log the human speech detection result and robot's talk, using ALMemory functionality.";

        public void Execute(IQiSession session)
        {
            var mem = ALMemory.CreateService(session);

            //人の会話
            var subscriberHumanSpeech = mem.Subscriber("Dialog/LastInput");
            subscriberHumanSpeech.Received += OnHumanSpeech;

            //ロボットの発話
            var subscriberRobotSpeech = mem.Subscriber("ALTextToSpeech/CurrentSentence");
            subscriberRobotSpeech.Received += OnRobotSpeech;

            Console.WriteLine("Press ENTER to quit logging results.");
            Console.ReadLine();

            subscriberHumanSpeech.Received -= OnHumanSpeech;
            subscriberRobotSpeech.Received -= OnRobotSpeech;
        }

        private static void OnHumanSpeech(object sender, QiSignalEventArgs e)
        {
            var data = e.Data;
            if (data.Count > 0 && !string.IsNullOrEmpty(data[0].ToQiString()))
            {
                Console.WriteLine($"Human: {data[0].ToQiString()}");
            }
            else
            {
                Console.WriteLine("Human: Received unexpected data");
                Console.WriteLine(data.Dump());
            }
        }

        private static void OnRobotSpeech(object sender, QiSignalEventArgs e)
        {
            var data = e.Data;
            if (data.Count > 0 && !string.IsNullOrEmpty(data[0].ToQiString()))
            {
                string sentence = data[0].ToQiString();
                if (!string.IsNullOrEmpty(sentence))
                {
                    Console.WriteLine($"Robot: {sentence}");
                }
            }
            else
            {
                Console.WriteLine("Robot: Received unexpected data");
                Console.WriteLine(data.Dump());
            }
        }
    }
}
