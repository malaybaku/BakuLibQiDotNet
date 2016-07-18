using Newtonsoft.Json.Linq;
using System;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiSignal : IQiSignal
    {
        public QiSignal(QiSession session, JObject jobj)
        {
            _session = session;
            _session.Signal += OnSessionSignal;

            Id = (int)jobj["pyobject"];
        }

        public int Id { get; }

        private event EventHandler<QiSignalEventArgs> _received;
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
