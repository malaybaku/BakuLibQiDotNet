using System;
using System.Collections.Generic;
using System.Linq;

using Baku.LibqiDotNet;

namespace StandardSamples
{
    /// <summary>Choregraphe 2.4付属ドキュメントのPythonサンプルでSensorに相当する部分</summary>
    public static class Sensors
    {
        public static void Execute(IQiSession session)
        {
            var mem = session.GetService("ALMemory");
            var sonar = session.GetService("ALSonar");

            //NOTE: PythonサンプルにはFSR(力センサ)の話題も載ってるがだいたい同じなので省略

            Console.WriteLine("First: read IMU values\n");
            var results = new Dictionary<string, string>()
            {
                { "GyrX", "Device/SubDeviceList/InertialSensor/GyrX/Sensor/Value" },
                { "GyrY", "Device/SubDeviceList/InertialSensor/GyrY/Sensor/Value" },

                { "AccX", "Device/SubDeviceList/InertialSensor/AccX/Sensor/Value" },
                { "AccY", "Device/SubDeviceList/InertialSensor/AccY/Sensor/Value" },
                { "AccZ", "Device/SubDeviceList/InertialSensor/AccZ/Sensor/Value" },

                { "TorsoAngleX", "Device/SubDeviceList/InertialSensor/AngleX/Sensor/Value" },
                { "TorsoAngleY", "Device/SubDeviceList/InertialSensor/AngleY/Sensor/Value" }
            }.Select(p => $"key={p.Key}, value={mem["getData"].Call<IQiResult>(p.Value).Dump()}");

            foreach (var r in results)
            {
                //Dynamicのアンパックとかあると見た目的に見づらいのでそこを対策
                Console.WriteLine(r.Replace("\n", ""));
            }

            Console.WriteLine("Second: read sonar values\n");
            sonar["subscribe"].Call("MySampleApplication");
            Console.WriteLine(
                "Left: {0}",
                mem["getData"].Call<IQiResult>("Device/SubDeviceList/US/Left/Sensor/Value").Dump()
                );
            Console.WriteLine(
                "Right: {0}",
                mem["getData"].Call<IQiResult>("Device/SubDeviceList/US/Right/Sensor/Value").Dump()
                );

            sonar["unsubscribe"].Call("MySampleApplication");
        }
    }
}
