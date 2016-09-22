using System;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのメソッドを表します。</summary>
    public interface IQiMethod
    {
        /// <summary>メソッド名を取得します。</summary>
        string Name { get; }

        /// <summary>関数を呼び出します。結果は非同期的に取得します</summary>
        /// <param name="args">関数の引数</param>
        /// <returns>結果</returns>
        IQiFuture CallAsync(params object[] args);

        /// <summary>関数を呼び出します。結果は非同期的に取得します</summary>
        /// <param name="args">関数の引数</param>
        /// <returns>結果</returns>
        IQiFuture<T> CallAsync<T>(params object[] args);
    }

    /// <summary><see cref="IQiMethod"/>インターフェースの拡張メソッドを提供します。</summary>
    public static class IQiMethodExtensions
    {
        /// <summary>関数を同期的に呼び出します。関数の戻り値は無いか、あったとしても無視されます。</summary>
        /// <param name="method">メソッド</param>
        /// <param name="args">メソッドの引数</param>
        public static void Call(this IQiMethod method, params object[] args)
            => method.CallAsync(args)
            .WaitAndThrowIfFailed();

        /// <summary>関数を同期的に呼び出し、結果を組み込み型あるいはよく用いられる組み込み型の配列として取得します。</summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="method">メソッド</param>
        /// <param name="args">メソッドの引数</param>
        /// <returns>関数の呼び出し結果</returns>
        public static T Call<T>(this IQiMethod method, params object[] args)
            => method.CallAsync<T>(args)
            .WaitAndThrowIfFailed()
            .Get();

    }
}
