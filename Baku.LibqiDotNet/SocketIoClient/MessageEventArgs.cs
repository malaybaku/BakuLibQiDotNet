using System;
using SocketIOClient.Messages;

namespace SocketIOClient
{
    /// <summary>メッセージ受信時のイベントデータを表します。</summary>
    public class MessageEventArgs : EventArgs
	{
        /// <summary>受信したメッセージを取得します。</summary>
		public IMessage Message { get; }

        /// <summary>メッセージによってインスタンスを初期化します。</summary>
        /// <param name="msg">受信したメッセージ</param>
		public MessageEventArgs(IMessage msg)
		{
            Message = msg;
		}
	}
}
