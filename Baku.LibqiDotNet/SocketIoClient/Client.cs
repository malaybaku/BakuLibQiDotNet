using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Linq;

using SocketIOClient.Eventing;
using SocketIOClient.Messages;
using Newtonsoft.Json.Linq;
using Baku.Websocket.Client;

namespace SocketIOClient
{
    /// <summary>
    /// Class to emulate socket.io javascript client capabilities for .net classes
    /// </summary>
    /// <exception cref = "ArgumentException">Connection for wss or https urls</exception>  
    public sealed class Client : IDisposable, IClient
    {
        /// <summary>Allow one connection attempt at a time</summary>
		private readonly static object padLock = new object();

#if NET35
        private readonly Thread dequeueOutBoundMsgTask;
#else
        private readonly System.Threading.Tasks.Task dequeueOutBoundMsgTask;
#endif
        private Timer socketHeartBeatTimer;
        private ConcurrentQueue<string> outboundQueue = new ConcurrentQueue<string>();
		private int retryConnectionCount = 0;

        /// <summary>Uri of Websocket server</summary>
        private Uri _uri;
        /// <summary>WebSocket implementation</summary>
        private IWebSocket wsClient;
		/// <summary>RegistrationManager for dynamic events</summary>
		private RegistrationManager registrationManager; 
		///// <summary>By Default, use WebSocketVersion.Rfc6455</summary>
		//private WebSocketVersion socketVersion = WebSocketVersion.Rfc6455;

		// Events
		public event EventHandler Opened;
		public event EventHandler<MessageEventArgs> ReceivedMessage;
		public event EventHandler ConnectionRetry;
		public event EventHandler HeartBeatSent;
		public event EventHandler Closed;
		public event EventHandler<ErrorEventArgs> Error;

		/// <summary>ResetEvent for Outbound MessageQueue Empty Event - all pending messages have been sent</summary>
		private readonly ManualResetEvent _messageQueueEmptyEvent = new ManualResetEvent(true);

		/// <summary>Connection Open Event</summary>
		private readonly ManualResetEvent _connectionOpenEvent = new ManualResetEvent(false);


        /// <summary>
        /// Number of reconnection attempts before raising SocketConnectionClosed event - (default = 3)
        /// </summary>
        public int RetryConnectionAttempts { get; set; } = 3;

		public string LastErrorMessage { get; set; } = "";

        private string _path = "/socket.io/";
        /// <summary>Abs Path to socket.io service(default is : "/socket.io/")</summary>
        public string Path
        {
            get { return _path; }
            set
            {
                _path = (!value.StartsWith("/") ? "/" : "") + 
                    value + 
                    (!value.EndsWith("/") ? "/" : "");
            }
        }

		/// <summary>The initial handshake parameters received from the socket.io service (SID, HeartbeatTimeout etc)</summary>
		public SocketIOHandshake HandShake { get; private set; }

		/// <summary> Get if the connection is established </summary>
		public bool IsConnected => ReadyState == WebSocketState.Open;

        /// <summary> Get the connection state of websocket client (None, Connecting, Open, Closing, Closed)</summary>
        private WebSocketState ReadyState => wsClient?.State ?? WebSocketState.None;

		// Constructors
		public Client()
		{
            registrationManager = new RegistrationManager();
#if NET35
            dequeueOutBoundMsgTask = new Thread(DequeueOutboundMessages);
            dequeueOutBoundMsgTask.Start();
#else 
            this.dequeueOutBoundMsgTask = System.Threading.Tasks.Task.Run(() => DequeueOutboundMessages());
#endif
        }

		/// <summary>Initiate the connection with Socket.IO service</summary>
		public void Connect(string url, IWebSocket ws)
		{
            if (ReadyState == WebSocketState.Open)
            {
                Close();
            }
            wsClient = ws;

            _uri = new Uri(url);
			lock (padLock)
			{
                if (ReadyState == WebSocketState.Connecting || ReadyState == WebSocketState.Open)
                {
                    return;
                }

				try
				{
                    _connectionOpenEvent.Reset();
                    HandShake = RequestHandshake(_uri);// perform an initial HTTP request as a new, non-handshaken connection

					if (HandShake == null || string.IsNullOrEmpty(HandShake.SID) || HandShake.HadError)
					{
                        LastErrorMessage = $"Error initializing handshake with {_uri}";
                        OnError(this, new ErrorEventArgs(LastErrorMessage, new Exception()));
					}
					else
					{
                        string wsScheme = (_uri.Scheme == "https" ? "wss" : "ws");
                        wsClient.InitializeUrl(string.Format("{0}://{1}:{2}{3}1/websocket/{4}", wsScheme, _uri.Host, _uri.Port, Path, HandShake.SID));
                        wsClient.AllowUnstrustedCertificate = true;
                        wsClient.EnableAutoSendPing = true; // #4 tkiley: Websocket4net client library initiates a websocket heartbeat, causes delivery problems
                        wsClient.Opened += wsClient_OpenEvent;
                        wsClient.MessageReceived += wsClient_MessageReceived;
                        wsClient.Error += wsClient_Error;
                        wsClient.Closed += wsClient_Closed;

                        wsClient.Open();
					}
				}
				catch (Exception ex)
				{
                    OnError(this, new ErrorEventArgs("SocketIO.Client.Connect threw an exception", ex));
				}
			}
		}
        private void Connect()
        {
            Connect(this._uri.AbsoluteUri, this.wsClient);
        }

