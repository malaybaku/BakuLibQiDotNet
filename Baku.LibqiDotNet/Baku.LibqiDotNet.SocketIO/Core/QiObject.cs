using System;
using Newtonsoft.Json.Linq;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>Socket.io通信に基づいたサービスオブジェクトを表します。</summary>
    public class QiObject : IQiObject
    {
        /// <summary>通信に用いたセッションとサービス内容を表すJSONオブジェクトを用いてインスタンスを初期化します。</summary>
        /// <param name="session">通信に用いたセッション</param>
        /// <param name="jobj">サービス内容を表すJSONオブジェクト</param>
        internal QiObject(QiSession session, JObject jobj)
        {
            Id = (int)jobj["pyobject"];
            JObject metaObject = jobj["metaobject"]["methods"] as JObject;
            //とりあえずメソッド一覧と概要文まで: ホントは他にも何かできたような気もする
            _methods = new QiMethods(session, this, metaObject);

            Description = (string)metaObject["description"];
            
            //TODO: Socket.IOのOnCompletedコールバック等をうまく使わないとObjectの名前(ALMotionとか)は取れない            
        }

        private readonly QiMethods _methods;

        /// <summary>メソッド名を指定して対応するメソッドを取得します。</summary>
        /// <param name="methodName">メソッド名</param>
        /// <returns>メソッド</returns>
        public IQiMethod this[string methodName] => _methods[methodName];

        /// <summary>このサービスインスタンスに対応づけられた一意な整数値を取得します。</summary>
        public int Id { get; }
        /// <summary>サービス名を取得します。実際には<see cref="Id"/>を文字列にした値を取得します。</summary>
        public string Name => Id.ToString();
        /// <summary>サービスの概要を説明した要約文を取得します。</summary>
        public string Description { get; }

        #region NOT supported
        
        //NOTE: MetaObjectの様子見ないとだけど原理的にムリかもしれない領域

        /// <summary>[NOT SUPPORTED]</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pname"></param>
        /// <returns></returns>
        public IQiFuture<T> GetProperty<T>(string pname)
        {
            throw new NotSupportedException(
                "Socket.io based session does not supports property getter/setter functionality");
        }

        /// <summary>[NOT SUPPORTED]</summary>
        /// <param name="pname"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public IQiFuture SetProperty(string pname, object v)
        {
            throw new NotSupportedException(
                "Socket.io based session does not supports property getter/setter functionality");
        }

        #endregion
    }
}
