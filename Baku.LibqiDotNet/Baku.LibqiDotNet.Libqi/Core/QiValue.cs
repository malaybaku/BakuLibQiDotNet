using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Baku.LibqiDotNet.Libqi.QiApi;

namespace Baku.LibqiDotNet.Libqi
{
    /// <summary>Qiの一般的な値を表します。この値はAPIの入出力いずれにも使われます。</summary>
    public sealed class QiValue : IQiResult
    {
        internal QiValue(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        #region 基本処理

        /// <summary>値の種類を取得します。</summary>
        public QiValueKind ValueKind => QiApiValue.GetKind(this);

        /// <summary>値の種類を取得しますが、動的型については中身の型の種類を取得します。</summary>
        public QiValueKind ContentValueKind => NonDynamicValue.ValueKind;

        /// <summary>値のシグネチャを取得します。</summary>
        /// <param name="resolveDynamics">シグネチャの解決法フラグ(サンプル見た限り既定値以外を使うように見えない)</param>
        /// <returns>値のシグネチャ</returns>
        public string GetSignature(bool resolveDynamics=false) => QiApiValue.GetSignature(this, Convert.ToInt32(resolveDynamics));

        /// <summary>値のシグネチャを取得しますが、動的型の場合中身のシグネチャを取得します。</summary>
        /// <param name="resolveDynamics">シグネチャの解決法フラグ(サンプル見た限り既定値以外を使うように見えない)</param>
        /// <returns>値のシグネチャ</returns>
        public string GetContentSignature(bool resolveDynamics = false) => NonDynamicValue.GetSignature(resolveDynamics);

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

        /// <summary>型情報を取得しますが、動的型の場合中身の型情報を取得します。</summary>
        /// <returns>インスタンスに対応する型情報</returns>
        public QiType GetContentQiType() => NonDynamicValue.GetQiType();

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

        #region Getter / Setter Functions

        /// <summary>格納されている値を取得します。コンテナ型の場合自分自身のインスタンスを返します。</summary>
        public object Value
        {
            get
            {
                //TODO: signatureをきちんと見たらFloatとかIntの曖昧性が消せるのかもしれないので要調査
                var vk = ValueKind;
                switch (vk)
                {
                    case QiValueKind.QiInt:
                        long resultLong = 0;
                        if (QiApiValue.GetInt64(this, ref resultLong))
                        {
                            return resultLong;
                        }
                        return ToUInt64();

                    case QiValueKind.QiFloat:
                        double resultDouble = 0.0;
                        if (QiApiValue.GetDouble(this, ref resultDouble))
                        {
                            return resultDouble;
                        }
                        return ToFloat();

                    case QiValueKind.QiRaw: return QiApiValue.GetRaw(this);
                    case QiValueKind.QiString: return QiApiValue.GetString(this);
                    case QiValueKind.QiDynamic: return QiApiValue.GetDynamic(this);
                    case QiValueKind.QiObject: return QiApiValue.GetObject(this);
                    case QiValueKind.QiVoid: return null;

                    //コンテナの場合
                    default:
                        return this;
                }
            }
        }

        #region Getter
 
        /// <summary>格納されているはずのbool値を取得します。</summary>
        /// <returns>格納されたbool値</returns>
        public bool ToBool() => Convert.ToBoolean(GetValue(0L));
        /// <summary>この変数が符号あり1バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public sbyte ToSByte() => (sbyte)GetValue(0L);
        /// <summary>この変数が符号あり2バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public short ToInt16() => (short)GetValue(0L);
        /// <summary>この変数が符号あり4バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public int ToInt32() => (int)GetValue(0L);
        /// <summary>この変数が符号あり8バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public long ToInt64() => GetValue(0L);
        /// <summary>この変数が符号なし1バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public byte ToByte() => (byte)GetValue(0UL);
        /// <summary>この変数が符号なし2バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public ushort ToUInt16() => (ushort)GetValue(0UL);
        /// <summary>この変数が符号なし4バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public uint ToUInt32() => (uint)GetValue(0UL);
        /// <summary>この変数が符号なし8バイト整数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public ulong ToUInt64() => GetValue(0UL);

        /// <summary>この変数が単精度小数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public float ToFloat() => QiApiValue.GetFloatWithDefault(NonDynamicValue, 0.0f);
        /// <summary>この変数が倍精度小数型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public double ToDouble() => QiApiValue.GetDoubleWithDefault(NonDynamicValue, 0.0);

        /// <summary>この変数がバイナリデータ型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public byte[] ToBytes() => QiApiValue.GetRaw(NonDynamicValue);

        /// <summary>この変数が文字列型である場合はその値、そうでない場合は保持している値の型を表す文字列を取得します。</summary>
        /// <returns>格納された値</returns>
        public override string ToString() => (ContentValueKind == QiValueKind.QiString) ?
            QiApiValue.GetString(NonDynamicValue) :
            ContentValueKind.ToString();

        public string ToQiString() 
            => (ContentValueKind == QiValueKind.QiString) ? QiApiValue.GetString(NonDynamicValue) : "";

        /// <summary>この変数がオブジェクト型であると想定して値を取得します。</summary>
        /// <returns>格納された値</returns>
        public IQiObject GetObject() => QiApiValue.GetObject(NonDynamicValue);

        /// <summary>この変数がダイナミック型であると想定し、内側に格納している値を取り出します。</summary>
        /// <returns>動的型の中に格納された値</returns>
        internal QiValue GetDynamic() => QiApiValue.GetDynamic(this);

        #endregion

        #region Setter

        /// <summary>この変数が符号あり整数型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(long v) => QiApiValue.SetInt64(NonDynamicValue, v);
        /// <summary>この変数が符号なし整数型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(ulong v) => QiApiValue.SetUInt64(NonDynamicValue, v);
        /// <summary>この変数が単精度小数型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(float v) => QiApiValue.SetFloat(NonDynamicValue, v);
        /// <summary>この変数が倍精度小数型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(double v) => QiApiValue.SetDouble(NonDynamicValue, v);
        /// <summary>この変数が文字列型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(string v) => QiApiValue.SetString(NonDynamicValue, v);

        /// <summary>この変数が動的型であると想定し、値を設定します。</summary>
        /// <param name="v">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(QiValue v) => QiApiValue.SetDynamic(this, v);
        /// <summary>この変数がオブジェクト型であると想定し、値を設定します。</summary>
        /// <param name="obj">設定する値</param>
        /// <returns>設定に成功した場合はtrue</returns>
        public bool SetValue(QiObject obj) => QiApiValue.SetObject(NonDynamicValue, obj);

        /// <summary>Rawデータ型の変数にバイナリを設定します。</summary>
        /// <param name="data">設定するバイナリデータ</param>
        /// <returns>設定に成功したかどうか</returns>
        public bool SetValue(byte[] data) => QiApiValue.SetRaw(NonDynamicValue, data);

        #endregion

        #region Container functions

        /// <summary>リスト、連想配列、タプルの要素数を取得します。それ以外の値の場合0を返します。</summary>
        public int Count
        {
            get
            {
                var kind = ContentValueKind;
                return kind == QiValueKind.QiTuple ? QiApiValue.SizeTuple(NonDynamicValue) :
                       kind == QiValueKind.QiList ? QiApiValue.SizeList(NonDynamicValue) :
                       kind == QiValueKind.QiMap ? (int)QiApiValue.SizeMap(NonDynamicValue) :
                       0;
            }
        }

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
            if (ContentValueKind != QiValueKind.QiMap)
            {
                throw new InvalidOperationException("This QiValue is not QiMap");
            }
            return QiApiValue.KeysMap(NonDynamicValue);
        }

