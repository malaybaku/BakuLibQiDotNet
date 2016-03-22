using System.Linq;

namespace Baku.LibqiDotNet.ServiceCodeGenerator
{
    //テンプレートコードで使うデータを生成するコードビハインド的な実装
    public partial class QiServiceTemplate
    {
        public QiServiceTemplate(string serviceName, MetaObject metaObject)
        {
            ServiceName = serviceName;
            ServiceDescription = MetaMethodTemplate.XmlCommentize(metaObject.description);

            MethodInfos = metaObject
                .methods
                .Select(mi => new MetaMethodTemplate(mi))
                .ToArray();
        }

        public string ServiceName { get; }

        public string ServiceDescription { get; }

        /// <summary>メソッド情報の一覧</summary>
        public MetaMethodTemplate[] MethodInfos { get; }

        public string GetArgumentXmlDocumentComment(string argName, string argDesc)
            => $"/// <param name=\"{argName}\">{argDesc}</param>";

    }
}
