# Baku.LibqiDotNet

Baku/獏(ばく)

2016/Feb/12

## About

Aldebaran社が公開しているメッセージングフレームワーク```libqi```を.NETから使えるようにするためのラッパーライブラリです。Aldebaranのlibqiライブラリ群については下記等を参照ください。

- [libqi](https://github.com/aldebaran/libqi)
- [libqi-capi](https://github.com/aldebaran/libqi-capi)


## Environment

本ライブラリはWindows 10/Visual Studio 2015 Communityで開発されています。ターゲットプラットフォーム32bitでのみ動作します。

現時点ではWindowsアプリケーションのみをターゲットとしており、動作保証は.NET Framework 4.5.2に対してのみ行っています。

うまく移植したらUnityEngineとかMac/Linux環境でも使いまわせるかもしれません。

## Library Files Preparation

本プロジェクトはあくまでラッパーでありラップ元のライブラリ("qic.dll"を含むライブラリ群)は同梱していません。次のいずれかの手順を踏んでライブラリを手に入れて下さい。

#### 推奨する方法

本ラッパー用にビルドしたライブラリを使う方法です。ラップ元である[libqi-capi](https://github.com/aldebaran/libqi-capi)の一部機能が2016年2月時点で実装されていなかったため、不足していた機能を補完してビルドを行ったものを配布しています。下記の手順で入手、配置してください。

1. [Google Drive](https://drive.google.com/folderview?id=0BzVgwIMLJboJeHI1N2pwTlc4ZlE&usp=sharing)にライブラリ群を固めたzipがあるのでダウンロードして解凍
3. プログラムの実行ファイルディレクトリに```dlls```ディレクトリを作り、解答した中身のライブラリを全てその下にペースト

#### 推奨しない方法

Google Driveからライブラリを拾うのに抵抗ある方のために古いほうの手順を記載しています。この方法で入手したライブラリでもほぼ全ての機能が使えますが、バイト配列型のデータを読み書き出来ないことに注意してください。

1. PythonのNaoqi SDKをアルデバランの公式サイトから入手し、インストールする
2. インストールするとPythonのパッケージのディレクトリにコア相当ライブラリ(らしい)"qi.dll"や"qic.dll"とboostのdllが配置されるハズなので、それらを全部コピー
3. 実行ファイルのディレクトリに```dlls```ディレクトリを作り、コピーしたライブラリを全てその下にペースト

ディレクトリ名は```dlls```以外でも構いませんが、下記のHello Worldサンプルで示すようにディレクトリ名はプログラム側で使用します。


## Hello World

アプリケーション初期化、セッションの接続、サービス取得、サービスの関数を利用、というラップ元のライブラリと同様な流れで利用できるようになっています。

```
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

            //"say"関数に文字列引数を指定して実行
            tts.Call("say", new QiString("this is test"));

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
```



## Caution

Licenseにも明記していますが免責は宣言しているのでご留意下さい。とくに外部依存ライブラリの解決関係をマジメに調査していないため、複雑な操作に挑戦するとクラッシュする可能性があります。細かい条件まで負えていませんが、異常系の一部のコードでは```AccessViolationException```が出ることも確認しています。




## 問い合わせとか

ブログは[こちら](www.baku-dreameater.net)です。バグ報告や要望についてはブログの適当な記事へのコメント、または[Twitter](https://twitter.com/baku_dreameater)とかへお知らせ下さい。
