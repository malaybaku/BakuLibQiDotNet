using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>非同期的にリクエストの戻り値を受け取るコンテナを表します。</summary>
    public class QiFuture
    {
        internal QiFuture(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>
        /// 指定した時間まで待機します。
        /// </summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>待機後の、このインスタンス自身</returns>
        public QiFuture Wait(int timeout)
        {
            QiApiFuture.Wait(this, timeout);
            return this;
        }
        /// <summary>
        /// 無期限に待機します。
        /// </summary>
        /// <returns>待機後の、このインスタンス自身</returns>
        public QiFuture Wait() => Wait(InfiniteTimeout);

        /// <summary>
        /// エラーが起きたかどうかを待機しつつ確認します。
        /// </summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError(int timeout) => QiApiFuture.HasError(this, timeout);
        /// <summary>
        /// エラーが起きたかどうかを無期限待機ののち確認します。
        /// </summary>
        /// <returns>エラーの有無</returns>
        public bool CheckHasError() => CheckHasError(InfiniteTimeout);

        /// <summary>
        /// 値を持っているかどうかを待機ののち確認します。
        /// </summary>
        /// <param name="timeout">待機時間の上限(ミリ秒)</param>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue(int timeout) => QiApiFuture.HasValue(this, timeout);
        /// <summary>
        /// 値を持っているかどうかを無期限待機ののち確認します。
        /// </summary>
        /// <returns>値の所持の有無</returns>
        public bool CheckHasValue() => CheckHasValue(InfiniteTimeout);

        /// <summary>結果取得をキャンセルします。</summary>
        public void Cancel() => QiApiFuture.IsCanceled(this);

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiFuture.Destroy(this);

        /// <summary>処理が実行中であるかを取得します。</summary>
        public bool IsRunning => QiApiFuture.IsRunning(this);

        /// <summary>処理が終了済であるかを取得します。</summary>
        public bool IsFinished => QiApiFuture.IsFinished(this);

        /// <summary>処理がキャンセル済みであるかを取得します。</summary>
        public bool IsCanceled => QiApiFuture.IsCanceled(this);

        /// <summary>コピーを生成します。</summary>
        /// <returns>コピーされたインスタンス</returns>
        public QiFuture CloneFuture() => QiApiFuture.Clone(this);

        /// <summary>一般的な処理結果を取得します。</summary>
        /// <returns>
        /// 呼び出し結果。
        /// 処理の完了待機が適切に行われていない場合、例外が生じる可能性があります。
        /// </returns>
        public QiValue GetValue() => QiApiFuture.GetValue(this);

        /// <summary>エラーがある場合、それを文字列として取得します。</summary>
        /// <returns>エラーを表す文字列</returns>
        public string GetError() => QiApiFuture.GetError(this);

        /// <summary>結果を符号つき整数として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public long GetInt64(long def) => QiApiFuture.GetInt64Default(this, def);

        /// <summary>結果を符号なし整数として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public ulong GetUInt64(ulong def) => QiApiFuture.GetUInt64Default(this, def);

        /// <summary>結果を文字列として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public string GetString() => QiApiFuture.GetString(this);

        /// <summary>結果を<see cref="QiObject"/>として取得します。</summary>
        /// <returns>呼び出し結果</returns>
        public QiObject GetObject() => QiApiFuture.GetObject(this);

        /// <summary>
        /// (動作未確認)動作完了時のコールバック関数を登録します。
        /// </summary>
        /// <param name="cb">コールバック関数</param>
        /// <param name="userData">ユーザーデータ</param>
        public void AddCallback(QiFutureCallback cb, IntPtr userData)
        {
            var apiCallback = new QiApiFutureCallback((fut, udata) => cb(new QiFuture(fut), udata));
            QiApiFuture.AddCallback(this, apiCallback, userData);
        }


        /// <summary>(詳細未確認)待機を行わないことを表します。</summary>
        public static readonly int NoneTimeout = 0;
        /// <summary>無期限の待機を表します。</summary>
        public static readonly int InfiniteTimeout = 0x7fffffff;

    }

    public delegate void QiFutureCallback(QiFuture future, IntPtr userdata);


}
