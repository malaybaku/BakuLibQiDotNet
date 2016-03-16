using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>Qi Frameworkのモジュールに定義された関数の一覧を表します。</summary>
    public sealed class QiMethods
    {
        internal QiMethods(QiObject qiObj)
        {
            _methods = GetMethods(qiObj);
        }

        /// <summary>名前を指定してメソッド名を取得します。</summary>
        /// <param name="methodName">メソッドの名前</param>
        /// <returns>対応するメソッド。不正な名前を指定した場合は例外が送出されます。</returns>
        /// <exception cref="KeyNotFoundException"/>
        public QiMethod this[string methodName] => _methods[methodName];

        private readonly IDictionary<string, QiMethod> _methods;

        private static IDictionary<string, QiMethod> GetMethods(QiObject qiObj)
        {
            //観察事実としてmObjは4要素タプルであり、第0要素にメソッド一覧が入ってる
            var mObj = qiObj.MetaObject;
            if (mObj.Count == 0)
            {
                throw new InvalidOperationException("meta object does not contains info");
            }

            var qKeys = mObj[0].GetKeys();
            var methodInfos = Enumerable
                .Range(0, qKeys.Count)
                .Select(i => qKeys[i])
                .Select(k => new QiMethodInfo(mObj[0][k]));

            var methodOverloads = new Dictionary<string, List<QiMethodInfo>>();
            foreach (var mi in methodInfos)
            {
                if (methodOverloads.ContainsKey(mi.Name))
                {
                    methodOverloads[mi.Name].Add(mi);
                }
                else
                {
                    methodOverloads[mi.Name] = new List<QiMethodInfo>() { mi };
                }
            }

            return methodOverloads.ToDictionary(
                p => p.Key,
                p => new QiMethod(qiObj, p.Value)
                );
        }

    }
}
