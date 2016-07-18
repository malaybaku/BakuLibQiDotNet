using System;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Libqi;

namespace StandardSamples
{
    /// <summary>音声のリアルタイム入出力</summary>
    static class SoundIO
    {
        public static void Execute(IQiSession session)
        {
            string serviceName = "CSharpSoundDownloaderSpare";
            var audioDevice = session.GetService("ALAudioDevice");

            var waveIn = new WaveInEvent();

            #region 1/4: ロボットへ音を投げる方の仕込み
            //出力サンプリングレートをデフォルト(48kHz)から16kHzに下げる
            //16000, 22050, 44100, 48000のいずれかしか選択できない点に注意
            audioDevice["setParameter"].Call("outputSampleRate", 16000);

            //下のDataAvailableイベントが発生する頻度、バッファの長さに影響する。
            //バッファ長は16384を超えてはいけない点に注意
            //(詳細は公式ドキュメンテーション参照)
            waveIn.BufferMilliseconds = 200;
            //マイクの集音時フォーマット: 周波数を上で設定した値に合わせる
            waveIn.WaveFormat = new WaveFormat(16000, 16, 2);

            int count = 0;
            waveIn.DataAvailable += (_, e) =>
            {
                if (e.BytesRecorded > 16384) return;

                byte[] bufferToSend = new byte[e.BytesRecorded];
                Array.Copy(e.Buffer, bufferToSend, e.BytesRecorded);

                var f = audioDevice["sendRemoteBufferToOutput"].CallAsync(bufferToSend.Length / 4, bufferToSend);
                Console.WriteLine($"received data, {count}");
                count++;
            };
            #endregion

            #region 2/4 ロボットから音を拾う, 再生デバイス準備
            var mmDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var wavProvider = new BufferedWaveProvider(new WaveFormat(16000, 16, 1));

            var wavPlayer = new WasapiOut(mmDevice, AudioClientShareMode.Shared, false, 200);
            wavPlayer.Init(new VolumeWaveProvider16(wavProvider));
            wavPlayer.Play();
            #endregion

            #region 3/4 ロボットから音を拾う, ロボットのマイク監視モードに入る
            var objBuilder = QiObjectBuilder.Create();
            //コールバックであるprocessRemote関数を登録することでALAudioDevice側の仕様に対応
            objBuilder.AdvertiseMethod(
                "processRemote::v(iimm)",
                (sig, arg) =>
                {
                    //ここで処理
                    //Console.WriteLine("Received Buffer!");
                    //Console.WriteLine(arg.Dump());

                    //データの内容については上記のダンプを行うことである程度確認可能
                    byte[] raw = arg[3].ToBytes();
                    wavProvider.AddSamples(raw, 0, raw.Length);

                    return QiValue.Void;
                });

            //上記のコールバック取得用サービスを登録
            session.Listen("tcp://0.0.0.0:0");
            ulong registeredId = (ulong)session.RegisterService(serviceName, objBuilder.BuildObject());

            #endregion

            #region 4/4 設定を調整して実際に入出力を行う
            //マジックナンバーあるけど詳細は右記参照 http://www.baku-dreameater.net/archives/2411 
            audioDevice["setClientPreferences"].Call(serviceName, 16000, 3, 0);

            //開始
            audioDevice["subscribe"].Call(serviceName);
            waveIn.StartRecording();
            #endregion

            Console.WriteLine("Press ENTER to quit..");
            Console.ReadLine();

            audioDevice["unsubscribe"].Call(serviceName);
            session.UnregisterService((uint)registeredId);
            wavPlayer.Stop();
            wavPlayer.Dispose();

            waveIn.StopRecording();
            waveIn.Dispose();
        }
    }
}
