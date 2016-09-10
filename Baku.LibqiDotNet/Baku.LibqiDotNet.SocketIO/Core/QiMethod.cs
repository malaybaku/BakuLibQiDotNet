using System;

namespace Baku.LibqiDotNet.SocketIo
{
    /// <summary>JSONオブジェクト情報に基づくメソッドを表します。</summary>
    public class QiMethod : IQiMethod
    {
        /// <summary>メソッド名、セッション、元となるサービスインスタンスを用いてインスタンスを初期化します。</summary>
        /// <param name="name">メソッド名</param>
        /// <param name="session">通信に用いているセッション</param>
        /// <param name="qiobj">このメソッドが属するサービスインスタンス</param>
        public QiMethod(string name, QiSession session, QiObject qiobj)
        {
            Name = name;
            _session = session;
            _qiobj = qiobj;
        }

        private readonly QiSession _session;
        private readonly QiObject _qiobj;

        /// <summary>メソッド名を取得します。</summary>
        public string Name { get; }

        /// <summary>引数を与えてメソッドを非同期で呼び出します。</summary>
        /// <param name="args">メソッドの引数一覧</param>
        /// <returns>呼び出したメソッドに応じた戻り値を持つ非同期呼び出し結果</returns>
        public IQiFuture CallAsync(params object[] args)
            => _session.CallAsync(_qiobj.Id, Name, args);

        /// <summary>引数を与えてメソッドを非同期で呼び出します。</summary>
        /// <typeparam name="T">結果の型</typeparam>
        /// <param name="args">メソッドの引数一覧</param>
        /// <returns>呼び出したメソッドに応じた戻り値を持つ非同期呼び出し結果</returns>
        public IQiFuture<T> CallAsync<T>(params object[] args)
            => _session.CallAsync(_qiobj.Id, Name, args).WillReturns<T>();
    }
}
