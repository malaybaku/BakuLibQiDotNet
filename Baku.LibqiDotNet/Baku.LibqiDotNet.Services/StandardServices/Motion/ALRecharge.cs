using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALRecharge
	{
		internal ALRecharge(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALRecharge CreateService(IQiSession session)
		{
			var result = new ALRecharge(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALRecharge CreateUninitializedService(IQiSession session)
		{
			return new ALRecharge(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALRecharge");
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

        /// <summary>.</summary>
		/// <returns></returns>
        public void GoToStation()
        {
            SourceService["goToStation"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture GoToStationAsync()
        {
            return SourceService["goToStation"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int LeaveStation()
        {
            return SourceService["leaveStation"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> LeaveStationAsync()
        {
            return SourceService["leaveStation"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult GetStationPosition()
        {
            return SourceService["getStationPosition"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetStationPositionAsync()
        {
            return SourceService["getStationPosition"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture StopAllAsync()
        {
            return SourceService["stopAll"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void Subscribe()
        {
            SourceService["subscribe"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture SubscribeAsync()
        {
            return SourceService["subscribe"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void Unsubscribe()
        {
            SourceService["unsubscribe"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture UnsubscribeAsync()
        {
            return SourceService["unsubscribe"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int GetStatus()
        {
            return SourceService["getStatus"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> GetStatusAsync()
        {
            return SourceService["getStatus"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult LookForStation()
        {
            return SourceService["lookForStation"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> LookForStationAsync()
        {
            return SourceService["lookForStation"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int MoveInFrontOfStation()
        {
            return SourceService["moveInFrontOfStation"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> MoveInFrontOfStationAsync()
        {
            return SourceService["moveInFrontOfStation"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int DockOnStation()
        {
            return SourceService["dockOnStation"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> DockOnStationAsync()
        {
            return SourceService["dockOnStation"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetUseTrackerSearcher(bool arg0)
        {
            SourceService["setUseTrackerSearcher"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture SetUseTrackerSearcherAsync(bool arg0)
        {
            return SourceService["setUseTrackerSearcher"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool GetUseTrackerSearcher()
        {
            return SourceService["getUseTrackerSearcher"].Call<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<bool> GetUseTrackerSearcherAsync()
        {
            return SourceService["getUseTrackerSearcher"].CallAsync<bool>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetMaxNumberOfTries(int arg0)
        {
            SourceService["setMaxNumberOfTries"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture SetMaxNumberOfTriesAsync(int arg0)
        {
            return SourceService["setMaxNumberOfTries"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int GetMaxNumberOfTries()
        {
            return SourceService["getMaxNumberOfTries"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> GetMaxNumberOfTriesAsync()
        {
            return SourceService["getMaxNumberOfTries"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int AdjustDockingPosition(object arg0)
        {
            return SourceService["adjustDockingPosition"].Call<int>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> AdjustDockingPositionAsync(object arg0)
        {
            return SourceService["adjustDockingPosition"].CallAsync<int>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getConfidenceIndex()
        {
            return SourceService["_getConfidenceIndex"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getConfidenceIndexAsync()
        {
            return SourceService["_getConfidenceIndex"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _allowTrackerNavigateTo(bool arg0)
        {
            SourceService["_allowTrackerNavigateTo"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _allowTrackerNavigateToAsync(bool arg0)
        {
            return SourceService["_allowTrackerNavigateTo"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachDistance(float arg0)
        {
            SourceService["_setFinalApproachDistance"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFinalApproachDistanceAsync(float arg0)
        {
            return SourceService["_setFinalApproachDistance"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalApproachDistance()
        {
            return SourceService["_getFinalApproachDistance"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getFinalApproachDistanceAsync()
        {
            return SourceService["_getFinalApproachDistance"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachYOffset(float arg0)
        {
            SourceService["_setFinalApproachYOffset"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFinalApproachYOffsetAsync(float arg0)
        {
            return SourceService["_setFinalApproachYOffset"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalApproachYOffset()
        {
            return SourceService["_getFinalApproachYOffset"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getFinalApproachYOffsetAsync()
        {
            return SourceService["_getFinalApproachYOffset"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachThreshold(IEnumerable<float> arg0)
        {
            SourceService["_setFinalApproachThreshold"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFinalApproachThresholdAsync(IEnumerable<float> arg0)
        {
            return SourceService["_setFinalApproachThreshold"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getFinalApproachThreshold()
        {
            return SourceService["_getFinalApproachThreshold"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getFinalApproachThresholdAsync()
        {
            return SourceService["_getFinalApproachThreshold"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setStationDetectionConfidenceThreshold(float arg0)
        {
            SourceService["_setStationDetectionConfidenceThreshold"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setStationDetectionConfidenceThresholdAsync(float arg0)
        {
            return SourceService["_setStationDetectionConfidenceThreshold"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getStationDetectionConfidenceThreshold()
        {
            return SourceService["_getStationDetectionConfidenceThreshold"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getStationDetectionConfidenceThresholdAsync()
        {
            return SourceService["_getStationDetectionConfidenceThreshold"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _startLogging()
        {
            SourceService["_startLogging"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _startLoggingAsync()
        {
            return SourceService["_startLogging"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _stopLogging()
        {
            SourceService["_stopLogging"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _stopLoggingAsync()
        {
            return SourceService["_stopLogging"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getFinalConnectionMoves()
        {
            return SourceService["_getFinalConnectionMoves"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getFinalConnectionMovesAsync()
        {
            return SourceService["_getFinalConnectionMoves"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalConnectionMoves(object arg0)
        {
            SourceService["_setFinalConnectionMoves"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFinalConnectionMovesAsync(object arg0)
        {
            return SourceService["_setFinalConnectionMoves"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalConnectionMovesDelay(float arg0)
        {
            SourceService["_setFinalConnectionMovesDelay"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFinalConnectionMovesDelayAsync(float arg0)
        {
            return SourceService["_setFinalConnectionMovesDelay"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalConnectionMovesDelay()
        {
            return SourceService["_getFinalConnectionMovesDelay"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getFinalConnectionMovesDelayAsync()
        {
            return SourceService["_getFinalConnectionMovesDelay"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setEnableCheckDisconnectionTask(bool arg0)
        {
            SourceService["_setEnableCheckDisconnectionTask"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setEnableCheckDisconnectionTaskAsync(bool arg0)
        {
            return SourceService["_setEnableCheckDisconnectionTask"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _getEnableCheckDisconnectionTask()
        {
            return SourceService["_getEnableCheckDisconnectionTask"].Call<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _getEnableCheckDisconnectionTaskAsync()
        {
            return SourceService["_getEnableCheckDisconnectionTask"].CallAsync<bool>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _updateStationDetection(string arg0, object arg1, string arg2)
        {
            SourceService["_updateStationDetection"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _updateStationDetectionAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_updateStationDetection"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerSearcherLoopCallback()
        {
            SourceService["_eventTrackerSearcherLoopCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _eventTrackerSearcherLoopCallbackAsync()
        {
            return SourceService["_eventTrackerSearcherLoopCallback"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerTargetReachedCallback()
        {
            SourceService["_eventTrackerTargetReachedCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _eventTrackerTargetReachedCallbackAsync()
        {
            return SourceService["_eventTrackerTargetReachedCallback"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerTargetLostCallback()
        {
            SourceService["_eventTrackerTargetLostCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _eventTrackerTargetLostCallbackAsync()
        {
            return SourceService["_eventTrackerTargetLostCallback"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventTrackerActiveTargetChangedCallback(string arg0, object arg1, string arg2)
        {
            SourceService["_eventTrackerActiveTargetChangedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _eventTrackerActiveTargetChangedCallbackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_eventTrackerActiveTargetChangedCallback"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventMoveFailedCallback(string arg0, object arg1, string arg2)
        {
            SourceService["_eventMoveFailedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _eventMoveFailedCallbackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_eventMoveFailedCallback"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventBatteryConnectedToChargingStationCallback(string arg0, object arg1, string arg2)
        {
            SourceService["_eventBatteryConnectedToChargingStationCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _eventBatteryConnectedToChargingStationCallbackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_eventBatteryConnectedToChargingStationCallback"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventNavigationStatusChangedCallback(string arg0, object arg1, string arg2)
        {
            SourceService["_eventNavigationStatusChangedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _eventNavigationStatusChangedCallbackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_eventNavigationStatusChangedCallback"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventSlopeDetectedChangedCallback(string arg0, object arg1, string arg2)
        {
            SourceService["_eventSlopeDetectedChangedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _eventSlopeDetectedChangedCallbackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_eventSlopeDetectedChangedCallback"].CallAsync(arg0, arg1, arg2);
        }

    }
}