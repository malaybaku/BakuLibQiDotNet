using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALSystem
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALSystem(QiSession session)
        {
            SourceService = session.GetService("ALSystem");
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

        /// <summary>Exits and unregisters the module.</summary>
		/// <returns></returns>
        public void Exit()
        {
            SourceService["exit"].Call();
        }

        /// <summary>Internal function to pCall methods</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int __pCall(uint arg0, QiAnyValue arg1)
        {
            return (int)SourceService["__pCall"].Call(arg0, arg1);
        }

        /// <summary>NAOqi1 pCall method.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue PCall(QiAnyValue arg0)
        {
            return SourceService["pCall"].Call(arg0);
        }

        /// <summary>Returns the version of the module.</summary>
		/// <returns>A string containing the version of the module.</returns>
        public string Version()
        {
            return (string)SourceService["version"].Call();
        }

        /// <summary>Just a ping. Always returns true</summary>
		/// <returns>returns true</returns>
        public bool Ping()
        {
            return (bool)SourceService["ping"].Call();
        }

        /// <summary>Retrieves the module's method list.</summary>
		/// <returns>An array of method names.</returns>
        public string[] GetMethodList()
        {
            return (string[])SourceService["getMethodList"].Call();
        }

        /// <summary>Retrieves a method's description.</summary>
		/// <param name="arg0_methodName">The name of the method.</param>
		/// <returns>A structure containing the method's description.</returns>
        public QiValue GetMethodHelp(string arg0_methodName)
        {
            return SourceService["getMethodHelp"].Call(arg0_methodName);
        }

        /// <summary>Retrieves the module's description.</summary>
		/// <returns>A structure describing the module.</returns>
        public QiValue GetModuleHelp()
        {
            return SourceService["getModuleHelp"].Call();
        }

        /// <summary>Wait for the end of a long running method that was called using 'post'</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <param name="arg1_timeoutPeriod">The timeout period in ms. To wait indefinately, use a timeoutPeriod of zero.</param>
		/// <returns>True if the timeout period terminated. False if the method returned.</returns>
        public bool Wait(int arg0_id, int arg1_timeoutPeriod)
        {
            return (bool)SourceService["wait"].Call(arg0_id, arg1_timeoutPeriod);
        }

        /// <summary>Wait for the end of a long running method that was called using 'post', returns a cancelable future</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns></returns>
        public void Wait(int arg0_id)
        {
            SourceService["wait"].Call(arg0_id);
        }

        /// <summary>Returns true if the method is currently running.</summary>
		/// <param name="arg0_id">The ID of the method that was returned when calling the method using 'post'</param>
		/// <returns>True if the method is currently running</returns>
        public bool IsRunning(int arg0_id)
        {
            return (bool)SourceService["isRunning"].Call(arg0_id);
        }

        /// <summary>returns true if the method is currently running</summary>
		/// <param name="arg0_id">the ID of the method to wait for</param>
		/// <returns></returns>
        public void Stop(int arg0_id)
        {
            SourceService["stop"].Call(arg0_id);
        }

        /// <summary>Gets the name of the parent broker.</summary>
		/// <returns>The name of the parent broker.</returns>
        public string GetBrokerName()
        {
            return (string)SourceService["getBrokerName"].Call();
        }

        /// <summary>Gets the method usage string. This summarises how to use the method.</summary>
		/// <param name="arg0_name">The name of the method.</param>
		/// <returns>A string that summarises the usage of the method.</returns>
        public string GetUsage(string arg0_name)
        {
            return (string)SourceService["getUsage"].Call(arg0_name);
        }

        /// <summary>Get the backup information of applications</summary>
		/// <returns>A vector with all application backup infos</returns>
        public QiValue AppBackupInfo()
        {
            return SourceService["appBackupInfo"].Call();
        }

        /// <summary>Display free disk space</summary>
		/// <param name="arg0_all">Show all mount partions.</param>
		/// <returns>A vector with all partions' infos</returns>
        public QiValue DiskFree(bool arg0_all)
        {
            return SourceService["diskFree"].Call(arg0_all);
        }

        /// <summary>System hostname</summary>
		/// <returns>name of the robot</returns>
        public string RobotName()
        {
            return (string)SourceService["robotName"].Call();
        }

        /// <summary>Set system hostname</summary>
		/// <param name="arg0_name">name to use</param>
		/// <returns>whether the operation was successful</returns>
        public bool SetRobotName(string arg0_name)
        {
            return (bool)SourceService["setRobotName"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiObject RobotIcon(int arg0)
        {
            return SourceService["robotIcon"].CallObject(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue RobotIcon()
        {
            return SourceService["robotIcon"].Call();
        }

        /// <summary>Shutdown robot</summary>
		/// <returns></returns>
        public void Shutdown()
        {
            SourceService["shutdown"].Call();
        }

        /// <summary>Reboot robot</summary>
		/// <returns></returns>
        public void Reboot()
        {
            SourceService["reboot"].Call();
        }

        /// <summary>Running system version</summary>
		/// <returns>running system version</returns>
        public string SystemVersion()
        {
            return (string)SourceService["systemVersion"].Call();
        }

        /// <summary>Running system version</summary>
		/// <returns>information about the system version</returns>
        public QiValue SystemInfo()
        {
            return SourceService["systemInfo"].Call();
        }

        /// <summary>Amount of available memory in heap</summary>
		/// <returns>amount of available memory in heap</returns>
        public int FreeMemory()
        {
            return (int)SourceService["freeMemory"].Call();
        }

        /// <summary>Amount of total memory in heap</summary>
		/// <returns>amount of total memory in heap</returns>
        public int TotalMemory()
        {
            return (int)SourceService["totalMemory"].Call();
        }

        /// <summary>Current timezone</summary>
		/// <returns>current timezone</returns>
        public string Timezone()
        {
            return (string)SourceService["timezone"].Call();
        }

        /// <summary>Set current timezone</summary>
		/// <param name="arg0_timezone">timezone to use</param>
		/// <returns>whether the operation was successful</returns>
        public bool SetTimezone(string arg0_timezone)
        {
            return (bool)SourceService["setTimezone"].Call(arg0_timezone);
        }

        /// <summary>Set current robot icon</summary>
		/// <param name="arg0_imageFile">Image file to use as a robot icon</param>
		/// <returns></returns>
        public int SetRobotIcon(QiAnyValue arg0_imageFile)
        {
            return (int)SourceService["setRobotIcon"].Call(arg0_imageFile);
        }

        /// <summary>Previous system version before software update (empty if this is not the 1st boot after a software update)</summary>
		/// <returns>Previous system version before software update.</returns>
        public string PreviousSystemVersion()
        {
            return (string)SourceService["previousSystemVersion"].Call();
        }

        /// <summary>Change the user password.</summary>
		/// <param name="arg0_oldpassword">The current password of the user.</param>
		/// <param name="arg1_newpassword">The new user password.</param>
		/// <returns></returns>
        public void ChangePassword(string arg0_oldpassword, string arg1_newpassword)
        {
            SourceService["changePassword"].Call(arg0_oldpassword, arg1_newpassword);
        }

        /// <summary>Flash the system image.</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public void Upgrade(string arg0_image, string arg1_checksum)
        {
            SourceService["upgrade"].Call(arg0_image, arg1_checksum);
        }

        /// <summary>Flash the system image and erase the user data</summary>
		/// <param name="arg0_image">Local path to a valid image.</param>
		/// <param name="arg1_checksum">Local path to a md5 checksum file, or empty string for no verification</param>
		/// <returns></returns>
        public void FactoryReset(string arg0_image, string arg1_checksum)
        {
            SourceService["factoryReset"].Call(arg0_image, arg1_checksum);
        }

        /// <summary>Set the robot status LED</summary>
		/// <param name="arg0_state">state to set</param>
		/// <returns></returns>
        public void _setStatusLed(int arg0_state)
        {
            SourceService["_setStatusLed"].Call(arg0_state);
        }

        /// <summary>Load system notification and data</summary>
		/// <returns></returns>
        public void _initializeSystemNotification()
        {
            SourceService["_initializeSystemNotification"].Call();
        }

        /// <summary>List of the faulty boards</summary>
		/// <returns>A vector with the name of the faulty boards</returns>
        public string[] _boardFirmwareUpdateError()
        {
            return (string[])SourceService["_boardFirmwareUpdateError"].Call();
        }

        /// <summary>Execute operations for safe naoqi stop</summary>
		/// <returns></returns>
        public void _prepareNaoqiStop()
        {
            SourceService["_prepareNaoqiStop"].Call();
        }

    }
}