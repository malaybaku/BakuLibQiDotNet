using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALVideoDevice, formerly called Video Input systemis architectured in order to provide every module related to vision, called vision module, a direct access to raw images from video source, or an access to images transformed in the requested format.  Extension name of the methods providing images depends on wether modules are local (dynamic library) or remote (executable).</summary>
    public class ALVideoDevice
	{
		internal ALVideoDevice(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVideoDevice CreateService(IQiSession session)
		{
			var result = new ALVideoDevice(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVideoDevice CreateUninitializedService(IQiSession session)
		{
			return new ALVideoDevice(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALVideoDevice");
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

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <param name="arg2_resolution">Resolution requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpace">Colorspace requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public string SubscribeCamera(string arg0_name, int arg1_cameraIndex, int arg2_resolution, int arg3_colorSpace, int arg4_fps)
        {
            return SourceService["subscribeCamera"].Call<string>(arg0_name, arg1_cameraIndex, arg2_resolution, arg3_colorSpace, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <param name="arg2_resolution">Resolution requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpace">Colorspace requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public IQiFuture<string> SubscribeCameraAsync(string arg0_name, int arg1_cameraIndex, int arg2_resolution, int arg3_colorSpace, int arg4_fps)
        {
            return SourceService["subscribeCamera"].CallAsync<string>(arg0_name, arg1_cameraIndex, arg2_resolution, arg3_colorSpace, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <param name="arg2_resolutions">Resolutions requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpaces">Colorspaces requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public string SubscribeCameras(string arg0_name, object arg1_cameraIndexes, object arg2_resolutions, object arg3_colorSpaces, int arg4_fps)
        {
            return SourceService["subscribeCameras"].Call<string>(arg0_name, arg1_cameraIndexes, arg2_resolutions, arg3_colorSpaces, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <param name="arg2_resolutions">Resolutions requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpaces">Colorspaces requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public IQiFuture<string> SubscribeCamerasAsync(string arg0_name, object arg1_cameraIndexes, object arg2_resolutions, object arg3_colorSpaces, int arg4_fps)
        {
            return SourceService["subscribeCameras"].CallAsync<string>(arg0_name, arg1_cameraIndexes, arg2_resolutions, arg3_colorSpaces, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_nameId">Name under which the vision module is known from ALVideoDevice.</param>
		/// <returns>True if success, false otherwise</returns>
        public bool Unsubscribe(string arg0_nameId)
        {
            return SourceService["unsubscribe"].Call<bool>(arg0_nameId);
        }

        /// <summary></summary>
		/// <param name="arg0_nameId">Name under which the vision module is known from ALVideoDevice.</param>
		/// <returns>True if success, false otherwise</returns>
        public IQiFuture<bool> UnsubscribeAsync(string arg0_nameId)
        {
            return SourceService["unsubscribe"].CallAsync<bool>(arg0_nameId);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult GetSubscribers()
        {
            return SourceService["getSubscribers"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetSubscribersAsync()
        {
            return SourceService["getSubscribers"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult GetCameraIndexes()
        {
            return SourceService["getCameraIndexes"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetCameraIndexesAsync()
        {
            return SourceService["getCameraIndexes"].CallAsync<IQiResult>();
        }

        /// <summary>Tells which camera is the default one</summary>
		/// <returns> 0: top camera - 1: bottom camera</returns>
        public int GetActiveCamera()
        {
            return SourceService["getActiveCamera"].Call<int>();
        }

        /// <summary>Tells which camera is the default one</summary>
		/// <returns> 0: top camera - 1: bottom camera</returns>
        public IQiFuture<int> GetActiveCameraAsync()
        {
            return SourceService["getActiveCamera"].CallAsync<int>();
        }

        /// <summary>Set the active camera</summary>
		/// <param name="arg0_activeCamera"> 0: top camera - 1: bottom camera</param>
		/// <returns></returns>
        public bool SetActiveCamera(int arg0_activeCamera)
        {
            return SourceService["setActiveCamera"].Call<bool>(arg0_activeCamera);
        }

        /// <summary>Set the active camera</summary>
		/// <param name="arg0_activeCamera"> 0: top camera - 1: bottom camera</param>
		/// <returns></returns>
        public IQiFuture<bool> SetActiveCameraAsync(int arg0_activeCamera)
        {
            return SourceService["setActiveCamera"].CallAsync<bool>(arg0_activeCamera);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns> 1(kOV7670): VGA camera - 2(kMT9M114): HD camera</returns>
        public int GetCameraModel(int arg0_cameraIndex)
        {
            return SourceService["getCameraModel"].Call<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns> 1(kOV7670): VGA camera - 2(kMT9M114): HD camera</returns>
        public IQiFuture<int> GetCameraModelAsync(int arg0_cameraIndex)
        {
            return SourceService["getCameraModel"].CallAsync<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>CameraTop - CameraBottom - CameraDepth</returns>
        public string GetCameraName(int arg0_cameraIndex)
        {
            return SourceService["getCameraName"].Call<string>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>CameraTop - CameraBottom - CameraDepth</returns>
        public IQiFuture<string> GetCameraNameAsync(int arg0_cameraIndex)
        {
            return SourceService["getCameraName"].CallAsync<string>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetFrameRate(int arg0_cameraIndex)
        {
            return SourceService["getFrameRate"].Call<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetFrameRateAsync(int arg0_cameraIndex)
        {
            return SourceService["getFrameRate"].CallAsync<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetResolution(int arg0_cameraIndex)
        {
            return SourceService["getResolution"].Call<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetResolutionAsync(int arg0_cameraIndex)
        {
            return SourceService["getResolution"].CallAsync<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetColorSpace(int arg0_cameraIndex)
        {
            return SourceService["getColorSpace"].Call<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetColorSpaceAsync(int arg0_cameraIndex)
        {
            return SourceService["getColorSpace"].CallAsync<int>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetHorizontalFOV(int arg0_cameraIndex)
        {
            return SourceService["getHorizontalFOV"].Call<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<float> GetHorizontalFOVAsync(int arg0_cameraIndex)
        {
            return SourceService["getHorizontalFOV"].CallAsync<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetVerticalFOV(int arg0_cameraIndex)
        {
            return SourceService["getVerticalFOV"].Call<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<float> GetVerticalFOVAsync(int arg0_cameraIndex)
        {
            return SourceService["getVerticalFOV"].CallAsync<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetParameter(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameter"].Call<int>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetParameterAsync(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameter"].CallAsync<int>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult GetParameterRange(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterRange"].Call<IQiResult>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetParameterRangeAsync(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterRange"].CallAsync<IQiResult>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult GetParameterInfo(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterInfo"].Call<IQiResult>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetParameterInfoAsync(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterInfo"].CallAsync<IQiResult>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public bool SetParameter(int arg0_cameraIndex, int arg1_parameterId, int arg2_value)
        {
            return SourceService["setParameter"].Call<bool>(arg0_cameraIndex, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetParameterAsync(int arg0_cameraIndex, int arg1_parameterId, int arg2_value)
        {
            return SourceService["setParameter"].CallAsync<bool>(arg0_cameraIndex, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public bool SetParameterToDefault(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["setParameterToDefault"].Call<bool>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetParameterToDefaultAsync(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["setParameterToDefault"].CallAsync<bool>(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool SetAllParametersToDefault(int arg0_cameraIndex)
        {
            return SourceService["setAllParametersToDefault"].Call<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetAllParametersToDefaultAsync(int arg0_cameraIndex)
        {
            return SourceService["setAllParametersToDefault"].CallAsync<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool OpenCamera(int arg0)
        {
            return SourceService["openCamera"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> OpenCameraAsync(int arg0)
        {
            return SourceService["openCamera"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool CloseCamera(int arg0)
        {
            return SourceService["closeCamera"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> CloseCameraAsync(int arg0)
        {
            return SourceService["closeCamera"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsCameraOpen(int arg0)
        {
            return SourceService["isCameraOpen"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> IsCameraOpenAsync(int arg0)
        {
            return SourceService["isCameraOpen"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool StartCamera(int arg0)
        {
            return SourceService["startCamera"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> StartCameraAsync(int arg0)
        {
            return SourceService["startCamera"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool StopCamera(int arg0)
        {
            return SourceService["stopCamera"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> StopCameraAsync(int arg0)
        {
            return SourceService["stopCamera"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsCameraStarted(int arg0)
        {
            return SourceService["isCameraStarted"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> IsCameraStartedAsync(int arg0)
        {
            return SourceService["isCameraStarted"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ResetCamera(int arg0)
        {
            return SourceService["resetCamera"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ResetCameraAsync(int arg0)
        {
            return SourceService["resetCamera"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool StartFrameGrabber(int arg0_cameraIndex)
        {
            return SourceService["startFrameGrabber"].Call<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> StartFrameGrabberAsync(int arg0_cameraIndex)
        {
            return SourceService["startFrameGrabber"].CallAsync<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool StopFrameGrabber(int arg0_cameraIndex)
        {
            return SourceService["stopFrameGrabber"].Call<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> StopFrameGrabberAsync(int arg0_cameraIndex)
        {
            return SourceService["stopFrameGrabber"].CallAsync<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool IsFrameGrabberOff(int arg0_cameraIndex)
        {
            return SourceService["isFrameGrabberOff"].Call<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> IsFrameGrabberOffAsync(int arg0_cameraIndex)
        {
            return SourceService["isFrameGrabberOff"].CallAsync<bool>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool HasDepthCamera()
        {
            return SourceService["hasDepthCamera"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> HasDepthCameraAsync()
        {
            return SourceService["hasDepthCamera"].CallAsync<bool>();
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetFrameRate(string arg0_name)
        {
            return SourceService["getFrameRate"].Call<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<int> GetFrameRateAsync(string arg0_name)
        {
            return SourceService["getFrameRate"].CallAsync<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_frameRate">Frame Rate requested.</param>
		/// <returns></returns>
        public bool SetFrameRate(string arg0_name, int arg1_frameRate)
        {
            return SourceService["setFrameRate"].Call<bool>(arg0_name, arg1_frameRate);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_frameRate">Frame Rate requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetFrameRateAsync(string arg0_name, int arg1_frameRate)
        {
            return SourceService["setFrameRate"].CallAsync<bool>(arg0_name, arg1_frameRate);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetActiveCamera(string arg0_name)
        {
            return SourceService["getActiveCamera"].Call<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<int> GetActiveCameraAsync(string arg0_name)
        {
            return SourceService["getActiveCamera"].CallAsync<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool SetActiveCamera(string arg0_name, int arg1_cameraIndex)
        {
            return SourceService["setActiveCamera"].Call<bool>(arg0_name, arg1_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetActiveCameraAsync(string arg0_name, int arg1_cameraIndex)
        {
            return SourceService["setActiveCamera"].CallAsync<bool>(arg0_name, arg1_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetResolution(string arg0_name)
        {
            return SourceService["getResolution"].Call<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<int> GetResolutionAsync(string arg0_name)
        {
            return SourceService["getResolution"].CallAsync<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolution">Resolution requested.</param>
		/// <returns></returns>
        public bool SetResolution(string arg0_name, int arg1_resolution)
        {
            return SourceService["setResolution"].Call<bool>(arg0_name, arg1_resolution);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolution">Resolution requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetResolutionAsync(string arg0_name, int arg1_resolution)
        {
            return SourceService["setResolution"].CallAsync<bool>(arg0_name, arg1_resolution);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetColorSpace(string arg0_name)
        {
            return SourceService["getColorSpace"].Call<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<int> GetColorSpaceAsync(string arg0_name)
        {
            return SourceService["getColorSpace"].CallAsync<int>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpace">Color Space requested.</param>
		/// <returns></returns>
        public bool SetColorSpace(string arg0_name, int arg1_colorSpace)
        {
            return SourceService["setColorSpace"].Call<bool>(arg0_name, arg1_colorSpace);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpace">Color Space requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetColorSpaceAsync(string arg0_name, int arg1_colorSpace)
        {
            return SourceService["setColorSpace"].CallAsync<bool>(arg0_name, arg1_colorSpace);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetCameraParameter(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameter"].Call<int>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetCameraParameterAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameter"].CallAsync<int>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult GetCameraParameterRange(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterRange"].Call<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetCameraParameterRangeAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterRange"].CallAsync<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult GetCameraParameterInfo(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterInfo"].Call<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetCameraParameterInfoAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterInfo"].CallAsync<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public bool SetCameraParameter(string arg0_name, int arg1_parameterId, int arg2_value)
        {
            return SourceService["setCameraParameter"].Call<bool>(arg0_name, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetCameraParameterAsync(string arg0_name, int arg1_parameterId, int arg2_value)
        {
            return SourceService["setCameraParameter"].CallAsync<bool>(arg0_name, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public bool SetCameraParameterToDefault(string arg0_name, int arg1_parameterId)
        {
            return SourceService["setCameraParameterToDefault"].Call<bool>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<bool> SetCameraParameterToDefaultAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["setCameraParameterToDefault"].CallAsync<bool>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public bool SetAllCameraParametersToDefault(string arg0_name)
        {
            return SourceService["setAllCameraParametersToDefault"].Call<bool>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<bool> SetAllCameraParametersToDefaultAsync(string arg0_name)
        {
            return SourceService["setAllCameraParametersToDefault"].CallAsync<bool>(arg0_name);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiResult GetDirectRawImageLocal(string arg0_name)
        {
            return SourceService["getDirectRawImageLocal"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiFuture<IQiResult> GetDirectRawImageLocalAsync(string arg0_name)
        {
            return SourceService["getDirectRawImageLocal"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiResult GetDirectRawImageRemote(string arg0_name)
        {
            return SourceService["getDirectRawImageRemote"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiFuture<IQiResult> GetDirectRawImageRemoteAsync(string arg0_name)
        {
            return SourceService["getDirectRawImageRemote"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImageLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public bool ReleaseDirectRawImage(string arg0_name)
        {
            return SourceService["releaseDirectRawImage"].Call<bool>(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImageLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiFuture<bool> ReleaseDirectRawImageAsync(string arg0_name)
        {
            return SourceService["releaseDirectRawImage"].CallAsync<bool>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiResult GetImageLocal(string arg0_name)
        {
            return SourceService["getImageLocal"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiFuture<IQiResult> GetImageLocalAsync(string arg0_name)
        {
            return SourceService["getImageLocal"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiResult GetImageRemote(string arg0_name)
        {
            return SourceService["getImageRemote"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiFuture<IQiResult> GetImageRemoteAsync(string arg0_name)
        {
            return SourceService["getImageRemote"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public bool ReleaseImage(string arg0_name)
        {
            return SourceService["releaseImage"].Call<bool>(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiFuture<bool> ReleaseImageAsync(string arg0_name)
        {
            return SourceService["releaseImage"].CallAsync<bool>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiResult GetActiveCameras(string arg0_name)
        {
            return SourceService["getActiveCameras"].Call<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetActiveCamerasAsync(string arg0_name)
        {
            return SourceService["getActiveCameras"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <returns></returns>
        public IQiResult SetActiveCameras(string arg0_name, object arg1_cameraIndexes)
        {
            return SourceService["setActiveCameras"].Call<IQiResult>(arg0_name, arg1_cameraIndexes);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SetActiveCamerasAsync(string arg0_name, object arg1_cameraIndexes)
        {
            return SourceService["setActiveCameras"].CallAsync<IQiResult>(arg0_name, arg1_cameraIndexes);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiResult GetResolutions(string arg0_name)
        {
            return SourceService["getResolutions"].Call<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetResolutionsAsync(string arg0_name)
        {
            return SourceService["getResolutions"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolutions">Resolutions requested.</param>
		/// <returns></returns>
        public IQiResult SetResolutions(string arg0_name, object arg1_resolutions)
        {
            return SourceService["setResolutions"].Call<IQiResult>(arg0_name, arg1_resolutions);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolutions">Resolutions requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SetResolutionsAsync(string arg0_name, object arg1_resolutions)
        {
            return SourceService["setResolutions"].CallAsync<IQiResult>(arg0_name, arg1_resolutions);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiResult GetColorSpaces(string arg0_name)
        {
            return SourceService["getColorSpaces"].Call<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetColorSpacesAsync(string arg0_name)
        {
            return SourceService["getColorSpaces"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpaces">Color Spaces requested.</param>
		/// <returns></returns>
        public IQiResult SetColorSpaces(string arg0_name, object arg1_colorSpaces)
        {
            return SourceService["setColorSpaces"].Call<IQiResult>(arg0_name, arg1_colorSpaces);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpaces">Color Spaces requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SetColorSpacesAsync(string arg0_name, object arg1_colorSpaces)
        {
            return SourceService["setColorSpaces"].CallAsync<IQiResult>(arg0_name, arg1_colorSpaces);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult GetCamerasParameter(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCamerasParameter"].Call<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetCamerasParameterAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCamerasParameter"].CallAsync<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_values">values requested.</param>
		/// <returns></returns>
        public IQiResult SetCamerasParameter(string arg0_name, int arg1_parameterId, object arg2_values)
        {
            return SourceService["setCamerasParameter"].Call<IQiResult>(arg0_name, arg1_parameterId, arg2_values);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_values">values requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SetCamerasParameterAsync(string arg0_name, int arg1_parameterId, object arg2_values)
        {
            return SourceService["setCamerasParameter"].CallAsync<IQiResult>(arg0_name, arg1_parameterId, arg2_values);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiResult SetCamerasParameterToDefault(string arg0_name, int arg1_parameterId)
        {
            return SourceService["setCamerasParameterToDefault"].Call<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> SetCamerasParameterToDefaultAsync(string arg0_name, int arg1_parameterId)
        {
            return SourceService["setCamerasParameterToDefault"].CallAsync<IQiResult>(arg0_name, arg1_parameterId);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiResult GetDirectRawImagesLocal(string arg0_name)
        {
            return SourceService["getDirectRawImagesLocal"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiFuture<IQiResult> GetDirectRawImagesLocalAsync(string arg0_name)
        {
            return SourceService["getDirectRawImagesLocal"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiResult GetDirectRawImagesRemote(string arg0_name)
        {
            return SourceService["getDirectRawImagesRemote"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiFuture<IQiResult> GetDirectRawImagesRemoteAsync(string arg0_name)
        {
            return SourceService["getDirectRawImagesRemote"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImagesLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiResult ReleaseDirectRawImages(string arg0_name)
        {
            return SourceService["releaseDirectRawImages"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImagesLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiFuture<IQiResult> ReleaseDirectRawImagesAsync(string arg0_name)
        {
            return SourceService["releaseDirectRawImages"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiResult GetImagesLocal(string arg0_name)
        {
            return SourceService["getImagesLocal"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public IQiFuture<IQiResult> GetImagesLocalAsync(string arg0_name)
        {
            return SourceService["getImagesLocal"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiResult GetImagesRemote(string arg0_name)
        {
            return SourceService["getImagesRemote"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public IQiFuture<IQiResult> GetImagesRemoteAsync(string arg0_name)
        {
            return SourceService["getImagesRemote"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiResult ReleaseImages(string arg0_name)
        {
            return SourceService["releaseImages"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public IQiFuture<IQiResult> ReleaseImagesAsync(string arg0_name)
        {
            return SourceService["releaseImages"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Background record of an .arv raw format video from the images processed by a vision moduleActualy it take picture each time the vision module call getDirectRawImageRemote().</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from the V.I.M.</param>
		/// <param name="arg1_path">path/name of the video to be recorded</param>
		/// <param name="arg2_totalNumber">number of images to be recorded. 0xFFFFFFFF for &quot;unlimited&quot;</param>
		/// <param name="arg3_period">one image recorded every pPeriod images</param>
		/// <returns>true if success</returns>
        public bool RecordVideo(string arg0_id, string arg1_path, int arg2_totalNumber, int arg3_period)
        {
            return SourceService["recordVideo"].Call<bool>(arg0_id, arg1_path, arg2_totalNumber, arg3_period);
        }

        /// <summary>Background record of an .arv raw format video from the images processed by a vision moduleActualy it take picture each time the vision module call getDirectRawImageRemote().</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from the V.I.M.</param>
		/// <param name="arg1_path">path/name of the video to be recorded</param>
		/// <param name="arg2_totalNumber">number of images to be recorded. 0xFFFFFFFF for &quot;unlimited&quot;</param>
		/// <param name="arg3_period">one image recorded every pPeriod images</param>
		/// <returns>true if success</returns>
        public IQiFuture<bool> RecordVideoAsync(string arg0_id, string arg1_path, int arg2_totalNumber, int arg3_period)
        {
            return SourceService["recordVideo"].CallAsync<bool>(arg0_id, arg1_path, arg2_totalNumber, arg3_period);
        }

        /// <summary>Stop writing the video sequence</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from ALVideoDevice.</param>
		/// <returns>true if success</returns>
        public bool StopVideo(string arg0_id)
        {
            return SourceService["stopVideo"].Call<bool>(arg0_id);
        }

        /// <summary>Stop writing the video sequence</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from ALVideoDevice.</param>
		/// <returns>true if success</returns>
        public IQiFuture<bool> StopVideoAsync(string arg0_id)
        {
            return SourceService["stopVideo"].CallAsync<bool>(arg0_id);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetAngularPositionFromImagePosition(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularPositionFromImagePosition"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetAngularPositionFromImagePositionAsync(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularPositionFromImagePosition"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetImagePositionFromAngularPosition(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImagePositionFromAngularPosition"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImagePositionFromAngularPositionAsync(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImagePositionFromAngularPosition"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetAngularSizeFromImageSize(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularSizeFromImageSize"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetAngularSizeFromImageSizeAsync(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularSizeFromImageSize"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetImageSizeFromAngularSize(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageSizeFromAngularSize"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImageSizeFromAngularSizeAsync(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageSizeFromAngularSize"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetImageInfoFromAngularInfo(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageInfoFromAngularInfo"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImageInfoFromAngularInfoAsync(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageInfoFromAngularInfo"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiResult GetImageInfoFromAngularInfoWithResolution(int arg0, IEnumerable<float> arg1, int arg2)
        {
            return SourceService["getImageInfoFromAngularInfoWithResolution"].Call<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImageInfoFromAngularInfoWithResolutionAsync(int arg0, IEnumerable<float> arg1, int arg2)
        {
            return SourceService["getImageInfoFromAngularInfoWithResolution"].CallAsync<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg2_height">int height of image</param>
		/// <param name="arg3_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public bool PutImage(int arg0_cameraIndex, int arg1_width, int arg2_height, object arg3_imageBuffer)
        {
            return SourceService["putImage"].Call<bool>(arg0_cameraIndex, arg1_width, arg2_height, arg3_imageBuffer);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg2_height">int height of image</param>
		/// <param name="arg3_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public IQiFuture<bool> PutImageAsync(int arg0_cameraIndex, int arg1_width, int arg2_height, object arg3_imageBuffer)
        {
            return SourceService["putImage"].CallAsync<bool>(arg0_cameraIndex, arg1_width, arg2_height, arg3_imageBuffer);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public IQiResult GetExpectedImageParameters(int arg0_cameraIndex)
        {
            return SourceService["getExpectedImageParameters"].Call<IQiResult>(arg0_cameraIndex);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public IQiFuture<IQiResult> GetExpectedImageParametersAsync(int arg0_cameraIndex)
        {
            return SourceService["getExpectedImageParameters"].CallAsync<IQiResult>(arg0_cameraIndex);
        }

        /// <summary>Get average environment luminance.</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>The average brightness luminance == (15680-Texposure)*256+AverageLuminance</returns>
        public int _getExternalBrightness(int arg0_cameraIndex)
        {
            return SourceService["_getExternalBrightness"].Call<int>(arg0_cameraIndex);
        }

        /// <summary>Get average environment luminance.</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>The average brightness luminance == (15680-Texposure)*256+AverageLuminance</returns>
        public IQiFuture<int> _getExternalBrightnessAsync(int arg0_cameraIndex)
        {
            return SourceService["_getExternalBrightness"].CallAsync<int>(arg0_cameraIndex);
        }

        /// <summary>Callback when client is disconnected</summary>
		/// <param name="arg0_eventName">The echoed event name</param>
		/// <param name="arg1_eventContents">The name of the client that has disconnected</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public void OnClientDisconnected(string arg0_eventName, object arg1_eventContents, string arg2_message)
        {
            SourceService["onClientDisconnected"].Call(arg0_eventName, arg1_eventContents, arg2_message);
        }

        /// <summary>Callback when client is disconnected</summary>
		/// <param name="arg0_eventName">The echoed event name</param>
		/// <param name="arg1_eventContents">The name of the client that has disconnected</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public IQiFuture OnClientDisconnectedAsync(string arg0_eventName, object arg1_eventContents, string arg2_message)
        {
            return SourceService["onClientDisconnected"].CallAsync(arg0_eventName, arg1_eventContents, arg2_message);
        }

        /// <summary>Register to ALVideoDevice (formerly Video Input Module/V.I.M.). When a General Video Module(G.V.M.) registers to ALVideoDevice, a buffer of the requested image format is added to the buffers list.Returns the name under which the G.V.M. is registered to ALVideoDevice (useful when two G.V.M. try to register using the same name</summary>
		/// <param name="arg0_gvmName">Name of the subscribing G.V.M.</param>
		/// <param name="arg1_resolution">Resolution requested. { 0 = kQQVGA, 1 = kQVGA, 2 = kVGA } </param>
		/// <param name="arg2_colorSpace">Colorspace requested. { 0 = kYuv, 9 = kYUV422, 10 = kYUV, 11 = kRGB, 12 = kHSY, 13 = kBGR } </param>
		/// <param name="arg3_fps">Fps (frames per second) requested. { 5, 10, 15, 30 } </param>
		/// <returns>Name under which the G.V.M. is known from ALVideoDevice, 0 if failed.</returns>
        public string Subscribe(string arg0_gvmName, int arg1_resolution, int arg2_colorSpace, int arg3_fps)
        {
            return SourceService["subscribe"].Call<string>(arg0_gvmName, arg1_resolution, arg2_colorSpace, arg3_fps);
        }

        /// <summary>Register to ALVideoDevice (formerly Video Input Module/V.I.M.). When a General Video Module(G.V.M.) registers to ALVideoDevice, a buffer of the requested image format is added to the buffers list.Returns the name under which the G.V.M. is registered to ALVideoDevice (useful when two G.V.M. try to register using the same name</summary>
		/// <param name="arg0_gvmName">Name of the subscribing G.V.M.</param>
		/// <param name="arg1_resolution">Resolution requested. { 0 = kQQVGA, 1 = kQVGA, 2 = kVGA } </param>
		/// <param name="arg2_colorSpace">Colorspace requested. { 0 = kYuv, 9 = kYUV422, 10 = kYUV, 11 = kRGB, 12 = kHSY, 13 = kBGR } </param>
		/// <param name="arg3_fps">Fps (frames per second) requested. { 5, 10, 15, 30 } </param>
		/// <returns>Name under which the G.V.M. is known from ALVideoDevice, 0 if failed.</returns>
        public IQiFuture<string> SubscribeAsync(string arg0_gvmName, int arg1_resolution, int arg2_colorSpace, int arg3_fps)
        {
            return SourceService["subscribe"].CallAsync<string>(arg0_gvmName, arg1_resolution, arg2_colorSpace, arg3_fps);
        }

        /// <summary>Used to unsubscribe all instances for a given G.V.M. (e.g. VisionModule and VisionModule_5) from ALVideoDevice.</summary>
		/// <param name="arg0_id">Root name of the G.V.M. (e.g. with the example above this will be VisionModule).</param>
		/// <returns></returns>
        public void UnsubscribeAllInstances(string arg0_id)
        {
            SourceService["unsubscribeAllInstances"].Call(arg0_id);
        }

        /// <summary>Used to unsubscribe all instances for a given G.V.M. (e.g. VisionModule and VisionModule_5) from ALVideoDevice.</summary>
		/// <param name="arg0_id">Root name of the G.V.M. (e.g. with the example above this will be VisionModule).</param>
		/// <returns></returns>
        public IQiFuture UnsubscribeAllInstancesAsync(string arg0_id)
        {
            return SourceService["unsubscribeAllInstances"].CallAsync(arg0_id);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMResolution()
        {
            return SourceService["getVIMResolution"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetVIMResolutionAsync()
        {
            return SourceService["getVIMResolution"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMColorSpace()
        {
            return SourceService["getVIMColorSpace"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetVIMColorSpaceAsync()
        {
            return SourceService["getVIMColorSpace"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMFrameRate()
        {
            return SourceService["getVIMFrameRate"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetVIMFrameRateAsync()
        {
            return SourceService["getVIMFrameRate"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMResolution(string arg0)
        {
            return SourceService["getGVMResolution"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetGVMResolutionAsync(string arg0)
        {
            return SourceService["getGVMResolution"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMColorSpace(string arg0)
        {
            return SourceService["getGVMColorSpace"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetGVMColorSpaceAsync(string arg0)
        {
            return SourceService["getGVMColorSpace"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMFrameRate(string arg0)
        {
            return SourceService["getGVMFrameRate"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetGVMFrameRateAsync(string arg0)
        {
            return SourceService["getGVMFrameRate"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetCameraModelID()
        {
            return SourceService["getCameraModelID"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetCameraModelIDAsync()
        {
            return SourceService["getCameraModelID"].CallAsync<int>();
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <returns></returns>
        public void SetParam(int arg0_pParam, int arg1_pNewValue)
        {
            SourceService["setParam"].Call(arg0_pParam, arg1_pNewValue);
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <returns></returns>
        public IQiFuture SetParamAsync(int arg0_pParam, int arg1_pNewValue)
        {
            return SourceService["setParam"].CallAsync(arg0_pParam, arg1_pNewValue);
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <param name="arg2_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public void SetParam(int arg0_pParam, int arg1_pNewValue, int arg2_pCameraIndex)
        {
            SourceService["setParam"].Call(arg0_pParam, arg1_pNewValue, arg2_pCameraIndex);
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <param name="arg2_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture SetParamAsync(int arg0_pParam, int arg1_pNewValue, int arg2_pCameraIndex)
        {
            return SourceService["setParam"].CallAsync(arg0_pParam, arg1_pNewValue, arg2_pCameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetParam(int arg0_pParam)
        {
            return SourceService["getParam"].Call<int>(arg0_pParam);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetParamAsync(int arg0_pParam)
        {
            return SourceService["getParam"].CallAsync<int>(arg0_pParam);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetParam(int arg0_pParam, int arg1_pCameraIndex)
        {
            return SourceService["getParam"].Call<int>(arg0_pParam, arg1_pCameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<int> GetParamAsync(int arg0_pParam, int arg1_pCameraIndex)
        {
            return SourceService["getParam"].CallAsync<int>(arg0_pParam, arg1_pCameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetParamDefault(int arg0)
        {
            SourceService["setParamDefault"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture SetParamDefaultAsync(int arg0)
        {
            return SourceService["setParamDefault"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetAngPosFromImgPos(IEnumerable<float> arg0)
        {
            return SourceService["getAngPosFromImgPos"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetAngPosFromImgPosAsync(IEnumerable<float> arg0)
        {
            return SourceService["getAngPosFromImgPos"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetImgPosFromAngPos(IEnumerable<float> arg0)
        {
            return SourceService["getImgPosFromAngPos"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImgPosFromAngPosAsync(IEnumerable<float> arg0)
        {
            return SourceService["getImgPosFromAngPos"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetAngSizeFromImgSize(IEnumerable<float> arg0)
        {
            return SourceService["getAngSizeFromImgSize"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetAngSizeFromImgSizeAsync(IEnumerable<float> arg0)
        {
            return SourceService["getAngSizeFromImgSize"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetImgSizeFromAngSize(IEnumerable<float> arg0)
        {
            return SourceService["getImgSizeFromAngSize"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImgSizeFromAngSizeAsync(IEnumerable<float> arg0)
        {
            return SourceService["getImgSizeFromAngSize"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetImgInfoFromAngInfo(IEnumerable<float> arg0)
        {
            return SourceService["getImgInfoFromAngInfo"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImgInfoFromAngInfoAsync(IEnumerable<float> arg0)
        {
            return SourceService["getImgInfoFromAngInfo"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetImgInfoFromAngInfoWithRes(IEnumerable<float> arg0, int arg1)
        {
            return SourceService["getImgInfoFromAngInfoWithRes"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetImgInfoFromAngInfoWithResAsync(IEnumerable<float> arg0, int arg1)
        {
            return SourceService["getImgInfoFromAngInfoWithRes"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult ResolutionToSizes(int arg0)
        {
            return SourceService["resolutionToSizes"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> ResolutionToSizesAsync(int arg0)
        {
            return SourceService["resolutionToSizes"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int SizesToResolution(int arg0, int arg1)
        {
            return SourceService["sizesToResolution"].Call<int>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<int> SizesToResolutionAsync(int arg0, int arg1)
        {
            return SourceService["sizesToResolution"].CallAsync<int>(arg0, arg1);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public IQiResult GetExpectedImageParameters()
        {
            return SourceService["getExpectedImageParameters"].Call<IQiResult>();
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public IQiFuture<IQiResult> GetExpectedImageParametersAsync()
        {
            return SourceService["getExpectedImageParameters"].CallAsync<IQiResult>();
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg1_height">int height of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <returns>true if setSize worked</returns>
        public bool SetSimCamInputSize(int arg0_width, int arg1_height)
        {
            return SourceService["setSimCamInputSize"].Call<bool>(arg0_width, arg1_height);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg1_height">int height of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <returns>true if setSize worked</returns>
        public IQiFuture<bool> SetSimCamInputSizeAsync(int arg0_width, int arg1_height)
        {
            return SourceService["setSimCamInputSize"].CallAsync<bool>(arg0_width, arg1_height);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public bool PutImage(object arg0_imageBuffer)
        {
            return SourceService["putImage"].Call<bool>(arg0_imageBuffer);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public IQiFuture<bool> PutImageAsync(object arg0_imageBuffer)
        {
            return SourceService["putImage"].CallAsync<bool>(arg0_imageBuffer);
        }

        /// <summary>Advanced method that opens and initialize video source device if it was not before.Note that the first module subscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public bool StartFrameGrabber()
        {
            return SourceService["startFrameGrabber"].Call<bool>();
        }

        /// <summary>Advanced method that opens and initialize video source device if it was not before.Note that the first module subscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public IQiFuture<bool> StartFrameGrabberAsync()
        {
            return SourceService["startFrameGrabber"].CallAsync<bool>();
        }

        /// <summary>Advanced method that close video source device.Note that the last module unsubscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public bool StopFrameGrabber()
        {
            return SourceService["stopFrameGrabber"].Call<bool>();
        }

        /// <summary>Advanced method that close video source device.Note that the last module unsubscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public IQiFuture<bool> StopFrameGrabberAsync()
        {
            return SourceService["stopFrameGrabber"].CallAsync<bool>();
        }

        /// <summary>Advanced method that asks if the framegrabber is off.</summary>
		/// <returns>true if off</returns>
        public int IsFrameGrabberOff()
        {
            return SourceService["isFrameGrabberOff"].Call<int>();
        }

        /// <summary>Advanced method that asks if the framegrabber is off.</summary>
		/// <returns>true if off</returns>
        public IQiFuture<int> IsFrameGrabberOffAsync()
        {
            return SourceService["isFrameGrabberOff"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetHorizontalAperture(int arg0_cameraIndex)
        {
            return SourceService["getHorizontalAperture"].Call<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<float> GetHorizontalApertureAsync(int arg0_cameraIndex)
        {
            return SourceService["getHorizontalAperture"].CallAsync<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetVerticalAperture(int arg0_cameraIndex)
        {
            return SourceService["getVerticalAperture"].Call<float>(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public IQiFuture<float> GetVerticalApertureAsync(int arg0_cameraIndex)
        {
            return SourceService["getVerticalAperture"].CallAsync<float>(arg0_cameraIndex);
        }

    }
}