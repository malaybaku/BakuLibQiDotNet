using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Frame manager is used to play choregraphe projects in naoqi. It needs Choregraphe projects in input and will return an ID for each project. It can also only read a given box/timeline in a complex behavior.</summary>
    public class ALFrameManager
	{
		internal ALFrameManager(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALFrameManager CreateService(IQiSession session)
		{
			var result = new ALFrameManager(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALFrameManager CreateUninitializedService(IQiSession session)
		{
			return new ALFrameManager(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALFrameManager");
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

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot. DEPRECATED since 2.3</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_behName"></param>
		/// <returns>return a unique identifier for the created box (the box URI), that can be used by playBehavior</returns>
        public string NewBehaviorFromFile(string arg0_xmlFilePath, string arg1_behName)
        {
            return SourceService["newBehaviorFromFile"].Call<string>(arg0_xmlFilePath, arg1_behName);
        }

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot. DEPRECATED since 2.3</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_behName"></param>
		/// <returns>return a unique identifier for the created box (the box URI), that can be used by playBehavior</returns>
        public IQiFuture<string> NewBehaviorFromFileAsync(string arg0_xmlFilePath, string arg1_behName)
        {
            return SourceService["newBehaviorFromFile"].CallAsync<string>(arg0_xmlFilePath, arg1_behName);
        }

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot.</summary>
		/// <param name="arg0_packageDir"> the base directory of the behavior's package, eg: &quot;/home/myApp&quot;.</param>
		/// <param name="arg1_behaviorPath">the relative path of the behavior inside the package, eg: &quot;/behavior_1/behavior.xar&quot;.</param>
		/// <param name="arg2_behName"></param>
		/// <returns>return a unique identifier for the created box, that can be used by playBehavior</returns>
        public string CreateBehavior(string arg0_packageDir, string arg1_behaviorPath, string arg2_behName)
        {
            return SourceService["createBehavior"].Call<string>(arg0_packageDir, arg1_behaviorPath, arg2_behName);
        }

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot.</summary>
		/// <param name="arg0_packageDir"> the base directory of the behavior's package, eg: &quot;/home/myApp&quot;.</param>
		/// <param name="arg1_behaviorPath">the relative path of the behavior inside the package, eg: &quot;/behavior_1/behavior.xar&quot;.</param>
		/// <param name="arg2_behName"></param>
		/// <returns>return a unique identifier for the created box, that can be used by playBehavior</returns>
        public IQiFuture<string> CreateBehaviorAsync(string arg0_packageDir, string arg1_behaviorPath, string arg2_behName)
        {
            return SourceService["createBehavior"].CallAsync<string>(arg0_packageDir, arg1_behaviorPath, arg2_behName);
        }

        /// <summary>Creates a new behavior, from the current Choregraphe behavior 0(uploaded to /tmp/currentChoregrapheBehavior/behavior.xar). DEPRECATED since 1.14</summary>
		/// <returns>return a unique identifier for the created behavior (the box URI)</returns>
        public string NewBehaviorFromChoregraphe()
        {
            return SourceService["newBehaviorFromChoregraphe"].Call<string>();
        }

        /// <summary>Creates a new behavior, from the current Choregraphe behavior 0(uploaded to /tmp/currentChoregrapheBehavior/behavior.xar). DEPRECATED since 1.14</summary>
		/// <returns>return a unique identifier for the created behavior (the box URI)</returns>
        public IQiFuture<string> NewBehaviorFromChoregrapheAsync()
        {
            return SourceService["newBehaviorFromChoregraphe"].CallAsync<string>();
        }

        /// <summary>It will play a behavior and block until the behavior is finished. Note that it can block forever if the behavior output is never called.</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void CompleteBehavior(string arg0_id)
        {
            SourceService["completeBehavior"].Call(arg0_id);
        }

        /// <summary>It will play a behavior and block until the behavior is finished. Note that it can block forever if the behavior output is never called.</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public IQiFuture CompleteBehaviorAsync(string arg0_id)
        {
            return SourceService["completeBehavior"].CallAsync(arg0_id);
        }

        /// <summary>Deletes a behavior (meaning a box). Stop the whole behavior contained in this box first.</summary>
		/// <param name="arg0_id">The id of the box to delete (the box URI).</param>
		/// <returns></returns>
        public void DeleteBehavior(string arg0_id)
        {
            SourceService["deleteBehavior"].Call(arg0_id);
        }

        /// <summary>Deletes a behavior (meaning a box). Stop the whole behavior contained in this box first.</summary>
		/// <param name="arg0_id">The id of the box to delete (the box URI).</param>
		/// <returns></returns>
        public IQiFuture DeleteBehaviorAsync(string arg0_id)
        {
            return SourceService["deleteBehavior"].CallAsync(arg0_id);
        }

        /// <summary>Starts a behavior</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void PlayBehavior(string arg0_id)
        {
            SourceService["playBehavior"].Call(arg0_id);
        }

        /// <summary>Starts a behavior</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public IQiFuture PlayBehaviorAsync(string arg0_id)
        {
            return SourceService["playBehavior"].CallAsync(arg0_id);
        }

        /// <summary>Exit the reading of a timeline contained in a given box</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void ExitBehavior(string arg0_id)
        {
            SourceService["exitBehavior"].Call(arg0_id);
        }

        /// <summary>Exit the reading of a timeline contained in a given box</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public IQiFuture ExitBehaviorAsync(string arg0_id)
        {
            return SourceService["exitBehavior"].CallAsync(arg0_id);
        }

        /// <summary>Tells whether the behavior is running</summary>
		/// <param name="arg0_id">The id of the behavior to check (The URI of the root box).</param>
		/// <returns>True if the behavior is running, false otherwise</returns>
        public bool IsBehaviorRunning(string arg0_id)
        {
            return SourceService["isBehaviorRunning"].Call<bool>(arg0_id);
        }

        /// <summary>Tells whether the behavior is running</summary>
		/// <param name="arg0_id">The id of the behavior to check (The URI of the root box).</param>
		/// <returns>True if the behavior is running, false otherwise</returns>
        public IQiFuture<bool> IsBehaviorRunningAsync(string arg0_id)
        {
            return SourceService["isBehaviorRunning"].CallAsync<bool>(arg0_id);
        }

        /// <summary>Stop playing any behavior in FrameManager, and delete all of them.</summary>
		/// <returns></returns>
        public void CleanBehaviors()
        {
            SourceService["cleanBehaviors"].Call();
        }

        /// <summary>Stop playing any behavior in FrameManager, and delete all of them.</summary>
		/// <returns></returns>
        public IQiFuture CleanBehaviorsAsync()
        {
            return SourceService["cleanBehaviors"].CallAsync();
        }

        /// <summary>Returns a playing behavior absolute path.</summary>
		/// <param name="arg0_id">The id of the behavior (The URI of the root box).</param>
		/// <returns>Returns the absolute path of given behavior.</returns>
        public string GetBehaviorPath(string arg0_id)
        {
            return SourceService["getBehaviorPath"].Call<string>(arg0_id);
        }

        /// <summary>Returns a playing behavior absolute path.</summary>
		/// <param name="arg0_id">The id of the behavior (The URI of the root box).</param>
		/// <returns>Returns the absolute path of given behavior.</returns>
        public IQiFuture<string> GetBehaviorPathAsync(string arg0_id)
        {
            return SourceService["getBehaviorPath"].CallAsync<string>(arg0_id);
        }

        /// <summary>Creates a timeline.</summary>
		/// <param name="arg0_timelineContent">The timeline content (in XML format).</param>
		/// <returns>return a unique identifier for the created box that contains the timeline. You must call deleteBehavior on it at some point. DEPRECATED since 1.14</returns>
        public string CreateTimeline(string arg0_timelineContent)
        {
            return SourceService["createTimeline"].Call<string>(arg0_timelineContent);
        }

        /// <summary>Creates a timeline.</summary>
		/// <param name="arg0_timelineContent">The timeline content (in XML format).</param>
		/// <returns>return a unique identifier for the created box that contains the timeline. You must call deleteBehavior on it at some point. DEPRECATED since 1.14</returns>
        public IQiFuture<string> CreateTimelineAsync(string arg0_timelineContent)
        {
            return SourceService["createTimeline"].CallAsync<string>(arg0_timelineContent);
        }

        /// <summary>Starts playing a timeline contained in a given box. If the box is a flow diagram, it will look for the first onStart input of type Bang, and stimulate it ! DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public void PlayTimeline(string arg0_id)
        {
            SourceService["playTimeline"].Call(arg0_id);
        }

        /// <summary>Starts playing a timeline contained in a given box. If the box is a flow diagram, it will look for the first onStart input of type Bang, and stimulate it ! DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public IQiFuture PlayTimelineAsync(string arg0_id)
        {
            return SourceService["playTimeline"].CallAsync(arg0_id);
        }

        /// <summary>Stops playing a timeline contained in a given box, at the current frame. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public void StopTimeline(string arg0_id)
        {
            SourceService["stopTimeline"].Call(arg0_id);
        }

        /// <summary>Stops playing a timeline contained in a given box, at the current frame. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public IQiFuture StopTimelineAsync(string arg0_id)
        {
            return SourceService["stopTimeline"].CallAsync(arg0_id);
        }

        /// <summary>Sets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <param name="arg1_fps">The FPS to set.</param>
		/// <returns></returns>
        public void SetTimelineFps(string arg0_id, int arg1_fps)
        {
            SourceService["setTimelineFps"].Call(arg0_id, arg1_fps);
        }

        /// <summary>Sets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <param name="arg1_fps">The FPS to set.</param>
		/// <returns></returns>
        public IQiFuture SetTimelineFpsAsync(string arg0_id, int arg1_fps)
        {
            return SourceService["setTimelineFps"].CallAsync(arg0_id, arg1_fps);
        }

        /// <summary>Gets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <returns>Returns the timeline's FPS.</returns>
        public int GetTimelineFps(string arg0_id)
        {
            return SourceService["getTimelineFps"].Call<int>(arg0_id);
        }

        /// <summary>Gets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <returns>Returns the timeline's FPS.</returns>
        public IQiFuture<int> GetTimelineFpsAsync(string arg0_id)
        {
            return SourceService["getTimelineFps"].CallAsync<int>(arg0_id);
        }

        /// <summary>Returns in seconds, the duration of a given movement stored in a box. Returns 0 if the behavior has no motion layers.  DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns>Returns the time in seconds.</returns>
        public float GetMotionLength(string arg0_id)
        {
            return SourceService["getMotionLength"].Call<float>(arg0_id);
        }

        /// <summary>Returns in seconds, the duration of a given movement stored in a box. Returns 0 if the behavior has no motion layers.  DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns>Returns the time in seconds.</returns>
        public IQiFuture<float> GetMotionLengthAsync(string arg0_id)
        {
            return SourceService["getMotionLength"].CallAsync<float>(arg0_id);
        }

        /// <summary>List all behaviors currently handled by the frame manager.</summary>
		/// <returns>a set listing all behavior ids</returns>
        public string[] Behaviors()
        {
            return SourceService["behaviors"].Call<string[]>();
        }

        /// <summary>List all behaviors currently handled by the frame manager.</summary>
		/// <returns>a set listing all behavior ids</returns>
        public IQiFuture<string[]> BehaviorsAsync()
        {
            return SourceService["behaviors"].CallAsync<string[]>();
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public void GotoAndStop(string arg0_id, string arg1_frame)
        {
            SourceService["gotoAndStop"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public IQiFuture GotoAndStopAsync(string arg0_id, string arg1_frame)
        {
            return SourceService["gotoAndStop"].CallAsync(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public void GotoAndStop(string arg0_id, int arg1_frame)
        {
            SourceService["gotoAndStop"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public IQiFuture GotoAndStopAsync(string arg0_id, int arg1_frame)
        {
            return SourceService["gotoAndStop"].CallAsync(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public void GotoAndPlay(string arg0_id, string arg1_frame)
        {
            SourceService["gotoAndPlay"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public IQiFuture GotoAndPlayAsync(string arg0_id, string arg1_frame)
        {
            return SourceService["gotoAndPlay"].CallAsync(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public void GotoAndPlay(string arg0_id, int arg1_frame)
        {
            SourceService["gotoAndPlay"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public IQiFuture GotoAndPlayAsync(string arg0_id, int arg1_frame)
        {
            return SourceService["gotoAndPlay"].CallAsync(arg0_id, arg1_frame);
        }

        /// <summary>Called by ALMemory when subcription data is updated. INTERNAL</summary>
		/// <param name="arg0_dataName">Name of the subscribed data.</param>
		/// <param name="arg1_data">Value of the the subscribed data</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public void _dataChanged(string arg0_dataName, object arg1_data, string arg2_message)
        {
            SourceService["_dataChanged"].Call(arg0_dataName, arg1_data, arg2_message);
        }

        /// <summary>Called by ALMemory when subcription data is updated. INTERNAL</summary>
		/// <param name="arg0_dataName">Name of the subscribed data.</param>
		/// <param name="arg1_data">Value of the the subscribed data</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public IQiFuture _dataChangedAsync(string arg0_dataName, object arg1_data, string arg2_message)
        {
            return SourceService["_dataChanged"].CallAsync(arg0_dataName, arg1_data, arg2_message);
        }

        /// <summary>method called by almemory to inform framemanager that a box is subscribing to an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_message">the associated message</param>
		/// <param name="arg3_callback">the name of the box's callback to call</param>
		/// <param name="arg4_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public void _subscribeBoxToEvent(string arg0_eventName, string arg1_boxName, string arg2_message, string arg3_callback, bool arg4_micro)
        {
            SourceService["_subscribeBoxToEvent"].Call(arg0_eventName, arg1_boxName, arg2_message, arg3_callback, arg4_micro);
        }

        /// <summary>method called by almemory to inform framemanager that a box is subscribing to an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_message">the associated message</param>
		/// <param name="arg3_callback">the name of the box's callback to call</param>
		/// <param name="arg4_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public IQiFuture _subscribeBoxToEventAsync(string arg0_eventName, string arg1_boxName, string arg2_message, string arg3_callback, bool arg4_micro)
        {
            return SourceService["_subscribeBoxToEvent"].CallAsync(arg0_eventName, arg1_boxName, arg2_message, arg3_callback, arg4_micro);
        }

        /// <summary>method called by almemory to inform framemanager that a box is unsubscribing from an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public void _unsubscribeBoxToEvent(string arg0_eventName, string arg1_boxName, bool arg2_micro)
        {
            SourceService["_unsubscribeBoxToEvent"].Call(arg0_eventName, arg1_boxName, arg2_micro);
        }

        /// <summary>method called by almemory to inform framemanager that a box is unsubscribing from an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public IQiFuture _unsubscribeBoxToEventAsync(string arg0_eventName, string arg1_boxName, bool arg2_micro)
        {
            return SourceService["_unsubscribeBoxToEvent"].CallAsync(arg0_eventName, arg1_boxName, arg2_micro);
        }

        /// <summary></summary>
		/// <param name="arg0_eventName"></param>
		/// <param name="arg1_value"></param>
		/// <param name="arg2_message"></param>
		/// <returns></returns>
        public void _boxDataChanged(string arg0_eventName, object arg1_value, string arg2_message)
        {
            SourceService["_boxDataChanged"].Call(arg0_eventName, arg1_value, arg2_message);
        }

        /// <summary></summary>
		/// <param name="arg0_eventName"></param>
		/// <param name="arg1_value"></param>
		/// <param name="arg2_message"></param>
		/// <returns></returns>
        public IQiFuture _boxDataChangedAsync(string arg0_eventName, object arg1_value, string arg2_message)
        {
            return SourceService["_boxDataChanged"].CallAsync(arg0_eventName, arg1_value, arg2_message);
        }

        /// <summary>Start recording some performance data.</summary>
		/// <returns></returns>
        public void _startBenchmark()
        {
            SourceService["_startBenchmark"].Call();
        }

        /// <summary>Start recording some performance data.</summary>
		/// <returns></returns>
        public IQiFuture _startBenchmarkAsync()
        {
            return SourceService["_startBenchmark"].CallAsync();
        }

        /// <summary>Stop performance data recording, and return a summary.</summary>
		/// <returns>Returns a textual report of the recorded performance data.</returns>
        public string _stopBenchmark()
        {
            return SourceService["_stopBenchmark"].Call<string>();
        }

        /// <summary>Stop performance data recording, and return a summary.</summary>
		/// <returns>Returns a textual report of the recorded performance data.</returns>
        public IQiFuture<string> _stopBenchmarkAsync()
        {
            return SourceService["_stopBenchmark"].CallAsync<string>();
        }

        /// <summary>Creates a new box found in an xml file stored in the robot, without loading it, and without auto-delete on stop. (used by link box)</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_path">The path to reach the box to instantiate in the project (&quot;&quot; if root).</param>
		/// <returns>return a unique identifier for the created box (the URI of the box), that can be used by playBehavior</returns>
        public string _newBoxFromFile(string arg0_xmlFilePath, string arg1_path)
        {
            return SourceService["_newBoxFromFile"].Call<string>(arg0_xmlFilePath, arg1_path);
        }

        /// <summary>Creates a new box found in an xml file stored in the robot, without loading it, and without auto-delete on stop. (used by link box)</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_path">The path to reach the box to instantiate in the project (&quot;&quot; if root).</param>
		/// <returns>return a unique identifier for the created box (the URI of the box), that can be used by playBehavior</returns>
        public IQiFuture<string> _newBoxFromFileAsync(string arg0_xmlFilePath, string arg1_path)
        {
            return SourceService["_newBoxFromFile"].CallAsync<string>(arg0_xmlFilePath, arg1_path);
        }

        /// <summary>wait for a previously started behavior is stopped</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior to wait for (the URI of the root box)</param>
		/// <returns></returns>
        public void _waitForStopped(string arg0_fmid)
        {
            SourceService["_waitForStopped"].Call(arg0_fmid);
        }

        /// <summary>wait for a previously started behavior is stopped</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior to wait for (the URI of the root box)</param>
		/// <returns></returns>
        public IQiFuture _waitForStoppedAsync(string arg0_fmid)
        {
            return SourceService["_waitForStopped"].CallAsync(arg0_fmid);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public void _onPreferenceUpdated(string arg0_key, object arg1_value, string arg2_message)
        {
            SourceService["_onPreferenceUpdated"].Call(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public IQiFuture _onPreferenceUpdatedAsync(string arg0_key, object arg1_value, string arg2_message)
        {
            return SourceService["_onPreferenceUpdated"].CallAsync(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public void _onPreferencesSynchronized(string arg0_key, object arg1_value, string arg2_message)
        {
            SourceService["_onPreferencesSynchronized"].Call(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public IQiFuture _onPreferencesSynchronizedAsync(string arg0_key, object arg1_value, string arg2_message)
        {
            return SourceService["_onPreferencesSynchronized"].CallAsync(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>called by behaviors when an error occured</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior that failed (the URI of the root box)</param>
		/// <param name="arg1_boxid">the identifier of the box that failed (the URI of the box).</param>
		/// <param name="arg2_error">the error message</param>
		/// <returns></returns>
        public void _reportError(string arg0_fmid, string arg1_boxid, string arg2_error)
        {
            SourceService["_reportError"].Call(arg0_fmid, arg1_boxid, arg2_error);
        }

        /// <summary>called by behaviors when an error occured</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior that failed (the URI of the root box)</param>
		/// <param name="arg1_boxid">the identifier of the box that failed (the URI of the box).</param>
		/// <param name="arg2_error">the error message</param>
		/// <returns></returns>
        public IQiFuture _reportErrorAsync(string arg0_fmid, string arg1_boxid, string arg2_error)
        {
            return SourceService["_reportError"].CallAsync(arg0_fmid, arg1_boxid, arg2_error);
        }

        /// <summary>get an object tracking transitions in a behavior</summary>
		/// <param name="arg0_behavior">name of the behavior (the URI of the root box)</param>
		/// <returns></returns>
        public IQiSignal GetBehaviorDebuggerFor(string arg0_behavior)
        {
            return SourceService["getBehaviorDebuggerFor"].Call<IQiSignal>(arg0_behavior);
        }

        /// <summary>get an object tracking transitions in a behavior</summary>
		/// <param name="arg0_behavior">name of the behavior (the URI of the root box)</param>
		/// <returns></returns>
        public IQiFuture<IQiSignal> GetBehaviorDebuggerForAsync(string arg0_behavior)
        {
            return SourceService["getBehaviorDebuggerFor"].CallAsync<IQiSignal>(arg0_behavior);
        }

        /// <summary>get a box as an object</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <returns></returns>
        public IQiSignal GetBox(string arg0_box)
        {
            return SourceService["getBox"].Call<IQiSignal>(arg0_box);
        }

        /// <summary>get a box as an object</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <returns></returns>
        public IQiFuture<IQiSignal> GetBoxAsync(string arg0_box)
        {
            return SourceService["getBox"].CallAsync<IQiSignal>(arg0_box);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg">input argument</param>
		/// <returns></returns>
        public IQiResult CallBoxInput(string arg0_box, string arg1_method, object arg2_arg)
        {
            return SourceService["callBoxInput"].Call<IQiResult>(arg0_box, arg1_method, arg2_arg);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg">input argument</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> CallBoxInputAsync(string arg0_box, string arg1_method, object arg2_arg)
        {
            return SourceService["callBoxInput"].CallAsync<IQiResult>(arg0_box, arg1_method, arg2_arg);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box). A box URI is of the format 'behavior_name:/diagram_1/box_2'</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg1">input argument</param>
		/// <param name="arg3_arg2">input argument</param>
		/// <returns></returns>
        public IQiResult CallBoxInput(string arg0_box, string arg1_method, object arg2_arg1, object arg3_arg2)
        {
            return SourceService["callBoxInput"].Call<IQiResult>(arg0_box, arg1_method, arg2_arg1, arg3_arg2);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box). A box URI is of the format 'behavior_name:/diagram_1/box_2'</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg1">input argument</param>
		/// <param name="arg3_arg2">input argument</param>
		/// <returns></returns>
        public IQiFuture<IQiResult> CallBoxInputAsync(string arg0_box, string arg1_method, object arg2_arg1, object arg3_arg2)
        {
            return SourceService["callBoxInput"].CallAsync<IQiResult>(arg0_box, arg1_method, arg2_arg1, arg3_arg2);
        }

    }
}