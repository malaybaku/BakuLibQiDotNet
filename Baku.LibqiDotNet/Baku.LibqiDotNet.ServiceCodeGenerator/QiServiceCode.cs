using System.Linq;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    //テンプレートコードで使うデータを生成するコードビハインド的な実装
    public partial class QiServiceTemplate
    {
        public QiServiceTemplate(string serviceName, QiValue metaObject)
        {
            QiMetaObject = metaObject;

            ServiceName = serviceName;
            ServiceDescription = metaObject[3].ToString().Replace("\n", "").Replace("\r", "");

            MethodInfos = QiMetaObject[0].MapValues
                .Select(mi => new QiMethodInfoForTemplate(mi))
                .ToArray();
        }

        public string ServiceName { get; }

        public string ServiceDescription { get; }

        public QiValue QiMetaObject { get; }

        /// <summary>メソッド情報の一覧</summary>
        public QiMethodInfoForTemplate[] MethodInfos { get; }

        public string GetArgumentXmlDocumentComment(string argName, string argDesc)
            => $"/// <param name=\"{argName}\">{argDesc}</param>";

    }
}
