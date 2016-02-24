using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Baku.LibqiDotNet.QiApi
{
    /// <summary>アンマネージドAPIのうち<see cref="QiValue"/>に関するもの</summary>
    internal static class QiApiValue
    {
        #region dllimport

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_create(string sig);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_value_destroy(IntPtr value);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_reset(IntPtr value, string sig);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void qi_value_swap(IntPtr dest, IntPtr src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_copy(IntPtr src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern QiValueKind qi_value_get_kind(IntPtr value);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_get_signature(IntPtr value, int resolveDynamics);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_get_type(IntPtr value);


        #region 組み込み型(long, ulong, float, double, string)の取得と設定

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_uint64(IntPtr value, ulong src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_get_uint64(IntPtr value, ref ulong target);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern ulong qi_value_get_uint64_default(IntPtr value, ulong defaultValue);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_int64(IntPtr value, long src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_get_int64(IntPtr value, ref long target);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern long qi_value_get_int64_default(IntPtr value, long defaultValue);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_float(IntPtr value, float src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_get_float(IntPtr value, ref float target);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern float qi_value_get_float_default(IntPtr value, float defaultValue);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_double(IntPtr value, double src);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_get_double(IntPtr value, ref double target);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern double qi_value_get_double_default(IntPtr value, double defaultValue);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_string(IntPtr value, IntPtr utf8strPtr);

        //const char*が飛んでくるのだけどreturn MarshalAsでうまく捌けないのであとでラップ
        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_get_string(IntPtr value);

        #endregion

        #region コンテナ系(LIST/MAP/OBJECT/TUPLE/DYNAMIC/RAW)

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_list_set(IntPtr container, uint idx, IntPtr element);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_list_get(IntPtr container, uint idx);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_list_push_back(IntPtr container, IntPtr element);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_list_size(IntPtr container);



        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern uint qi_value_map_size(IntPtr container);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_map_set(IntPtr container, IntPtr key, IntPtr element);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_map_get(IntPtr container, IntPtr key);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_map_keys(IntPtr container);


        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_get_object(IntPtr value);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_set_object(IntPtr value, IntPtr obj);


        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_tuple_set(IntPtr container, uint idx, IntPtr element);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_tuple_get(IntPtr container, uint idx);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_tuple_size(IntPtr container);


        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_dynamic_set(IntPtr container, IntPtr element);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr qi_value_dynamic_get(IntPtr container);


        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_raw_set(IntPtr container, IntPtr data, int size);

        [DllImport(DllImportSettings.DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int qi_value_raw_get(IntPtr container, ref IntPtr result, ref int size);

        #endregion


        #endregion

        #region internal関数

        #region ベースの運用


        internal static QiValue Create(string sig) => new QiValue(qi_value_create(sig));
        internal static void Destroy(QiValue v) => qi_value_destroy(v.Handle);

        internal static bool Reset(QiValue v, [MarshalAs(UnmanagedType.LPStr)]string sig)
            => Convert.ToBoolean(qi_value_reset(v.Handle, sig));

        internal static void Swap(QiValue v1, QiValue v2)
            => qi_value_swap(v1.Handle, v2.Handle);

        internal static QiValue Copy(QiValue src) => new QiValue(qi_value_copy(src.Handle));

        internal static QiValueKind GetKind(QiValue v) => qi_value_get_kind(v.Handle);

        internal static string GetSignature(QiValue v, int resolveDynamics)
            => Marshal.PtrToStringAnsi(qi_value_get_signature(v.Handle, resolveDynamics));

        internal static QiType GetQiType(QiValue v) => new QiType(qi_value_get_type(v.Handle));

        #endregion

        #region 型ごとの処理

        #region 組み込み型(int64, uint64, float, double, string)

        internal static bool SetUInt64(QiValue v, ulong target)
            => Convert.ToBoolean(qi_value_set_uint64(v.Handle, target));

        internal static bool GetUInt64(QiValue v, ref ulong target)
            => Convert.ToBoolean(qi_value_get_uint64(v.Handle, ref target));

        internal static ulong GetUInt64WithDefault(QiValue v, ulong defaultValue)
            => qi_value_get_uint64_default(v.Handle, defaultValue);

        internal static bool SetInt64(QiValue v, long target)
            => Convert.ToBoolean(qi_value_set_int64(v.Handle, target));

        internal static bool GetInt64(QiValue v, ref long target)
            => Convert.ToBoolean(qi_value_get_int64(v.Handle, ref target));

        internal static long GetInt64WithDefault(QiValue v, long defaultValue)
            => qi_value_get_int64_default(v.Handle, defaultValue);

        internal static bool SetFloat(QiValue v, float target)
            => Convert.ToBoolean(qi_value_set_float(v.Handle, target));

        internal static bool GetFloat(QiValue v, ref float target)
            => Convert.ToBoolean(qi_value_get_float(v.Handle, ref target));

        internal static float GetFloatWithDefault(QiValue v, float defaultValue)
            => qi_value_get_float_default(v.Handle, defaultValue);

        internal static bool SetDouble(QiValue v, double target)
            => Convert.ToBoolean(qi_value_set_double(v.Handle, target));

        internal static bool GetDouble(QiValue v, ref double target)
            => Convert.ToBoolean(qi_value_get_double(v.Handle, ref target));

        internal static double GetDoubleWithDefault(QiValue v, double defaultValue)
            => qi_value_get_double_default(v.Handle, defaultValue);

        internal static bool SetString(QiValue v, string target)
        {
            //NOTE: アンマネージ側はヌル終端文字を想定してるらしい
            var data = Encoding.UTF8.GetBytes(target);
            IntPtr tPtr = Marshal.AllocHGlobal(data.Length + 1);
            Marshal.Copy(data, 0, tPtr, data.Length);
            Marshal.WriteByte(tPtr, data.Length, 0x00);
            bool result = Convert.ToBoolean(qi_value_set_string(v.Handle, tPtr));
            Marshal.FreeHGlobal(tPtr);

            return result;
        }

        internal static string GetString(QiValue v)
        {
            IntPtr utf8nullEndStringPtr = qi_value_get_string(v.Handle);
            int byteLength = 0;
            //ヌル終端探し(これ上限無いの地味に怖いなあ)
            while(Marshal.ReadByte(utf8nullEndStringPtr, byteLength) != (byte)0x00)
            {
                byteLength++;
            }

            var strBytes = new byte[byteLength];
            Marshal.Copy(utf8nullEndStringPtr, strBytes, 0, byteLength);
            return Encoding.UTF8.GetString(strBytes);
        }

        #endregion

        #region コンテナ型とか

        internal static bool SetList(QiValue container, uint idx, QiValue element)
            => Convert.ToBoolean(qi_value_list_set(container.Handle, idx, element.Handle));

        internal static QiValue GetList(QiValue container, uint idx)
            => new QiValue(qi_value_list_get(container.Handle, idx));

        internal static bool AddList(QiValue container, QiValue element)
            => Convert.ToBoolean(qi_value_list_push_back(container.Handle, element.Handle));

        internal static int SizeList(QiValue container) => qi_value_list_size(container.Handle);


        internal static uint SizeMap(QiValue container)  => qi_value_map_size(container.Handle);

        internal static bool SetMap(QiValue container, QiValue key, QiValue element)
            => Convert.ToBoolean(qi_value_map_set(container.Handle, key.Handle, element.Handle));

        internal static QiValue GetMap(QiValue container, QiValue key) 
            => new QiValue(qi_value_map_get(container.Handle, key.Handle));

        internal static QiValue KeysMap(QiValue container) 
            => new QiValue(qi_value_map_keys(container.Handle));

        internal static QiObject GetObject(QiValue v)
            => new QiObject(qi_value_get_object(v.Handle));

        internal static bool SetObject(QiValue v, QiObject obj)
            => Convert.ToBoolean(qi_value_set_object(v.Handle, obj.Handle));


        internal static bool SetTuple(QiValue container, uint idx, QiValue element)
            => Convert.ToBoolean(qi_value_tuple_set(container.Handle, idx, element.Handle));

        internal static QiValue GetTuple(QiValue container, uint idx)
            => new QiValue(qi_value_tuple_get(container.Handle, idx));

        internal static int SizeTuple(QiValue container)
            => qi_value_tuple_size(container.Handle);


        internal static bool SetDynamic(QiValue container, QiValue value)
            => Convert.ToBoolean(qi_value_dynamic_set(container.Handle, value.Handle));

        internal static QiValue GetDynamic(QiValue container)
            => new QiValue(qi_value_dynamic_get(container.Handle));


        internal static bool SetRaw(QiValue v, byte[] data)
        {
            var dataPtr = Marshal.AllocHGlobal(data.Length);

            Marshal.Copy(data, 0, dataPtr, data.Length);
            var result = Convert.ToBoolean(qi_value_raw_set(v.Handle, dataPtr, data.Length));
            Marshal.FreeHGlobal(dataPtr);

            return result;
        }

        internal static byte[] GetRaw(QiValue v)
        {
            IntPtr data = IntPtr.Zero;
            int size = 0;

            int response = qi_value_raw_get(v.Handle, ref data, ref size);
            //冗長だけど念のためサイズも確認
            if(response > 0 && size > 0)
            {
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                //(少なくとも自作実装では)元データのポインタを貰う想定なので解放しない
                //Marshal.FreeHGlobal(data);
                return result;
            }
            else
            {
                Marshal.FreeHGlobal(data);
                return new byte[0];
            }
        }

        #endregion

        #endregion

        #endregion
    }

}
