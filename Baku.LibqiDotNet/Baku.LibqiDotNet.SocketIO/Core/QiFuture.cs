using System;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
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

        public bool IsCanceled => _promise.PromiseState == PromiseStates.Canceled;
        public bool IsFinished => _promise.PromiseState != PromiseStates.Running;
        public bool IsRunning => _promise.PromiseState == PromiseStates.Running;
        public bool HasError => _promise.PromiseState == PromiseStates.Failed;

        public void Cancel() => _promise.Cancel();
        public void AddCallback(Action cb)
        {
            //ContinueWith的な。
            throw new NotImplementedException();
        }

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
        public void Wait() => Wait(InfiniteTimeSpan);
        public void Wait(int timeout) => Wait(TimeSpan.FromMilliseconds(timeout));

        public bool CheckHasError() => CheckHasError(InfiniteTimeSpan);
        public bool CheckHasError(int timeout) => CheckHasError(TimeSpan.FromMilliseconds(timeout));
        public bool CheckHasError(TimeSpan ts)
        {
            Wait(ts);
            return _promise.PromiseState == PromiseStates.Failed;
        }

        public bool CheckHasValue() => CheckHasValue(InfiniteTimeSpan);
        public bool CheckHasValue(int timeout) => CheckHasValue(TimeSpan.FromMilliseconds(timeout));
        public bool CheckHasValue(TimeSpan ts)
        {
            Wait(ts);
            //本来は型チェックするんだけどねえ。
            return _promise.PromiseState == PromiseStates.Completed;
        }

        public string ErrorMessage => _promise.PromiseState == PromiseStates.Failed ? _promise.ErrorMessage : "";

        //Future自体を複製する状況は滅多にないハズなので適当に。
        public IQiFuture CloneFuture() => this;

        //TODO: GetValueって非Finish時にWaitするんだっけ…？仕様を忘れてしまった。確認していただきたく。
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

        public event EventHandler Finished;

        /// <summary>無期限の待機を表します。</summary>
        public static readonly TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
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
            throw new NotImplementedException();
        }

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
