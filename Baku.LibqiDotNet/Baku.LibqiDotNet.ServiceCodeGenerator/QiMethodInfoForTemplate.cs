using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    public class QiMethodInfoForTemplate
    {
        public QiMethodInfoForTemplate(QiValue methodInfo)
        {
            Id = methodInfo[0].ToInt64();

            ReturnValueSignature = QiSig2CSharpSig
                .GetReturnSignature(methodInfo[1].ToString());

            MethodName = methodInfo[2].ToString();

            Description = RemoveNewLine(methodInfo[4].ToString());

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


                argDescs[i] = (argInfo.Count > i) ? RemoveNewLine(argInfo[i][1].ToString()) : $"";
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

            ReturnDescription = RemoveNewLine(methodInfo[6].ToString());
        }

        public long Id { get; }

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


        private string RemoveNewLine(string s) => s.Replace("\n", "").Replace("\r", "");

    }

}
