using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module is intended to manage behaviors. With this module, you can load, start, stop behaviors, add default behaviors or remove them. </summary>
    public class ALBehaviorManager
	{
		internal ALBehaviorManager(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALBehaviorManager CreateService(IQiSession session)
		{
			var result = new ALBehaviorManager(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALBehaviorManager CreateUninitializedService(IQiSession session)
		{
			return new ALBehaviorManager(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALBehaviorManager");
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

        /// <summary>Load a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it was successfully loaded.</returns>
        public bool PreloadBehavior(string arg0_behavior)
        {
            return SourceService["preloadBehavior"].Call<bool>(arg0_behavior);
        }

        /// <summary>Load a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it was successfully loaded.</returns>
        public IQiFuture<bool> PreloadBehaviorAsync(string arg0_behavior)
        {
            return SourceService["preloadBehavior"].CallAsync<bool>(arg0_behavior);
        }

        /// <summary>Starts a behavior, returns when started.</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void StartBehavior(string arg0_behavior)
        {
            SourceService["startBehavior"].Call(arg0_behavior);
        }

        /// <summary>Starts a behavior, returns when started.</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public IQiFuture StartBehaviorAsync(string arg0_behavior)
        {
            return SourceService["startBehavior"].CallAsync(arg0_behavior);
        }

        /// <summary>Runs a behavior, returns when finished</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void RunBehavior(string arg0_behavior)
        {
            SourceService["runBehavior"].Call(arg0_behavior);
        }

        /// <summary>Runs a behavior, returns when finished</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public IQiFuture RunBehaviorAsync(string arg0_behavior)
        {
            return SourceService["runBehavior"].CallAsync(arg0_behavior);
        }

        /// <summary>Stop a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void StopBehavior(string arg0_behavior)
        {
            SourceService["stopBehavior"].Call(arg0_behavior);
        }

        /// <summary>Stop a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public IQiFuture StopBehaviorAsync(string arg0_behavior)
        {
            return SourceService["stopBehavior"].CallAsync(arg0_behavior);
        }

        /// <summary>Stop all behaviors</summary>
		/// <returns></returns>
        public void StopAllBehaviors()
        {
            SourceService["stopAllBehaviors"].Call();
        }

        /// <summary>Stop all behaviors</summary>
		/// <returns></returns>
        public IQiFuture StopAllBehaviorsAsync()
        {
            return SourceService["stopAllBehaviors"].CallAsync();
        }

        /// <summary>Tell if supplied name corresponds to a behavior that has been installed</summary>
		/// <param name="arg0_name">The behavior directory name</param>
		/// <returns>Returns true if it is a valid behavior</returns>
        public bool IsBehaviorInstalled(string arg0_name)
        {
            return SourceService["isBehaviorInstalled"].Call<bool>(arg0_name);
        }

        /// <summary>Tell if supplied name corresponds to a behavior that has been installed</summary>
		/// <param name="arg0_name">The behavior directory name</param>
		/// <returns>Returns true if it is a valid behavior</returns>
        public IQiFuture<bool> IsBehaviorInstalledAsync(string arg0_name)
        {
            return SourceService["isBehaviorInstalled"].CallAsync<bool>(arg0_name);
        }

        /// <summary>Tell if the supplied namecorresponds to an existing behavior.</summary>
		/// <param name="arg0_prefixedBehavior">Prefixed behavior or just behavior's name (latter usage deprecated, in this case the behavior is searched for amongst user's behaviors, then in system behaviors) DEPRECATED in favor of ALBehaviorManager.isBehaviorInstalled.</param>
		/// <returns>Returns true if it is an existing behavior</returns>
        public bool IsBehaviorPresent(string arg0_prefixedBehavior)
        {
            return SourceService["isBehaviorPresent"].Call<bool>(arg0_prefixedBehavior);
        }

        /// <summary>Tell if the supplied namecorresponds to an existing behavior.</summary>
		/// <param name="arg0_prefixedBehavior">Prefixed behavior or just behavior's name (latter usage deprecated, in this case the behavior is searched for amongst user's behaviors, then in system behaviors) DEPRECATED in favor of ALBehaviorManager.isBehaviorInstalled.</param>
		/// <returns>Returns true if it is an existing behavior</returns>
        public IQiFuture<bool> IsBehaviorPresentAsync(string arg0_prefixedBehavior)
        {
            return SourceService["isBehaviorPresent"].CallAsync<bool>(arg0_prefixedBehavior);
        }

        /// <summary>Get behaviors</summary>
		/// <returns>Returns the list of behaviors prefixed by their type (User/ or System/). DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetBehaviorNames()
        {
            return SourceService["getBehaviorNames"].Call<string[]>();
        }

        /// <summary>Get behaviors</summary>
		/// <returns>Returns the list of behaviors prefixed by their type (User/ or System/). DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public IQiFuture<string[]> GetBehaviorNamesAsync()
        {
            return SourceService["getBehaviorNames"].CallAsync<string[]>();
        }

        /// <summary>Get user's behaviors</summary>
		/// <returns>Returns the list of user's behaviors prefixed by User/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetUserBehaviorNames()
        {
            return SourceService["getUserBehaviorNames"].Call<string[]>();
        }

        /// <summary>Get user's behaviors</summary>
		/// <returns>Returns the list of user's behaviors prefixed by User/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public IQiFuture<string[]> GetUserBehaviorNamesAsync()
        {
            return SourceService["getUserBehaviorNames"].CallAsync<string[]>();
        }

        /// <summary>Get system behaviors</summary>
		/// <returns>Returns the list of system behaviors prefixed by System/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetSystemBehaviorNames()
        {
            return SourceService["getSystemBehaviorNames"].Call<string[]>();
        }

        /// <summary>Get system behaviors</summary>
		/// <returns>Returns the list of system behaviors prefixed by System/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public IQiFuture<string[]> GetSystemBehaviorNamesAsync()
        {
            return SourceService["getSystemBehaviorNames"].CallAsync<string[]>();
        }

        /// <summary>Get installed behaviors directories names</summary>
		/// <returns>Returns the behaviors list</returns>
        public string[] GetInstalledBehaviors()
        {
            return SourceService["getInstalledBehaviors"].Call<string[]>();
        }

        /// <summary>Get installed behaviors directories names</summary>
		/// <returns>Returns the behaviors list</returns>
        public IQiFuture<string[]> GetInstalledBehaviorsAsync()
        {
            return SourceService["getInstalledBehaviors"].CallAsync<string[]>();
        }

        /// <summary>Get installed behaviors directories names and filter it by tag.</summary>
		/// <param name="arg0_tag">A tag to filter the list with.</param>
		/// <returns>Returns the behaviors list</returns>
        public string[] GetBehaviorsByTag(string arg0_tag)
        {
            return SourceService["getBehaviorsByTag"].Call<string[]>(arg0_tag);
        }

        /// <summary>Get installed behaviors directories names and filter it by tag.</summary>
		/// <param name="arg0_tag">A tag to filter the list with.</param>
		/// <returns>Returns the behaviors list</returns>
        public IQiFuture<string[]> GetBehaviorsByTagAsync(string arg0_tag)
        {
            return SourceService["getBehaviorsByTag"].CallAsync<string[]>(arg0_tag);
        }

        /// <summary>Tell if supplied name corresponds to a running behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a running behavior</returns>
        public bool IsBehaviorRunning(string arg0_behavior)
        {
            return SourceService["isBehaviorRunning"].Call<bool>(arg0_behavior);
        }

        /// <summary>Tell if supplied name corresponds to a running behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a running behavior</returns>
        public IQiFuture<bool> IsBehaviorRunningAsync(string arg0_behavior)
        {
            return SourceService["isBehaviorRunning"].CallAsync<bool>(arg0_behavior);
        }

        /// <summary>Tell if supplied name corresponds to a loaded behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a loaded behavior</returns>
        public bool IsBehaviorLoaded(string arg0_behavior)
        {
            return SourceService["isBehaviorLoaded"].Call<bool>(arg0_behavior);
        }

        /// <summary>Tell if supplied name corresponds to a loaded behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a loaded behavior</returns>
        public IQiFuture<bool> IsBehaviorLoadedAsync(string arg0_behavior)
        {
            return SourceService["isBehaviorLoaded"].CallAsync<bool>(arg0_behavior);
        }

        /// <summary>Get running behaviors</summary>
		/// <returns>Return running behaviors</returns>
        public string[] GetRunningBehaviors()
        {
            return SourceService["getRunningBehaviors"].Call<string[]>();
        }

        /// <summary>Get running behaviors</summary>
		/// <returns>Return running behaviors</returns>
        public IQiFuture<string[]> GetRunningBehaviorsAsync()
        {
            return SourceService["getRunningBehaviors"].CallAsync<string[]>();
        }

        /// <summary>Get loaded behaviors</summary>
		/// <returns>Return loaded behaviors</returns>
        public string[] GetLoadedBehaviors()
        {
            return SourceService["getLoadedBehaviors"].Call<string[]>();
        }

        /// <summary>Get loaded behaviors</summary>
		/// <returns>Return loaded behaviors</returns>
        public IQiFuture<string[]> GetLoadedBehaviorsAsync()
        {
            return SourceService["getLoadedBehaviors"].CallAsync<string[]>();
        }

        /// <summary>Get tags found on installed behaviors.</summary>
		/// <returns>The list of tags found.</returns>
        public string[] GetTagList()
        {
            return SourceService["getTagList"].Call<string[]>();
        }

        /// <summary>Get tags found on installed behaviors.</summary>
		/// <returns>The list of tags found.</returns>
        public IQiFuture<string[]> GetTagListAsync()
        {
            return SourceService["getTagList"].CallAsync<string[]>();
        }

        /// <summary>Get tags found on the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The list of tags found.</returns>
        public string[] GetBehaviorTags(string arg0_behavior)
        {
            return SourceService["getBehaviorTags"].Call<string[]>(arg0_behavior);
        }

        /// <summary>Get tags found on the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The list of tags found.</returns>
        public IQiFuture<string[]> GetBehaviorTagsAsync(string arg0_behavior)
        {
            return SourceService["getBehaviorTags"].CallAsync<string[]>(arg0_behavior);
        }

        /// <summary>Get the nature of the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The nature of the behavior.</returns>
        public string GetBehaviorNature(string arg0_behavior)
        {
            return SourceService["getBehaviorNature"].Call<string>(arg0_behavior);
        }

        /// <summary>Get the nature of the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The nature of the behavior.</returns>
        public IQiFuture<string> GetBehaviorNatureAsync(string arg0_behavior)
        {
            return SourceService["getBehaviorNature"].CallAsync<string>(arg0_behavior);
        }

        /// <summary>Get the relative path of a running behavior inside its package.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The relative path of the behavior.</returns>
        public string _getBehaviorRelativePath(string arg0_behaviorId)
        {
            return SourceService["_getBehaviorRelativePath"].Call<string>(arg0_behaviorId);
        }

        /// <summary>Get the relative path of a running behavior inside its package.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The relative path of the behavior.</returns>
        public IQiFuture<string> _getBehaviorRelativePathAsync(string arg0_behaviorId)
        {
            return SourceService["_getBehaviorRelativePath"].CallAsync<string>(arg0_behaviorId);
        }

        /// <summary>Get the package UID of a running behavior.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The package UID of the behavior.</returns>
        public string _getPackageUid(string arg0_behaviorId)
        {
            return SourceService["_getPackageUid"].Call<string>(arg0_behaviorId);
        }

        /// <summary>Get the package UID of a running behavior.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The package UID of the behavior.</returns>
        public IQiFuture<string> _getPackageUidAsync(string arg0_behaviorId)
        {
            return SourceService["_getPackageUid"].CallAsync<string>(arg0_behaviorId);
        }

        /// <summary>Set the given behavior as default</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void AddDefaultBehavior(string arg0_behavior)
        {
            SourceService["addDefaultBehavior"].Call(arg0_behavior);
        }

        /// <summary>Set the given behavior as default</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public IQiFuture AddDefaultBehaviorAsync(string arg0_behavior)
        {
            return SourceService["addDefaultBehavior"].CallAsync(arg0_behavior);
        }

        /// <summary>Remove the given behavior from the default behaviors</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void RemoveDefaultBehavior(string arg0_behavior)
        {
            SourceService["removeDefaultBehavior"].Call(arg0_behavior);
        }

        /// <summary>Remove the given behavior from the default behaviors</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public IQiFuture RemoveDefaultBehaviorAsync(string arg0_behavior)
        {
            return SourceService["removeDefaultBehavior"].CallAsync(arg0_behavior);
        }

        /// <summary>Get default behaviors</summary>
		/// <returns>Return default behaviors</returns>
        public string[] GetDefaultBehaviors()
        {
            return SourceService["getDefaultBehaviors"].Call<string[]>();
        }

        /// <summary>Get default behaviors</summary>
		/// <returns>Return default behaviors</returns>
        public IQiFuture<string[]> GetDefaultBehaviorsAsync()
        {
            return SourceService["getDefaultBehaviors"].CallAsync<string[]>();
        }

        /// <summary>Play default behaviors</summary>
		/// <returns></returns>
        public void PlayDefaultProject()
        {
            SourceService["playDefaultProject"].Call();
        }

        /// <summary>Play default behaviors</summary>
		/// <returns></returns>
        public IQiFuture PlayDefaultProjectAsync()
        {
            return SourceService["playDefaultProject"].CallAsync();
        }

        /// <summary>Be notified when something we have subscribe to has changed in ALMemory</summary>
		/// <param name="arg0_dataName">name of the data</param>
		/// <param name="arg1_dataValue">value of the data</param>
		/// <param name="arg2_message">callback message</param>
		/// <returns></returns>
        public void _onDataChanged(string arg0_dataName, object arg1_dataValue, string arg2_message)
        {
            SourceService["_onDataChanged"].Call(arg0_dataName, arg1_dataValue, arg2_message);
        }

        /// <summary>Be notified when something we have subscribe to has changed in ALMemory</summary>
		/// <param name="arg0_dataName">name of the data</param>
		/// <param name="arg1_dataValue">value of the data</param>
		/// <param name="arg2_message">callback message</param>
		/// <returns></returns>
        public IQiFuture _onDataChangedAsync(string arg0_dataName, object arg1_dataValue, string arg2_message)
        {
            return SourceService["_onDataChanged"].CallAsync(arg0_dataName, arg1_dataValue, arg2_message);
        }

        /// <summary>get the FrameManagerID. INTERNAL</summary>
		/// <param name="arg0_name">name of choregraphe project</param>
		/// <returns></returns>
        public string _getBehaviorFrameManagerId(string arg0_name)
        {
            return SourceService["_getBehaviorFrameManagerId"].Call<string>(arg0_name);
        }

        /// <summary>get the FrameManagerID. INTERNAL</summary>
		/// <param name="arg0_name">name of choregraphe project</param>
		/// <returns></returns>
        public IQiFuture<string> _getBehaviorFrameManagerIdAsync(string arg0_name)
        {
            return SourceService["_getBehaviorFrameManagerId"].CallAsync<string>(arg0_name);
        }

        /// <summary>Find out the actual &lt;package&gt;/&lt;behavior&gt; path behind a behavior name.</summary>
		/// <param name="arg0_name">name of a behavior</param>
		/// <returns>The actual &lt;package&gt;/&lt;behavior&gt; path if found, else an empty string. Throws an ALERROR if two behavior names conflicted.</returns>
        public string ResolveBehaviorName(string arg0_name)
        {
            return SourceService["resolveBehaviorName"].Call<string>(arg0_name);
        }

        /// <summary>Find out the actual &lt;package&gt;/&lt;behavior&gt; path behind a behavior name.</summary>
		/// <param name="arg0_name">name of a behavior</param>
		/// <returns>The actual &lt;package&gt;/&lt;behavior&gt; path if found, else an empty string. Throws an ALERROR if two behavior names conflicted.</returns>
        public IQiFuture<string> ResolveBehaviorNameAsync(string arg0_name)
        {
            return SourceService["resolveBehaviorName"].CallAsync<string>(arg0_name);
        }

    }
}