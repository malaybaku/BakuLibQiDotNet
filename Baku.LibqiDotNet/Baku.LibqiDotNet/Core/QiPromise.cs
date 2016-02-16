using System;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{

    /// <summary>
    /// <see cref="QiFuture"/>の対となる値の返却処理を表します(多分)。
    /// サービスの自作をしない限り必要なさそうなため実装は最低限になっています。
    /// </summary>
    public class QiPromise
    {

        internal QiPromise(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiPromise.Destroy(this);

        /// <summary>
        /// 値を設定します。
        /// </summary>
        /// <param name="value">設定する値</param>
        public void SetValue(QiValue value) => QiApiPromise.SetValue(this, value);

        /// <summary>
        /// エラーが起きたことを設定します。
        /// </summary>
        /// <param name="error">エラーの内容の要約文</param>
        public void SetError(string error) => QiApiPromise.SetError(this, error);

        /// <summary>処理がキャンセルされたことを通知します。</summary>
        public void SetCanceled() => QiApiPromise.SetCanceled(this);

        /// <summary>
        /// 処理に対応した<see cref="QiFuture"/>を発行します。
        /// </summary>
        /// <returns>処理に対応する結果への予約</returns>
        public QiFuture GetFuture() => QiApiPromise.GetFuture(this);

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="asyncCallback">非同期コールバックの設定(詳細未確認)</param>
        /// <returns></returns>
        public static QiPromise Create(bool asyncCallback=true) => QiApiPromise.Create(asyncCallback);

        /// <summary>
        /// (未確認)キャンセル時のコールバックを設定してインスタンスを生成します。
        /// </summary>
        /// <param name="asyncCallback"></param>
        /// <param name="cb"></param>
        /// <param name="userdata"></param>
        /// <returns></returns>
        public static QiPromise Create(bool asyncCallback, QiFutureCancel cb, IntPtr userdata)
            => QiApiPromise.CreateCancelable(asyncCallback, cb, userdata);

    }

    /// <summary>
    /// <see cref="QiPromise.Create(bool, QiFutureCancel, IntPtr)"/>によって
    /// キャンセル処理が生じた場合に用いるコールバック関数を表します。
    /// </summary>
    /// <param name="promise">対象となる<see cref="QiPromise"/></param>
    /// <param name="userdata">ユーザデータ(通常は使用しない)</param>
    public delegate void QiFutureCancel(IntPtr promise, IntPtr userdata);


}
