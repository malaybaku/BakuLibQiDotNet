# Baku.LibqiDotNet

Baku/獏(ばく)

2016/Feb/7

## About

Aldebaran社が公開しているメッセージングライブラリ```libqi```を.NETから使えるようにするためのラッパーライブラリです。Aldebaranのlibqiライブラリ群については下記を参照ください。

- [libqi](https://github.com/aldebaran/libqi)
- [libqi-capi](https://github.com/aldebaran/libqi-capi)


## Environment

Windows 10/Visual Studio 2015 Community

現時点ではWindowsアプリケーションのみをターゲットとしているため動作保証は.NET Framework 4.5.2に対してのみ行っています。

うまく移植したらUnityとかMac/Linux環境でも使いまわせるかもしれません。

## Library Files Preparation

本プロジェクトはあくまでラッパーでありラップ元のライブラリ("qic.dll"を含むライブラリ群)は同梱していません。

手順は細かく書きませんが次のような手順を踏んでライブラリを手に入れて下さい。

1. PythonのNaoqi SDKをアルデバランの公式サイトから入手し、インストールする
2. インストールするとPythonのパッケージのディレクトリにコア相当ライブラリ(らしい)"qi.dll"や"qic.dll"とboostのdllが配置されるハズなので、それらを全部コピー
3. 実行ファイルのディレクトリに```dlls```ディレクトリを作り、コピーしたライブラリを全てその下にペースト

ディレクトリ名は```dlls```以外でも構いませんが、下記のHello Worldサンプルで示すようにディレクトリ名はプログラム側で使用します。


## Hello World

アプリケーション初期化、セッションの接続、サービス取得、サービスの関数を利用、というラップ元のライブラリと同様な流れで利用できるようになっています。

```
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

            //最も基本的なモジュールの一つとして合成音声のモジュールを取得
            var tts = session
                .GetService("ALTextToSpeech")
                .Wait()
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
```



## Caution

MIT Licenseにあるように免責は宣言しているのでご留意下さい。とくに外部依存ライブラリの解決関係をマジメに調査していないため、複雑な操作に挑戦するとクラッシュする可能性があります。




## 問い合わせとか

ブログは[こちら](www.baku-dreameater.net)です。バグ報告や要望についてはブログの適当な記事へのコメント、または[Twitter](https://twitter.com/baku_dreameater)とかへお知らせ下さい。