		private void ReConnect()
		{
            retryConnectionCount++;

            OnConnectionRetry(this, EventArgs.Empty);

            // stop the heartbeat time
            CloseHeartBeatTimer();
            // stop websocket
            CloseWebSocketClient();

            Connect();
            // block while waiting for connection
            bool connected = _connectionOpenEvent.WaitOne(4000); 
			//Trace.WriteLine($"\tRetry-Connection successful: {connected}");
			if (connected)
            {
                retryConnectionCount = 0;
            }
            else
			{	
                // we didn't connect - try again until exhausted
				if (retryConnectionCount < RetryConnectionAttempts)
				{
                    ReConnect();
				}
				else
				{
                    Close();
                    OnClosed(this, EventArgs.Empty);
				}
			}
		}
		
		/// <summary>
		/// <para>Asynchronously calls the action delegate on event message notification</para>
		/// <para>Mimicks the Socket.IO client 'socket.on('name',function(data){});' pattern</para>
		/// <para>Reserved socket.io event names available: connect, disconnect, open, close, error, retry, reconnect  </para>
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="action"></param>
		/// <example>
		/// client.On("testme", (data) =>
		///    {
		///        Debug.WriteLine(data.ToJson());
		///    });
		/// </example>
		public void On(string eventName, Action<IMessage> action)
		{
            registrationManager.AddOnEvent(eventName, action);
		}
		public void On(string eventName, string endPoint, Action<IMessage> action)
		{
            registrationManager.AddOnEvent(eventName, endPoint, action);
		}
		/// <summary>
		/// <para>Asynchronously sends payload using eventName</para>
		/// <para>payload must a string or Json Serializable</para>
		/// <para>Mimicks Socket.IO client 'socket.emit('name',payload);' pattern</para>
		/// <para>Do not use the reserved socket.io event names: connect, disconnect, open, close, error, retry, reconnect</para>
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="payload">must be a string or a Json Serializable object</param>
		/// <remarks>ArgumentOutOfRangeException will be thrown on reserved event names</remarks>
		public void Emit(string eventName, object payload, string endPoint, Action<JToken> callback)
		{
            var reservedEventNames = new string[]
            {
                "connect",
				"disconnect",
				"open",
				"close",
				"error",
				"retry",
				"reconnect"
            };

			string lceventName = eventName.ToLower();

            if (reservedEventNames.Contains(lceventName))
            {
                throw new ArgumentOutOfRangeException(eventName, "Event name is reserved by socket.io");
            }


            if (lceventName == "message")
            {
                if (payload is string)
                {
                    Send(new TextMessage() { MessageText = payload.ToString() });
                }
                else
                {
                    Send(new JSONMessage(payload));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(endPoint) && !endPoint.StartsWith("/"))
                {
                    endPoint = "/" + endPoint;
                }
                var msg = new EventMessage(eventName, payload, endPoint, callback);
                if (callback != null)
                {
                    registrationManager.AddCallBack(msg.AckId.Value, msg.Callback);
                }
                Send(msg);
			}
		}
		/// <summary>
		/// <para>Asynchronously sends payload using eventName</para>
		/// <para>payload must a string or Json Serializable</para>
		/// <para>Mimicks Socket.IO client 'socket.emit('name',payload);' pattern</para>
		/// <para>Do not use the reserved socket.io event names: connect, disconnect, open, close, error, retry, reconnect</para>
		/// </summary>
		/// <param name="eventName"></param>
		/// <param name="payload">must be a string or a Json Serializable object</param>
		public void Emit(string eventName, object payload) => Emit(eventName, payload, "", null);

        //specific for event 
        public void Emit(string eventName, JObject payload)
        {
            var msg = new EventMessage(
                eventName,
                new JObject(
                    new JProperty("name", eventName),
                    new JProperty("args", new JArray(new object[] { payload }))
                    )
                );
            Send(msg);
        }