        /// <summary>リストまたはタプルにインデクスでアクセスします。境界チェックは行われません。</summary>
        /// <param name="index">取得したい要素のインデックス</param>
        /// <returns>指定した要素</returns>
        public IQiResult this[int index]
        {
            //TODO: Map型でキーが整数だった場合、とかどう思いますかね
            get
            {
                switch (ContentValueKind)
                {
                    case QiValueKind.QiList:
                        return QiApiValue.GetList(NonDynamicValue, (uint)index);
                    case QiValueKind.QiTuple:
                        return QiApiValue.GetTuple(NonDynamicValue, (uint)index);
                    default:
                        throw new InvalidOperationException("QiValue is neither list or tuple");
                }
            }
            set
            {
                var qv = value as QiValue;
                if (qv == null)
                {
                    throw new InvalidOperationException("value type is not 'Baku.LibqiDotNet.Libqi.QiValue'");
                }

                switch (ContentValueKind)
                {
                    case QiValueKind.QiList:
                        QiApiValue.SetList(NonDynamicValue, (uint)index, qv);
                        return;
                    case QiValueKind.QiTuple:
                        QiApiValue.SetTuple(NonDynamicValue, (uint)index, qv);
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
        public IQiResult this[IQiResult key]
        {
            get
            {
                if (!(key is QiValue))
                {
                    throw new InvalidOperationException("key actual type is not 'Baku.LibqiDotNet.Libqi.QiValue'");
                }

                if (ContentValueKind != QiValueKind.QiMap)
                {
                    throw new InvalidOperationException("This QiValue is not QiMap");
                }

                return QiApiValue.GetMap(NonDynamicValue, key as QiValue);
            }
            set
            {
                if (!(key is QiValue) || !(value is QiValue))
                {
                    throw new InvalidOperationException("key or value is not 'Baku.LibqiDotNet.Libqi.QiValue'");
                }

                if (ContentValueKind != QiValueKind.QiMap)
                {
                    throw new InvalidOperationException("This QiValue is not QiMap");
                }
                QiApiValue.SetMap(NonDynamicValue, key as QiValue, value as QiValue);
            }
        }

        /// <summary>保持しているデータが連想配列である場合、キー/値ペアのうちキーの一覧を取得します。</summary>
        public IEnumerable<IQiResult> Keys
        {
            get
            {
                if (ContentValueKind != QiValueKind.QiMap)
                {
                    return new QiValue[0];
                }

                var keys = GetKeys();
                return Enumerable
                    .Range(0, Count)
                    .Select(i => keys[i]);
            }
        }

        /// <summary>保持しているデータが連想配列である場合、キー/値ペアの一覧を取得します。</summary>
        public IEnumerable<KeyValuePair<IQiResult, IQiResult>> MapItems
            => Keys.Select(k => new KeyValuePair<IQiResult, IQiResult>(k, this[k]));

        /// <summary>ダイナミック型を再帰的にアンパックし、ダイナミック型でない実際の内容を取得します。</summary>
        internal QiValue NonDynamicValue => ValueKind == QiValueKind.QiDynamic ?
            GetDynamic().NonDynamicValue :
            this;

        #endregion

        #endregion

        /// <summary>データの内部構造を文字列として取得します。</summary>
        /// <returns></returns>
        public string Dump() => Dump(2, 0);

        /// <summary>文字列データとしてオブジェクトの階層構造を出力します。</summary>
        /// <returns>文字列でダンプされた出力</returns>
        public string Dump(int indentStep, int indentStart)
        {
            var kind = ValueKind;
            string indent = new string(' ', indentStart);
            string largeIndent = new string(' ', indentStart + indentStep);

            //組み込み型
            if (new QiValueKind[] { QiValueKind.QiInt, QiValueKind.QiFloat, QiValueKind.QiString }.Contains(kind))
            {
                return indent + kind.ToString() + ":" + Value.ToString();
            }

            if (kind == QiValueKind.QiDynamic)
            {
                return indent + "Dynamic\n" + GetDynamic().Dump(indentStep, indentStart + indentStep);
            }

            //メタオブジェクトを吐く(通常使われない)
            if (kind == QiValueKind.QiObject)
            {
                return indent + "Object\n" + (GetObject() as QiObject).MetaObject.Dump(indentStep, indentStart + indentStep);
            }

            //リスト/タプルは要素別に表示するので作業が一部似てる
            if (kind == QiValueKind.QiList || kind == QiValueKind.QiTuple)
            {
                int c = Count;

                var result = new StringBuilder(indent);
                string typeinfo = (kind == QiValueKind.QiList) ?
                    $"List[{c}]:\n" :
                    $"Tuple[{c}]:\n";
                result.Append(typeinfo);

                for (int i = 0; i < c; i++)
                {
                    result.Append((this[i] as QiValue).Dump(indentStep, indentStart + indentStep) + "\n");
                }

                return result.ToString();
            }

            if (kind == QiValueKind.QiMap)
            {
                var pairs = MapItems.ToArray();

                var result = new StringBuilder();
                result.Append(
                    indent +
                    $"Map<key:{GetQiType().GetMapKeyType().TypeKind}, " +
                    $"value:{GetQiType().GetMapValueType().TypeKind}>[{pairs.Length}]\n"
                    );

                foreach(var p in pairs)
                {
                    result.Append(largeIndent + "Key:\n" + (p.Key as QiValue).Dump(indentStep, indentStart + indentStep * 2) + "\n");
                    result.Append(largeIndent + "Value:\n" + (p.Value as QiValue).Dump(indentStep, indentStart + indentStep * 2) + "\n");
                }
                return result.ToString();
            }

            //ポインタとかバイナリは適切な表示法が特に無いので種類名だけ表示
            return indent + kind.ToString();
        }

        /// <summary>Qi Frameworkへ登録する関数についての、戻り値が無いことを示す値を取得します。</summary>
        public static QiValue Void => Create(QiSignatures.TypeVoid);


        /// <summary>この変数が符号あり整数型であると想定し、失敗時のデフォルト値を指定して値を取得します。</summary>
        /// <param name="defaultValue">取得に失敗した場合返される値</param>
        /// <returns>成功した場合は実際の値、失敗した場合は指定したデフォルト値</returns>
        private long GetValue(long defaultValue) => QiApiValue.GetInt64WithDefault(NonDynamicValue, defaultValue);
        /// <summary>この変数が符号なし整数型であると想定し、失敗時のデフォルト値を指定して値を取得します。</summary>
        /// <param name="defaultValue">取得に失敗した場合返される値</param>
        /// <returns>成功した場合は実際の値、失敗した場合は指定したデフォルト値</returns>
        private ulong GetValue(ulong defaultValue) => QiApiValue.GetUInt64WithDefault(NonDynamicValue, defaultValue);

    }

}
