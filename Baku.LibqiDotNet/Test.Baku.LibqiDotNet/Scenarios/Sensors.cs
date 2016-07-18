using System.Linq;
using Baku.LibqiDotNet;

namespace Test.Baku.LibqiDotNet
{
    static class Sensors
    {
        public static void GetIMUData(QiSession session)
        {
            var mem = session.GetService("ALMemory");

            float[] results = new string[]
            {
                "Device/SubDeviceList/InertialSensor/GyrX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/GyrY/Sensor/Value",

                "Device/SubDeviceList/InertialSensor/AccX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AccY/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AccZ/Sensor/Value",

                "Device/SubDeviceList/InertialSensor/AngleX/Sensor/Value",
                "Device/SubDeviceList/InertialSensor/AngleY/Sensor/Value"
            }.Select(key => mem["getData"].Call<float>(key))
            .ToArray();
        }

        public static void GetSonarData(QiSession session)
        {
            var mem = session.GetService("ALMemory");
            var sonar = session.GetService("ALSonar");

            sonar["subscribe"].Call("MySampleApplication");

            //NOTE: 妥当な条件が特に無いので、単にデータ取れたら成功扱いする。
            float leftSonar = mem["getData"].Call<float>("Device/SubDeviceList/US/Left/Sensor/Value");
            float rightSonar = mem["getData"].Call<float>("Device/SubDeviceList/US/Right/Sensor/Value");

            sonar["unsubscribe"].Call("MySampleApplication");
        }
    }
}
