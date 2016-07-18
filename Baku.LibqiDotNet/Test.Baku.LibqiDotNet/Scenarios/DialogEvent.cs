using System;
using Baku.LibqiDotNet;

namespace Test.Baku.LibqiDotNet
{
    static class DialogEvent
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

            var tts = session.GetService("ALTextToSpeech");
            var mem = session.GetService("ALMemory");

            //ロボットの発話を監視
            IQiSignal sigRobotSpeech = mem["subscriber"].Call<IQiSignal>("ALTextToSpeech/CurrentSentence");
            sigRobotSpeech.Received += onRobotSpeech;

            //TODO: 正常系でココにWaitっぽい処理いれないとダメか検証する

            //自分で監視したイベントを自分で発火させる
            tts["say"].Call("Hello.");

            //TODO: 正常系でココにWaitっぽい処理いれないとダメか検証する。
            //(なんとなくWait無しの条件は必要以上に厳しい気がする)

            sigRobotSpeech.Received -= onRobotSpeech;


            return result;
        }
    }
}