		/// <summary>
		/// Queue outbound message
		/// </summary>
		/// <param name="msg"></param>
		public void Send(IMessage msg)
		{
            _messageQueueEmptyEvent.Reset();
            outboundQueue?.Enqueue(msg.Encoded);
        }		
		public void Send(string msg) => Send(new TextMessage() { MessageText = msg });

		/// <summary>
		/// if a registerd event name is found, don't raise the more generic Message event
		/// </summary>
		/// <param name="msg"></param>
		private void OnMessageEvent(IMessage msg)
		{
			bool skip = false;
			if (!string.IsNullOrEmpty(msg.Event))
            {
                skip = registrationManager.InvokeOnEvent(msg);
            }

            if(!skip)
            {
                ReceivedMessage?.Invoke(this, new MessageEventArgs(msg));
			}
		}
		
		/// <summary>Close SocketIO4Net.Client and clear all event registrations </summary>
		public void Close()
		{
            // reset for next connection cycle
            retryConnectionCount = 0; 

            // stop the heartbeat time
            CloseHeartBeatTimer();

            // stop outbound messages
            CloseOutboundQueue();
            CloseWebSocketClient();

			if (registrationManager != null)
			{
                registrationManager.Dispose();
                registrationManager = null;
			}

		}

		private void CloseHeartBeatTimer()
		{
			// stop the heartbeat timer
			if (socketHeartBeatTimer != null)
			{
                //socketHeartBeatTimer.Change(Timeout.Infinite, Timeout.Infinite);
                socketHeartBeatTimer.Dispose();
                socketHeartBeatTimer = null;
			}
		}
		private void CloseOutboundQueue()
		{
			// stop outbound messages
			if (outboundQueue != null)
			{
                //outboundQueue.TryDequeue(); // stop adding any more items;
                //dequeueOutBoundMsgTask.Wait(700); // wait for dequeue thread to stop
                //outboundQueue = n
                outboundQueue = null;
			}
		}
		private void CloseWebSocketClient()
		{
			if (wsClient != null)
			{
                // unwire events
                wsClient.Closed -= wsClient_Closed;
                wsClient.MessageReceived -= wsClient_MessageReceived;
                wsClient.Error -= wsClient_Error;
                wsClient.Opened -= wsClient_OpenEvent;

				if (wsClient.State == WebSocketState.Connecting || wsClient.State == WebSocketState.Open)
				{
					try
                    {
                        wsClient.Close();
                    }
					catch
                    {
                        //Trace.WriteLine("exception raised trying to close websocket: can safely ignore, socket is being closed");
                    }
				}
                wsClient = null;
			}
		}

