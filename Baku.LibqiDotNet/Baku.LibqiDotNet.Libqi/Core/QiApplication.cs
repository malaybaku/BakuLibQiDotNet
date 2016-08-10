using System;
using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
	/// <summary>アプリケーションを表します。初期化処理等を行うために用います</summary>
	public sealed class QiApplication
    {
        internal QiApplication(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>このクラスが保持しているアンマネージリソースのハンドルを解放します。</summary>
        //~QiApplication()
        //{
        //    QiApiApplication.Destroy(this);
        //}

        /// <summary>サーバとしてアプリケーションを実行します。クライアントでは呼び出しは必要ありません。</summary>
        public void Run() => QiApiApplication.Run(this);

        /// <summary>アプリケーションを停止します。</summary>
        public void Stop() => QiApiApplication.Stop(this);

        /// <summary>アプリケーションが初期化済みであるかどうかを取得します。</summary>
        public static bool IsApplicationInitialized => QiApiApplication.CheckInitialized();

        /// <summary>コマンドライン相当の入力を受けて初期化されたアプリケーションを取得します。</summary>
        /// <param name="args">コマンドラインに相当する入力。長さが0の場合<see cref="InvalidOperationException"/>が発生します。</param>
        /// <returns>初期化されたアプリケーション</returns>
        /// <exception cref="InvalidOperationException"/>
        public static QiApplication Create(string[] args)
        {
            if(args.Length == 0)
            {
                throw new InvalidOperationException("args must have element");
            }
            return QiApiApplication.Create(args);
        }

        //廃止: このやり方は.NETっぽくない。
        ///// <summary>
        ///// 既定の方法でアプリケーションを初期化します。
        ///// NOTE: この関数はコマンドライン引数の最初の引数(アプリケーション名)を自動で使用します。
        ///// </summary>
        ///// <returns>初期化されたアプリケーション</returns>
        //public static QiApplication Create()
        //    => Create(new string[] { Environment.GetCommandLineArgs()[0] });

    }


}
