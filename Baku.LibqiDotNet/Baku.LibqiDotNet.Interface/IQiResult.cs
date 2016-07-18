using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiの関数呼び出し結果を表します。結果は組み込み型、リスト、ディクショナリ、オブジェクト、シグナル等のデータ構造を持ちえます。</summary>
    public interface IQiResult
    {

        /// <summary>オブジェクトの内部構造を表す表示用の文字列を取得します。</summary>
        /// <returns>オブジェクトの構造を表す文字列。デバッグに使えればよく一意性とか厳密性は不要</returns>
        string Dump();

        /// <summary>格納されているはずのbool値を取得します。</summary>
        /// <returns>格納されたbool値</returns>
        bool ToBool();
        /// <summary>この変数が符号あり1バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        sbyte ToSByte();
        /// <summary>この変数が符号あり2バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        short ToInt16();
        /// <summary>この変数が符号あり4バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        int ToInt32();
        /// <summary>この変数が符号あり8バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        long ToInt64();
        /// <summary>この変数が符号なし1バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        byte ToByte();
        /// <summary>この変数が符号なし2バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        ushort ToUInt16();
        /// <summary>この変数が符号なし4バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        uint ToUInt32();
        /// <summary>この変数が符号なし8バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        ulong ToUInt64();

        /// <summary>この変数が単精度小数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        float ToFloat();
        /// <summary>この変数が倍精度小数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        double ToDouble();

        /// <summary>この変数がバイナリデータ型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        byte[] ToBytes();

        /// <summary>
        /// この変数が文字列型である場合はその値、そうでない場合は保持している値の型を表す文字列を取得します。
        /// NOTE: この関数を実装する際にToStringもToQiStringと同じ結果を返すようにしてほしい
        /// </summary>
        /// <returns>格納された値</returns>
        string ToQiString();

        /// <summary>リストやタプルの長さを取得します。</summary>
        int Count { get; }

        /// <summary>リストまたはタプルにインデクスでアクセスします。境界チェックは行われません。</summary>
        IQiResult this[int index] { get; set; }

        /// <summary>連想配列にキー要素でアクセスします。キーが連想配列に含まれるかどうかはチェックされません。</summary>
        IQiResult this[IQiResult key] { get; set; }

        /// <summary>連想配列のキー一覧を取得します。連想配列でない値で呼び出すと要素が空の一覧を取得します。</summary>
        IEnumerable<IQiResult> Keys { get; }

        /// <summary>連想配列のキー/値ペア一覧を取得します。連想配列でない値で呼び出すと空の一覧を取得します。</summary>
        IEnumerable<KeyValuePair<IQiResult, IQiResult>> MapItems { get; }

    }

    /// <summary><see cref="IQiResult"/>の拡張メソッドを提供します。</summary>
    public static class IQiResultExtensions
    {
        /// <summary>再帰的に入れ子データを展開する際の再帰深度の上限を取得、設定します。</summary>
        public static int RecurseDepthLimit { get; set; } = 7;

        /// <summary>オブジェクト自身を取り出します。この処理は<see cref="Get{T}(IQiResult)"/>に対応づける目的で作成しています。</summary>
        public static IQiResult Get(this IQiResult result) => result;

        /// <summary>結果が指定した型である前提で値を取り出します。</summary>
        /// <typeparam name="T">組み込み型あるいはbyte[], int[], double[], string[]</typeparam>
        /// <returns>対応する型の結果。想定と実際の戻り値が違う場合や上記の型以外では例外をスローします。</returns>
        public static T Get<T>(this IQiResult result)
            => (typeof(T) == typeof(IQiResult)) ? 
                (T)(result as object) : 
                (T)GetSub(result, typeof(T), RecurseDepthLimit);

        private static object GetSub(IQiResult result, Type t, int recurseDepthRemain)
        {
            //組み込み型は普通にTypeCodeで拾う
            if (IsEmbeddedType(t))
            {
                return GetEmbeddedTypeData(result, Type.GetTypeCode(t));
            }

            //バイナリデータ
            if (t == typeof(byte[]))
            {
                return result.ToBytes();
            }

            //よく出てくる配列/IE<T>型は速度重視のためリフレクしない
            if(IsSpecialEnumerableType(t))
            {
                return GetSpecialEnumerableType(result, t);
            }
            
            //IDic<TKey, TValue>
            if (t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                return GetDictionary(result, t, recurseDepthRemain);
            }

            //IE<T>
            if (t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return GetEnumerable(result, t, recurseDepthRemain);
            }

            //TEMP: 変なのを指定された場合はデフォルト値で返す(後で仕様変えるかも)
            return (t.IsValueType) ? Activator.CreateInstance(t) : null;
        }

        private static object GetEmbeddedTypeData(IQiResult result, TypeCode tCode)
        {
            switch (tCode)
            {
                case TypeCode.Boolean: return result.ToBool();
                case TypeCode.SByte: return result.ToSByte();
                case TypeCode.Int16: return result.ToInt16();
                case TypeCode.Int32: return result.ToInt32();
                case TypeCode.Int64: return result.ToInt64();
                case TypeCode.Byte: return result.ToByte();
                case TypeCode.UInt16: return result.ToUInt16();
                case TypeCode.UInt32: return result.ToUInt32();
                case TypeCode.UInt64: return result.ToUInt64();
                case TypeCode.Single: return result.ToFloat();
                case TypeCode.Double: return result.ToDouble();
                case TypeCode.String: return result.ToQiString();
                default:
                    throw new ArgumentException();
            }
        }

        private static bool IsEmbeddedType(Type t)
            => _embeddedTypeCodes.Contains(Type.GetTypeCode(t));

        private static object GetSpecialEnumerableType(IQiResult result, Type t)
        {
            if (t == typeof(int[]) || t == typeof(IEnumerable<int>))
            {
                return GetIntArray(result);
            }
            else if (t == typeof(string[]) || t == typeof(IEnumerable<string>))
            {
                return GetStringArray(result);
            }
            else if (t == typeof(double[]) || t == typeof(IEnumerable<double>))
            {
                return GetDoubleArray(result);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        private static int[] GetIntArray(IQiResult result)
        {
            var resArray = new int[result.Count];
            for (int i = 0; i < resArray.Length; i++)
            {
                resArray[i] = result[i].ToInt32();
            }
            return resArray;
        }
        private static string[] GetStringArray(IQiResult result)
        {
            var resArray = new string[result.Count];
            for (int i = 0; i < resArray.Length; i++)
            {
                resArray[i] = result[i].ToQiString();
            }
            return resArray;
        }
        private static double[] GetDoubleArray(IQiResult result)
        {
            var resArray = new double[result.Count];
            for (int i = 0; i < resArray.Length; i++)
            {
                resArray[i] = result[i].ToDouble();
            }
            return resArray;
        }

        private static bool IsSpecialEnumerableType(Type t)
            => _specialEnumerableType.Contains(t);

        private static object GetDictionary(IQiResult result, Type t, int recurseDepthRemain)
        {
            Type[] gtypes = t.GetGenericArguments();
            Type keyType = gtypes[0];
            Type valueType = gtypes[1];

            Type resType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

            //辞書型のインスタンスを取得
            object resDic = Activator.CreateInstance(resType);

            //インデクサ(setterを拾う)
            PropertyInfo indexer = resType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .First(p => p.GetIndexParameters()
                    .Select(ip => ip.ParameterType)
                    .SequenceEqual(new Type[] { keyType }));

            foreach (var p in result.MapItems)
            {
                object pairKey = GetSub(p.Key, keyType, recurseDepthRemain - 1);
                object pairValue = GetSub(p.Value, valueType, recurseDepthRemain - 1);

                //resDic[p.Key] = p.Value;
                indexer.SetValue(resDic, pairValue, new object[] { pairKey });
            }

            return resDic;
        }

        private static object GetEnumerable(IQiResult result, Type t, int recurseDepthRemain)
        {
            Type contentType = t.GetGenericArguments()[0];
            Type resType = typeof(List<>).MakeGenericType(contentType);

            //リスト型変数を取得
            object resList = Activator.CreateInstance(resType);
            //Addメソッドを取得
            //NOTE: nameof(List<object>.Add) == "Add", 型引数に<object>としてるのは単にエラー回避のため
            //MethodInfo addMethod = resType.GetMethod(nameof(List<object>.Add));
            MethodInfo addMethod = resType.GetMethod(
                nameof(List<object>.Add), new Type[] { contentType }
                );

            for (int i = 0; i < result.Count; i++)
            {
                object elemToAdd = GetSub(result[i], contentType, recurseDepthRemain - 1);
                addMethod.Invoke(resList, new object[] { elemToAdd });
            }

            return resList;
        }

        #region readonly type arrays

        private static readonly TypeCode[] _embeddedTypeCodes = new []
        {
            TypeCode.Boolean,
            TypeCode.Byte,
            TypeCode.UInt16,
            TypeCode.UInt32,
            TypeCode.UInt64,
            TypeCode.SByte,
            TypeCode.Int16,
            TypeCode.Int32,
            TypeCode.Int64,
            TypeCode.String,
            TypeCode.Single,
            TypeCode.Double
        };

        private static readonly Type[] _specialEnumerableType = new[]
        {
            typeof(int[]),
            typeof(IEnumerable<int>),
            typeof(string[]),
            typeof(IEnumerable<string>),
            typeof(double[]),
            typeof(IEnumerable<double>)
        };

        #endregion

    }

}
