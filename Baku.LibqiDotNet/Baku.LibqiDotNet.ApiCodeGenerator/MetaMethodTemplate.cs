using System.Collections.Generic;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    /// <summary><see cref="MetaMethod"/>を整形してC#ソースに乗る形に直す</summary>
    public class MetaMethodTemplate
    {
        public MetaMethodTemplate(MetaMethod methodInfo)
        {
            _src = methodInfo;
            OriginalMethodName = _src.name; ;

            ReturnValueSignature = QiSig2CSharpSig.GetReturnSignature(_src.returnSignature);
            MethodName = GetModifiedMethodName(_src.name);

            Description = XmlCommentize(methodInfo.description);
            ReturnDescription = XmlCommentize(methodInfo.returnDescription);

            ArgumentCount = QiSig2CSharpSig.GetArgCount(methodInfo.parametersSignature);


            var argInfo = methodInfo.parameters ?? new List<MetaMethodParameter>();
            var argNames = new string[ArgumentCount];
            var argDescs = new string[ArgumentCount];
            for (int i = 0; i < ArgumentCount; i++)
            {
                //前置文字は予約語との競合防止
                argNames[i] =
                    (argInfo.Count > i && !string.IsNullOrWhiteSpace(argInfo[i].name)) ?
                    $"arg{i}_" + argInfo[i].name.Replace(" ", "") :
                    $"arg{i}";

                argDescs[i] = (argInfo.Count > i) ? XmlCommentize(argInfo[i].description) : "";
            }
            ArgumentNames = argNames;
            ArgumentDescriptions = argDescs;

            ArgumentDeclaration = QiSig2CSharpSig.GetExpandedArgDeclaration(
                methodInfo.parametersSignature,
                ArgumentNames
                );
            ArgumentUsage = QiSig2CSharpSig.GetExpandedArgUsage(
                methodInfo.parametersSignature,
                ArgumentNames
                );

        }

        private readonly MetaMethod _src;

        public uint Id => _src.uid;

        public string OriginalMethodName { get; }
        public string MethodName { get; }
        public string AsyncMethodName => MethodName + "Async";
        public IReadOnlyList<string> ArgumentNames { get; }


        public string Description { get; }
        public IReadOnlyList<string> ArgumentDescriptions { get; }
        public string ReturnDescription { get; }


        public string ReturnValueSignature { get; }

        public string ReturnExpression => (ReturnValueSignature != "void") ? "return " : "";

        public string ArgumentDeclaration { get; }

        public string ArgumentUsage { get; }

        public int ArgumentCount { get; }

        public string CallTypeTemplateOrEmpty 
            => (ReturnValueSignature != "void") ? $"<{ReturnValueSignature}>" : "";


        //メソッド名をパスカル記法に直す。これはC#流にするためでもあるが
        //予約語と衝突する("event"とか)関数名の定義を回避するためでもある。まあ大文字でも問題になる時はなるんだけどね。
        private string GetModifiedMethodName(string originalName)
            => originalName[0].ToString().ToUpper() + originalName.Substring(1);

        //XMLドキュメントコメントに不適切な文字を消す
        public static string XmlCommentize(string s)
            => s.Replace("\n", "")
            .Replace("\r", "")
            .Replace("&", "&amp;")
            .Replace("\"", "&quot;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;");
    }
}
