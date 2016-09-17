using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALWorldRepresentation
	{
		internal ALWorldRepresentation(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALWorldRepresentation CreateService(IQiSession session)
		{
			var result = new ALWorldRepresentation(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALWorldRepresentation CreateUninitializedService(IQiSession session)
		{
			return new ALWorldRepresentation(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALWorldRepresentation");
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

        /// <summary>Add an attribute to a category.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int AddAttributeToCategory(string arg0, string arg1, object arg2)
        {
            return SourceService["addAttributeToCategory"].Call<int>(arg0, arg1, arg2);
        }

        /// <summary>Add an attribute to a category.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<int> AddAttributeToCategoryAsync(string arg0, string arg1, object arg2)
        {
            return SourceService["addAttributeToCategory"].CallAsync<int>(arg0, arg1, arg2);
        }

        /// <summary>Clear an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int ClearObject(string arg0)
        {
            return SourceService["clearObject"].Call<int>(arg0);
        }

        /// <summary>Clear an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> ClearObjectAsync(string arg0)
        {
            return SourceService["clearObject"].CallAsync<int>(arg0);
        }

        /// <summary>Clear recording of old positions.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int ClearOldPositions(string arg0, int arg1)
        {
            return SourceService["clearOldPositions"].Call<int>(arg0, arg1);
        }

        /// <summary>Clear recording of old positions.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<int> ClearOldPositionsAsync(string arg0, int arg1)
        {
            return SourceService["clearOldPositions"].CallAsync<int>(arg0, arg1);
        }

        /// <summary>Create a new object category</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int CreateObjectCategory(string arg0, bool arg1)
        {
            return SourceService["createObjectCategory"].Call<int>(arg0, arg1);
        }

        /// <summary>Create a new object category</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<int> CreateObjectCategoryAsync(string arg0, bool arg1)
        {
            return SourceService["createObjectCategory"].CallAsync<int>(arg0, arg1);
        }

        /// <summary>Remove an object category</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int RemoveObjectCategory(string arg0)
        {
            return SourceService["removeObjectCategory"].Call<int>(arg0);
        }

        /// <summary>Remove an object category</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> RemoveObjectCategoryAsync(string arg0)
        {
            return SourceService["removeObjectCategory"].CallAsync<int>(arg0);
        }

        /// <summary>Tells if an object category exists</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ObjectCategoryExists(string arg0)
        {
            return SourceService["objectCategoryExists"].Call<bool>(arg0);
        }

        /// <summary>Tells if an object category exists</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ObjectCategoryExistsAsync(string arg0)
        {
            return SourceService["objectCategoryExists"].CallAsync<bool>(arg0);
        }

        /// <summary>Delete an object attribute</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int DeleteObjectAttribute(string arg0, string arg1, string arg2)
        {
            return SourceService["deleteObjectAttribute"].Call<int>(arg0, arg1, arg2);
        }

        /// <summary>Delete an object attribute</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<int> DeleteObjectAttributeAsync(string arg0, string arg1, string arg2)
        {
            return SourceService["deleteObjectAttribute"].CallAsync<int>(arg0, arg1, arg2);
        }

        /// <summary>Check that an object is present.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool FindObject(string arg0)
        {
            return SourceService["findObject"].Call<bool>(arg0);
        }

        /// <summary>Check that an object is present.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> FindObjectAsync(string arg0)
        {
            return SourceService["findObject"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int Load()
        {
            return SourceService["load"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> LoadAsync()
        {
            return SourceService["load"].CallAsync<int>();
        }

        /// <summary>Get all attributes from a category if it exists.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetAttributesFromCategory(string arg0)
        {
            return SourceService["getAttributesFromCategory"].Call<IQiResult>(arg0);
        }

        /// <summary>Get all attributes from a category if it exists.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetAttributesFromCategoryAsync(string arg0)
        {
            return SourceService["getAttributesFromCategory"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Get the direct children of an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetChildrenNames(string arg0)
        {
            return SourceService["getChildrenNames"].Call<string[]>(arg0);
        }

        /// <summary>Get the direct children of an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string[]> GetChildrenNamesAsync(string arg0)
        {
            return SourceService["getChildrenNames"].CallAsync<string[]>(arg0);
        }

        /// <summary>Get the name of the objects.</summary>
		/// <returns></returns>
        public string[] GetObjectNames()
        {
            return SourceService["getObjectNames"].Call<string[]>();
        }

        /// <summary>Get the name of the objects.</summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetObjectNamesAsync()
        {
            return SourceService["getObjectNames"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetObjectAttributes(string arg0)
        {
            return SourceService["getObjectAttributes"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetObjectAttributesAsync(string arg0)
        {
            return SourceService["getObjectAttributes"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiResult GetObjectAttributeValues(string arg0, string arg1, int arg2)
        {
            return SourceService["getObjectAttributeValues"].Call<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetObjectAttributeValuesAsync(string arg0, string arg1, int arg2)
        {
            return SourceService["getObjectAttributeValues"].CallAsync<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetObjectLatestAttributes(string arg0, int arg1)
        {
            return SourceService["getObjectLatestAttributes"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetObjectLatestAttributesAsync(string arg0, int arg1)
        {
            return SourceService["getObjectLatestAttributes"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetObjectParentName(string arg0)
        {
            return SourceService["getObjectParentName"].Call<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetObjectParentNameAsync(string arg0)
        {
            return SourceService["getObjectParentName"].CallAsync<string>(arg0);
        }

        /// <summary>Get the name of the objects stored in the database.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetObjectsInCategory(string arg0)
        {
            return SourceService["getObjectsInCategory"].Call<string[]>(arg0);
        }

        /// <summary>Get the name of the objects stored in the database.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string[]> GetObjectsInCategoryAsync(string arg0)
        {
            return SourceService["getObjectsInCategory"].CallAsync<string[]>(arg0);
        }

        /// <summary>Get the name of the database where the object is stored.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetObjectCategory(string arg0)
        {
            return SourceService["getObjectCategory"].Call<string>(arg0);
        }

        /// <summary>Get the name of the database where the object is stored.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetObjectCategoryAsync(string arg0)
        {
            return SourceService["getObjectCategory"].CallAsync<string>(arg0);
        }

        /// <summary>Get the position of an object with quaternion / translation.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetPosition(string arg0, string arg1)
        {
            return SourceService["getPosition"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary>Get the position of an object with quaternion / translation.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetPositionAsync(string arg0, string arg1)
        {
            return SourceService["getPosition"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary>Get the position from one object to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetPosition6D(string arg0, string arg1)
        {
            return SourceService["getPosition6D"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary>Get the position from one object to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetPosition6DAsync(string arg0, string arg1)
        {
            return SourceService["getPosition6D"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary>Get the interpolated position of an object</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiResult GetPosition6DAtTime(string arg0, string arg1, int arg2, int arg3)
        {
            return SourceService["getPosition6DAtTime"].Call<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Get the interpolated position of an object</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetPosition6DAtTimeAsync(string arg0, string arg1, int arg2, int arg3)
        {
            return SourceService["getPosition6DAtTime"].CallAsync<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string GetRootName()
        {
            return SourceService["getRootName"].Call<string>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string> GetRootNameAsync()
        {
            return SourceService["getRootName"].CallAsync<string>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int Save()
        {
            return SourceService["save"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> SaveAsync()
        {
            return SourceService["save"].CallAsync<int>();
        }

        /// <summary>Select information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiResult Select(string arg0, string arg1, string arg2, string arg3)
        {
            return SourceService["select"].Call<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Select information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SelectAsync(string arg0, string arg1, string arg2, string arg3)
        {
            return SourceService["select"].CallAsync<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Select ordered information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public IQiResult SelectWithOrder(string arg0, string arg1, string arg2, string arg3, string arg4)
        {
            return SourceService["selectWithOrder"].Call<IQiResult>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary>Select ordered information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SelectWithOrderAsync(string arg0, string arg1, string arg2, string arg3, string arg4)
        {
            return SourceService["selectWithOrder"].CallAsync<IQiResult>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public int StoreObject(string arg0, string arg1, IEnumerable<float> arg2, string arg3, object arg4)
        {
            return SourceService["storeObject"].Call<int>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public IQiFuture<int> StoreObjectAsync(string arg0, string arg1, IEnumerable<float> arg2, string arg3, object arg4)
        {
            return SourceService["storeObject"].CallAsync<int>(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public int StoreObjectWithReference(string arg0, string arg1, string arg2, IEnumerable<float> arg3, string arg4, object arg5)
        {
            return SourceService["storeObjectWithReference"].Call<int>(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public IQiFuture<int> StoreObjectWithReferenceAsync(string arg0, string arg1, string arg2, IEnumerable<float> arg3, string arg4, object arg5)
        {
            return SourceService["storeObjectWithReference"].CallAsync<int>(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int StoreObjectAttribute(string arg0, string arg1, object arg2)
        {
            return SourceService["storeObjectAttribute"].Call<int>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<int> StoreObjectAttributeAsync(string arg0, string arg1, object arg2)
        {
            return SourceService["storeObjectAttribute"].CallAsync<int>(arg0, arg1, arg2);
        }

        /// <summary>Update the position of an object.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int UpdatePosition(string arg0, IEnumerable<float> arg1, bool arg2)
        {
            return SourceService["updatePosition"].Call<int>(arg0, arg1, arg2);
        }

        /// <summary>Update the position of an object.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<int> UpdatePositionAsync(string arg0, IEnumerable<float> arg1, bool arg2)
        {
            return SourceService["updatePosition"].CallAsync<int>(arg0, arg1, arg2);
        }

        /// <summary>Update the position of an object relative to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public int UpdatePositionWithReference(string arg0, string arg1, IEnumerable<float> arg2, bool arg3)
        {
            return SourceService["updatePositionWithReference"].Call<int>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Update the position of an object relative to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<int> UpdatePositionWithReferenceAsync(string arg0, string arg1, IEnumerable<float> arg2, bool arg3)
        {
            return SourceService["updatePositionWithReference"].CallAsync<int>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public int UpdateAttribute(string arg0, string arg1, string arg2, object arg3)
        {
            return SourceService["updateAttribute"].Call<int>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<int> UpdateAttributeAsync(string arg0, string arg1, string arg2, object arg3)
        {
            return SourceService["updateAttribute"].CallAsync<int>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startMemoryCheck(int arg0)
        {
            SourceService["_startMemoryCheck"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _startMemoryCheckAsync(int arg0)
        {
            return SourceService["_startMemoryCheck"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _stopMemoryCheck()
        {
            SourceService["_stopMemoryCheck"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture _stopMemoryCheckAsync()
        {
            return SourceService["_stopMemoryCheck"].CallAsync();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _beginTransaction(string arg0)
        {
            return SourceService["_beginTransaction"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _beginTransactionAsync(string arg0)
        {
            return SourceService["_beginTransaction"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _endTransaction(string arg0)
        {
            return SourceService["_endTransaction"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _endTransactionAsync(string arg0)
        {
            return SourceService["_endTransaction"].CallAsync<int>(arg0);
        }

    }
}