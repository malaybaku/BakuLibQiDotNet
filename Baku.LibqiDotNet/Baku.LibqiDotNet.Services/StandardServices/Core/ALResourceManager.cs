using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manage robot resources: Synchronize movement, led, sound. Run specific actions when another behavior wants your resources</summary>
    public class ALResourceManager
	{
		internal ALResourceManager(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALResourceManager CreateService(IQiSession session)
		{
			var result = new ALResourceManager(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALResourceManager CreateUninitializedService(IQiSession session)
		{
			return new ALResourceManager(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALResourceManager");
			}
		}

		/// <summary>
		/// ネットワーク経由でサービス情報を取得し、初期化する処理を非同期的に開始します。
		/// 初期化の完了は<see ref="IsInitialized"/>プロパティあるいは<see ref="Initialized"/>イベントを通じて行います。
		///</summary>
		public void StartInitializeService()
		{
			if (!IsInitialized)
			{

#if NET35
                new System.Threading.Thread(this.InitializeService).Start();
#else
                new System.Threading.Tasks.Task(this.InitializeService).Start();
#endif
			}
		}

		private readonly object _sourceServiceLock = new object();
		private IQiObject _sourceService;

        /// <summary>コード生成によってラップされる前のサービスを表すオブジェクトを取得します。</summary>
        public IQiObject SourceService 
		{ 
			get { lock (_sourceServiceLock) { return _sourceService; } }
			private set 
			{ 
				lock (_sourceServiceLock) 
				{ 
					_sourceService = value; 
				}
				if (value != null)
				{
					IsInitialized = true;
					Initialized?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>このサービスに関連付けられたセッション情報を取得します。</summary>
		public IQiSession Session { get; }

		/// <summary>このサービスが初期化済みであるかを取得します。</summary>
		public bool IsInitialized { get; private set; }

		/// <summary>このサービスの初期化が完了すると発生します。</summary>
		public event EventHandler Initialized;

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public ulong RegisterEvent(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["registerEvent"].Call<ulong>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<ulong> RegisterEventAsync(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["registerEvent"].CallAsync<ulong>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void UnregisterEvent(uint arg0, uint arg1, ulong arg2)
        {
            SourceService["unregisterEvent"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture UnregisterEventAsync(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["unregisterEvent"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult MetaObject(uint arg0)
        {
            return SourceService["metaObject"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> MetaObjectAsync(uint arg0)
        {
            return SourceService["metaObject"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void Terminate(uint arg0)
        {
            SourceService["terminate"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture TerminateAsync(uint arg0)
        {
            return SourceService["terminate"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult Property(object arg0)
        {
            return SourceService["property"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> PropertyAsync(object arg0)
        {
            return SourceService["property"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void SetProperty(object arg0, object arg1)
        {
            SourceService["setProperty"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture SetPropertyAsync(object arg0, object arg1)
        {
            return SourceService["setProperty"].CallAsync(arg0, arg1);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] Properties()
        {
            return SourceService["properties"].Call<string[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string[]> PropertiesAsync()
        {
            return SourceService["properties"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public ulong RegisterEventWithSignature(uint arg0, uint arg1, ulong arg2, string arg3)
        {
            return SourceService["registerEventWithSignature"].Call<ulong>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<ulong> RegisterEventWithSignatureAsync(uint arg0, uint arg1, ulong arg2, string arg3)
        {
            return SourceService["registerEventWithSignature"].CallAsync<ulong>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsStatsEnabled()
        {
            return SourceService["isStatsEnabled"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> IsStatsEnabledAsync()
        {
            return SourceService["isStatsEnabled"].CallAsync<bool>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void EnableStats(bool arg0)
        {
            SourceService["enableStats"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture EnableStatsAsync(bool arg0)
        {
            return SourceService["enableStats"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult Stats()
        {
            return SourceService["stats"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> StatsAsync()
        {
            return SourceService["stats"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void ClearStats()
        {
            SourceService["clearStats"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture ClearStatsAsync()
        {
            return SourceService["clearStats"].CallAsync();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsTraceEnabled()
        {
            return SourceService["isTraceEnabled"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> IsTraceEnabledAsync()
        {
            return SourceService["isTraceEnabled"].CallAsync<bool>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void EnableTrace(bool arg0)
        {
            SourceService["enableTrace"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture EnableTraceAsync(bool arg0)
        {
            return SourceService["enableTrace"].CallAsync(arg0);
        }

        /// <summary>Exits and unregisters the module.</summary>
		/// <returns></returns>
        public void Exit()
        {
            SourceService["exit"].Call();
        }

        /// <summary>Exits and unregisters the module.</summary>
		/// <returns></returns>
        public IQiFuture ExitAsync()
        {
            return SourceService["exit"].CallAsync();
        }

        /// <summary>Internal function to pCall methods</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int __pCall(uint arg0, object arg1)
        {
            return SourceService["__pCall"].Call<int>(arg0, arg1);
        }

        /// <summary>Internal function to pCall methods</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<int> __pCallAsync(uint arg0, object arg1)
        {
            return SourceService["__pCall"].CallAsync<int>(arg0, arg1);
        }

        /// <summary>NAOqi1 pCall method.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult PCall(object arg0)
        {
            return SourceService["pCall"].Call<IQiResult>(arg0);
        }

        /// <summary>NAOqi1 pCall method.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> PCallAsync(object arg0)
        {
            return SourceService["pCall"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Returns the version of the module.</summary>
		/// <returns>A string containing the version of the module.</returns>
        public string Version()
        {
            return SourceService["version"].Call<string>();
        }

        /// <summary>Returns the version of the module.</summary>
		/// <returns>A string containing the version of the module.</returns>
        public IQiFuture<string> VersionAsync()
        {
            return SourceService["version"].CallAsync<string>();
        }

        /// <summary>Just a ping. Always returns true</summary>
		/// <returns>returns true</returns>
        public bool Ping()
        {
            return SourceService["ping"].Call<bool>();
        }

        /// <summary>Just a ping. Always returns true</summary>
		/// <returns>returns true</returns>
        public IQiFuture<bool> PingAsync()
        {
            return SourceService["ping"].CallAsync<bool>();
        }

        /// <summary>Retrieves the module's method list.</summary>
		/// <returns>An array of method names.</returns>
        public string[] GetMethodList()
        {
            return SourceService["getMethodList"].Call<string[]>();
        }

        /// <summary>Retrieves the module's method list.</summary>
		/// <returns>An array of method names.</returns>
        public IQiFuture<string[]> GetMethodListAsync()
        {
            return SourceService["getMethodList"].CallAsync<string[]>();
        }

        /// <summary>Retrieves a method's description.</summary>
		/// <param name="arg0_methodName">The name of the method.</param>
		/// <returns>A structure containing the method's description.</returns>
        public IQiResult GetMethodHelp(string arg0_methodName)
        {
            return SourceService["getMethodHelp"].Call<IQiResult>(arg0_methodName);
        }

        /// <summary>Retrieves a method's description.</summary>
		/// <param name="arg0_methodName">The name of the method.</param>
		/// <returns>A structure containing the method's description.</returns>
        public IQiFuture<IQiResult> GetMethodHelpAsync(string arg0_methodName)
        {
            return SourceService["getMethodHelp"].CallAsync<IQiResult>(arg0_methodName);
        }

        /// <summary>Retrieves the module's description.</summary>
		/// <returns>A structure describing the module.</returns>
        public IQiResult GetModuleHelp()
        {
            return SourceService["getModuleHelp"].Call<IQiResult>();
        }

        /// <summary>Retrieves the module's description.</summary>
		/// <returns>A structure describing the module.</returns>
        public IQiFuture<IQiResult> GetModuleHelpAsync()
        {
            return SourceService["getModuleHelp"].CallAsync<IQiResult>();
        }

        /// <summary>Wait for the end of a long running method that was called using 'post'</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <param name="arg1_timeoutPeriod">The timeout period in ms. To wait indefinately, use a timeoutPeriod of zero.</param>
		/// <returns>True if the timeout period terminated. False if the method returned.</returns>
        public bool Wait(int arg0_id, int arg1_timeoutPeriod)
        {
            return SourceService["wait"].Call<bool>(arg0_id, arg1_timeoutPeriod);
        }

        /// <summary>Wait for the end of a long running method that was called using 'post'</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <param name="arg1_timeoutPeriod">The timeout period in ms. To wait indefinately, use a timeoutPeriod of zero.</param>
		/// <returns>True if the timeout period terminated. False if the method returned.</returns>
        public IQiFuture<bool> WaitAsync(int arg0_id, int arg1_timeoutPeriod)
        {
            return SourceService["wait"].CallAsync<bool>(arg0_id, arg1_timeoutPeriod);
        }

        /// <summary>Wait for the end of a long running method that was called using 'post', returns a cancelable future</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns></returns>
        public void Wait(int arg0_id)
        {
            SourceService["wait"].Call(arg0_id);
        }

        /// <summary>Wait for the end of a long running method that was called using 'post', returns a cancelable future</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns></returns>
        public IQiFuture WaitAsync(int arg0_id)
        {
            return SourceService["wait"].CallAsync(arg0_id);
        }

        /// <summary>Returns true if the method is currently running.</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns>True if the method is currently running</returns>
        public bool IsRunning(int arg0_id)
        {
            return SourceService["isRunning"].Call<bool>(arg0_id);
        }

        /// <summary>Returns true if the method is currently running.</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns>True if the method is currently running</returns>
        public IQiFuture<bool> IsRunningAsync(int arg0_id)
        {
            return SourceService["isRunning"].CallAsync<bool>(arg0_id);
        }

        /// <summary>returns true if the method is currently running</summary>
		/// <param name="arg0_id">the ID of the method to wait for</param>
		/// <returns></returns>
        public void Stop(int arg0_id)
        {
            SourceService["stop"].Call(arg0_id);
        }

        /// <summary>returns true if the method is currently running</summary>
		/// <param name="arg0_id">the ID of the method to wait for</param>
		/// <returns></returns>
        public IQiFuture StopAsync(int arg0_id)
        {
            return SourceService["stop"].CallAsync(arg0_id);
        }

        /// <summary>Gets the name of the parent broker.</summary>
		/// <returns>The name of the parent broker.</returns>
        public string GetBrokerName()
        {
            return SourceService["getBrokerName"].Call<string>();
        }

        /// <summary>Gets the name of the parent broker.</summary>
		/// <returns>The name of the parent broker.</returns>
        public IQiFuture<string> GetBrokerNameAsync()
        {
            return SourceService["getBrokerName"].CallAsync<string>();
        }

        /// <summary>Gets the method usage string. This summarises how to use the method.</summary>
		/// <param name="arg0_name">The name of the method.</param>
		/// <returns>A string that summarises the usage of the method.</returns>
        public string GetUsage(string arg0_name)
        {
            return SourceService["getUsage"].Call<string>(arg0_name);
        }

        /// <summary>Gets the method usage string. This summarises how to use the method.</summary>
		/// <param name="arg0_name">The name of the method.</param>
		/// <returns>A string that summarises the usage of the method.</returns>
        public IQiFuture<string> GetUsageAsync(string arg0_name)
        {
            return SourceService["getUsage"].CallAsync<string>(arg0_name);
        }

        /// <summary>Wait resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void WaitForResource(string arg0_resourceName, string arg1_ownerName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["waitForResource"].Call(arg0_resourceName, arg1_ownerName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public IQiFuture WaitForResourceAsync(string arg0_resourceName, string arg1_ownerName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            return SourceService["waitForResource"].CallAsync(arg0_resourceName, arg1_ownerName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait and acquire a resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void AcquireResource(string arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["acquireResource"].Call(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait and acquire a resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public IQiFuture AcquireResourceAsync(string arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            return SourceService["acquireResource"].CallAsync(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait resource</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public string[] WaitForOptionalResourcesTree(IEnumerable<string> arg0, string arg1, string arg2, int arg3, IEnumerable<string> arg4)
        {
            return SourceService["waitForOptionalResourcesTree"].Call<string[]>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary>Wait resource</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public IQiFuture<string[]> WaitForOptionalResourcesTreeAsync(IEnumerable<string> arg0, string arg1, string arg2, int arg3, IEnumerable<string> arg4)
        {
            return SourceService["waitForOptionalResourcesTree"].CallAsync<string[]>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void WaitForResourcesTree(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["waitForResourcesTree"].Call(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public IQiFuture WaitForResourcesTreeAsync(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            return SourceService["waitForResourcesTree"].CallAsync(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void AcquireResourcesTree(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["acquireResourcesTree"].Call(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public IQiFuture AcquireResourcesTreeAsync(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            return SourceService["acquireResourcesTree"].CallAsync(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>True if all the specified resources are owned by the owner</summary>
		/// <param name="arg0_resourceNameList">Resource name</param>
		/// <param name="arg1_ownerName">Owner pointer with hierarchy</param>
		/// <returns>True if all the specify resources are owned by the owner</returns>
        public bool AreResourcesOwnedBy(IEnumerable<string> arg0_resourceNameList, string arg1_ownerName)
        {
            return SourceService["areResourcesOwnedBy"].Call<bool>(arg0_resourceNameList, arg1_ownerName);
        }

        /// <summary>True if all the specified resources are owned by the owner</summary>
		/// <param name="arg0_resourceNameList">Resource name</param>
		/// <param name="arg1_ownerName">Owner pointer with hierarchy</param>
		/// <returns>True if all the specify resources are owned by the owner</returns>
        public IQiFuture<bool> AreResourcesOwnedByAsync(IEnumerable<string> arg0_resourceNameList, string arg1_ownerName)
        {
            return SourceService["areResourcesOwnedBy"].CallAsync<bool>(arg0_resourceNameList, arg1_ownerName);
        }

        /// <summary>Release resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Existing owner name</param>
		/// <returns></returns>
        public void ReleaseResource(string arg0_resourceName, string arg1_ownerName)
        {
            SourceService["releaseResource"].Call(arg0_resourceName, arg1_ownerName);
        }

        /// <summary>Release resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Existing owner name</param>
		/// <returns></returns>
        public IQiFuture ReleaseResourceAsync(string arg0_resourceName, string arg1_ownerName)
        {
            return SourceService["releaseResource"].CallAsync(arg0_resourceName, arg1_ownerName);
        }

        /// <summary>Release  resources list</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <param name="arg1_ownerName">Owner name</param>
		/// <returns></returns>
        public void ReleaseResources(IEnumerable<string> arg0_resourceNames, string arg1_ownerName)
        {
            SourceService["releaseResources"].Call(arg0_resourceNames, arg1_ownerName);
        }

        /// <summary>Release  resources list</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <param name="arg1_ownerName">Owner name</param>
		/// <returns></returns>
        public IQiFuture ReleaseResourcesAsync(IEnumerable<string> arg0_resourceNames, string arg1_ownerName)
        {
            return SourceService["releaseResources"].CallAsync(arg0_resourceNames, arg1_ownerName);
        }

        /// <summary>Enable or disable a state resource</summary>
		/// <param name="arg0_resourceName">The name of the resource that you wish enable of disable. e.g. Standing</param>
		/// <param name="arg1_enabled">True to enable, false to disable</param>
		/// <returns></returns>
        public void EnableStateResource(string arg0_resourceName, bool arg1_enabled)
        {
            SourceService["enableStateResource"].Call(arg0_resourceName, arg1_enabled);
        }

        /// <summary>Enable or disable a state resource</summary>
		/// <param name="arg0_resourceName">The name of the resource that you wish enable of disable. e.g. Standing</param>
		/// <param name="arg1_enabled">True to enable, false to disable</param>
		/// <returns></returns>
        public IQiFuture EnableStateResourceAsync(string arg0_resourceName, bool arg1_enabled)
        {
            return SourceService["enableStateResource"].CallAsync(arg0_resourceName, arg1_enabled);
        }

        /// <summary>check if all the state resource in the list are free</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <returns></returns>
        public bool CheckStateResourceFree(IEnumerable<string> arg0_resourceName)
        {
            return SourceService["checkStateResourceFree"].Call<bool>(arg0_resourceName);
        }

        /// <summary>check if all the state resource in the list are free</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <returns></returns>
        public IQiFuture<bool> CheckStateResourceFreeAsync(IEnumerable<string> arg0_resourceName)
        {
            return SourceService["checkStateResourceFree"].CallAsync<bool>(arg0_resourceName);
        }

        /// <summary>True if all resources are free</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <returns>True if all the specify resources are free</returns>
        public bool AreResourcesFree(IEnumerable<string> arg0_resourceNames)
        {
            return SourceService["areResourcesFree"].Call<bool>(arg0_resourceNames);
        }

        /// <summary>True if all resources are free</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <returns>True if all the specify resources are free</returns>
        public IQiFuture<bool> AreResourcesFreeAsync(IEnumerable<string> arg0_resourceNames)
        {
            return SourceService["areResourcesFree"].CallAsync<bool>(arg0_resourceNames);
        }

        /// <summary>True if the resource is free</summary>
		/// <param name="arg0_resourceNames">Resource name</param>
		/// <returns>True if the specify resources is free</returns>
        public bool IsResourceFree(string arg0_resourceNames)
        {
            return SourceService["isResourceFree"].Call<bool>(arg0_resourceNames);
        }

        /// <summary>True if the resource is free</summary>
		/// <param name="arg0_resourceNames">Resource name</param>
		/// <returns>True if the specify resources is free</returns>
        public IQiFuture<bool> IsResourceFreeAsync(string arg0_resourceNames)
        {
            return SourceService["isResourceFree"].CallAsync<bool>(arg0_resourceNames);
        }

        /// <summary>Create a resource</summary>
		/// <param name="arg0_resourceName">Resource name to create</param>
		/// <param name="arg1_parentResourceName">Parent resource name or empty string for root resource</param>
		/// <returns></returns>
        public void CreateResource(string arg0_resourceName, string arg1_parentResourceName)
        {
            SourceService["createResource"].Call(arg0_resourceName, arg1_parentResourceName);
        }

        /// <summary>Create a resource</summary>
		/// <param name="arg0_resourceName">Resource name to create</param>
		/// <param name="arg1_parentResourceName">Parent resource name or empty string for root resource</param>
		/// <returns></returns>
        public IQiFuture CreateResourceAsync(string arg0_resourceName, string arg1_parentResourceName)
        {
            return SourceService["createResource"].CallAsync(arg0_resourceName, arg1_parentResourceName);
        }

        /// <summary>Delete a root resource</summary>
		/// <param name="arg0_resourceName">Resource name to delete</param>
		/// <param name="arg1_deleteChildResources">DEPRECATED: Delete child resources if true</param>
		/// <returns></returns>
        public void DeleteResource(string arg0_resourceName, bool arg1_deleteChildResources)
        {
            SourceService["deleteResource"].Call(arg0_resourceName, arg1_deleteChildResources);
        }

        /// <summary>Delete a root resource</summary>
		/// <param name="arg0_resourceName">Resource name to delete</param>
		/// <param name="arg1_deleteChildResources">DEPRECATED: Delete child resources if true</param>
		/// <returns></returns>
        public IQiFuture DeleteResourceAsync(string arg0_resourceName, bool arg1_deleteChildResources)
        {
            return SourceService["deleteResource"].CallAsync(arg0_resourceName, arg1_deleteChildResources);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public bool IsInGroup(string arg0_resourceGroupName, string arg1_resourceName)
        {
            return SourceService["isInGroup"].Call<bool>(arg0_resourceGroupName, arg1_resourceName);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public IQiFuture<bool> IsInGroupAsync(string arg0_resourceGroupName, string arg1_resourceName)
        {
            return SourceService["isInGroup"].CallAsync<bool>(arg0_resourceGroupName, arg1_resourceName);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public void CreateResourcesList(IEnumerable<string> arg0_resourceGroupName, string arg1_resourceName)
        {
            SourceService["createResourcesList"].Call(arg0_resourceGroupName, arg1_resourceName);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public IQiFuture CreateResourcesListAsync(IEnumerable<string> arg0_resourceGroupName, string arg1_resourceName)
        {
            return SourceService["createResourcesList"].CallAsync(arg0_resourceGroupName, arg1_resourceName);
        }

        /// <summary>Get tree of resources</summary>
		/// <returns></returns>
        public IQiResult GetResources()
        {
            return SourceService["getResources"].Call<IQiResult>();
        }

        /// <summary>Get tree of resources</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetResourcesAsync()
        {
            return SourceService["getResources"].CallAsync<IQiResult>();
        }

        /// <summary>The tree of the resources owners.</summary>
		/// <returns></returns>
        public IQiResult OwnersGet()
        {
            return SourceService["ownersGet"].Call<IQiResult>();
        }

        /// <summary>The tree of the resources owners.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> OwnersGetAsync()
        {
            return SourceService["ownersGet"].CallAsync<IQiResult>();
        }

    }
}