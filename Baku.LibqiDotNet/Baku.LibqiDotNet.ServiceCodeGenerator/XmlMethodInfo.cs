using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    public class XmlMetaObject
    {
        public List<XmlMethodInfo> MethodInfos { get; set; }

        public List<XmlSignalInfo> SignalInfos { get; set; }

        public List<XmlPropertyInfo> PropertyInfos { get; set; }

        public string Description { get; set; }
    }

    public class XmlMethodInfo
    {
        public uint Uid { get; set; }

        public string ReturnSignature { get; set; }

        public string MethodName { get; set; }

        public string ArgSignature { get; set; }

        public string Description { get; set; }

        public List<XmlArgInfo> ArgInfos { get; set; }

        public string MethodDescription { get; set; }
    }

    public class XmlArgInfo
    {
        public string ArgName { get; set; }

        public string Description { get; set; }
    }

    public class XmlSignalInfo
    {
        public uint Uid { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
    }

    public class XmlPropertyInfo
    {
        public uint Uid { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
    }

    static class XmlMetaObjectParser
    {
        public static XmlMetaObject CreateMetaObject(QiValue qv)
        {
            return new XmlMetaObject()
            {
                MethodInfos = qv[0].MapValues.Select(v => CreateMethodInfo(v)).ToList(),
                SignalInfos = qv[1].MapValues.Select(v => CreateSignalInfo(v)).ToList(),
                PropertyInfos = qv[2].MapValues.Select(v => CreatePropertyInfo(v)).ToList(),
                Description = qv[3].ToString()
            };
        }

        public static XmlMethodInfo CreateMethodInfo(QiValue qv)
        {
            return new XmlMethodInfo()
            {
                Uid = qv[0].ToUInt32(),
                ReturnSignature = qv[1].ToString(),
                MethodName = qv[2].ToString(),
                ArgSignature = qv[3].ToString(),
                Description = qv[4].ToString(),
                ArgInfos = Enumerable.Range(0, qv[5].Count).Select(i => CreateArgInfo(qv[5][i])).ToList(),
                MethodDescription = qv[6].ToString()
            };
        }

        private static XmlArgInfo CreateArgInfo(QiValue qv)
        {
            return new XmlArgInfo()
            {
                ArgName = qv[0].ToString(),
                Description = qv[1].ToString()
            };
        }

        private static XmlSignalInfo CreateSignalInfo(QiValue qv)
        {
            return new XmlSignalInfo()
            {
                Uid = qv[0].ToUInt32(),
                Name = qv[1].ToString(),
                Signature = qv[2].ToString()
            };
        }

        private static XmlPropertyInfo CreatePropertyInfo(QiValue qv)
        {
            return new XmlPropertyInfo()
            {
                Uid = qv[0].ToUInt32(),
                Name = qv[1].ToString(),
                Signature = qv[2].ToString()
            };
        }


    }
}
