using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using SocketIOClient;
using SocketIOClient.Messages;
using System.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiSession : IQiSession
    {
        private Client Socket { get; set; }

        internal QiFuture EmitAndReceiveFuture(string eventName, JObject data, uint id)
        {
            Socket.Emit(eventName, data);

            var promise = new QiPromise(this);
            _sentPromise[id] = promise;

            return promise.CreateFuture();
        }

        public static readonly int DefaultPortNumber = 8002;

        public IQiFuture ConnectAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentException();

            if (_connectionPromise != null) throw new InvalidOperationException("now connecting!");

            Close();
            _connectionPromise = new QiPromise(this);

            Task.Run(() =>
            {
                Socket = new Client(address);
                Socket.Path = "/1.0/";
                Socket.ReceivedMessage += OnReceiveMessage;
                Socket.On("reply", OnReply);
                Socket.On("error", OnError);
                Socket.On("signal", OnSignal);
                Socket.On("disconnect", OnDisconnect);
                Socket.Connect();
            });
            return _connectionPromise.CreateFuture();
        }

        public void Close()
        {
            IsConnected = false;
            Socket?.Close();
        }

        public IQiResult GetEndpoints()
        {
            //NOTE: そも、socket.ioの方法でEndPoint見れるかどうかから検証する必要があることに注意
            throw new NotImplementedException();
        }

        public IQiFuture<IQiObject> GetServiceAsync(string name)
        {
            var p = new QiPromise(this);

            if (Socket?.IsConnected != true)
            {
                p.Fail("Not Connected");
                return p.CreateFuture().WillReturns<IQiObject>();
            }

            //JSの場合はこれもメソッド呼び出しと厳格に同じような構成で動く
            return CallAsync("ServiceDirectory", "service", name).WillReturns<IQiObject>();
        }

        public bool IsConnected { get; private set; } //=> Socket.IsConnected;

        #region NOT Supported
        public IQiFuture ListenAsync(string address, bool standAlone)
        {
            throw new NotSupportedException("Socket.io based session does not supports service registration functionality");
        }

        public IQiFuture<uint> RegisterServiceAsync(string name, IQiObject obj)
        {
            throw new NotSupportedException("Socket.io based session does not supports service registration functionality");
        }

        public IQiFuture UnregisterServiceAsync(uint idx)
        {
            throw new NotSupportedException("Socket.io based session does not supports service registration functionality");
        }
        #endregion


        private QiPromise _connectionPromise = null;

        private void OnReceiveMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.MessageType == SocketIOMessageTypes.Connect)
            {
                IsConnected = true;
                if (_connectionPromise != null)
                {
                    _connectionPromise.Finish(null);
                    _connectionPromise = null;
                }
            }
            else if (e.Message.MessageType == SocketIOMessageTypes.Disconnect)
            {
                IsConnected = false;
            }
        }

        private readonly Dictionary<uint, QiPromise> _sentPromise 
            = new Dictionary<uint, QiPromise>();

        private readonly Dictionary<string, Dictionary<string, QiSignal>> _signals
            = new Dictionary<string, Dictionary<string, QiSignal>>();

        private object _generateIdLock = new object();
        private uint _id = 0;
        private uint GenerateId()
        {
            lock (_generateIdLock)
            {
                _id++;
                return _id;
            }
        }

        //objNameOdIdにはstringかintっぽいのを渡す
        internal QiFuture CallAsync(object objNameOrId, string methodName, params object[] args)
        {
            uint id = GenerateId();
            return EmitAndReceiveFuture(
                "call",
                new JObject(
                    new JProperty("idm", id),
                    new JProperty("params", new JObject(
                        new JProperty("obj", objNameOrId),
                        new JProperty("method", methodName),
                        new JProperty("args", new JArray(args.Select(a => JToken.FromObject(a))))
                        ))
                    ),
                id);
        }

        internal event EventHandler<QiFilteredSignalEventArgs> Signal;

        #region private

        private void OnReply(IMessage data)
        {
            if(data.MessageType != SocketIOMessageTypes.Event)
            {
                return;
            }

            JObject jobj = (data as EventMessage)?.Args;
            if (jobj == null)
            {
                return;
            }

            uint id = (uint)jobj["idm"];
            if (!_sentPromise.ContainsKey(id))
            {
                return;
            }
            _sentPromise[id].Finish(jobj["result"]);
            _sentPromise.Remove(id);
        }

        private void OnError(IMessage data)
        {
            var jobj = JObject.Parse((data as JSONMessage)?.MessageText ?? "");
            if (jobj == null) return;

            uint id = (uint)jobj["idm"];

            if (_sentPromise.ContainsKey(id))
            {
                string errorMessage = (string)jobj["resuilt"];
                _sentPromise[id].Fail(errorMessage);
                _sentPromise.Remove(id);
            }
        }

        private void OnSignal(IMessage data)
        {
            JObject jobj = (data as EventMessage)?.Args;
            if (jobj == null)
            {
                return;
            }

            var res = jobj["result"];
            Signal?.Invoke(this, new QiFilteredSignalEventArgs(
                this,
                (long)res["link"],
                (JArray)res["data"],
                (string)res["signal"],
                (int)res["obj"]
                ));
        }

        private void OnDisconnect(IMessage data)
        {
            foreach (var p in _sentPromise.Values)
            {
                p.Fail("disconnected");
            }
            _sentPromise.Clear();
        }

        #endregion
    }
}
