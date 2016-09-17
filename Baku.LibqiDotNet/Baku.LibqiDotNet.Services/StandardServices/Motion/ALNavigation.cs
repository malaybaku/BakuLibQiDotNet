using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALNavigation module to make the robot go safely to the asked pose2D.</summary>
    public class ALNavigation
	{
		internal ALNavigation(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALNavigation CreateService(IQiSession session)
		{
			var result = new ALNavigation(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALNavigation CreateUninitializedService(IQiSession session)
		{
			return new ALNavigation(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALNavigation");
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

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y)
        {
            return SourceService["navigateTo"].Call<bool>(arg0_x, arg1_y);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <returns></returns>
        public IQiFuture<bool> NavigateToAsync(float arg0_x, float arg1_y)
        {
            return SourceService["navigateTo"].CallAsync<bool>(arg0_x, arg1_y);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, object arg2_config)
        {
            return SourceService["navigateTo"].Call<bool>(arg0_x, arg1_y, arg2_config);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public IQiFuture<bool> NavigateToAsync(float arg0_x, float arg1_y, object arg2_config)
        {
            return SourceService["navigateTo"].CallAsync<bool>(arg0_x, arg1_y, arg2_config);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            return SourceService["navigateTo"].Call<bool>(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <returns></returns>
        public IQiFuture<bool> NavigateToAsync(float arg0_x, float arg1_y, float arg2_theta)
        {
            return SourceService["navigateTo"].CallAsync<bool>(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <param name="arg3_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, float arg2_theta, object arg3_config)
        {
            return SourceService["navigateTo"].Call<bool>(arg0_x, arg1_y, arg2_theta, arg3_config);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <param name="arg3_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public IQiFuture<bool> NavigateToAsync(float arg0_x, float arg1_y, float arg2_theta, object arg3_config)
        {
            return SourceService["navigateTo"].CallAsync<bool>(arg0_x, arg1_y, arg2_theta, arg3_config);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <returns></returns>
        public IQiFuture MoveToAsync(float arg0_x, float arg1_y, float arg2_theta)
        {
            return SourceService["moveTo"].CallAsync(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public IQiFuture MoveToAsync(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            return SourceService["moveTo"].CallAsync(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <returns></returns>
        public IQiFuture MoveAsync(float arg0_x, float arg1_y, float arg2_theta)
        {
            return SourceService["move"].CallAsync(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public IQiFuture MoveAsync(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            return SourceService["move"].CallAsync(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <returns></returns>
        public IQiFuture MoveTowardAsync(float arg0_x, float arg1_y, float arg2_theta)
        {
            return SourceService["moveToward"].CallAsync(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public IQiFuture MoveTowardAsync(float arg0_x, float arg1_y, float arg2_theta, object arg3_moveConfig)
        {
            return SourceService["moveToward"].CallAsync(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void _setNavigationConfig(object arg0_config)
        {
            SourceService["_setNavigationConfig"].Call(arg0_config);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public IQiFuture _setNavigationConfigAsync(object arg0_config)
        {
            return SourceService["_setNavigationConfig"].CallAsync(arg0_config);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetSecurityDistance(float arg0)
        {
            SourceService["setSecurityDistance"].Call(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture SetSecurityDistanceAsync(float arg0)
        {
            return SourceService["setSecurityDistance"].CallAsync(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public float GetSecurityDistance()
        {
            return SourceService["getSecurityDistance"].Call<float>();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public IQiFuture<float> GetSecurityDistanceAsync()
        {
            return SourceService["getSecurityDistance"].CallAsync<float>();
        }

        /// <summary>Stops the navigateTo.</summary>
		/// <returns></returns>
        public void StopNavigateTo()
        {
            SourceService["stopNavigateTo"].Call();
        }

        /// <summary>Stops the navigateTo.</summary>
		/// <returns></returns>
        public IQiFuture StopNavigateToAsync()
        {
            return SourceService["stopNavigateTo"].CallAsync();
        }

        /// <summary>Stops the navigateTo but no stop move.</summary>
		/// <returns></returns>
        public void _stopNavigateToWithoutStopMove()
        {
            SourceService["_stopNavigateToWithoutStopMove"].Call();
        }

        /// <summary>Stops the navigateTo but no stop move.</summary>
		/// <returns></returns>
        public IQiFuture _stopNavigateToWithoutStopMoveAsync()
        {
            return SourceService["_stopNavigateToWithoutStopMove"].CallAsync();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setTangentialSecurityDistance(float arg0)
        {
            SourceService["_setTangentialSecurityDistance"].Call(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setTangentialSecurityDistanceAsync(float arg0)
        {
            return SourceService["_setTangentialSecurityDistance"].CallAsync(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public float _getTangentialSecurityDistance()
        {
            return SourceService["_getTangentialSecurityDistance"].Call<float>();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getTangentialSecurityDistanceAsync()
        {
            return SourceService["_getTangentialSecurityDistance"].CallAsync<float>();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public int _getNavigateToStatus()
        {
            return SourceService["_getNavigateToStatus"].Call<int>();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public IQiFuture<int> _getNavigateToStatusAsync()
        {
            return SourceService["_getNavigateToStatus"].CallAsync<int>();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are the one used by the secure navigator</summary>
		/// <returns></returns>
        public IQiResult _getObstacleData()
        {
            return SourceService["_getObstacleData"].Call<IQiResult>();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are the one used by the secure navigator</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getObstacleDataAsync()
        {
            return SourceService["_getObstacleData"].CallAsync<IQiResult>();
        }

        /// <summary>Get the requested occupancy grid formatted as a ROS navigation stack message.</summary>
		/// <param name="arg0_client">Internal: 'Secure' for SecureNavigator or 'Local' for LocalNavigator.</param>
		/// <returns></returns>
        public IQiResult _getOccupancyGrid(string arg0_client)
        {
            return SourceService["_getOccupancyGrid"].Call<IQiResult>(arg0_client);
        }

        /// <summary>Get the requested occupancy grid formatted as a ROS navigation stack message.</summary>
		/// <param name="arg0_client">Internal: 'Secure' for SecureNavigator or 'Local' for LocalNavigator.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getOccupancyGridAsync(string arg0_client)
        {
            return SourceService["_getOccupancyGrid"].CallAsync<IQiResult>(arg0_client);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <returns></returns>
        public IQiResult _getSensorData()
        {
            return SourceService["_getSensorData"].Call<IQiResult>();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorDataAsync()
        {
            return SourceService["_getSensorData"].CallAsync<IQiResult>();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getSensorData(string arg0)
        {
            return SourceService["_getSensorData"].Call<IQiResult>(arg0);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorDataAsync(string arg0)
        {
            return SourceService["_getSensorData"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getSensorData(IEnumerable<string> arg0)
        {
            return SourceService["_getSensorData"].Call<IQiResult>(arg0);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorDataAsync(IEnumerable<string> arg0)
        {
            return SourceService["_getSensorData"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _subscribeToAll(string arg0)
        {
            return SourceService["_subscribeToAll"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _subscribeToAllAsync(string arg0)
        {
            return SourceService["_subscribeToAll"].CallAsync<bool>(arg0);
        }

        /// <summary>Start active sensors.The client needs to specify its name to register.If the client is the only one to register, the sensors are turned on, otherwise they are already started.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _subscribe(string arg0_clientName, IEnumerable<string> arg1)
        {
            return SourceService["_subscribe"].Call<bool>(arg0_clientName, arg1);
        }

        /// <summary>Start active sensors.The client needs to specify its name to register.If the client is the only one to register, the sensors are turned on, otherwise they are already started.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _subscribeAsync(string arg0_clientName, IEnumerable<string> arg1)
        {
            return SourceService["_subscribe"].CallAsync<bool>(arg0_clientName, arg1);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _unsubscribeFromAll(string arg0)
        {
            return SourceService["_unsubscribeFromAll"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _unsubscribeFromAllAsync(string arg0)
        {
            return SourceService["_unsubscribeFromAll"].CallAsync<bool>(arg0);
        }

        /// <summary>Stop active sensors.The client needs to specify its name to unregister.The active sensors are actually stopped if not client is registered anymore.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unsubscribe(string arg0_clientName, IEnumerable<string> arg1)
        {
            return SourceService["_unsubscribe"].Call<bool>(arg0_clientName, arg1);
        }

        /// <summary>Stop active sensors.The client needs to specify its name to unregister.The active sensors are actually stopped if not client is registered anymore.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _unsubscribeAsync(string arg0_clientName, IEnumerable<string> arg1)
        {
            return SourceService["_unsubscribe"].CallAsync<bool>(arg0_clientName, arg1);
        }

        /// <summary>Add a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public bool _addSensor(string arg0_sensor)
        {
            return SourceService["_addSensor"].Call<bool>(arg0_sensor);
        }

        /// <summary>Add a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public IQiFuture<bool> _addSensorAsync(string arg0_sensor)
        {
            return SourceService["_addSensor"].CallAsync<bool>(arg0_sensor);
        }

        /// <summary>Remove a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public bool _removeSensor(string arg0_sensor)
        {
            return SourceService["_removeSensor"].Call<bool>(arg0_sensor);
        }

        /// <summary>Remove a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public IQiFuture<bool> _removeSensorAsync(string arg0_sensor)
        {
            return SourceService["_removeSensor"].CallAsync<bool>(arg0_sensor);
        }

        /// <summary>Get trajectory from local navigator.ALArray containing successively x, y and theta coordinates.</summary>
		/// <returns></returns>
        public IQiResult _getTrajectory()
        {
            return SourceService["_getTrajectory"].Call<IQiResult>();
        }

        /// <summary>Get trajectory from local navigator.ALArray containing successively x, y and theta coordinates.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getTrajectoryAsync()
        {
            return SourceService["_getTrajectory"].CallAsync<IQiResult>();
        }

        /// <summary>Set speed factor for local navigator</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setSpeedFactor(float arg0)
        {
            SourceService["_setSpeedFactor"].Call(arg0);
        }

        /// <summary>Set speed factor for local navigator</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setSpeedFactorAsync(float arg0)
        {
            return SourceService["_setSpeedFactor"].CallAsync(arg0);
        }

        /// <summary>Get obstacle Map from localnavigator. ALValue formatted as follow for each sensor :[[SensorName1 [[x1 y1] [x2 y2] [x3 y3] ...]] [SensorName2 [[x1 y1] [x2 y2] [x3 y3] ...]] ... ]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getObstacleMap(string arg0)
        {
            return SourceService["_getObstacleMap"].Call<IQiResult>(arg0);
        }

        /// <summary>Get obstacle Map from localnavigator. ALValue formatted as follow for each sensor :[[SensorName1 [[x1 y1] [x2 y2] [x3 y3] ...]] [SensorName2 [[x1 y1] [x2 y2] [x3 y3] ...]] ... ]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getObstacleMapAsync(string arg0)
        {
            return SourceService["_getObstacleMap"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSensorDebug(bool arg0)
        {
            SourceService["_enableSensorDebug"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableSensorDebugAsync(bool arg0)
        {
            return SourceService["_enableSensorDebug"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _useHeadChecking(bool arg0)
        {
            SourceService["_useHeadChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _useHeadCheckingAsync(bool arg0)
        {
            return SourceService["_useHeadChecking"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _usePathChecking(bool arg0)
        {
            SourceService["_usePathChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _usePathCheckingAsync(bool arg0)
        {
            return SourceService["_usePathChecking"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSpeedFactor(bool arg0)
        {
            SourceService["_enableSpeedFactor"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableSpeedFactorAsync(bool arg0)
        {
            return SourceService["_enableSpeedFactor"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearObstacleMap()
        {
            SourceService["_clearObstacleMap"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _clearObstacleMapAsync()
        {
            return SourceService["_clearObstacleMap"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _useClearNavigationMap(bool arg0)
        {
            SourceService["_useClearNavigationMap"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _useClearNavigationMapAsync(bool arg0)
        {
            return SourceService["_useClearNavigationMap"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearNavigationMap()
        {
            SourceService["_clearNavigationMap"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _clearNavigationMapAsync()
        {
            return SourceService["_clearNavigationMap"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getSensorSubscribers()
        {
            return SourceService["_getSensorSubscribers"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorSubscribersAsync()
        {
            return SourceService["_getSensorSubscribers"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getSensorList()
        {
            return SourceService["_getSensorList"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorListAsync()
        {
            return SourceService["_getSensorList"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getSensorListBySubscriber(string arg0)
        {
            return SourceService["_getSensorListBySubscriber"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSensorListBySubscriberAsync(string arg0)
        {
            return SourceService["_getSensorListBySubscriber"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getActiveSensorList()
        {
            return SourceService["_getActiveSensorList"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getActiveSensorListAsync()
        {
            return SourceService["_getActiveSensorList"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isSensorEnabled(string arg0)
        {
            return SourceService["_isSensorEnabled"].Call<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _isSensorEnabledAsync(string arg0)
        {
            return SourceService["_isSensorEnabled"].CallAsync<bool>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getSecureNavSensors()
        {
            return SourceService["_getSecureNavSensors"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getSecureNavSensorsAsync()
        {
            return SourceService["_getSecureNavSensors"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableLogger(bool arg0)
        {
            SourceService["_enableLogger"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableLoggerAsync(bool arg0)
        {
            return SourceService["_enableLogger"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setController(int arg0)
        {
            SourceService["_setController"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setControllerAsync(int arg0)
        {
            return SourceService["_setController"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeTree()
        {
            SourceService["_writeTree"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _writeTreeAsync()
        {
            return SourceService["_writeTree"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public bool MoveAlong(object arg0_trajectory)
        {
            return SourceService["moveAlong"].Call<bool>(arg0_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public IQiFuture<bool> MoveAlongAsync(object arg0_trajectory)
        {
            return SourceService["moveAlong"].CallAsync<bool>(arg0_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0_moveAlongScale">a scale factor</param>
		/// <param name="arg1_allowMove">true if the robot should do any move at all</param>
		/// <param name="arg2_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public bool _moveAlong(float arg0_moveAlongScale, bool arg1_allowMove, object arg2_trajectory)
        {
            return SourceService["_moveAlong"].Call<bool>(arg0_moveAlongScale, arg1_allowMove, arg2_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0_moveAlongScale">a scale factor</param>
		/// <param name="arg1_allowMove">true if the robot should do any move at all</param>
		/// <param name="arg2_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public IQiFuture<bool> _moveAlongAsync(float arg0_moveAlongScale, bool arg1_allowMove, object arg2_trajectory)
        {
            return SourceService["_moveAlong"].CallAsync<bool>(arg0_moveAlongScale, arg1_allowMove, arg2_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSafety(bool arg0)
        {
            SourceService["_enableSafety"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableSafetyAsync(bool arg0)
        {
            return SourceService["_enableSafety"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isSafetyEnabled()
        {
            return SourceService["_isSafetyEnabled"].Call<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _isSafetyEnabledAsync()
        {
            return SourceService["_isSafetyEnabled"].CallAsync<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isSafetyLoopRunning()
        {
            return SourceService["_isSafetyLoopRunning"].Call<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _isSafetyLoopRunningAsync()
        {
            return SourceService["_isSafetyLoopRunning"].CallAsync<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _wakeUpCallBack()
        {
            SourceService["_wakeUpCallBack"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _wakeUpCallBackAsync()
        {
            return SourceService["_wakeUpCallBack"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _restCallBack(string arg0, object arg1, string arg2)
        {
            SourceService["_restCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _restCallBackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_restCallBack"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getFreeZoneCenter(double arg0)
        {
            return SourceService["_getFreeZoneCenter"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getFreeZoneCenterAsync(double arg0)
        {
            return SourceService["_getFreeZoneCenter"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _getFreeZoneWithConstraints(float arg0)
        {
            return SourceService["_getFreeZoneWithConstraints"].Call<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getFreeZoneWithConstraintsAsync(float arg0)
        {
            return SourceService["_getFreeZoneWithConstraints"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _updateFreeZone()
        {
            return SourceService["_updateFreeZone"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> _updateFreeZoneAsync()
        {
            return SourceService["_updateFreeZone"].CallAsync<int>();
        }

        /// <summary> Starts a loop to update the mapping of the free space around the robot. </summary>
		/// <returns></returns>
        public void StartFreeZoneUpdate()
        {
            SourceService["startFreeZoneUpdate"].Call();
        }

        /// <summary> Starts a loop to update the mapping of the free space around the robot. </summary>
		/// <returns></returns>
        public IQiFuture StartFreeZoneUpdateAsync()
        {
            return SourceService["startFreeZoneUpdate"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startFreeZoneUpdateWithTimeout(int arg0)
        {
            SourceService["_startFreeZoneUpdateWithTimeout"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _startFreeZoneUpdateWithTimeoutAsync(int arg0)
        {
            return SourceService["_startFreeZoneUpdateWithTimeout"].CallAsync(arg0);
        }

        /// <summary>Stops and returns free zone.</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public IQiResult StopAndComputeFreeZone(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["stopAndComputeFreeZone"].Call<IQiResult>(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>Stops and returns free zone.</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public IQiFuture<IQiResult> StopAndComputeFreeZoneAsync(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["stopAndComputeFreeZone"].CallAsync<IQiResult>(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeFreeZone()
        {
            SourceService["_writeFreeZone"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _writeFreeZoneAsync()
        {
            return SourceService["_writeFreeZone"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearFreeZone()
        {
            SourceService["_clearFreeZone"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _clearFreeZoneAsync()
        {
            return SourceService["_clearFreeZone"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _getFreeZoneMap()
        {
            return SourceService["_getFreeZoneMap"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getFreeZoneMapAsync()
        {
            return SourceService["_getFreeZoneMap"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult _computeFreeZone(float arg0, float arg1)
        {
            return SourceService["_computeFreeZone"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _computeFreeZoneAsync(float arg0, float arg1)
        {
            return SourceService["_computeFreeZone"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary>Returns [errorCode, result radius[centerWorldMotionX, centerWorldMotionY]]</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public IQiResult FindFreeZone(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["findFreeZone"].Call<IQiResult>(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>Returns [errorCode, result radius[centerWorldMotionX, centerWorldMotionY]]</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public IQiFuture<IQiResult> FindFreeZoneAsync(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["findFreeZone"].CallAsync<IQiResult>(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _moveToFreeZoneCenter()
        {
            SourceService["_moveToFreeZoneCenter"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _moveToFreeZoneCenterAsync()
        {
            return SourceService["_moveToFreeZoneCenter"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _stopFreeZoneTasks()
        {
            SourceService["_stopFreeZoneTasks"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _stopFreeZoneTasksAsync()
        {
            return SourceService["_stopFreeZoneTasks"].CallAsync();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeDilatedMaps()
        {
            SourceService["_writeDilatedMaps"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _writeDilatedMapsAsync()
        {
            return SourceService["_writeDilatedMaps"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startDiagnosis(IEnumerable<string> arg0)
        {
            SourceService["_startDiagnosis"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _startDiagnosisAsync(IEnumerable<string> arg0)
        {
            return SourceService["_startDiagnosis"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiResult _stopDiagnosis()
        {
            return SourceService["_stopDiagnosis"].Call<IQiResult>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _stopDiagnosisAsync()
        {
            return SourceService["_stopDiagnosis"].CallAsync<IQiResult>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _passiveDiagnosisCallBack(string arg0, object arg1, string arg2)
        {
            SourceService["_passiveDiagnosisCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _passiveDiagnosisCallBackAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_passiveDiagnosisCallBack"].CallAsync(arg0, arg1, arg2);
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
        public void _setTimeChecking(bool arg0)
        {
            SourceService["_setTimeChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setTimeCheckingAsync(bool arg0)
        {
            return SourceService["_setTimeChecking"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onTouchChanged(string arg0, object arg1, string arg2)
        {
            SourceService["_onTouchChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _onTouchChangedAsync(string arg0, object arg1, string arg2)
        {
            return SourceService["_onTouchChanged"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setSafetyMemoryTime(uint arg0)
        {
            SourceService["_setSafetyMemoryTime"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setSafetyMemoryTimeAsync(uint arg0)
        {
            return SourceService["_setSafetyMemoryTime"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public uint _getSafetyMemoryTime()
        {
            return SourceService["_getSafetyMemoryTime"].Call<uint>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<uint> _getSafetyMemoryTimeAsync()
        {
            return SourceService["_getSafetyMemoryTime"].CallAsync<uint>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getCollisionObstacleDistance()
        {
            return SourceService["_getCollisionObstacleDistance"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getCollisionObstacleDistanceAsync()
        {
            return SourceService["_getCollisionObstacleDistance"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setCollisionObstacleDistance(float arg0)
        {
            SourceService["_setCollisionObstacleDistance"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setCollisionObstacleDistanceAsync(float arg0)
        {
            return SourceService["_setCollisionObstacleDistance"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getCollisionObstacleRadius()
        {
            return SourceService["_getCollisionObstacleRadius"].Call<float>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<float> _getCollisionObstacleRadiusAsync()
        {
            return SourceService["_getCollisionObstacleRadius"].CallAsync<float>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setCollisionObstacleRadius(float arg0)
        {
            SourceService["_setCollisionObstacleRadius"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setCollisionObstacleRadiusAsync(float arg0)
        {
            return SourceService["_setCollisionObstacleRadius"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setBlindZoneSensorMode(int arg0)
        {
            SourceService["_setBlindZoneSensorMode"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setBlindZoneSensorModeAsync(int arg0)
        {
            return SourceService["_setBlindZoneSensorMode"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _getBlindZoneSensorMode()
        {
            return SourceService["_getBlindZoneSensorMode"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> _getBlindZoneSensorModeAsync()
        {
            return SourceService["_getBlindZoneSensorMode"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public string _get3DMap()
        {
            return SourceService["_get3DMap"].Call<string>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<string> _get3DMapAsync()
        {
            return SourceService["_get3DMap"].CallAsync<string>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventMoveFailedCallback()
        {
            SourceService["_eventMoveFailedCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture _eventMoveFailedCallbackAsync()
        {
            return SourceService["_eventMoveFailedCallback"].CallAsync();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFreeZoneTimeout(int arg0)
        {
            SourceService["_setFreeZoneTimeout"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFreeZoneTimeoutAsync(int arg0)
        {
            return SourceService["_setFreeZoneTimeout"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFreeZoneThreshold(float arg0)
        {
            SourceService["_setFreeZoneThreshold"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setFreeZoneThresholdAsync(float arg0)
        {
            return SourceService["_setFreeZoneThreshold"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setObstaclesNumber(uint arg0)
        {
            SourceService["_setObstaclesNumber"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setObstaclesNumberAsync(uint arg0)
        {
            return SourceService["_setObstaclesNumber"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _getObstaclesNumber()
        {
            return SourceService["_getObstaclesNumber"].Call<int>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int> _getObstaclesNumberAsync()
        {
            return SourceService["_getObstaclesNumber"].CallAsync<int>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableTouchType(int arg0)
        {
            SourceService["_enableTouchType"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableTouchTypeAsync(int arg0)
        {
            return SourceService["_enableTouchType"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _disableTouchType(int arg0)
        {
            SourceService["_disableTouchType"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _disableTouchTypeAsync(int arg0)
        {
            return SourceService["_disableTouchType"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int[] _getEnabledTouchTypes()
        {
            return SourceService["_getEnabledTouchTypes"].Call<int[]>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<int[]> _getEnabledTouchTypesAsync()
        {
            return SourceService["_getEnabledTouchTypes"].CallAsync<int[]>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDataTooOldThresholdMs(uint arg0)
        {
            SourceService["_setDataTooOldThresholdMs"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setDataTooOldThresholdMsAsync(uint arg0)
        {
            return SourceService["_setDataTooOldThresholdMs"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public uint _getDataTooOldThresholdMs()
        {
            return SourceService["_getDataTooOldThresholdMs"].Call<uint>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<uint> _getDataTooOldThresholdMsAsync()
        {
            return SourceService["_getDataTooOldThresholdMs"].CallAsync<uint>();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDiagnosisLogEnabled(bool arg0)
        {
            SourceService["_setDiagnosisLogEnabled"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setDiagnosisLogEnabledAsync(bool arg0)
        {
            return SourceService["_setDiagnosisLogEnabled"].CallAsync(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isDiagnosisLogEnabled()
        {
            return SourceService["_isDiagnosisLogEnabled"].Call<bool>();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public IQiFuture<bool> _isDiagnosisLogEnabledAsync()
        {
            return SourceService["_isDiagnosisLogEnabled"].CallAsync<bool>();
        }

    }
}