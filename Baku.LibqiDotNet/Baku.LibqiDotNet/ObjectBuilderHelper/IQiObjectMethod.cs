using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baku.LibqiDotNet
{
    /// <summary>qi Frameworkのサービスに登録できる関数を定義します。</summary>
    public interface IQiObjectMethod
    {
        /// <summary>メソッドの名前です。</summary>
        string MethodName { get; }

        /// <summary>関数の戻り値と引数を表すシグネチャです。例: "s(i)"がシグネチャであれば整数を引数に取り文字列を返す関数を表します。</summary>
        string Signature { get; }

        /// <summary>実際の処理を呼び出します。</summary>
        /// <param name="arg">タプルにまとめた形でqi Frameworkから渡される引数</param>
        /// <returns>処理の結果</returns>
        QiValue Invoke(QiValue arg);

    }
}
