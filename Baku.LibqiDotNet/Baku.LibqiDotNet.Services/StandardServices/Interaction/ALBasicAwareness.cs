using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALBasicAwareness
	{
		internal ALBasicAwareness(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALBasicAwareness CreateService(IQiSession session)
		{
			var result = new ALBasicAwareness(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALBasicAwareness CreateUninitializedService(IQiSession session)
		{
			return new ALBasicAwareness(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALBasicAwareness");
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

        /// <summary>Population Updated (event: PeoplePerception/PopulationUpdated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_populationUpdated">Boolean value for people detection event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onPeopleDetected(string arg0_name, object arg1_populationUpdated, string arg2_message)
        {
            SourceService["_onPeopleDetected"].Call(arg0_name, arg1_populationUpdated, arg2_message);
        }

        /// <summary>Population Updated (event: PeoplePerception/PopulationUpdated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_populationUpdated">Boolean value for people detection event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onPeopleDetectedAsync(string arg0_name, object arg1_populationUpdated, string arg2_message)
        {
            return SourceService["_onPeopleDetected"].CallAsync(arg0_name, arg1_populationUpdated, arg2_message);
        }

        /// <summary>Movement Detected (event: MovementDetection3D/MovementDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onMovementDetected(string arg0_name, object arg1_movementDetected, string arg2_message)
        {
            SourceService["_onMovementDetected"].Call(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Movement Detected (event: MovementDetection3D/MovementDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onMovementDetectedAsync(string arg0_name, object arg1_movementDetected, string arg2_message)
        {
            return SourceService["_onMovementDetected"].CallAsync(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Navigation Motion Detected (event: Navigation/MotionDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onNavigationMotionDetected(string arg0_name, object arg1_movementDetected, string arg2_message)
        {
            SourceService["_onNavigationMotionDetected"].Call(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Navigation Motion Detected (event: Navigation/MotionDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onNavigationMotionDetectedAsync(string arg0_name, object arg1_movementDetected, string arg2_message)
        {
            return SourceService["_onNavigationMotionDetected"].CallAsync(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Close Movement Detected (event: WavingDetection/Waving)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_closeMovementDetected">Boolean value for close movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onCloseMovementDetected(string arg0_name, object arg1_closeMovementDetected, string arg2_message)
        {
            SourceService["_onCloseMovementDetected"].Call(arg0_name, arg1_closeMovementDetected, arg2_message);
        }

        /// <summary>Close Movement Detected (event: WavingDetection/Waving)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_closeMovementDetected">Boolean value for close movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onCloseMovementDetectedAsync(string arg0_name, object arg1_closeMovementDetected, string arg2_message)
        {
            return SourceService["_onCloseMovementDetected"].CallAsync(arg0_name, arg1_closeMovementDetected, arg2_message);
        }

        /// <summary>Sound Detected (event: SoundLocated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_SoundLocated">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onSoundDetected(string arg0_name, object arg1_SoundLocated, string arg2_message)
        {
            SourceService["_onSoundDetected"].Call(arg0_name, arg1_SoundLocated, arg2_message);
        }

        /// <summary>Sound Detected (event: SoundLocated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_SoundLocated">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onSoundDetectedAsync(string arg0_name, object arg1_SoundLocated, string arg2_message)
        {
            return SourceService["_onSoundDetected"].CallAsync(arg0_name, arg1_SoundLocated, arg2_message);
        }

        /// <summary>Touch Detected (event: TouchDetection3D/TouchDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_touchDetected">Boolean value for touch event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onTouchDetected(string arg0_name, object arg1_touchDetected, string arg2_message)
        {
            SourceService["_onTouchDetected"].Call(arg0_name, arg1_touchDetected, arg2_message);
        }

        /// <summary>Touch Detected (event: TouchDetection3D/TouchDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_touchDetected">Boolean value for touch event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onTouchDetectedAsync(string arg0_name, object arg1_touchDetected, string arg2_message)
        {
            return SourceService["_onTouchDetected"].CallAsync(arg0_name, arg1_touchDetected, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FastPersonTracking)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onFastPersonTracking(string arg0_name, object arg1_tackerValue, string arg2_message)
        {
            SourceService["_onFastPersonTracking"].Call(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FastPersonTracking)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onFastPersonTrackingAsync(string arg0_name, object arg1_tackerValue, string arg2_message)
        {
            return SourceService["_onFastPersonTracking"].CallAsync(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>No person found by fast tracking callback (event:ALFastPersonTracking/TrackedPersonNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onNoFastPersonFound(string arg0_name, object arg1_val, string arg2_message)
        {
            SourceService["_onNoFastPersonFound"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>No person found by fast tracking callback (event:ALFastPersonTracking/TrackedPersonNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onNoFastPersonFoundAsync(string arg0_name, object arg1_val, string arg2_message)
        {
            return SourceService["_onNoFastPersonFound"].CallAsync(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FindPersonHead)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadTracking(string arg0_name, object arg1_tackerValue, string arg2_message)
        {
            SourceService["_onHeadTracking"].Call(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FindPersonHead)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onHeadTrackingAsync(string arg0_name, object arg1_tackerValue, string arg2_message)
        {
            return SourceService["_onHeadTracking"].CallAsync(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>HeadNotFound event callback (event:ALFindPersonHead/HeadNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadNotFound(string arg0_name, object arg1_val, string arg2_message)
        {
            SourceService["_onHeadNotFound"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>HeadNotFound event callback (event:ALFindPersonHead/HeadNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onHeadNotFoundAsync(string arg0_name, object arg1_val, string arg2_message)
        {
            return SourceService["_onHeadNotFound"].CallAsync(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>HeadReached event callback (event:ALFindPersonHead/HeadReached)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadReached(string arg0_name, object arg1_val, string arg2_message)
        {
            SourceService["_onHeadReached"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>HeadReached event callback (event:ALFindPersonHead/HeadReached)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onHeadReachedAsync(string arg0_name, object arg1_val, string arg2_message)
        {
            return SourceService["_onHeadReached"].CallAsync(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>tracking interruption</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadTrackingStopped(string arg0_name, object arg1_val, string arg2_message)
        {
            SourceService["_onHeadTrackingStopped"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>tracking interruption</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public IQiFuture _onHeadTrackingStoppedAsync(string arg0_name, object arg1_val, string arg2_message)
        {
            return SourceService["_onHeadTrackingStopped"].CallAsync(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>Enable/Disable BasicAwareness.</summary>
		/// <param name="arg0_enabled">True to enable BasicAwareness, False to disable BasicAwareness.</param>
		/// <returns></returns>
        public void SetEnabled(bool arg0_enabled)
        {
            SourceService["setEnabled"].Call(arg0_enabled);
        }

        /// <summary>Enable/Disable BasicAwareness.</summary>
		/// <param name="arg0_enabled">True to enable BasicAwareness, False to disable BasicAwareness.</param>
		/// <returns></returns>
        public IQiFuture SetEnabledAsync(bool arg0_enabled)
        {
            return SourceService["setEnabled"].CallAsync(arg0_enabled);
        }

        /// <summary>Return whether BasicAwareness is enabled or not.</summary>
		/// <returns>Boolean value, true if enabled else false</returns>
        public bool IsEnabled()
        {
            return SourceService["isEnabled"].Call<bool>();
        }

        /// <summary>Return whether BasicAwareness is enabled or not.</summary>
		/// <returns>Boolean value, true if enabled else false</returns>
        public IQiFuture<bool> IsEnabledAsync()
        {
            return SourceService["isEnabled"].CallAsync<bool>();
        }

        /// <summary>Return whether BasicAwareness is running.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public bool IsRunning()
        {
            return SourceService["isRunning"].Call<bool>();
        }

        /// <summary>Return whether BasicAwareness is running.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public IQiFuture<bool> IsRunningAsync()
        {
            return SourceService["isRunning"].CallAsync<bool>();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Start Basic Awareness.</summary>
		/// <returns></returns>
        public void StartAwareness()
        {
            SourceService["startAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Start Basic Awareness.</summary>
		/// <returns></returns>
        public IQiFuture StartAwarenessAsync()
        {
            return SourceService["startAwareness"].CallAsync();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Stop Basic Awareness.</summary>
		/// <returns></returns>
        public void StopAwareness()
        {
            SourceService["stopAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Stop Basic Awareness.</summary>
		/// <returns></returns>
        public IQiFuture StopAwarenessAsync()
        {
            return SourceService["stopAwareness"].CallAsync();
        }

        /// <summary>DEPRECATED since 2.4: use isEnabled instead.Get the status (started or not) of the module.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public bool IsAwarenessRunning()
        {
            return SourceService["isAwarenessRunning"].Call<bool>();
        }

        /// <summary>DEPRECATED since 2.4: use isEnabled instead.Get the status (started or not) of the module.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public IQiFuture<bool> IsAwarenessRunningAsync()
        {
            return SourceService["isAwarenessRunning"].CallAsync<bool>();
        }

        /// <summary>Pause BasicAwareness.</summary>
		/// <returns></returns>
        public void PauseAwareness()
        {
            SourceService["pauseAwareness"].Call();
        }

        /// <summary>Pause BasicAwareness.</summary>
		/// <returns></returns>
        public IQiFuture PauseAwarenessAsync()
        {
            return SourceService["pauseAwareness"].CallAsync();
        }

        /// <summary>Resume BasicAwareness.</summary>
		/// <returns></returns>
        public void ResumeAwareness()
        {
            SourceService["resumeAwareness"].Call();
        }

        /// <summary>Resume BasicAwareness.</summary>
		/// <returns></returns>
        public IQiFuture ResumeAwarenessAsync()
        {
            return SourceService["resumeAwareness"].CallAsync();
        }

        /// <summary>Get the pause status of the module.</summary>
		/// <returns></returns>
        public bool IsAwarenessPaused()
        {
            return SourceService["isAwarenessPaused"].Call<bool>();
        }

        /// <summary>Get the pause status of the module.</summary>
		/// <returns></returns>
        public IQiFuture<bool> IsAwarenessPausedAsync()
        {
            return SourceService["isAwarenessPaused"].CallAsync<bool>();
        }

        /// <summary>Enable/Disable Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to enable/disable</param>
		/// <param name="arg1_isStimulusDetectionEnabled">Boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetStimulusDetectionEnabled(string arg0_stimulusName, bool arg1_isStimulusDetectionEnabled)
        {
            SourceService["setStimulusDetectionEnabled"].Call(arg0_stimulusName, arg1_isStimulusDetectionEnabled);
        }

        /// <summary>Enable/Disable Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to enable/disable</param>
		/// <param name="arg1_isStimulusDetectionEnabled">Boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public IQiFuture SetStimulusDetectionEnabledAsync(string arg0_stimulusName, bool arg1_isStimulusDetectionEnabled)
        {
            return SourceService["setStimulusDetectionEnabled"].CallAsync(arg0_stimulusName, arg1_isStimulusDetectionEnabled);
        }

        /// <summary>Get status enabled/disabled for Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to check</param>
		/// <returns>Boolean value for status enabled/disabled</returns>
        public bool IsStimulusDetectionEnabled(string arg0_stimulusName)
        {
            return SourceService["isStimulusDetectionEnabled"].Call<bool>(arg0_stimulusName);
        }

        /// <summary>Get status enabled/disabled for Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to check</param>
		/// <returns>Boolean value for status enabled/disabled</returns>
        public IQiFuture<bool> IsStimulusDetectionEnabledAsync(string arg0_stimulusName)
        {
            return SourceService["isStimulusDetectionEnabled"].CallAsync<bool>(arg0_stimulusName);
        }

        /// <summary>Set the specified parameter </summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <param name="arg1_newVal">&quot;LookStimulusSpeed&quot; : Float in range [0.01;1] &quot;LookBackSpeed&quot; : Float in range [0.01;1] &quot;NobodyFoundTimeOut&quot; : Float &gt; 0 &quot;MinTimeTracking&quot; : Float in range [0;20] &quot;TimeSleepBeforeResumeMS&quot; : Int &gt; 0 &quot;TimeOutResetHead&quot; : Float in range [0;30] &quot;AmplitudeYawTracking&quot; : Float in range [10;120] &quot;FramerateTracking&quot; : Int in range [1;33] &quot;PeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;SlowPeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;HeadThreshold&quot; : Float in range [0;180] &quot;BodyRotationThreshold&quot; : Float in range [-180;180] &quot;BodyRotationThresholdNao&quot; : Float in range [-180;180] &quot;MoveDistanceX&quot; : Float in range [-5;5] &quot;MoveDistanceY&quot; : Float in range [-5;5] &quot;MoveAngleTheta&quot; : Float in range [-180;180] &quot;MoveThresholdX&quot; : Float in range [0;5] &quot;MoveThresholdY&quot; : Float in range [0;5] &quot;MoveThresholdTheta&quot; : Float in range [-180;180] &quot;MaxDistanceFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxDistanceNotFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxHumanSearchTime&quot; : Float in range [0.1;10] &quot;DeltaPitchComfortZone&quot; : Float in range [0;90] &quot;CenterPitchComfortZone&quot; : Float in range [-90;90] &quot;SoundHeight&quot; : Float in range [0;2] &quot;MoveSpeed&quot; : Float in range [0.1;0.55] &quot;MC_Interactive_MinTime&quot; : Int in range [0;100] &quot;MC_Interactive_MaxOffsetTime&quot; : Int in range [0;100] &quot;MC_Interactive_DistanceXY&quot; : Float in range [0;1] &quot;MC_Interactive_MinTheta&quot; : Float in range [-40;0] &quot;MC_Interactive_MaxTheta&quot; : Float in range [0;40] &quot;MC_Interactive_DistanceHumanRobot&quot; : Float in range [0.1;2] &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Float in range [0.1;3] </param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, object arg1_newVal)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_newVal);
        }

        /// <summary>Set the specified parameter </summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <param name="arg1_newVal">&quot;LookStimulusSpeed&quot; : Float in range [0.01;1] &quot;LookBackSpeed&quot; : Float in range [0.01;1] &quot;NobodyFoundTimeOut&quot; : Float &gt; 0 &quot;MinTimeTracking&quot; : Float in range [0;20] &quot;TimeSleepBeforeResumeMS&quot; : Int &gt; 0 &quot;TimeOutResetHead&quot; : Float in range [0;30] &quot;AmplitudeYawTracking&quot; : Float in range [10;120] &quot;FramerateTracking&quot; : Int in range [1;33] &quot;PeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;SlowPeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;HeadThreshold&quot; : Float in range [0;180] &quot;BodyRotationThreshold&quot; : Float in range [-180;180] &quot;BodyRotationThresholdNao&quot; : Float in range [-180;180] &quot;MoveDistanceX&quot; : Float in range [-5;5] &quot;MoveDistanceY&quot; : Float in range [-5;5] &quot;MoveAngleTheta&quot; : Float in range [-180;180] &quot;MoveThresholdX&quot; : Float in range [0;5] &quot;MoveThresholdY&quot; : Float in range [0;5] &quot;MoveThresholdTheta&quot; : Float in range [-180;180] &quot;MaxDistanceFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxDistanceNotFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxHumanSearchTime&quot; : Float in range [0.1;10] &quot;DeltaPitchComfortZone&quot; : Float in range [0;90] &quot;CenterPitchComfortZone&quot; : Float in range [-90;90] &quot;SoundHeight&quot; : Float in range [0;2] &quot;MoveSpeed&quot; : Float in range [0.1;0.55] &quot;MC_Interactive_MinTime&quot; : Int in range [0;100] &quot;MC_Interactive_MaxOffsetTime&quot; : Int in range [0;100] &quot;MC_Interactive_DistanceXY&quot; : Float in range [0;1] &quot;MC_Interactive_MinTheta&quot; : Float in range [-40;0] &quot;MC_Interactive_MaxTheta&quot; : Float in range [0;40] &quot;MC_Interactive_DistanceHumanRobot&quot; : Float in range [0.1;2] &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Float in range [0.1;3] </param>
		/// <returns></returns>
        public IQiFuture SetParameterAsync(string arg0_paramName, object arg1_newVal)
        {
            return SourceService["setParameter"].CallAsync(arg0_paramName, arg1_newVal);
        }

        /// <summary>Reset all parameters, including enabled/disabled stimulus.</summary>
		/// <returns></returns>
        public void ResetAllParameters()
        {
            SourceService["resetAllParameters"].Call();
        }

        /// <summary>Reset all parameters, including enabled/disabled stimulus.</summary>
		/// <returns></returns>
        public IQiFuture ResetAllParametersAsync()
        {
            return SourceService["resetAllParameters"].CallAsync();
        }

        /// <summary>Get the specified parameter.</summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <returns>ALValue format for required parameter</returns>
        public IQiResult GetParameter(string arg0_paramName)
        {
            return SourceService["getParameter"].Call<IQiResult>(arg0_paramName);
        }

        /// <summary>Get the specified parameter.</summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <returns>ALValue format for required parameter</returns>
        public IQiFuture<IQiResult> GetParameterAsync(string arg0_paramName)
        {
            return SourceService["getParameter"].CallAsync<IQiResult>(arg0_paramName);
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public void SetEngagementMode(string arg0_modeName)
        {
            SourceService["setEngagementMode"].Call(arg0_modeName);
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public IQiFuture SetEngagementModeAsync(string arg0_modeName)
        {
            return SourceService["setEngagementMode"].CallAsync(arg0_modeName);
        }

        /// <summary>Set engagement mode.</summary>
		/// <returns>Name of current engagement mode as a string</returns>
        public string GetEngagementMode()
        {
            return SourceService["getEngagementMode"].Call<string>();
        }

        /// <summary>Set engagement mode.</summary>
		/// <returns>Name of current engagement mode as a string</returns>
        public IQiFuture<string> GetEngagementModeAsync()
        {
            return SourceService["getEngagementMode"].CallAsync<string>();
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_checkStimWhenFocused">when it is tracking someone, true makes the robot check a stimulus to see if it corresponds to a human, false makes it go back to the current track human just after watching in the stim direction (as in SemiEngaged mode)</param>
		/// <param name="arg1_stimuliWhenNotTracking">stimuli enabled when the robot is tracking, as a stimuli names list</param>
		/// <param name="arg2_stimuliWhenTracking">stimuli enabled when the robot is not tracking, as a stimuli names list</param>
		/// <returns></returns>
        public void _setCustomEngagementMode(bool arg0_checkStimWhenFocused, IEnumerable<string> arg1_stimuliWhenNotTracking, IEnumerable<string> arg2_stimuliWhenTracking)
        {
            SourceService["_setCustomEngagementMode"].Call(arg0_checkStimWhenFocused, arg1_stimuliWhenNotTracking, arg2_stimuliWhenTracking);
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_checkStimWhenFocused">when it is tracking someone, true makes the robot check a stimulus to see if it corresponds to a human, false makes it go back to the current track human just after watching in the stim direction (as in SemiEngaged mode)</param>
		/// <param name="arg1_stimuliWhenNotTracking">stimuli enabled when the robot is tracking, as a stimuli names list</param>
		/// <param name="arg2_stimuliWhenTracking">stimuli enabled when the robot is not tracking, as a stimuli names list</param>
		/// <returns></returns>
        public IQiFuture _setCustomEngagementModeAsync(bool arg0_checkStimWhenFocused, IEnumerable<string> arg1_stimuliWhenNotTracking, IEnumerable<string> arg2_stimuliWhenTracking)
        {
            return SourceService["_setCustomEngagementMode"].CallAsync(arg0_checkStimWhenFocused, arg1_stimuliWhenNotTracking, arg2_stimuliWhenTracking);
        }

        /// <summary>Set tracking mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public void SetTrackingMode(string arg0_modeName)
        {
            SourceService["setTrackingMode"].Call(arg0_modeName);
        }

        /// <summary>Set tracking mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public IQiFuture SetTrackingModeAsync(string arg0_modeName)
        {
            return SourceService["setTrackingMode"].CallAsync(arg0_modeName);
        }

        /// <summary>Set tracking mode.</summary>
		/// <returns>Name of current tracking mode as a string</returns>
        public string GetTrackingMode()
        {
            return SourceService["getTrackingMode"].Call<string>();
        }

        /// <summary>Set tracking mode.</summary>
		/// <returns>Name of current tracking mode as a string</returns>
        public IQiFuture<string> GetTrackingModeAsync()
        {
            return SourceService["getTrackingMode"].CallAsync<string>();
        }

        /// <summary>Force Engage Person.</summary>
		/// <param name="arg0_engagePerson">ID of the person as found in PeoplePerception.</param>
		/// <returns>true if the robot succeeded to engage the person, else false.</returns>
        public bool EngagePerson(int arg0_engagePerson)
        {
            return SourceService["engagePerson"].Call<bool>(arg0_engagePerson);
        }

        /// <summary>Force Engage Person.</summary>
		/// <param name="arg0_engagePerson">ID of the person as found in PeoplePerception.</param>
		/// <returns>true if the robot succeeded to engage the person, else false.</returns>
        public IQiFuture<bool> EngagePersonAsync(int arg0_engagePerson)
        {
            return SourceService["engagePerson"].CallAsync<bool>(arg0_engagePerson);
        }

        /// <summary>Set a new contextual moves type.</summary>
		/// <param name="arg0_contextualMove">The contextual move, can be 'forward', 'backward', 'sides' and 'random'.</param>
		/// <returns></returns>
        public void _setContextualMoveType(string arg0_contextualMove)
        {
            SourceService["_setContextualMoveType"].Call(arg0_contextualMove);
        }

        /// <summary>Set a new contextual moves type.</summary>
		/// <param name="arg0_contextualMove">The contextual move, can be 'forward', 'backward', 'sides' and 'random'.</param>
		/// <returns></returns>
        public IQiFuture _setContextualMoveTypeAsync(string arg0_contextualMove)
        {
            return SourceService["_setContextualMoveType"].CallAsync(arg0_contextualMove);
        }

        /// <summary>Trigger a custom stimulus.</summary>
		/// <param name="arg0_stimulusPosition">Position of the stimulus, in Frame World</param>
		/// <returns>If someone was found, return value is its ID, else it's -1</returns>
        public int TriggerStimulus(IEnumerable<float> arg0_stimulusPosition)
        {
            return SourceService["triggerStimulus"].Call<int>(arg0_stimulusPosition);
        }

        /// <summary>Trigger a custom stimulus.</summary>
		/// <param name="arg0_stimulusPosition">Position of the stimulus, in Frame World</param>
		/// <returns>If someone was found, return value is its ID, else it's -1</returns>
        public IQiFuture<int> TriggerStimulusAsync(IEnumerable<float> arg0_stimulusPosition)
        {
            return SourceService["triggerStimulus"].CallAsync<int>(arg0_stimulusPosition);
        }

        /// <summary>DEPRECATED since 2.4: use pauseAwareness instead.</summary>
		/// <returns></returns>
        public void _pauseAwareness()
        {
            SourceService["_pauseAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use pauseAwareness instead.</summary>
		/// <returns></returns>
        public IQiFuture _pauseAwarenessAsync()
        {
            return SourceService["_pauseAwareness"].CallAsync();
        }

        /// <summary>DEPRECATED since 2.4: use resumeAwareness instead.</summary>
		/// <returns></returns>
        public void _resumeAwareness()
        {
            SourceService["_resumeAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use resumeAwareness instead.</summary>
		/// <returns></returns>
        public IQiFuture _resumeAwarenessAsync()
        {
            return SourceService["_resumeAwareness"].CallAsync();
        }

        /// <summary>DEPRECATED since 2.4: use isAwarenessPaused instead.</summary>
		/// <returns></returns>
        public bool _isAwarenessPaused()
        {
            return SourceService["_isAwarenessPaused"].Call<bool>();
        }

        /// <summary>DEPRECATED since 2.4: use isAwarenessPaused instead.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _isAwarenessPausedAsync()
        {
            return SourceService["_isAwarenessPaused"].CallAsync<bool>();
        }

        /// <summary>Use leds for debug</summary>
		/// <param name="arg0_useLeds">Boolean value: true to use leds.</param>
		/// <returns></returns>
        public void _useLedDebug(bool arg0_useLeds)
        {
            SourceService["_useLedDebug"].Call(arg0_useLeds);
        }

        /// <summary>Use leds for debug</summary>
		/// <param name="arg0_useLeds">Boolean value: true to use leds.</param>
		/// <returns></returns>
        public IQiFuture _useLedDebugAsync(bool arg0_useLeds)
        {
            return SourceService["_useLedDebug"].CallAsync(arg0_useLeds);
        }

        /// <summary>Set Led group</summary>
		/// <param name="arg0_ledGroupName">Name of the led group.</param>
		/// <returns></returns>
        public void _setLedGroup(string arg0_ledGroupName)
        {
            SourceService["_setLedGroup"].Call(arg0_ledGroupName);
        }

        /// <summary>Set Led group</summary>
		/// <param name="arg0_ledGroupName">Name of the led group.</param>
		/// <returns></returns>
        public IQiFuture _setLedGroupAsync(string arg0_ledGroupName)
        {
            return SourceService["_setLedGroup"].CallAsync(arg0_ledGroupName);
        }

        /// <summary>Use debug display in robot view</summary>
		/// <param name="arg0_useDisplay">Boolean value: true to use debug display in robot view.</param>
		/// <returns></returns>
        public void _displayRobotViewDebug(bool arg0_useDisplay)
        {
            SourceService["_displayRobotViewDebug"].Call(arg0_useDisplay);
        }

        /// <summary>Use debug display in robot view</summary>
		/// <param name="arg0_useDisplay">Boolean value: true to use debug display in robot view.</param>
		/// <returns></returns>
        public IQiFuture _displayRobotViewDebugAsync(bool arg0_useDisplay)
        {
            return SourceService["_displayRobotViewDebug"].CallAsync(arg0_useDisplay);
        }

        /// <summary>Get parameters documentation</summary>
		/// <returns>Parameters info as string</returns>
        public string _getParametersInfo()
        {
            return SourceService["_getParametersInfo"].Call<string>();
        }

        /// <summary>Get parameters documentation</summary>
		/// <returns>Parameters info as string</returns>
        public IQiFuture<string> _getParametersInfoAsync()
        {
            return SourceService["_getParametersInfo"].CallAsync<string>();
        }

        /// <summary>Allow the robot to detect stimuli coming from behind and to turnthe base up to 180 degrees to watch them. If it's disabled, thestimuli from behind won't be taken into account.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public void _setEnableStimuliFromBehind(bool arg0_enable)
        {
            SourceService["_setEnableStimuliFromBehind"].Call(arg0_enable);
        }

        /// <summary>Allow the robot to detect stimuli coming from behind and to turnthe base up to 180 degrees to watch them. If it's disabled, thestimuli from behind won't be taken into account.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public IQiFuture _setEnableStimuliFromBehindAsync(bool arg0_enable)
        {
            return SourceService["_setEnableStimuliFromBehind"].CallAsync(arg0_enable);
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if stimuli from behind are enabled, else false.</returns>
        public bool _getEnableStimuliFromBehind()
        {
            return SourceService["_getEnableStimuliFromBehind"].Call<bool>();
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if stimuli from behind are enabled, else false.</returns>
        public IQiFuture<bool> _getEnableStimuliFromBehindAsync()
        {
            return SourceService["_getEnableStimuliFromBehind"].CallAsync<bool>();
        }

        /// <summary>Allow the robot to check downwards for low stimuli if nobody's found.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public void _setEnableCheckLowStimuli(bool arg0_enable)
        {
            SourceService["_setEnableCheckLowStimuli"].Call(arg0_enable);
        }

        /// <summary>Allow the robot to check downwards for low stimuli if nobody's found.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public IQiFuture _setEnableCheckLowStimuliAsync(bool arg0_enable)
        {
            return SourceService["_setEnableCheckLowStimuli"].CallAsync(arg0_enable);
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if low stimuli are enabled, else false.</returns>
        public bool _getEnableCheckLowStimuli()
        {
            return SourceService["_getEnableCheckLowStimuli"].Call<bool>();
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if low stimuli are enabled, else false.</returns>
        public IQiFuture<bool> _getEnableCheckLowStimuliAsync()
        {
            return SourceService["_getEnableCheckLowStimuli"].CallAsync<bool>();
        }

        /// <summary>Get the position of home</summary>
		/// <returns>Pose2D as vector: Pose2D of home.</returns>
        public IQiResult _getHomeReferencePosition()
        {
            return SourceService["_getHomeReferencePosition"].Call<IQiResult>();
        }

        /// <summary>Get the position of home</summary>
		/// <returns>Pose2D as vector: Pose2D of home.</returns>
        public IQiFuture<IQiResult> _getHomeReferencePositionAsync()
        {
            return SourceService["_getHomeReferencePosition"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceUpdated(string arg0, object arg1, string arg2)
        {
            SourceService["_onPreferenceUpdated"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onPreferenceUpdatedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onPreferenceUpdated"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceSynchronized(string arg0, object arg1, string arg2)
        {
            SourceService["_onPreferenceSynchronized"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onPreferenceSynchronizedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onPreferenceSynchronized"].CallAsync(arg0, arg1, arg2);
        }

    }
}