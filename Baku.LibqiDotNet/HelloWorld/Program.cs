using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Baku.LibqiDotNet;


namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //作業ディレクトリだけでなく"dlls"というフォルダのライブラリも
            //実行中に参照できるよう設定を変更
            PathModifier.AddEnvironmentPaths(
                new string[]
                {
                    Path.Combine(Environment.CurrentDirectory, "dlls")
                });


            //ハローワールドしたいマシンのIPとポート(ポートは通常9559)で指定
            string targetIp = "127.0.0.1:9559";

            SayHelloWorld(targetIp);
        }

        static void SayHelloWorld(string targetMachine = "")
        {
            var app = QiApplication.Create(new string[] { "HelloWorld.exe", "--qi-url", targetMachine });
            var session = QiSession.Create();

            //Waitすることで接続処理が完了するのを確実に待機
            session.Connect("tcp://" + targetMachine).Wait();

            Console.WriteLine($"Connected? {session.CheckIsConnected()}");
            if(!session.CheckIsConnected())
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session
                .GetService("ALTextToSpeech")
                .GetObject();

            //"say"関数に文字列引数を指定して実行し、完了を待機
            tts.Call("say", new QiString("this is test")).Wait();

        }
    }

    static class PathModifier
    {
        public static void AddEnvironmentPaths(IEnumerable<string> paths)
        {
            var path = new[] { Environment.GetEnvironmentVariable("PATH") ?? "" };

            string newPath = string.Join(Path.PathSeparator.ToString(), path.Concat(paths));

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }
}
