using System.Linq;

using Baku.LibqiDotNet.Utils;

namespace Baku.LibqiDotNet
{
    /// <summary>メソッドの名称以外の補助情報を表します。</summary>
    public sealed class QiMethodInfo
    {
        internal QiMethodInfo(QiValue mInfo)
        {
            UID = mInfo[0].ToInt64();
            ReturnValueSignature = mInfo[1].GetString();
            Name = mInfo[2].GetString();
            ArgumentSignature = mInfo[3].GetString();
            Description = mInfo[4].GetString();

            ArgumentsInfo = new ReadOnlyList<QiMethodArgumentInfo>(
                Enumerable.Range(0, mInfo[5].Count)
                .Select(i => new QiMethodArgumentInfo(mInfo[5][i]))
                .ToList());

            ReturnValueDescription = mInfo[6].GetString();
        }

        /// <summary>メソッドに割り当てられたIDを取得します。</summary>
        public long UID { get; }

        /// <summary>メソッド名を取得します。</summary>
        public string Name { get; }

        /// <summary>戻り値の型に対応するシグネチャ文字列を取得します。</summary>
        public string ReturnValueSignature { get; }

        /// <summary>引数の型に対応するシグネチャ文字列を取得します。引数はタプルで一括りになっています。</summary>
        public string ArgumentSignature { get; }

        /// <summary>メソッドの役割についての要約文を取得します。</summary>
        public string Description { get; }

        /// <summary>戻り値の意味についての要約文を取得します。</summary>
        public string ReturnValueDescription { get; }

        /// <summary>引数のインフォメーション一覧(ロジック的には割とどうでもいい)</summary>
        public ReadOnlyList<QiMethodArgumentInfo> ArgumentsInfo { get; }
    }
}
