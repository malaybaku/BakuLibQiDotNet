using System;
using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>非同期的にリクエストの戻り値を受け取るコンテナを表します。</summary>
    public class QiFuture : IQiFuture
    {
        internal QiFuture(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        #region IQiFuture

        /// <summary>
        /// 指定した時間まで待機します。
        /// </summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>待機後の、このインスタンス自身</returns>
        public void Wait(int timeout) => QiApiFuture.Wait(this, timeout);

        /// <summary>無期限に待機します。</summary>
        /// <returns>待機後の、このインスタンス自身</returns>
        public void Wait() => Wait(InfiniteTimeout);

        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError(int timeout)
            => (HasError = QiApiFuture.HasError(this, timeout));

        /// <summary>エラーが起きたかどうかを無期限待機ののち確認します。</summary>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError() => CheckHasError(InfiniteTimeout);

        /// <summary>値を持っているかどうかを待機ののち確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue(int timeout) => QiApiFuture.HasValue(this, timeout);

        /// <summary>値を持っているかどうかを無期限待機ののち確認します。</summary>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue() => CheckHasValue(InfiniteTimeout);

        /// <summary>結果取得をキャンセルします。</summary>
        public void Cancel() => QiApiFuture.Cancel(this);

        /// <summary>処理が実行中であるかを取得します。</summary>
        public bool IsRunning => QiApiFuture.IsRunning(this);

        /// <summary>処理が終了済であるかを取得します。</summary>
        public bool IsFinished => QiApiFuture.IsFinished(this);

        /// <summary>処理がキャンセル済みであるかを取得します。</summary>
        public bool IsCanceled => QiApiFuture.IsCanceled(this);

        private bool? _hasError = null;
        /// <summary>処理がエラー終了したかどうかを取得します。</summary>
        public bool HasError
        {
            get
            {
                if (_hasError.HasValue)
                {
                    return _hasError.Value;
                }
                else if (IsFinished)
                {
                    _hasError = CheckHasError();
                    return _hasError.Value;
                }
                else
                {
                    //NOTE: CheckHasError()は時間かかるのでプロパティという体裁考えて使わないようにする
                    //楽観的に処理されないようエラーある扱いにしておく。
                    return true;
                }
            }
            private set { _hasError = value; }
        }

        /// <summary>エラーがある場合、それを文字列として取得します。</summary>
        public string ErrorMessage => QiApiFuture.GetError(this);

        public void AddCallback(Action cb)
            => AddCallback(new Action<IQiFuture>(_ => cb()));

        #endregion

        /// <summary>一般的な処理結果を取得します。</summary>
        /// <returns>呼び出し結果。完了待機や戻り値の有効性チェックが適切に行われていない場合、例外が生じる可能性があります。</returns>
        public IQiResult GetValue() => QiApiFuture.GetValue(this);

        /// <summary>結果を符号つき整数として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public long GetInt64(long def) => QiApiFuture.GetInt64Default(this, def);

        /// <summary>結果を符号なし整数として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public ulong GetUInt64(ulong def) => QiApiFuture.GetUInt64Default(this, def);

        /// <summary>結果を文字列として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public string GetString() => QiApiFuture.GetString(this);

        /// <summary>結果を<see cref="QiObject"/>として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public IQiObject GetObject() => QiApiFuture.GetObject(this);


        //NOTE: これさ、アンマネージに渡したapiCallbackがGCされて死ぬよくあるパターンでは？
        /// <summary>(動作未確認)動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        /// <param name="userData">ユーザーデータ</param>
        public void AddCallback(Action<IQiFuture, IntPtr> cb, IntPtr userData)
        {
            var apiCallback = new QiApiFutureCallback((fut, udata) => cb(new QiFuture(fut), udata));
            QiApiFuture.AddCallback(this, apiCallback, userData);
        }

        /// <summary>(動作未確認)動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        public void AddCallback(Action<IQiFuture> cb)
        {
            var apiCallback = new QiApiFutureCallback((fut, _) => cb(new QiFuture(fut)));
            QiApiFuture.AddCallback(this, apiCallback);
        }

        /// <summary>待機を行わないことを表します。</summary>
        public static int NoneTimeout { get; } = 0;
        /// <summary>無期限の待機を表します。</summary>
        public static int InfiniteTimeout { get; } = 0x7fffffff;

    }

    public class QiFuture<T> : IQiFuture<T>
    {
        public QiFuture(QiFuture future)
        {
            _future = future;
        }
        private QiFuture _future;

        public bool IsRunning => _future.IsRunning;
        public bool IsFinished => _future.IsFinished;
        public bool IsCanceled => _future.IsCanceled;
        public bool HasError => _future.HasError;
        public string ErrorMessage => _future.ErrorMessage;

        public void Wait(int timeout) => _future.Wait(timeout);
        public void Wait() => _future.Wait();
        public bool CheckHasError(int timeout) => _future.CheckHasError(timeout);
        public bool CheckHasError() => _future.CheckHasError();
        public bool CheckHasValue(int timeout) => _future.CheckHasValue(timeout);
        public bool CheckHasValue() => _future.CheckHasValue();
        public void Cancel() => _future.Cancel();
        public void AddCallback(Action cb) => _future.AddCallback(cb);

        public void AddCallback(Action<T> cb)
        {
            var apiCallback = new QiApiFutureCallback((fut, _) => cb(new QiFuture<T>(new QiFuture(fut)).Get()));
            QiApiFuture.AddCallback(_future, apiCallback);
        }

        public T Get()
        {
            if (typeof(T) == typeof(IQiObject) || typeof(T) == typeof(IQiSignal))
            {
                return (T)(_future.GetObject());
            }
            else
            {
                return _future.GetValue().Get<T>();
            }
        }
    }

    public static class QiFutureExtensions
    {
        /// <summary>
        /// <see cref="QiFuture"/>型で生成した非同期呼び出しが実際には<typeparamref name="T"/>型の
        /// 戻り値を返すことを宣言し、戻り値のある非同期呼び出しとして扱えるようにします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="future"></param>
        /// <returns></returns>
        public static QiFuture<T> WillReturns<T>(this QiFuture future) => new QiFuture<T>(future);
    }
}
