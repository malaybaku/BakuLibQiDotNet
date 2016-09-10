using System;
using System.Net;
using System.Collections.Generic;

namespace System.Collections.Concurrent
{
    /// <summary>コンカレントなキューを表します。</summary>
    /// <typeparam name="T">キューに格納するアイテムの型</typeparam>
    public class ConcurrentQueue<T>
    {
        private Queue<T> m_Queue;

        private object m_SyncRoot = new object();

        /// <summary>既定の設定でインスタンスを初期化します。</summary>
        public ConcurrentQueue()
        {
            m_Queue = new Queue<T>();
        }

        /// <summary>キューの容量を指定してインスタンスを初期化します。</summary>
        /// <param name="capacity">キュー容量</param>
        public ConcurrentQueue(int capacity)
        {
            m_Queue = new Queue<T>(capacity);
        }

        /// <summary>元となるアイテムを指定してインスタンスを初期化します。</summary>
        /// <param name="collection">元となるアイテム一覧</param>
        public ConcurrentQueue(IEnumerable<T> collection)
        {
            m_Queue = new Queue<T>(collection);
        }

        /// <summary>アイテムをキューに追加します。</summary>
        /// <param name="item">追加するアイテム</param>
        public void Enqueue(T item)
        {
            lock (m_SyncRoot)
            {
                m_Queue.Enqueue(item);
            }
        }
        /// <summary>アイテム取り出しを試みます。</summary>
        /// <param name="item">取り出し結果</param>
        /// <returns>取り出しに成功したかどうか</returns>
        public bool TryDequeue(out T item)
        {
            lock (m_SyncRoot)
            {
                if (m_Queue.Count <= 0)
                {
                    item = default(T);
                    return false;
                }

                item = m_Queue.Dequeue();
                return true;
            }
        }
    }
}
