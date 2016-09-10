using System;

namespace SocketIOClient
{
    /// <summary>エラーイベントのイベントデータを表します。</summary>
    public class ErrorEventArgs : EventArgs
	{
        /// <summary>エラーメッセージを取得します。</summary>
		public string Message { get; }
        /// <summary>発生した例外を取得します。</summary>
		public Exception Exception { get; }

        /// <summary>エラーメッセージのみを指定してインスタンスを初期化します。</summary>
        /// <param name="message">エラーメッセージ</param>
		public ErrorEventArgs (string message) :base()
		{
            Message = message;
		}
        /// <summary>エラーメッセージと例外を指定してインスタンスを初期化します。</summary>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="exception">エラー</param>
		public ErrorEventArgs (string message, Exception exception) : base()
		{
            Message = message;
            Exception = exception;
		}
	}
}
