using System;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    internal class QiFilteredSignalEventArgs : EventArgs
    {
        public QiFilteredSignalEventArgs(QiSession session, long linkId, JArray data, string sigName, int objId)
        {
            Session = session;

            LinkId = linkId;
            Data = data;
            SignalName = sigName;
            ObjectId = objId;
        }

        public QiSession Session { get; }

        public long LinkId { get; }
        public JArray Data { get; }
        public string SignalName { get; }
        public int ObjectId { get; }
    }
}
