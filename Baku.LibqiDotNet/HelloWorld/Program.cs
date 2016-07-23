using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;
using Baku.LibqiDotNet.Service;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //ネイティブライブラリを利用する場合に備えてネイティブライブラリの置き場所候補を増やす
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);

            var session = QiSession.CreateSession();
            session.Connect("xxx.xxx.xxx.xxx");

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            ALTextToSpeech tts = ALTextToSpeech.CreateService(session);
            //"say"関数に文字列引数を指定して実行
            tts.Say("This is test.");

            session.Close();
        }
    }

}
