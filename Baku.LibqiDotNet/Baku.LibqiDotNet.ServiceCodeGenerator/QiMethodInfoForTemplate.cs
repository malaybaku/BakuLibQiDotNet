using System.Collections.Generic;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    public class QiMethodInfoForTemplate
    {
        public QiMethodInfoForTemplate(QiValue methodInfo)
        {
            Id = methodInfo[0].ToInt64();

            ReturnValueSignature = QiSig2CSharpSig
                .GetReturnSignature(methodInfo[1].ToString());

            OriginalMethodName = methodInfo[2].ToString();
            MethodName = GetModifiedMethodName(methodInfo[2].ToString());

            Description = XmlCommentize(methodInfo[4].ToString());

            ArgumentCount = QiSig2CSharpSig.GetArgCount(methodInfo[3].ToString());


            var argInfo = methodInfo[5];
            var argNames = new string[ArgumentCount];
            var argDescs = new string[ArgumentCount];
            for (int i = 0; i < ArgumentCount; i++)
            {
                //アンダースコアを前置するのは予約語とうっかり競合するのを防止するため
                argNames[i] =
                    (argInfo.Count > i && !string.IsNullOrWhiteSpace(argInfo[i][0].ToString())) ?
                    $"arg{i}_" + argInfo[i][0].ToString().Replace(" ", "") :
                    $"arg{i}";


                argDescs[i] = (argInfo.Count > i) ? XmlCommentize(argInfo[i][1].ToString()) : $"";
            }
            ArgumentNames = argNames;
            ArgumentDescriptions = argDescs;

            ArgumentDeclaration = QiSig2CSharpSig.GetExpandedArgDeclaration(
                methodInfo[3].ToString(),
                ArgumentNames
                );
            ArgumentUsage = QiSig2CSharpSig.GetExpandedArgUsage(
                methodInfo[3].ToString(),
                ArgumentNames
                );


            ReturnExpression = QiSig2CSharpSig.GetReturnWordAndCast(ReturnValueSignature);

            ReturnDescription = XmlCommentize(methodInfo[6].ToString());
        }

        public long Id { get; }

        public string OriginalMethodName { get; }
        public string MethodName { get; }
        public IReadOnlyList<string> ArgumentNames { get; }


        public string Description { get; }
        public IReadOnlyList<string> ArgumentDescriptions { get; }
        public string ReturnDescription { get; }


        public string ReturnValueSignature { get; }

        public string ReturnExpression { get; }

        public string ArgumentDeclaration { get; }

        public string ArgumentUsage { get; }

        public int ArgumentCount { get; }

        //メソッド名をパスカル記法に直す。これはC#流にするためでもあるが
        //予約語と衝突する("event"とか)関数名の定義を回避するためでもある。まあ大文字でも問題になる時はなるんだけどね。
        private string GetModifiedMethodName(string originalName)
        {
            return originalName[0].ToString().ToUpper() + originalName.Substring(1);
        }

        //XMLドキュメントコメントに不適切な文字を消す
        public static string XmlCommentize(string s) 
            => s.Replace("\n", "")
            .Replace("\r", "")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;");

    }

}
