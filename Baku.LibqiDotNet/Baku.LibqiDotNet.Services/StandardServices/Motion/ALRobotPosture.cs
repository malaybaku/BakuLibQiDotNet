using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALRobotPosture module to make the robot go tothe asked posture.</summary>
    public class ALRobotPosture
	{
		internal ALRobotPosture(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALRobotPosture CreateService(IQiSession session)
		{
			var result = new ALRobotPosture(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALRobotPosture CreateUninitializedService(IQiSession session)
		{
			return new ALRobotPosture(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALRobotPosture");
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

        /// <summary>Returns the posture family for example Standing, LyingBelly,...</summary>
		/// <returns>Returns the posture family, e.g. Standing.</returns>
        public string GetPostureFamily()
        {
            return SourceService["getPostureFamily"].Call<string>();
        }

        /// <summary>Returns the posture family for example Standing, LyingBelly,...</summary>
		/// <returns>Returns the posture family, e.g. Standing.</returns>
        public IQiFuture<string> GetPostureFamilyAsync()
        {
            return SourceService["getPostureFamily"].CallAsync<string>();
        }

        /// <summary>Make the robot go to the choosenposture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public bool GoToPosture(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return SourceService["goToPosture"].Call<bool>(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Make the robot go to the choosenposture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public IQiFuture<bool> GoToPostureAsync(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return SourceService["goToPosture"].CallAsync<bool>(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Set the angle of the joints of the  robot to the choosen posture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public bool ApplyPosture(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return SourceService["applyPosture"].Call<bool>(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Set the angle of the joints of the  robot to the choosen posture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public IQiFuture<bool> ApplyPostureAsync(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return SourceService["applyPosture"].CallAsync<bool>(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Stop the posture move.</summary>
		/// <returns></returns>
        public void StopMove()
        {
            SourceService["stopMove"].Call();
        }

        /// <summary>Stop the posture move.</summary>
		/// <returns></returns>
        public IQiFuture StopMoveAsync()
        {
            return SourceService["stopMove"].CallAsync();
        }

        /// <summary>Get the list of posture names available.</summary>
		/// <returns></returns>
        public string[] GetPostureList()
        {
            return SourceService["getPostureList"].Call<string[]>();
        }

        /// <summary>Get the list of posture names available.</summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetPostureListAsync()
        {
            return SourceService["getPostureList"].CallAsync<string[]>();
        }

        /// <summary>Get the list of posture family names available.</summary>
		/// <returns></returns>
        public string[] GetPostureFamilyList()
        {
            return SourceService["getPostureFamilyList"].Call<string[]>();
        }

        /// <summary>Get the list of posture family names available.</summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetPostureFamilyListAsync()
        {
            return SourceService["getPostureFamilyList"].CallAsync<string[]>();
        }

        /// <summary>Set maximum of tries ongoToPosture fail.</summary>
		/// <param name="arg0_pMaxTryNumber">Number of retry if goToPosture fail.</param>
		/// <returns></returns>
        public void SetMaxTryNumber(int arg0_pMaxTryNumber)
        {
            SourceService["setMaxTryNumber"].Call(arg0_pMaxTryNumber);
        }

        /// <summary>Set maximum of tries ongoToPosture fail.</summary>
		/// <param name="arg0_pMaxTryNumber">Number of retry if goToPosture fail.</param>
		/// <returns></returns>
        public IQiFuture SetMaxTryNumberAsync(int arg0_pMaxTryNumber)
        {
            return SourceService["setMaxTryNumber"].CallAsync(arg0_pMaxTryNumber);
        }

        /// <summary>Determine posture.</summary>
		/// <returns></returns>
        public string GetPosture()
        {
            return SourceService["getPosture"].Call<string>();
        }

        /// <summary>Determine posture.</summary>
		/// <returns></returns>
        public IQiFuture<string> GetPostureAsync()
        {
            return SourceService["getPosture"].CallAsync<string>();
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiResult _isRobotInPosture(string arg0, float arg1, float arg2)
        {
            return SourceService["_isRobotInPosture"].Call<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _isRobotInPostureAsync(string arg0, float arg1, float arg2)
        {
            return SourceService["_isRobotInPosture"].CallAsync<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _isRobotInPostureId(int arg0, float arg1, float arg2)
        {
            return SourceService["_isRobotInPostureId"].Call<bool>(arg0, arg1, arg2);
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<bool> _isRobotInPostureIdAsync(int arg0, float arg1, float arg2)
        {
            return SourceService["_isRobotInPostureId"].CallAsync<bool>(arg0, arg1, arg2);
        }

        /// <summary>Determine posture id.</summary>
		/// <returns></returns>
        public IQiResult _getPosture()
        {
            return SourceService["_getPosture"].Call<IQiResult>();
        }

        /// <summary>Determine posture id.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getPostureAsync()
        {
            return SourceService["_getPosture"].CallAsync<IQiResult>();
        }

        /// <summary>Set the angle of the joints.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setPostureId(int arg0, float arg1)
        {
            return SourceService["_setPostureId"].Call<bool>(arg0, arg1);
        }

        /// <summary>Set the angle of the joints.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _setPostureIdAsync(int arg0, float arg1)
        {
            return SourceService["_setPostureId"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Set the angle of thejoints and of the inertial unit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _goToPostureId(int arg0, float arg1)
        {
            return SourceService["_goToPostureId"].Call<bool>(arg0, arg1);
        }

        /// <summary>Set the angle of thejoints and of the inertial unit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _goToPostureIdAsync(int arg0, float arg1)
        {
            return SourceService["_goToPostureId"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Name posture from id.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _namePosture(int arg0, string arg1)
        {
            return SourceService["_namePosture"].Call<bool>(arg0, arg1);
        }

        /// <summary>Name posture from id.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _namePostureAsync(int arg0, string arg1)
        {
            return SourceService["_namePosture"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Rename posture from name.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _renamePosture(string arg0, string arg1)
        {
            return SourceService["_renamePosture"].Call<bool>(arg0, arg1);
        }

        /// <summary>Rename posture from name.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _renamePostureAsync(string arg0, string arg1)
        {
            return SourceService["_renamePosture"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Resave posture joints, inertial, family. Keep neighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _resavePosture(int arg0)
        {
            return SourceService["_resavePosture"].Call<bool>(arg0);
        }

        /// <summary>Resave posture joints, inertial, family. Keep neighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _resavePostureAsync(int arg0)
        {
            return SourceService["_resavePosture"].CallAsync<bool>(arg0);
        }

        /// <summary>Set slow factorbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _setSlowFactor(int arg0, int arg1, float arg2)
        {
            return SourceService["_setSlowFactor"].Call<bool>(arg0, arg1, arg2);
        }

        /// <summary>Set slow factorbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<bool> _setSlowFactorAsync(int arg0, int arg1, float arg2)
        {
            return SourceService["_setSlowFactor"].CallAsync<bool>(arg0, arg1, arg2);
        }

        /// <summary>Set anti collisionbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setAntiCollision(int arg0, bool arg1)
        {
            return SourceService["_setAntiCollision"].Call<bool>(arg0, arg1);
        }

        /// <summary>Set anti collisionbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _setAntiCollisionAsync(int arg0, bool arg1)
        {
            return SourceService["_setAntiCollision"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Enables/Disables anti collision management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable anticollision management.</param>
		/// <returns></returns>
        public void _setUseAntiCollision(bool arg0_enable)
        {
            SourceService["_setUseAntiCollision"].Call(arg0_enable);
        }

        /// <summary>Enables/Disables anti collision management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable anticollision management.</param>
		/// <returns></returns>
        public IQiFuture _setUseAntiCollisionAsync(bool arg0_enable)
        {
            return SourceService["_setUseAntiCollision"].CallAsync(arg0_enable);
        }

        /// <summary>Enables/Disables auto balance management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable auto balance management.</param>
		/// <returns></returns>
        public void _setUseAutoBalance(bool arg0_enable)
        {
            SourceService["_setUseAutoBalance"].Call(arg0_enable);
        }

        /// <summary>Enables/Disables auto balance management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable auto balance management.</param>
		/// <returns></returns>
        public IQiFuture _setUseAutoBalanceAsync(bool arg0_enable)
        {
            return SourceService["_setUseAutoBalance"].CallAsync(arg0_enable);
        }

        /// <summary>Set cost between two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setCost(int arg0, float arg1)
        {
            return SourceService["_setCost"].Call<bool>(arg0, arg1);
        }

        /// <summary>Set cost between two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _setCostAsync(int arg0, float arg1)
        {
            return SourceService["_setCost"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Save current posture.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _saveCurrentPosture(int arg0)
        {
            return SourceService["_saveCurrentPosture"].Call<bool>(arg0);
        }

        /// <summary>Save current posture.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _saveCurrentPostureAsync(int arg0)
        {
            return SourceService["_saveCurrentPosture"].CallAsync<bool>(arg0);
        }

        /// <summary>Save with a namecurrent posture.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _saveCurrentPostureWithName(int arg0, string arg1)
        {
            return SourceService["_saveCurrentPostureWithName"].Call<bool>(arg0, arg1);
        }

        /// <summary>Save with a namecurrent posture.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _saveCurrentPostureWithNameAsync(int arg0, string arg1)
        {
            return SourceService["_saveCurrentPostureWithName"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Apply postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public bool _applyPostures(IEnumerable<int> arg0, float arg1, bool arg2, bool arg3)
        {
            return SourceService["_applyPostures"].Call<bool>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Apply postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<bool> _applyPosturesAsync(IEnumerable<int> arg0, float arg1, bool arg2, bool arg3)
        {
            return SourceService["_applyPostures"].CallAsync<bool>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Erase all postures.</summary>
		/// <returns></returns>
        public bool _eraseAllPostures()
        {
            return SourceService["_eraseAllPostures"].Call<bool>();
        }

        /// <summary>Erase all postures.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _eraseAllPosturesAsync()
        {
            return SourceService["_eraseAllPostures"].CallAsync<bool>();
        }

        /// <summary>Bind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public bool _bindPostures(int arg0, int arg1, float arg2, float arg3)
        {
            return SourceService["_bindPostures"].Call<bool>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Bind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<bool> _bindPosturesAsync(int arg0, int arg1, float arg2, float arg3)
        {
            return SourceService["_bindPostures"].CallAsync<bool>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Add a neighbour to a postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _addNeighbourToPosture(int arg0, int arg1, float arg2)
        {
            return SourceService["_addNeighbourToPosture"].Call<bool>(arg0, arg1, arg2);
        }

        /// <summary>Add a neighbour to a postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<bool> _addNeighbourToPostureAsync(int arg0, int arg1, float arg2)
        {
            return SourceService["_addNeighbourToPosture"].CallAsync<bool>(arg0, arg1, arg2);
        }

        /// <summary>Remove a neighbour from postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _removeNeighbourFromPosture(int arg0, int arg1)
        {
            return SourceService["_removeNeighbourFromPosture"].Call<bool>(arg0, arg1);
        }

        /// <summary>Remove a neighbour from postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _removeNeighbourFromPostureAsync(int arg0, int arg1)
        {
            return SourceService["_removeNeighbourFromPosture"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Unbind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unBindPostures(int arg0, int arg1)
        {
            return SourceService["_unBindPostures"].Call<bool>(arg0, arg1);
        }

        /// <summary>Unbind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _unBindPosturesAsync(int arg0, int arg1)
        {
            return SourceService["_unBindPostures"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary>Erase the posture and unBind theneighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _erasePosture(int arg0)
        {
            return SourceService["_erasePosture"].Call<bool>(arg0);
        }

        /// <summary>Erase the posture and unBind theneighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _erasePostureAsync(int arg0)
        {
            return SourceService["_erasePosture"].CallAsync<bool>(arg0);
        }

        /// <summary>Get library size.</summary>
		/// <returns></returns>
        public int _getLibrarySize()
        {
            return SourceService["_getLibrarySize"].Call<int>();
        }

        /// <summary>Get library size.</summary>
		/// <returns></returns>
        public IQiFuture<int> _getLibrarySizeAsync()
        {
            return SourceService["_getLibrarySize"].CallAsync<int>();
        }

        /// <summary>Load a new library file.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _loadPostureLibraryFromName(string arg0)
        {
            return SourceService["_loadPostureLibraryFromName"].Call<bool>(arg0);
        }

        /// <summary>Load a new library file.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _loadPostureLibraryFromNameAsync(string arg0)
        {
            return SourceService["_loadPostureLibraryFromName"].CallAsync<bool>(arg0);
        }

        /// <summary>Get current graph path.</summary>
		/// <returns></returns>
        public IQiResult _getCurrentPath()
        {
            return SourceService["_getCurrentPath"].Call<IQiResult>();
        }

        /// <summary>Get current graph path.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getCurrentPathAsync()
        {
            return SourceService["_getCurrentPath"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _isStandCallBack(string arg0, object arg1, string arg2)
        {
            SourceService["_isStandCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _isStandCallBackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_isStandCallBack"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _savePostureLibrary(string arg0)
        {
            return SourceService["_savePostureLibrary"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _savePostureLibraryAsync(string arg0)
        {
            return SourceService["_savePostureLibrary"].CallAsync<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public float _getArticularDistanceToPosture(int arg0)
        {
            return SourceService["_getArticularDistanceToPosture"].Call<float>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<float> _getArticularDistanceToPostureAsync(int arg0)
        {
            return SourceService["_getArticularDistanceToPosture"].CallAsync<float>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getCartesianDistanceToPosture(int arg0)
        {
            return SourceService["_getCartesianDistanceToPosture"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getCartesianDistanceToPostureAsync(int arg0)
        {
            return SourceService["_getCartesianDistanceToPosture"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getCartesianDistanceVector(int arg0)
        {
            return SourceService["_getCartesianDistanceVector"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getCartesianDistanceVectorAsync(int arg0)
        {
            return SourceService["_getCartesianDistanceVector"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int[] _getPostureIdList()
        {
            return SourceService["_getPostureIdList"].Call<int[]>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int[]> _getPostureIdListAsync()
        {
            return SourceService["_getPostureIdList"].CallAsync<int[]>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isReachable(int arg0)
        {
            return SourceService["_isReachable"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _isReachableAsync(int arg0)
        {
            return SourceService["_isReachable"].CallAsync<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _generateCartesianMap()
        {
            SourceService["_generateCartesianMap"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _generateCartesianMapAsync()
        {
            return SourceService["_generateCartesianMap"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getPostureZ(float arg0)
        {
            return SourceService["_getPostureZ"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getPostureZAsync(float arg0)
        {
            return SourceService["_getPostureZ"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getPostureNoZ()
        {
            return SourceService["_getPostureNoZ"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getPostureNoZAsync()
        {
            return SourceService["_getPostureNoZ"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _getIdFromName(string arg0)
        {
            return SourceService["_getIdFromName"].Call<int>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _getIdFromNameAsync(string arg0)
        {
            return SourceService["_getIdFromName"].CallAsync<int>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _activeDiagnosisCallBack(string arg0, object arg1, string arg2)
        {
            SourceService["_activeDiagnosisCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _activeDiagnosisCallBackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_activeDiagnosisCallBack"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _eraseFamily(string arg0)
        {
            return SourceService["_eraseFamily"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _eraseFamilyAsync(string arg0)
        {
            return SourceService["_eraseFamily"].CallAsync<bool>(arg0);
        }

    }
}