using System;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>Socket.io通信に基づく非同期呼び出し値を表します。</summary>
    public class QiFuture : IQiFuture
    {
        internal QiFuture(QiSession routedSession, QiPromise promise)
        {
            _session = routedSession;
            _promise = promise;
            _promise.Finished += (_, __) =>
            {
                _rawResult = promise.Result;
                Finished?.Invoke(this, EventArgs.Empty);
            };
        }

        private readonly QiSession _session;
        private readonly QiPromise _promise;
        private JToken _rawResult = null;

        /// <summary>処理がキャンセル済みであるかを取得します。</summary>
        public bool IsCanceled => _promise.PromiseState == PromiseStates.Canceled;
        /// <summary>処理が終了済であるかを取得します。</summary>
        public bool IsFinished => _promise.PromiseState != PromiseStates.Running;
        /// <summary>処理が実行中であるかを取得します。</summary>
        public bool IsRunning => _promise.PromiseState == PromiseStates.Running;
        /// <summary>エラーが起きたことが確定した場合<see langword="true"/>となります。処理自体が終了していない場合の値は未定義です。</summary>
        public bool HasError => _promise.PromiseState == PromiseStates.Failed;

        /// <summary>結果取得をキャンセルします。</summary>
        public void Cancel() => _promise.Cancel();
        /// <summary>動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        public void AddCallback(Action cb)
        {
            //ContinueWith的な。
            throw new NotImplementedException();
        }

        /// <summary>指定した時間処理の完了を待機します。</summary>
        /// <param name="ts">待機する時間</param>
        public void Wait(TimeSpan ts)
        {
            if (IsFinished) return;

            var cts = new CancellationTokenSource();
            EventHandler onFinish = (_, e) => cts?.Cancel();
            Finished += onFinish;
            //もう一回判定する(マルチスレッド対策っぽく。より真剣にやるならlock使う)
            if (!IsFinished)
            {
                cts.Token.WaitHandle.WaitOne(InfiniteTimeSpan);
            }
            Finished -= onFinish;
        }
        /// <summary>無期限に待機します。</summary>
        public void Wait() => Wait(InfiniteTimeSpan);
        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        public void Wait(int timeout) => Wait(TimeSpan.FromMilliseconds(timeout));

        /// <summary>エラーが起きたかどうかを無期限待機ののち確認します。</summary>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError() => CheckHasError(InfiniteTimeSpan);
        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError(int timeout) => CheckHasError(TimeSpan.FromMilliseconds(timeout));
        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="ts">待機時間</param>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError(TimeSpan ts)
        {
            Wait(ts);
            return _promise.PromiseState == PromiseStates.Failed;
        }

        /// <summary>値を持っているかどうかを無期限待機ののち確認します。</summary>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue() => CheckHasValue(InfiniteTimeSpan);
        /// <summary>値を持っているかどうかを待機ののち確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue(int timeout) => CheckHasValue(TimeSpan.FromMilliseconds(timeout));
        /// <summary>値を持っているかどうかを待機ののち確認します。</summary>
        /// <param name="ts">待機時間の上限</param>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue(TimeSpan ts)
        {
            Wait(ts);
            //本来は型チェックするんだけどねえ。
            return _promise.PromiseState == PromiseStates.Completed;
        }

        /// <summary>エラーがある場合、それを文字列として取得します。</summary>
        public string ErrorMessage => _promise.PromiseState == PromiseStates.Failed ? _promise.ErrorMessage : "";

        //Future自体を複製する状況は滅多にないハズなので適当に。
        /// <summary>
        /// 非同期呼び出し値の複製に相当する値を得ます。
        /// 実際にはこのオブjヘクト自身への参照を返します。
        /// </summary>
        /// <returns>このインスタンスそのもの</returns>
        public IQiFuture CloneFuture() => this;

        //TODO: GetValueって非Finish時にWaitするんだっけ…？仕様を忘れてしまった。確認していただきたく。
        /// <summary>非同期処理が完了済みであれば値を取得します。
        /// 完了前の場合は<see cref="InvalidOperationException"/>をスローします。
        /// </summary>
        /// <returns>非同期処理の結果</returns>
        /// <exception cref="InvalidOperationException" /> 
        public IQiResult GetValue()
        {
            if (IsFinished && _rawResult != null)
            {
                return new QiValue(_rawResult);
            }
            else
            {
                throw new InvalidOperationException("This QiFuture's result is void");
            }
        }
        /// <summary>オブジェクト値を取得します。
        /// 非同期処理が完了する前に呼び出した場合<see cref="InvalidOperationException"/>をスローします。
        /// </summary>
        /// <returns>オブジェクト値</returns>
        /// <exception cref="InvalidOperationException" />
        public IQiObject GetObject()
        {
            if (!IsFinished)
            {
                Wait();
            }

            if (_rawResult is JObject)
            {
                return new QiObject(_session, _rawResult as JObject);
            }
            else
            {
                throw new InvalidOperationException("This QiFuture's result type is not IQiObject");
            }

        }

        /// <summary>シグナル値を取得します。
        /// 非同期処理が完了する前に呼び出した場合<see cref="InvalidOperationException"/>をスローします。
        /// </summary>
        /// <returns>シグナル値</returns>
        /// <exception cref="InvalidOperationException" />
        public IQiSignal GetSignal()
        {
            if (!IsFinished)
            {
                Wait();
            }

            if (_rawResult is JObject)
            {
                return new QiSignal(_session, _rawResult as JObject);
            }
            else
            {
                throw new InvalidOperationException("This QiFuture's result type is not IQiSignal");
            }
        }

        /// <summary>処理が完了すると発生します。</summary>
        public event EventHandler Finished;

        /// <summary>無期限の待機を表します。</summary>
        public static readonly TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
    }

    /// <summary><see cref="QiFuture"/>のうち戻り値の型が明示されたものを表します。</summary>
    /// <typeparam name="T">非同期呼び出しの戻り値として想定されるデータ型</typeparam>
    public class QiFuture<T> : IQiFuture<T>
    {
        /// <summary>元となる<see cref="QiFuture"/>値を指定してインスタンスを初期化します。</summary>
        /// <param name="future">元となる非同期呼び出しのデータ</param>
        public QiFuture(QiFuture future)
        {
            _future = future;
        }
        private QiFuture _future;

        /// <summary>処理が実行中であるかを取得します。</summary>
        public bool IsRunning => _future.IsRunning;
        /// <summary>処理が終了済であるかを取得します。</summary>
        public bool IsFinished => _future.IsFinished;
        /// <summary>処理がキャンセル済みであるかを取得します。</summary>
        public bool IsCanceled => _future.IsCanceled;
        /// <summary>エラーが起きたことが確定した場合<see langword="true"/>となります。処理自体が終了していない場合の値は未定義です。</summary>
        public bool HasError => _future.HasError;
        /// <summary>エラーがある場合、それを文字列として取得します。</summary>
        public string ErrorMessage => _future.ErrorMessage;

        /// <summary>指定した時間まで待機します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        public void Wait(int timeout) => _future.Wait(timeout);
        /// <summary>無期限に待機します。</summary>
        public void Wait() => _future.Wait();
        /// <summary>エラーが起きたかどうかを待機しつつ確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError(int timeout) => _future.CheckHasError(timeout);
        /// <summary>エラーが起きたかどうかを無期限待機ののち確認します。</summary>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError() => _future.CheckHasError();
        /// <summary>値を持っているかどうかを待機ののち確認します。</summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue(int timeout) => _future.CheckHasValue(timeout);
        /// <summary>値を持っているかどうかを無期限待機ののち確認します。</summary>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue() => _future.CheckHasValue();
        /// <summary>結果取得をキャンセルします。</summary>
        public void Cancel() => _future.Cancel();
        /// <summary>動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        public void AddCallback(Action cb) => _future.AddCallback(cb);

        /// <summary>動作完了時のコールバック関数を登録します。</summary>
        /// <param name="cb">コールバック関数</param>
        public void AddCallback(Action<T> cb)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 呼び出し結果を取得します。
        /// 型<typeparamref name="T"/>が実際の戻り値と食い違っていたり
        /// <see cref="IQiFuture.IsFinished"/>が<see langword="false"/>場合に呼び出すと
        /// 例外が送出される可能性があります。
        /// </summary>
        /// <returns>呼び出し結果</returns>
        public T Get()
        {
            if (typeof(T) == typeof(IQiObject))
            {
                return (T)(_future.GetObject());
            }
            else if (typeof(T) == typeof(IQiSignal))
            {
                return (T)(_future.GetSignal());
            }
            else
            {
                return _future.GetValue().Get<T>();
            }
        }
    }

    /// <summary>><see cref="QiFuture"/>クラスへ拡張機能を提供します。</summary>
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
