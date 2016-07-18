using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALSpeechRecognition gives access to the embedded voice recognition system. It can be dynamically modified. This class allows user to load the current words list that should be recognized. The result of the recognition engine is located in the ALMemory's key: &quot;WordRecognized&quot;. The structure of the result is an array :  [ (string) word , (float) confidence ]</summary>
    public class ALSpeechRecognition
	{
		internal ALSpeechRecognition(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALSpeechRecognition CreateService(IQiSession session)
		{
			var result = new ALSpeechRecognition(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALSpeechRecognition CreateUninitializedService(IQiSession session)
		{
			return new ALSpeechRecognition(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALSpeechRecognition");
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
				new Thread(this.InitializeService).Start();
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

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds) if relevant.</param>
		/// <param name="arg2_precision">Precision of the extractor if relevant.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name, int arg1_period, float arg2_precision)
        {
            SourceService["subscribe"].Call(arg0_name, arg1_period, arg2_precision);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds) if relevant.</param>
		/// <param name="arg2_precision">Precision of the extractor if relevant.</param>
		/// <returns></returns>
        public IQiFuture SubscribeAsync(string arg0_name, int arg1_period, float arg2_precision)
        {
            return SourceService["subscribe"].CallAsync(arg0_name, arg1_period, arg2_precision);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name)
        {
            SourceService["subscribe"].Call(arg0_name);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <returns></returns>
        public IQiFuture SubscribeAsync(string arg0_name)
        {
            return SourceService["subscribe"].CallAsync(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public void Unsubscribe(string arg0_name)
        {
            SourceService["unsubscribe"].Call(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public IQiFuture UnsubscribeAsync(string arg0_name)
        {
            return SourceService["unsubscribe"].CallAsync(arg0_name);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public void UpdatePeriod(string arg0_name, int arg1_period)
        {
            SourceService["updatePeriod"].Call(arg0_name, arg1_period);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public IQiFuture UpdatePeriodAsync(string arg0_name, int arg1_period)
        {
            return SourceService["updatePeriod"].CallAsync(arg0_name, arg1_period);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public void UpdatePrecision(string arg0_name, float arg1_precision)
        {
            SourceService["updatePrecision"].Call(arg0_name, arg1_precision);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public IQiFuture UpdatePrecisionAsync(string arg0_name, float arg1_precision)
        {
            return SourceService["updatePrecision"].CallAsync(arg0_name, arg1_precision);
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetCurrentPeriod()
        {
            return SourceService["getCurrentPeriod"].Call<int>();
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public IQiFuture<int> GetCurrentPeriodAsync()
        {
            return SourceService["getCurrentPeriod"].CallAsync<int>();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public float GetCurrentPrecision()
        {
            return SourceService["getCurrentPrecision"].Call<float>();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public IQiFuture<float> GetCurrentPrecisionAsync()
        {
            return SourceService["getCurrentPrecision"].CallAsync<float>();
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetMyPeriod(string arg0_name)
        {
            return SourceService["getMyPeriod"].Call<int>(arg0_name);
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public IQiFuture<int> GetMyPeriodAsync(string arg0_name)
        {
            return SourceService["getMyPeriod"].CallAsync<int>(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public float GetMyPrecision(string arg0_name)
        {
            return SourceService["getMyPrecision"].Call<float>(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public IQiFuture<float> GetMyPrecisionAsync(string arg0_name)
        {
            return SourceService["getMyPrecision"].CallAsync<float>(arg0_name);
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public IQiResult GetSubscribersInfo()
        {
            return SourceService["getSubscribersInfo"].Call<IQiResult>();
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public IQiFuture<IQiResult> GetSubscribersInfoAsync()
        {
            return SourceService["getSubscribersInfo"].CallAsync<IQiResult>();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public string[] GetOutputNames()
        {
            return SourceService["getOutputNames"].Call<string[]>();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetOutputNamesAsync()
        {
            return SourceService["getOutputNames"].CallAsync<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetEventList()
        {
            return SourceService["getEventList"].Call<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetEventListAsync()
        {
            return SourceService["getEventList"].CallAsync<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetMemoryKeyList()
        {
            return SourceService["getMemoryKeyList"].Call<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetMemoryKeyListAsync()
        {
            return SourceService["getMemoryKeyList"].CallAsync<string[]>();
        }

        /// <summary>Enables or disables the leds animations showing the state of the recognition engine during the recognition process.</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public void SetVisualExpression(bool arg0_setOrNot)
        {
            SourceService["setVisualExpression"].Call(arg0_setOrNot);
        }

        /// <summary>Enables or disables the leds animations showing the state of the recognition engine during the recognition process.</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public IQiFuture SetVisualExpressionAsync(bool arg0_setOrNot)
        {
            return SourceService["setVisualExpression"].CallAsync(arg0_setOrNot);
        }

        /// <summary>Sets the LED animation mode</summary>
		/// <param name="arg0_mode">animation mode: 0: deactivated, 1: eyes, 2: ears, 3: full</param>
		/// <returns></returns>
        public void SetVisualExpressionMode(int arg0_mode)
        {
            SourceService["setVisualExpressionMode"].Call(arg0_mode);
        }

        /// <summary>Sets the LED animation mode</summary>
		/// <param name="arg0_mode">animation mode: 0: deactivated, 1: eyes, 2: ears, 3: full</param>
		/// <returns></returns>
        public IQiFuture SetVisualExpressionModeAsync(int arg0_mode)
        {
            return SourceService["setVisualExpressionMode"].CallAsync(arg0_mode);
        }

        /// <summary>Enables or disables the playing of sounds indicating the state of the recognition engine. If this option is enabled, a sound is played at the beginning of the recognition process (after a call to the subscribe method), and a sound is played when the user call the unsubscribe method</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public void SetAudioExpression(bool arg0_setOrNot)
        {
            SourceService["setAudioExpression"].Call(arg0_setOrNot);
        }

        /// <summary>Enables or disables the playing of sounds indicating the state of the recognition engine. If this option is enabled, a sound is played at the beginning of the recognition process (after a call to the subscribe method), and a sound is played when the user call the unsubscribe method</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public IQiFuture SetAudioExpressionAsync(bool arg0_setOrNot)
        {
            return SourceService["setAudioExpression"].CallAsync(arg0_setOrNot);
        }

        /// <summary>To check if audio expression is enabled or disabled.</summary>
		/// <returns></returns>
        public bool GetAudioExpression()
        {
            return SourceService["getAudioExpression"].Call<bool>();
        }

        /// <summary>To check if audio expression is enabled or disabled.</summary>
		/// <returns></returns>
        public IQiFuture<bool> GetAudioExpressionAsync()
        {
            return SourceService["getAudioExpression"].CallAsync<bool>();
        }

        /// <summary>Sets the language used by the speech recognition engine. The list of the available languages can be collected through the getAvailableLanguages method. If you want to set a language as the default language (loading automatically at module launch), please refer to the web page of the robot.</summary>
		/// <param name="arg0_languageName">Name of the language in English.</param>
		/// <returns></returns>
        public void SetLanguage(string arg0_languageName)
        {
            SourceService["setLanguage"].Call(arg0_languageName);
        }

        /// <summary>Sets the language used by the speech recognition engine. The list of the available languages can be collected through the getAvailableLanguages method. If you want to set a language as the default language (loading automatically at module launch), please refer to the web page of the robot.</summary>
		/// <param name="arg0_languageName">Name of the language in English.</param>
		/// <returns></returns>
        public IQiFuture SetLanguageAsync(string arg0_languageName)
        {
            return SourceService["setLanguage"].CallAsync(arg0_languageName);
        }

        /// <summary>Set a language as the default language for the Speech Recognition engine</summary>
		/// <param name="arg0_pLanguage">The language among those available on your robot as a String</param>
		/// <returns></returns>
        public void _setDefaultLanguage(string arg0_pLanguage)
        {
            SourceService["_setDefaultLanguage"].Call(arg0_pLanguage);
        }

        /// <summary>Set a language as the default language for the Speech Recognition engine</summary>
		/// <param name="arg0_pLanguage">The language among those available on your robot as a String</param>
		/// <returns></returns>
        public IQiFuture _setDefaultLanguageAsync(string arg0_pLanguage)
        {
            return SourceService["_setDefaultLanguage"].CallAsync(arg0_pLanguage);
        }

        /// <summary>Returns the current language used by the speech recognition system.</summary>
		/// <returns>Current language used by the speech recognition engine.</returns>
        public string GetLanguage()
        {
            return SourceService["getLanguage"].Call<string>();
        }

        /// <summary>Returns the current language used by the speech recognition system.</summary>
		/// <returns>Current language used by the speech recognition engine.</returns>
        public IQiFuture<string> GetLanguageAsync()
        {
            return SourceService["getLanguage"].CallAsync<string>();
        }

        /// <summary>Returns the list of the languages installed on the system.</summary>
		/// <returns>Array of strings that contains the list of the installed languages.</returns>
        public string[] GetAvailableLanguages()
        {
            return SourceService["getAvailableLanguages"].Call<string[]>();
        }

        /// <summary>Returns the list of the languages installed on the system.</summary>
		/// <returns>Array of strings that contains the list of the installed languages.</returns>
        public IQiFuture<string[]> GetAvailableLanguagesAsync()
        {
            return SourceService["getAvailableLanguages"].CallAsync<string[]>();
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, float arg1_paramValue)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public IQiFuture SetParameterAsync(string arg0_paramName, float arg1_paramValue)
        {
            return SourceService["setParameter"].CallAsync(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, bool arg1_paramValue)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public IQiFuture SetParameterAsync(string arg0_paramName, bool arg1_paramValue)
        {
            return SourceService["setParameter"].CallAsync(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Gets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be retrieved</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <returns>Value of the parameter.</returns>
        public float GetParameter(string arg0_paramName)
        {
            return SourceService["getParameter"].Call<float>(arg0_paramName);
        }

        /// <summary>Gets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be retrieved</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <returns>Value of the parameter.</returns>
        public IQiFuture<float> GetParameterAsync(string arg0_paramName)
        {
            return SourceService["getParameter"].CallAsync<float>(arg0_paramName);
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <returns></returns>
        public void SetWordListAsVocabulary(IEnumerable<string> arg0_vocabulary)
        {
            SourceService["setWordListAsVocabulary"].Call(arg0_vocabulary);
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <returns></returns>
        public IQiFuture SetWordListAsVocabularyAsync(IEnumerable<string> arg0_vocabulary)
        {
            return SourceService["setWordListAsVocabulary"].CallAsync(arg0_vocabulary);
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <param name="arg1_enabledWordSpotting">If disabled, the engine expects to hear one of the specified words, nothing more, nothing less. If enabled, the specified words can be pronounced in the middle of a whole speech stream, the engine will try to spot them.</param>
		/// <returns></returns>
        public void SetVocabulary(IEnumerable<string> arg0_vocabulary, bool arg1_enabledWordSpotting)
        {
            SourceService["setVocabulary"].Call(arg0_vocabulary, arg1_enabledWordSpotting);
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <param name="arg1_enabledWordSpotting">If disabled, the engine expects to hear one of the specified words, nothing more, nothing less. If enabled, the specified words can be pronounced in the middle of a whole speech stream, the engine will try to spot them.</param>
		/// <returns></returns>
        public IQiFuture SetVocabularyAsync(IEnumerable<string> arg0_vocabulary, bool arg1_enabledWordSpotting)
        {
            return SourceService["setVocabulary"].CallAsync(arg0_vocabulary, arg1_enabledWordSpotting);
        }

        /// <summary>Stops and restarts the speech recognition engine according to the input parameter This can be used to add contexts, activate or deactivate rules of a contex, add a words to a slot.</summary>
		/// <param name="arg0_pause">Boolean to enable or disable pause of the speech recognition engine.</param>
		/// <returns></returns>
        public void Pause(bool arg0_pause)
        {
            SourceService["pause"].Call(arg0_pause);
        }

        /// <summary>Stops and restarts the speech recognition engine according to the input parameter This can be used to add contexts, activate or deactivate rules of a contex, add a words to a slot.</summary>
		/// <param name="arg0_pause">Boolean to enable or disable pause of the speech recognition engine.</param>
		/// <returns></returns>
        public IQiFuture PauseAsync(bool arg0_pause)
        {
            return SourceService["pause"].CallAsync(arg0_pause);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void Compile(string arg0, string arg1, string arg2)
        {
            SourceService["compile"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture CompileAsync(string arg0, string arg1, string arg2)
        {
            return SourceService["compile"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>Add a context from a LCF file.</summary>
		/// <param name="arg0_pathToLCFFile">Path to a LCF file. This LCF file contains the set of rules that should be recognized by the speech recognition engine.</param>
		/// <param name="arg1_contextName">Name of the context of your choice.</param>
		/// <returns></returns>
        public void AddContext(string arg0_pathToLCFFile, string arg1_contextName)
        {
            SourceService["addContext"].Call(arg0_pathToLCFFile, arg1_contextName);
        }

        /// <summary>Add a context from a LCF file.</summary>
		/// <param name="arg0_pathToLCFFile">Path to a LCF file. This LCF file contains the set of rules that should be recognized by the speech recognition engine.</param>
		/// <param name="arg1_contextName">Name of the context of your choice.</param>
		/// <returns></returns>
        public IQiFuture AddContextAsync(string arg0_pathToLCFFile, string arg1_contextName)
        {
            return SourceService["addContext"].CallAsync(arg0_pathToLCFFile, arg1_contextName);
        }

        /// <summary>Remove one context from the speech recognition engine.</summary>
		/// <param name="arg0_contextName">Name of the context to remove from the speech recognition engine.</param>
		/// <returns></returns>
        public void RemoveContext(string arg0_contextName)
        {
            SourceService["removeContext"].Call(arg0_contextName);
        }

        /// <summary>Remove one context from the speech recognition engine.</summary>
		/// <param name="arg0_contextName">Name of the context to remove from the speech recognition engine.</param>
		/// <returns></returns>
        public IQiFuture RemoveContextAsync(string arg0_contextName)
        {
            return SourceService["removeContext"].CallAsync(arg0_contextName);
        }

        /// <summary>Remove all contexts from the speech recognition engine.</summary>
		/// <returns></returns>
        public void RemoveAllContext()
        {
            SourceService["removeAllContext"].Call();
        }

        /// <summary>Remove all contexts from the speech recognition engine.</summary>
		/// <returns></returns>
        public IQiFuture RemoveAllContextAsync()
        {
            return SourceService["removeAllContext"].CallAsync();
        }

        /// <summary>Disable current contexts of the speech recognition engine and save them in a  stack.</summary>
		/// <returns></returns>
        public void PushContexts()
        {
            SourceService["pushContexts"].Call();
        }

        /// <summary>Disable current contexts of the speech recognition engine and save them in a  stack.</summary>
		/// <returns></returns>
        public IQiFuture PushContextsAsync()
        {
            return SourceService["pushContexts"].CallAsync();
        }

        /// <summary>Disable current contexts and restore saved contexts of the speech recognition engine.</summary>
		/// <returns></returns>
        public void PopContexts()
        {
            SourceService["popContexts"].Call();
        }

        /// <summary>Disable current contexts and restore saved contexts of the speech recognition engine.</summary>
		/// <returns></returns>
        public IQiFuture PopContextsAsync()
        {
            return SourceService["popContexts"].CallAsync();
        }

        /// <summary>Save current context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which to save</param>
		/// <returns></returns>
        public bool SaveContextSet(string arg0_saveName)
        {
            return SourceService["saveContextSet"].Call<bool>(arg0_saveName);
        }

        /// <summary>Save current context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which to save</param>
		/// <returns></returns>
        public IQiFuture<bool> SaveContextSetAsync(string arg0_saveName)
        {
            return SourceService["saveContextSet"].CallAsync<bool>(arg0_saveName);
        }

        /// <summary>Load a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public void LoadContextSet(string arg0_saveName)
        {
            SourceService["loadContextSet"].Call(arg0_saveName);
        }

        /// <summary>Load a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public IQiFuture LoadContextSetAsync(string arg0_saveName)
        {
            return SourceService["loadContextSet"].CallAsync(arg0_saveName);
        }

        /// <summary>Erase a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public void EraseContextSet(string arg0_saveName)
        {
            SourceService["eraseContextSet"].Call(arg0_saveName);
        }

        /// <summary>Erase a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public IQiFuture EraseContextSetAsync(string arg0_saveName)
        {
            return SourceService["eraseContextSet"].CallAsync(arg0_saveName);
        }

        /// <summary>Activate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to activate.</param>
		/// <returns></returns>
        public void ActivateRule(string arg0_contextName, string arg1_ruleName)
        {
            SourceService["activateRule"].Call(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Activate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to activate.</param>
		/// <returns></returns>
        public IQiFuture ActivateRuleAsync(string arg0_contextName, string arg1_ruleName)
        {
            return SourceService["activateRule"].CallAsync(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Deactivate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to deactivate.</param>
		/// <returns></returns>
        public void DeactivateRule(string arg0_contextName, string arg1_ruleName)
        {
            SourceService["deactivateRule"].Call(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Deactivate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to deactivate.</param>
		/// <returns></returns>
        public IQiFuture DeactivateRuleAsync(string arg0_contextName, string arg1_ruleName)
        {
            return SourceService["deactivateRule"].CallAsync(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Activate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public void ActivateAllRules(string arg0_contextName)
        {
            SourceService["activateAllRules"].Call(arg0_contextName);
        }

        /// <summary>Activate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public IQiFuture ActivateAllRulesAsync(string arg0_contextName)
        {
            return SourceService["activateAllRules"].CallAsync(arg0_contextName);
        }

        /// <summary>Deactivate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public void DeactivateAllRules(string arg0_contextName)
        {
            SourceService["deactivateAllRules"].Call(arg0_contextName);
        }

        /// <summary>Deactivate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public IQiFuture DeactivateAllRulesAsync(string arg0_contextName)
        {
            return SourceService["deactivateAllRules"].CallAsync(arg0_contextName);
        }

        /// <summary>Set the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to change</param>
		/// <param name="arg2_value">New parameter value</param>
		/// <returns></returns>
        public void SetContextParam(string arg0_contextName, string arg1_paramName, float arg2_value)
        {
            SourceService["setContextParam"].Call(arg0_contextName, arg1_paramName, arg2_value);
        }

        /// <summary>Set the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to change</param>
		/// <param name="arg2_value">New parameter value</param>
		/// <returns></returns>
        public IQiFuture SetContextParamAsync(string arg0_contextName, string arg1_paramName, float arg2_value)
        {
            return SourceService["setContextParam"].CallAsync(arg0_contextName, arg1_paramName, arg2_value);
        }

        /// <summary>Get the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to get</param>
		/// <returns>Value of the fetched parameter</returns>
        public float GetContextParam(string arg0_contextName, string arg1_paramName)
        {
            return SourceService["getContextParam"].Call<float>(arg0_contextName, arg1_paramName);
        }

        /// <summary>Get the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to get</param>
		/// <returns>Value of the fetched parameter</returns>
        public IQiFuture<float> GetContextParamAsync(string arg0_contextName, string arg1_paramName)
        {
            return SourceService["getContextParam"].CallAsync<float>(arg0_contextName, arg1_paramName);
        }

        /// <summary>Add a list of words in a slot. A slot is a part of a context which can be modified. You can add a list of words that should be recognized by the speech recognition engine</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <param name="arg2_wordList">List of words to insert in the slot.</param>
		/// <returns></returns>
        public void AddWordListToSlot(string arg0_contextName, string arg1_slotName, IEnumerable<string> arg2_wordList)
        {
            SourceService["addWordListToSlot"].Call(arg0_contextName, arg1_slotName, arg2_wordList);
        }

        /// <summary>Add a list of words in a slot. A slot is a part of a context which can be modified. You can add a list of words that should be recognized by the speech recognition engine</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <param name="arg2_wordList">List of words to insert in the slot.</param>
		/// <returns></returns>
        public IQiFuture AddWordListToSlotAsync(string arg0_contextName, string arg1_slotName, IEnumerable<string> arg2_wordList)
        {
            return SourceService["addWordListToSlot"].CallAsync(arg0_contextName, arg1_slotName, arg2_wordList);
        }

        /// <summary>Remove all words from a slot.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <returns></returns>
        public void RemoveWordListFromSlot(string arg0_contextName, string arg1_slotName)
        {
            SourceService["removeWordListFromSlot"].Call(arg0_contextName, arg1_slotName);
        }

        /// <summary>Remove all words from a slot.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <returns></returns>
        public IQiFuture RemoveWordListFromSlotAsync(string arg0_contextName, string arg1_slotName)
        {
            return SourceService["removeWordListFromSlot"].CallAsync(arg0_contextName, arg1_slotName);
        }

        /// <summary>Get all rules contained for a specific context.</summary>
		/// <param name="arg0_contextName">Name of the context to analyze.</param>
		/// <param name="arg1_typeName">Type of the required rules.</param>
		/// <returns></returns>
        public string[] GetRules(string arg0_contextName, string arg1_typeName)
        {
            return SourceService["getRules"].Call<string[]>(arg0_contextName, arg1_typeName);
        }

        /// <summary>Get all rules contained for a specific context.</summary>
		/// <param name="arg0_contextName">Name of the context to analyze.</param>
		/// <param name="arg1_typeName">Type of the required rules.</param>
		/// <returns></returns>
        public IQiFuture<string[]> GetRulesAsync(string arg0_contextName, string arg1_typeName)
        {
            return SourceService["getRules"].CallAsync<string[]>(arg0_contextName, arg1_typeName);
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns>Boolean indicating whether free speech to text is available for the current language</returns>
        public bool _isFreeSpeechToTextAvailable()
        {
            return SourceService["_isFreeSpeechToTextAvailable"].Call<bool>();
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns>Boolean indicating whether free speech to text is available for the current language</returns>
        public IQiFuture<bool> _isFreeSpeechToTextAvailableAsync()
        {
            return SourceService["_isFreeSpeechToTextAvailable"].CallAsync<bool>();
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns></returns>
        public void _enableFreeSpeechToText()
        {
            SourceService["_enableFreeSpeechToText"].Call();
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns></returns>
        public IQiFuture _enableFreeSpeechToTextAsync()
        {
            return SourceService["_enableFreeSpeechToText"].CallAsync();
        }

        /// <summary>Disable free speech to text.</summary>
		/// <returns></returns>
        public void _disableFreeSpeechToText()
        {
            SourceService["_disableFreeSpeechToText"].Call();
        }

        /// <summary>Disable free speech to text.</summary>
		/// <returns></returns>
        public IQiFuture _disableFreeSpeechToTextAsync()
        {
            return SourceService["_disableFreeSpeechToText"].CallAsync();
        }

        /// <summary>Get a remote consumption speed change recommendation.</summary>
		/// <returns>Integer indicating whether to increase, decrease or keep the remote consumption speed</returns>
        public int _remoteConsumptionOk()
        {
            return SourceService["_remoteConsumptionOk"].Call<int>();
        }

        /// <summary>Get a remote consumption speed change recommendation.</summary>
		/// <returns>Integer indicating whether to increase, decrease or keep the remote consumption speed</returns>
        public IQiFuture<int> _remoteConsumptionOkAsync()
        {
            return SourceService["_remoteConsumptionOk"].CallAsync<int>();
        }

        /// <summary>Loads the vocabulary to recognized contained in a .lxd file. This method is not available with the ASR engine language set to Chinese. For more informations see the red documentation</summary>
		/// <param name="arg0_vocabularyFile">Name of the lxd file containing the vocabulary</param>
		/// <returns></returns>
        public void LoadVocabulary(string arg0_vocabularyFile)
        {
            SourceService["loadVocabulary"].Call(arg0_vocabularyFile);
        }

        /// <summary>Loads the vocabulary to recognized contained in a .lxd file. This method is not available with the ASR engine language set to Chinese. For more informations see the red documentation</summary>
		/// <param name="arg0_vocabularyFile">Name of the lxd file containing the vocabulary</param>
		/// <returns></returns>
        public IQiFuture LoadVocabularyAsync(string arg0_vocabularyFile)
        {
            return SourceService["loadVocabulary"].CallAsync(arg0_vocabularyFile);
        }

        /// <summary>reload the engine if new application installed is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _naoStoreApplicationInstalled(string arg0, object arg1, string arg2)
        {
            SourceService["_naoStoreApplicationInstalled"].Call(arg0, arg1, arg2);
        }

        /// <summary>reload the engine if new application installed is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _naoStoreApplicationInstalledAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_naoStoreApplicationInstalled"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>reload the engine if application uninstalled is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _naoStoreApplicationUninstalled(string arg0, object arg1, string arg2)
        {
            SourceService["_naoStoreApplicationUninstalled"].Call(arg0, arg1, arg2);
        }

        /// <summary>reload the engine if application uninstalled is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _naoStoreApplicationUninstalledAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_naoStoreApplicationUninstalled"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _systemSoundSetChanged()
        {
            SourceService["_systemSoundSetChanged"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture _systemSoundSetChangedAsync()
        {
            return SourceService["_systemSoundSetChanged"].CallAsync();
        }

        /// <summary>Set the ASR_Recognizer thread to real time priority. Be careful this could change the scheduling of the robot.</summary>
		/// <param name="arg0_isRealTime">True or False to enable or disable real time priority.</param>
		/// <returns></returns>
        public void _enableRealTimeThread(bool arg0_isRealTime)
        {
            SourceService["_enableRealTimeThread"].Call(arg0_isRealTime);
        }

        /// <summary>Set the ASR_Recognizer thread to real time priority. Be careful this could change the scheduling of the robot.</summary>
		/// <param name="arg0_isRealTime">True or False to enable or disable real time priority.</param>
		/// <returns></returns>
        public IQiFuture _enableRealTimeThreadAsync(bool arg0_isRealTime)
        {
            return SourceService["_enableRealTimeThread"].CallAsync(arg0_isRealTime);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _silentNextBipOn()
        {
            SourceService["_silentNextBipOn"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture _silentNextBipOnAsync()
        {
            return SourceService["_silentNextBipOn"].CallAsync();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _silentNextBipOff()
        {
            SourceService["_silentNextBipOff"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture _silentNextBipOffAsync()
        {
            return SourceService["_silentNextBipOff"].CallAsync();
        }

        /// <summary>Enable audio dumps.</summary>
		/// <param name="arg0_path">Path to write the dump files to. Pass an empty string to deactivate audio logging</param>
		/// <returns></returns>
        public void _enableAudioLogging(string arg0_path)
        {
            SourceService["_enableAudioLogging"].Call(arg0_path);
        }

        /// <summary>Enable audio dumps.</summary>
		/// <param name="arg0_path">Path to write the dump files to. Pass an empty string to deactivate audio logging</param>
		/// <returns></returns>
        public IQiFuture _enableAudioLoggingAsync(string arg0_path)
        {
            return SourceService["_enableAudioLogging"].CallAsync(arg0_path);
        }

        /// <summary>Enable beamformer.</summary>
		/// <returns></returns>
        public void _enableBeamformer()
        {
            SourceService["_enableBeamformer"].Call();
        }

        /// <summary>Enable beamformer.</summary>
		/// <returns></returns>
        public IQiFuture _enableBeamformerAsync()
        {
            return SourceService["_enableBeamformer"].CallAsync();
        }

        /// <summary>Disable beamformer.</summary>
		/// <returns></returns>
        public void _disableBeamformer()
        {
            SourceService["_disableBeamformer"].Call();
        }

        /// <summary>Disable beamformer.</summary>
		/// <returns></returns>
        public IQiFuture _disableBeamformerAsync()
        {
            return SourceService["_disableBeamformer"].CallAsync();
        }

        /// <summary>Get beamformer status.</summary>
		/// <returns>Whether the beamformer is enabled or not</returns>
        public bool _beamformerEnabled()
        {
            return SourceService["_beamformerEnabled"].Call<bool>();
        }

        /// <summary>Get beamformer status.</summary>
		/// <returns>Whether the beamformer is enabled or not</returns>
        public IQiFuture<bool> _beamformerEnabledAsync()
        {
            return SourceService["_beamformerEnabled"].CallAsync<bool>();
        }

        /// <summary>get vocon version</summary>
		/// <returns>Version</returns>
        public string _getVersion()
        {
            return SourceService["_getVersion"].Call<string>();
        }

        /// <summary>get vocon version</summary>
		/// <returns>Version</returns>
        public IQiFuture<string> _getVersionAsync()
        {
            return SourceService["_getVersion"].CallAsync<string>();
        }

    }
}