using Baku.LibqiDotNet.Libqi;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{

    public class MetaObject
    {
        public List<MetaMethod> methods { get; set; }

        public List<MetaSignal> signals { get; set; }

        public List<MetaProperty> properties { get; set; }

        public string description { get; set; }

        public static MetaObject Create(QiValue qv)
        {
            return new MetaObject()
            {
                methods = qv[0].MapItems.Select(p => MetaMethod.Create(p.Value as QiValue)).ToList(),
                signals = qv[1].MapItems.Select(p => MetaSignal.Create(p.Value as QiValue)).ToList(),
                properties = qv[2].MapItems.Select(p => MetaProperty.Create(p.Value as QiValue)).ToList(),
                description = qv[3].ToString()
            };
        }
    }

    public class MetaMethod
    {
        public uint uid { get; set; }

        public string returnSignature { get; set; }

        public string name { get; set; }

        public string parametersSignature { get; set; }

        public string description { get; set; }

        public List<MetaMethodParameter> parameters { get; set; }

        public string returnDescription { get; set; }

        public static MetaMethod Create(QiValue qv)
        {
            return new MetaMethod()
            {
                uid = qv[0].ToUInt32(),
                returnSignature = qv[1].ToString(),
                name = qv[2].ToString(),
                parametersSignature = qv[3].ToString(),
                description = qv[4].ToString(),
                parameters = Enumerable
                    .Range(0, qv[5].Count)
                    .Select(i => MetaMethodParameter.Create(qv[5][i]))
                    .ToList(),
                returnDescription = qv[6].ToString()
            };
        }
    }

    public class MetaMethodParameter
    {
        public string name { get; set; }

        public string description { get; set; }

        public static MetaMethodParameter Create(IQiResult qv)
        {
            return new MetaMethodParameter()
            {
                name = qv[0].ToString(),
                description = qv[1].ToString()
            };
        }
    }

    public class MetaSignal
    {
        public uint uid { get; set; }
        public string name { get; set; }
        public string signature { get; set; }

        public static MetaSignal Create(QiValue qv)
        {
            return new MetaSignal()
            {
                uid = qv[0].ToUInt32(),
                name = qv[1].ToString(),
                signature = qv[2].ToString()
            };
        }
    }

    public class MetaProperty
    {
        public uint uid { get; set; }
        public string name { get; set; }
        public string signature { get; set; }

        public static MetaProperty Create(QiValue qv)
        {
            return new MetaProperty()
            {
                uid = qv[0].ToUInt32(),
                name = qv[1].ToString(),
                signature = qv[2].ToString()
            };
        }
    }

}
