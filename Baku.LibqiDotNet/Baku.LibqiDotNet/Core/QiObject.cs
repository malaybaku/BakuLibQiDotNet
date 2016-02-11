using System;
using Baku.LibqiDotNet.QiApi;
using System.Linq;

namespace Baku.LibqiDotNet
{
    /// <summary>Qiのオブジェクト(基本的にサービスモジュールと同じ)を表します。</summary>
    public class QiObject
    {
        internal QiObject(IntPtr handle)
        {
            Handle = handle;
        }

        internal IntPtr Handle { get; }

        //ObjectBuilderとGetServiceの戻り値以外でのインスタンス生成は不適切な気がするのでアセンブリ外に対し非公開化
        internal static QiObject Create() => QiApiObject.Create();

        private QiServiceInfo _serviceInfo = null;
        /// <summary>インスタンスに対応したサービス情報を取得します。</summary>
        public QiServiceInfo ServiceInfo
            => _serviceInfo ?? (_serviceInfo = new QiServiceInfo(this));

        /// <summary>インスタンスを破棄します。</summary>
        public void Destroy() => QiApiObject.Destroy(this);

        /// <summary>サービスの内部情報を表すメタオブジェクトを取得します。</summary>
        /// <returns>サービスを表すメタオブジェクト</returns>
        public QiValue GetMetaObject() => QiApiObject.GetMetaObject(this);

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を呼び出します。
        /// デバッグ目的で公開されており、普通は<see cref="Call"/>を使用してください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>戻り値の取得に使えるfuture型</returns>
        public QiFuture CallDirect(string signature, QiValue argsTuple)
            => QiApiObject.Call(this, signature, argsTuple);

        /// <summary>
        /// 自力でシグネチャを正しく定義してタプルを渡し、関数を非同期で呼び出します。
        /// デバッグ目的で公開されており、普通は<see cref="Post"/>を使用してください。
        /// </summary>
        /// <param name="signature">関数名と引数タプルの合わさった文字列("ping::()"など)</param>
        /// <param name="argsTuple">引数の入ってるタプル</param>
        /// <returns>非同期呼び出しの状態確認を行うために使われるID</returns>
        public int PostDirect(string signature, QiValue argsTuple)
            => QiApiObject.Post(this, signature, argsTuple);

        //NOTE: ここ本来ならeventっぽく書きたい所である(Disconnectも)
        public QiFuture ConnectSignal(string signature, QiObjectSignalCallbackHolder cbHolder, IntPtr userdata)
            => QiApiObject.SignalConnect(this, signature, cbHolder, userdata);

        public QiFuture DisconnectSignal(ulong id)
            => QiApiObject.SignalDisconnect(this, id);

        /// <summary>
        /// (動作未確認)オブジェクトのプロパティ値を取得します。
        /// </summary>
        /// <param name="pname">取得対象となるプロパティの名前</param>
        /// <returns>対応するプロパティ値への予約</returns>
        public QiFuture GetProperty(string pname) => QiApiObject.GetProperty(this, pname);

        /// <summary>
        /// (動作未確認)オブジェクトのプロパティに値を設定します。
        /// </summary>
        /// <param name="pname">プロパティ名</param>
        /// <param name="v">プロパティへ代入する値</param>
        /// <returns>代入結果への予約</returns>
        public QiFuture SetProperty(string pname, QiValue v) => QiApiObject.SetProperty(this, pname, v);

        /// <summary>
        /// 関数を同期的に呼び出します。
        /// </summary>
        /// <param name="methodName">関数名</param>
        /// <param name="args">関数の引数</param>
        /// <returns>結果に対する予約</returns>
        public QiValue Call(string methodName, params QiAnyValue[] args)
        {
            if(!CheckMethodExists(methodName))
            {
                throw new InvalidOperationException($"Method {methodName} does not exists in this service");
            }

            return CallDirect(
                GetMethodSignature(methodName, args),
                QiTuple.CreateDynamic(args).QiValue
                )
                .Wait()
                .GetValue();
        }

        /// <summary>
        /// 関数を非同期で呼び出します。
        /// </summary>
        /// <param name="methodName">関数名</param>
        /// <param name="args">関数の引数</param>
        /// <returns>非同期呼び出しの結果確認に使うID</returns>
        public int Post(string methodName, params QiAnyValue[] args)
        {
            if (!CheckMethodExists(methodName))
            {
                throw new InvalidOperationException($"Method {methodName} does not exists in this service");
            }

            return PostDirect(
                GetMethodSignature(methodName, args), 
                QiTuple.CreateDynamic(args).QiValue
                );
        }

        /// <summary>
        /// メソッド名を指定して、そのメソッド名に対応した引数シグネチャの一覧を返します。
        /// 存在しないメソッドを指定した場合は空の配列を返します。
        /// </summary>
        /// <param name="methodName">メソッド名</param>
        /// <returns>メソッドが取りうるシグネチャ一覧</returns>
        public string[] GetMethodSignatures(string methodName)
            => ServiceInfo
            .MethodInfos
            .Values
            .Where(mi => mi.Name == methodName)
            .Select(mi => mi.ArgumentSignature)
            .ToArray();


        private bool CheckMethodExists(string methodName)
            => ServiceInfo.MethodInfos.Values.Any(mi => mi.Name == methodName);

        private string GetMethodSignature(string methodName, QiAnyValue[] args)
        {
            var targets = ServiceInfo.MethodInfos.Values.Where(mi => mi.Name == methodName);
            //基本ケース: オーバーロード無い場合はチェック入れない(結果的にシグネチャ間違いあるかもしれないが無視)
            if (targets.Count() == 1)
            {
                return methodName + QiSignatures.MethodNameSuffix + targets.First().ArgumentSignature;
            }

            //オーバーロードがある場合は引数リストと見比べて適合するのがあるか判定
            var fittedMethod = targets.FirstOrDefault(t =>
                QiSignatureValidityChecker.CheckValidity(t.ArgumentSignature, args)
                );

            if (fittedMethod != null)
            {
                return methodName + QiSignatures.MethodNameSuffix + fittedMethod.ArgumentSignature;
            }

            throw new InvalidOperationException(
                $"Could not find proper overload for {methodName}, " +
                $"args: {QiTuple.Create(args).Signature}, " +
                $"existing method signatures: {string.Join(",", targets.Select(t => t.ArgumentSignature))}"
                );
        }


    }

    public delegate QiValue QiObjectMethod(string completeSignature, QiValue msg, IntPtr userdata);
    public delegate void QiObjectSignalCallback(QiValue parameter, IntPtr userdata);

}
