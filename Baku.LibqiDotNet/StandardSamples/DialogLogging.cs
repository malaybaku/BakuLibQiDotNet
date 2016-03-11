﻿using System;
using Baku.LibqiDotNet;

namespace StandardSamples
{
    static class DialogLogging
    {
        public static void Execute(QiSession session)
        {
            var mem = session.GetService("ALMemory");

            //人の会話
            //var subscriberHumanSpeech = mem.CallObject("subscriber", new QiString("Dialog/LastInput"));
            var subscriberHumanSpeech = mem["subscriber"].Call<QiObject>("Dialog/LastInput");
            ulong idHumanSpeech = subscriberHumanSpeech.ConnectSignal("signal", qv =>
            {
                if (qv.Count > 0 && qv[0].ContentValueKind == QiValueKind.QiString)
                {
                    Console.WriteLine($"Human: {qv[0].GetString()}");
                }
                else
                {
                    Console.WriteLine("Human: Received unexpected data");
                    Console.WriteLine(qv.Dump());
                }
            });

            //ロボットの発話
            var subscriberRobotSpeech = mem["subscriber"].Call<QiObject>("ALTextToSpeech/CurrentSentence");
            ulong idRobotSpeech = subscriberRobotSpeech.ConnectSignal("signal", qv =>
            {
                if (qv.Count > 0 && qv[0].ContentValueKind == QiValueKind.QiString)
                {
                    string sentence = qv[0].GetString();
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
