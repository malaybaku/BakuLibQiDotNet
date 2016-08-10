using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALSystem
	{
		internal ALSystem(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALSystem CreateService(IQiSession session)
		{
			var result = new ALSystem(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALSystem CreateUninitializedService(IQiSession session)
		{
			return new ALSystem(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALSystem");
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

        /// <summary>Get the backup information of applications</summary>
		/// <returns>A vector with all application backup infos</returns>
        public IQiResult AppBackupInfo()
        {
            return SourceService["appBackupInfo"].Call<IQiResult>();
        }

        /// <summary>Get the backup information of applications</summary>
		/// <returns>A vector with all application backup infos</returns>
        public IQiFuture<IQiResult> AppBackupInfoAsync()
        {
            return SourceService["appBackupInfo"].CallAsync<IQiResult>();
        }

        /// <summary>Display free disk space</summary>
		/// <param name="arg0_all">Show all mount partions.</param>
		/// <returns>A vector with all partions' infos</returns>
        public IQiResult DiskFree(bool arg0_all)
        {
            return SourceService["diskFree"].Call<IQiResult>(arg0_all);
        }

        /// <summary>Display free disk space</summary>
		/// <param name="arg0_all">Show all mount partions.</param>
		/// <returns>A vector with all partions' infos</returns>
        public IQiFuture<IQiResult> DiskFreeAsync(bool arg0_all)
        {
            return SourceService["diskFree"].CallAsync<IQiResult>(arg0_all);
        }

        /// <summary>System hostname</summary>
		/// <returns>name of the robot</returns>
        public string RobotName()
        {
            return SourceService["robotName"].Call<string>();
        }

        /// <summary>System hostname</summary>
		/// <returns>name of the robot</returns>
        public IQiFuture<string> RobotNameAsync()
        {
            return SourceService["robotName"].CallAsync<string>();
        }

        /// <summary>Set system hostname</summary>
		/// <param name="arg0_name">name to use</param>
		/// <returns>whether the operation was successful</returns>
        public bool SetRobotName(string arg0_name)
        {
            return SourceService["setRobotName"].Call<bool>(arg0_name);
        }

        /// <summary>Set system hostname</summary>
		/// <param name="arg0_name">name to use</param>
		/// <returns>whether the operation was successful</returns>
        public IQiFuture<bool> SetRobotNameAsync(string arg0_name)
        {
            return SourceService["setRobotName"].CallAsync<bool>(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiSignal RobotIcon(int arg0)
        {
            return SourceService["robotIcon"].Call<IQiSignal>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiSignal> RobotIconAsync(int arg0)
        {
            return SourceService["robotIcon"].CallAsync<IQiSignal>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult RobotIcon()
        {
            return SourceService["robotIcon"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> RobotIconAsync()
        {
            return SourceService["robotIcon"].CallAsync<IQiResult>();
        }

        /// <summary>Shutdown robot</summary>
		/// <returns></returns>
        public void Shutdown()
        {
            SourceService["shutdown"].Call();
        }

        /// <summary>Shutdown robot</summary>
		/// <returns></returns>
        public IQiFuture ShutdownAsync()
        {
            return SourceService["shutdown"].CallAsync();
        }

        /// <summary>Reboot robot</summary>
		/// <returns></returns>
        public void Reboot()
        {
            SourceService["reboot"].Call();
        }

        /// <summary>Reboot robot</summary>
		/// <returns></returns>
        public IQiFuture RebootAsync()
        {
            return SourceService["reboot"].CallAsync();
        }

        /// <summary>Running system version</summary>
		/// <returns>running system version</returns>
        public string SystemVersion()
        {
            return SourceService["systemVersion"].Call<string>();
        }

        /// <summary>Running system version</summary>
		/// <returns>running system version</returns>
        public IQiFuture<string> SystemVersionAsync()
        {
            return SourceService["systemVersion"].CallAsync<string>();
        }

        /// <summary>Running system version</summary>
		/// <returns>information about the system version</returns>
        public IQiResult SystemInfo()
        {
            return SourceService["systemInfo"].Call<IQiResult>();
        }

        /// <summary>Running system version</summary>
		/// <returns>information about the system version</returns>
        public IQiFuture<IQiResult> SystemInfoAsync()
        {
            return SourceService["systemInfo"].CallAsync<IQiResult>();
        }

        /// <summary>Amount of available memory in heap</summary>
		/// <returns>amount of available memory in heap</returns>
        public int FreeMemory()
        {
            return SourceService["freeMemory"].Call<int>();
        }

        /// <summary>Amount of available memory in heap</summary>
		/// <returns>amount of available memory in heap</returns>
        public IQiFuture<int> FreeMemoryAsync()
        {
            return SourceService["freeMemory"].CallAsync<int>();
        }

        /// <summary>Amount of total memory in heap</summary>
		/// <returns>amount of total memory in heap</returns>
        public int TotalMemory()
        {
            return SourceService["totalMemory"].Call<int>();
        }

        /// <summary>Amount of total memory in heap</summary>
		/// <returns>amount of total memory in heap</returns>
        public IQiFuture<int> TotalMemoryAsync()
        {
            return SourceService["totalMemory"].CallAsync<int>();
        }

        /// <summary>Current timezone</summary>
		/// <returns>current timezone</returns>
        public string Timezone()
        {
            return SourceService["timezone"].Call<string>();
        }

        /// <summary>Current timezone</summary>
		/// <returns>current timezone</returns>
        public IQiFuture<string> TimezoneAsync()
        {
            return SourceService["timezone"].CallAsync<string>();
        }

        /// <summary>Set current timezone</summary>
		/// <param name="arg0_timezone">timezone to use</param>
		/// <returns>whether the operation was successful</returns>
        public bool SetTimezone(string arg0_timezone)
        {
            return SourceService["setTimezone"].Call<bool>(arg0_timezone);
        }

        /// <summary>Set current timezone</summary>
		/// <param name="arg0_timezone">timezone to use</param>
		/// <returns>whether the operation was successful</returns>
        public IQiFuture<bool> SetTimezoneAsync(string arg0_timezone)
        {
            return SourceService["setTimezone"].CallAsync<bool>(arg0_timezone);
        }

        /// <summary>Set current robot icon</summary>
		/// <param name="arg0_imageFile">Image file to use as a robot icon</param>
		/// <returns></returns>
        public int SetRobotIcon(object arg0_imageFile)
        {
            return SourceService["setRobotIcon"].Call<int>(arg0_imageFile);
        }

        /// <summary>Set current robot icon</summary>
		/// <param name="arg0_imageFile">Image file to use as a robot icon</param>
		/// <returns></returns>
        public IQiFuture<int> SetRobotIconAsync(object arg0_imageFile)
        {
            return SourceService["setRobotIcon"].CallAsync<int>(arg0_imageFile);
        }

        /// <summary>Previous system version before software update (empty if this is not the 1st boot after a software update)</summary>
		/// <returns>Previous system version before software update.</returns>
        public string PreviousSystemVersion()
        {
            return SourceService["previousSystemVersion"].Call<string>();
        }

        /// <summary>Previous system version before software update (empty if this is not the 1st boot after a software update)</summary>
		/// <returns>Previous system version before software update.</returns>
        public IQiFuture<string> PreviousSystemVersionAsync()
        {
            return SourceService["previousSystemVersion"].CallAsync<string>();
        }

        /// <summary>Change the user password.</summary>
		/// <param name="arg0_oldpassword">The current password of the user.</param>
		/// <param name="arg1_newpassword">The new user password.</param>
		/// <returns></returns>
        public void ChangePassword(string arg0_oldpassword, string arg1_newpassword)
        {
            SourceService["changePassword"].Call(arg0_oldpassword, arg1_newpassword);
        }

        /// <summary>Change the user password.</summary>
		/// <param name="arg0_oldpassword">The current password of the user.</param>
		/// <param name="arg1_newpassword">The new user password.</param>
		/// <returns></returns>
        public IQiFuture ChangePasswordAsync(string arg0_oldpassword, string arg1_newpassword)
        {
            return SourceService["changePassword"].CallAsync(arg0_oldpassword, arg1_newpassword);
        }

        /// <summary>Flash the system image.</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public void Upgrade(string arg0_image, string arg1_checksum)
        {
            SourceService["upgrade"].Call(arg0_image, arg1_checksum);
        }

        /// <summary>Flash the system image.</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public IQiFuture UpgradeAsync(string arg0_image, string arg1_checksum)
        {
            return SourceService["upgrade"].CallAsync(arg0_image, arg1_checksum);
        }

        /// <summary>Flash the system image and erase the user data</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public void FactoryReset(string arg0_image, string arg1_checksum)
        {
            SourceService["factoryReset"].Call(arg0_image, arg1_checksum);
        }

        /// <summary>Flash the system image and erase the user data</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public IQiFuture FactoryResetAsync(string arg0_image, string arg1_checksum)
        {
            return SourceService["factoryReset"].CallAsync(arg0_image, arg1_checksum);
        }

        /// <summary>Set the robot status LED</summary>
		/// <param name="arg0_state">state to set</param>
		/// <returns></returns>
        public void _setStatusLed(int arg0_state)
        {
            SourceService["_setStatusLed"].Call(arg0_state);
        }

        /// <summary>Set the robot status LED</summary>
		/// <param name="arg0_state">state to set</param>
		/// <returns></returns>
        public IQiFuture _setStatusLedAsync(int arg0_state)
        {
            return SourceService["_setStatusLed"].CallAsync(arg0_state);
        }

        /// <summary>Load system notification and data</summary>
		/// <returns></returns>
        public void _initializeSystemNotification()
        {
            SourceService["_initializeSystemNotification"].Call();
        }

        /// <summary>Load system notification and data</summary>
		/// <returns></returns>
        public IQiFuture _initializeSystemNotificationAsync()
        {
            return SourceService["_initializeSystemNotification"].CallAsync();
        }

        /// <summary>List of the faulty boards</summary>
		/// <returns>A vector with the name of the faulty boards</returns>
        public string[] _boardFirmwareUpdateError()
        {
            return SourceService["_boardFirmwareUpdateError"].Call<string[]>();
        }

        /// <summary>List of the faulty boards</summary>
		/// <returns>A vector with the name of the faulty boards</returns>
        public IQiFuture<string[]> _boardFirmwareUpdateErrorAsync()
        {
            return SourceService["_boardFirmwareUpdateError"].CallAsync<string[]>();
        }

        /// <summary>Execute operations for safe naoqi stop</summary>
		/// <returns></returns>
        public void _prepareNaoqiStop()
        {
            SourceService["_prepareNaoqiStop"].Call();
        }

        /// <summary>Execute operations for safe naoqi stop</summary>
		/// <returns></returns>
        public IQiFuture _prepareNaoqiStopAsync()
        {
            return SourceService["_prepareNaoqiStop"].CallAsync();
        }

    }
}