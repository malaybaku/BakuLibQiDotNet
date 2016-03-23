using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    /// <summary>qi FrameworkとBaku.LibqiDotNetのシグネチャを交換するための機能いろいろ</summary>
    public static class QiSig2CSharpSig
    {

        /// <summary>Qi Framework方式の型文字列を受け取り、適切な戻り値の型を文字列として取得する</summary>
        /// <param name="src">Qi Framework方式の表現による文字列</param>
        /// <returns>.NETの対応する型の文字列</returns>
        public static string GetReturnSignature(string src)
            => _returnSigs.ContainsKey(src) ? _returnSigs[src] :
            JudgeObjectTypeReturned(src) ? nameof(QiObject) :
            nameof(QiValue);

        /// <summary>関数の戻り値が<see cref="QiObject"/>型であるかどうかを判定します。</summary>
        /// <param name="src">戻り値のシグネチャ</param>
        /// <returns>戻り値が<see cref="QiObject"/>かどうか</returns>
        public static bool JudgeObjectTypeReturned(string src)
            => src == QiSignatures.TypeObject;

        /// <summary>
        /// 戻り値の型文字列に応じてreturnキーワードを入れたり明示キャストを使ったりする処理を文字列ベースで設定
        /// </summary>
        /// <param name="returnSig"><see cref="GetReturnSignature(string)"/>で得た戻り値の型</param>
        /// <returns>型に応じたreturn部分の適切な文頭表現</returns>
        public static string GetReturnWordAndCast(string returnSig)
            => (returnSig == "void") ? "" :
            (returnSig == nameof(QiValue) || returnSig == nameof(QiObject)) ? "return " :
            $"return ({returnSig})";

        /// <summary>
        /// 引数部分に入力する、型名と引数名の一覧を取得します。外側のカッコは含まれません。
        /// </summary>
        /// <param name="tupleArgSrc"></param>
        /// <param name="argNames"></param>
        /// <returns></returns>
        public static string GetExpandedArgDeclaration(string tupleArgSrc, IReadOnlyList<string> argNames)
            => string.Join(", ",
                GetArgSignatures(tupleArgSrc)
                    .Select((s, i) => $"{s} {argNames[i]}")
                );

        /// <summary>
        /// QiMethod.Callに渡す部分の文字列を生成します。外側のカッコは含まれません。
        /// </summary>
        /// <param name="tupleArgSrc"></param>
        /// <param name="argNames"></param>
        /// <returns></returns>
        public static string GetExpandedArgUsage(string tupleArgSrc, IReadOnlyList<string> argNames)
            => string.Join(", ",
                GetArgSignatures(tupleArgSrc)
                    .Select((s, i) => GetPreprocessedArg(s, argNames[i]))
                );

        public static int GetArgCount(string tupleArgSrc) => GetArgSignatures(tupleArgSrc).Length;

        private static string[] GetArgSignatures(string tupleArgSrc)
        {
            //フォーマット不正なのか、引数文字列がタプルで囲われずに"m"とかだけのやつがあるので対策
            tupleArgSrc = (tupleArgSrc.StartsWith("(")) ? tupleArgSrc : $"({tupleArgSrc})";

            return QiSignatureValidityChecker
                .SplitTupleSignatures(tupleArgSrc, true)
                .Select(src => GetArgSignature(src))
                .ToArray();
        }

        /// <summary>Qi Framework方式の型文字列を受け取り、適切な引数の型を文字列として取得する</summary>
        /// <param name="src">Qi Framework方式の表現による文字列</param>
        /// <returns>.NETの対応する型の文字列</returns>
        private static string GetArgSignature(string src)
            => _argumentSigs.ContainsKey(src) ?
            _argumentSigs[src] :
            nameof(QiAnyValue);

        /// <summary>IE型は配列に直るよう適切に変換し、QiMethod.Callに渡せる形式の引数表現を生成します。</token></summary>
        /// <param name="sig"><see cref="GetArgSignature"/>で取得した引数の型文字列</param>
        /// <param name="argName">引数の名前</param>
        /// <returns>QiList.Create(argName)またはargName</returns>
        private static string GetPreprocessedArg(string sig, string argName)
            => sig.StartsWith("IEnumerable") ?
            $"QiList.Create({argName})" :
            argName;

        static QiSig2CSharpSig()
        {
            _returnSigs = _embeddedSigs
                .Concat(_returnAdditionalSigs)
                .ToDictionary(p => p.Key, p => p.Value);

            _argumentSigs = _embeddedSigs
                .Concat(_argumentAdditionalSigs)
                .ToDictionary(p => p.Key, p => p.Value);

        }

        //戻り値の"void",または明示キャストが可能なもの一覧
        private static readonly Dictionary<string, string> _returnSigs;

        //引数として暗黙型変換を使って渡せるもの, またはIE<T>型でQiList.Createに渡せるもの一覧
        private static readonly Dictionary<string, string> _argumentSigs;

        private static readonly Dictionary<string, string> _embeddedSigs = new Dictionary<string, string>()
        {
            [QiSignatures.TypeBool] = "bool",
            [QiSignatures.TypeUInt8] = "byte",
            [QiSignatures.TypeUInt16] = "ushort",
            [QiSignatures.TypeUInt32] = "uint",
            [QiSignatures.TypeUInt64] = "ulong",
            [QiSignatures.TypeInt8] = "sbyte",
            [QiSignatures.TypeInt16] = "short",
            [QiSignatures.TypeInt32] = "int",
            [QiSignatures.TypeInt64] = "long",

            [QiSignatures.TypeFloat] = "float",
            [QiSignatures.TypeDouble] = "double",
            [QiSignatures.TypeString] = "string",
        };

        private static readonly Dictionary<string, string> _returnAdditionalSigs = new Dictionary<string, string>()
        {
            [QiSignatures.TypeVoid] = "void",
            [QiSignatures.TypeRaw] = "byte[]",

            [ListSigOf(QiSignatures.TypeInt32)] = "int[]",
            [ListSigOf(QiSignatures.TypeDouble)] = "double[]",
            [ListSigOf(QiSignatures.TypeString)] = "string[]"
        };

        private static readonly Dictionary<string, string> _argumentAdditionalSigs = new Dictionary<string, string>()
        {
            //nameof(IEnumerable<bool>)は"IEnumerable"に解決されるのでダメ
            [ListSigOf(QiSignatures.TypeBool)] = "IEnumerable<bool>",
            [ListSigOf(QiSignatures.TypeUInt8)] = "IEnumerable<byte>",
            [ListSigOf(QiSignatures.TypeUInt16)] = "IEnumerable<ushort>",
            [ListSigOf(QiSignatures.TypeUInt32)] = "IEnumerable<uint>",
            [ListSigOf(QiSignatures.TypeUInt64)] = "IEnumerable<ulong>",
            [ListSigOf(QiSignatures.TypeInt8)] = "IEnumerable<sbyte>",
            [ListSigOf(QiSignatures.TypeInt16)] = "IEnumerable<short>",
            [ListSigOf(QiSignatures.TypeInt32)] = "IEnumerable<int>",
            [ListSigOf(QiSignatures.TypeInt64)] = "IEnumerable<long>",

            [ListSigOf(QiSignatures.TypeFloat)] = "IEnumerable<float>",
            [ListSigOf(QiSignatures.TypeDouble)] = "IEnumerable<double>",
            [ListSigOf(QiSignatures.TypeString)] = "IEnumerable<string>",
        };



        private static string ListSigOf(string s)
            => QiSignatures.TypeListBegin + s + QiSignatures.TypeListEnd;
    }
}
