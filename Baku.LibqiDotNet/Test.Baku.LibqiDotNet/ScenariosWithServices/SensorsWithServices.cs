using Baku.LibqiDotNet;
using Baku.LibqiDotNet.Service;
using System.Linq;

namespace Test.Baku.LibqiDotNet
{
    static class SensorsWithServices
    {
        public static void GetIMUData(QiSession session)
        {
            var mem = ALMemory.CreateService(session);

            float[] results = new string[]
            {
                "Device/SubDeviceList/InertialSensor/GyrX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/GyrY/Sensor/Value",

                "Device/SubDeviceList/InertialSensor/AccX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AccY/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AccZ/Sensor/Value",

                "Device/SubDeviceList/InertialSensor/AngleX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AngleY/Sensor/Value"
            }.Select(key => mem.GetData(key).ToFloat())
            .ToArray();
        }

        public static void GetSonarData(QiSession session)
        {
            var mem = ALMemory.CreateService(session);
            var sonar = ALSonar.CreateService(session);

            sonar.Subscribe("MySampleApplication");

            //NOTE: 妥当な条件が特に無いので、単にデータ取れたら成功扱いする。
            float leftSonar = mem.GetData("Device/SubDeviceList/US/Left/Sensor/Value").ToFloat();
            float rightSonar = mem.GetData("Device/SubDeviceList/US/Right/Sensor/Value").ToFloat();

            sonar.Unsubscribe("MySampleApplication");
        }
    }
}
