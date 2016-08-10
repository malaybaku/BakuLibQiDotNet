//using Newtonsoft.Json.Linq;
//using System;
//using System.Linq;

//namespace SocketIOClient
//{
//    class EndPointClient : IEndPointClient
//	{
//		public IClient Client { get; }
//		public string EndPoint { get; }

//		public EndPointClient(IClient client, string endPoint)
//		{
//            ValidateNameSpace(endPoint);
//            Client = client;
//            EndPoint = endPoint;
//		}

//		public void On(string eventName, Action<Messages.IMessage> action)
//            => Client.On(eventName, EndPoint, action);

//		public void Emit(string eventName, object payload, Action<JToken> callBack )
//            => Client.Emit(eventName, payload, EndPoint, callBack);

//		public void Send(Messages.IMessage msg)
//		{
//			msg.Endpoint = EndPoint;
//            Client.Send(msg);
//		}

//        private void ValidateNameSpace(string name)
//        {
//            if (string.IsNullOrEmpty(name))
//            {
//                throw new ArgumentNullException("nameSpace", "Parameter cannot be null");
//            }
//            if (name.Contains(':'))
//            {
//                throw new ArgumentException("Parameter cannot contain ':' characters", "nameSpace");
//            }
//        }
//    }
//}
