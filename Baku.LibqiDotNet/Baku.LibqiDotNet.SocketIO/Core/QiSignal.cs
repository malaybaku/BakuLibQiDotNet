using System;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>Socket.ioによる非同期イベント処理の送受信器を表します。</summary>
    public class QiSignal : IQiSignal
    {
        /// <summary>取得したJObjectと取得元セッションを用いてシグナルインスタンスを初期化します。</summary>
        /// <param name="session">データの取得元セッション</param>
        /// <param name="jobj">シグナル情報を表すJSONオブジェクト</param>
        public QiSignal(QiSession session, JObject jobj)
        {
            _session = session;
            _session.Signal += OnSessionSignal;

            Id = (int)jobj["pyobject"];
        }

        /// <summary>シグナルに対応づけられた一意な番号を取得します。</summary>
        public int Id { get; }

        /// <summary>シグナル受信時の処理を登録します。</summary>
        /// <param name="handler">受信時に呼ばれるハンドラ関数</param>
        /// <returns>登録の非同期処理状態</returns>
        public IQiFuture ConnectAsync(Action<IQiResult> handler)
        {
            if (_received == null)
            {
                _received += handler;
                return EnableSignalReceiveAsync();
            }
            else
            {
                _received += handler;
                return QiPromise.CreateFinishedFuture(_session, 0);
            }
        }

        /// <summary>シグナル受信時の処理を登録解除します。</summary>
        /// <param name="handler"><see cref="ConnectAsync(Action{IQiResult})"/>で登録したハンドラ関数</param>
        /// <returns>登録解除の非同期処理状態</returns>
        public IQiFuture DisconnectAsync(Action<IQiResult> handler)
        {
            _received -= handler;
            if (_received == null)
            {
                return DisableSignalReceiveAsync();
            }
            else
            {
                return QiPromise.CreateFinishedFuture(_session, 0);
            }
        }

        private event Action<IQiResult> _received;
       
        private void OnEnableSignalReceiveAsyncEnded(object sender, EventArgs e)
        {
            var future = sender as QiFuture;
            if (future == null) return;
            _linkId = future.GetValue().ToInt64();

            future.Finished -= OnEnableSignalReceiveAsyncEnded;
        }

        private IQiFuture EnableSignalReceiveAsync()
        {
            var future = _session.CallAsync(Id, "registerEvent", "signal") as QiFuture;

            if (future != null)
            {
                future.Finished += OnEnableSignalReceiveAsyncEnded;
                return future;
            }
            else
            {
                return QiPromise.CreateFinishedFuture(_session, 0);
            }
        }

        private IQiFuture DisableSignalReceiveAsync()
        {
            if (_linkId.HasValue)
            {
                var future = _session.CallAsync(Id, "unregisterEvent", "signal", _linkId.Value);
                _linkId = null;
                return future;
            }
            else
            {
                return QiPromise.CreateFinishedFuture(_session, 0);
            }
        }

        private readonly QiSession _session;
        private long? _linkId;

        /// <summary>シグナルに対応するSocket.IOのイベント名を取得します。</summary>
        public string SignalName => "signal";

        private void RaiseReceived(IQiResult qv) => _received?.Invoke(qv);

        private void OnSessionSignal(object sender, QiFilteredSignalEventArgs e)
        {
            if (e.Session == _session &&
                (_linkId.HasValue && e.LinkId == _linkId.Value) &&  
                e.ObjectId == Id &&
                e.SignalName == SignalName)
            {
                RaiseReceived(new QiValue(e.Data));
            }
        }
    }

}
