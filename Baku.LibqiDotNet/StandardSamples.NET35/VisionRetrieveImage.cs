using System;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;

namespace StandardSamples
{
    class VisionRetrieveImage : ILibqiDotNetSample
    {
        public string Description { get; } = "Get front camera RGB image, using ALVideoDevice functionality.";

        public void Execute(IQiSession session)
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

        static byte[] DownloadRawImage(IQiSession session)
        {
            var videoDevice = ALVideoDevice.CreateService(session);

            //Please see online documentation about the magic numbers used in "SubscribeCamera" method
            //http://doc.aldebaran.com/2-1/naoqi/vision/alvideodevice-api.html?highlight=alvideodevice#ALVideoDeviceProxy::subscribeCamera__ssCR.iCR.iCR.iCR.iCR
            string idName = videoDevice.SubscribeCamera("mytestimage",
                //Camera Type. 0:front camera, 1:downward camera, 2:depth camera
                0,
                //Resolution. 1:320x240, and many other options in the official documentation
                1,
                //Color Space. 11: 24bit RGB, and many other options in the official documentation
                11,
                //FPS, 1 to 30. if using high resolution, low value is preferred.
                5
                );

            //Wait until the camera image is stored in data buffer in the robot...
            Thread.Sleep(500);

            try
            {
                return videoDevice.GetImageRemote(idName).ToBytes();
            }
            finally
            {
                videoDevice.Unsubscribe(idName);
            }
        }

        //Standard transformation from "raw RGB" to normal image format
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
