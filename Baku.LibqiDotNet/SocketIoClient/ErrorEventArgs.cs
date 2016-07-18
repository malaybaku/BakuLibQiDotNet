using System;

namespace SocketIOClient
{
    public class ErrorEventArgs : EventArgs
	{
		public string Message { get; }
		public Exception Exception { get; }

		public ErrorEventArgs (string message) :base()
		{
            Message = message;
		}
		public ErrorEventArgs (string message, Exception exception) : base()
		{
            Message = message;
            Exception = exception;
		}
	}
}
