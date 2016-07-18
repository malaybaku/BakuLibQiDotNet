using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Baku.LibqiDotNet.Utils;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiMethods
    {
        internal QiMethods(QiSession session, QiObject parentObj, JObject methods)
        {
            _methods = methods
                .Properties()
                .Select(p => (string)p.Value["name"])
                .Distinct()
                .ToDictionary(n => n,  n => new QiMethod(n, session, parentObj))
                .ToReadOnlyDictionary();
        }

        public QiMethod this[string name]
        {
            get
            {
                if (_methods.ContainsKey(name))
                {
                    return _methods[name];
                }
                else
                {
                    throw new KeyNotFoundException($"This QiObject does not have method '{name}'");
                }
            }
        }

        private readonly ReadOnlyDictionary<string, QiMethod> _methods;
    }
}
