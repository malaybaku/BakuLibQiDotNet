using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module provides methods to record videos and store them on disk.</summary>
    public class ALVideoRecorder
	{
		internal ALVideoRecorder(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVideoRecorder CreateService(IQiSession session)
		{
			var result = new ALVideoRecorder(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVideoRecorder CreateUninitializedService(IQiSession session)
		{
			return new ALVideoRecorder(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALVideoRecorder");
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

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <returns></returns>
        public void StartRecording(string arg0_folderPath, string arg1_fileName)
        {
            SourceService["startRecording"].Call(arg0_folderPath, arg1_fileName);
        }

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <returns></returns>
        public IQiFuture StartRecordingAsync(string arg0_folderPath, string arg1_fileName)
        {
            return SourceService["startRecording"].CallAsync(arg0_folderPath, arg1_fileName);
        }

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <param name="arg2_overwrite">If false and the filename already exists, an exception is thrown.</param>
		/// <returns></returns>
        public void StartRecording(string arg0_folderPath, string arg1_fileName, bool arg2_overwrite)
        {
            SourceService["startRecording"].Call(arg0_folderPath, arg1_fileName, arg2_overwrite);
        }

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <param name="arg2_overwrite">If false and the filename already exists, an exception is thrown.</param>
		/// <returns></returns>
        public IQiFuture StartRecordingAsync(string arg0_folderPath, string arg1_fileName, bool arg2_overwrite)
        {
            return SourceService["startRecording"].CallAsync(arg0_folderPath, arg1_fileName, arg2_overwrite);
        }

        /// <summary>Stops a video record that was launched with startRecording(). The function returns the number of frames that were recorded, as well as the video absolute file name.</summary>
		/// <returns>Array of two elements [numRecordedFrames, recordAbsolutePath]</returns>
        public IQiResult StopRecording()
        {
            return SourceService["stopRecording"].Call<IQiResult>();
        }

        /// <summary>Stops a video record that was launched with startRecording(). The function returns the number of frames that were recorded, as well as the video absolute file name.</summary>
		/// <returns>Array of two elements [numRecordedFrames, recordAbsolutePath]</returns>
        public IQiFuture<IQiResult> StopRecordingAsync()
        {
            return SourceService["stopRecording"].CallAsync<IQiResult>();
        }

        /// <summary>Are we currently recording a video</summary>
		/// <returns>True/False</returns>
        public bool IsRecording()
        {
            return SourceService["isRecording"].Call<bool>();
        }

        /// <summary>Are we currently recording a video</summary>
		/// <returns>True/False</returns>
        public IQiFuture<bool> IsRecordingAsync()
        {
            return SourceService["isRecording"].CallAsync<bool>();
        }

        /// <summary>private</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _recordVideo(string arg0)
        {
            SourceService["_recordVideo"].Call(arg0);
        }

        /// <summary>private</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _recordVideoAsync(string arg0)
        {
            return SourceService["_recordVideo"].CallAsync(arg0);
        }

        /// <summary>Sets camera ID.</summary>
		/// <param name="arg0_cameraID">ID of the camera to use.</param>
		/// <returns></returns>
        public void SetCameraID(int arg0_cameraID)
        {
            SourceService["setCameraID"].Call(arg0_cameraID);
        }

        /// <summary>Sets camera ID.</summary>
		/// <param name="arg0_cameraID">ID of the camera to use.</param>
		/// <returns></returns>
        public IQiFuture SetCameraIDAsync(int arg0_cameraID)
        {
            return SourceService["setCameraID"].CallAsync(arg0_cameraID);
        }

        /// <summary>Sets resolution.</summary>
		/// <param name="arg0_resolution">New frame resolution.</param>
		/// <returns></returns>
        public void SetResolution(int arg0_resolution)
        {
            SourceService["setResolution"].Call(arg0_resolution);
        }

        /// <summary>Sets resolution.</summary>
		/// <param name="arg0_resolution">New frame resolution.</param>
		/// <returns></returns>
        public IQiFuture SetResolutionAsync(int arg0_resolution)
        {
            return SourceService["setResolution"].CallAsync(arg0_resolution);
        }

        /// <summary>Sets color space.</summary>
		/// <param name="arg0_colorSpace">New color space.</param>
		/// <returns></returns>
        public void SetColorSpace(int arg0_colorSpace)
        {
            SourceService["setColorSpace"].Call(arg0_colorSpace);
        }

        /// <summary>Sets color space.</summary>
		/// <param name="arg0_colorSpace">New color space.</param>
		/// <returns></returns>
        public IQiFuture SetColorSpaceAsync(int arg0_colorSpace)
        {
            return SourceService["setColorSpace"].CallAsync(arg0_colorSpace);
        }

        /// <summary>Sets frame rate.</summary>
		/// <param name="arg0_frameRate">New frame rate.</param>
		/// <returns></returns>
        public void SetFrameRate(float arg0_frameRate)
        {
            SourceService["setFrameRate"].Call(arg0_frameRate);
        }

        /// <summary>Sets frame rate.</summary>
		/// <param name="arg0_frameRate">New frame rate.</param>
		/// <returns></returns>
        public IQiFuture SetFrameRateAsync(float arg0_frameRate)
        {
            return SourceService["setFrameRate"].CallAsync(arg0_frameRate);
        }

        /// <summary>Sets video format.</summary>
		/// <param name="arg0_videoFormat">New video format.</param>
		/// <returns></returns>
        public void SetVideoFormat(string arg0_videoFormat)
        {
            SourceService["setVideoFormat"].Call(arg0_videoFormat);
        }

        /// <summary>Sets video format.</summary>
		/// <param name="arg0_videoFormat">New video format.</param>
		/// <returns></returns>
        public IQiFuture SetVideoFormatAsync(string arg0_videoFormat)
        {
            return SourceService["setVideoFormat"].CallAsync(arg0_videoFormat);
        }

        /// <summary>Returns current camera ID.</summary>
		/// <returns>Current camera ID.</returns>
        public int GetCameraID()
        {
            return SourceService["getCameraID"].Call<int>();
        }

        /// <summary>Returns current camera ID.</summary>
		/// <returns>Current camera ID.</returns>
        public IQiFuture<int> GetCameraIDAsync()
        {
            return SourceService["getCameraID"].CallAsync<int>();
        }

        /// <summary>Returns current resolution.</summary>
		/// <returns>Current resolution.</returns>
        public int GetResolution()
        {
            return SourceService["getResolution"].Call<int>();
        }

        /// <summary>Returns current resolution.</summary>
		/// <returns>Current resolution.</returns>
        public IQiFuture<int> GetResolutionAsync()
        {
            return SourceService["getResolution"].CallAsync<int>();
        }

        /// <summary>Returns current color space.</summary>
		/// <returns>Current color space.</returns>
        public int GetColorSpace()
        {
            return SourceService["getColorSpace"].Call<int>();
        }

        /// <summary>Returns current color space.</summary>
		/// <returns>Current color space.</returns>
        public IQiFuture<int> GetColorSpaceAsync()
        {
            return SourceService["getColorSpace"].CallAsync<int>();
        }

        /// <summary>Returns current frame rate.</summary>
		/// <returns>Current frame rate.</returns>
        public int GetFrameRate()
        {
            return SourceService["getFrameRate"].Call<int>();
        }

        /// <summary>Returns current frame rate.</summary>
		/// <returns>Current frame rate.</returns>
        public IQiFuture<int> GetFrameRateAsync()
        {
            return SourceService["getFrameRate"].CallAsync<int>();
        }

        /// <summary>Returns current video format.</summary>
		/// <returns>Current video format.</returns>
        public string GetVideoFormat()
        {
            return SourceService["getVideoFormat"].Call<string>();
        }

        /// <summary>Returns current video format.</summary>
		/// <returns>Current video format.</returns>
        public IQiFuture<string> GetVideoFormatAsync()
        {
            return SourceService["getVideoFormat"].CallAsync<string>();
        }

    }
}