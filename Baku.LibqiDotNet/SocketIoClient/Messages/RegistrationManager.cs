using System;
using System.Collections.Generic;
using SocketIOClient.Messages;
using Newtonsoft.Json.Linq;

namespace SocketIOClient.Eventing
{
    public sealed class RegistrationManager : IDisposable
	{
		public RegistrationManager()
		{
            //do nothing.
		}
		
		public void AddCallBack(int ackId, Action<JToken> callback)
            => _ackCallBacks.Add(ackId, callback);

        public void InvokeCallBack(int? ackId, string value)
        {
            if (ackId.HasValue && _ackCallBacks.ContainsKey(ackId.Value))
            {
                Action<JToken> target = _ackCallBacks[ackId.Value];
                target.BeginInvoke(value, target.EndInvoke, null);
                _ackCallBacks.Remove(ackId.Value);
            }
        }

        public void AddOnEvent(string eventName, Action<IMessage> callback)
            => _eventCallbacks.Add(eventName, callback);

        public void AddOnEvent(string eventName, string endPoint, Action<IMessage> callback)
        {
            if (string.IsNullOrEmpty(endPoint))
            {
                AddOnEvent(eventName, callback);
            }
            else
            {
                AddOnEvent($"{eventName}::{endPoint}", callback);
            }
        }

        /// <summary>If eventName is found, Executes Action delegate<typeparamref name="T"/> asynchronously</summary>
        public bool InvokeOnEvent(IMessage value)
		{
            string eventName = string.IsNullOrEmpty(value.Endpoint) ?
                value.Event :
                $"{value.Event}::{value.Endpoint}";

            if (_eventCallbacks.ContainsKey(eventName))
            {
                _eventCallbacks[eventName].Invoke(value);
                return true;
            }
            else
            {
                return false;
            }
        }

		public void Dispose()
		{
            _ackCallBacks.Clear();
            _eventCallbacks.Clear();
            GC.SuppressFinalize(this);
		}

        private readonly Dictionary<int, Action<JToken>> _ackCallBacks = new Dictionary<int, Action<JToken>>();

        private readonly Dictionary<string, Action<IMessage>> _eventCallbacks = new Dictionary<string, Action<IMessage>>();
    }
}
