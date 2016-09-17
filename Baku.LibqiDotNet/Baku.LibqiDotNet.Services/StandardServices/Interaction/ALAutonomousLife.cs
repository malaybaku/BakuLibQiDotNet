using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manages the focused Activity and Autonomous Life state</summary>
    public class ALAutonomousLife
	{
		internal ALAutonomousLife(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALAutonomousLife CreateService(IQiSession session)
		{
			var result = new ALAutonomousLife(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALAutonomousLife CreateUninitializedService(IQiSession session)
		{
			return new ALAutonomousLife(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALAutonomousLife");
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

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceChanged(string arg0, object arg1, string arg2)
        {
            SourceService["_onPreferenceChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onPreferenceChangedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onPreferenceChanged"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void OnReady(string arg0, object arg1, string arg2)
        {
            SourceService["onReady"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture OnReadyAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["onReady"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onRobotHealthChanged(string arg0, object arg1, string arg2)
        {
            SourceService["_onRobotHealthChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onRobotHealthChangedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onRobotHealthChanged"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPushRecovery(string arg0, object arg1, string arg2)
        {
            SourceService["_onPushRecovery"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onPushRecoveryAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onPushRecovery"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onFallRecovery(string arg0, object arg1, string arg2)
        {
            SourceService["_onFallRecovery"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onFallRecoveryAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onFallRecovery"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onRobotMoved(string arg0, object arg1, string arg2)
        {
            SourceService["_onRobotMoved"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onRobotMovedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onRobotMoved"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0_enabled">Enabled/Disable the setState() method.</param>
		/// <returns></returns>
        public void _setStateChangeEnabled(bool arg0_enabled)
        {
            SourceService["_setStateChangeEnabled"].Call(arg0_enabled);
        }

        /// <summary></summary>
		/// <param name="arg0_enabled">Enabled/Disable the setState() method.</param>
		/// <returns></returns>
        public IQiFuture _setStateChangeEnabledAsync(bool arg0_enabled)
        {
            return SourceService["_setStateChangeEnabled"].CallAsync(arg0_enabled);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _loadConfigFile(string arg0)
        {
            SourceService["_loadConfigFile"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _loadConfigFileAsync(string arg0)
        {
            return SourceService["_loadConfigFile"].CallAsync(arg0);
        }

        /// <summary>Programatically control the state of Autonomous Life</summary>
		/// <param name="arg0_state">The possible states of AutonomousLife are: interactive, solitary, safeguard, disabled</param>
		/// <returns></returns>
        public void SetState(string arg0_state)
        {
            SourceService["setState"].Call(arg0_state);
        }

        /// <summary>Programatically control the state of Autonomous Life</summary>
		/// <param name="arg0_state">The possible states of AutonomousLife are: interactive, solitary, safeguard, disabled</param>
		/// <returns></returns>
        public IQiFuture SetStateAsync(string arg0_state)
        {
            return SourceService["setState"].CallAsync(arg0_state);
        }

        /// <summary>Returns the current state of AutonomousLife</summary>
		/// <returns>Can be: solitary, interactive, safeguard, disabled</returns>
        public string GetState()
        {
            return SourceService["getState"].Call<string>();
        }

        /// <summary>Returns the current state of AutonomousLife</summary>
		/// <returns>Can be: solitary, interactive, safeguard, disabled</returns>
        public IQiFuture<string> GetStateAsync()
        {
            return SourceService["getState"].CallAsync<string>();
        }

        /// <summary>Returns the currently focused activity</summary>
		/// <returns>The name of the focused activity</returns>
        public string FocusedActivity()
        {
            return SourceService["focusedActivity"].Call<string>();
        }

        /// <summary>Returns the currently focused activity</summary>
		/// <returns>The name of the focused activity</returns>
        public IQiFuture<string> FocusedActivityAsync()
        {
            return SourceService["focusedActivity"].CallAsync<string>();
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <returns></returns>
        public void SwitchFocus(string arg0_activity_name)
        {
            SourceService["switchFocus"].Call(arg0_activity_name);
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <returns></returns>
        public IQiFuture SwitchFocusAsync(string arg0_activity_name)
        {
            return SourceService["switchFocus"].CallAsync(arg0_activity_name);
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <param name="arg1_flags">Int flags for focus changing. STOP_CURRENT(0) or STOP_AND_STACK_CURRENT(1)</param>
		/// <returns></returns>
        public void SwitchFocus(string arg0_activity_name, int arg1_flags)
        {
            SourceService["switchFocus"].Call(arg0_activity_name, arg1_flags);
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <param name="arg1_flags">Int flags for focus changing. STOP_CURRENT(0) or STOP_AND_STACK_CURRENT(1)</param>
		/// <returns></returns>
        public IQiFuture SwitchFocusAsync(string arg0_activity_name, int arg1_flags)
        {
            return SourceService["switchFocus"].CallAsync(arg0_activity_name, arg1_flags);
        }

        /// <summary>Stops the focused activity. If another activity is stacked it will be started.</summary>
		/// <returns></returns>
        public void StopFocus()
        {
            SourceService["stopFocus"].Call();
        }

        /// <summary>Stops the focused activity. If another activity is stacked it will be started.</summary>
		/// <returns></returns>
        public IQiFuture StopFocusAsync()
        {
            return SourceService["stopFocus"].CallAsync();
        }

        /// <summary>Stops the focused activity and clears stack of activities</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary>Stops the focused activity and clears stack of activities</summary>
		/// <returns></returns>
        public IQiFuture StopAllAsync()
        {
            return SourceService["stopAll"].CallAsync();
        }

        /// <summary>Get a value of an ALMemory key that is used in a condition, which is the value at the previous autonomous activity focus.</summary>
		/// <param name="arg0_name">Name of the ALMemory key to get.  Will throw if key is not used in any activity conditions.</param>
		/// <returns>An array of the ALValue of the memory key and timestamp of when it was set: [seconds, microseconds, value]</returns>
        public IQiResult GetFocusContext(string arg0_name)
        {
            return SourceService["getFocusContext"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Get a value of an ALMemory key that is used in a condition, which is the value at the previous autonomous activity focus.</summary>
		/// <param name="arg0_name">Name of the ALMemory key to get.  Will throw if key is not used in any activity conditions.</param>
		/// <returns>An array of the ALValue of the memory key and timestamp of when it was set: [seconds, microseconds, value]</returns>
        public IQiFuture<IQiResult> GetFocusContextAsync(string arg0_name)
        {
            return SourceService["getFocusContext"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Get a list of permissions that would be violated by a given activity in the current context.</summary>
		/// <param name="arg0_name">The name of the activity to check.</param>
		/// <returns>An array of strings of the violated permissions. EG: [&quot;nature&quot;, &quot;canRunOnPod&quot;, &quot;canRunInSleep&quot;]</returns>
        public string[] GetActivityContextPermissionViolations(string arg0_name)
        {
            return SourceService["getActivityContextPermissionViolations"].Call<string[]>(arg0_name);
        }

        /// <summary>Get a list of permissions that would be violated by a given activity in the current context.</summary>
		/// <param name="arg0_name">The name of the activity to check.</param>
		/// <returns>An array of strings of the violated permissions. EG: [&quot;nature&quot;, &quot;canRunOnPod&quot;, &quot;canRunInSleep&quot;]</returns>
        public IQiFuture<string[]> GetActivityContextPermissionViolationsAsync(string arg0_name)
        {
            return SourceService["getActivityContextPermissionViolations"].CallAsync<string[]>(arg0_name);
        }

        /// <summary>Returns the nature of an activity</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to check</param>
		/// <returns>Possible values are: solitary, interactive</returns>
        public string GetActivityNature(string arg0_activity_name)
        {
            return SourceService["getActivityNature"].Call<string>(arg0_activity_name);
        }

        /// <summary>Returns the nature of an activity</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to check</param>
		/// <returns>Possible values are: solitary, interactive</returns>
        public IQiFuture<string> GetActivityNatureAsync(string arg0_activity_name)
        {
            return SourceService["getActivityNature"].CallAsync<string>(arg0_activity_name);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult GetActivityStatistics()
        {
            return SourceService["getActivityStatistics"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetActivityStatisticsAsync()
        {
            return SourceService["getActivityStatistics"].CallAsync<IQiResult>();
        }

        /// <summary>Get launch count, last completion time, etc for activities with autonomous launch trigger conditions.</summary>
		/// <returns>A map of activity names, with a cooresponding map of  &quot;prevStartTime&quot;, &quot;prevCompletionTime&quot;, &quot;startCount&quot;, &quot;totalDuration&quot;. Times are 0 for unlaunched Activities</returns>
        public IQiResult GetAutonomousActivityStatistics()
        {
            return SourceService["getAutonomousActivityStatistics"].Call<IQiResult>();
        }

        /// <summary>Get launch count, last completion time, etc for activities with autonomous launch trigger conditions.</summary>
		/// <returns>A map of activity names, with a cooresponding map of  &quot;prevStartTime&quot;, &quot;prevCompletionTime&quot;, &quot;startCount&quot;, &quot;totalDuration&quot;. Times are 0 for unlaunched Activities</returns>
        public IQiFuture<IQiResult> GetAutonomousActivityStatisticsAsync()
        {
            return SourceService["getAutonomousActivityStatistics"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult GetFocusHistory()
        {
            return SourceService["getFocusHistory"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetFocusHistoryAsync()
        {
            return SourceService["getFocusHistory"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetFocusHistory(int arg0)
        {
            return SourceService["getFocusHistory"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetFocusHistoryAsync(int arg0)
        {
            return SourceService["getFocusHistory"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult GetStateHistory()
        {
            return SourceService["getStateHistory"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetStateHistoryAsync()
        {
            return SourceService["getStateHistory"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetStateHistory(int arg0)
        {
            return SourceService["getStateHistory"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetStateHistoryAsync(int arg0)
        {
            return SourceService["getStateHistory"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Get the time in seconds as life sees it.  Based on gettimeofday()</summary>
		/// <returns>The int time in seconds as Autonomous Life sees it</returns>
        public int GetLifeTime()
        {
            return SourceService["getLifeTime"].Call<int>();
        }

        /// <summary>Get the time in seconds as life sees it.  Based on gettimeofday()</summary>
		/// <returns>The int time in seconds as Autonomous Life sees it</returns>
        public IQiFuture<int> GetLifeTimeAsync()
        {
            return SourceService["getLifeTime"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void SetAutonomousAbilityEnabled(string arg0, bool arg1)
        {
            SourceService["setAutonomousAbilityEnabled"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture SetAutonomousAbilityEnabledAsync(string arg0, bool arg1)
        {
            return SourceService["setAutonomousAbilityEnabled"].CallAsync(arg0, arg1);
        }

        /// <summary>Know is an Autonomous Ability is enabled or not</summary>
		/// <param name="arg0_autonomousAbility">The Autonomous Ability.</param>
		/// <returns>True if the Autonomous Ability is enabled, False otherwise.</returns>
        public bool GetAutonomousAbilityEnabled(string arg0_autonomousAbility)
        {
            return SourceService["getAutonomousAbilityEnabled"].Call<bool>(arg0_autonomousAbility);
        }

        /// <summary>Know is an Autonomous Ability is enabled or not</summary>
		/// <param name="arg0_autonomousAbility">The Autonomous Ability.</param>
		/// <returns>True if the Autonomous Ability is enabled, False otherwise.</returns>
        public IQiFuture<bool> GetAutonomousAbilityEnabledAsync(string arg0_autonomousAbility)
        {
            return SourceService["getAutonomousAbilityEnabled"].CallAsync<bool>(arg0_autonomousAbility);
        }

        /// <summary>Get the Autonomous Abilities status (get the autonomous abilities name and booleans to know if they are enabled or running</summary>
		/// <returns>The Autonomous Abilities status. A vector containing a status for each autonomous ability. Each status is composed of the autonomous ability name, a boolean to know if it's enabled and another boolean to know if it's running.</returns>
        public IQiResult GetAutonomousAbilitiesStatus()
        {
            return SourceService["getAutonomousAbilitiesStatus"].Call<IQiResult>();
        }

        /// <summary>Get the Autonomous Abilities status (get the autonomous abilities name and booleans to know if they are enabled or running</summary>
		/// <returns>The Autonomous Abilities status. A vector containing a status for each autonomous ability. Each status is composed of the autonomous ability name, a boolean to know if it's enabled and another boolean to know if it's running.</returns>
        public IQiFuture<IQiResult> GetAutonomousAbilitiesStatusAsync()
        {
            return SourceService["getAutonomousAbilitiesStatus"].CallAsync<IQiResult>();
        }

        /// <summary>Start monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public void StartMonitoringLaunchpadConditions()
        {
            SourceService["startMonitoringLaunchpadConditions"].Call();
        }

        /// <summary>Start monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public IQiFuture StartMonitoringLaunchpadConditionsAsync()
        {
            return SourceService["startMonitoringLaunchpadConditions"].CallAsync();
        }

        /// <summary>Stop monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public void StopMonitoringLaunchpadConditions()
        {
            SourceService["stopMonitoringLaunchpadConditions"].Call();
        }

        /// <summary>Stop monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public IQiFuture StopMonitoringLaunchpadConditionsAsync()
        {
            return SourceService["stopMonitoringLaunchpadConditions"].CallAsync();
        }

        /// <summary>Gets running status of AutonomousLaunchpad</summary>
		/// <returns>True if AutonomousLaunchpad is monitoring ALMemory and reporting conditional triggers.</returns>
        public bool IsMonitoringLaunchpadConditions()
        {
            return SourceService["isMonitoringLaunchpadConditions"].Call<bool>();
        }

        /// <summary>Gets running status of AutonomousLaunchpad</summary>
		/// <returns>True if AutonomousLaunchpad is monitoring ALMemory and reporting conditional triggers.</returns>
        public IQiFuture<bool> IsMonitoringLaunchpadConditionsAsync()
        {
            return SourceService["isMonitoringLaunchpadConditions"].CallAsync<bool>();
        }

        /// <summary>Temporarily enables/disables AutonomousLaunchpad Plugins</summary>
		/// <param name="arg0_plugin_name">The name of the plugin to enable/disable</param>
		/// <param name="arg1_enabled">Whether or not to enable this plugin</param>
		/// <returns></returns>
        public void SetLaunchpadPluginEnabled(string arg0_plugin_name, bool arg1_enabled)
        {
            SourceService["setLaunchpadPluginEnabled"].Call(arg0_plugin_name, arg1_enabled);
        }

        /// <summary>Temporarily enables/disables AutonomousLaunchpad Plugins</summary>
		/// <param name="arg0_plugin_name">The name of the plugin to enable/disable</param>
		/// <param name="arg1_enabled">Whether or not to enable this plugin</param>
		/// <returns></returns>
        public IQiFuture SetLaunchpadPluginEnabledAsync(string arg0_plugin_name, bool arg1_enabled)
        {
            return SourceService["setLaunchpadPluginEnabled"].CallAsync(arg0_plugin_name, arg1_enabled);
        }

        /// <summary>Get a list of enabled AutonomousLaunchpad Plugins.  Enabled plugins will run when AutonomousLaunchpad is started</summary>
		/// <returns>A list of strings of enabled plugins.</returns>
        public string[] GetEnabledLaunchpadPlugins()
        {
            return SourceService["getEnabledLaunchpadPlugins"].Call<string[]>();
        }

        /// <summary>Get a list of enabled AutonomousLaunchpad Plugins.  Enabled plugins will run when AutonomousLaunchpad is started</summary>
		/// <returns>A list of strings of enabled plugins.</returns>
        public IQiFuture<string[]> GetEnabledLaunchpadPluginsAsync()
        {
            return SourceService["getEnabledLaunchpadPlugins"].CallAsync<string[]>();
        }

        /// <summary>Get a list of AutonomousLaunchpad Plugins that belong to specified group</summary>
		/// <param name="arg0_group">The group to search for the plugins</param>
		/// <returns>A list of strings of the plugins belonging to the group.</returns>
        public string[] GetLaunchpadPluginsForGroup(string arg0_group)
        {
            return SourceService["getLaunchpadPluginsForGroup"].Call<string[]>(arg0_group);
        }

        /// <summary>Get a list of AutonomousLaunchpad Plugins that belong to specified group</summary>
		/// <param name="arg0_group">The group to search for the plugins</param>
		/// <returns>A list of strings of the plugins belonging to the group.</returns>
        public IQiFuture<string[]> GetLaunchpadPluginsForGroupAsync(string arg0_group)
        {
            return SourceService["getLaunchpadPluginsForGroup"].CallAsync<string[]>(arg0_group);
        }

        /// <summary>Set the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <param name="arg0_offset">The new vertical offset (in meters)</param>
		/// <returns></returns>
        public void SetRobotOffsetFromFloor(float arg0_offset)
        {
            SourceService["setRobotOffsetFromFloor"].Call(arg0_offset);
        }

        /// <summary>Set the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <param name="arg0_offset">The new vertical offset (in meters)</param>
		/// <returns></returns>
        public IQiFuture SetRobotOffsetFromFloorAsync(float arg0_offset)
        {
            return SourceService["setRobotOffsetFromFloor"].CallAsync(arg0_offset);
        }

        /// <summary>Get the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <returns>Current vertical offset (in meters)</returns>
        public float GetRobotOffsetFromFloor()
        {
            return SourceService["getRobotOffsetFromFloor"].Call<float>();
        }

        /// <summary>Get the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <returns>Current vertical offset (in meters)</returns>
        public IQiFuture<float> GetRobotOffsetFromFloorAsync()
        {
            return SourceService["getRobotOffsetFromFloor"].CallAsync<float>();
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidAutonomousInteractiveStateChange(bool arg0_is_forbidden)
        {
            SourceService["_forbidAutonomousInteractiveStateChange"].Call(arg0_is_forbidden);
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public IQiFuture _forbidAutonomousInteractiveStateChangeAsync(bool arg0_is_forbidden)
        {
            return SourceService["_forbidAutonomousInteractiveStateChange"].CallAsync(arg0_is_forbidden);
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidAutonomousActivityFocusSwitch(bool arg0_is_forbidden)
        {
            SourceService["_forbidAutonomousActivityFocusSwitch"].Call(arg0_is_forbidden);
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public IQiFuture _forbidAutonomousActivityFocusSwitchAsync(bool arg0_is_forbidden)
        {
            return SourceService["_forbidAutonomousActivityFocusSwitch"].CallAsync(arg0_is_forbidden);
        }

        /// <summary>Set if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <param name="arg1_enabled">True if life handles the safeguard.</param>
		/// <returns></returns>
        public void SetSafeguardEnabled(string arg0_name, bool arg1_enabled)
        {
            SourceService["setSafeguardEnabled"].Call(arg0_name, arg1_enabled);
        }

        /// <summary>Set if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <param name="arg1_enabled">True if life handles the safeguard.</param>
		/// <returns></returns>
        public IQiFuture SetSafeguardEnabledAsync(string arg0_name, bool arg1_enabled)
        {
            return SourceService["setSafeguardEnabled"].CallAsync(arg0_name, arg1_enabled);
        }

        /// <summary>Get if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <returns>True if life handles the safeguard.</returns>
        public bool IsSafeguardEnabled(string arg0_name)
        {
            return SourceService["isSafeguardEnabled"].Call<bool>(arg0_name);
        }

        /// <summary>Get if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <returns>True if life handles the safeguard.</returns>
        public IQiFuture<bool> IsSafeguardEnabledAsync(string arg0_name)
        {
            return SourceService["isSafeguardEnabled"].CallAsync<bool>(arg0_name);
        }

        /// <summary>Get if the movedsafeguard will be instantaneous, or end when move is stopped</summary>
		/// <returns>True if safeguard is instantaneous, false if safeguard exited after move stopped.</returns>
        public bool _isMovedSafeguardInstantaneous()
        {
            return SourceService["_isMovedSafeguardInstantaneous"].Call<bool>();
        }

        /// <summary>Get if the movedsafeguard will be instantaneous, or end when move is stopped</summary>
		/// <returns>True if safeguard is instantaneous, false if safeguard exited after move stopped.</returns>
        public IQiFuture<bool> _isMovedSafeguardInstantaneousAsync()
        {
            return SourceService["_isMovedSafeguardInstantaneous"].CallAsync<bool>();
        }

        /// <summary>Set how long to stay in safeguard state if robot pushed.</summary>
		/// <param name="arg0_duration_ms">Time in milliseconds to stay in safeguard state.</param>
		/// <returns></returns>
        public void _setPushRecoverySafeguardDuration(int arg0_duration_ms)
        {
            SourceService["_setPushRecoverySafeguardDuration"].Call(arg0_duration_ms);
        }

        /// <summary>Set how long to stay in safeguard state if robot pushed.</summary>
		/// <param name="arg0_duration_ms">Time in milliseconds to stay in safeguard state.</param>
		/// <returns></returns>
        public IQiFuture _setPushRecoverySafeguardDurationAsync(int arg0_duration_ms)
        {
            return SourceService["_setPushRecoverySafeguardDuration"].CallAsync(arg0_duration_ms);
        }

        /// <summary>Get how long to stay in safeguard state if robot pushed.</summary>
		/// <returns>Time in milliseconds to stay in safeguard state.</returns>
        public int _getPushRecoverySafeguardDuration()
        {
            return SourceService["_getPushRecoverySafeguardDuration"].Call<int>();
        }

        /// <summary>Get how long to stay in safeguard state if robot pushed.</summary>
		/// <returns>Time in milliseconds to stay in safeguard state.</returns>
        public IQiFuture<int> _getPushRecoverySafeguardDurationAsync()
        {
            return SourceService["_getPushRecoverySafeguardDuration"].CallAsync<int>();
        }

        /// <summary>Put the robot to sleep.</summary>
		/// <returns></returns>
        public void _sleep()
        {
            SourceService["_sleep"].Call();
        }

        /// <summary>Put the robot to sleep.</summary>
		/// <returns></returns>
        public IQiFuture _sleepAsync()
        {
            return SourceService["_sleep"].CallAsync();
        }

        /// <summary>Wake the robot up.</summary>
		/// <returns></returns>
        public void _wakeUp()
        {
            SourceService["_wakeUp"].Call();
        }

        /// <summary>Wake the robot up.</summary>
		/// <returns></returns>
        public IQiFuture _wakeUpAsync()
        {
            return SourceService["_wakeUp"].CallAsync();
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidStopCommands(bool arg0_is_forbidden)
        {
            SourceService["_forbidStopCommands"].Call(arg0_is_forbidden);
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public IQiFuture _forbidStopCommandsAsync(bool arg0_is_forbidden)
        {
            return SourceService["_forbidStopCommands"].CallAsync(arg0_is_forbidden);
        }

    }
}