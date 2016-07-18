using System;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiMethod : IQiMethod
    {
        public QiMethod(string name, QiSession session, QiObject qiobj)
        {
            Name = name;
            _session = session;
            _qiobj = qiobj;
        }

        private readonly QiSession _session;
        private readonly QiObject _qiobj;

        public string Name { get; }

        public IQiFuture CallAsync(params object[] args)
            => _session.CallAsync(_qiobj.Id, Name, args);

        public IQiFuture<T> CallAsync<T>(params object[] args)
            => _session.CallAsync(_qiobj.Id, Name, args).WillReturns<T>();
    }
}
