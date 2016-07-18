using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALTabletService
	{
		internal ALTabletService(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTabletService CreateService(IQiSession session)
		{
			var result = new ALTabletService(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTabletService CreateUninitializedService(IQiSession session)
		{
			return new ALTabletService(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALTabletService");
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

        /// <summary>Show Webview (with app-specific content)</summary>
		/// <returns></returns>
        public bool ShowWebview()
        {
            return SourceService["showWebview"].Call<bool>();
        }

        /// <summary>Show Webview (with app-specific content)</summary>
		/// <returns></returns>
        public IQiFuture<bool> ShowWebviewAsync()
        {
            return SourceService["showWebview"].CallAsync<bool>();
        }

        /// <summary>Show Webview and load the url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowWebview(string arg0)
        {
            return SourceService["showWebview"].Call<bool>(arg0);
        }

        /// <summary>Show Webview and load the url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ShowWebviewAsync(string arg0)
        {
            return SourceService["showWebview"].CallAsync<bool>(arg0);
        }

        /// <summary>Load URL on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool LoadUrl(string arg0)
        {
            return SourceService["loadUrl"].Call<bool>(arg0);
        }

        /// <summary>Load URL on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> LoadUrlAsync(string arg0)
        {
            return SourceService["loadUrl"].CallAsync<bool>(arg0);
        }

        /// <summary>Reload current displayed web page</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void ReloadPage(bool arg0)
        {
            SourceService["reloadPage"].Call(arg0);
        }

        /// <summary>Reload current displayed web page</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture ReloadPageAsync(bool arg0)
        {
            return SourceService["reloadPage"].CallAsync(arg0);
        }

        /// <summary>Start application on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool LoadApplication(string arg0)
        {
            return SourceService["loadApplication"].Call<bool>(arg0);
        }

        /// <summary>Start application on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> LoadApplicationAsync(string arg0)
        {
            return SourceService["loadApplication"].CallAsync<bool>(arg0);
        }

        /// <summary>Hide Webview </summary>
		/// <returns></returns>
        public bool HideWebview()
        {
            return SourceService["hideWebview"].Call<bool>();
        }

        /// <summary>Hide Webview </summary>
		/// <returns></returns>
        public IQiFuture<bool> HideWebviewAsync()
        {
            return SourceService["hideWebview"].CallAsync<bool>();
        }

        /// <summary>Clean Webview </summary>
		/// <returns></returns>
        public void CleanWebview()
        {
            SourceService["cleanWebview"].Call();
        }

        /// <summary>Clean Webview </summary>
		/// <returns></returns>
        public IQiFuture CleanWebviewAsync()
        {
            return SourceService["cleanWebview"].CallAsync();
        }

        /// <summary>Clear the cache of the webview, false : just RAM, true DISK FILES also</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _clearWebviewCache(bool arg0)
        {
            SourceService["_clearWebviewCache"].Call(arg0);
        }

        /// <summary>Clear the cache of the webview, false : just RAM, true DISK FILES also</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _clearWebviewCacheAsync(bool arg0)
        {
            return SourceService["_clearWebviewCache"].CallAsync(arg0);
        }

        /// <summary>Execute javascript </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void ExecuteJS(string arg0)
        {
            SourceService["executeJS"].Call(arg0);
        }

        /// <summary>Execute javascript </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture ExecuteJSAsync(string arg0)
        {
            return SourceService["executeJS"].CallAsync(arg0);
        }

        /// <summary>CrossWalk animated render mode (can make the webview crash)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setAnimatedCrossWalkView(bool arg0)
        {
            SourceService["_setAnimatedCrossWalkView"].Call(arg0);
        }

        /// <summary>CrossWalk animated render mode (can make the webview crash)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setAnimatedCrossWalkViewAsync(bool arg0)
        {
            return SourceService["_setAnimatedCrossWalkView"].CallAsync(arg0);
        }

        /// <summary>CrossWalk animated render mode (can make the webview crash)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDebugCrossWalkViewEnable(bool arg0)
        {
            SourceService["_setDebugCrossWalkViewEnable"].Call(arg0);
        }

        /// <summary>CrossWalk animated render mode (can make the webview crash)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setDebugCrossWalkViewEnableAsync(bool arg0)
        {
            return SourceService["_setDebugCrossWalkViewEnable"].CallAsync(arg0);
        }

        /// <summary>Change the onTouch webview scale factor. Default is 1.34 so the viewport is 1707 × 1067</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetOnTouchWebviewScaleFactor(float arg0)
        {
            SourceService["setOnTouchWebviewScaleFactor"].Call(arg0);
        }

        /// <summary>Change the onTouch webview scale factor. Default is 1.34 so the viewport is 1707 × 1067</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture SetOnTouchWebviewScaleFactorAsync(float arg0)
        {
            return SourceService["setOnTouchWebviewScaleFactor"].CallAsync(arg0);
        }

        /// <summary>get the onTouch scale factor for current view, by default 1.34 for the webview and 1 for the other views</summary>
		/// <returns></returns>
        public float GetOnTouchScaleFactor()
        {
            return SourceService["getOnTouchScaleFactor"].Call<float>();
        }

        /// <summary>get the onTouch scale factor for current view, by default 1.34 for the webview and 1 for the other views</summary>
		/// <returns></returns>
        public IQiFuture<float> GetOnTouchScaleFactorAsync()
        {
            return SourceService["getOnTouchScaleFactor"].CallAsync<float>();
        }

        /// <summary>Play video on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool PlayVideo(string arg0)
        {
            return SourceService["playVideo"].Call<bool>(arg0);
        }

        /// <summary>Play video on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> PlayVideoAsync(string arg0)
        {
            return SourceService["playVideo"].CallAsync<bool>(arg0);
        }

        /// <summary>Resume video on tablet</summary>
		/// <returns></returns>
        public bool ResumeVideo()
        {
            return SourceService["resumeVideo"].Call<bool>();
        }

        /// <summary>Resume video on tablet</summary>
		/// <returns></returns>
        public IQiFuture<bool> ResumeVideoAsync()
        {
            return SourceService["resumeVideo"].CallAsync<bool>();
        }

        /// <summary>Pause video activity on tablet</summary>
		/// <returns></returns>
        public bool PauseVideo()
        {
            return SourceService["pauseVideo"].Call<bool>();
        }

        /// <summary>Pause video activity on tablet</summary>
		/// <returns></returns>
        public IQiFuture<bool> PauseVideoAsync()
        {
            return SourceService["pauseVideo"].CallAsync<bool>();
        }

        /// <summary>Stop video activity on tablet</summary>
		/// <returns></returns>
        public bool StopVideo()
        {
            return SourceService["stopVideo"].Call<bool>();
        }

        /// <summary>Stop video activity on tablet</summary>
		/// <returns></returns>
        public IQiFuture<bool> StopVideoAsync()
        {
            return SourceService["stopVideo"].CallAsync<bool>();
        }

        /// <summary>Get video position (in ms from beginning)</summary>
		/// <returns></returns>
        public int GetVideoPosition()
        {
            return SourceService["getVideoPosition"].Call<int>();
        }

        /// <summary>Get video position (in ms from beginning)</summary>
		/// <returns></returns>
        public IQiFuture<int> GetVideoPositionAsync()
        {
            return SourceService["getVideoPosition"].CallAsync<int>();
        }

        /// <summary>Get video length (in ms)</summary>
		/// <returns></returns>
        public int GetVideoLength()
        {
            return SourceService["getVideoLength"].Call<int>();
        }

        /// <summary>Get video length (in ms)</summary>
		/// <returns></returns>
        public IQiFuture<int> GetVideoLengthAsync()
        {
            return SourceService["getVideoLength"].CallAsync<int>();
        }

        /// <summary>preload an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool PreLoadImage(string arg0)
        {
            return SourceService["preLoadImage"].Call<bool>(arg0);
        }

        /// <summary>preload an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> PreLoadImageAsync(string arg0)
        {
            return SourceService["preLoadImage"].CallAsync<bool>(arg0);
        }

        /// <summary>show an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowImage(string arg0)
        {
            return SourceService["showImage"].Call<bool>(arg0);
        }

        /// <summary>show an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ShowImageAsync(string arg0)
        {
            return SourceService["showImage"].CallAsync<bool>(arg0);
        }

        /// <summary>show an image, disable tablet cache</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowImageNoCache(string arg0)
        {
            return SourceService["showImageNoCache"].Call<bool>(arg0);
        }

        /// <summary>show an image, disable tablet cache</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ShowImageNoCacheAsync(string arg0)
        {
            return SourceService["showImageNoCache"].CallAsync<bool>(arg0);
        }

        /// <summary>Hide an image</summary>
		/// <returns></returns>
        public void HideImage()
        {
            SourceService["hideImage"].Call();
        }

        /// <summary>Hide an image</summary>
		/// <returns></returns>
        public IQiFuture HideImageAsync()
        {
            return SourceService["hideImage"].CallAsync();
        }

        /// <summary>resume the gif</summary>
		/// <returns></returns>
        public void ResumeGif()
        {
            SourceService["resumeGif"].Call();
        }

        /// <summary>resume the gif</summary>
		/// <returns></returns>
        public IQiFuture ResumeGifAsync()
        {
            return SourceService["resumeGif"].CallAsync();
        }

        /// <summary>pause the gif</summary>
		/// <returns></returns>
        public void PauseGif()
        {
            SourceService["pauseGif"].Call();
        }

        /// <summary>pause the gif</summary>
		/// <returns></returns>
        public IQiFuture PauseGifAsync()
        {
            return SourceService["pauseGif"].CallAsync();
        }

        /// <summary>Set the background color for image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetBackgroundColor(string arg0)
        {
            return SourceService["setBackgroundColor"].Call<bool>(arg0);
        }

        /// <summary>Set the background color for image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetBackgroundColorAsync(string arg0)
        {
            return SourceService["setBackgroundColor"].CallAsync<bool>(arg0);
        }

        /// <summary>Show a flash animation</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _startAnimation(string arg0)
        {
            return SourceService["_startAnimation"].Call<bool>(arg0);
        }

        /// <summary>Show a flash animation</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _startAnimationAsync(string arg0)
        {
            return SourceService["_startAnimation"].CallAsync<bool>(arg0);
        }

        /// <summary>Hide a flash animation</summary>
		/// <returns></returns>
        public void _stopAnimation()
        {
            SourceService["_stopAnimation"].Call();
        }

        /// <summary>Hide a flash animation</summary>
		/// <returns></returns>
        public IQiFuture _stopAnimationAsync()
        {
            return SourceService["_stopAnimation"].CallAsync();
        }

        /// <summary>hide the top view</summary>
		/// <returns></returns>
        public void Hide()
        {
            SourceService["hide"].Call();
        }

        /// <summary>hide the top view</summary>
		/// <returns></returns>
        public IQiFuture HideAsync()
        {
            return SourceService["hide"].CallAsync();
        }

        /// <summary>Change screen brightness</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetBrightness(float arg0)
        {
            return SourceService["setBrightness"].Call<bool>(arg0);
        }

        /// <summary>Change screen brightness</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetBrightnessAsync(float arg0)
        {
            return SourceService["setBrightness"].CallAsync<bool>(arg0);
        }

        /// <summary>Change screen brightness</summary>
		/// <returns></returns>
        public float GetBrightness()
        {
            return SourceService["getBrightness"].Call<float>();
        }

        /// <summary>Change screen brightness</summary>
		/// <returns></returns>
        public IQiFuture<float> GetBrightnessAsync()
        {
            return SourceService["getBrightness"].CallAsync<float>();
        }

        /// <summary>Turn on (true) / off (false)  the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void TurnScreenOn(bool arg0)
        {
            SourceService["turnScreenOn"].Call(arg0);
        }

        /// <summary>Turn on (true) / off (false)  the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture TurnScreenOnAsync(bool arg0)
        {
            return SourceService["turnScreenOn"].CallAsync(arg0);
        }

        /// <summary>Put the tablet in sleep mode (standby mode)</summary>
		/// <returns></returns>
        public void GoToSleep()
        {
            SourceService["goToSleep"].Call();
        }

        /// <summary>Put the tablet in sleep mode (standby mode)</summary>
		/// <returns></returns>
        public IQiFuture GoToSleepAsync()
        {
            return SourceService["goToSleep"].CallAsync();
        }

        /// <summary>Put the tablet in wake mode (standby mode)</summary>
		/// <returns></returns>
        public void WakeUp()
        {
            SourceService["wakeUp"].Call();
        }

        /// <summary>Put the tablet in wake mode (standby mode)</summary>
		/// <returns></returns>
        public IQiFuture WakeUpAsync()
        {
            return SourceService["wakeUp"].CallAsync();
        }

        /// <summary>Display an android Toast: 1) Text to display 2) Duration 1 long, 0 short</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _displayToast(string arg0, int arg1)
        {
            SourceService["_displayToast"].Call(arg0, arg1);
        }

        /// <summary>Display an android Toast: 1) Text to display 2) Duration 1 long, 0 short</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture _displayToastAsync(string arg0, int arg1)
        {
            return SourceService["_displayToast"].CallAsync(arg0, arg1);
        }

        /// <summary>Display an android Toast: 1) Text to display 2) Duration 1 long, 0 short 3) Text size</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _displayToast(string arg0, int arg1, int arg2)
        {
            SourceService["_displayToast"].Call(arg0, arg1, arg2);
        }

        /// <summary>Display an android Toast: 1) Text to display 2) Duration 1 long, 0 short 3) Text size</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture _displayToastAsync(string arg0, int arg1, int arg2)
        {
            return SourceService["_displayToast"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>Check the WIFI on the tablet : IDLE, SCANNING, DISCONNECTED, CONNECTED</summary>
		/// <returns></returns>
        public string GetWifiStatus()
        {
            return SourceService["getWifiStatus"].Call<string>();
        }

        /// <summary>Check the WIFI on the tablet : IDLE, SCANNING, DISCONNECTED, CONNECTED</summary>
		/// <returns></returns>
        public IQiFuture<string> GetWifiStatusAsync()
        {
            return SourceService["getWifiStatus"].CallAsync<string>();
        }

        /// <summary>Enable the wifi on the tablet</summary>
		/// <returns></returns>
        public void EnableWifi()
        {
            SourceService["enableWifi"].Call();
        }

        /// <summary>Enable the wifi on the tablet</summary>
		/// <returns></returns>
        public IQiFuture EnableWifiAsync()
        {
            return SourceService["enableWifi"].CallAsync();
        }

        /// <summary>Disable the wifi on the tablet</summary>
		/// <returns></returns>
        public void DisableWifi()
        {
            SourceService["disableWifi"].Call();
        }

        /// <summary>Disable the wifi on the tablet</summary>
		/// <returns></returns>
        public IQiFuture DisableWifiAsync()
        {
            return SourceService["disableWifi"].CallAsync();
        }

        /// <summary>Forget the wifi : 1) SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ForgetWifi(string arg0)
        {
            return SourceService["forgetWifi"].Call<bool>(arg0);
        }

        /// <summary>Forget the wifi : 1) SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ForgetWifiAsync(string arg0)
        {
            return SourceService["forgetWifi"].CallAsync<bool>(arg0);
        }

        /// <summary>Try to connect to the wifi by is SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ConnectWifi(string arg0)
        {
            return SourceService["connectWifi"].Call<bool>(arg0);
        }

        /// <summary>Try to connect to the wifi by is SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> ConnectWifiAsync(string arg0)
        {
            return SourceService["connectWifi"].CallAsync<bool>(arg0);
        }

        /// <summary>Disconnect current wifi</summary>
		/// <returns></returns>
        public bool DisconnectWifi()
        {
            return SourceService["disconnectWifi"].Call<bool>();
        }

        /// <summary>Disconnect current wifi</summary>
		/// <returns></returns>
        public IQiFuture<bool> DisconnectWifiAsync()
        {
            return SourceService["disconnectWifi"].CallAsync<bool>();
        }

        /// <summary>Configure the WIFI, arguments:        1) is type among (wep, wpa, open)        2) is the wifi SSID        3) is wep or wap passphrase </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool ConfigureWifi(string arg0, string arg1, string arg2)
        {
            return SourceService["configureWifi"].Call<bool>(arg0, arg1, arg2);
        }

        /// <summary>Configure the WIFI, arguments:        1) is type among (wep, wpa, open)        2) is the wifi SSID        3) is wep or wap passphrase </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<bool> ConfigureWifiAsync(string arg0, string arg1, string arg2)
        {
            return SourceService["configureWifi"].CallAsync<bool>(arg0, arg1, arg2);
        }

        /// <summary>Get the wifi mac address</summary>
		/// <returns></returns>
        public string GetWifiMacAddress()
        {
            return SourceService["getWifiMacAddress"].Call<string>();
        }

        /// <summary>Get the wifi mac address</summary>
		/// <returns></returns>
        public IQiFuture<string> GetWifiMacAddressAsync()
        {
            return SourceService["getWifiMacAddress"].CallAsync<string>();
        }

        /// <summary>Show a input text dialog, arguments        1) the title        2) is the ok text         3) the cancel text </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void ShowInputTextDialog(string arg0, string arg1, string arg2)
        {
            SourceService["showInputTextDialog"].Call(arg0, arg1, arg2);
        }

        /// <summary>Show a input text dialog, arguments        1) the title        2) is the ok text         3) the cancel text </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture ShowInputTextDialogAsync(string arg0, string arg1, string arg2)
        {
            return SourceService["showInputTextDialog"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>Show a input text dialog, arguments        1) the title        2) is the ok text         3) the cancel text        4) the pre-filled text of the input field        5) input characters limit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public void ShowInputTextDialog(string arg0, string arg1, string arg2, string arg3, int arg4)
        {
            SourceService["showInputTextDialog"].Call(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary>Show a input text dialog, arguments        1) the title        2) is the ok text         3) the cancel text        4) the pre-filled text of the input field        5) input characters limit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public IQiFuture ShowInputTextDialogAsync(string arg0, string arg1, string arg2, string arg3, int arg4)
        {
            return SourceService["showInputTextDialog"].CallAsync(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary>Show a input text dialog, arguments :        1) is type among text, password, email, url, number        2) the title        3) is the ok text        4) the cancel text</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public void ShowInputDialog(string arg0, string arg1, string arg2, string arg3)
        {
            SourceService["showInputDialog"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary>Show a input text dialog, arguments :        1) is type among text, password, email, url, number        2) the title        3) is the ok text        4) the cancel text</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture ShowInputDialogAsync(string arg0, string arg1, string arg2, string arg3)
        {
            return SourceService["showInputDialog"].CallAsync(arg0, arg1, arg2, arg3);
        }

        /// <summary>Show a input text dialog, arguments        1) is type among text, password, email, url, number        2) the title        3) is the ok text        4) the cancel text        5) the pre-filled text of the input field, use '' if you don't want any        6) input characters limit, use -1 if you don't want a limit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public void ShowInputDialog(string arg0, string arg1, string arg2, string arg3, string arg4, int arg5)
        {
            SourceService["showInputDialog"].Call(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>Show a input text dialog, arguments        1) is type among text, password, email, url, number        2) the title        3) is the ok text        4) the cancel text        5) the pre-filled text of the input field, use '' if you don't want any        6) input characters limit, use -1 if you don't want a limit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public IQiFuture ShowInputDialogAsync(string arg0, string arg1, string arg2, string arg3, string arg4, int arg5)
        {
            return SourceService["showInputDialog"].CallAsync(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>Test debug function</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void ShowAlertView(float arg0, string arg1, int arg2)
        {
            SourceService["showAlertView"].Call(arg0, arg1, arg2);
        }

        /// <summary>Test debug function</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture ShowAlertViewAsync(float arg0, string arg1, int arg2)
        {
            return SourceService["showAlertView"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary>Hide the dialog view</summary>
		/// <returns></returns>
        public void HideDialog()
        {
            SourceService["hideDialog"].Call();
        }

        /// <summary>Hide the dialog view</summary>
		/// <returns></returns>
        public IQiFuture HideDialogAsync()
        {
            return SourceService["hideDialog"].CallAsync();
        }

        /// <summary>Set keyboard using is keyboard id from getAvailableKeyboards</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetKeyboard(string arg0)
        {
            return SourceService["setKeyboard"].Call<bool>(arg0);
        }

        /// <summary>Set keyboard using is keyboard id from getAvailableKeyboards</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetKeyboardAsync(string arg0)
        {
            return SourceService["setKeyboard"].CallAsync<bool>(arg0);
        }

        /// <summary>get available keyboards</summary>
		/// <returns></returns>
        public string[] GetAvailableKeyboards()
        {
            return SourceService["getAvailableKeyboards"].Call<string[]>();
        }

        /// <summary>get available keyboards</summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetAvailableKeyboardsAsync()
        {
            return SourceService["getAvailableKeyboards"].CallAsync<string[]>();
        }

        /// <summary>Change the tablet language: fr, fr_FR, en, us, it, ja ... </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetTabletLanguage(string arg0)
        {
            return SourceService["setTabletLanguage"].Call<bool>(arg0);
        }

        /// <summary>Change the tablet language: fr, fr_FR, en, us, it, ja ... </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetTabletLanguageAsync(string arg0)
        {
            return SourceService["setTabletLanguage"].CallAsync<bool>(arg0);
        }

        /// <summary>Open android settings</summary>
		/// <returns></returns>
        public void _openSettings()
        {
            SourceService["_openSettings"].Call();
        }

        /// <summary>Open android settings</summary>
		/// <returns></returns>
        public IQiFuture _openSettingsAsync()
        {
            return SourceService["_openSettings"].CallAsync();
        }

        /// <summary>Set the volume of the tablet between 0 and 15</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetVolume(int arg0)
        {
            return SourceService["setVolume"].Call<bool>(arg0);
        }

        /// <summary>Set the volume of the tablet between 0 and 15</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetVolumeAsync(int arg0)
        {
            return SourceService["setVolume"].CallAsync<bool>(arg0);
        }

        /// <summary>Enable debug menu.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDebugEnabled(bool arg0)
        {
            SourceService["_setDebugEnabled"].Call(arg0);
        }

        /// <summary>Enable debug menu.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setDebugEnabledAsync(bool arg0)
        {
            return SourceService["_setDebugEnabled"].CallAsync(arg0);
        }

        /// <summary>Set the system time zone (Ex: Europe/Paris)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setTimeZone(string arg0)
        {
            SourceService["_setTimeZone"].Call(arg0);
        }

        /// <summary>Set the system time zone (Ex: Europe/Paris)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setTimeZoneAsync(string arg0)
        {
            return SourceService["_setTimeZone"].CallAsync(arg0);
        }

        /// <summary>Number of lines that will be send for java stacktrace, current is </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _setStackTraceDepth(int arg0)
        {
            return SourceService["_setStackTraceDepth"].Call<bool>(arg0);
        }

        /// <summary>Number of lines that will be send for java stacktrace, current is </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _setStackTraceDepthAsync(int arg0)
        {
            return SourceService["_setStackTraceDepth"].CallAsync<bool>(arg0);
        }

        /// <summary>Simple ping/pong method. Return 'pong'</summary>
		/// <returns></returns>
        public string _ping()
        {
            return SourceService["_ping"].Call<string>();
        }

        /// <summary>Simple ping/pong method. Return 'pong'</summary>
		/// <returns></returns>
        public IQiFuture<string> _pingAsync()
        {
            return SourceService["_ping"].CallAsync<string>();
        }

        /// <summary>Get IP of connected robot</summary>
		/// <returns></returns>
        public string RobotIp()
        {
            return SourceService["robotIp"].Call<string>();
        }

        /// <summary>Get IP of connected robot</summary>
		/// <returns></returns>
        public IQiFuture<string> RobotIpAsync()
        {
            return SourceService["robotIp"].CallAsync<string>();
        }

        /// <summary>Return the current life activity running</summary>
		/// <returns></returns>
        public string GetCurrentLifeActivity()
        {
            return SourceService["getCurrentLifeActivity"].Call<string>();
        }

        /// <summary>Return the current life activity running</summary>
		/// <returns></returns>
        public IQiFuture<string> GetCurrentLifeActivityAsync()
        {
            return SourceService["getCurrentLifeActivity"].CallAsync<string>();
        }

        /// <summary>Return service version</summary>
		/// <returns></returns>
        public string Version()
        {
            return SourceService["version"].Call<string>();
        }

        /// <summary>Return service version</summary>
		/// <returns></returns>
        public IQiFuture<string> VersionAsync()
        {
            return SourceService["version"].CallAsync<string>();
        }

        /// <summary>Return android firmware version</summary>
		/// <returns></returns>
        public string _firmwareVersion()
        {
            return SourceService["_firmwareVersion"].Call<string>();
        }

        /// <summary>Return android firmware version</summary>
		/// <returns></returns>
        public IQiFuture<string> _firmwareVersionAsync()
        {
            return SourceService["_firmwareVersion"].CallAsync<string>();
        }

        /// <summary>Return launcher version</summary>
		/// <returns></returns>
        public string _launcherVersion()
        {
            return SourceService["_launcherVersion"].Call<string>();
        }

        /// <summary>Return launcher version</summary>
		/// <returns></returns>
        public IQiFuture<string> _launcherVersionAsync()
        {
            return SourceService["_launcherVersion"].CallAsync<string>();
        }

        /// <summary>reset the tablet (get back to the bubble views and clear everything)</summary>
		/// <returns></returns>
        public void ResetTablet()
        {
            SourceService["resetTablet"].Call();
        }

        /// <summary>reset the tablet (get back to the bubble views and clear everything)</summary>
		/// <returns></returns>
        public IQiFuture ResetTabletAsync()
        {
            return SourceService["resetTablet"].CallAsync();
        }

        /// <summary>enable reset tablet command (true by default)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableResetTablet(bool arg0)
        {
            SourceService["_enableResetTablet"].Call(arg0);
        }

        /// <summary>enable reset tablet command (true by default)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _enableResetTabletAsync(bool arg0)
        {
            return SourceService["_enableResetTablet"].CallAsync(arg0);
        }

        /// <summary>Cancel reset tablet (standby mode)</summary>
		/// <returns></returns>
        public void _cancelReset()
        {
            SourceService["_cancelReset"].Call();
        }

        /// <summary>Cancel reset tablet (standby mode)</summary>
		/// <returns></returns>
        public IQiFuture _cancelResetAsync()
        {
            return SourceService["_cancelReset"].CallAsync();
        }

        /// <summary>Prevent to run command if screen is turn off, default is true</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setPreventCommandScreenOff(bool arg0)
        {
            SourceService["_setPreventCommandScreenOff"].Call(arg0);
        }

        /// <summary>Prevent to run command if screen is turn off, default is true</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setPreventCommandScreenOffAsync(bool arg0)
        {
            return SourceService["_setPreventCommandScreenOff"].CallAsync(arg0);
        }

        /// <summary>Set custom Open GL state</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setOpenGLState(int arg0)
        {
            SourceService["_setOpenGLState"].Call(arg0);
        }

        /// <summary>Set custom Open GL state</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setOpenGLStateAsync(int arg0)
        {
            return SourceService["_setOpenGLState"].CallAsync(arg0);
        }

        /// <summary>Set if we use a black screen to turn off the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setBlackScreenMode(bool arg0)
        {
            SourceService["_setBlackScreenMode"].Call(arg0);
        }

        /// <summary>Set if we use a black screen to turn off the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setBlackScreenModeAsync(bool arg0)
        {
            return SourceService["_setBlackScreenMode"].CallAsync(arg0);
        }

        /// <summary>Update browser service</summary>
		/// <returns></returns>
        public bool _update()
        {
            return SourceService["_update"].Call<bool>();
        }

        /// <summary>Update browser service</summary>
		/// <returns></returns>
        public IQiFuture<bool> _updateAsync()
        {
            return SourceService["_update"].CallAsync<bool>();
        }

        /// <summary>Uninstall both the launcher and the browser</summary>
		/// <returns></returns>
        public void _uninstallApps()
        {
            SourceService["_uninstallApps"].Call();
        }

        /// <summary>Uninstall both the launcher and the browser</summary>
		/// <returns></returns>
        public IQiFuture _uninstallAppsAsync()
        {
            return SourceService["_uninstallApps"].CallAsync();
        }

        /// <summary>Uninstall the launcher</summary>
		/// <returns></returns>
        public void _uninstallLauncher()
        {
            SourceService["_uninstallLauncher"].Call();
        }

        /// <summary>Uninstall the launcher</summary>
		/// <returns></returns>
        public IQiFuture _uninstallLauncherAsync()
        {
            return SourceService["_uninstallLauncher"].CallAsync();
        }

        /// <summary>Uninstall the browser</summary>
		/// <returns></returns>
        public void _uninstallBrowser()
        {
            SourceService["_uninstallBrowser"].Call();
        }

        /// <summary>Uninstall the browser</summary>
		/// <returns></returns>
        public IQiFuture _uninstallBrowserAsync()
        {
            return SourceService["_uninstallBrowser"].CallAsync();
        }

        /// <summary>Wipe all the data</summary>
		/// <returns></returns>
        public void _wipeData()
        {
            SourceService["_wipeData"].Call();
        }

        /// <summary>Wipe all the data</summary>
		/// <returns></returns>
        public IQiFuture _wipeDataAsync()
        {
            return SourceService["_wipeData"].CallAsync();
        }

        /// <summary>Restart the browser application</summary>
		/// <returns></returns>
        public void _restart()
        {
            SourceService["_restart"].Call();
        }

        /// <summary>Restart the browser application</summary>
		/// <returns></returns>
        public IQiFuture _restartAsync()
        {
            return SourceService["_restart"].CallAsync();
        }

        /// <summary>Turn off the tablet</summary>
		/// <returns></returns>
        public void _powerOff()
        {
            SourceService["_powerOff"].Call();
        }

        /// <summary>Turn off the tablet</summary>
		/// <returns></returns>
        public IQiFuture _powerOffAsync()
        {
            return SourceService["_powerOff"].CallAsync();
        }

        /// <summary>Install an android APK using an url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _installApk(string arg0)
        {
            return SourceService["_installApk"].Call<bool>(arg0);
        }

        /// <summary>Install an android APK using an url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _installApkAsync(string arg0)
        {
            return SourceService["_installApk"].CallAsync<bool>(arg0);
        }

        /// <summary>Launch an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _launchApk(string arg0)
        {
            return SourceService["_launchApk"].Call<bool>(arg0);
        }

        /// <summary>Launch an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _launchApkAsync(string arg0)
        {
            return SourceService["_launchApk"].CallAsync<bool>(arg0);
        }

        /// <summary>Remove an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _removeApk(string arg0)
        {
            SourceService["_removeApk"].Call(arg0);
        }

        /// <summary>Remove an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _removeApkAsync(string arg0)
        {
            return SourceService["_removeApk"].CallAsync(arg0);
        }

        /// <summary>List all apks on the tablet (return package names)</summary>
		/// <returns></returns>
        public string _listApks()
        {
            return SourceService["_listApks"].Call<string>();
        }

        /// <summary>List all apks on the tablet (return package names)</summary>
		/// <returns></returns>
        public IQiFuture<string> _listApksAsync()
        {
            return SourceService["_listApks"].CallAsync<string>();
        }

        /// <summary>Stop APK given is package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _stopApk(string arg0)
        {
            SourceService["_stopApk"].Call(arg0);
        }

        /// <summary>Stop APK given is package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _stopApkAsync(string arg0)
        {
            return SourceService["_stopApk"].CallAsync(arg0);
        }

        /// <summary>Test is apk installed using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isApkExist(string arg0)
        {
            return SourceService["_isApkExist"].Call<bool>(arg0);
        }

        /// <summary>Test is apk installed using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _isApkExistAsync(string arg0)
        {
            return SourceService["_isApkExist"].CallAsync<bool>(arg0);
        }

        /// <summary>Get apk version using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string _getApkVersion(string arg0)
        {
            return SourceService["_getApkVersion"].Call<string>(arg0);
        }

        /// <summary>Get apk version using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> _getApkVersionAsync(string arg0)
        {
            return SourceService["_getApkVersion"].CallAsync<string>(arg0);
        }

        /// <summary>test function</summary>
		/// <returns></returns>
        public string _test()
        {
            return SourceService["_test"].Call<string>();
        }

        /// <summary>test function</summary>
		/// <returns></returns>
        public IQiFuture<string> _testAsync()
        {
            return SourceService["_test"].CallAsync<string>();
        }

        /// <summary>Crash the browser</summary>
		/// <returns></returns>
        public void _crash()
        {
            SourceService["_crash"].Call();
        }

        /// <summary>Crash the browser</summary>
		/// <returns></returns>
        public IQiFuture _crashAsync()
        {
            return SourceService["_crash"].CallAsync();
        }

        /// <summary>Get last video played error log [DEPRECATED]</summary>
		/// <returns></returns>
        public string GetLastVideoErrorLog()
        {
            return SourceService["getLastVideoErrorLog"].Call<string>();
        }

        /// <summary>Get last video played error log [DEPRECATED]</summary>
		/// <returns></returns>
        public IQiFuture<string> GetLastVideoErrorLogAsync()
        {
            return SourceService["getLastVideoErrorLog"].CallAsync<string>();
        }

        /// <summary>Enable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public void EnableWebviewTouch()
        {
            SourceService["enableWebviewTouch"].Call();
        }

        /// <summary>Enable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public IQiFuture EnableWebviewTouchAsync()
        {
            return SourceService["enableWebviewTouch"].CallAsync();
        }

        /// <summary>Disable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public void DisableWebviewTouch()
        {
            SourceService["disableWebviewTouch"].Call();
        }

        /// <summary>Disable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public IQiFuture DisableWebviewTouchAsync()
        {
            return SourceService["disableWebviewTouch"].CallAsync();
        }

        /// <summary>reset to default value [DEPRECATED]</summary>
		/// <returns></returns>
        public void ResetToDefaultValue()
        {
            SourceService["resetToDefaultValue"].Call();
        }

        /// <summary>reset to default value [DEPRECATED]</summary>
		/// <returns></returns>
        public IQiFuture ResetToDefaultValueAsync()
        {
            return SourceService["resetToDefaultValue"].CallAsync();
        }

        /// <summary>Stop current apk [DEPRECATED]</summary>
		/// <returns></returns>
        public void _stopApk()
        {
            SourceService["_stopApk"].Call();
        }

        /// <summary>Stop current apk [DEPRECATED]</summary>
		/// <returns></returns>
        public IQiFuture _stopApkAsync()
        {
            return SourceService["_stopApk"].CallAsync();
        }

        /// <summary>[DEPRECATED]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setLifeDetectorEnabled(bool arg0)
        {
            SourceService["_setLifeDetectorEnabled"].Call(arg0);
        }

        /// <summary>[DEPRECATED]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _setLifeDetectorEnabledAsync(bool arg0)
        {
            return SourceService["_setLifeDetectorEnabled"].CallAsync(arg0);
        }

    }
}