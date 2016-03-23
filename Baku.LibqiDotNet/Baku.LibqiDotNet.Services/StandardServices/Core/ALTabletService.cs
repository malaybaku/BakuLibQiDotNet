using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALTabletService
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALTabletService(QiSession session)
        {
            SourceService = session.GetService("ALTabletService");
        }

        /// <summary>コード生成によってラップされる前のサービスオブジェクトを取得します。</summary>
        public QiObject SourceService { get; }


        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public ulong RegisterEvent(uint arg0, uint arg1, ulong arg2)
        {
            return (ulong)SourceService["registerEvent"].Call(arg0, arg1, arg2);
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
		/// <returns></returns>
        public QiValue MetaObject(uint arg0)
        {
            return SourceService["metaObject"].Call(arg0);
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
        public QiValue Property(QiAnyValue arg0)
        {
            return SourceService["property"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void SetProperty(QiAnyValue arg0, QiAnyValue arg1)
        {
            SourceService["setProperty"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] Properties()
        {
            return (string[])SourceService["properties"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public ulong RegisterEventWithSignature(uint arg0, uint arg1, ulong arg2, string arg3)
        {
            return (ulong)SourceService["registerEventWithSignature"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsStatsEnabled()
        {
            return (bool)SourceService["isStatsEnabled"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void EnableStats(bool arg0)
        {
            SourceService["enableStats"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue Stats()
        {
            return SourceService["stats"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void ClearStats()
        {
            SourceService["clearStats"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsTraceEnabled()
        {
            return (bool)SourceService["isTraceEnabled"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void EnableTrace(bool arg0)
        {
            SourceService["enableTrace"].Call(arg0);
        }

        /// <summary>Show Webview (with app-specific content)</summary>
		/// <returns></returns>
        public bool ShowWebview()
        {
            return (bool)SourceService["showWebview"].Call();
        }

        /// <summary>Show Webview and load the url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowWebview(string arg0)
        {
            return (bool)SourceService["showWebview"].Call(arg0);
        }

        /// <summary>Load URL on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool LoadUrl(string arg0)
        {
            return (bool)SourceService["loadUrl"].Call(arg0);
        }

        /// <summary>Reload current displayed web page</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void ReloadPage(bool arg0)
        {
            SourceService["reloadPage"].Call(arg0);
        }

        /// <summary>Start application on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool LoadApplication(string arg0)
        {
            return (bool)SourceService["loadApplication"].Call(arg0);
        }

        /// <summary>Hide Webview </summary>
		/// <returns></returns>
        public bool HideWebview()
        {
            return (bool)SourceService["hideWebview"].Call();
        }

        /// <summary>Clean Webview </summary>
		/// <returns></returns>
        public void CleanWebview()
        {
            SourceService["cleanWebview"].Call();
        }

        /// <summary>Clear the cache of the webview, false : just RAM, true DISK FILES also</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _clearWebviewCache(bool arg0)
        {
            SourceService["_clearWebviewCache"].Call(arg0);
        }

        /// <summary>Execute javascript </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void ExecuteJS(string arg0)
        {
            SourceService["executeJS"].Call(arg0);
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
        public void _setDebugCrossWalkViewEnable(bool arg0)
        {
            SourceService["_setDebugCrossWalkViewEnable"].Call(arg0);
        }

        /// <summary>Change the onTouch webview scale factor. Default is 1.34 so the viewport is 1707 × 1067</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetOnTouchWebviewScaleFactor(float arg0)
        {
            SourceService["setOnTouchWebviewScaleFactor"].Call(arg0);
        }

        /// <summary>get the onTouch scale factor for current view, by default 1.34 for the webview and 1 for the other views</summary>
		/// <returns></returns>
        public float GetOnTouchScaleFactor()
        {
            return (float)SourceService["getOnTouchScaleFactor"].Call();
        }

        /// <summary>Play video on tablet</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool PlayVideo(string arg0)
        {
            return (bool)SourceService["playVideo"].Call(arg0);
        }

        /// <summary>Resume video on tablet</summary>
		/// <returns></returns>
        public bool ResumeVideo()
        {
            return (bool)SourceService["resumeVideo"].Call();
        }

        /// <summary>Pause video activity on tablet</summary>
		/// <returns></returns>
        public bool PauseVideo()
        {
            return (bool)SourceService["pauseVideo"].Call();
        }

        /// <summary>Stop video activity on tablet</summary>
		/// <returns></returns>
        public bool StopVideo()
        {
            return (bool)SourceService["stopVideo"].Call();
        }

        /// <summary>Get video position (in ms from beginning)</summary>
		/// <returns></returns>
        public int GetVideoPosition()
        {
            return (int)SourceService["getVideoPosition"].Call();
        }

        /// <summary>Get video length (in ms)</summary>
		/// <returns></returns>
        public int GetVideoLength()
        {
            return (int)SourceService["getVideoLength"].Call();
        }

        /// <summary>preload an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool PreLoadImage(string arg0)
        {
            return (bool)SourceService["preLoadImage"].Call(arg0);
        }

        /// <summary>show an image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowImage(string arg0)
        {
            return (bool)SourceService["showImage"].Call(arg0);
        }

        /// <summary>show an image, disable tablet cache</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ShowImageNoCache(string arg0)
        {
            return (bool)SourceService["showImageNoCache"].Call(arg0);
        }

        /// <summary>Hide an image</summary>
		/// <returns></returns>
        public void HideImage()
        {
            SourceService["hideImage"].Call();
        }

        /// <summary>resume the gif</summary>
		/// <returns></returns>
        public void ResumeGif()
        {
            SourceService["resumeGif"].Call();
        }

        /// <summary>pause the gif</summary>
		/// <returns></returns>
        public void PauseGif()
        {
            SourceService["pauseGif"].Call();
        }

        /// <summary>Set the background color for image</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetBackgroundColor(string arg0)
        {
            return (bool)SourceService["setBackgroundColor"].Call(arg0);
        }

        /// <summary>Show a flash animation</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _startAnimation(string arg0)
        {
            return (bool)SourceService["_startAnimation"].Call(arg0);
        }

        /// <summary>Hide a flash animation</summary>
		/// <returns></returns>
        public void _stopAnimation()
        {
            SourceService["_stopAnimation"].Call();
        }

        /// <summary>hide the top view</summary>
		/// <returns></returns>
        public void Hide()
        {
            SourceService["hide"].Call();
        }

        /// <summary>Change screen brightness</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetBrightness(float arg0)
        {
            return (bool)SourceService["setBrightness"].Call(arg0);
        }

        /// <summary>Change screen brightness</summary>
		/// <returns></returns>
        public float GetBrightness()
        {
            return (float)SourceService["getBrightness"].Call();
        }

        /// <summary>Turn on (true) / off (false)  the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void TurnScreenOn(bool arg0)
        {
            SourceService["turnScreenOn"].Call(arg0);
        }

        /// <summary>Put the tablet in sleep mode (standby mode)</summary>
		/// <returns></returns>
        public void GoToSleep()
        {
            SourceService["goToSleep"].Call();
        }

        /// <summary>Put the tablet in wake mode (standby mode)</summary>
		/// <returns></returns>
        public void WakeUp()
        {
            SourceService["wakeUp"].Call();
        }

        /// <summary>Display an android Toast: 1) Text to display 2) Duration 1 long, 0 short</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _displayToast(string arg0, int arg1)
        {
            SourceService["_displayToast"].Call(arg0, arg1);
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

        /// <summary>Check the WIFI on the tablet : IDLE, SCANNING, DISCONNECTED, CONNECTED</summary>
		/// <returns></returns>
        public string GetWifiStatus()
        {
            return (string)SourceService["getWifiStatus"].Call();
        }

        /// <summary>Enable the wifi on the tablet</summary>
		/// <returns></returns>
        public void EnableWifi()
        {
            SourceService["enableWifi"].Call();
        }

        /// <summary>Disable the wifi on the tablet</summary>
		/// <returns></returns>
        public void DisableWifi()
        {
            SourceService["disableWifi"].Call();
        }

        /// <summary>Forget the wifi : 1) SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ForgetWifi(string arg0)
        {
            return (bool)SourceService["forgetWifi"].Call(arg0);
        }

        /// <summary>Try to connect to the wifi by is SSID</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ConnectWifi(string arg0)
        {
            return (bool)SourceService["connectWifi"].Call(arg0);
        }

        /// <summary>Disconnect current wifi</summary>
		/// <returns></returns>
        public bool DisconnectWifi()
        {
            return (bool)SourceService["disconnectWifi"].Call();
        }

        /// <summary>Configure the WIFI, arguments:        1) is type among (wep, wpa, open)        2) is the wifi SSID        3) is wep or wap passphrase </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool ConfigureWifi(string arg0, string arg1, string arg2)
        {
            return (bool)SourceService["configureWifi"].Call(arg0, arg1, arg2);
        }

        /// <summary>Get the wifi mac address</summary>
		/// <returns></returns>
        public string GetWifiMacAddress()
        {
            return (string)SourceService["getWifiMacAddress"].Call();
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

        /// <summary>Test debug function</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void ShowAlertView(float arg0, string arg1, int arg2)
        {
            SourceService["showAlertView"].Call(arg0, arg1, arg2);
        }

        /// <summary>Hide the dialog view</summary>
		/// <returns></returns>
        public void HideDialog()
        {
            SourceService["hideDialog"].Call();
        }

        /// <summary>Set keyboard using is keyboard id from getAvailableKeyboards</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetKeyboard(string arg0)
        {
            return (bool)SourceService["setKeyboard"].Call(arg0);
        }

        /// <summary>get available keyboards</summary>
		/// <returns></returns>
        public string[] GetAvailableKeyboards()
        {
            return (string[])SourceService["getAvailableKeyboards"].Call();
        }

        /// <summary>Change the tablet language: fr, fr_FR, en, us, it, ja ... </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetTabletLanguage(string arg0)
        {
            return (bool)SourceService["setTabletLanguage"].Call(arg0);
        }

        /// <summary>Open android settings</summary>
		/// <returns></returns>
        public void _openSettings()
        {
            SourceService["_openSettings"].Call();
        }

        /// <summary>Set the volume of the tablet between 0 and 15</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetVolume(int arg0)
        {
            return (bool)SourceService["setVolume"].Call(arg0);
        }

        /// <summary>Enable debug menu.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDebugEnabled(bool arg0)
        {
            SourceService["_setDebugEnabled"].Call(arg0);
        }

        /// <summary>Set the system time zone (Ex: Europe/Paris)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setTimeZone(string arg0)
        {
            SourceService["_setTimeZone"].Call(arg0);
        }

        /// <summary>Number of lines that will be send for java stacktrace, current is </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _setStackTraceDepth(int arg0)
        {
            return (bool)SourceService["_setStackTraceDepth"].Call(arg0);
        }

        /// <summary>Simple ping/pong method. Return 'pong'</summary>
		/// <returns></returns>
        public string _ping()
        {
            return (string)SourceService["_ping"].Call();
        }

        /// <summary>Get IP of connected robot</summary>
		/// <returns></returns>
        public string RobotIp()
        {
            return (string)SourceService["robotIp"].Call();
        }

        /// <summary>Return the current life activity running</summary>
		/// <returns></returns>
        public string GetCurrentLifeActivity()
        {
            return (string)SourceService["getCurrentLifeActivity"].Call();
        }

        /// <summary>Return service version</summary>
		/// <returns></returns>
        public string Version()
        {
            return (string)SourceService["version"].Call();
        }

        /// <summary>Return android firmware version</summary>
		/// <returns></returns>
        public string _firmwareVersion()
        {
            return (string)SourceService["_firmwareVersion"].Call();
        }

        /// <summary>Return launcher version</summary>
		/// <returns></returns>
        public string _launcherVersion()
        {
            return (string)SourceService["_launcherVersion"].Call();
        }

        /// <summary>reset the tablet (get back to the bubble views and clear everything)</summary>
		/// <returns></returns>
        public void ResetTablet()
        {
            SourceService["resetTablet"].Call();
        }

        /// <summary>enable reset tablet command (true by default)</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableResetTablet(bool arg0)
        {
            SourceService["_enableResetTablet"].Call(arg0);
        }

        /// <summary>Cancel reset tablet (standby mode)</summary>
		/// <returns></returns>
        public void _cancelReset()
        {
            SourceService["_cancelReset"].Call();
        }

        /// <summary>Prevent to run command if screen is turn off, default is true</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setPreventCommandScreenOff(bool arg0)
        {
            SourceService["_setPreventCommandScreenOff"].Call(arg0);
        }

        /// <summary>Set custom Open GL state</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setOpenGLState(int arg0)
        {
            SourceService["_setOpenGLState"].Call(arg0);
        }

        /// <summary>Set if we use a black screen to turn off the screen</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setBlackScreenMode(bool arg0)
        {
            SourceService["_setBlackScreenMode"].Call(arg0);
        }

        /// <summary>Update browser service</summary>
		/// <returns></returns>
        public bool _update()
        {
            return (bool)SourceService["_update"].Call();
        }

        /// <summary>Uninstall both the launcher and the browser</summary>
		/// <returns></returns>
        public void _uninstallApps()
        {
            SourceService["_uninstallApps"].Call();
        }

        /// <summary>Uninstall the launcher</summary>
		/// <returns></returns>
        public void _uninstallLauncher()
        {
            SourceService["_uninstallLauncher"].Call();
        }

        /// <summary>Uninstall the browser</summary>
		/// <returns></returns>
        public void _uninstallBrowser()
        {
            SourceService["_uninstallBrowser"].Call();
        }

        /// <summary>Wipe all the data</summary>
		/// <returns></returns>
        public void _wipeData()
        {
            SourceService["_wipeData"].Call();
        }

        /// <summary>Restart the browser application</summary>
		/// <returns></returns>
        public void _restart()
        {
            SourceService["_restart"].Call();
        }

        /// <summary>Turn off the tablet</summary>
		/// <returns></returns>
        public void _powerOff()
        {
            SourceService["_powerOff"].Call();
        }

        /// <summary>Install an android APK using an url</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _installApk(string arg0)
        {
            return (bool)SourceService["_installApk"].Call(arg0);
        }

        /// <summary>Launch an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _launchApk(string arg0)
        {
            return (bool)SourceService["_launchApk"].Call(arg0);
        }

        /// <summary>Remove an android APK using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _removeApk(string arg0)
        {
            SourceService["_removeApk"].Call(arg0);
        }

        /// <summary>List all apks on the tablet (return package names)</summary>
		/// <returns></returns>
        public string _listApks()
        {
            return (string)SourceService["_listApks"].Call();
        }

        /// <summary>Stop APK given is package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _stopApk(string arg0)
        {
            SourceService["_stopApk"].Call(arg0);
        }

        /// <summary>Test is apk installed using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isApkExist(string arg0)
        {
            return (bool)SourceService["_isApkExist"].Call(arg0);
        }

        /// <summary>Get apk version using his package name</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string _getApkVersion(string arg0)
        {
            return (string)SourceService["_getApkVersion"].Call(arg0);
        }

        /// <summary>test function</summary>
		/// <returns></returns>
        public string _test()
        {
            return (string)SourceService["_test"].Call();
        }

        /// <summary>Crash the browser</summary>
		/// <returns></returns>
        public void _crash()
        {
            SourceService["_crash"].Call();
        }

        /// <summary>Get last video played error log [DEPRECATED]</summary>
		/// <returns></returns>
        public string GetLastVideoErrorLog()
        {
            return (string)SourceService["getLastVideoErrorLog"].Call();
        }

        /// <summary>Enable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public void EnableWebviewTouch()
        {
            SourceService["enableWebviewTouch"].Call();
        }

        /// <summary>Disable touch signal on webview [DEPRECATED]</summary>
		/// <returns></returns>
        public void DisableWebviewTouch()
        {
            SourceService["disableWebviewTouch"].Call();
        }

        /// <summary>reset to default value [DEPRECATED]</summary>
		/// <returns></returns>
        public void ResetToDefaultValue()
        {
            SourceService["resetToDefaultValue"].Call();
        }

        /// <summary>Stop current apk [DEPRECATED]</summary>
		/// <returns></returns>
        public void _stopApk()
        {
            SourceService["_stopApk"].Call();
        }

        /// <summary>[DEPRECATED]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setLifeDetectorEnabled(bool arg0)
        {
            SourceService["_setLifeDetectorEnabled"].Call(arg0);
        }

    }
}