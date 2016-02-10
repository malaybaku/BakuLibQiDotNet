using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiで受け渡されるメソッド情報を表します。</summary>
    public class QiMethodInfo
    {
        public QiMethodInfo(QiValue mInfo)
        {
            UID = (long)mInfo[0].Value;
            ReturnValueSignature = (string)mInfo[1].Value;
            Name = (string)mInfo[2].Value;
            ArgumentSignature = (string)mInfo[3].Value;
            Description = (string)mInfo[4].Value;

            ArgumentsInfo = Enumerable.Range(0, mInfo[5].Count)
                .Select(i => new QiMethodArgumentInfo(mInfo[5][i]))
                .ToList();

            ReturnValueDescription = (string)mInfo[6].Value;
        }

        /// <summary>メソッドに割り当てられたID</summary>
        public long UID { get; }

        /// <summary>戻り値の型に対応するシグネチャ文字列</summary>
        public string ReturnValueSignature { get; }
        
        /// <summary>メソッド名</summary>
        public string Name { get; }

        /// <summary>引数の型に対応するシグネチャ文字列。必ず最上位はタプルになっている</summary>
        public string ArgumentSignature { get; }

        /// <summary>メソッドを簡単に説明したプレーンテキスト文字列</summary>
        public string Description { get; }

        /// <summary>戻り値の意味を簡単に説明したプレーンテキスト文字列</summary>
        public string ReturnValueDescription { get; }

        /// <summary>引数のインフォメーション一覧(ロジック的には割とどうでもいい)</summary>
        public IReadOnlyList<QiMethodArgumentInfo> ArgumentsInfo { get; }
    }

    /// <summary>引数の名前と意味の情報を表します。シグネチャを持つわけではないことに注意してください。</summary>
    public class QiMethodArgumentInfo
    {
        public QiMethodArgumentInfo(QiValue argInfo)
        {
            Name = (string)argInfo[0].Value;
            Description = (string)argInfo[1].Value;
        }

        public string Name { get; }
        public string Description { get; }
    }


}
