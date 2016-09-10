using System;
using System.Collections.Generic;

using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>
    /// <see cref="QiObject"/>のビルダークラスです。
    /// 自作サービスを作る場合のみ使われるものであるため、実装は最低限です。
    /// </summary>
    public sealed class QiObjectBuilder
    {
        internal QiObjectBuilder(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        /// <summary>関数を登録します。</summary>
        /// <param name="signature">関数のフルシグネチャ</param>
        /// <param name="method">実際の関数</param>
        public void AdvertiseMethod(string signature, QiObjectMethod method)
        {
            var qiMethod = new QiMethod(method);
            uint id = QiApiObjectBuilder.AdvertiseMethod(
                this, signature, qiMethod.UnmanagedMethod, IntPtr.Zero
                );
            
            _advertisedMethods[id] = qiMethod;
        }

        /// <summary>関数を登録します。</summary>
        /// <param name="methodName">関数の名前</param>
        /// <param name="returns">返却する値の型</param>
        /// <param name="args">引数の型一覧</param>
        /// <param name="method">メソッドの実装</param>
        public void AdvertiseMethod(
            string methodName,
            QiMethodSignature returns,
            IEnumerable<QiMethodSignature> args,
            QiObjectMethod method
            )
        {
            string signature = methodName +
                QiSignatures.MethodNameSuffix +
                returns.Signature +
                QiMethodSignature.TupleOf(args).Signature;

            AdvertiseMethod(signature, method);
        }


        /// <summary>シグナルを登録します。</summary>
        /// <param name="name">シグナル名</param>
        /// <param name="signature">シグネチャ</param>
        /// <returns>シグナルに割り振ったID</returns>
        public uint AdvertiseSignal(string name, string signature)
            => QiApiObjectBuilder.AdvertiseSignal(this, name, signature);

        /// <summary>
        /// プロパティを登録します。
        /// </summary>
        /// <param name="name">プロパティ名</param>
        /// <param name="signature">プロパティのシグネチャ</param>
        /// <returns>プロパティに割り振ったID</returns>
        public uint AdvertiseProperty(string name, string signature)
            => QiApiObjectBuilder.AdvertiseProperty(this, name, signature);

        /// <summary>
        /// 登録情報に基づき、オブジェクトを生成します。
        /// </summary>
        /// <returns>生成されたオブジェクト</returns>
        public QiObject BuildObject() => QiApiObjectBuilder.BuildObject(this);


        /// <summary>
        /// 既定の方法でインスタンスを生成します。
        /// </summary>
        /// <returns>生成されたインスタンス</returns>
        public static QiObjectBuilder Create() => QiApiObjectBuilder.Create();

        //GC対策で登録した関数保持するキャッシュ
        private readonly Dictionary<uint, QiMethod> _advertisedMethods = new Dictionary<uint, QiMethod>();

        /// <summary>マネージドに宣言されたメソッドとアンマネージド版をセットで保持するホルダー</summary>
        class QiMethod
        {
            public QiMethod(QiObjectMethod method)
            {
                ManagedMethod = method;
                UnmanagedMethod = (sig, args, ret, _) =>
                {
                    var result = ManagedMethod(sig, new QiValue(args));
                    var retValue = new QiValue(ret);
                    //すり替え処理によって計算結果を渡したい
                    //(というかC言語APIだと他に良い手が無さそうに見える)
                    QiValue.Swap(retValue, result);
                };
            }

            internal QiObjectMethod ManagedMethod { get; }
            internal QiApiObjectMethod UnmanagedMethod { get; }
        }

    }

    /// <summary>
    /// サービスに登録される関数を表します。
    /// </summary>
    /// <param name="completeSignature">関数の引数名と完全なシグネチャ</param>
    /// <param name="args">引数</param>
    /// <returns></returns>
    public delegate QiValue QiObjectMethod(string completeSignature, QiValue args);

}
