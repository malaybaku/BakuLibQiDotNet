# Baku.LibqiDotNet

Baku/獏(ばく)

2016/March/15

- About
- Environment
- Library Files Preparation
- Hello World
- Contact

This is Japanese documentation, and [English version](https://github.com/malaybaku/BakuLibQiDotNet/blob/master/readme_en.md) is also available.

## About

Aldebaran社が公開しているメッセージングフレームワーク```libqi```を.NETから使えるようにするためのラッパーライブラリです。Aldebaranのlibqiライブラリ群については下記等を参照ください。

- [libqi](https://github.com/aldebaran/libqi)
- [libqi-capi](https://github.com/aldebaran/libqi-capi)

ドキュメンテーションのレポジトリも別途用意しています。ドキュメンテーションは基本的にNuGetパッケージ(とUnityパッケージ)の最新版向けに公開しており、こちらの`master`ブランチの最新内容とは一部食い違っている事があるので気を付けて下さい。

- [チュートリアル](http://malaybaku.github.io/BakuLibqiDotNetTutorial/)
- [クラス構造のリファレンス](http://malaybaku.github.io/BakuLibqiDotNetDoc/)



## Environment

開発: Windows 10/Visual Studio 2015 Community

想定する実行環境
- Windows 7/8/10
- .NET 3.5以降
- **32bit**

**32bit**をターゲットとしているのはWindowsでの`libqi`のラップ元であるアンマネージライブラリが32bitにしか対応していないためです。

.NET 3.5がターゲットなのでビルド設定によってUnityEngine向けにもビルド可能です。Unityでの利用方法については[ブログの記事](http://www.baku-dreameater.net/archives/10791)をご覧ください。UnityEngineでの利用に関してはMacのUnityEditor(64bit)でも動作するのを確認しています。


## Library Files Preparation

本プロジェクトはあくまでラッパーでありラップ元のライブラリ("qic.dll"を含むライブラリ群)は同梱していません。次のいずれかの手順を踏んでライブラリを手に入れて下さい。なお、[NuGetパッケージ版](https://www.nuget.org/packages/Baku.LibqiDotNet/)ではパッケージにライブラリが同梱されています。パッケージの準備手順が分からない場合、NuGetパッケージが行う配置処理を一つの参考にしてもらえると分かりやすいかもしれません。

#### 推奨する方法

本ラッパー用にビルドしたライブラリを使う方法です。ラップ元である[libqi-capi](https://github.com/aldebaran/libqi-capi)の一部機能が2016年2月時点で実装されていなかったため、不足機能を実装してビルドを行ったものを配布しています。詳細は[このissue](https://github.com/malaybaku/BakuLibQiDotNet/issues/1)をご覧ください。

下記の手順で入手、配置します。

1. [Google Drive](https://drive.google.com/folderview?id=0BzVgwIMLJboJeHI1N2pwTlc4ZlE&usp=sharing)にライブラリ群を固めたzipがあるのでダウンロードして解凍
3. プログラムの実行ファイルディレクトリへ、上記解凍物の中にある```dlls```フォルダをフォルダごとコピーペースト

#### 推奨しない方法

Google Driveからライブラリを拾うのに抵抗ある方のために代替手順を記載しています。この方法で入手したライブラリでもほぼ全ての機能が使えますが、バイト配列型のデータを読み書き出来ないことに注意してください。

1. PythonのNaoqi SDKをアルデバランの公式サイトから入手し、インストールする
2. インストールするとPythonのパッケージのディレクトリにコア相当ライブラリ(らしい)"qi.dll"や"qic.dll"とboostのdllが配置されるハズなので、それらを全部コピー
3. 実行ファイルのディレクトリに```dlls```ディレクトリを作り、コピーしたライブラリを全てその下にペースト

ディレクトリ名は```dlls```以外でも構いませんが、下記のHello Worldサンプルで示すようにディレクトリ名はプログラム側で使用します。


## Hello World

C++/Python/Java等とだいたい同じやり方で使えます。セッション接続、サービスの取得、サービスの関数を呼び出す、という流れでだいたいの機能は利用できるようになっています。

```
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
            string address = "tcp://127.0.0.1:9559";
            var session = QiSession.Create(address);

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

            session.Close();
            session.Destroy();
        }
    }
}
```

ライブラリ本来の挙動に対してあまり本質的ではない注意になりますが、`PathModifier`を用いることで、exeファイルのディレクトリに配置された`dlls`フォルダの中に入っているアンマネージライブラリを参照可能にしている点に注意してください。この処理を省きたい場合、`dlls`フォルダに含まれるアンマネージライブラリをあらかじめexeファイルの含まれるディレクトリにコピーしておいてください。



## Contact
バグ報告だけでなく機能追加の要望も受け付けています。たぶんtwitterでコンタクトを取っていただくと一番レスポンスが速いです。

- [Blog](https://www.baku-dreameater.net)
- [Twitter](https://twitter.com/baku_dreameater)
