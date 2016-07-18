using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Baku.LibqiDotNet.Libqi.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiType"/>に関するもの</summary>
    internal static class QiApiType
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_of_kind(QiTypeKind kind);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_int(int issigned, int bytelen);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_float(int bytelen);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_list_of(IntPtr qiType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_map_of(IntPtr keyType, IntPtr elemType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_tuple_of(int count, [In]IntPtr[] qiType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_type_destroy(IntPtr qiType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern QiTypeKind qi_type_get_kind(IntPtr qiType);


        //Map型用
        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_get_key(IntPtr qiType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_get_value(IntPtr qiType);


        //タプルはリストとかマップと異なり、要素別に型が違ってもOK
        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_type_get_element_count(IntPtr qiType);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_type_get_element(IntPtr qiType, int index);



        #endregion

        //NOTE: この辺からしばらくファクトリメソッドである
        internal static QiType TypeOfKind(QiTypeKind kind) => new QiType(qi_type_of_kind(kind));

        internal static QiType TypeInt(bool isSigned, int bytelen)
            => new QiType(qi_type_int(Convert.ToInt32(isSigned), bytelen));

        internal static QiType TypeFloat(int bytelen)
            => new QiType(qi_type_float(bytelen));

        internal static QiType TypeListOf(QiType qiType)
            => new QiType(qi_type_list_of(qiType.Handle));

        internal static QiType TypeMapOf(QiType keyType, QiType valueType)
            => new QiType(qi_type_map_of(keyType.Handle, valueType.Handle));

        internal static QiType TypeTupleOf(QiType[] qiTypes)
            => new QiType(qi_type_tuple_of(
                qiTypes.Length,
                qiTypes.Select(q => q.Handle).ToArray()
                ));


        //NOTE: 既存のタイプをハンドリングする関数はこっから下
        internal static void Destroy(QiType qiType) => qi_type_destroy(qiType.Handle);

        internal static QiTypeKind GetKind(QiType qiType) => qi_type_get_kind(qiType.Handle);

        internal static QiType GetMapKeyType(QiType mapType)
            => new QiType(qi_type_get_key(mapType.Handle));

        internal static QiType GetMapValueType(QiType mapType)
            => new QiType(qi_type_get_value(mapType.Handle));

        internal static int GetTupleCount(QiType tupleType)
            => qi_type_get_element_count(tupleType.Handle);

        internal static QiType GetTupleTypeAt(QiType tupleType, int index)
            => new QiType(qi_type_get_element(tupleType.Handle, index));

        internal static IEnumerable<QiType> GetTupleTypes(QiType tupleType)
            => Enumerable
            .Range(0, GetTupleCount(tupleType))
            .Select(i => GetTupleTypeAt(tupleType, i));

    }

}
