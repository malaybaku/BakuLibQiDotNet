using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace Test.Baku.LibqiDotNet
{
    static class DialogEventWithServices
    {
        public static bool TryDetectSignalEvent(QiSession session)
        {
            bool result = false;
            Action<IQiResult> onRobotSpeech = (res) =>
            {
                if (res != null && res.Count > 0 && !string.IsNullOrWhiteSpace(res[0].ToQiString()))
                {
                    result = true;
                }
            };

            var tts = ALTextToSpeech.CreateService(session);
            var mem = ALMemory.CreateService(session);

            //ロボットの発話を監視
            IQiSignal sigRobotSpeech = mem.Subscriber("ALTextToSpeech/CurrentSentence");
            sigRobotSpeech.Connect(onRobotSpeech);

            //自分で監視したイベントを自分で発火させる
            tts.Say("Hello.");

            //sayしたというイベントが飛んでくるまで若干の間があることに注意
            System.Threading.Thread.Sleep(100);

            sigRobotSpeech.Disconnect(onRobotSpeech);

            return result;
        }
    }
}
