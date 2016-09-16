using System;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary><see cref="QiFuture"/>に結果を与える遅延処理を表します。</summary>
    internal class QiPromise
    {
        internal QiPromise(QiSession routeSession)
        {
            _session = routeSession;
        }
        private readonly QiSession _session;

        /// <summary>タスクを正常終了します。</summary>
        public void Finish(JToken result)
        {
            Result = result;
            PromiseState = PromiseStates.Completed;
            OnFinished();
        }

        /// <summary>タスクを失敗終了し、エラー内容を文字列として設定します。</summary>
        /// <param name="error"></param>
        public void Fail(string error)
        {
            ErrorMessage = error ?? "";
            PromiseState = PromiseStates.Failed;
            OnFinished();
        }

        /// <summary>タスクをキャンセルします。</summary>
        public void Cancel()
        {
            PromiseState = PromiseStates.Canceled;
            OnFinished();
        }

        internal QiFuture CreateFuture() => new QiFuture(_session, this);

        internal JToken Result { get; private set; } = null;
        internal string ErrorMessage { get; private set; } = "";
        internal PromiseStates PromiseState { get; private set; } = PromiseStates.Running;

        private void OnFinished() => Finished?.Invoke(this, EventArgs.Empty);

        /// <summary>処理が成功、キャンセル、エラーのいずれかで終了すると発生します。</summary>
        public event EventHandler Finished;

        internal static QiFuture CreateFinishedFuture(QiSession session, JToken result)
        {
            var p = new QiPromise(session);
            p.Finish(result);
            return p.CreateFuture();
        }
    }

    /// <summary>Promiseの実行状態を表します。</summary>
    internal enum PromiseStates
    {
        Running,
        Completed,
        Canceled,
        Failed
    }
}
