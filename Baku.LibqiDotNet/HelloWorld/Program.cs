using System;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //作業ディレクトリだけでなく"dlls"というフォルダのライブラリも実行中に参照できるよう設定を変更
            PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);

            //HelloWorldの対象とするマシンのIPアドレスを指定(ポートは既定値のHTTP:8002/TCP:9559を使用)
            var session = QiSession.CreateSocketIoSession();
            session.Protocol = "http://";
            session.Port = QiSession.DefaultHttpPort;
            session.Connect("192.168.1.3");

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session.GetService("ALTextToSpeech");

            //"say"関数に文字列引数を指定して実行
            tts["say"].Call("this is test");

            var tts2 = session.GetService("ALTextToSpeech");
            tts2["say"].Call("this is also test, do you understand?");

            session.Close();
        }
    }

}
