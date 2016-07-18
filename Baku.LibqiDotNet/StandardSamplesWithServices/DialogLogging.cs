using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamplesWithServices
{
    static class DialogLogging
    {
        public static void Execute(QiSession session)
        {
            var mem = ALMemory.CreateService(session);

            var robotSpeech = mem.Subscriber("ALTextToSpeech/CurrentSentence");
            var humanSpeech = mem.Subscriber("Dialog/LastInput");

            robotSpeech.Received += OnRobotSpeech;
            humanSpeech.Received += OnHumanSpeech;

            Console.WriteLine("Press ENTER to quit logging results.");
            Console.ReadLine();

            robotSpeech.Received -= OnRobotSpeech;
            humanSpeech.Received -= OnHumanSpeech;
        }

        //人の会話イベントのハンドラ
        private static void OnHumanSpeech(object sender, QiSignalEventArgs e)
        {
            var qv = e.Data;
            if (qv.Count > 0 && !string.IsNullOrWhiteSpace(qv[0].ToQiString()))
            {
                Console.WriteLine($"Human: {qv[0].ToString()}");
            }
            else
            {
                Console.WriteLine("Human: Received unexpected data");
                Console.WriteLine(qv.Dump());
            }
        }

        //ロボットの発話イベントのハンドラ
        private static void OnRobotSpeech(object sender, QiSignalEventArgs e)
        {
            var qv = e.Data;
            if (qv.Count > 0 && !string.IsNullOrWhiteSpace(qv[0].ToQiString()))
            {
                string sentence = qv[0].ToString();
                if (!string.IsNullOrWhiteSpace(sentence))
                {
                    Console.WriteLine($"Robot: {sentence}");
                }
            }
            else
            {
                Console.WriteLine("Robot: Received unexpected data");
                Console.WriteLine(qv.Dump());
            }
        }

    }
}
