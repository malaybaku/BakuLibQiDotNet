using System;
using System.Linq;

//参考元: http://doc.aldebaran.com/libqi/api/cpp/type/signature.html


namespace Baku.LibqiDotNet
{
    /// <summary>Qiの値型を表す文字列の一覧</summary>
    public static class QiSignatures
    {
        /// <summary>None型(通常は使用されないはず)</summary>
        public static readonly string TypeNone = "_";
        /// <summary>関数に戻り値が無いことを示す型</summary>
        public static readonly string TypeVoid = "v";

        /// <summary>論理値型</summary>
        public static readonly string TypeBool = "b";
        /// <summary>符号あり1バイト整数型</summary>
        public static readonly string TypeInt8 = "c";
        /// <summary>符号なし1バイト整数型</summary>
        public static readonly string TypeUInt8 = "C";
        /// <summary>符号あり2バイト整数型</summary>
        public static readonly string TypeInt16 = "w";
        /// <summary>符号なし2バイト整数型</summary>
        public static readonly string TypeUInt16 = "W";
        /// <summary>符号あり4バイト整数型</summary>
        public static readonly string TypeInt32 = "i";
        /// <summary>符号なし4バイト整数型</summary>
        public static readonly string TypeUInt32 = "I";
        /// <summary>符号あり8バイト整数型</summary>
        public static readonly string TypeInt64 = "l";
        /// <summary>符号なし8バイト整数型</summary>
        public static readonly string TypeUInt64 = "L";
        /// <summary>4バイト小数型</summary>
        public static readonly string TypeFloat = "f";
        /// <summary>8バイト小数型</summary>
        public static readonly string TypeDouble = "d";

        /// <summary>文字列型</summary>
        public static readonly string TypeString = "s";

        /// <summary>配列型の開き括弧</summary>
        public static readonly string TypeListBegin = "[";
        /// <summary>配列型の閉じ括弧</summary>
        public static readonly string TypeListEnd = "]";
        /// <summary>マップ型の開き括弧</summary>
        public static readonly string TypeMapBegin = "{";
        /// <summary>マップ型の閉じ括弧</summary>
        public static readonly string TypeMapEnd = "}";
        /// <summary>タプル型の開き括弧</summary>
        public static readonly string TypeTupleBegin = "(";
        /// <summary>タプル型の閉じ括弧</summary>
        public static readonly string TypeTupleEnd = ")";
        /// <summary>動的型</summary>
        public static readonly string TypeDynamic = "m";
        /// <summary>バイナリ型</summary>
        public static readonly string TypeRaw = "r";
        /// <summary>ポインタ型</summary>
        public static readonly string TypePointer = "*";
        /// <summary>オブジェクト型</summary>
        public static readonly string TypeObject = "o";

        /// <summary>可変長引数型</summary>
        public static readonly string TypeVarArgs = "#";
        /// <summary>可変長マップ引数型</summary>
        public static readonly string TypeKwArgs = "~";
        /// <summary>未知の型(エラーを表す場合もある)</summary>
        public static readonly string TypeUnknown = "X";

        /// <summary>メソッド名と引数、戻り値シグネチャを区切る文字列</summary>
        public static readonly string MethodNameSuffix = "::";

    }

    internal static class QiSignatureValidityChecker
    {
        /// <summary>
        /// メソッドの引数リストと実際に渡す予定の引数を比較し、妥当な対応が取れているかを確認します。
        /// </summary>
        /// <param name="signature">ターゲットのシグネチャ(全体を囲うタプルの丸括弧を含む)</param>
        /// <param name="args">実際の引数のシグネチャ</param>
        /// <returns></returns>
        public static bool CheckValidity(string signature, QiAnyValue[] args)
            => CheckValiditySubroutine(
                signature.Substring(1, signature.Length - 2),
                string.Join("", args.Select(a => a.Signature).ToArray())
                );

        private static bool CheckValiditySubroutine(string methodSignature, string argsSignature)
        {
            //ダイナミック要素の無いシグネチャはこれで素早く評価
            if (methodSignature == argsSignature) return true;

            //シンプルに先頭から調べる
            if (methodSignature == "" && argsSignature == "") return true;
            if (methodSignature == "" && argsSignature != "") return false;
            if (methodSignature != "" && argsSignature == "") return false;


            bool success;
            string msig = GetHeadToken(methodSignature, out success);
            if (!success) return false;

            string asig = GetHeadToken(argsSignature, out success);
            if (!success) return false;

            if (msig == QiSignatures.TypeDynamic)
            {
                return CheckValiditySubroutine(methodSignature.Substring(1), argsSignature.Substring(asig.Length));
            }

            if (msig.Length == 1)
            {
                //組み込み型の場合
                return msig == asig ?
                    CheckValiditySubroutine(methodSignature.Substring(1), argsSignature.Substring(1)) :
                    false;
            }
            else
            {
                //リストの場合, 外側ひっぺがして内側を比較したあとで次に進む
                return (
                    msig.Length > 1 &&
                    asig.Length > 1 &&
                    CheckValiditySubroutine(msig.Substring(1, msig.Length - 2), asig.Substring(1, asig.Length - 2))
                    ) ?
                    CheckValiditySubroutine(methodSignature.Substring(msig.Length), argsSignature.Substring(asig.Length)) :
                    false;
            }
        }

        //シグネチャ文字列の先頭からトークン(普通の変数or配列シグネチャ)を得る
        //TODO: 再帰正規表現を使うともっとキレイに書けるはず(だが今回あまり長い文字列を扱わないので速度差は無さそう)
        private static string GetHeadToken(string src, out bool success)
        {
            string s = src[0].ToString();
            if (s == QiSignatures.TypeDynamic || EmbeddedTypeQiSignatures.Contains(s))
            {
                success = true;
                return s;
            }

            if (s == QiSignatures.TypeListBegin)
            {
                int x = 1;
                int index = -1;
                for (int i = 1; i < src.Length; i++)
                {
                    x += src[i] == QiSignatures.TypeListEnd[0] ? -1 :
                         src[i] == QiSignatures.TypeListBegin[0] ? 1 :
                         0;
                    if (x == 0)
                    {
                        index = i;
                        break;
                    }
                }
                //シグネチャ側の書き間違い等でリストシグネチャが閉じてない場合
                if (index == -1)
                {
                    success = false;
                    return "";
                }
                else
                {
                    success = true;
                    return src.Substring(0, index + 1);
                }
            }

            throw new InvalidOperationException($"could not found signature token properly: {src}");

        }

        private static readonly string[] EmbeddedTypeQiSignatures = new[]
        {
            QiSignatures.TypeBool,
            QiSignatures.TypeInt8,
            QiSignatures.TypeInt16,
            QiSignatures.TypeInt32,
            QiSignatures.TypeInt64,
            QiSignatures.TypeUInt8,
            QiSignatures.TypeUInt16,
            QiSignatures.TypeUInt32,
            QiSignatures.TypeUInt64,
            QiSignatures.TypeFloat,
            QiSignatures.TypeDouble,
            QiSignatures.TypeString
        };



    }


}
