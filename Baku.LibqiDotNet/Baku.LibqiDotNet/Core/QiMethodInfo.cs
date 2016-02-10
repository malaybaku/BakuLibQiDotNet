using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiで受け渡されるメソッド情報を表します。</summary>
    public class QiMethodInfo
    {
        internal QiMethodInfo(QiValue mInfo)
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

        /// <summary>メソッドに割り当てられたIDを取得します。</summary>
        public long UID { get; }

        /// <summary>戻り値の型に対応するシグネチャ文字列を取得します。</summary>
        public string ReturnValueSignature { get; }
        
        /// <summary>メソッド名を取得します。</summary>
        public string Name { get; }

        /// <summary>引数の型に対応するシグネチャ文字列を取得します。引数はタプルで一括りになっています。</summary>
        public string ArgumentSignature { get; }

        /// <summary>メソッドの役割についての要約文を取得します。</summary>
        public string Description { get; }

        /// <summary>戻り値の意味についての要約文を取得します。</summary>
        public string ReturnValueDescription { get; }

        /// <summary>引数のインフォメーション一覧(ロジック的には割とどうでもいい)</summary>
        public IReadOnlyList<QiMethodArgumentInfo> ArgumentsInfo { get; }
    }

    /// <summary>Qiの関数引数に関する情報を表します。</summary>
    public class QiMethodArgumentInfo
    {
        internal QiMethodArgumentInfo(QiValue argInfo)
        {
            Name = (string)argInfo[0].Value;
            Description = (string)argInfo[1].Value;
        }

        /// <summary>引数の名前を取得します。</summary>
        public string Name { get; }
        /// <summary>引数の意味について要約文を取得します。</summary>
        public string Description { get; }
    }


}
