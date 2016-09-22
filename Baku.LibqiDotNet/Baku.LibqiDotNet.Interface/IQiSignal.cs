using System;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのシグナルという、.NETのイベントに相当するオブジェクトを表します。</summary>
    public interface IQiSignal
    {
        ///// <summary>シグナルが送られると発生します。</summary>
        //event EventHandler<QiSignalEventArgs> Received;

        /// <summary>シグナルを受信した場合に実行されるイベントハンドラ相当の関数を登録します。</summary>
        /// <param name="handler">シグナル受信時に実行される関数</param>
        /// <returns>非同期の処理結果</returns>
        IQiFuture ConnectAsync(Action<IQiResult> handler);

        /// <summary><see cref="ConnectAsync(Action{IQiResult})"/>で登録した関数を登録解除します。</summary>
        /// <param name="handler">シグナル受信時に実行されるよう登録していた関数</param>
        /// <returns>非同期の処理結果</returns>
        IQiFuture DisconnectAsync(Action<IQiResult> handler);
    }

    ///// <summary>シグナルに付随するイベントデータを表します。</summary>
    //public class QiSignalEventArgs : EventArgs
    //{
    //    /// <summary>シグナルの付随情報を表すデータを指定してイベントデータを初期化します。</summary>
    //    /// <param name="v">シグナルに付随するデータ。データが無い場合は<see langword="null"/>を指定しても構いません。</param>
    //    public QiSignalEventArgs(IQiResult v)
    //    {
    //        Data = v;
    //    }

    //    /// <summary>シグナルの付随情報を取得します。付随情報が無い場合<see langword="null"/>になることに注意してください。</summary>
    //    public IQiResult Data { get; }
    //}

    /// <summary><see cref="IQiSignal"/>インターフェースに拡張メソッドを提供します。</summary>
    public static class IQiSignalExtensions
    {
        /// <summary>シグナルを受信した場合に実行されるイベントハンドラ相当の関数を登録します。</summary>
        /// <param name="signal">操作対象となるシグナルのインスタンス</param>
        /// <param name="handler">シグナル受信時に実行される関数</param>
        public static void Connect(this IQiSignal signal, Action<IQiResult> handler)
            => signal.ConnectAsync(handler).WaitAndThrowIfFailed();

        /// <summary><see cref="IQiSignal.ConnectAsync(Action{IQiResult})"/>で登録した関数を登録解除します。</summary>
        /// <param name="signal">操作対象となるシグナルのインスタンス</param>
        /// <param name="handler">シグナル受信時に実行されるよう登録していた関数</param>
        public static void Disconnect(this IQiSignal signal, Action<IQiResult> handler)
            => signal.DisconnectAsync(handler).WaitAndThrowIfFailed();

    }
}
