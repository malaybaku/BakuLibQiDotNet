using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manage link with devices (sensors and actuators). See specific documentation.</summary>
    public class DCM
	{
		internal DCM(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static DCM CreateService(IQiSession session)
		{
			var result = new DCM(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static DCM CreateUninitializedService(IQiSession session)
		{
			return new DCM(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("DCM");
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

        /// <summary>Call this function to send a timed-command list to an actuator</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public void Set(object arg0_commands)
        {
            SourceService["set"].Call(arg0_commands);
        }

        /// <summary>Call this function to send a timed-command list to an actuator</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public IQiFuture SetAsync(object arg0_commands)
        {
            return SourceService["set"].CallAsync(arg0_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators)</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public void SetAlias(object arg0_commands)
        {
            SourceService["setAlias"].Call(arg0_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators)</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public IQiFuture SetAliasAsync(object arg0_commands)
        {
            return SourceService["setAlias"].CallAsync(arg0_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators) with &quot;ClearAll&quot; merge startegy</summary>
		/// <param name="arg0_name">alias name</param>
		/// <param name="arg1_time">time for the timed command</param>
		/// <param name="arg2_commands">std::vector&lt;float&gt; with all commands</param>
		/// <returns></returns>
        public void SetAlias(string arg0_name, int arg1_time, IEnumerable<float> arg2_commands)
        {
            SourceService["setAlias"].Call(arg0_name, arg1_time, arg2_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators) with &quot;ClearAll&quot; merge startegy</summary>
		/// <param name="arg0_name">alias name</param>
		/// <param name="arg1_time">time for the timed command</param>
		/// <param name="arg2_commands">std::vector&lt;float&gt; with all commands</param>
		/// <returns></returns>
        public IQiFuture SetAliasAsync(string arg0_name, int arg1_time, IEnumerable<float> arg2_commands)
        {
            return SourceService["setAlias"].CallAsync(arg0_name, arg1_time, arg2_commands);
        }

        /// <summary>Return the DCM time</summary>
		/// <param name="arg0_offset">optional time in ms (signed) to add/remove</param>
		/// <returns>An integer (could be signed) with the DCM time</returns>
        public int GetTime(int arg0_offset)
        {
            return SourceService["getTime"].Call<int>(arg0_offset);
        }

        /// <summary>Return the DCM time</summary>
		/// <param name="arg0_offset">optional time in ms (signed) to add/remove</param>
		/// <returns>An integer (could be signed) with the DCM time</returns>
        public IQiFuture<int> GetTimeAsync(int arg0_offset)
        {
            return SourceService["getTime"].CallAsync<int>(arg0_offset);
        }

        /// <summary>Create or change an alias (list of actuators)</summary>
		/// <param name="arg0_alias">Alias name and description</param>
		/// <returns>Same as pParams, but with the name removed if the actuator is not found</returns>
        public IQiResult CreateAlias(object arg0_alias)
        {
            return SourceService["createAlias"].Call<IQiResult>(arg0_alias);
        }

        /// <summary>Create or change an alias (list of actuators)</summary>
		/// <param name="arg0_alias">Alias name and description</param>
		/// <returns>Same as pParams, but with the name removed if the actuator is not found</returns>
        public IQiFuture<IQiResult> CreateAliasAsync(object arg0_alias)
        {
            return SourceService["createAlias"].CallAsync<IQiResult>(arg0_alias);
        }

        /// <summary>Return the STM base name</summary>
		/// <returns>the STM base name for all device/sensors (1st string in the array) and all devices (2nd string in the array)</returns>
        public IQiResult GetPrefix()
        {
            return SourceService["getPrefix"].Call<IQiResult>();
        }

        /// <summary>Return the STM base name</summary>
		/// <returns>the STM base name for all device/sensors (1st string in the array) and all devices (2nd string in the array)</returns>
        public IQiFuture<IQiResult> GetPrefixAsync()
        {
            return SourceService["getPrefix"].CallAsync<IQiResult>();
        }

        /// <summary>Special DCM commands</summary>
		/// <param name="arg0_result">one string and could be Reset, Version, Chain, Diagnostic, Config</param>
		/// <returns></returns>
        public void Special(string arg0_result)
        {
            SourceService["special"].Call(arg0_result);
        }

        /// <summary>Special DCM commands</summary>
		/// <param name="arg0_result">one string and could be Reset, Version, Chain, Diagnostic, Config</param>
		/// <returns></returns>
        public IQiFuture SpecialAsync(string arg0_result)
        {
            return SourceService["special"].CallAsync(arg0_result);
        }

        /// <summary>Calibration of a joint</summary>
		/// <param name="arg0_calibrationInput">A complex ALValue. See red documentation</param>
		/// <returns></returns>
        public void Calibration(object arg0_calibrationInput)
        {
            SourceService["calibration"].Call(arg0_calibrationInput);
        }

        /// <summary>Calibration of a joint</summary>
		/// <param name="arg0_calibrationInput">A complex ALValue. See red documentation</param>
		/// <returns></returns>
        public IQiFuture CalibrationAsync(object arg0_calibrationInput)
        {
            return SourceService["calibration"].CallAsync(arg0_calibrationInput);
        }

        /// <summary>Save updated value from DCM in XML pref file</summary>
		/// <param name="arg0_action">string : 'Save' 'Load' 'Add'</param>
		/// <param name="arg1_target">string : 'Chest' 'Head' 'Main' 'All' </param>
		/// <param name="arg2_keyName">The name of the key if action = 'Add'.</param>
		/// <param name="arg3_keyValue">The ALVAlue of the key to add</param>
		/// <returns>Nothing</returns>
        public int Preferences(string arg0_action, string arg1_target, string arg2_keyName, object arg3_keyValue)
        {
            return SourceService["preferences"].Call<int>(arg0_action, arg1_target, arg2_keyName, arg3_keyValue);
        }

        /// <summary>Save updated value from DCM in XML pref file</summary>
		/// <param name="arg0_action">string : 'Save' 'Load' 'Add'</param>
		/// <param name="arg1_target">string : 'Chest' 'Head' 'Main' 'All' </param>
		/// <param name="arg2_keyName">The name of the key if action = 'Add'.</param>
		/// <param name="arg3_keyValue">The ALVAlue of the key to add</param>
		/// <returns>Nothing</returns>
        public IQiFuture<int> PreferencesAsync(string arg0_action, string arg1_target, string arg2_keyName, object arg3_keyValue)
        {
            return SourceService["preferences"].CallAsync<int>(arg0_action, arg1_target, arg2_keyName, arg3_keyValue);
        }

        /// <summary>Add or update data for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <param name="arg1_values">list of values (float, could be cast in int)</param>
		/// <returns>bool : false on error, true if ok</returns>
        public bool _injectionAdd(IEnumerable<string> arg0_key, IEnumerable<float> arg1_values)
        {
            return SourceService["_injectionAdd"].Call<bool>(arg0_key, arg1_values);
        }

        /// <summary>Add or update data for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <param name="arg1_values">list of values (float, could be cast in int)</param>
		/// <returns>bool : false on error, true if ok</returns>
        public IQiFuture<bool> _injectionAddAsync(IEnumerable<string> arg0_key, IEnumerable<float> arg1_values)
        {
            return SourceService["_injectionAdd"].CallAsync<bool>(arg0_key, arg1_values);
        }

        /// <summary>Stop datas injection</summary>
		/// <returns>Nothing</returns>
        public void _injectionStop()
        {
            SourceService["_injectionStop"].Call();
        }

        /// <summary>Stop datas injection</summary>
		/// <returns>Nothing</returns>
        public IQiFuture _injectionStopAsync()
        {
            return SourceService["_injectionStop"].CallAsync();
        }

        /// <summary>Remove datas for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <returns>Nothing</returns>
        public void _injectionRemove(IEnumerable<string> arg0_key)
        {
            SourceService["_injectionRemove"].Call(arg0_key);
        }

        /// <summary>Remove datas for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <returns>Nothing</returns>
        public IQiFuture _injectionRemoveAsync(IEnumerable<string> arg0_key)
        {
            return SourceService["_injectionRemove"].CallAsync(arg0_key);
        }

    }
}