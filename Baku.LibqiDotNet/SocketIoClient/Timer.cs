using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocketIOClient
{

    /// <summary>定期的に処理を実行するタイマーを表します。</summary>
    public class Timer : IDisposable
    {
        /// <summary>
        /// 処理内容と処理感覚でタイマーを初期化します。
        /// </summary>
        /// <param name="action">実行するアクション</param>
        /// <param name="state">継続アクションによって使用されるデータを表すオブジェクト</param>
        /// <param name="dueTime">最初の実行までに遅延する時間（ミリ秒）</param>
        /// <param name="period">アクションを実行する間隔（ミリ秒）</param>
        public Timer(Action<object> action, object state, int dueTime, int period)
        {
            _cts = new CancellationTokenSource();
            Task.Delay(dueTime, _cts.Token).ContinueWith(
            async (t, s) =>
            {
                var tuple = (Tuple<Action<object>, object>)s;

                while (!_cts.IsCancellationRequested)
                {
                    await Task.Run(() => tuple.Item1(tuple.Item2), _cts.Token);
                    await Task.Delay(period);
                }
            },
            Tuple.Create(action, state),
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
            TaskScheduler.Default);
        }

        private readonly CancellationTokenSource _cts;

        /// <summary>タイマーによる周期処理を停止します。</summary>
        public void Dispose() => _cts?.Cancel();
    }
}
