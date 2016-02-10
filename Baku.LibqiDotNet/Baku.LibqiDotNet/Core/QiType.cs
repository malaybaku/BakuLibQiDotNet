using System;
using System.Linq;
using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{

    /// <summary><see cref="QiValue"/>に対応した型情報を表します。</summary>
    public class QiType
    {
        internal QiType(IntPtr handle)
        {
            Handle = handle;
        }
        public IntPtr Handle { get; }

        public QiTypeKind TypeKind => QiApiType.GetKind(this);

        public QiType GetMapKeyType() => QiApiType.GetMapKeyType(this);
        public QiType GetMapValueType() => QiApiType.GetMapValueType(this);

        public int GetTupleCount() => QiApiType.GetTupleCount(this);
        public QiType GetTupleTypeAt(int index) => QiApiType.GetTupleTypeAt(this, index);
        public QiType[] GetTupleTypes() => QiApiType.GetTupleTypes(this).ToArray();
    }

}
