using System;
using System.Net;
using System.Linq;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;

namespace StandardSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = GetSettings();
            if (!setting.IsValidAddress)
            {
                Console.WriteLine("Received invalid IP address. Program ends...");
                return;
            }

            if (!setting.IsValidRuntimeBit)
            {
                Console.WriteLine("Libqi native API was chosen, but this program is 64bit process, so cannot exec. Program ends...");
                return;
            }

            //create instance and connect
            QiSession session = null;
            try
            {
                if (setting.UseLibqi)
                {
                    PathModifier.AddEnvironmentPath("dlls", PathModifyMode.RelativeToEntryAssembly);
                }
                session = setting.UseLibqi ?
                    new QiSessionFactory().CreateLibqiSession() :
                    new QiSessionFactory().CreateSocketIoSession();

                session.Connect(setting.TargetAddress);
                if (!session.IsConnected)
                {
                    Console.WriteLine("Failed to connect. Program ends...");
                    return;
                }
            }
            catch (DllNotFoundException)
            {
                //This exception happens if native .dll files are not in "(StandardSamples.NET35.exe)/dlls" directory.
                Console.WriteLine($"Failed to load dll file. Native libraries are required to put in 'dlls' folder");
                Console.WriteLine("Ends program...");
            }

            _samples[setting.ExecuteSampleId].Execute(session);

            Console.WriteLine("Press ENTER to quit program");
            Console.ReadLine();
        }

        private static SampleExecuteSettings GetSettings()
        {
            //1. Choose implementation Libqi native API wrapper / Socket.IO
            Console.WriteLine(
                "Please input 'Libqi' if you want to use Libqi native API wrapper implementation, \n" +
                "otherwise just press ENTER");
            bool useLibqi = (Console.ReadLine() == "Libqi");
            Console.WriteLine((useLibqi ? "Libqi" : "Socket.IO") + " implementation was selected");

            //2. Input IPAddress of the target robot
            Console.WriteLine("Please input IP address to connect (i.e. '192.168.1.2')");
            string address = Console.ReadLine();

            //3. Select sample to execute
            int targetId = -1;

            Console.WriteLine($"Choose sample by input number 0 to {_samples.Length - 1}");
            for (int i = 0; i < _samples.Length; i++)
            {
                Console.WriteLine($"{i}: {_samples[i].Description}");
            }
            var validInputs = Enumerable
                .Range(0, _samples.Length)
                .Select(v => v.ToString());

            while (true)
            {
                string input = Console.ReadLine();

                if (validInputs.Contains(input))
                {
                    targetId = int.Parse(input);
                    break;
                }
                else
                {
                    Console.WriteLine("could not verify input, please try again.");
                }
            }

            return new SampleExecuteSettings(useLibqi, address, targetId);
        }

        private static ILibqiDotNetSample[] _samples = new ILibqiDotNetSample[]
        {
            new MotionPosesInit(),
            new MotionStiffnessOn(),
            new Sensors(),
            new VisionRetrieveImage(),
            new VisionVideoRecording(),
            new DialogLogging(),
            new SoundIO()
        };

        class SampleExecuteSettings
        {
            public SampleExecuteSettings(bool useLibqi, string address, int targetId)
            {
                UseLibqi = useLibqi;
                TargetAddress = address;
                ExecuteSampleId = targetId;

                IPAddress test;
                IsValidAddress = IPAddress.TryParse(TargetAddress, out test);

                //32bitにしか対応してない。
                IsValidRuntimeBit = (UseLibqi && (IntPtr.Size > 4)) ? false : true;
            }

            public bool IsValidAddress { get; }

            public bool IsValidRuntimeBit { get; }

            public bool UseLibqi { get; }

            public string TargetAddress { get; }

            public int ExecuteSampleId { get; }
        }
    }

}
