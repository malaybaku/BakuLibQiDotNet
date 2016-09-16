using System;
using Baku.LibqiDotNet;

namespace Test.Baku.LibqiDotNet
{
    static class DialogEvent
    {
        public static bool TryDetectSignalEvent(QiSession session)
        {
            bool result = false;
            Action<IQiResult> onRobotSpeech = res =>
            {
                if (res != null && res.Count > 0 && !string.IsNullOrWhiteSpace(res[0].ToQiString()))
                {
                    result = true;
                }
            };

            var tts = session.GetService("ALTextToSpeech");
            var mem = session.GetService("ALMemory");

            //ロボットの発話を監視
            IQiSignal sigRobotSpeech = mem["subscriber"].Call<IQiSignal>("ALTextToSpeech/CurrentSentence");
            sigRobotSpeech.Connect(onRobotSpeech);

            //自分で監視したイベントを自分で発火させる
            tts["say"].Call("Hello.");

            //sayしたというイベントが飛んでくるまで若干の間があることに注意
            System.Threading.Thread.Sleep(100);

            sigRobotSpeech.Disconnect(onRobotSpeech);


            return result;
        }
    }
}
