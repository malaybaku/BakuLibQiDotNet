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

        public QiValueKind ValueKind => QiApiValue.GetKind(this);

        public string GetSignature(int resolveDynamics = 0) => QiApiValue.GetSignature(this, resolveDynamics);

        public void Reset(string signature) => QiApiValue.Reset(this, signature);

        public QiType GetQiType() => QiApiValue.GetQiType(this);

        public void Destroy() => QiApiValue.Destroy(this);
        public QiValue Copy() => GetCopy(this);

        public static QiValue Create(string sig) => QiApiValue.Create(sig);
        public static QiValue GetCopy(QiValue src) => QiApiValue.Copy(src);
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

        public bool SetValue(byte[] data, int size) => QiApiValue.SetRaw(this, data, size);
        public bool SetValue(byte[] data) => SetValue(data, data.Length);

        public bool AddElement(QiValue value)
        {
            if (ValueKind != QiValueKind.QiList)
            {
                throw new InvalidOperationException("this QiValue is not QiList");
            }
            return QiApiValue.AddList(this, value);
        }

        public QiValue GetKeys()
        {
            if (ValueKind != QiValueKind.QiMap)
            {
                throw new InvalidOperationException("This QiValue is not QiMap");
            }
            return QiApiValue.KeysMap(this);
        }

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

            //ポインタとかは再帰してもアレなので。
            return kind.ToString();
        }
    }

}
