using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALTracker module to make the robot track an object or a person with head and arms or not.</summary>
    public class ALTracker
	{
		internal ALTracker(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTracker CreateService(IQiSession session)
		{
			var result = new ALTracker(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTracker CreateUninitializedService(IQiSession session)
		{
			return new ALTracker(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALTracker");
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

        /// <summary>Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <param name="arg0_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public IQiResult GetTargetPosition(int arg0_pFrame)
        {
            return SourceService["getTargetPosition"].Call<IQiResult>(arg0_pFrame);
        }

        /// <summary>Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <param name="arg0_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public IQiFuture<IQiResult> GetTargetPositionAsync(int arg0_pFrame)
        {
            return SourceService["getTargetPosition"].CallAsync<IQiResult>(arg0_pFrame);
        }

        /// <summary>Only work with LandMarks target name. Returns the [x, y, z, wx, wy, wz] position of the robot in coordinate system setted with setMap API. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 6 floats corresponding to the robot position 6D.</returns>
        public IQiResult GetRobotPosition()
        {
            return SourceService["getRobotPosition"].Call<IQiResult>();
        }

        /// <summary>Only work with LandMarks target name. Returns the [x, y, z, wx, wy, wz] position of the robot in coordinate system setted with setMap API. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 6 floats corresponding to the robot position 6D.</returns>
        public IQiFuture<IQiResult> GetRobotPositionAsync()
        {
            return SourceService["getRobotPosition"].CallAsync<IQiResult>();
        }

        /// <summary>Return true if Tracker is running.</summary>
		/// <returns>True if Tracker is running.</returns>
        public bool IsActive()
        {
            return SourceService["isActive"].Call<bool>();
        }

        /// <summary>Return true if Tracker is running.</summary>
		/// <returns>True if Tracker is running.</returns>
        public IQiFuture<bool> IsActiveAsync()
        {
            return SourceService["isActive"].CallAsync<bool>();
        }

        /// <summary>Return true if a new target was detected.</summary>
		/// <returns>True if a new target was detected since the last getTargetPosition().</returns>
        public bool IsNewTargetDetected()
        {
            return SourceService["isNewTargetDetected"].Call<bool>();
        }

        /// <summary>Return true if a new target was detected.</summary>
		/// <returns>True if a new target was detected since the last getTargetPosition().</returns>
        public IQiFuture<bool> IsNewTargetDetectedAsync()
        {
            return SourceService["isNewTargetDetected"].CallAsync<bool>();
        }

        /// <summary>Set the robot position relative to target in Move mode.</summary>
		/// <param name="arg0_target">Set the final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</param>
		/// <returns></returns>
        public void SetRelativePosition(object arg0_target)
        {
            SourceService["setRelativePosition"].Call(arg0_target);
        }

        /// <summary>Set the robot position relative to target in Move mode.</summary>
		/// <param name="arg0_target">Set the final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</param>
		/// <returns></returns>
        public IQiFuture SetRelativePositionAsync(object arg0_target)
        {
            return SourceService["setRelativePosition"].CallAsync(arg0_target);
        }

        /// <summary>Get the robot position relative to target in Move mode.</summary>
		/// <returns>The final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</returns>
        public IQiResult GetRelativePosition()
        {
            return SourceService["getRelativePosition"].Call<IQiResult>();
        }

        /// <summary>Get the robot position relative to target in Move mode.</summary>
		/// <returns>The final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</returns>
        public IQiFuture<IQiResult> GetRelativePositionAsync()
        {
            return SourceService["getRelativePosition"].CallAsync<IQiResult>();
        }

        /// <summary>Only work with LandMarks target name. Set objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <param name="arg0_pCoord">objects coordinates.</param>
		/// <returns></returns>
        public void SetTargetCoordinates(object arg0_pCoord)
        {
            SourceService["setTargetCoordinates"].Call(arg0_pCoord);
        }

        /// <summary>Only work with LandMarks target name. Set objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <param name="arg0_pCoord">objects coordinates.</param>
		/// <returns></returns>
        public IQiFuture SetTargetCoordinatesAsync(object arg0_pCoord)
        {
            return SourceService["setTargetCoordinates"].CallAsync(arg0_pCoord);
        }

        /// <summary>Only work with LandMarks target name. Get objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <returns>objects coordinates.</returns>
        public IQiResult GetTargetCoordinates()
        {
            return SourceService["getTargetCoordinates"].Call<IQiResult>();
        }

        /// <summary>Only work with LandMarks target name. Get objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <returns>objects coordinates.</returns>
        public IQiFuture<IQiResult> GetTargetCoordinatesAsync()
        {
            return SourceService["getTargetCoordinates"].CallAsync<IQiResult>();
        }

        /// <summary>Set the tracker in the predefined mode.Could be &quot;Head&quot;, &quot;WholeBody&quot; or &quot;Move&quot;.</summary>
		/// <param name="arg0_pMode">a predefined mode.</param>
		/// <returns></returns>
        public void SetMode(string arg0_pMode)
        {
            SourceService["setMode"].Call(arg0_pMode);
        }

        /// <summary>Set the tracker in the predefined mode.Could be &quot;Head&quot;, &quot;WholeBody&quot; or &quot;Move&quot;.</summary>
		/// <param name="arg0_pMode">a predefined mode.</param>
		/// <returns></returns>
        public IQiFuture SetModeAsync(string arg0_pMode)
        {
            return SourceService["setMode"].CallAsync(arg0_pMode);
        }

        /// <summary>Get the tracker current mode.</summary>
		/// <returns>The current tracker mode.</returns>
        public string GetMode()
        {
            return SourceService["getMode"].Call<string>();
        }

        /// <summary>Get the tracker current mode.</summary>
		/// <returns>The current tracker mode.</returns>
        public IQiFuture<string> GetModeAsync()
        {
            return SourceService["getMode"].CallAsync<string>();
        }

        /// <summary>Get the list of predefined mode.</summary>
		/// <returns>List of predefined mode.</returns>
        public string[] GetAvailableModes()
        {
            return SourceService["getAvailableModes"].Call<string[]>();
        }

        /// <summary>Get the list of predefined mode.</summary>
		/// <returns>List of predefined mode.</returns>
        public IQiFuture<string[]> GetAvailableModesAsync()
        {
            return SourceService["getAvailableModes"].CallAsync<string[]>();
        }

        /// <summary>Enables/disables the target search process. Target search process occurs only when the target is lost.</summary>
		/// <param name="arg0_pSearch">If true and if the target is lost, the robot moves the head in order to find the target. If false and if the target is lost the robot does not move.</param>
		/// <returns></returns>
        public void ToggleSearch(bool arg0_pSearch)
        {
            SourceService["toggleSearch"].Call(arg0_pSearch);
        }

        /// <summary>Enables/disables the target search process. Target search process occurs only when the target is lost.</summary>
		/// <param name="arg0_pSearch">If true and if the target is lost, the robot moves the head in order to find the target. If false and if the target is lost the robot does not move.</param>
		/// <returns></returns>
        public IQiFuture ToggleSearchAsync(bool arg0_pSearch)
        {
            return SourceService["toggleSearch"].CallAsync(arg0_pSearch);
        }

        /// <summary>Set search process fraction max speed.</summary>
		/// <param name="arg0_pFractionMaxSpeed">a fraction max speed.</param>
		/// <returns></returns>
        public void SetSearchFractionMaxSpeed(float arg0_pFractionMaxSpeed)
        {
            SourceService["setSearchFractionMaxSpeed"].Call(arg0_pFractionMaxSpeed);
        }

        /// <summary>Set search process fraction max speed.</summary>
		/// <param name="arg0_pFractionMaxSpeed">a fraction max speed.</param>
		/// <returns></returns>
        public IQiFuture SetSearchFractionMaxSpeedAsync(float arg0_pFractionMaxSpeed)
        {
            return SourceService["setSearchFractionMaxSpeed"].CallAsync(arg0_pFractionMaxSpeed);
        }

        /// <summary>Get search process fraction max speed.</summary>
		/// <returns>a fraction max speed.</returns>
        public float GetSearchFractionMaxSpeed()
        {
            return SourceService["getSearchFractionMaxSpeed"].Call<float>();
        }

        /// <summary>Get search process fraction max speed.</summary>
		/// <returns>a fraction max speed.</returns>
        public IQiFuture<float> GetSearchFractionMaxSpeedAsync()
        {
            return SourceService["getSearchFractionMaxSpeed"].CallAsync<float>();
        }

        /// <summary>Return true if the target search process is enabled.</summary>
		/// <returns>If true the target search process is enabled.</returns>
        public bool IsSearchEnabled()
        {
            return SourceService["isSearchEnabled"].Call<bool>();
        }

        /// <summary>Return true if the target search process is enabled.</summary>
		/// <returns>If true the target search process is enabled.</returns>
        public IQiFuture<bool> IsSearchEnabledAsync()
        {
            return SourceService["isSearchEnabled"].CallAsync<bool>();
        }

        /// <summary>Stop the tracker.</summary>
		/// <returns></returns>
        public void StopTracker()
        {
            SourceService["stopTracker"].Call();
        }

        /// <summary>Stop the tracker.</summary>
		/// <returns></returns>
        public IQiFuture StopTrackerAsync()
        {
            return SourceService["stopTracker"].CallAsync();
        }

        /// <summary>Return true if the target was lost.</summary>
		/// <returns>True if the target was lost.</returns>
        public bool IsTargetLost()
        {
            return SourceService["isTargetLost"].Call<bool>();
        }

        /// <summary>Return true if the target was lost.</summary>
		/// <returns>True if the target was lost.</returns>
        public IQiFuture<bool> IsTargetLostAsync()
        {
            return SourceService["isTargetLost"].CallAsync<bool>();
        }

        /// <summary>Set the predefided target to track and start the tracking process if not started.</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void Track(string arg0_pTarget)
        {
            SourceService["track"].Call(arg0_pTarget);
        }

        /// <summary>Set the predefided target to track and start the tracking process if not started.</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public IQiFuture TrackAsync(string arg0_pTarget)
        {
            return SourceService["track"].CallAsync(arg0_pTarget);
        }

        /// <summary>Track event and start the tracking process if not started.</summary>
		/// <param name="arg0_pEventName">a event name to track.</param>
		/// <returns></returns>
        public void TrackEvent(string arg0_pEventName)
        {
            SourceService["trackEvent"].Call(arg0_pEventName);
        }

        /// <summary>Track event and start the tracking process if not started.</summary>
		/// <param name="arg0_pEventName">a event name to track.</param>
		/// <returns></returns>
        public IQiFuture TrackEventAsync(string arg0_pEventName)
        {
            return SourceService["trackEvent"].CallAsync(arg0_pEventName);
        }

        /// <summary>Register a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public void RegisterTarget(string arg0_pTarget, object arg1_pParams)
        {
            SourceService["registerTarget"].Call(arg0_pTarget, arg1_pParams);
        }

        /// <summary>Register a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public IQiFuture RegisterTargetAsync(string arg0_pTarget, object arg1_pParams)
        {
            return SourceService["registerTarget"].CallAsync(arg0_pTarget, arg1_pParams);
        }

        /// <summary>Set a period for the corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pPeriod">a period in milliseconds</param>
		/// <returns></returns>
        public void SetExtractorPeriod(string arg0_pTarget, int arg1_pPeriod)
        {
            SourceService["setExtractorPeriod"].Call(arg0_pTarget, arg1_pPeriod);
        }

        /// <summary>Set a period for the corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pPeriod">a period in milliseconds</param>
		/// <returns></returns>
        public IQiFuture SetExtractorPeriodAsync(string arg0_pTarget, int arg1_pPeriod)
        {
            return SourceService["setExtractorPeriod"].CallAsync(arg0_pTarget, arg1_pPeriod);
        }

        /// <summary>Get the period of corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns>a period in milliseconds</returns>
        public int GetExtractorPeriod(string arg0_pTarget)
        {
            return SourceService["getExtractorPeriod"].Call<int>(arg0_pTarget);
        }

        /// <summary>Get the period of corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns>a period in milliseconds</returns>
        public IQiFuture<int> GetExtractorPeriodAsync(string arg0_pTarget)
        {
            return SourceService["getExtractorPeriod"].CallAsync<int>(arg0_pTarget);
        }

        /// <summary>Unregister target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void UnregisterTarget(string arg0_pTarget)
        {
            SourceService["unregisterTarget"].Call(arg0_pTarget);
        }

        /// <summary>Unregister target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public IQiFuture UnregisterTargetAsync(string arg0_pTarget)
        {
            return SourceService["unregisterTarget"].CallAsync(arg0_pTarget);
        }

        /// <summary>Unregister a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void UnregisterTargets(IEnumerable<string> arg0_pTarget)
        {
            SourceService["unregisterTargets"].Call(arg0_pTarget);
        }

        /// <summary>Unregister a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public IQiFuture UnregisterTargetsAsync(IEnumerable<string> arg0_pTarget)
        {
            return SourceService["unregisterTargets"].CallAsync(arg0_pTarget);
        }

        /// <summary>Unregister all targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public void UnregisterAllTargets()
        {
            SourceService["unregisterAllTargets"].Call();
        }

        /// <summary>Unregister all targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public IQiFuture UnregisterAllTargetsAsync()
        {
            return SourceService["unregisterAllTargets"].CallAsync();
        }

        /// <summary>Return active target name.</summary>
		/// <returns>Tracked target name.</returns>
        public string GetActiveTarget()
        {
            return SourceService["getActiveTarget"].Call<string>();
        }

        /// <summary>Return active target name.</summary>
		/// <returns>Tracked target name.</returns>
        public IQiFuture<string> GetActiveTargetAsync()
        {
            return SourceService["getActiveTarget"].CallAsync<string>();
        }

        /// <summary>Return a list of supported targets names.</summary>
		/// <returns>Supported targets names.</returns>
        public string[] GetSupportedTargets()
        {
            return SourceService["getSupportedTargets"].Call<string[]>();
        }

        /// <summary>Return a list of supported targets names.</summary>
		/// <returns>Supported targets names.</returns>
        public IQiFuture<string[]> GetSupportedTargetsAsync()
        {
            return SourceService["getSupportedTargets"].CallAsync<string[]>();
        }

        /// <summary>Return a list of registered targets names.</summary>
		/// <returns>Registered targets names.</returns>
        public string[] GetRegisteredTargets()
        {
            return SourceService["getRegisteredTargets"].Call<string[]>();
        }

        /// <summary>Return a list of registered targets names.</summary>
		/// <returns>Registered targets names.</returns>
        public IQiFuture<string[]> GetRegisteredTargetsAsync()
        {
            return SourceService["getRegisteredTargets"].CallAsync<string[]>();
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg3_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void LookAt(IEnumerable<float> arg0_pPosition, int arg1_pFrame, float arg2_pFractionMaxSpeed, bool arg3_pUseWholeBody)
        {
            SourceService["lookAt"].Call(arg0_pPosition, arg1_pFrame, arg2_pFractionMaxSpeed, arg3_pUseWholeBody);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg3_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public IQiFuture LookAtAsync(IEnumerable<float> arg0_pPosition, int arg1_pFrame, float arg2_pFractionMaxSpeed, bool arg3_pUseWholeBody)
        {
            return SourceService["lookAt"].CallAsync(arg0_pPosition, arg1_pFrame, arg2_pFractionMaxSpeed, arg3_pUseWholeBody);
        }

        /// <summary>Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public void PointAt(string arg0_pEffector, IEnumerable<float> arg1_pPosition, int arg2_pFrame, float arg3_pFractionMaxSpeed)
        {
            SourceService["pointAt"].Call(arg0_pEffector, arg1_pPosition, arg2_pFrame, arg3_pFractionMaxSpeed);
        }

        /// <summary>Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public IQiFuture PointAtAsync(string arg0_pEffector, IEnumerable<float> arg1_pPosition, int arg2_pFrame, float arg3_pFractionMaxSpeed)
        {
            return SourceService["pointAt"].CallAsync(arg0_pEffector, arg1_pPosition, arg2_pFrame, arg3_pFractionMaxSpeed);
        }

        /// <summary>Get the config for move modes.</summary>
		/// <returns>ALMotion GaitConfig</returns>
        public IQiResult GetMoveConfig()
        {
            return SourceService["getMoveConfig"].Call<IQiResult>();
        }

        /// <summary>Get the config for move modes.</summary>
		/// <returns>ALMotion GaitConfig</returns>
        public IQiFuture<IQiResult> GetMoveConfigAsync()
        {
            return SourceService["getMoveConfig"].CallAsync<IQiResult>();
        }

        /// <summary>set a config for move modes.</summary>
		/// <param name="arg0_config">ALMotion GaitConfig</param>
		/// <returns></returns>
        public void SetMoveConfig(object arg0_config)
        {
            SourceService["setMoveConfig"].Call(arg0_config);
        }

        /// <summary>set a config for move modes.</summary>
		/// <param name="arg0_config">ALMotion GaitConfig</param>
		/// <returns></returns>
        public IQiFuture SetMoveConfigAsync(object arg0_config)
        {
            return SourceService["setMoveConfig"].CallAsync(arg0_config);
        }

        /// <summary>get the timeout parameter for target lost.</summary>
		/// <returns>time in milliseconds.</returns>
        public int GetTimeOut()
        {
            return SourceService["getTimeOut"].Call<int>();
        }

        /// <summary>get the timeout parameter for target lost.</summary>
		/// <returns>time in milliseconds.</returns>
        public IQiFuture<int> GetTimeOutAsync()
        {
            return SourceService["getTimeOut"].CallAsync<int>();
        }

        /// <summary>set the timeout parameter for target lost.</summary>
		/// <param name="arg0_pTimeMs">time in milliseconds.</param>
		/// <returns></returns>
        public void SetTimeOut(int arg0_pTimeMs)
        {
            SourceService["setTimeOut"].Call(arg0_pTimeMs);
        }

        /// <summary>set the timeout parameter for target lost.</summary>
		/// <param name="arg0_pTimeMs">time in milliseconds.</param>
		/// <returns></returns>
        public IQiFuture SetTimeOutAsync(int arg0_pTimeMs)
        {
            return SourceService["setTimeOut"].CallAsync(arg0_pTimeMs);
        }

        /// <summary>get the maximum distance for target detection in meter.</summary>
		/// <returns>The maximum distance for target detection in meter.</returns>
        public float GetMaximumDistanceDetection()
        {
            return SourceService["getMaximumDistanceDetection"].Call<float>();
        }

        /// <summary>get the maximum distance for target detection in meter.</summary>
		/// <returns>The maximum distance for target detection in meter.</returns>
        public IQiFuture<float> GetMaximumDistanceDetectionAsync()
        {
            return SourceService["getMaximumDistanceDetection"].CallAsync<float>();
        }

        /// <summary>set the maximum target detection distance in meter.</summary>
		/// <param name="arg0_pMaxDistance">The maximum distance for target detection in meter.</param>
		/// <returns></returns>
        public void SetMaximumDistanceDetection(float arg0_pMaxDistance)
        {
            SourceService["setMaximumDistanceDetection"].Call(arg0_pMaxDistance);
        }

        /// <summary>set the maximum target detection distance in meter.</summary>
		/// <param name="arg0_pMaxDistance">The maximum distance for target detection in meter.</param>
		/// <returns></returns>
        public IQiFuture SetMaximumDistanceDetectionAsync(float arg0_pMaxDistance)
        {
            return SourceService["setMaximumDistanceDetection"].CallAsync(arg0_pMaxDistance);
        }

        /// <summary>Get active effector.</summary>
		/// <returns>Active effector name. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </returns>
        public string GetEffector()
        {
            return SourceService["getEffector"].Call<string>();
        }

        /// <summary>Get active effector.</summary>
		/// <returns>Active effector name. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </returns>
        public IQiFuture<string> GetEffectorAsync()
        {
            return SourceService["getEffector"].CallAsync<string>();
        }

        /// <summary>Set an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </param>
		/// <returns></returns>
        public void SetEffector(string arg0_pEffector)
        {
            SourceService["setEffector"].Call(arg0_pEffector);
        }

        /// <summary>Set an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </param>
		/// <returns></returns>
        public IQiFuture SetEffectorAsync(string arg0_pEffector)
        {
            return SourceService["setEffector"].CallAsync(arg0_pEffector);
        }

        /// <summary>Initialize tracker parameters with default values.</summary>
		/// <returns></returns>
        public void Initialize()
        {
            SourceService["initialize"].Call();
        }

        /// <summary>Initialize tracker parameters with default values.</summary>
		/// <returns></returns>
        public IQiFuture InitializeAsync()
        {
            return SourceService["initialize"].CallAsync();
        }

        /// <summary>Set the maximum velocity for tracking.</summary>
		/// <param name="arg0_pVelocity">The maximum velocity in rad.s-1 .</param>
		/// <returns></returns>
        public void SetMaximumVelocity(float arg0_pVelocity)
        {
            SourceService["setMaximumVelocity"].Call(arg0_pVelocity);
        }

        /// <summary>Set the maximum velocity for tracking.</summary>
		/// <param name="arg0_pVelocity">The maximum velocity in rad.s-1 .</param>
		/// <returns></returns>
        public IQiFuture SetMaximumVelocityAsync(float arg0_pVelocity)
        {
            return SourceService["setMaximumVelocity"].CallAsync(arg0_pVelocity);
        }

        /// <summary>Get the maximum velocity for tracking.</summary>
		/// <returns>The maximum velocity in rad.s-1 .</returns>
        public float GetMaximumVelocity()
        {
            return SourceService["getMaximumVelocity"].Call<float>();
        }

        /// <summary>Get the maximum velocity for tracking.</summary>
		/// <returns>The maximum velocity in rad.s-1 .</returns>
        public IQiFuture<float> GetMaximumVelocityAsync()
        {
            return SourceService["getMaximumVelocity"].CallAsync<float>();
        }

        /// <summary>Set the maximum acceleration for tracking.</summary>
		/// <param name="arg0_pAcceleration">The maximum acceleration in rad.s-2 .</param>
		/// <returns></returns>
        public void SetMaximumAcceleration(float arg0_pAcceleration)
        {
            SourceService["setMaximumAcceleration"].Call(arg0_pAcceleration);
        }

        /// <summary>Set the maximum acceleration for tracking.</summary>
		/// <param name="arg0_pAcceleration">The maximum acceleration in rad.s-2 .</param>
		/// <returns></returns>
        public IQiFuture SetMaximumAccelerationAsync(float arg0_pAcceleration)
        {
            return SourceService["setMaximumAcceleration"].CallAsync(arg0_pAcceleration);
        }

        /// <summary>Get the maximum acceleration for tracking.</summary>
		/// <returns>The maximum acceleration in rad.s-2 .</returns>
        public float GetMaximumAcceleration()
        {
            return SourceService["getMaximumAcceleration"].Call<float>();
        }

        /// <summary>Get the maximum acceleration for tracking.</summary>
		/// <returns>The maximum acceleration in rad.s-2 .</returns>
        public IQiFuture<float> GetMaximumAccelerationAsync()
        {
            return SourceService["getMaximumAcceleration"].CallAsync<float>();
        }

        /// <summary>DEPRECATED. Use lookAt with frame instead. Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void LookAt(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody)
        {
            SourceService["lookAt"].Call(arg0_pPosition, arg1_pFractionMaxSpeed, arg2_pUseWholeBody);
        }

        /// <summary>DEPRECATED. Use lookAt with frame instead. Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public IQiFuture LookAtAsync(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody)
        {
            return SourceService["lookAt"].CallAsync(arg0_pPosition, arg1_pFractionMaxSpeed, arg2_pUseWholeBody);
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public void PointAt(string arg0_pEffector, IEnumerable<float> arg1_pPosition, float arg2_pFractionMaxSpeed)
        {
            SourceService["pointAt"].Call(arg0_pEffector, arg1_pPosition, arg2_pFractionMaxSpeed);
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public IQiFuture PointAtAsync(string arg0_pEffector, IEnumerable<float> arg1_pPosition, float arg2_pFractionMaxSpeed)
        {
            return SourceService["pointAt"].CallAsync(arg0_pEffector, arg1_pPosition, arg2_pFractionMaxSpeed);
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public IQiResult GetTargetPosition()
        {
            return SourceService["getTargetPosition"].Call<IQiResult>();
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public IQiFuture<IQiResult> GetTargetPositionAsync()
        {
            return SourceService["getTargetPosition"].CallAsync<IQiResult>();
        }

        /// <summary>DEPRECATED. Use getSupportedTargets() instead. Return a list of targets names.</summary>
		/// <returns>Valid targets names.</returns>
        public string[] GetTargetNames()
        {
            return SourceService["getTargetNames"].Call<string[]>();
        }

        /// <summary>DEPRECATED. Use getSupportedTargets() instead. Return a list of targets names.</summary>
		/// <returns>Valid targets names.</returns>
        public IQiFuture<string[]> GetTargetNamesAsync()
        {
            return SourceService["getTargetNames"].CallAsync<string[]>();
        }

        /// <summary>DEPRECATED. Use getRegisteredTargets() instead. Return a list of managed targets names.</summary>
		/// <returns>Managed targets names.</returns>
        public string[] GetManagedTargets()
        {
            return SourceService["getManagedTargets"].Call<string[]>();
        }

        /// <summary>DEPRECATED. Use getRegisteredTargets() instead. Return a list of managed targets names.</summary>
		/// <returns>Managed targets names.</returns>
        public IQiFuture<string[]> GetManagedTargetsAsync()
        {
            return SourceService["getManagedTargets"].CallAsync<string[]>();
        }

        /// <summary>DEPRECATED. Use registerTarget() instead. Add a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public void AddTarget(string arg0_pTarget, object arg1_pParams)
        {
            SourceService["addTarget"].Call(arg0_pTarget, arg1_pParams);
        }

        /// <summary>DEPRECATED. Use registerTarget() instead. Add a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public IQiFuture AddTargetAsync(string arg0_pTarget, object arg1_pParams)
        {
            return SourceService["addTarget"].CallAsync(arg0_pTarget, arg1_pParams);
        }

        /// <summary>DEPRECATED. Use unregisterTarget() instead. Remove target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void RemoveTarget(string arg0_pTarget)
        {
            SourceService["removeTarget"].Call(arg0_pTarget);
        }

        /// <summary>DEPRECATED. Use unregisterTarget() instead. Remove target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public IQiFuture RemoveTargetAsync(string arg0_pTarget)
        {
            return SourceService["removeTarget"].CallAsync(arg0_pTarget);
        }

        /// <summary>DEPRECATED. Use unregisterTargets() instead. Remove a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void RemoveTargets(IEnumerable<string> arg0_pTarget)
        {
            SourceService["removeTargets"].Call(arg0_pTarget);
        }

        /// <summary>DEPRECATED. Use unregisterTargets() instead. Remove a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public IQiFuture RemoveTargetsAsync(IEnumerable<string> arg0_pTarget)
        {
            return SourceService["removeTargets"].CallAsync(arg0_pTarget);
        }

        /// <summary>DEPRECATED. Use unregisterAllTargets() instead. Remove all managed targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public void RemoveAllTargets()
        {
            SourceService["removeAllTargets"].Call();
        }

        /// <summary>DEPRECATED. Use unregisterAllTargets() instead. Remove all managed targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public IQiFuture RemoveAllTargetsAsync()
        {
            return SourceService["removeAllTargets"].CallAsync();
        }

        /// <summary>DEPRECATED. Use setEffector instead. Add an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public void AddEffector(string arg0_pEffector)
        {
            SourceService["addEffector"].Call(arg0_pEffector);
        }

        /// <summary>DEPRECATED. Use setEffector instead. Add an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public IQiFuture AddEffectorAsync(string arg0_pEffector)
        {
            return SourceService["addEffector"].CallAsync(arg0_pEffector);
        }

        /// <summary>DEPRECATED. Use setEffector(&quot;None&quot;) instead. Remove an end-effector from tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public void RemoveEffector(string arg0_pEffector)
        {
            SourceService["removeEffector"].Call(arg0_pEffector);
        }

        /// <summary>DEPRECATED. Use setEffector(&quot;None&quot;) instead. Remove an end-effector from tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public IQiFuture RemoveEffectorAsync(string arg0_pEffector)
        {
            return SourceService["removeEffector"].CallAsync(arg0_pEffector);
        }

        /// <summary>Pause the tracking process.</summary>
		/// <returns></returns>
        public void _pause()
        {
            SourceService["_pause"].Call();
        }

        /// <summary>Pause the tracking process.</summary>
		/// <returns></returns>
        public IQiFuture _pauseAsync()
        {
            return SourceService["_pause"].CallAsync();
        }

        /// <summary>Restart the tracking process.</summary>
		/// <returns></returns>
        public void _restart()
        {
            SourceService["_restart"].Call();
        }

        /// <summary>Restart the tracking process.</summary>
		/// <returns></returns>
        public IQiFuture _restartAsync()
        {
            return SourceService["_restart"].CallAsync();
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void _setTrackerConfig(object arg0_config)
        {
            SourceService["_setTrackerConfig"].Call(arg0_config);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public IQiFuture _setTrackerConfigAsync(object arg0_config)
        {
            return SourceService["_setTrackerConfig"].CallAsync(arg0_config);
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>map contraining all the information.</returns>
        public IQiResult _getTrackerConfig()
        {
            return SourceService["_getTrackerConfig"].Call<IQiResult>();
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>map contraining all the information.</returns>
        public IQiFuture<IQiResult> _getTrackerConfigAsync()
        {
            return SourceService["_getTrackerConfig"].CallAsync<IQiResult>();
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>string contraining all the information.</returns>
        public string _getTrackerConfigStr()
        {
            return SourceService["_getTrackerConfigStr"].Call<string>();
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>string contraining all the information.</returns>
        public IQiFuture<string> _getTrackerConfigStrAsync()
        {
            return SourceService["_getTrackerConfigStr"].CallAsync<string>();
        }

        /// <summary>Lost event callback.</summary>
		/// <returns></returns>
        public void _lostEvent()
        {
            SourceService["_lostEvent"].Call();
        }

        /// <summary>Lost event callback.</summary>
		/// <returns></returns>
        public IQiFuture _lostEventAsync()
        {
            return SourceService["_lostEvent"].CallAsync();
        }

        /// <summary>Detected event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _detectedEvent(string arg0, object arg1)
        {
            SourceService["_detectedEvent"].Call(arg0, arg1);
        }

        /// <summary>Detected event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture _detectedEventAsync(string arg0, object arg1)
        {
            return SourceService["_detectedEvent"].CallAsync(arg0, arg1);
        }

        /// <summary>Active debug in choregraphe 3D view.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDebugInView3D(bool arg0)
        {
            SourceService["_setDebugInView3D"].Call(arg0);
        }

        /// <summary>Active debug in choregraphe 3D view.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setDebugInView3DAsync(bool arg0)
        {
            return SourceService["_setDebugInView3D"].CallAsync(arg0);
        }

        /// <summary>debug event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _debugCallbackEvent(string arg0, object arg1)
        {
            SourceService["_debugCallbackEvent"].Call(arg0, arg1);
        }

        /// <summary>debug event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture _debugCallbackEventAsync(string arg0, object arg1)
        {
            return SourceService["_debugCallbackEvent"].CallAsync(arg0, arg1);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO.x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use.Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <param name="arg3_pUseMove">If true, use move to look at target behind.</param>
		/// <returns></returns>
        public void _lookAtWithMove(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody, bool arg3_pUseMove)
        {
            SourceService["_lookAtWithMove"].Call(arg0_pPosition, arg1_pFractionMaxSpeed, arg2_pUseWholeBody, arg3_pUseMove);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO.x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use.Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <param name="arg3_pUseMove">If true, use move to look at target behind.</param>
		/// <returns></returns>
        public IQiFuture _lookAtWithMoveAsync(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody, bool arg3_pUseMove)
        {
            return SourceService["_lookAtWithMove"].CallAsync(arg0_pPosition, arg1_pFractionMaxSpeed, arg2_pUseWholeBody, arg3_pUseMove);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pEffectorId">effector id {Middle of eyes = 0, Camera Top = 1, Camera Bottom = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg4_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void _lookAtWithEffector(IEnumerable<float> arg0_pPosition, int arg1_pFrame, int arg2_pEffectorId, float arg3_pFractionMaxSpeed, bool arg4_pUseWholeBody)
        {
            SourceService["_lookAtWithEffector"].Call(arg0_pPosition, arg1_pFrame, arg2_pEffectorId, arg3_pFractionMaxSpeed, arg4_pUseWholeBody);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pEffectorId">effector id {Middle of eyes = 0, Camera Top = 1, Camera Bottom = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg4_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public IQiFuture _lookAtWithEffectorAsync(IEnumerable<float> arg0_pPosition, int arg1_pFrame, int arg2_pEffectorId, float arg3_pFractionMaxSpeed, bool arg4_pUseWholeBody)
        {
            return SourceService["_lookAtWithEffector"].CallAsync(arg0_pPosition, arg1_pFrame, arg2_pEffectorId, arg3_pFractionMaxSpeed, arg4_pUseWholeBody);
        }

        /// <summary>Stop current look at</summary>
		/// <returns></returns>
        public void _stopLookAt()
        {
            SourceService["_stopLookAt"].Call();
        }

        /// <summary>Stop current look at</summary>
		/// <returns></returns>
        public IQiFuture _stopLookAtAsync()
        {
            return SourceService["_stopLookAt"].CallAsync();
        }

        /// <summary>Stop current point at</summary>
		/// <returns></returns>
        public void _stopPointAt()
        {
            SourceService["_stopPointAt"].Call();
        }

        /// <summary>Stop current point at</summary>
		/// <returns></returns>
        public IQiFuture _stopPointAtAsync()
        {
            return SourceService["_stopPointAt"].CallAsync();
        }

        /// <summary>Enable whole body look at during search</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _searcherSetUseWholeBodyLookAt(bool arg0)
        {
            SourceService["_searcherSetUseWholeBodyLookAt"].Call(arg0);
        }

        /// <summary>Enable whole body look at during search</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _searcherSetUseWholeBodyLookAtAsync(bool arg0)
        {
            return SourceService["_searcherSetUseWholeBodyLookAt"].CallAsync(arg0);
        }

        /// <summary>Set a specific event for move.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setMoveEvent(string arg0)
        {
            SourceService["_setMoveEvent"].Call(arg0);
        }

        /// <summary>Set a specific event for move.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setMoveEventAsync(string arg0)
        {
            return SourceService["_setMoveEvent"].CallAsync(arg0);
        }

        /// <summary>Set move hysteresis.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setMoveHysteresis(IEnumerable<float> arg0)
        {
            SourceService["_setMoveHysteresis"].Call(arg0);
        }

        /// <summary>Set move hysteresis.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setMoveHysteresisAsync(IEnumerable<float> arg0)
        {
            return SourceService["_setMoveHysteresis"].CallAsync(arg0);
        }

        /// <summary>Get move hysteresis.</summary>
		/// <returns></returns>
        public IQiResult _getMoveHysteresis()
        {
            return SourceService["_getMoveHysteresis"].Call<IQiResult>();
        }

        /// <summary>Get move hysteresis.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _getMoveHysteresisAsync()
        {
            return SourceService["_getMoveHysteresis"].CallAsync<IQiResult>();
        }

    }
}