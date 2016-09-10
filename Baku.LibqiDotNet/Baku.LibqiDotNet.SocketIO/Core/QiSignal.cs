using Newtonsoft.Json.Linq;
using System;

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

        private event EventHandler<QiSignalEventArgs> _received;
        /// <summary>イベントを受信すると発生します。</summary>
        public event EventHandler<QiSignalEventArgs> Received
        {
            add
            {
                if (_received == null)
                {
                    ConnectAsync();
                }
                _received += value;
            }
            remove
            {
                _received -= value;
                if (_received == null)
                {
                    DisconnectAsync();
                }
            }
        }

       
        private void OnConnectAsyncEnded(object sender, EventArgs e)
        {
            var future = sender as QiFuture;
            if (future == null) return;
            _linkId = future.GetValue().ToInt64();

            future.Finished -= OnConnectAsyncEnded;
        }

        private void ConnectAsync()
        {
            var future = _session.CallAsync(Id, "registerEvent", "signal") as QiFuture;

            if (future != null)
            {
                future.Finished += OnConnectAsyncEnded;
            }
        }

        private void DisconnectAsync()
        {
            if (_linkId.HasValue)
            {
                _session.CallAsync(Id, "unregisterEvent", "signal", _linkId.Value);
                _linkId = null;
            }
        }

        private readonly QiSession _session;
        private long? _linkId;

        /// <summary>シグナルに対応するSocket.IOのイベント名を取得します。</summary>
        public string SignalName => "signal";

        private void RaiseReceived(IQiResult qv) => _received?.Invoke(this, new QiSignalEventArgs(qv));

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
