using System;
using System.IO;
using System.Threading;
using System.Reflection;

using Newtonsoft.Json;
using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Libqi;
using Baku.LibqiDotNet.ApiCodeGenerator;

namespace ApiCodeGenerator
{
    class Program
    {
        private static readonly string SolutionFileName = "Baku.LibqiDotNet.sln";
        private static readonly string TargetProjectDirectory = "Baku.LibqiDotNet.Services";
        private static readonly string TargetCodeDirectory = "GeneratedSources";


        static void Main(string[] args)
        {
            Baku.LibqiDotNet.Path.PathModifier.AddEnvironmentPath(
                "dlls", Baku.LibqiDotNet.Path.PathModifyMode.RelativeToEntryAssembly);

            string jsonDirName = "Jsons";

            //JSONの保存(まだ取得してない場合)
            Console.WriteLine("Create New Json Files? ('yes' to connect and create json, or just RETURN to continue)");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Please input connect target IP address(i.e. 192.168.xxx.xxx, robot.local");
                string address = Console.ReadLine();

                //var session = new QiSessionFactory().CreateLibqiSession();
                var session = Baku.LibqiDotNet.Libqi.QiSession.Create(address) 
                    as Baku.LibqiDotNet.Libqi.QiSession;
                if (!session.IsConnected)
                {
                    Console.WriteLine($"Failed to connect to {address}. Ends program...");
                    return;
                }

                LoadServicesAndSaveJsons(session, jsonDirName);
            }

            //JSONからC#への変換
            Console.WriteLine("Create C# Files? ('yes' to create, or just RETURN to pass)");
            if (Console.ReadLine() == "yes")
            {
                ConvertJsonFilesToCSharpFiles(jsonDirName, GetTargetDirectory());
            }

            Console.WriteLine("Program ended. Press RETURN to exit...");
            Console.ReadLine();
        }

        static void LoadServicesAndSaveJsons(Baku.LibqiDotNet.Libqi.QiSession session, string saveDir)
        {
            Directory.CreateDirectory(saveDir);
            foreach (string serviceName in session.GetServices())
            {
                string fileName = Path.Combine(saveDir, $"{serviceName}.json");

                var metaObjectQiValue = (session.GetService(serviceName) as QiObject).GetMetaObject();
                var metaObject = MetaObject.Create(metaObjectQiValue);
                string jsonText = JsonConvert.SerializeObject(metaObject, Formatting.Indented);

                File.WriteAllText(fileName, jsonText);
                Console.WriteLine($"{serviceName}: succeed to save");
                Thread.Sleep(100);
            }
        }

        static void ConvertJsonFilesToCSharpFiles(string srcDir, string destDir)
        {
            if (!Directory.Exists(srcDir))
            {
                Console.WriteLine("Failed to convert JSON to C#: JSON file directory was not found");
                return;
            }
            Directory.CreateDirectory(destDir);
            Console.WriteLine($"Source Directory: {srcDir}");
            Console.WriteLine($"Destination Directory: {destDir}");

            foreach (var srcFile in Directory.GetFiles(srcDir))
            {
                string serviceName = Path.GetFileNameWithoutExtension(srcFile);
                string filename = Path.Combine(destDir, $"{serviceName}.cs");

                var metaObject = JsonConvert.DeserializeObject<MetaObject>(File.ReadAllText(srcFile));
                var templateSource = new QiServiceTemplate(serviceName, metaObject);

                string codeOutput = templateSource.TransformText();
                File.WriteAllText(filename, codeOutput);
                Console.WriteLine($"success: {Path.GetFileName(srcFile)} to {Path.GetFileName(filename)}");
            }
        }

        //C#コードを保存するディレクトリ(Baku.LibqiDotNet.Servicesプロジェクトの下)のパスを取得
        static string GetTargetDirectory()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            while (!File.Exists(Path.Combine(dir, SolutionFileName)))
            {
                dir = Path.GetDirectoryName(dir);
                if (string.IsNullOrEmpty(dir))
                {
                    throw new FileNotFoundException(
                        $"{SolutionFileName} was not found could not get Generated code save path correctly");
                }
            }

            return Path.Combine(dir, TargetProjectDirectory, TargetCodeDirectory);
        }

    }
}
