using System;
using System.Collections.Generic;
using SocketIOClient.Messages;
using Newtonsoft.Json.Linq;

namespace SocketIOClient.Eventing
{
    /// <summary>Socket.IOのメッセージコールバック処理器を表します。</summary>
    public sealed class RegistrationManager : IDisposable
	{
        /// <summary>既定の状態にインスタンスを初期化します。</summary>
		public RegistrationManager()
		{
            //do nothing.
		}
		
        /// <summary>IDとコールバック関数を登録します。</summary>
        /// <param name="ackId">ACK ID</param>
        /// <param name="callback">IDに対応するコールバック処理</param>
		public void AddCallBack(int ackId, Action<JToken> callback)
            => _ackCallBacks.Add(ackId, callback);

        /// <summary>IDとメッセージに基づいてコールバックを呼び出します。</summary>
        /// <param name="ackId">ACK ID</param>
        /// <param name="value">メッセージ</param>
        public void InvokeCallBack(int? ackId, string value)
        {
            if (ackId.HasValue && _ackCallBacks.ContainsKey(ackId.Value))
            {
                Action<JToken> target = _ackCallBacks[ackId.Value];
                target.BeginInvoke(value, target.EndInvoke, null);
                _ackCallBacks.Remove(ackId.Value);
            }
        }

        /// <summary>イベントコールバックを登録します。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="callback">コールバック関数</param>
        public void AddOnEvent(string eventName, Action<IMessage> callback)
            => _eventCallbacks.Add(eventName, callback);

        /// <summary>イベントコールバックを登録します。</summary>
        /// <param name="eventName">イベント名</param>
        /// <param name="endPoint">エンドポイント名</param>
        /// <param name="callback">コールバック関数</param>
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

        /// <summary>イベントメッセージの受信時、必要ならコールバック処理を呼び出します。</summary>
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

        /// <summary>コールバック登録を解除し、リソースを解放します。</summary>
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
