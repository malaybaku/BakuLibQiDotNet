using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALPreferenceManager
	{
		internal ALPreferenceManager(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALPreferenceManager CreateService(IQiSession session)
		{
			var result = new ALPreferenceManager(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALPreferenceManager CreateUninitializedService(IQiSession session)
		{
			return new ALPreferenceManager(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALPreferenceManager");
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

        /// <summary>Get specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns>corresponding preferences value</returns>
        public IQiResult GetValue(string arg0_domain, string arg1_setting)
        {
            return SourceService["getValue"].Call<IQiResult>(arg0_domain, arg1_setting);
        }

        /// <summary>Get specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns>corresponding preferences value</returns>
        public IQiFuture<IQiResult> GetValueAsync(string arg0_domain, string arg1_setting)
        {
            return SourceService["getValue"].CallAsync<IQiResult>(arg0_domain, arg1_setting);
        }

        /// <summary>Set specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public void SetValue(string arg0_domain, string arg1_setting, object arg2_value)
        {
            SourceService["setValue"].Call(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Set specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public IQiFuture SetValueAsync(string arg0_domain, string arg1_setting, object arg2_value)
        {
            return SourceService["setValue"].CallAsync(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Get preferences names and values for a given domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns>a list of preferences names and values associated to the domain</returns>
        public IQiResult GetValueList(string arg0_domain)
        {
            return SourceService["getValueList"].Call<IQiResult>(arg0_domain);
        }

        /// <summary>Get preferences names and values for a given domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns>a list of preferences names and values associated to the domain</returns>
        public IQiFuture<IQiResult> GetValueListAsync(string arg0_domain)
        {
            return SourceService["getValueList"].CallAsync<IQiResult>(arg0_domain);
        }

        /// <summary>Get available preferences domain</summary>
		/// <returns>a list containing all the available domain names</returns>
        public string[] GetDomainList()
        {
            return SourceService["getDomainList"].Call<string[]>();
        }

        /// <summary>Get available preferences domain</summary>
		/// <returns>a list containing all the available domain names</returns>
        public IQiFuture<string[]> GetDomainListAsync()
        {
            return SourceService["getDomainList"].CallAsync<string[]>();
        }

        /// <summary>Remove specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns></returns>
        public void RemoveValue(string arg0_domain, string arg1_setting)
        {
            SourceService["removeValue"].Call(arg0_domain, arg1_setting);
        }

        /// <summary>Remove specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns></returns>
        public IQiFuture RemoveValueAsync(string arg0_domain, string arg1_setting)
        {
            return SourceService["removeValue"].CallAsync(arg0_domain, arg1_setting);
        }

        /// <summary>Add many values at once.</summary>
		/// <param name="arg0_values">A map (domain as index) of map (setting name as index) of values.</param>
		/// <returns></returns>
        public void SetValues(object arg0_values)
        {
            SourceService["setValues"].Call(arg0_values);
        }

        /// <summary>Add many values at once.</summary>
		/// <param name="arg0_values">A map (domain as index) of map (setting name as index) of values.</param>
		/// <returns></returns>
        public IQiFuture SetValuesAsync(object arg0_values)
        {
            return SourceService["setValues"].CallAsync(arg0_values);
        }

        /// <summary>Remove an entire preference domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns></returns>
        public void RemoveDomainValues(string arg0_domain)
        {
            SourceService["removeDomainValues"].Call(arg0_domain);
        }

        /// <summary>Remove an entire preference domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns></returns>
        public IQiFuture RemoveDomainValuesAsync(string arg0_domain)
        {
            return SourceService["removeDomainValues"].CallAsync(arg0_domain);
        }

        /// <summary>Import a preferences XML file</summary>
		/// <param name="arg0_domain">Preference domain: all preferences values found in XML file will be imported in that domain.</param>
		/// <param name="arg1_applicationName">Application name: will be used to search for preference file on disk (in location of type &lt;configurationdirectory&gt;/applicationName/filename).</param>
		/// <param name="arg2_filename">Preference XML filename</param>
		/// <param name="arg3_override">Set this to true if you want to override preferences that already exist with preferences in imported XML file</param>
		/// <returns></returns>
        public void ImportPrefFile(string arg0_domain, string arg1_applicationName, string arg2_filename, bool arg3_override)
        {
            SourceService["importPrefFile"].Call(arg0_domain, arg1_applicationName, arg2_filename, arg3_override);
        }

        /// <summary>Import a preferences XML file</summary>
		/// <param name="arg0_domain">Preference domain: all preferences values found in XML file will be imported in that domain.</param>
		/// <param name="arg1_applicationName">Application name: will be used to search for preference file on disk (in location of type &lt;configurationdirectory&gt;/applicationName/filename).</param>
		/// <param name="arg2_filename">Preference XML filename</param>
		/// <param name="arg3_override">Set this to true if you want to override preferences that already exist with preferences in imported XML file</param>
		/// <returns></returns>
        public IQiFuture ImportPrefFileAsync(string arg0_domain, string arg1_applicationName, string arg2_filename, bool arg3_override)
        {
            return SourceService["importPrefFile"].CallAsync(arg0_domain, arg1_applicationName, arg2_filename, arg3_override);
        }

        /// <summary>Synchronizes local preferences with preferences stored on a server.</summary>
		/// <returns></returns>
        public void Update()
        {
            SourceService["update"].Call();
        }

        /// <summary>Synchronizes local preferences with preferences stored on a server.</summary>
		/// <returns></returns>
        public IQiFuture UpdateAsync()
        {
            return SourceService["update"].CallAsync();
        }

        /// <summary>Update local preference from version store on Cloud (usefull when preference was updated on Cloud)</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public void _setFromCloud(string arg0_domain, string arg1_setting, object arg2_value)
        {
            SourceService["_setFromCloud"].Call(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Update local preference from version store on Cloud (usefull when preference was updated on Cloud)</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public IQiFuture _setFromCloudAsync(string arg0_domain, string arg1_setting, object arg2_value)
        {
            return SourceService["_setFromCloud"].CallAsync(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Restart preferences module</summary>
		/// <param name="arg0_url">Preference server url</param>
		/// <param name="arg1_path">Path to sqlite database</param>
		/// <returns></returns>
        public void _restart(string arg0_url, string arg1_path)
        {
            SourceService["_restart"].Call(arg0_url, arg1_path);
        }

        /// <summary>Restart preferences module</summary>
		/// <param name="arg0_url">Preference server url</param>
		/// <param name="arg1_path">Path to sqlite database</param>
		/// <returns></returns>
        public IQiFuture _restartAsync(string arg0_url, string arg1_path)
        {
            return SourceService["_restart"].CallAsync(arg0_url, arg1_path);
        }

        /// <summary>Internal callback.</summary>
		/// <param name="arg0_string">variable</param>
		/// <param name="arg1_string">value</param>
		/// <param name="arg2_string">message</param>
		/// <returns></returns>
        public void _onConnectivityChanged(string arg0_string, object arg1_string, string arg2_string)
        {
            SourceService["_onConnectivityChanged"].Call(arg0_string, arg1_string, arg2_string);
        }

        /// <summary>Internal callback.</summary>
		/// <param name="arg0_string">variable</param>
		/// <param name="arg1_string">value</param>
		/// <param name="arg2_string">message</param>
		/// <returns></returns>
        public IQiFuture _onConnectivityChangedAsync(string arg0_string, object arg1_string, string arg2_string)
        {
            return SourceService["_onConnectivityChanged"].CallAsync(arg0_string, arg1_string, arg2_string);
        }

    }
}