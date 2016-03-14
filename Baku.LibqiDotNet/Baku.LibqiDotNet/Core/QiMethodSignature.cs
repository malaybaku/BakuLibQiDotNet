using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>
    /// <see cref="QiObjectBuilder.AdvertiseMethod(string, QiMethodSignature, IEnumerable{QiMethodSignature}, QiObjectMethod)"/>
    /// 関数で用いるための、変数の型情報を表します。
    /// </summary>
    public class QiMethodSignature
    {
        internal QiMethodSignature(string sig)
        {　
            Signature = sig;
        }

        /// <summary>型情報と等価な文字列を取得します。</summary>
        public string Signature { get; }

        /// <summary>型を指定し、対応する型を保持するシグネチャを取得します。</summary>
        /// <param name="signature">型の種類</param>
        /// <returns>型に対応したシグネチャ</returns>
        public static QiMethodSignature Create(QiMethodSignatureKind signature)
            => new QiMethodSignature(_sigMap[signature]);

        /// <summary>指定した型からなるリスト型のシグネチャを取得します。</summary>
        /// <param name="sig">リストの要素型</param>
        /// <returns>リストのシグネチャ</returns>
        public static QiMethodSignature ListOf(QiMethodSignature sig)
            => new QiMethodSignature(QiSignatures.TypeListBegin + sig.Signature + QiSignatures.TypeListEnd);

        /// <summary>指定した型を順に内包するタプル型のシグネチャを取得します。</summary>
        /// <param name="sigs">タプルに含む型の一覧</param>
        /// <returns>タプル型のシグネチャ</returns>
        public static QiMethodSignature TupleOf(IEnumerable<QiMethodSignature> sigs)
        {
            return new QiMethodSignature(
                QiSignatures.TypeTupleBegin +
                string.Join("", sigs.Select(s => s.Signature).ToArray()) +
                QiSignatures.TypeTupleEnd
                );
        }


        private readonly static Dictionary<QiMethodSignatureKind, string> _sigMap = new Dictionary<QiMethodSignatureKind, string>
        {
            #region Mapping
            [QiMethodSignatureKind.Void] = QiSignatures.TypeVoid,

            [QiMethodSignatureKind.Bool] = QiSignatures.TypeBool,

            [QiMethodSignatureKind.Int8] = QiSignatures.TypeInt8,
            [QiMethodSignatureKind.Int16] = QiSignatures.TypeInt16,
            [QiMethodSignatureKind.Int32] = QiSignatures.TypeInt32,
            [QiMethodSignatureKind.Int64] = QiSignatures.TypeInt64,

            [QiMethodSignatureKind.UInt8] = QiSignatures.TypeUInt8,
            [QiMethodSignatureKind.UInt16] = QiSignatures.TypeUInt16,
            [QiMethodSignatureKind.UInt32] = QiSignatures.TypeUInt32,
            [QiMethodSignatureKind.UInt64] = QiSignatures.TypeUInt64,

            [QiMethodSignatureKind.Float] = QiSignatures.TypeFloat,
            [QiMethodSignatureKind.Double] = QiSignatures.TypeDouble,

            [QiMethodSignatureKind.String] = QiSignatures.TypeString,
            [QiMethodSignatureKind.Dynamic] = QiSignatures.TypeDynamic,
            [QiMethodSignatureKind.Raw] = QiSignatures.TypeRaw,
            #endregion
        };
    }

    /// <summary>自作関数を作る場合に関数を指定するためのシグネチャ一覧です。</summary>
    public enum QiMethodSignatureKind
    {

        /// <summary>関数に戻り値が無いことを示す型</summary>
        Void,
        /// <summary>論理値型</summary>
        Bool,
        /// <summary>符号あり1バイト整数型</summary>
        Int8,
        /// <summary>符号なし1バイト整数型</summary>
        UInt8,
        /// <summary>符号あり2バイト整数型</summary>
        Int16,
        /// <summary>符号なし2バイト整数型</summary>
        UInt16,
        /// <summary>符号あり4バイト整数型</summary>
        Int32,
        /// <summary>符号なし4バイト整数型</summary>
        UInt32,
        /// <summary>符号あり8バイト整数型</summary>
        Int64,
        /// <summary>符号なし8バイト整数型</summary>
        UInt64,
        /// <summary>4バイト小数型</summary>
        Float,
        /// <summary>8バイト小数型</summary>
        Double,
        /// <summary>文字列型</summary>
        String,
        /// <summary>動的型</summary>
        Dynamic,
        /// <summary>バイナリ型</summary>
        Raw,

    }

}
