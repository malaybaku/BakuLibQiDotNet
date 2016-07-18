using System;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのシグナルという、.NETのイベントに相当するオブジェクトを表します。</summary>
    public interface IQiSignal
    {
        /// <summary>シグナルが送られると発生します。</summary>
        event EventHandler<QiSignalEventArgs> Received;
    }

    /// <summary>シグナルに付随するイベントデータを表します。</summary>
    public class QiSignalEventArgs : EventArgs
    {
        /// <summary>シグナルの付随情報を表すデータを指定してイベントデータを初期化します。</summary>
        /// <param name="v">シグナルに付随するデータ。データが無い場合は<see langword="null"/>を指定しても構いません。</param>
        public QiSignalEventArgs(IQiResult v)
        {
            Data = v;
        }

        /// <summary>シグナルの付随情報を取得します。付随情報が無い場合<see langword="null"/>になることに注意してください。</summary>
        public IQiResult Data { get; }
    }
}