		// websocket client events - open, messages, errors, closing
		private void wsClient_OpenEvent(object sender, EventArgs e)
		{
#if NET35
            socketHeartBeatTimer = new System.Threading.Timer(
                OnHeartBeatTimerCallback, new object(),
                (int)HandShake.HeartbeatInterval.TotalMilliseconds,
                (int)HandShake.HeartbeatInterval.TotalMilliseconds
                );
#else
            socketHeartBeatTimer = new Timer(
                OnHeartBeatTimerCallback, new object(), 
                (int)HandShake.HeartbeatInterval.TotalMilliseconds, 
                (int)HandShake.HeartbeatInterval.TotalMilliseconds
                );
#endif

            _connectionOpenEvent.Set();

            OnMessageEvent(new EventMessage() { Event = "open" });
            Opened?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Raw websocket messages from server - convert to message types and call subscribers of events and/or callbacks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wsClient_MessageReceived(object sender, WebSocketMessageReceivedEventArgs e)
		{
			IMessage iMsg = Message.Factory(e.Message);

            switch (iMsg.MessageType)
			{
				case SocketIOMessageTypes.Disconnect:
                    OnMessageEvent(iMsg);
                    if (string.IsNullOrEmpty(iMsg.Endpoint))
                    {
                        // Disconnect the whole socket
                        Close();
                    }
					break;
				case SocketIOMessageTypes.Heartbeat:
                    OnHeartBeatTimerCallback(null);
					break;
				case SocketIOMessageTypes.Connect:
				case SocketIOMessageTypes.Message:
				case SocketIOMessageTypes.JSONMessage:
				case SocketIOMessageTypes.Event:
				case SocketIOMessageTypes.Error:
                    OnMessageEvent(iMsg);
					break;
				case SocketIOMessageTypes.ACK:
                    registrationManager.InvokeCallBack(iMsg.AckId, iMsg.MessageText);
					break;
				default:
					//Trace.WriteLine("unknown wsClient message Received...");
					break;
			}
		}

		/// <summary>
		/// websocket has closed unexpectedly - retry connection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void wsClient_Closed(object sender, EventArgs e)
		{
			if (retryConnectionCount < RetryConnectionAttempts)
			{
                _connectionOpenEvent.Reset();
                ReConnect();
			}
			else
			{
                Close();
                OnClosed(this, EventArgs.Empty);
			}
		}

		private void wsClient_Error(object sender, WebSocketErrorEventArgs e)
		{
            OnError(sender, new ErrorEventArgs("SocketClient error", e.Exception));
		}

		private void OnError(object sender, ErrorEventArgs e)
		{
            LastErrorMessage = e.Message;
            Error?.Invoke(this, e);
		}
		private void OnClosed(object sender, EventArgs e)
            => Closed?.Invoke(sender, e);

        private void OnConnectionRetry(object sender, EventArgs e)
            => ConnectionRetry?.Invoke(sender, e);

		// Housekeeping
		private void OnHeartBeatTimerCallback(object state)
		{
            if (!IsConnected)
            {
                return;
            }

			if (outboundQueue != null)
			{
                outboundQueue.Enqueue(Heartbeat.Instance.Encoded);
                //HeartBeatSent?.BeginInvoke(this, EventArgs.Empty, EndAsyncEvent, null);
                HeartBeatSent?.Invoke(this, EventArgs.Empty);
			}
		}
		//private void EndAsyncEvent(IAsyncResult result)
		//{
		//	try
		//	{
  //              var ar = (System.Runtime.Remoting.Messaging.AsyncResult)result;
  //              (ar.AsyncDelegate as EventHandler)?.EndInvoke(result);
		//	}
		//	catch
		//	{
		//		// Handle any exceptions that were thrown by the invoked method
		//		//Trace.WriteLine("An event listener went kaboom!");
		//	}
		//}

		/// <summary>While connection is open, dequeue and send messages to the socket server</summary>
		private void DequeueOutboundMessages()
		{
			while (outboundQueue != null)
			{
				if (IsConnected)
				{
					try
					{
                        string msgString = "";
                        if (outboundQueue.TryDequeue(out msgString))
						{
                            if (!string.IsNullOrEmpty(msgString))
                            {
                                wsClient.Send(msgString);
                            }
                            else
                            {
                                wsClient.Send(msgString);
                            }
                        }
						else
                        {
                            _messageQueueEmptyEvent.Set();
                        }
                    }
					catch(Exception)
					{
						//Trace.WriteLine("The outboundQueue is no longer open...");
					}
				}
				else
                {
                    // wait for connection event
                    _connectionOpenEvent.WaitOne(2000);
				}
			}
		}

		/// <summary>
		/// <para>Client performs an initial HTTP POST to obtain a SessionId (sid) assigned to a client, followed
		///  by the heartbeat timeout, connection closing timeout, and the list of supported transports.</para>
		/// <para>The tansport and sid are required as part of the ws: transport connection</para>
		/// </summary>
		/// <param name="uri">http://localhost:3000</param>
		/// <returns>Handshake object with sid value</returns>
		/// <example>DownloadString: 13052140081337757257:15:25:websocket,htmlfile,xhr-polling,jsonp-polling</example>
		private SocketIOHandshake RequestHandshake(Uri uri)
		{
            try
            {
                string targetUrl = string.Format("{0}://{1}:{2}{3}1/{4}", uri.Scheme, uri.Host, uri.Port, Path, uri.Query);

#if NET35
                using (var client = new System.Net.WebClient())
                {
                    string value = client.DownloadString(targetUrl);
#else
                using (var client = new System.Net.Http.HttpClient())
                {
                    string value = client.GetStringAsync(targetUrl).Result;
#endif
                    // 13052140081337757257:15:25:websocket,htmlfile,xhr-polling,jsonp-polling
                    return string.IsNullOrEmpty(value) ?
                        new SocketIOHandshake() { ErrorMessage = "Did not receive handshake string from server" } :
                        SocketIOHandshake.LoadFromString(value);
                }
            }
            catch (Exception ex)
            {
                return new SocketIOHandshake()
                {
                    ErrorMessage = "Error getting handsake from Socket.IO host instance: " + ex.Message
                };
            }
        }

        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		// The bulk of the clean-up code 
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
                Close();
#if NET35
                _messageQueueEmptyEvent.Close();
                _connectionOpenEvent.Close();
#else
                _messageQueueEmptyEvent.Dispose();
                _connectionOpenEvent.Dispose();
#endif
            }

        }
	}


}
