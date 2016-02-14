using System;
using System.Linq;
using System.Text;

using Baku.LibqiDotNet.QiApi;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiの一般的な値を表します。</summary>
    public class QiValue
    {
        internal QiValue(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        #region 基本処理


        /// <summary>値の種類を取得します。</summary>
        public QiValueKind ValueKind => QiApiValue.GetKind(this);

        /// <summary>値のシグネチャを取得します。</summary>
        /// <param name="resolveDynamics">シグネチャの解決法(サンプル見た限り既定値の<see cref="0"/>で十分そう)</param>
        /// <returns>値のシグネチャ</returns>
        public string GetSignature(int resolveDynamics = 0) => QiApiValue.GetSignature(this, resolveDynamics);

        /// <summary>
        /// (動作未確認)値を規定値に戻します。
        /// </summary>
        /// <param name="signature"></param>
        public void Reset(string signature) => QiApiValue.Reset(this, signature);

        /// <summary>
        /// 型情報を取得します。
        /// </summary>
        /// <returns>インスタンスに対応する型情報</returns>
        public QiType GetQiType() => QiApiValue.GetQiType(this);

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiValue.Destroy(this);
        /// <summary>
        /// 値をコピーします。
        /// </summary>
        /// <returns>コピーされた値</returns>
        public QiValue Copy() => GetCopy(this);

        /// <summary>
        /// シグネチャを指定して値を初期化します。
        /// </summary>
        /// <param name="sig">値のシグネチャを表す文字列</param>
        /// <returns>初期化された値</returns>
        public static QiValue Create(string sig) => QiApiValue.Create(sig);
        /// <summary>
        /// 値のコピーを生成します。
        /// </summary>
        /// <param name="src">生成元の値</param>
        /// <returns>コピーされた値</returns>
        public static QiValue GetCopy(QiValue src) => QiApiValue.Copy(src);
        /// <summary>
        /// 指定した2つの値を入れ替えます。
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public static void Swap(QiValue v1, QiValue v2) => QiApiValue.Swap(v1, v2);

        #endregion

        #region 値のIO関連

        /// <summary>
        /// 格納されている値を取得します。コンテナ型の場合自分自身のインスタンスを返します。
        /// </summary>
        public object Value
        {
            get
            {
                //TODO: signatureを見るとFloatとかIntの曖昧性が消せるのかもしれないので要調査
                var vk = ValueKind;
                switch (vk)
                {
                    case QiValueKind.QiInt:
                        long result_long = 0;
                        if (QiApiValue.GetInt64(this, ref result_long))
                        {
                            return result_long;
                        }
                        ulong result_ulong = 0;
                        QiApiValue.GetUInt64(this, ref result_ulong);
                        return result_ulong;

                    case QiValueKind.QiFloat:
                        double result_double = 0.0;
                        if (QiApiValue.GetDouble(this, ref result_double))
                        {
                            return result_double;
                        }
                        float result_float = 0.0f;
                        QiApiValue.GetFloat(this, ref result_float);
                        return result_float;

                    case QiValueKind.QiRaw: return QiApiValue.GetRaw(this);
                    case QiValueKind.QiString: return QiApiValue.GetString(this);
                    case QiValueKind.QiDynamic: return QiApiValue.GetDynamic(this);
                    case QiValueKind.QiObject: return QiApiValue.GetObject(this);
                    case QiValueKind.QiVoid: return null;

                    //コンテナの場合
                    default:
                        return this;
                }
                throw new NotImplementedException();
            }
        }

        #region 関数名によって型を区別したいときの為に。
        public bool GetBool() => Convert.ToBoolean(GetValue(0L));

        public sbyte GetSByte() => Convert.ToSByte(GetValue(0L));
        public short GetInt16() => Convert.ToInt16(GetValue(0L));
        public int GetInt32() => Convert.ToInt32(GetValue(0L));
        public long GetInt64() => Convert.ToInt64(GetValue(0L));
        public byte GetByte() => Convert.ToByte(GetValue(0UL));
        public ushort GetUInt16() => Convert.ToUInt16(GetValue(0UL));
        public uint GetUInt32() => Convert.ToUInt32(GetValue(0UL));
        public ulong GetUInt64() => Convert.ToUInt64(GetValue(0UL));

        public float GetFloat() => QiApiValue.GetFloatWithDefault(this, 0.0f);
        public double GetDouble() => QiApiValue.GetDoubleWithDefault(this, 0.0);

        public string GetString() => QiApiValue.GetString(this);
        public byte[] GetRaw() => QiApiValue.GetRaw(this);
        public QiValue GetDynamic() => QiApiValue.GetDynamic(this);
        public QiObject GetObject() => QiApiValue.GetObject(this);
        #endregion

        public long GetValue(long defaultValue) => QiApiValue.GetInt64WithDefault(this, defaultValue);
        public ulong GetValue(ulong defaultValue) => QiApiValue.GetUInt64WithDefault(this, defaultValue);
        public float GetValue(float defaultValue) => QiApiValue.GetFloatWithDefault(this, defaultValue);
        public double GetValue(double defaultValue) => QiApiValue.GetDoubleWithDefault(this, defaultValue);

        public bool SetValue(long v) => QiApiValue.SetInt64(this, v);
        public bool SetValue(ulong v) => QiApiValue.SetUInt64(this, v);
        public bool SetValue(float v) => QiApiValue.SetFloat(this, v);
        public bool SetValue(double v) => QiApiValue.SetDouble(this, v);
        public bool SetValue(string v) => QiApiValue.SetString(this, v);

        public bool SetValue(QiValue v) => QiApiValue.SetDynamic(this, v);
        public bool SetValue(QiObject obj) => QiApiValue.SetObject(this, obj);

        /// <summary>
        /// Rawデータにバイナリを設定します。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool SetValue(byte[] data) => QiApiValue.SetRaw(this, data);

        /// <summary>
        /// リストに要素を追加します。
        /// </summary>
        /// <param name="value">追加する値</param>
        /// <returns></returns>
        public bool AddElement(QiValue value)
        {
            if (ValueKind != QiValueKind.QiList)
            {
                throw new InvalidOperationException("this QiValue is not QiList");
            }
            return QiApiValue.AddList(this, value);
        }

        /// <summary>
        /// 連想配列のキー一覧を取得します。
        /// </summary>
        /// <returns>キー一覧</returns>
        public QiValue GetKeys()
        {
            if (ValueKind != QiValueKind.QiMap)
            {
                throw new InvalidOperationException("This QiValue is not QiMap");
            }
            return QiApiValue.KeysMap(this);
        }

        /// <summary>
        /// リスト、連想配列、タプルの要素数を取得します。それ以外の値の場合0を返します。
        /// </summary>
        public int Count
        {
            get
            {
                var kind = ValueKind;
                return kind == QiValueKind.QiTuple ? QiApiValue.SizeTuple(this) :
                       kind == QiValueKind.QiList ? QiApiValue.SizeList(this) :
                       kind == QiValueKind.QiMap ? (int)QiApiValue.SizeMap(this) :
                       0;
            }
        }

        /// <summary>
        /// リストまたはタプルにインデクスでアクセスします。境界チェックは行われません。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public QiValue this[int index]
        {
            //TODO: Map型でキーが整数だった場合、とかどう思いますかね
            get
            {
                switch (ValueKind)
                {
                    case QiValueKind.QiList:
                        return QiApiValue.GetList(this, (uint)index);
                    case QiValueKind.QiTuple:
                        return QiApiValue.GetTuple(this, (uint)index);
                    default:
                        throw new InvalidOperationException("QiValue is neither list or tuple");
                }
            }
            set
            {
                switch (ValueKind)
                {
                    case QiValueKind.QiList:
                        QiApiValue.SetList(this, (uint)index, value);
                        return;
                    case QiValueKind.QiTuple:
                        QiApiValue.SetTuple(this, (uint)index, value);
                        return;
                    default:
                        throw new InvalidOperationException("QiValue is neither list or tuple");
                }
            }
        }

        /// <summary>
        /// 連想配列にキー要素でアクセスします。キーが連想配列に含まれるかどうかはチェックされません。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public QiValue this[QiValue key]
        {
            get
            {
                if (ValueKind != QiValueKind.QiMap)
                {
                    throw new InvalidOperationException("This QiValue is not QiMap");
                }
                return QiApiValue.GetMap(this, key);
            }
            set
            {
                if (ValueKind != QiValueKind.QiMap)
                {
                    throw new InvalidOperationException("This QiValue is not QiMap");
                }
                QiApiValue.SetMap(this, key, value);
            }
        }

        /// <summary>
        /// 指定された型のデータの取得を試みます。
        /// 失敗した場合は<see cref="ArgumentException"/>が送出されます。
        /// </summary>
        /// <typeparam name="T">取り出したい値の型</typeparam>
        /// <returns>成功した場合その値の型</returns>
        /// <exception cref="ArgumentException"/>
        public T TryGet<T>()
        {
            var t = typeof(T);
            switch(Type.GetTypeCode(t))
            {
                case TypeCode.Boolean:
                    return (T)Convert.ChangeType(GetBool(), t);
                case TypeCode.SByte:
                    return (T)Convert.ChangeType(GetSByte(), t);
                case TypeCode.Int16:
                    return (T)Convert.ChangeType(GetInt16(), t);
                case TypeCode.Int32:
                    return (T)Convert.ChangeType(GetInt32(), t);
                case TypeCode.Int64:
                    return (T)Convert.ChangeType(GetInt64(), t);
                case TypeCode.Byte:
                    return (T)Convert.ChangeType(GetByte(), t);
                case TypeCode.UInt16:
                    return (T)Convert.ChangeType(GetUInt16(), t);
                case TypeCode.UInt32:
                    return (T)Convert.ChangeType(GetUInt32(), t);
                case TypeCode.UInt64:
                    return (T)Convert.ChangeType(GetUInt64(), t);
                case TypeCode.String:
                    return (T)Convert.ChangeType(GetString(), t);
                default:
                    break;
            }
            //組み込み型以外のケース: とりあえず標準ケースとしてIEnumerable<組み込み>だけサポートしますかね。



            throw new ArgumentException("Given type parameter is not supported currently");

        }


        #endregion



        /// <summary>文字列データとしてオブジェクトの階層構造を出力します。</summary>
        /// <returns>文字列でダンプされた出力</returns>
        public string Dump(int indentStep = 2, int indentStart = 0)
        {
            var kind = ValueKind;
            string indent = new string(Enumerable.Repeat(' ', indentStart).ToArray());
            string largeIndent = new string(Enumerable.Repeat(' ', indentStart + indentStep).ToArray());

            //組み込み型は単に値出せばOK
            if (new QiValueKind[] { QiValueKind.QiInt, QiValueKind.QiFloat, QiValueKind.QiString }.Contains(kind))
            {
                return indent + kind.ToString() + ":" + Value.ToString();
            }

            //コンテナ型
            if (kind == QiValueKind.QiDynamic)
            {
                return indent + "Dynamic\n" + (Value as QiValue).Dump(indentStep, indentStart + indentStep);
            }

            if (kind == QiValueKind.QiObject)
            {
                return indent + "Object\n" + (Value as QiObject).GetMetaObject().Dump(indentStep, indentStart + indentStep);
            }

            if (kind == QiValueKind.QiList || kind == QiValueKind.QiTuple)
            {
                int c = Count;

                var result = new StringBuilder();
                result.Append(indent);
                if (kind == QiValueKind.QiList)
                {
                    result.Append("List");
                    if(Count > 0)
                    {
                        result.Append($"<{this[0].GetQiType().TypeKind}>");
                    }
                    else
                    {
                        result.Append("<Empty>");
                    }
                    result.Append($"[{c}]\n");
                }
                else
                {
                    result.Append($"Tuple[{c}]:\n");
                }

                for (int i = 0; i < Count; i++)
                {
                    result.Append(this[i].Dump(indentStep, indentStart + indentStep) + "\n");
                }
                return result.ToString();
            }

            if (kind == QiValueKind.QiMap)
            {
                //keysはリスト固定っぽいね
                var keys = GetKeys();
                int c = keys.Count;

                var result = new StringBuilder();
                result.Append(
                    indent + 
                    $"Map<key:{GetQiType().GetMapKeyType().TypeKind}, value:{GetQiType().GetMapValueType().TypeKind}>[{c}]\n"
                    );

                for (int i = 0; i < c; i++)
                {
                    var key = keys[i];
                    result.Append(largeIndent + "Key:\n" + key.Dump(indentStep, indentStart + indentStep * 2) + "\n");
                    result.Append(largeIndent + "Value:\n" + this[key].Dump(indentStep, indentStart + indentStep * 2) + "\n");
                }
                return result.ToString();
            }

            //ポインタとかバイナリは適切な表示法が特に無いので種類名だけ表示
            return indent + kind.ToString();
        }

        /// <summary>Qi Frameworkへ登録する関数についての、戻り値が無いことを示す値を取得します。</summary>
        public static QiValue Void => Create(QiSignatures.TypeVoid);

    }

}
