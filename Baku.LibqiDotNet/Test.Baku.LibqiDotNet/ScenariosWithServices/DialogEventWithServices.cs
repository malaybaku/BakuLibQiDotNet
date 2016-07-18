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
            EventHandler<QiSignalEventArgs> onRobotSpeech = (_, e) =>
            {
                if (e.Data != null &&
                    e.Data.Count > 0 &&
                    !string.IsNullOrWhiteSpace(e.Data[0].ToQiString()))
                {
                    result = true;
                }
            };

            var tts = ALTextToSpeech.CreateService(session);
            var mem = ALMemory.CreateService(session);

            //ロボットの発話を監視
            IQiSignal sigRobotSpeech = mem.Subscriber("ALTextToSpeech/CurrentSentence");
            sigRobotSpeech.Received += onRobotSpeech;

            //TODO: 正常系でココにWaitっぽい処理いれないとダメか検証する

            //自分で監視したイベントを自分で発火させる
            tts.Say("Hello.");

            //TODO: 正常系でココにWaitっぽい処理いれないとダメか検証する。
            //(なんとなくWait無しの条件は必要以上に厳しい気がする)

            sigRobotSpeech.Received -= onRobotSpeech;


            return result;
        }
    }
}
