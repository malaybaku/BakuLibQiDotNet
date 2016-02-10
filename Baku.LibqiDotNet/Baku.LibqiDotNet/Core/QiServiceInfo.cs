using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>サービスに含まれるメソッド情報などの一覧を表します。</summary>
    public class QiServiceInfo
    {
        public QiServiceInfo(QiObject qiObj)
        {
            var mObj = qiObj.GetMetaObject();
            //観察事実としてmObjは4要素タプルであり、第0要素にメソッド一覧が入ってる
            if (mObj.Count == 0)
            {
                throw new InvalidOperationException("meta object does not contains info");
            }

            var qKeys = mObj[0].GetKeys();

            MethodInfos = Enumerable
                .Range(0, qKeys.Count)
                .Select(i => qKeys[i])
                .ToDictionary(
                    k => (long)k.Value,
                    k => new QiMethodInfo(mObj[0][k])
                );

            Description = (string)mObj[3].Value;
        }

        /// <summary>サービスに含まれるメソッドの一覧</summary>
        public IReadOnlyDictionary<long, QiMethodInfo> MethodInfos { get; }

        /// <summary>サービスの機能について簡単に説明したプレーンテキスト文字列</summary>
        public string Description { get; }

    }
}
