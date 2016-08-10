using Baku.LibqiDotNet.Service;

namespace Baku.LibqiDotNet.Samples.Net45
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new QiSessionFactory().CreateSocketIoSession();

            s.Connect("192.168.1.3");

            var tts = ALTextToSpeech.CreateService(s);

            tts.Say("Hello, I am from dot net framework 4.5.");
        }
    }
}
