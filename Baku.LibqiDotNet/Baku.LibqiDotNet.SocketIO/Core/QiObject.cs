using System;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    public class QiObject : IQiObject
    {
        internal QiObject(QiSession session, JObject jobj)
        {
            Id = (int)jobj["pyobject"];
            JObject metaObject = jobj["metaobject"]["methods"] as JObject;
            //なんかここでメタオブジェクトをめっちゃ良い感じにする
            _methods = new QiMethods(session, this, metaObject);

            Description = (string)metaObject["description"];
            
            //TODO: Socket.IOのOnCompleted的な処理をうまく使わないとObjectの名前(ALMotionとか)は取れない            
        }

        private readonly QiMethods _methods;

        public IQiMethod this[string methodName] => _methods[methodName];

        public int Id { get; }
        public string Name => Id.ToString();
        public string Description { get; }

        #region NOT supported
        
        //NOTE: MetaObjectの様子見ないとだけど原理的にムリかもしれない領域

        public IQiFuture<T> GetProperty<T>(string pname)
        {
            throw new NotSupportedException(
                "Socket.io based session does not supports property getter/setter functionality");
        }

        public IQiFuture SetProperty(string pname, object v)
        {
            throw new NotSupportedException(
                "Socket.io based session does not supports property getter/setter functionality");
        }

        #endregion
    }
}
