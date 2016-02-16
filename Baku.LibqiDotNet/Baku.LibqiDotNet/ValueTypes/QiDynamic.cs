
namespace Baku.LibqiDotNet
{
    /// <summary>動的に型付けが行われる値を表します。</summary>
    public class QiDynamic : QiAnyValue
    {
        /// <summary>
        /// 渡された<see cref="QiSignatures.TypeDynamic"/>シグネチャを持った変数をそのまま格納するか、
        /// そうでない場合渡された値を動的型コンテナに格納してインスタンスを初期化します。
        /// </summary>
        /// <param name="value">インスタンスが保持する値</param>
        public QiDynamic(QiValue value)
        {
            if (value.ValueKind == QiValueKind.QiDynamic)
            {
                QiValue = value;
            }
            else
            {
                QiValue = QiValue.Create(QiSignatures.TypeDynamic);
                QiValue.SetValue(value);
            }
        }
        /// <summary>
        /// 生成済みの他の値を用いてインスタンスを初期化します。
        /// </summary>
        /// <param name="v">生成された値</param>
        public QiDynamic(QiAnyValue v) : this(v.QiValue) { }


        /// <summary>ラップしている<see cref="QiValue"/>型の値を取得します。</summary>
        public override QiValue QiValue { get; }
        /// <summary>変数型に対応したシグネチャを取得します。</summary>
        public override string Signature { get; } = QiSignatures.TypeDynamic;

        /// <summary>格納しているデータを取得します。</summary>
        public QiValue Value => QiValue.Value as QiValue;

    }

    /// <summary><see cref="QiDynamic"/>のためのヘルパー拡張メソッドを定義します。</summary>
    public static class QiDynamicExtension
    {
        /// <summary>
        /// <see cref="QiAnyValue"/>の派生型変数を動的型にキャストします。
        /// </summary>
        /// <param name="v">何かしらの値</param>
        /// <returns>指定した値を動的型コンテナに格納した値</returns>
        public static QiDynamic ToDynamic(this QiAnyValue v) => new QiDynamic(v);
    }
}
