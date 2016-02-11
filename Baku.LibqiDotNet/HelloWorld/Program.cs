using System;
using System.IO;
using System.Linq;

using Baku.LibqiDotNet;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //作業ディレクトリだけでなく"dlls"というフォルダのライブラリも実行中に参照できるよう設定を変更
            PathModifier.AddEnvironmentPaths(Path.Combine(Environment.CurrentDirectory, "dlls"));

            //HelloWorldの対象とするマシンのアドレスをIPとポート(ポートは通常9559)で指定
            string address = "tcp://127.0.0.1:9559";

            var app = QiApplication.Create();
            var session = QiSession.Create(address);

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session.GetService("ALTextToSpeech").GetObject();

            //"say"関数に文字列引数を指定して実行し、完了を待機
            tts.Call("say", new QiString("this is test")).Wait();

            session.Close();
            session.Destroy();
            app.Destroy();
        }
    }

    static class PathModifier
    {
        public static void AddEnvironmentPaths(params string[] paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? "" };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }
}
