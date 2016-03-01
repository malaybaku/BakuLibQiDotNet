using System;
using System.Linq;

using Baku.LibqiDotNet;

namespace StandardSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string expectedDllPath = System.IO.Path.Combine(Environment.CurrentDirectory, "dlls");
            PathModifier.AddEnvironmentPaths(expectedDllPath);

            string input = "";

            try
            {
                Console.WriteLine("Please input address to connect (i.e. 'tcp://127.0.0.1:9559')");
                string address = Console.ReadLine();
                var session = QiSession.Create(address);
                if (!session.IsConnected)
                {
                    Console.WriteLine("Failed to connect. Program ends...");
                    return;
                }

                while (true)
                {
                    Console.WriteLine("Choose sample by input number 1, 2, 3, 4 or 5.");
                    Console.WriteLine("1. Motion Pose Initialize");
                    Console.WriteLine("2. Motion Stiffness On");
                    Console.WriteLine("3. Sensor Read");
                    Console.WriteLine("4. Get camera image to local");
                    Console.WriteLine("5. Video Recording");
                    Console.WriteLine("6. Speech Recognition / Robot Speech Logging");
                    Console.WriteLine("7. Sound IO");

                    input = Console.ReadLine();
                    if ((new string[] { "1", "2", "3", "4", "5", "6", "7" }).Contains(input))
                    {
                        break;
                    }

                    Console.WriteLine("could not verify input, please try again.");
                }

                if(input == "1")
                {
                    MotionPosesInit.Execute(session);
                }
                else if (input == "2")
                {
                    MotionStiffnessOn.Execute(session);
                }
                else if (input == "3")
                {
                    Sensors.Execute(session);
                }
                else if (input == "4")
                {
                    VisionRetrieveImage.Execute(session);
                }
                else if (input == "5")
                {
                    VisionVideoRecording.Execute(session);
                }
                else if (input == "6")
                {
                    DialogLogging.Execute(session);
                }
                else if (input == "7")
                {
                    SoundIO.Execute(session);
                }

            }
            catch(DllNotFoundException)
            {
                //アンマネージドのDLLを実行ファイルの"dll"に置くのを忘れていたケース
                Console.WriteLine($"Failed to load dll file. Unmanaged libraries are required to put at {expectedDllPath}");
                Console.WriteLine("Ends program...");
            }

            Console.WriteLine("Press ENTER to quit program");
            Console.ReadLine();

        }
    }
}
