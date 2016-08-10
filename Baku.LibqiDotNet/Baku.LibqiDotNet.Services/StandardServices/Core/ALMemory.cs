using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALMemory provides a centralized memory that can be used to store and retrieve named values. It also acts as a hub for the distribution of event notifications.</summary>
    public class ALMemory
	{
		internal ALMemory(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALMemory CreateService(IQiSession session)
		{
			var result = new ALMemory(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALMemory CreateUninitializedService(IQiSession session)
		{
			return new ALMemory(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALMemory");
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

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <returns></returns>
        public void DeclareEvent(string arg0_eventName)
        {
            SourceService["declareEvent"].Call(arg0_eventName);
        }

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <returns></returns>
        public IQiFuture DeclareEventAsync(string arg0_eventName)
        {
            return SourceService["declareEvent"].CallAsync(arg0_eventName);
        }

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <param name="arg1_extractorName">The name of the extractor capable of creating the event</param>
		/// <returns></returns>
        public void DeclareEvent(string arg0_eventName, string arg1_extractorName)
        {
            SourceService["declareEvent"].Call(arg0_eventName, arg1_extractorName);
        }

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <param name="arg1_extractorName">The name of the extractor capable of creating the event</param>
		/// <returns></returns>
        public IQiFuture DeclareEventAsync(string arg0_eventName, string arg1_extractorName)
        {
            return SourceService["declareEvent"].CallAsync(arg0_eventName, arg1_extractorName);
        }

        /// <summary>Gets the value of a key-value pair stored in memory</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <returns>The data as an ALValue. This can often be cast transparently into the original type.</returns>
        public IQiResult GetData(string arg0_key)
        {
            return SourceService["getData"].Call<IQiResult>(arg0_key);
        }

        /// <summary>Gets the value of a key-value pair stored in memory</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <returns>The data as an ALValue. This can often be cast transparently into the original type.</returns>
        public IQiFuture<IQiResult> GetDataAsync(string arg0_key)
        {
            return SourceService["getData"].CallAsync<IQiResult>(arg0_key);
        }

        /// <summary>DEPRECATED - Gets the value of a key-value pair stored in memory. Please use the version of this method with no second parameter.</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - This parameter has no effect, but is left for compatibility reason.</param>
		/// <returns>The data as an ALValue</returns>
        public IQiResult GetData(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getData"].Call<IQiResult>(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>DEPRECATED - Gets the value of a key-value pair stored in memory. Please use the version of this method with no second parameter.</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - This parameter has no effect, but is left for compatibility reason.</param>
		/// <returns>The data as an ALValue</returns>
        public IQiFuture<IQiResult> GetDataAsync(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getData"].CallAsync<IQiResult>(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>Get an object wrapping a signal bound to the given ALMemory event. Creates the event if it does not exist.</summary>
		/// <param name="arg0_eventName">Name of the ALMemory event</param>
		/// <returns>An AnyObject with a signal named &quot;signal&quot;</returns>
        public IQiSignal Subscriber(string arg0_eventName)
        {
            return SourceService["subscriber"].Call<IQiSignal>(arg0_eventName);
        }

        /// <summary>Get an object wrapping a signal bound to the given ALMemory event. Creates the event if it does not exist.</summary>
		/// <param name="arg0_eventName">Name of the ALMemory event</param>
		/// <returns>An AnyObject with a signal named &quot;signal&quot;</returns>
        public IQiFuture<IQiSignal> SubscriberAsync(string arg0_eventName)
        {
            return SourceService["subscriber"].CallAsync<IQiSignal>(arg0_eventName);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public IQiResult GetTimestamp(string arg0_key)
        {
            return SourceService["getTimestamp"].Call<IQiResult>(arg0_key);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public IQiFuture<IQiResult> GetTimestampAsync(string arg0_key)
        {
            return SourceService["getTimestamp"].CallAsync<IQiResult>(arg0_key);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public IQiResult GetEventHistory(string arg0_key)
        {
            return SourceService["getEventHistory"].Call<IQiResult>(arg0_key);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public IQiFuture<IQiResult> GetEventHistoryAsync(string arg0_key)
        {
            return SourceService["getEventHistory"].CallAsync<IQiResult>(arg0_key);
        }

        /// <summary>Gets a list of all key names that contain a given string</summary>
		/// <param name="arg0_filter">A string used as the search term</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public string[] GetDataList(string arg0_filter)
        {
            return SourceService["getDataList"].Call<string[]>(arg0_filter);
        }

        /// <summary>Gets a list of all key names that contain a given string</summary>
		/// <param name="arg0_filter">A string used as the search term</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public IQiFuture<string[]> GetDataListAsync(string arg0_filter)
        {
            return SourceService["getDataList"].CallAsync<string[]>(arg0_filter);
        }

        /// <summary>Gets the key names for all the key-value pairs in memory</summary>
		/// <returns>A list containing the keys in memory</returns>
        public string[] GetDataListName()
        {
            return SourceService["getDataListName"].Call<string[]>();
        }

        /// <summary>Gets the key names for all the key-value pairs in memory</summary>
		/// <returns>A list containing the keys in memory</returns>
        public IQiFuture<string[]> GetDataListNameAsync()
        {
            return SourceService["getDataListName"].CallAsync<string[]>();
        }

        /// <summary>DEPRECATED - Blocks the caller until the value of a key changes</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - this parameter has no effect</param>
		/// <returns>an array containing all the retrieved data</returns>
        public IQiResult GetDataOnChange(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getDataOnChange"].Call<IQiResult>(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>DEPRECATED - Blocks the caller until the value of a key changes</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - this parameter has no effect</param>
		/// <returns>an array containing all the retrieved data</returns>
        public IQiFuture<IQiResult> GetDataOnChangeAsync(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getDataOnChange"].CallAsync<IQiResult>(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>Gets a pointer to 32 a bit data item. Beware, the pointer will only be valid during the lifetime of the ALMemory object. Use with care, at initialization, not every loop.</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <returns>A pointer converted to int</returns>
        public IQiResult GetDataPtr(string arg0_key)
        {
            return SourceService["getDataPtr"].Call<IQiResult>(arg0_key);
        }

        /// <summary>Gets a pointer to 32 a bit data item. Beware, the pointer will only be valid during the lifetime of the ALMemory object. Use with care, at initialization, not every loop.</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <returns>A pointer converted to int</returns>
        public IQiFuture<IQiResult> GetDataPtrAsync(string arg0_key)
        {
            return SourceService["getDataPtr"].CallAsync<IQiResult>(arg0_key);
        }

        /// <summary>Gets a list containing the names of all the declared events</summary>
		/// <returns>A list containing the names of all events</returns>
        public string[] GetEventList()
        {
            return SourceService["getEventList"].Call<string[]>();
        }

        /// <summary>Gets a list containing the names of all the declared events</summary>
		/// <returns>A list containing the names of all events</returns>
        public IQiFuture<string[]> GetEventListAsync()
        {
            return SourceService["getEventList"].CallAsync<string[]>();
        }

        /// <summary>Gets the list of all events generated by a given extractor</summary>
		/// <param name="arg0_extractorName">The name of the extractor</param>
		/// <returns>A list containing the names of the events associated with the given extractor</returns>
        public string[] GetExtractorEvent(string arg0_extractorName)
        {
            return SourceService["getExtractorEvent"].Call<string[]>(arg0_extractorName);
        }

        /// <summary>Gets the list of all events generated by a given extractor</summary>
		/// <param name="arg0_extractorName">The name of the extractor</param>
		/// <returns>A list containing the names of the events associated with the given extractor</returns>
        public IQiFuture<string[]> GetExtractorEventAsync(string arg0_extractorName)
        {
            return SourceService["getExtractorEvent"].CallAsync<string[]>(arg0_extractorName);
        }

        /// <summary>Gets the values associated with the given list of keys. This is more efficient than calling getData many times, especially over the network.</summary>
		/// <param name="arg0_keyList">An array containing the key names.</param>
		/// <returns>An array containing all the values corresponding to the given keys.</returns>
        public IQiResult GetListData(object arg0_keyList)
        {
            return SourceService["getListData"].Call<IQiResult>(arg0_keyList);
        }

        /// <summary>Gets the values associated with the given list of keys. This is more efficient than calling getData many times, especially over the network.</summary>
		/// <param name="arg0_keyList">An array containing the key names.</param>
		/// <returns>An array containing all the values corresponding to the given keys.</returns>
        public IQiFuture<IQiResult> GetListDataAsync(object arg0_keyList)
        {
            return SourceService["getListData"].CallAsync<IQiResult>(arg0_keyList);
        }

        /// <summary>Gets a list containing the names of all the declared micro events</summary>
		/// <returns>A list containing the names of all the microEvents</returns>
        public string[] GetMicroEventList()
        {
            return SourceService["getMicroEventList"].Call<string[]>();
        }

        /// <summary>Gets a list containing the names of all the declared micro events</summary>
		/// <returns>A list containing the names of all the microEvents</returns>
        public IQiFuture<string[]> GetMicroEventListAsync()
        {
            return SourceService["getMicroEventList"].CallAsync<string[]>();
        }

        /// <summary>Gets a list containing the names of subscribers to an event.</summary>
		/// <param name="arg0_name">Name of the event or micro-event</param>
		/// <returns>List of subscriber names</returns>
        public string[] GetSubscribers(string arg0_name)
        {
            return SourceService["getSubscribers"].Call<string[]>(arg0_name);
        }

        /// <summary>Gets a list containing the names of subscribers to an event.</summary>
		/// <param name="arg0_name">Name of the event or micro-event</param>
		/// <returns>List of subscriber names</returns>
        public IQiFuture<string[]> GetSubscribersAsync(string arg0_name)
        {
            return SourceService["getSubscribers"].CallAsync<string[]>(arg0_name);
        }

        /// <summary>Gets the storage class of the stored data. This is not the underlying POD type.</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>String type: Data, Event, MicroEvent</returns>
        public string GetType(string arg0_key)
        {
            return SourceService["getType"].Call<string>(arg0_key);
        }

        /// <summary>Gets the storage class of the stored data. This is not the underlying POD type.</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>String type: Data, Event, MicroEvent</returns>
        public IQiFuture<string> GetTypeAsync(string arg0_key)
        {
            return SourceService["getType"].CallAsync<string>(arg0_key);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an int</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The int to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, int arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an int</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The int to be inserted</param>
		/// <returns></returns>
        public IQiFuture InsertDataAsync(string arg0_key, int arg1_value)
        {
            return SourceService["insertData"].CallAsync(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a float</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The float to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, float arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a float</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The float to be inserted</param>
		/// <returns></returns>
        public IQiFuture InsertDataAsync(string arg0_key, float arg1_value)
        {
            return SourceService["insertData"].CallAsync(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a string</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The string to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, string arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a string</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The string to be inserted</param>
		/// <returns></returns>
        public IQiFuture InsertDataAsync(string arg0_key, string arg1_value)
        {
            return SourceService["insertData"].CallAsync(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an ALValue</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_data">The ALValue to be inserted. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, object arg1_data)
        {
            SourceService["insertData"].Call(arg0_key, arg1_data);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an ALValue</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_data">The ALValue to be inserted. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public IQiFuture InsertDataAsync(string arg0_key, object arg1_data)
        {
            return SourceService["insertData"].CallAsync(arg0_key, arg1_data);
        }

        /// <summary>Inserts a list of key-value pairs into memory.</summary>
		/// <param name="arg0_list">An ALValue list of the form [[Key, Value],...]. Each item will be inserted.</param>
		/// <returns></returns>
        public void InsertListData(object arg0_list)
        {
            SourceService["insertListData"].Call(arg0_list);
        }

        /// <summary>Inserts a list of key-value pairs into memory.</summary>
		/// <param name="arg0_list">An ALValue list of the form [[Key, Value],...]. Each item will be inserted.</param>
		/// <returns></returns>
        public IQiFuture InsertListDataAsync(object arg0_list)
        {
            return SourceService["insertListData"].CallAsync(arg0_list);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void RaiseEvent(string arg0_name, object arg1_value)
        {
            SourceService["raiseEvent"].Call(arg0_name, arg1_value);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public IQiFuture RaiseEventAsync(string arg0_name, object arg1_value)
        {
            return SourceService["raiseEvent"].CallAsync(arg0_name, arg1_value);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void RaiseMicroEvent(string arg0_name, object arg1_value)
        {
            SourceService["raiseMicroEvent"].Call(arg0_name, arg1_value);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public IQiFuture RaiseMicroEventAsync(string arg0_name, object arg1_value)
        {
            return SourceService["raiseMicroEvent"].CallAsync(arg0_name, arg1_value);
        }

        /// <summary>Removes a key-value pair from memory</summary>
		/// <param name="arg0_key">Name of the data to be removed.</param>
		/// <returns></returns>
        public void RemoveData(string arg0_key)
        {
            SourceService["removeData"].Call(arg0_key);
        }

        /// <summary>Removes a key-value pair from memory</summary>
		/// <param name="arg0_key">Name of the data to be removed.</param>
		/// <returns></returns>
        public IQiFuture RemoveDataAsync(string arg0_key)
        {
            return SourceService["removeData"].CallAsync(arg0_key);
        }

        /// <summary>Removes a event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public void RemoveEvent(string arg0_name)
        {
            SourceService["removeEvent"].Call(arg0_name);
        }

        /// <summary>Removes a event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public IQiFuture RemoveEventAsync(string arg0_name)
        {
            return SourceService["removeEvent"].CallAsync(arg0_name);
        }

        /// <summary>Removes a micro event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public void RemoveMicroEvent(string arg0_name)
        {
            SourceService["removeMicroEvent"].Call(arg0_name);
        }

        /// <summary>Removes a micro event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public IQiFuture RemoveMicroEventAsync(string arg0_name)
        {
            return SourceService["removeMicroEvent"].CallAsync(arg0_name);
        }

        /// <summary>Subscribes to an event and automaticaly launches the module that declared itself as the generator of the event if required.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMethod)
        {
            SourceService["subscribeToEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMethod);
        }

        /// <summary>Subscribes to an event and automaticaly launches the module that declared itself as the generator of the event if required.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public IQiFuture SubscribeToEventAsync(string arg0_name, string arg1_callbackModule, string arg2_callbackMethod)
        {
            return SourceService["subscribeToEvent"].CallAsync(arg0_name, arg1_callbackModule, arg2_callbackMethod);
        }

        /// <summary>DEPRECATED Subscribes to event and automaticaly launches the module capable of generating the event if it is not already running. Please use the version without the callbackMessage parameter.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">DEPRECATED Message included in the notification.</param>
		/// <param name="arg3_callbacMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbacMethod)
        {
            SourceService["subscribeToEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbacMethod);
        }

        /// <summary>DEPRECATED Subscribes to event and automaticaly launches the module capable of generating the event if it is not already running. Please use the version without the callbackMessage parameter.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">DEPRECATED Message included in the notification.</param>
		/// <param name="arg3_callbacMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public IQiFuture SubscribeToEventAsync(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbacMethod)
        {
            return SourceService["subscribeToEvent"].CallAsync(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbacMethod);
        }

        /// <summary>Subscribes to a microEvent. Subscribed modules are notified on theircallback method whenever the data is updated, even if the new value is the same as the old value.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">Message included in the notification. This can be used to disambiguate multiple subscriptions.</param>
		/// <param name="arg3_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToMicroEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbackMethod)
        {
            SourceService["subscribeToMicroEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbackMethod);
        }

        /// <summary>Subscribes to a microEvent. Subscribed modules are notified on theircallback method whenever the data is updated, even if the new value is the same as the old value.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">Message included in the notification. This can be used to disambiguate multiple subscriptions.</param>
		/// <param name="arg3_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public IQiFuture SubscribeToMicroEventAsync(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbackMethod)
        {
            return SourceService["subscribeToMicroEvent"].CallAsync(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbackMethod);
        }

        /// <summary>Informs ALMemory that a module doesn't exist anymore.</summary>
		/// <param name="arg0_moduleName">Name of the departing module.</param>
		/// <returns></returns>
        public void UnregisterModuleReference(string arg0_moduleName)
        {
            SourceService["unregisterModuleReference"].Call(arg0_moduleName);
        }

        /// <summary>Informs ALMemory that a module doesn't exist anymore.</summary>
		/// <param name="arg0_moduleName">Name of the departing module.</param>
		/// <returns></returns>
        public IQiFuture UnregisterModuleReferenceAsync(string arg0_moduleName)
        {
            return SourceService["unregisterModuleReference"].CallAsync(arg0_moduleName);
        }

        /// <summary>ALMemory performance</summary>
		/// <returns></returns>
        public void _perf()
        {
            SourceService["_perf"].Call();
        }

        /// <summary>ALMemory performance</summary>
		/// <returns></returns>
        public IQiFuture _perfAsync()
        {
            return SourceService["_perf"].CallAsync();
        }

        /// <summary>Unsubscribes a module from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">The name of the event</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public void UnsubscribeToEvent(string arg0_name, string arg1_callbackModule)
        {
            SourceService["unsubscribeToEvent"].Call(arg0_name, arg1_callbackModule);
        }

        /// <summary>Unsubscribes a module from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">The name of the event</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public IQiFuture UnsubscribeToEventAsync(string arg0_name, string arg1_callbackModule)
        {
            return SourceService["unsubscribeToEvent"].CallAsync(arg0_name, arg1_callbackModule);
        }

        /// <summary>Unsubscribes from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">Name of the event.</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public void UnsubscribeToMicroEvent(string arg0_name, string arg1_callbackModule)
        {
            SourceService["unsubscribeToMicroEvent"].Call(arg0_name, arg1_callbackModule);
        }

        /// <summary>Unsubscribes from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">Name of the event.</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public IQiFuture UnsubscribeToMicroEventAsync(string arg0_name, string arg1_callbackModule)
        {
            return SourceService["unsubscribeToMicroEvent"].CallAsync(arg0_name, arg1_callbackModule);
        }

        /// <summary>Insert object in ALMemory. Please use ALMemoryFastAccess</summary>
		/// <param name="arg0_name">ALMemory data name</param>
		/// <param name="arg1_buffer">buffer in ALValue</param>
		/// <param name="arg2_bufferSize">buffer size</param>
		/// <returns>return an array of data's string name.</returns>
        public void _insertObject(string arg0_name, object arg1_buffer, int arg2_bufferSize)
        {
            SourceService["_insertObject"].Call(arg0_name, arg1_buffer, arg2_bufferSize);
        }

        /// <summary>Insert object in ALMemory. Please use ALMemoryFastAccess</summary>
		/// <param name="arg0_name">ALMemory data name</param>
		/// <param name="arg1_buffer">buffer in ALValue</param>
		/// <param name="arg2_bufferSize">buffer size</param>
		/// <returns>return an array of data's string name.</returns>
        public IQiFuture _insertObjectAsync(string arg0_name, object arg1_buffer, int arg2_bufferSize)
        {
            return SourceService["_insertObject"].CallAsync(arg0_name, arg1_buffer, arg2_bufferSize);
        }

        /// <summary>Allows modules to change time policy of already subscribed data.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_nTimePolicy">time of new policy in ms. Default is 0: no time policy: called at every change/insert. If timepolicy &gt; 0, we will not notifiy under timepolicy even if data change under timepolicy frequency</param>
		/// <returns></returns>
        public void _subscribeOnDataSetTimePolicy(string arg0_name, string arg1_callbackModule, int arg2_nTimePolicy)
        {
            SourceService["_subscribeOnDataSetTimePolicy"].Call(arg0_name, arg1_callbackModule, arg2_nTimePolicy);
        }

        /// <summary>Allows modules to change time policy of already subscribed data.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_nTimePolicy">time of new policy in ms. Default is 0: no time policy: called at every change/insert. If timepolicy &gt; 0, we will not notifiy under timepolicy even if data change under timepolicy frequency</param>
		/// <returns></returns>
        public IQiFuture _subscribeOnDataSetTimePolicyAsync(string arg0_name, string arg1_callbackModule, int arg2_nTimePolicy)
        {
            return SourceService["_subscribeOnDataSetTimePolicy"].CallAsync(arg0_name, arg1_callbackModule, arg2_nTimePolicy);
        }

        /// <summary>Receives notifications in the same order that the event were sent. This is slower than</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_synchronizedResponse">True to receive notifications in the same order as events are sent</param>
		/// <returns></returns>
        public void _subscribeOnDataSetSynchronizeResponse(string arg0_name, string arg1_callbackModule, bool arg2_synchronizedResponse)
        {
            SourceService["_subscribeOnDataSetSynchronizeResponse"].Call(arg0_name, arg1_callbackModule, arg2_synchronizedResponse);
        }

        /// <summary>Receives notifications in the same order that the event were sent. This is slower than</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_synchronizedResponse">True to receive notifications in the same order as events are sent</param>
		/// <returns></returns>
        public IQiFuture _subscribeOnDataSetSynchronizeResponseAsync(string arg0_name, string arg1_callbackModule, bool arg2_synchronizedResponse)
        {
            return SourceService["_subscribeOnDataSetSynchronizeResponse"].CallAsync(arg0_name, arg1_callbackModule, arg2_synchronizedResponse);
        }

        /// <summary>Describe a key</summary>
		/// <param name="arg0_name">Name of the key.</param>
		/// <param name="arg1_description">The description of the event (text format).</param>
		/// <returns></returns>
        public void SetDescription(string arg0_name, string arg1_description)
        {
            SourceService["setDescription"].Call(arg0_name, arg1_description);
        }

        /// <summary>Describe a key</summary>
		/// <param name="arg0_name">Name of the key.</param>
		/// <param name="arg1_description">The description of the event (text format).</param>
		/// <returns></returns>
        public IQiFuture SetDescriptionAsync(string arg0_name, string arg1_description)
        {
            return SourceService["setDescription"].CallAsync(arg0_name, arg1_description);
        }

        /// <summary>Descriptions of all given keys</summary>
		/// <param name="arg0_keylist">List of keys. (empty to get all descriptions)</param>
		/// <returns>an array of tuple (name, type, description) describing all keys.</returns>
        public IQiResult GetDescriptionList(IEnumerable<string> arg0_keylist)
        {
            return SourceService["getDescriptionList"].Call<IQiResult>(arg0_keylist);
        }

        /// <summary>Descriptions of all given keys</summary>
		/// <param name="arg0_keylist">List of keys. (empty to get all descriptions)</param>
		/// <returns>an array of tuple (name, type, description) describing all keys.</returns>
        public IQiFuture<IQiResult> GetDescriptionListAsync(IEnumerable<string> arg0_keylist)
        {
            return SourceService["getDescriptionList"].CallAsync<IQiResult>(arg0_keylist);
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signal">Name of the signal</param>
		/// <param name="arg2_event">Name of the event</param>
		/// <returns></returns>
        public void AddMapping(string arg0_service, string arg1_signal, string arg2_event)
        {
            SourceService["addMapping"].Call(arg0_service, arg1_signal, arg2_event);
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signal">Name of the signal</param>
		/// <param name="arg2_event">Name of the event</param>
		/// <returns></returns>
        public IQiFuture AddMappingAsync(string arg0_service, string arg1_signal, string arg2_event)
        {
            return SourceService["addMapping"].CallAsync(arg0_service, arg1_signal, arg2_event);
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signalEvent">A map of signal corresponding to event</param>
		/// <returns></returns>
        public void AddMapping(string arg0_service, IDictionary<string, string> arg1_signalEvent)
        {
            SourceService["addMapping"].Call(arg0_service, arg1_signalEvent);
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signalEvent">A map of signal corresponding to event</param>
		/// <returns></returns>
        public IQiFuture AddMappingAsync(string arg0_service, IDictionary<string, string> arg1_signalEvent)
        {
            return SourceService["addMapping"].CallAsync(arg0_service, arg1_signalEvent);
        }

    }
}