using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ApiCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module allows you to control NAO's LEDs. It provides simple ways of setting or fading the intensity of single LEDs and groups of LEDs. Groups of LEDs typically include face LEDs, ear LEDs etc. It is also possible to control each LED separately (for example, each of the 8 LEDs in one NAO's eyes).There are three primary colors of LEDs available - red, green and blue, so it is possible to combine them to obtain different colors. The ears contain blue LEDs only.It is possible to control the LED's intensity (between 0 and 100%).</summary>
    public class ALLeds
	{
		internal ALLeds(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALLeds CreateService(IQiSession session)
		{
			var result = new ALLeds(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALLeds CreateUninitializedService(IQiSession session)
		{
			return new ALLeds(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALLeds");
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

        /// <summary>Makes a group name for ease of setting multiple LEDs.</summary>
		/// <param name="arg0_groupName">The name of the group.</param>
		/// <param name="arg1_ledNames">A vector of the names of the LEDs in the group.</param>
		/// <returns></returns>
        public void CreateGroup(string arg0_groupName, IEnumerable<string> arg1_ledNames)
        {
            SourceService["createGroup"].Call(arg0_groupName, arg1_ledNames);
        }

        /// <summary>Makes a group name for ease of setting multiple LEDs.</summary>
		/// <param name="arg0_groupName">The name of the group.</param>
		/// <param name="arg1_ledNames">A vector of the names of the LEDs in the group.</param>
		/// <returns></returns>
        public IQiFuture CreateGroupAsync(string arg0_groupName, IEnumerable<string> arg1_ledNames)
        {
            return SourceService["createGroup"].CallAsync(arg0_groupName, arg1_ledNames);
        }

        /// <summary>An animation to show a direction with the ears.</summary>
		/// <param name="arg0_degrees">The angle you want to show in degrees (int). 0 is up, 90 is forwards, 180 is down and 270 is back.</param>
		/// <param name="arg1_duration">The duration in seconds of the animation.</param>
		/// <param name="arg2_leaveOnAtEnd">If true the last led is left on at the end of the animation.</param>
		/// <returns></returns>
        public void EarLedsSetAngle(int arg0_degrees, float arg1_duration, bool arg2_leaveOnAtEnd)
        {
            SourceService["earLedsSetAngle"].Call(arg0_degrees, arg1_duration, arg2_leaveOnAtEnd);
        }

        /// <summary>An animation to show a direction with the ears.</summary>
		/// <param name="arg0_degrees">The angle you want to show in degrees (int). 0 is up, 90 is forwards, 180 is down and 270 is back.</param>
		/// <param name="arg1_duration">The duration in seconds of the animation.</param>
		/// <param name="arg2_leaveOnAtEnd">If true the last led is left on at the end of the animation.</param>
		/// <returns></returns>
        public IQiFuture EarLedsSetAngleAsync(int arg0_degrees, float arg1_duration, bool arg2_leaveOnAtEnd)
        {
            return SourceService["earLedsSetAngle"].CallAsync(arg0_degrees, arg1_duration, arg2_leaveOnAtEnd);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs within a given time.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <param name="arg2_duration">The duration of the fade in seconds</param>
		/// <returns></returns>
        public void Fade(string arg0_name, float arg1_intensity, float arg2_duration)
        {
            SourceService["fade"].Call(arg0_name, arg1_intensity, arg2_duration);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs within a given time.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <param name="arg2_duration">The duration of the fade in seconds</param>
		/// <returns></returns>
        public IQiFuture FadeAsync(string arg0_name, float arg1_intensity, float arg2_duration)
        {
            return SourceService["fade"].CallAsync(arg0_name, arg1_intensity, arg2_duration);
        }

        /// <summary>Chain a list of color for a device, as the motion.doMove command.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgbList">List of RGB led value, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_timeList">List of time to go to given intensity.</param>
		/// <returns></returns>
        public void FadeListRGB(string arg0_name, object arg1_rgbList, object arg2_timeList)
        {
            SourceService["fadeListRGB"].Call(arg0_name, arg1_rgbList, arg2_timeList);
        }

        /// <summary>Chain a list of color for a device, as the motion.doMove command.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgbList">List of RGB led value, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_timeList">List of time to go to given intensity.</param>
		/// <returns></returns>
        public IQiFuture FadeListRGBAsync(string arg0_name, object arg1_rgbList, object arg2_timeList)
        {
            return SourceService["fadeListRGB"].CallAsync(arg0_name, arg1_rgbList, arg2_timeList);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_red">the intensity of red channel (0-1).</param>
		/// <param name="arg2_green">the intensity of green channel (0-1).</param>
		/// <param name="arg3_blue">the intensity of blue channel (0-1).</param>
		/// <param name="arg4_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, float arg1_red, float arg2_green, float arg3_blue, float arg4_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_red, arg2_green, arg3_blue, arg4_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_red">the intensity of red channel (0-1).</param>
		/// <param name="arg2_green">the intensity of green channel (0-1).</param>
		/// <param name="arg3_blue">the intensity of blue channel (0-1).</param>
		/// <param name="arg4_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public IQiFuture FadeRGBAsync(string arg0_name, float arg1_red, float arg2_green, float arg3_blue, float arg4_duration)
        {
            return SourceService["fadeRGB"].CallAsync(arg0_name, arg1_red, arg2_green, arg3_blue, arg4_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_colorName">the name of the color (supported colors: &quot;white&quot;, &quot;red&quot;, &quot;green&quot;, &quot;blue&quot;, &quot;yellow&quot;, &quot;magenta&quot;, &quot;cyan&quot;)</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, string arg1_colorName, float arg2_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_colorName, arg2_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_colorName">the name of the color (supported colors: &quot;white&quot;, &quot;red&quot;, &quot;green&quot;, &quot;blue&quot;, &quot;yellow&quot;, &quot;magenta&quot;, &quot;cyan&quot;)</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public IQiFuture FadeRGBAsync(string arg0_name, string arg1_colorName, float arg2_duration)
        {
            return SourceService["fadeRGB"].CallAsync(arg0_name, arg1_colorName, arg2_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgb">The RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, int arg1_rgb, float arg2_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_rgb, arg2_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgb">The RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public IQiFuture FadeRGBAsync(string arg0_name, int arg1_rgb, float arg2_duration)
        {
            return SourceService["fadeRGB"].CallAsync(arg0_name, arg1_rgb, arg2_duration);
        }

        /// <summary>Resets the state of the leds to default (for ex, eye LEDs are white and fully on by default).</summary>
		/// <param name="arg0_name">The name of the LED or Group (for now, only &quot;AllLeds&quot; are implemented).</param>
		/// <returns></returns>
        public void Reset(string arg0_name)
        {
            SourceService["reset"].Call(arg0_name);
        }

        /// <summary>Resets the state of the leds to default (for ex, eye LEDs are white and fully on by default).</summary>
		/// <param name="arg0_name">The name of the LED or Group (for now, only &quot;AllLeds&quot; are implemented).</param>
		/// <returns></returns>
        public IQiFuture ResetAsync(string arg0_name)
        {
            return SourceService["reset"].CallAsync(arg0_name);
        }

        /// <summary>Sets an intensity ratio for the leds. If the leds are asked to be set to a specific intensity, the real intensity applied on the leds will be the specific intensity multiplied by this ratio.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity ratio between 0.6 and 1.</param>
		/// <returns></returns>
        public void _setIntensityRatio(string arg0_name, float arg1_intensity)
        {
            SourceService["_setIntensityRatio"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Sets an intensity ratio for the leds. If the leds are asked to be set to a specific intensity, the real intensity applied on the leds will be the specific intensity multiplied by this ratio.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity ratio between 0.6 and 1.</param>
		/// <returns></returns>
        public IQiFuture _setIntensityRatioAsync(string arg0_name, float arg1_intensity)
        {
            return SourceService["_setIntensityRatio"].CallAsync(arg0_name, arg1_intensity);
        }

        /// <summary>Gets the intensity of a LED or device</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns>The intensity of the LED or Group.</returns>
        public IQiResult GetIntensity(string arg0_name)
        {
            return SourceService["getIntensity"].Call<IQiResult>(arg0_name);
        }

        /// <summary>Gets the intensity of a LED or device</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns>The intensity of the LED or Group.</returns>
        public IQiFuture<IQiResult> GetIntensityAsync(string arg0_name)
        {
            return SourceService["getIntensity"].CallAsync<IQiResult>(arg0_name);
        }

        /// <summary>Lists the short LED names.</summary>
		/// <returns>A vector of LED names.</returns>
        public string[] ListLEDs()
        {
            return SourceService["listLEDs"].Call<string[]>();
        }

        /// <summary>Lists the short LED names.</summary>
		/// <returns>A vector of LED names.</returns>
        public IQiFuture<string[]> ListLEDsAsync()
        {
            return SourceService["listLEDs"].CallAsync<string[]>();
        }

        /// <summary>Lists the devices aliased by a short LED name.</summary>
		/// <param name="arg0_name">The name of the LED to list</param>
		/// <returns>A vector of device names.</returns>
        public string[] ListLED(string arg0_name)
        {
            return SourceService["listLED"].Call<string[]>(arg0_name);
        }

        /// <summary>Lists the devices aliased by a short LED name.</summary>
		/// <param name="arg0_name">The name of the LED to list</param>
		/// <returns>A vector of device names.</returns>
        public IQiFuture<string[]> ListLEDAsync(string arg0_name)
        {
            return SourceService["listLED"].CallAsync<string[]>(arg0_name);
        }

        /// <summary>Lists the devices in the group.</summary>
		/// <param name="arg0_groupName">The name of the Group.</param>
		/// <returns>A vector of string device names.</returns>
        public string[] ListGroup(string arg0_groupName)
        {
            return SourceService["listGroup"].Call<string[]>(arg0_groupName);
        }

        /// <summary>Lists the devices in the group.</summary>
		/// <param name="arg0_groupName">The name of the Group.</param>
		/// <returns>A vector of string device names.</returns>
        public IQiFuture<string[]> ListGroupAsync(string arg0_groupName)
        {
            return SourceService["listGroup"].CallAsync<string[]>(arg0_groupName);
        }

        /// <summary>Lists available group names.</summary>
		/// <returns>A vector of group names.</returns>
        public string[] ListGroups()
        {
            return SourceService["listGroups"].Call<string[]>();
        }

        /// <summary>Lists available group names.</summary>
		/// <returns>A vector of group names.</returns>
        public IQiFuture<string[]> ListGroupsAsync()
        {
            return SourceService["listGroups"].CallAsync<string[]>();
        }

        /// <summary>Switch to a minimum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public void Off(string arg0_name)
        {
            SourceService["off"].Call(arg0_name);
        }

        /// <summary>Switch to a minimum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public IQiFuture OffAsync(string arg0_name)
        {
            return SourceService["off"].CallAsync(arg0_name);
        }

        /// <summary>Switch to a maximum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public void On(string arg0_name)
        {
            SourceService["on"].Call(arg0_name);
        }

        /// <summary>Switch to a maximum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public IQiFuture OnAsync(string arg0_name)
        {
            return SourceService["on"].CallAsync(arg0_name);
        }

        /// <summary>Launch a green/yellow/red rasta animation on all body.</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void Rasta(float arg0_duration)
        {
            SourceService["rasta"].Call(arg0_duration);
        }

        /// <summary>Launch a green/yellow/red rasta animation on all body.</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public IQiFuture RastaAsync(float arg0_duration)
        {
            return SourceService["rasta"].CallAsync(arg0_duration);
        }

        /// <summary>Launch a rotation using the leds of the eyes.</summary>
		/// <param name="arg0_rgb">the RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg1_timeForRotation">Approximate time to make one turn.</param>
		/// <param name="arg2_totalDuration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void RotateEyes(int arg0_rgb, float arg1_timeForRotation, float arg2_totalDuration)
        {
            SourceService["rotateEyes"].Call(arg0_rgb, arg1_timeForRotation, arg2_totalDuration);
        }

        /// <summary>Launch a rotation using the leds of the eyes.</summary>
		/// <param name="arg0_rgb">the RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg1_timeForRotation">Approximate time to make one turn.</param>
		/// <param name="arg2_totalDuration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public IQiFuture RotateEyesAsync(int arg0_rgb, float arg1_timeForRotation, float arg2_totalDuration)
        {
            return SourceService["rotateEyes"].CallAsync(arg0_rgb, arg1_timeForRotation, arg2_totalDuration);
        }

        /// <summary>Launch a random animation in eyes</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void RandomEyes(float arg0_duration)
        {
            SourceService["randomEyes"].Call(arg0_duration);
        }

        /// <summary>Launch a random animation in eyes</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public IQiFuture RandomEyesAsync(float arg0_duration)
        {
            return SourceService["randomEyes"].CallAsync(arg0_duration);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public void SetIntensity(string arg0_name, float arg1_intensity)
        {
            SourceService["setIntensity"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public IQiFuture SetIntensityAsync(string arg0_name, float arg1_intensity)
        {
            return SourceService["setIntensity"].CallAsync(arg0_name, arg1_intensity);
        }

        /// <summary>Make the eyes blink once.</summary>
		/// <returns></returns>
        public void _blink()
        {
            SourceService["_blink"].Call();
        }

        /// <summary>Make the eyes blink once.</summary>
		/// <returns></returns>
        public IQiFuture _blinkAsync()
        {
            return SourceService["_blink"].CallAsync();
        }

        /// <summary>Make the eyes blink once with a eyeshadow color.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _blink(int arg0)
        {
            SourceService["_blink"].Call(arg0);
        }

        /// <summary>Make the eyes blink once with a eyeshadow color.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture _blinkAsync(int arg0)
        {
            return SourceService["_blink"].CallAsync(arg0);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs (even chest LED).</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public void _setAnyLedIntensity(string arg0_name, float arg1_intensity)
        {
            SourceService["_setAnyLedIntensity"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs (even chest LED).</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public IQiFuture _setAnyLedIntensityAsync(string arg0_name, float arg1_intensity)
        {
            return SourceService["_setAnyLedIntensity"].CallAsync(arg0_name, arg1_intensity);
        }

        /// <summary>Start passive blinking.</summary>
		/// <returns></returns>
        public void _startPassiveBlinking()
        {
            SourceService["_startPassiveBlinking"].Call();
        }

        /// <summary>Start passive blinking.</summary>
		/// <returns></returns>
        public IQiFuture _startPassiveBlinkingAsync()
        {
            return SourceService["_startPassiveBlinking"].CallAsync();
        }

        /// <summary>Start passive blinking with a eyeshadow color.</summary>
		/// <param name="arg0_eyeShadow">The color of the eye shadow during and after the blink.</param>
		/// <returns></returns>
        public void _startPassiveBlinking(int arg0_eyeShadow)
        {
            SourceService["_startPassiveBlinking"].Call(arg0_eyeShadow);
        }

        /// <summary>Start passive blinking with a eyeshadow color.</summary>
		/// <param name="arg0_eyeShadow">The color of the eye shadow during and after the blink.</param>
		/// <returns></returns>
        public IQiFuture _startPassiveBlinkingAsync(int arg0_eyeShadow)
        {
            return SourceService["_startPassiveBlinking"].CallAsync(arg0_eyeShadow);
        }

        /// <summary>Stop passive blinking.</summary>
		/// <returns></returns>
        public void _stopPassiveBlinking()
        {
            SourceService["_stopPassiveBlinking"].Call();
        }

        /// <summary>Stop passive blinking.</summary>
		/// <returns></returns>
        public IQiFuture _stopPassiveBlinkingAsync()
        {
            return SourceService["_stopPassiveBlinking"].CallAsync();
        }

        /// <summary>Set values for minimum and maximum time waited between two passive blinks.</summary>
		/// <param name="arg0_min">The minimum (should be &gt;= 0)</param>
		/// <param name="arg1_max">The maximum (should be &gt;= min)</param>
		/// <returns></returns>
        public void _setTimeBetweenTwoBlinks(float arg0_min, float arg1_max)
        {
            SourceService["_setTimeBetweenTwoBlinks"].Call(arg0_min, arg1_max);
        }

        /// <summary>Set values for minimum and maximum time waited between two passive blinks.</summary>
		/// <param name="arg0_min">The minimum (should be &gt;= 0)</param>
		/// <param name="arg1_max">The maximum (should be &gt;= min)</param>
		/// <returns></returns>
        public IQiFuture _setTimeBetweenTwoBlinksAsync(float arg0_min, float arg1_max)
        {
            return SourceService["_setTimeBetweenTwoBlinks"].CallAsync(arg0_min, arg1_max);
        }

    }
}