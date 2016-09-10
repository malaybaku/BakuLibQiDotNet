using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Baku.LibqiDotNet.Utils;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>JSONオブジェクト情報に基づくメソッド一覧を表します。</summary>
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

        /// <summary>メソッド名を指定してメソッドを取得します。</summary>
        /// <param name="name">メソッド名</param>
        /// <returns>指定された名前のメソッド</returns>
        /// <exception cref="KeyNotFoundException" />
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
