using System;
using System.Linq;
using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary><see cref="QiValue"/>のインスタンスに対応する型情報を表します。</summary>
    public sealed class QiType
    {
        internal QiType(IntPtr handle)
        {
            Handle = handle;
        }
        internal IntPtr Handle { get; }

        /// <summary>型の種類を取得します。</summary>
        public QiTypeKind TypeKind => QiApiType.GetKind(this);

        /// <summary>型が連想配列の場合、キーの型を取得します。</summary>
        /// <returns>キーの型</returns>
        public QiType GetMapKeyType() => QiApiType.GetMapKeyType(this);
        /// <summary>型が連想配列の場合、値の型を取得します。</summary>
        /// <returns>値の型</returns>
        public QiType GetMapValueType() => QiApiType.GetMapValueType(this);

        /// <summary>型がタプルの場合、タプルの要素数を取得します。</summary>
        /// <returns>タプルの要素数</returns>
        public int GetTupleCount() => QiApiType.GetTupleCount(this);

        /// <summary>型がタプルの場合、タプルの指定した位置の値の型を取得します。</summary>
        /// <param name="index">指定するインデクス</param>
        /// <returns>指定された位置での値の型</returns>
        public QiType GetTupleTypeAt(int index) => QiApiType.GetTupleTypeAt(this, index);

        /// <summary>型がタプルの場合、タプルの各要素の型をまとめたものを取得します。</summary>
        /// <returns>タプルの各要素の型</returns>
        public QiType[] GetTupleTypes() => QiApiType.GetTupleTypes(this).ToArray();
    }

}
