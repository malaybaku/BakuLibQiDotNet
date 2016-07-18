using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>The Animated Speech module makes NAO interpret a text annotated with behaviors.</summary>
    public class ALAnimatedSpeech
	{
		internal ALAnimatedSpeech(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALAnimatedSpeech CreateService(IQiSession session)
		{
			var result = new ALAnimatedSpeech(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALAnimatedSpeech CreateUninitializedService(IQiSession session)
		{
			return new ALAnimatedSpeech(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALAnimatedSpeech");
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

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <returns></returns>
        public void Say(string arg0_text)
        {
            SourceService["say"].Call(arg0_text);
        }

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <returns></returns>
        public IQiFuture SayAsync(string arg0_text)
        {
            return SourceService["say"].CallAsync(arg0_text);
        }

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <param name="arg1_configuration">The animated speech configuration.</param>
		/// <returns></returns>
        public void Say(string arg0_text, object arg1_configuration)
        {
            SourceService["say"].Call(arg0_text, arg1_configuration);
        }

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <param name="arg1_configuration">The animated speech configuration.</param>
		/// <returns></returns>
        public IQiFuture SayAsync(string arg0_text, object arg1_configuration)
        {
            return SourceService["say"].CallAsync(arg0_text, arg1_configuration);
        }

        /// <summary>Reset the Animated Speech configuration.</summary>
		/// <returns></returns>
        public void _reset()
        {
            SourceService["_reset"].Call();
        }

        /// <summary>Reset the Animated Speech configuration.</summary>
		/// <returns></returns>
        public IQiFuture _resetAsync()
        {
            return SourceService["_reset"].CallAsync();
        }

        /// <summary>Stop all the speeches.</summary>
		/// <param name="arg0_blocking">If this method wait for the end of the speeches.</param>
		/// <returns></returns>
        public void _stopAll(bool arg0_blocking)
        {
            SourceService["_stopAll"].Call(arg0_blocking);
        }

        /// <summary>Stop all the speeches.</summary>
		/// <param name="arg0_blocking">If this method wait for the end of the speeches.</param>
		/// <returns></returns>
        public IQiFuture _stopAllAsync(bool arg0_blocking)
        {
            return SourceService["_stopAll"].CallAsync(arg0_blocking);
        }

        /// <summary>Know if animated speech is running.</summary>
		/// <returns>True, if animated speech is running, False otherwise.</returns>
        public bool _isRunning()
        {
            return SourceService["_isRunning"].Call<bool>();
        }

        /// <summary>Know if animated speech is running.</summary>
		/// <returns>True, if animated speech is running, False otherwise.</returns>
        public IQiFuture<bool> _isRunningAsync()
        {
            return SourceService["_isRunning"].CallAsync<bool>();
        }

        /// <summary>DEPRECATED since 1.18: use setBodyLanguageMode instead.Enable or disable the automatic body talk on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetBodyTalkEnabled(bool arg0_enable)
        {
            SourceService["setBodyTalkEnabled"].Call(arg0_enable);
        }

        /// <summary>DEPRECATED since 1.18: use setBodyLanguageMode instead.Enable or disable the automatic body talk on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public IQiFuture SetBodyTalkEnabledAsync(bool arg0_enable)
        {
            return SourceService["setBodyTalkEnabled"].CallAsync(arg0_enable);
        }

        /// <summary>DEPRECATED since 1.22: use setBodyLanguageMode instead.Enable or disable the automatic body language on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetBodyLanguageEnabled(bool arg0_enable)
        {
            SourceService["setBodyLanguageEnabled"].Call(arg0_enable);
        }

        /// <summary>DEPRECATED since 1.22: use setBodyLanguageMode instead.Enable or disable the automatic body language on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public IQiFuture SetBodyLanguageEnabledAsync(bool arg0_enable)
        {
            return SourceService["setBodyLanguageEnabled"].CallAsync(arg0_enable);
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_stringBodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public void SetBodyLanguageModeFromStr(string arg0_stringBodyLanguageMode)
        {
            SourceService["setBodyLanguageModeFromStr"].Call(arg0_stringBodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_stringBodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public IQiFuture SetBodyLanguageModeFromStrAsync(string arg0_stringBodyLanguageMode)
        {
            return SourceService["setBodyLanguageModeFromStr"].CallAsync(arg0_stringBodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_bodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public void SetBodyLanguageMode(uint arg0_bodyLanguageMode)
        {
            SourceService["setBodyLanguageMode"].Call(arg0_bodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_bodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public IQiFuture SetBodyLanguageModeAsync(uint arg0_bodyLanguageMode)
        {
            return SourceService["setBodyLanguageMode"].CallAsync(arg0_bodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public string GetBodyLanguageModeToStr()
        {
            return SourceService["getBodyLanguageModeToStr"].Call<string>();
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public IQiFuture<string> GetBodyLanguageModeToStrAsync()
        {
            return SourceService["getBodyLanguageModeToStr"].CallAsync<string>();
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public uint GetBodyLanguageMode()
        {
            return SourceService["getBodyLanguageMode"].Call<uint>();
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public IQiFuture<uint> GetBodyLanguageModeAsync()
        {
            return SourceService["getBodyLanguageMode"].CallAsync<uint>();
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareAnimationsPackage instead.Add a new package that contains animations.</summary>
		/// <param name="arg0_animationsPackage">The new package that contains animations.</param>
		/// <returns></returns>
        public void DeclareAnimationsPackage(string arg0_animationsPackage)
        {
            SourceService["declareAnimationsPackage"].Call(arg0_animationsPackage);
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareAnimationsPackage instead.Add a new package that contains animations.</summary>
		/// <param name="arg0_animationsPackage">The new package that contains animations.</param>
		/// <returns></returns>
        public IQiFuture DeclareAnimationsPackageAsync(string arg0_animationsPackage)
        {
            return SourceService["declareAnimationsPackage"].CallAsync(arg0_animationsPackage);
        }

        /// <summary>Change the pause's time before the speech.</summary>
		/// <param name="arg0_pause">The pause's time in milliseconds before the speech.</param>
		/// <returns></returns>
        public void _setMSPauseBeforeSpeech(int arg0_pause)
        {
            SourceService["_setMSPauseBeforeSpeech"].Call(arg0_pause);
        }

        /// <summary>Change the pause's time before the speech.</summary>
		/// <param name="arg0_pause">The pause's time in milliseconds before the speech.</param>
		/// <returns></returns>
        public IQiFuture _setMSPauseBeforeSpeechAsync(int arg0_pause)
        {
            return SourceService["_setMSPauseBeforeSpeech"].CallAsync(arg0_pause);
        }

        /// <summary>Get the pause's time before the speech.</summary>
		/// <returns>The pause's time in milliseconds before the speech.</returns>
        public uint _getMSPauseBeforeSpeech()
        {
            return SourceService["_getMSPauseBeforeSpeech"].Call<uint>();
        }

        /// <summary>Get the pause's time before the speech.</summary>
		/// <returns>The pause's time in milliseconds before the speech.</returns>
        public IQiFuture<uint> _getMSPauseBeforeSpeechAsync()
        {
            return SourceService["_getMSPauseBeforeSpeech"].CallAsync<uint>();
        }

        /// <summary>If we need to check the execution times.</summary>
		/// <returns>True, if we need to check the execution times, False otherwise.</returns>
        public bool _isCheckExecutionTimesEnabled()
        {
            return SourceService["_isCheckExecutionTimesEnabled"].Call<bool>();
        }

        /// <summary>If we need to check the execution times.</summary>
		/// <returns>True, if we need to check the execution times, False otherwise.</returns>
        public IQiFuture<bool> _isCheckExecutionTimesEnabledAsync()
        {
            return SourceService["_isCheckExecutionTimesEnabled"].CallAsync<bool>();
        }

        /// <summary>Set if we need to check the execution times.</summary>
		/// <param name="arg0_pause">If we need to check the execution times.</param>
		/// <returns></returns>
        public void _setCheckExecutionTimes(bool arg0_pause)
        {
            SourceService["_setCheckExecutionTimes"].Call(arg0_pause);
        }

        /// <summary>Set if we need to check the execution times.</summary>
		/// <param name="arg0_pause">If we need to check the execution times.</param>
		/// <returns></returns>
        public IQiFuture _setCheckExecutionTimesAsync(bool arg0_pause)
        {
            return SourceService["_setCheckExecutionTimes"].CallAsync(arg0_pause);
        }

        /// <summary>Add some new links between tags and words.</summary>
		/// <param name="arg0_tagsToWords">Map of tags to words.</param>
		/// <returns></returns>
        public void AddTagsToWords(object arg0_tagsToWords)
        {
            SourceService["addTagsToWords"].Call(arg0_tagsToWords);
        }

        /// <summary>Add some new links between tags and words.</summary>
		/// <param name="arg0_tagsToWords">Map of tags to words.</param>
		/// <returns></returns>
        public IQiFuture AddTagsToWordsAsync(object arg0_tagsToWords)
        {
            return SourceService["addTagsToWords"].CallAsync(arg0_tagsToWords);
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareTagForAnimations instead.Declare some tags with the associated animations.</summary>
		/// <param name="arg0_tagsToAnimations">Map of Tags to Animations.</param>
		/// <returns></returns>
        public void DeclareTagForAnimations(object arg0_tagsToAnimations)
        {
            SourceService["declareTagForAnimations"].Call(arg0_tagsToAnimations);
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareTagForAnimations instead.Declare some tags with the associated animations.</summary>
		/// <param name="arg0_tagsToAnimations">Map of Tags to Animations.</param>
		/// <returns></returns>
        public IQiFuture DeclareTagForAnimationsAsync(object arg0_tagsToAnimations)
        {
            return SourceService["declareTagForAnimations"].CallAsync(arg0_tagsToAnimations);
        }

        /// <summary>Print many debug informations about the current state of animated speech.</summary>
		/// <returns></returns>
        public void _diagnosis()
        {
            SourceService["_diagnosis"].Call();
        }

        /// <summary>Print many debug informations about the current state of animated speech.</summary>
		/// <returns></returns>
        public IQiFuture _diagnosisAsync()
        {
            return SourceService["_diagnosis"].CallAsync();
        }

        /// <summary>DEPRECATED since 1.18: use getBodyLanguageMode instead.Indicate if the body talk is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public bool IsBodyTalkEnabled()
        {
            return SourceService["isBodyTalkEnabled"].Call<bool>();
        }

        /// <summary>DEPRECATED since 1.18: use getBodyLanguageMode instead.Indicate if the body talk is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public IQiFuture<bool> IsBodyTalkEnabledAsync()
        {
            return SourceService["isBodyTalkEnabled"].CallAsync<bool>();
        }

        /// <summary>DEPRECATED since 1.22: use getBodyLanguageMode instead.Indicate if the body language is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public bool IsBodyLanguageEnabled()
        {
            return SourceService["isBodyLanguageEnabled"].Call<bool>();
        }

        /// <summary>DEPRECATED since 1.22: use getBodyLanguageMode instead.Indicate if the body language is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public IQiFuture<bool> IsBodyLanguageEnabledAsync()
        {
            return SourceService["isBodyLanguageEnabled"].CallAsync<bool>();
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get tags found on installed animations which are in &quot;animation library&quot;.</summary>
		/// <returns>The list of tags found.</returns>
        public string[] _getTagList()
        {
            return SourceService["_getTagList"].Call<string[]>();
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get tags found on installed animations which are in &quot;animation library&quot;.</summary>
		/// <returns>The list of tags found.</returns>
        public IQiFuture<string[]> _getTagListAsync()
        {
            return SourceService["_getTagList"].CallAsync<string[]>();
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get all installed animations for a tag. Currently: animations = &quot;behaviors of the animation library.&quot;</summary>
		/// <param name="arg0_tag">A tag to filter the list of animations with.</param>
		/// <returns>The animation list.</returns>
        public string[] _getAnimationsByTag(string arg0_tag)
        {
            return SourceService["_getAnimationsByTag"].Call<string[]>(arg0_tag);
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get all installed animations for a tag. Currently: animations = &quot;behaviors of the animation library.&quot;</summary>
		/// <param name="arg0_tag">A tag to filter the list of animations with.</param>
		/// <returns>The animation list.</returns>
        public IQiFuture<string[]> _getAnimationsByTagAsync(string arg0_tag)
        {
            return SourceService["_getAnimationsByTag"].CallAsync<string[]>(arg0_tag);
        }

        /// <summary>Callback for ALMemory subscription for speech bookmark tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _speechBookMarkCallback(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            SourceService["_speechBookMarkCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Callback for ALMemory subscription for speech bookmark tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public IQiFuture _speechBookMarkCallbackAsync(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            return SourceService["_speechBookMarkCallback"].CallAsync(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Method called by the tts when &quot;mrkpause&quot; bookmark is reached.This method is blocking until the action is finish.</summary>
		/// <param name="arg0_pBookmark">Id of the bookmark.</param>
		/// <returns></returns>
        public void _mrkpauseCallback(uint arg0_pBookmark)
        {
            SourceService["_mrkpauseCallback"].Call(arg0_pBookmark);
        }

        /// <summary>Method called by the tts when &quot;mrkpause&quot; bookmark is reached.This method is blocking until the action is finish.</summary>
		/// <param name="arg0_pBookmark">Id of the bookmark.</param>
		/// <returns></returns>
        public IQiFuture _mrkpauseCallbackAsync(uint arg0_pBookmark)
        {
            return SourceService["_mrkpauseCallback"].CallAsync(arg0_pBookmark);
        }

        /// <summary>Callback for ALMemory subscription for speech status tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _speechStatusCallback(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            SourceService["_speechStatusCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Callback for ALMemory subscription for speech status tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public IQiFuture _speechStatusCallbackAsync(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            return SourceService["_speechStatusCallback"].CallAsync(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Callback for ALMemory subscription to postureFamilyChanged.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _postureFamilyChangedCallback(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            SourceService["_postureFamilyChangedCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Callback for ALMemory subscription to postureFamilyChanged.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public IQiFuture _postureFamilyChangedCallbackAsync(string arg0_memoryKey, object arg1_value, string arg2_message)
        {
            return SourceService["_postureFamilyChangedCallback"].CallAsync(arg0_memoryKey, arg1_value, arg2_message);
        }

    }
}