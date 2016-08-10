using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALVisionRecognition is a module which detects and recognizes learned pictures, like pages of a comic books, faces of objects or even locations.The learning stage is done using the Choregraphe interface. Follow the steps in the green doc that will explain how to create your own database.The output value is written in ALMemory in the PictureDetected variable.It contains an array of tags, with the following format:  [ [ TimeStampField ] [ Picture_info_0 , Picture _info_1, . . . , Picture_info_N-1 ] ]  with as many Picture_info tags as things currently recognized. Picture_info = [[labels_list], matched_keypoints, ratio, [boundary_points]] with labels_list = [label_0, label_1, ..., label_N-1] and label_n belongs to label_n+1 and boundary_points = [[x0,y0], [x1,y1], ..., [xN,yN]]  - Labels are the names given to the picture (e.g. &quot;cover/my book&quot;, or &quot;fridge corner/kitchen/my flat&quot;). - matched_keypoints corresponds to the number of keypoints retrieved in the current frame. - ratio represents the number of keypoints found for the object in the current frame divided by the number of keypoints found during the learning stage. - boundary_points is a list of points coordinates in angle values representing the reprojection in the current image of the boundaries selected during the learning stage. </summary>
    public class ALVisionRecognition
	{
		internal ALVisionRecognition(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVisionRecognition CreateService(IQiSession session)
		{
			var result = new ALVisionRecognition(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALVisionRecognition CreateUninitializedService(IQiSession session)
		{
			return new ALVisionRecognition(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALVisionRecognition");
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

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds) if relevant.</param>
		/// <param name="arg2_precision">Precision of the extractor if relevant.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name, int arg1_period, float arg2_precision)
        {
            SourceService["subscribe"].Call(arg0_name, arg1_period, arg2_precision);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds) if relevant.</param>
		/// <param name="arg2_precision">Precision of the extractor if relevant.</param>
		/// <returns></returns>
        public IQiFuture SubscribeAsync(string arg0_name, int arg1_period, float arg2_precision)
        {
            return SourceService["subscribe"].CallAsync(arg0_name, arg1_period, arg2_precision);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name)
        {
            SourceService["subscribe"].Call(arg0_name);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <returns></returns>
        public IQiFuture SubscribeAsync(string arg0_name)
        {
            return SourceService["subscribe"].CallAsync(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public void Unsubscribe(string arg0_name)
        {
            SourceService["unsubscribe"].Call(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public IQiFuture UnsubscribeAsync(string arg0_name)
        {
            return SourceService["unsubscribe"].CallAsync(arg0_name);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public void UpdatePeriod(string arg0_name, int arg1_period)
        {
            SourceService["updatePeriod"].Call(arg0_name, arg1_period);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public IQiFuture UpdatePeriodAsync(string arg0_name, int arg1_period)
        {
            return SourceService["updatePeriod"].CallAsync(arg0_name, arg1_period);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public void UpdatePrecision(string arg0_name, float arg1_precision)
        {
            SourceService["updatePrecision"].Call(arg0_name, arg1_precision);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public IQiFuture UpdatePrecisionAsync(string arg0_name, float arg1_precision)
        {
            return SourceService["updatePrecision"].CallAsync(arg0_name, arg1_precision);
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetCurrentPeriod()
        {
            return SourceService["getCurrentPeriod"].Call<int>();
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public IQiFuture<int> GetCurrentPeriodAsync()
        {
            return SourceService["getCurrentPeriod"].CallAsync<int>();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public float GetCurrentPrecision()
        {
            return SourceService["getCurrentPrecision"].Call<float>();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public IQiFuture<float> GetCurrentPrecisionAsync()
        {
            return SourceService["getCurrentPrecision"].CallAsync<float>();
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetMyPeriod(string arg0_name)
        {
            return SourceService["getMyPeriod"].Call<int>(arg0_name);
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public IQiFuture<int> GetMyPeriodAsync(string arg0_name)
        {
            return SourceService["getMyPeriod"].CallAsync<int>(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public float GetMyPrecision(string arg0_name)
        {
            return SourceService["getMyPrecision"].Call<float>(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public IQiFuture<float> GetMyPrecisionAsync(string arg0_name)
        {
            return SourceService["getMyPrecision"].CallAsync<float>(arg0_name);
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public IQiResult GetSubscribersInfo()
        {
            return SourceService["getSubscribersInfo"].Call<IQiResult>();
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public IQiFuture<IQiResult> GetSubscribersInfoAsync()
        {
            return SourceService["getSubscribersInfo"].CallAsync<IQiResult>();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public string[] GetOutputNames()
        {
            return SourceService["getOutputNames"].Call<string[]>();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetOutputNamesAsync()
        {
            return SourceService["getOutputNames"].CallAsync<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetEventList()
        {
            return SourceService["getEventList"].Call<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetEventListAsync()
        {
            return SourceService["getEventList"].CallAsync<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetMemoryKeyList()
        {
            return SourceService["getMemoryKeyList"].Call<string[]>();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public IQiFuture<string[]> GetMemoryKeyListAsync()
        {
            return SourceService["getMemoryKeyList"].CallAsync<string[]>();
        }

        /// <summary>Sets the extractor framerate for a chosen subscriber</summary>
		/// <param name="arg0_subscriberName">Name of the subcriber</param>
		/// <param name="arg1_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(string arg0_subscriberName, int arg1_framerate)
        {
            return SourceService["setFrameRate"].Call<bool>(arg0_subscriberName, arg1_framerate);
        }

        /// <summary>Sets the extractor framerate for a chosen subscriber</summary>
		/// <param name="arg0_subscriberName">Name of the subcriber</param>
		/// <param name="arg1_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public IQiFuture<bool> SetFrameRateAsync(string arg0_subscriberName, int arg1_framerate)
        {
            return SourceService["setFrameRate"].CallAsync<bool>(arg0_subscriberName, arg1_framerate);
        }

        /// <summary>Sets the extractor framerate for all the subscribers</summary>
		/// <param name="arg0_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(int arg0_framerate)
        {
            return SourceService["setFrameRate"].Call<bool>(arg0_framerate);
        }

        /// <summary>Sets the extractor framerate for all the subscribers</summary>
		/// <param name="arg0_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public IQiFuture<bool> SetFrameRateAsync(int arg0_framerate)
        {
            return SourceService["setFrameRate"].CallAsync<bool>(arg0_framerate);
        }

        /// <summary>Sets extractor resolution</summary>
		/// <param name="arg0_resolution">New resolution</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetResolution(int arg0_resolution)
        {
            return SourceService["setResolution"].Call<bool>(arg0_resolution);
        }

        /// <summary>Sets extractor resolution</summary>
		/// <param name="arg0_resolution">New resolution</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public IQiFuture<bool> SetResolutionAsync(int arg0_resolution)
        {
            return SourceService["setResolution"].CallAsync<bool>(arg0_resolution);
        }

        /// <summary>Sets extractor active camera</summary>
		/// <param name="arg0_cameraId">Id of the camera that will become the active camera</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetActiveCamera(int arg0_cameraId)
        {
            return SourceService["setActiveCamera"].Call<bool>(arg0_cameraId);
        }

        /// <summary>Sets extractor active camera</summary>
		/// <param name="arg0_cameraId">Id of the camera that will become the active camera</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public IQiFuture<bool> SetActiveCameraAsync(int arg0_cameraId)
        {
            return SourceService["setActiveCamera"].CallAsync<bool>(arg0_cameraId);
        }

        /// <summary>DEPRECATED: Sets pause and resolution</summary>
		/// <param name="arg0_paramName">Name of the parameter to set</param>
		/// <param name="arg1_value">New value</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, object arg1_value)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_value);
        }

        /// <summary>DEPRECATED: Sets pause and resolution</summary>
		/// <param name="arg0_paramName">Name of the parameter to set</param>
		/// <param name="arg1_value">New value</param>
		/// <returns></returns>
        public IQiFuture SetParameterAsync(string arg0_paramName, object arg1_value)
        {
            return SourceService["setParameter"].CallAsync(arg0_paramName, arg1_value);
        }

        /// <summary>Gets extractor framerate</summary>
		/// <returns>Current value of the framerate of the extractor</returns>
        public int GetFrameRate()
        {
            return SourceService["getFrameRate"].Call<int>();
        }

        /// <summary>Gets extractor framerate</summary>
		/// <returns>Current value of the framerate of the extractor</returns>
        public IQiFuture<int> GetFrameRateAsync()
        {
            return SourceService["getFrameRate"].CallAsync<int>();
        }

        /// <summary>Gets extractor resolution</summary>
		/// <returns>Current value of the resolution of the extractor</returns>
        public int GetResolution()
        {
            return SourceService["getResolution"].Call<int>();
        }

        /// <summary>Gets extractor resolution</summary>
		/// <returns>Current value of the resolution of the extractor</returns>
        public IQiFuture<int> GetResolutionAsync()
        {
            return SourceService["getResolution"].CallAsync<int>();
        }

        /// <summary>Gets extractor active camera</summary>
		/// <returns>Id of the current active camera of the extractor</returns>
        public int GetActiveCamera()
        {
            return SourceService["getActiveCamera"].Call<int>();
        }

        /// <summary>Gets extractor active camera</summary>
		/// <returns>Id of the current active camera of the extractor</returns>
        public IQiFuture<int> GetActiveCameraAsync()
        {
            return SourceService["getActiveCamera"].CallAsync<int>();
        }

        /// <summary>Gets extractor pause status</summary>
		/// <returns>True if the extractor is paused, False if not</returns>
        public bool IsPaused()
        {
            return SourceService["isPaused"].Call<bool>();
        }

        /// <summary>Gets extractor pause status</summary>
		/// <returns>True if the extractor is paused, False if not</returns>
        public IQiFuture<bool> IsPausedAsync()
        {
            return SourceService["isPaused"].CallAsync<bool>();
        }

        /// <summary>Gets extractor running status</summary>
		/// <returns>True if the extractor is currently processing images, False if not</returns>
        public bool IsProcessing()
        {
            return SourceService["isProcessing"].Call<bool>();
        }

        /// <summary>Gets extractor running status</summary>
		/// <returns>True if the extractor is currently processing images, False if not</returns>
        public IQiFuture<bool> IsProcessingAsync()
        {
            return SourceService["isProcessing"].CallAsync<bool>();
        }

        /// <summary>Changes the pause status of the extractor</summary>
		/// <param name="arg0_paused">New pause satus</param>
		/// <returns></returns>
        public void Pause(bool arg0_paused)
        {
            SourceService["pause"].Call(arg0_paused);
        }

        /// <summary>Changes the pause status of the extractor</summary>
		/// <param name="arg0_paused">New pause satus</param>
		/// <returns></returns>
        public IQiFuture PauseAsync(bool arg0_paused)
        {
            return SourceService["pause"].CallAsync(arg0_paused);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _run()
        {
            SourceService["_run"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture _runAsync()
        {
            return SourceService["_run"].CallAsync();
        }

        /// <summary>By default the database has the name &quot;current&quot; and is on the robot in /home/nao/naoqi/share/naoqi/vision/visionrecognition/ folder. This bound method allows to choose both another name and another folder for the database. </summary>
		/// <param name="arg0_databasePath">Absolute path of the database on the robot, or &quot;&quot; to set default path.</param>
		/// <param name="arg1_databaseName">Name of the database folder, or &quot;&quot; to set default database folder.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public bool ChangeDatabase(string arg0_databasePath, string arg1_databaseName)
        {
            return SourceService["changeDatabase"].Call<bool>(arg0_databasePath, arg1_databaseName);
        }

        /// <summary>By default the database has the name &quot;current&quot; and is on the robot in /home/nao/naoqi/share/naoqi/vision/visionrecognition/ folder. This bound method allows to choose both another name and another folder for the database. </summary>
		/// <param name="arg0_databasePath">Absolute path of the database on the robot, or &quot;&quot; to set default path.</param>
		/// <param name="arg1_databaseName">Name of the database folder, or &quot;&quot; to set default database folder.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public IQiFuture<bool> ChangeDatabaseAsync(string arg0_databasePath, string arg1_databaseName)
        {
            return SourceService["changeDatabase"].CallAsync<bool>(arg0_databasePath, arg1_databaseName);
        }

        /// <summary>Clear the current database, the user has to be warned before calling this function.</summary>
		/// <returns></returns>
        public void ClearCurrentDatabase()
        {
            SourceService["clearCurrentDatabase"].Call();
        }

        /// <summary>Clear the current database, the user has to be warned before calling this function.</summary>
		/// <returns></returns>
        public IQiFuture ClearCurrentDatabaseAsync()
        {
            return SourceService["clearCurrentDatabase"].CallAsync();
        }

        /// <summary>Set vision recognition parameters (deprecated in 1.22)</summary>
		/// <param name="arg0_paramName">Name of the parameter to be changed. Only &quot;resolution&quot; can be used.</param>
		/// <param name="arg1_paramValue">Value of the resolution as an integer: 0(QQVGA) 1(QVGA) 2(VGA)</param>
		/// <returns></returns>
        public void SetParam(string arg0_paramName, object arg1_paramValue)
        {
            SourceService["setParam"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Set vision recognition parameters (deprecated in 1.22)</summary>
		/// <param name="arg0_paramName">Name of the parameter to be changed. Only &quot;resolution&quot; can be used.</param>
		/// <param name="arg1_paramValue">Value of the resolution as an integer: 0(QQVGA) 1(QVGA) 2(VGA)</param>
		/// <returns></returns>
        public IQiFuture SetParamAsync(string arg0_paramName, object arg1_paramValue)
        {
            return SourceService["setParam"].CallAsync(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Get some vision recognition parameters.</summary>
		/// <param name="arg0_paramName">The name of the parameter to get. &quot;db_path&quot; and &quot;db_name&quot; can be used.</param>
		/// <returns>Value of the parameter as a string for &quot;db_path&quot; and &quot;db_name&quot;</returns>
        public IQiResult GetParam(string arg0_paramName)
        {
            return SourceService["getParam"].Call<IQiResult>(arg0_paramName);
        }

        /// <summary>Get some vision recognition parameters.</summary>
		/// <param name="arg0_paramName">The name of the parameter to get. &quot;db_path&quot; and &quot;db_name&quot; can be used.</param>
		/// <returns>Value of the parameter as a string for &quot;db_path&quot; and &quot;db_name&quot;</returns>
        public IQiFuture<IQiResult> GetParamAsync(string arg0_paramName)
        {
            return SourceService["getParam"].CallAsync<IQiResult>(arg0_paramName);
        }

        /// <summary>Load an image and interpret it as an object.</summary>
		/// <param name="arg0_filename">The filename of the image that will be interpreted as a planar object.</param>
		/// <param name="arg1_name">The name of the object (used as a unique identifier).</param>
		/// <param name="arg2_tags">A list of tags (as strings) containing any met-data about your object.</param>
		/// <param name="arg3_isWholeImage">indicates if the object occupies the whole image. If set to false, visionrecognition will try to detect the border of the object automatically. This works with unicolor background where object stands out well from the background. By default, this is set to true.</param>
		/// <param name="arg4_forced">indicates if learned object will replace existing object (having the same original name) if any.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public bool LearnFromFile(string arg0_filename, string arg1_name, IEnumerable<string> arg2_tags, bool arg3_isWholeImage, bool arg4_forced)
        {
            return SourceService["learnFromFile"].Call<bool>(arg0_filename, arg1_name, arg2_tags, arg3_isWholeImage, arg4_forced);
        }

        /// <summary>Load an image and interpret it as an object.</summary>
		/// <param name="arg0_filename">The filename of the image that will be interpreted as a planar object.</param>
		/// <param name="arg1_name">The name of the object (used as a unique identifier).</param>
		/// <param name="arg2_tags">A list of tags (as strings) containing any met-data about your object.</param>
		/// <param name="arg3_isWholeImage">indicates if the object occupies the whole image. If set to false, visionrecognition will try to detect the border of the object automatically. This works with unicolor background where object stands out well from the background. By default, this is set to true.</param>
		/// <param name="arg4_forced">indicates if learned object will replace existing object (having the same original name) if any.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public IQiFuture<bool> LearnFromFileAsync(string arg0_filename, string arg1_name, IEnumerable<string> arg2_tags, bool arg3_isWholeImage, bool arg4_forced)
        {
            return SourceService["learnFromFile"].CallAsync<bool>(arg0_filename, arg1_name, arg2_tags, arg3_isWholeImage, arg4_forced);
        }

        /// <summary>Set the maximal number (not more than 10) of detected objects for each detection. By default, this is set to 1.</summary>
		/// <param name="arg0_iMaxOutObjs">number of desired objects to be detected.</param>
		/// <returns></returns>
        public void SetMaxOutObjs(int arg0_iMaxOutObjs)
        {
            SourceService["setMaxOutObjs"].Call(arg0_iMaxOutObjs);
        }

        /// <summary>Set the maximal number (not more than 10) of detected objects for each detection. By default, this is set to 1.</summary>
		/// <param name="arg0_iMaxOutObjs">number of desired objects to be detected.</param>
		/// <returns></returns>
        public IQiFuture SetMaxOutObjsAsync(int arg0_iMaxOutObjs)
        {
            return SourceService["setMaxOutObjs"].CallAsync(arg0_iMaxOutObjs);
        }

        /// <summary>Get the maximal number of detected objects for each detection.</summary>
		/// <returns>number of maximal objects to be detected.</returns>
        public int GetMaxOutObjs()
        {
            return SourceService["getMaxOutObjs"].Call<int>();
        }

        /// <summary>Get the maximal number of detected objects for each detection.</summary>
		/// <returns>number of maximal objects to be detected.</returns>
        public IQiFuture<int> GetMaxOutObjsAsync()
        {
            return SourceService["getMaxOutObjs"].CallAsync<int>();
        }

        /// <summary>Get number of objects in the current database.</summary>
		/// <returns>number of objects in the current database.</returns>
        public int GetSize()
        {
            return SourceService["getSize"].Call<int>();
        }

        /// <summary>Get number of objects in the current database.</summary>
		/// <returns>number of objects in the current database.</returns>
        public IQiFuture<int> GetSizeAsync()
        {
            return SourceService["getSize"].CallAsync<int>();
        }

        /// <summary>Remove an obbject with a specific hash from the DB (Attention: All files related to this object will be deleted.)</summary>
		/// <param name="arg0_hash">the hash (as a string) of the object to be deleted.</param>
		/// <returns></returns>
        public void _removeObject(string arg0_hash)
        {
            SourceService["_removeObject"].Call(arg0_hash);
        }

        /// <summary>Remove an obbject with a specific hash from the DB (Attention: All files related to this object will be deleted.)</summary>
		/// <param name="arg0_hash">the hash (as a string) of the object to be deleted.</param>
		/// <returns></returns>
        public IQiFuture _removeObjectAsync(string arg0_hash)
        {
            return SourceService["_removeObject"].CallAsync(arg0_hash);
        }

        /// <summary>Load an image and search for known objects.</summary>
		/// <param name="arg0_image">The image that will be searched for known objects.</param>
		/// <returns></returns>
        public void DetectFromFile(string arg0_image)
        {
            SourceService["detectFromFile"].Call(arg0_image);
        }

        /// <summary>Load an image and search for known objects.</summary>
		/// <param name="arg0_image">The image that will be searched for known objects.</param>
		/// <returns></returns>
        public IQiFuture DetectFromFileAsync(string arg0_image)
        {
            return SourceService["detectFromFile"].CallAsync(arg0_image);
        }

    }
}