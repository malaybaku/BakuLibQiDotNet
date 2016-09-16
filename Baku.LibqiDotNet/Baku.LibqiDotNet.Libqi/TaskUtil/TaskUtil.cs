using System;

namespace Baku.LibqiDotNet.Libqi
{
    ///<summary>forgettableな非同期処理機能</summary>
    internal class TaskUtil
    {
        public TaskUtil(Action action)
        {
            Action = action;
        }

        public Action Action { get; }

        public void Start()
        {
#if NET35
            new System.Threading.Thread(() => this.Action()).Start();
#else
            System.Threading.Tasks.Task.Run(Action);
#endif
        }

        public static TaskUtil Run(Action action)
        {
            var t = new TaskUtil(action);
            t.Start();
            return t;
        }
    }
}
