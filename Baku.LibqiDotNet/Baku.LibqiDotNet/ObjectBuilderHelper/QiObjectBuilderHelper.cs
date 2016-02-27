namespace Baku.LibqiDotNet
{
    /// <summary>qiのセッションへサービスを登録する補助方法を実装します。</summary>
    public static class QiObjectBuilderHelper
    {
        /// <summary>サービス情報をもとに登録を行い、登録情報に対応したIDを返します。</summary>
        /// <param name="session">登録先のセッション</param>
        /// <param name="buildable">登録するサービス</param>
        /// <returns>登録情報に対応したID</returns>
        public static ulong RegisterService(this IQiBuildableObject buildable, QiSession session)
        {
            var objBuilder = QiObjectBuilder.Create();
            foreach(var method in buildable.GetMethods())
            {
                objBuilder.AdvertiseMethod(
                    method.MethodName + QiSignatures.MethodNameSuffix + method.Signature,
                    (sig, args) => method.Invoke(args)
                    );
            }

            return session
                .RegisterService(buildable.ServiceName, objBuilder.BuildObject())
                .GetUInt64(0UL);
        }
    }
}
