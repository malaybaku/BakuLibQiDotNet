using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamplesWithServices
{
    static class DialogLogging
    {
        public static void Execute(QiSession session)
        {
            var mem = new ALMemory(session);

            //人の会話
            var subscriberHumanSpeech = mem.Subscriber("Dialog/LastInput");
            ulong idHumanSpeech = subscriberHumanSpeech.ConnectSignal("signal", qv =>
            {
                if (qv.Count > 0 && qv[0].ContentValueKind == QiValueKind.QiString)
                {
                    Console.WriteLine($"Human: {qv[0].ToString()}");
                }
                else
                {
                    Console.WriteLine("Human: Received unexpected data");
                    Console.WriteLine(qv.Dump());
                }
            });

            //ロボットの発話
            var subscriberRobotSpeech = mem.Subscriber("ALTextToSpeech/CurrentSentence");
            ulong idRobotSpeech = subscriberRobotSpeech.ConnectSignal("signal", qv =>
            {
                if (qv.Count > 0 && qv[0].ContentValueKind == QiValueKind.QiString)
                {
                    string sentence = qv[0].ToString();
                    if(!string.IsNullOrWhiteSpace(sentence))
                    {
                        Console.WriteLine($"Robot: {sentence}");
                    }
                }
                else
                {
                    Console.WriteLine("Robot: Received unexpected data");
                    Console.WriteLine(qv.Dump());
                }
            });

            Console.WriteLine("Press ENTER to quit logging results.");
            Console.ReadLine();

            subscriberHumanSpeech.DisconnectSignal(idHumanSpeech).Wait();
            subscriberRobotSpeech.DisconnectSignal(idRobotSpeech).Wait();
        }
    }
}
