using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardSamples
{
    /// <summary>音声のリアルタイム入出力</summary>
    class SoundIO : ILibqiDotNetSample
    {
        const string ServiceName = "CSharpSoundDownloaderSpare";

        public string Description { get; } 
            = "Download/Upload sound via robot, using ALAudioDevice functionality and NAudio.";

        public void Execute(IQiSession session)
        {
            Console.Write(
                "NOTE: SoundIO sample is special in that, \n" +
                "  you can download sound ONLY IF you use Libqi native API wrapper.\n" +
                "  (sound upload is supported both in Libqi native / Socket.IO)\n"
                );

            var audioDevice = ALAudioDevice.CreateService(session);

            //Upload
            var waveIn = new WaveInEvent();
            StartSoundUpload(audioDevice, waveIn);

            //Download
            var mmDevice = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var wavProvider = new BufferedWaveProvider(new WaveFormat(16000, 16, 1));
            var wavPlayer = new WasapiOut(mmDevice, AudioClientShareMode.Shared, false, 200);
            wavPlayer.Init(new VolumeWaveProvider16(wavProvider));

            ulong serviceId = 0;
            if (session.IsServiceRegistrationSupported)
            {
                serviceId = RegisterDownloaderService(session, wavProvider);
                StartSoundDownload(audioDevice, wavPlayer);
            }

            Console.WriteLine("Press ENTER to quit..");
            Console.ReadLine();

            if (session.IsServiceRegistrationSupported)
            {
                StopSoundDownload(audioDevice, wavPlayer);
                session.UnregisterService((uint)serviceId);
            }

            StopSoundUpload(waveIn);
        }

        private void StartSoundUpload(ALAudioDevice audioDevice, WaveInEvent waveIn)
        {
            //Choose sampling rate, from [16000, 22050, 44100, 48000]
            audioDevice.SetParameter("outputSampleRate", 16000);

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

                audioDevice.SendLocalBufferToOutputAsync(bufferToSend.Length / 4, bufferToSend);
                Console.WriteLine($"received data, {count}");
                count++;
            };

            waveIn.StartRecording();
        }

        private void StopSoundUpload(WaveInEvent waveIn)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
        }

        private ulong RegisterDownloaderService(
            IQiSession session, BufferedWaveProvider wavProvider)
        {
            var objBuilder = Baku.LibqiDotNet.Libqi.QiObjectBuilder.Create();
            //コールバックであるprocessRemote関数を登録することでALAudioDevice側の仕様に対応
            objBuilder.AdvertiseMethod(
                "processRemote::v(iimm)",
                (sig, arg) =>
                {
                    //If you want to check data, you can do it by Dump
                    //Console.WriteLine(arg.Dump());
                    byte[] raw = arg[3].ToBytes();
                    wavProvider.AddSamples(raw, 0, raw.Length);

                    return Baku.LibqiDotNet.Libqi.QiValue.Void;
                });

            //Register my service to Robot
            session.Listen("tcp://0.0.0.0:0");
            return session.RegisterService(ServiceName, objBuilder.BuildObject());
        }

        private void StartSoundDownload(ALAudioDevice audioDevice, IWavePlayer wavPlayer)
        {
            wavPlayer.Play();
            //See for the magic number. http://www.baku-dreameater.net/archives/2411 
            audioDevice.SetClientPreferences(ServiceName, 16000, 3, 0);
            audioDevice.Subscribe(ServiceName);
        }

        private void StopSoundDownload(ALAudioDevice audioDevice, IWavePlayer wavPlayer)
        {
            audioDevice.Unsubscribe(ServiceName);
            wavPlayer.Stop();
            wavPlayer.Dispose();
        }
    }
}
