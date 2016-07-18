using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamplesWithServices
{
    static class VisionRetrieveImage
    {
        public static void Execute(QiSession session)
        {
            byte[] rawImageData = DownloadRawImage(session);
            Console.WriteLine($"raw data length = {rawImageData.Length}");

            try
            {
                int height = 240;
                int width = 320;
                int channel = 3;
                var img = GetImageFromRawData(rawImageData, width, height, channel);
                img.Save("result.png", ImageFormat.Png);
                Console.WriteLine("Front camera's image was saved to working directory with name 'result.png'");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Failed to get image: " + ex.Message);
            }

        }

        static byte[] DownloadRawImage(QiSession session)
        {
            var vd = ALVideoDevice.CreateService(session);

            //忌々しいマジックナンバーを使っているが、パラメタについては
            //ALVideoDevice::subscribeのドキュメンテーションに載っているので参照されたく。
            //http://doc.aldebaran.com/2-1/naoqi/vision/alvideodevice-api.html?highlight=alvideodevice#ALVideoDeviceProxy::subscribeCamera__ssCR.iCR.iCR.iCR.iCR
            string idName = vd.SubscribeCamera("mytestimage",
                //カメラ種類 0:正面, 1:下方, 2:深度
                0,
                //解像度 1:320x240
                1,
                //色空間 11が24bit RGBなので基本コレでいいがYUVの方が速度速そうみたいな話もあるので注意
                11,
                //FPS: 1から30くらいまで
                5
                );

            //画像がデータバッファに溜まるのを確実に待機
            Task.Delay(500).Wait();

            try
            {
                return vd.GetImageRemote(idName)[6].ToBytes();
            }
            finally
            {
                vd.Unsubscribe(idName);
            }

        }

        //System.Drawingで生のRGBバイトから画像への変換を行う一般的な方法
        //NOTE: System.Windows.Media.Imaging.BitmapSourceクラスの静的メソッドであるCreateメソッドでもほぼ同じ処理が可能
        static Bitmap GetImageFromRawData(byte[] data, int width, int height, int channel)
        {
            if (data.Length != width * height * channel)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "data.Length is not matches to 'width * height * channel' (expected {0}, length was {1})",
                        width * height * channel, 
                        data.Length
                        )
                    );
            }

            return new Bitmap(width, height, width * channel,
                PixelFormat.Format24bppRgb,
                Marshal.UnsafeAddrOfPinnedArrayElement(data, 0)
                );

        }

    }
}
