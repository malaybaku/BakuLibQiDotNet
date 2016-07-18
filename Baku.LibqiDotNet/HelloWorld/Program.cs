using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //ネイティブライブラリを利用する場合に備えてネイティブライブラリの置き場所候補を増やす
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);

            var session = QiSession.CreateSession();
            session.Connect("127.0.0.1");

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            Console.WriteLine("Robot will say 'this is test.'");

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session.GetService("ALTextToSpeech");
            //"say"関数に文字列引数を指定して実行
            tts["say"].Call("this is test");

            session.Close();
        }
    }

}
