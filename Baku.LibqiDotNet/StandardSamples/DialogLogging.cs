using System;
using Baku.LibqiDotNet;

namespace StandardSamples
{
    static class DialogLogging
    {
        public static void Execute(IQiSession session)
        {
            EventHandler<QiSignalEventArgs> onHumanSpeech = (_, e) =>
            {
                if (e.Data == null) return;

                if (e.Data.Count > 0 && !string.IsNullOrEmpty(e.Data[0].ToQiString()))
                {
                    Console.WriteLine($"Human: {e.Data[0].ToQiString()}");
                }
                else
                {
                    Console.WriteLine("Human: Received unexpected data");
                    Console.WriteLine(e.Data.Dump());
                }
            };

            EventHandler<QiSignalEventArgs> onRobotSpeech = (_, e) =>
            {
                if (e.Data == null) return;

                if (e.Data.Count > 0 && !string.IsNullOrEmpty(e.Data[0].ToQiString()))
                {
                    string sentence = e.Data[0].ToString();
                    if (!string.IsNullOrWhiteSpace(sentence))
                    {
                        Console.WriteLine($"Robot: {sentence}");
                    }
                }
                else
                {
                    Console.WriteLine("Robot: Received unexpected data");
                    Console.WriteLine(e.Data.Dump());
                }
            };

            var mem = session.GetService("ALMemory");

            //人の会話
            //var subscriberHumanSpeech = mem.CallObject("subscriber", new QiString("Dialog/LastInput"));
            IQiSignal sigHumanSpeech = mem["subscriber"].Call<IQiSignal>("Dialog/LastInput");
            sigHumanSpeech.Received += onHumanSpeech;

            //ロボットの発話
            IQiSignal sigRobotSpeech = mem["subscriber"].Call<IQiSignal>("ALTextToSpeech/CurrentSentence");
            sigRobotSpeech.Received += onRobotSpeech;

            Console.WriteLine("Press ENTER to quit logging results.");
            Console.ReadLine();

            sigHumanSpeech.Received -= onHumanSpeech;
            sigRobotSpeech.Received -= onRobotSpeech;
        }
    }
}
