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

            //HelloWorldの対象とするマシンのアドレスをIPとポート(ポートは通常9559)で指定
            string address = "tcp://brassy325.local:9559";
            var session = QiSession.Create(address);

            Console.WriteLine($"Connected? {session.IsConnected}");
            if (!session.IsConnected)
            {
                Console.WriteLine("end program because there is no connection");
                return;
            }

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session.GetService("ALTextToSpeech");

            var mo = tts.GetMetaObject();
            Console.WriteLine(mo.GetSignature());


            //めも1: ファイナライザはAccessViolationか何かのヤバいクラッシュ要因になるので絶対ダメ
            //めも2: メタオブジェクトはJSONかXMLで保存出来た方がいいよね常識的に考えて

            //"say"関数に文字列引数を指定して実行
            //tts["say"].Call("this is test");

            //session.Close();
        }
    }

}
