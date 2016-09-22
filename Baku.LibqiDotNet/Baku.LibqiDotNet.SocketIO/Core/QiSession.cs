using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using SocketIOClient;
using SocketIOClient.Messages;
using Baku.Websocket.Client;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>Socket.ioを利用するセッションを表します。</summary>
    public class QiSession : IQiSession
    {
        /// <summary>通信に用いるWebSocketを用いてインスタンスを初期化します。</summary>
        /// <param name="ws">通信に使用するWebSocket</param>
        public QiSession(IWebSocket ws)
        {
            _ws = ws;                 
        }

        private readonly IWebSocket _ws;

        private IClient Socket { get; set; }


        internal QiFuture EmitAndReceiveFuture(string eventName, JObject data, uint id)
        {
            Socket.Emit(eventName, data);

            var promise = new QiPromise(this);
            _sentPromise[id] = promise;

            return promise.CreateFuture();
        }

        /// <summary>Socket.ioで通信する場合のポート番号のデフォルト値です。</summary>
        public static readonly int DefaultPortNumber = 8002;

        /// <summary>接続先に接続します。</summary>
        /// <param name="address">接続先アドレス</param>
        /// <returns>接続の非同期処理を表す値</returns>
        public IQiFuture ConnectAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentException();

            if (_connectionPromise != null) throw new InvalidOperationException("now connecting!");

            Close();
            _connectionPromise = new QiPromise(this);

            Task.Run(() =>
            {
                Socket = new Client();
                Socket.Path = "/1.0/";
                Socket.ReceivedMessage += OnReceiveMessage;
                Socket.On("reply", OnReply);
                Socket.On("error", OnError);
                Socket.On("signal", OnSignal);
                Socket.On("disconnect", OnDisconnect);
                Socket.Connect(address, _ws);
            });

            return _connectionPromise.CreateFuture();
        }

        /// <summary>接続先と切断します。</summary>
        public void Close()
        {
            IsConnected = false;
            Socket?.Close();
        }

        /// <summary>
        /// この実装ではGetEndPoints関数はサポートされていません。
        /// 常に<see cref="NotImplementedException"/>をスローします。
        /// </summary>
        /// <returns>結果は取得できません。</returns>
        public IQiResult GetEndpoints()
        {
            //NOTE: そも、socket.ioの方法でEndPoint見れるかどうかから検証する必要があることに注意
            throw new NotImplementedException();
        }

        /// <summary>サービス名を指定してサービスを非同期で取得します。</summary>
        /// <param name="name">サービス名</param>
        /// <returns>指定した名前のサービス</returns>
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

        /// <summary>セッションが接続済みかを取得します。</summary>
        public bool IsConnected { get; private set; } //=> Socket.IsConnected;
        
        /// <summary>
        /// サービスの登録/登録解除が可能かを取得します。この実装ではつねに<see langword="false"/>を返します。
        /// </summary>
        public bool IsServiceRegistrationSupported { get; } = false;

        #region NOT Supported
        /// <summary>[NOT SUPPORTED]</summary>
        /// <param name="address"></param>
        /// <param name="standAlone"></param>
        /// <returns></returns>
        public IQiFuture ListenAsync(string address, bool standAlone)
        {
            throw new NotSupportedException("Socket.io based session does not supports service registration functionality");
        }

        /// <summary>[NOT SUPPORTED]</summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IQiFuture<uint> RegisterServiceAsync(string name, IQiObject obj)
        {
            throw new NotSupportedException("Socket.io based session does not supports service registration functionality");
        }

        /// <summary>[NOT SUPPORTED]</summary>
        /// <param name="idx"></param>
        /// <returns></returns>
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
            //var jobj = JObject.Parse((data as JSONMessage)?.MessageText ?? "");
            var jobj = JObject.Parse((data as EventMessage)?.MessageText ?? "{}");
            if (jobj == null) return;
            var args = jobj["args"] as JObject;
            if (args == null) return;

            uint id = (uint)args["idm"];

            if (_sentPromise.ContainsKey(id))
            {
                string errorMessage = (string)args["result"];
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
