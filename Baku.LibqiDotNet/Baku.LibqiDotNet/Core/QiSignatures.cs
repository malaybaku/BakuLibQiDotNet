using System;
using System.Collections.Generic;
using System.Linq;

//参考元: http://doc.aldebaran.com/libqi/api/cpp/type/signature.html


namespace Baku.LibqiDotNet
{
    /// <summary>Qiの値型を表す文字列の一覧</summary>
    public static class QiSignatures
    {

        public static readonly string TypeNone = "_";
        public static readonly string TypeVoid = "v";

        //number
        public static readonly string TypeBool = "b";
        public static readonly string TypeInt8 = "c";
        public static readonly string TypeUInt8 = "C";
        public static readonly string TypeInt16 = "w";
        public static readonly string TypeUInt16 = "W";
        public static readonly string TypeInt32 = "i";
        public static readonly string TypeUInt32 = "I";
        public static readonly string TypeInt64 = "l";
        public static readonly string TypeUInt64 = "L";

        public static readonly string TypeFloat = "f";
        public static readonly string TypeDouble = "d";

        //string
        public static readonly string TypeString = "s";

        //container
        public static readonly string TypeListBegin = "[";
        public static readonly string TypeListEnd = "]";
        public static readonly string TypeMapBegin = "{";
        public static readonly string TypeMapEnd = "}";
        public static readonly string TypeTupleBegin = "(";
        public static readonly string TypeTupleEnd = ")";

        public static readonly string TypeDynamic = "m";
        public static readonly string TypeRaw = "r";
        public static readonly string TypePointer = "*";
        public static readonly string TypeObject = "o";

        //
        public static readonly string TypeVarArgs = "#";
        public static readonly string TypeKwArgs = "~";
        public static readonly string TypeUnknown = "X";

        public static readonly string MethodNameSuffix = "::";

    }

    public static class QiSignatureValidityChecker
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
                string.Concat(args.Select(a => a.Signature))
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

            throw new InvalidOperationException(
                $"could not found signature token properly: {src}"
                );

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
