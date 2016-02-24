using System.Collections.Generic;

namespace Baku.LibqiDotNet
{
    /// <summary>qi Frameworkに登録可能なサービスを定義します。</summary>
    public interface IQiBuildableObject
    {
        /// <summary>登録されるサービスの名前です。</summary>
        string ServiceName { get; }

        /// <summary>メソッドの一覧を公開します。</summary>
        /// <returns>サービスへ登録する関数の一覧</returns>
        IEnumerable<IQiObjectMethod> GetMethods();

        //TODO: Signalが登録できないのマズいんだけどイマイチ対応するモチベが上がらない。。。
        
    }
}
