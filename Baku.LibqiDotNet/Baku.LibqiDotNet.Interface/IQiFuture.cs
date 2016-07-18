using System;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiの非同期呼び出し処理のうち戻り値取得を含まないインターフェースを定義します。</summary>
    public interface IQiFuture
    {
        /// <summary>指定した時間まで待機します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>待機後の、このインスタンス自身</returns>
        void Wait(int timeout);

        /// <summary>無期限に待機します。</summary>
        /// <returns>待機後の、このインスタンス自身</returns>
        void Wait();

        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>エラーの有無</returns>
        bool CheckHasError(int timeout);

        /// <summary>エラーが起きたかどうかを無期限待機ののち確認します。</summary>
        /// <returns>エラーの有無</returns>
        bool CheckHasError();

        /// <summary>値を持っているかどうかを待機ののち確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>値の所持の有無</returns>
        bool CheckHasValue(int timeout);

        /// <summary>値を持っているかどうかを無期限待機ののち確認します。</summary>
        /// <returns>値の所持の有無</returns>
        bool CheckHasValue();

        /// <summary>結果取得をキャンセルします。</summary>
        void Cancel();

        /// <summary>処理が実行中であるかを取得します。</summary>
        bool IsRunning { get; }

        /// <summary>処理が終了済であるかを取得します。</summary>
        bool IsFinished { get; }

        /// <summary>処理がキャンセル済みであるかを取得します。</summary>
        bool IsCanceled { get; }

        /// <summary>エラーが起きたことが確定した場合<see langword="true"/>となります。処理自体が終了していない場合の値は未定義です。</summary>
        bool HasError { get; }

        /// <summary>エラーがある場合、それを文字列として取得します。</summary>
        string ErrorMessage { get; }

        /// <summary>動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        void AddCallback(Action cb);
    }

    /// <summary>戻り値のあるQiの非同期呼び出し処理インターフェースを定義します。</summary>
    /// <typeparam name="T">呼び出し処理の戻り値の型。何でも指定できるわけではないので気を付けて下さい。(TODO:ドキュメンテーション)</typeparam>
    public interface IQiFuture<T> : IQiFuture
    {
        /// <summary>
        /// 呼び出し結果を取得します。
        /// 型<typeparamref name="T"/>が実際の戻り値と食い違っていたり
        /// <see cref="IQiFuture.IsFinished"/>が<see langword="false"/>場合に呼び出すと
        /// 例外が送出される可能性があります。
        /// </summary>
        /// <returns>呼び出し結果</returns>
        T Get();

        /// <summary>動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        void AddCallback(Action<T> cb);
    }

    /// <summary>[do NOT use directly]<see cref="IQiFuture"/>の拡張メソッドを提供します。</summary>
    public static class QiFutureAsyncExtension
    {
        /// <summary>[do NOT use directly]<see cref="IQiFuture"/>のAwaiterを取得します。</summary>
        /// <param name="future">非同期呼び出し</param>
        /// <returns>非同期呼び出しに対応したAwaiter</returns>
        public static QiFutureAwaiter GetAwaiter(this IQiFuture future) => new QiFutureAwaiter(future);
    }

    /// <summary>[do NOT use directly]<see cref="IQiFuture"/>クラスへAwaiterパターンの実装を提供します。</summary>
    public class QiFutureAwaiter
    {
        internal QiFutureAwaiter(IQiFuture future)
        {
            _future = future;
        }

    private readonly IQiFuture _future;
    
    /// <summary>生成元の<see cref="IQiFuture"/>の処理が完了したかを取得します。</summary>
    public bool IsCompleted => _future.IsFinished;
    
    /// <summary><see cref="IQiFuture"/>の処理完了後のコールバックを登録します。TODO: この処理の品質調査</summary>
    /// <param name="continuation">継続処理</param>
    public void OnCompleted(Action continuation) => _future.AddCallback(continuation);

    /// <summary>処理完了まで待機し、元の<see cref="IQiFuture"/>を取得します。</summary>
    /// <returns>処理結果</returns>
    public IQiFuture GetResult()
    {
        _future.Wait();
        return _future;
    }
}

    /// <summary>[do NOT use directly]<see cref="IQiFuture{T}"/>クラスに対してAwaiterパターンの実装を提供します。</summary>
    public class QiFutureAwaiter<T>
    {
        internal QiFutureAwaiter(IQiFuture<T> future)
        {
            _future = future;
        }

        private readonly IQiFuture<T> _future;
        /// <summary>生成元の<see cref="IQiFuture"/>の処理が完了したかを取得します。</summary>
        public bool IsCompleted => _future.IsFinished;
        /// <summary><see cref="IQiFuture"/>の処理完了後のコールバックを登録します。TODO: この処理の品質調査</summary>
        /// <param name="continuation">継続処理</param>
        public void OnCompleted(Action continuation) => _future.AddCallback(_ => continuation());
        /// <summary>処理完了まで待機し、生成元の<see cref="IQiFuture"/>に対応した処理結果を取得します。</summary>
        /// <returns>処理結果</returns>
        public T GetResult()
        {
            _future.Wait();
            return _future.Get();
        }
    }
}
