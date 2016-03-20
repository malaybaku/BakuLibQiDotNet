using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Path;
using Baku.LibqiDotNet.ServiceCodeGenerator;
using System.Threading;
using System.Xml.Serialization;

namespace ServiceCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            PathModifier.AddEnvironmentPath("dlls",  PathModifyMode.RelativeToEntryAssembly);

            Console.WriteLine("Please input connect target IP address(i.e. 192.168.xxx.xxx, robot.local");
            string address = Console.ReadLine();

            var session = QiSession.Create(address);
            if (!session.IsConnected)
            {
                Console.WriteLine($"Failed to connect to {address}. Ends program...");
                return;
            }

            bool ignoreUnderscoreStartedService 
                = ChooseYesOrNo("Ignore services with underscore-started name (like '_SomeService')? ");

            Console.WriteLine($"Setting was set to {ignoreUnderscoreStartedService}");



            string dirName = GetTargetDirectory();
            Directory.CreateDirectory(dirName);

            string[] services = session.GetServices()
                .Where(sname => !ignoreUnderscoreStartedService || !sname.StartsWith("_"))
                .ToArray();
            //コードを生成する場合
            //int successCount = 0;
            //foreach (var serviceName in services)
            //{
            //    bool succeed = TryGenerateAndSaveCode(session, serviceName, dirName);
            //    if(succeed)
            //    {
            //        successCount++;
            //    }
            //    Thread.Sleep(100);
            //}
            //Console.WriteLine(
            //    $"Service:{services.Length}, Succeed: {successCount}, Failed: {services.Length - successCount}");

            //Xmlを取得する場合
            int successCount = 0;
            foreach (var serviceName in services)
            {
                //bool succeed = TryGenerateAndSaveCode(session, serviceName, dirName);
                string xmlDirName = "XmlFiles";
                Directory.CreateDirectory(xmlDirName);
                string filename = Path.Combine(xmlDirName, $"{serviceName}.xml");

                try
                {
                    var service = session.GetService(serviceName);
                    var mo = service.GetMetaObject();
                    var xmlMo = XmlMetaObjectParser.CreateMetaObject(mo);
                    var serializer = new XmlSerializer(xmlMo.GetType());
                    using (var sw = new StreamWriter(filename))
                    {
                        serializer.Serialize(sw, xmlMo);
                    }
                    Console.WriteLine($"{serviceName}: succeed to save");
                    successCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{serviceName}: Failed, {ex.GetType().Name}: {ex.Message}");
                    File.Delete(filename);
                }
                Thread.Sleep(100);
            }
            Console.WriteLine(
                $"Service:{services.Length}, Succeed: {successCount}, Failed: {services.Length - successCount}");

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        static bool ChooseYesOrNo(string question)
        {
            bool? result = null;
            while (!result.HasValue)
            {
                Console.WriteLine(question + " (Y/n)");
                string input = Console.ReadLine();

                if (input == "Y" || input == "y")
                {
                    result = true;
                }
                else if (input == "N" || input == "n")
                {
                    result = false;
                }
            }

            return result.GetValueOrDefault();
        }

        private static readonly string SolutionFileName = "Baku.LibqiDotNet.sln";
        private static readonly string TargetProjectDirectory = "Baku.LibqiDotNet.Services";
        private static readonly string TargetCodeDirectory = "GeneratedSources";

        static string GetTargetDirectory()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            while (!File.Exists(Path.Combine(dir, SolutionFileName)))
            {
                dir = Path.GetDirectoryName(dir);
                if(string.IsNullOrEmpty(dir))
                {
                    throw new FileNotFoundException(
                        $"{SolutionFileName} was not found could not get Generated code save path correctly");
                }
            }

            return Path.Combine(dir, TargetProjectDirectory, TargetCodeDirectory);
        }

        static bool TryGenerateAndSaveCode(QiSession session, string serviceName, string saveDir)
        {
            string filename = Path.Combine(saveDir, $"{serviceName}.cs");
            try
            {
                var qs = new QiServiceTemplate(
                    serviceName, session.GetService(serviceName).GetMetaObject()
                    );

                string output = qs.TransformText();
                File.WriteAllText(filename, output);

                Console.WriteLine($"{serviceName}: succeed to save");
                return true;
            }
            catch (Exception ex)
            {
                File.Delete(filename);

                Console.WriteLine($"{serviceName}: Failed, {ex.GetType().Name}: {ex.Message}");
                return false;
            }
        }
    }
}
