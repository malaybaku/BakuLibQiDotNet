using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALLocalization
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALLocalization(QiSession session)
        {
            SourceService = session.GetService("ALLocalization");
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

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetMessageFromErrorCode(int arg0)
        {
            return (string)SourceService["getMessageFromErrorCode"].Call(arg0);
        }

        /// <summary>Stop all robot movements.</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _safetyStop()
        {
            SourceService["_safetyStop"].Call();
        }

        /// <summary>Learn the robot home.</summary>
		/// <returns></returns>
        public int LearnHome()
        {
            return (int)SourceService["learnHome"].Call();
        }

        /// <summary>Is the robot in its home?</summary>
		/// <returns></returns>
        public bool IsInCurrentHome()
        {
            return (bool)SourceService["isInCurrentHome"].Call();
        }

        /// <summary>Get some information about the current panorama.</summary>
		/// <returns></returns>
        public QiValue GetCurrentPanoramaDescriptor()
        {
            return SourceService["getCurrentPanoramaDescriptor"].Call();
        }

        /// <summary>Get a frame buffer.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetFrame(int arg0, string arg1)
        {
            return SourceService["getFrame"].Call(arg0, arg1);
        }

        /// <summary>Delete all panoramas in a directory.</summary>
		/// <param name="arg0_pDirectory">Name of the directory</param>
		/// <returns></returns>
        public int Clear(string arg0_pDirectory)
        {
            return (int)SourceService["clear"].Call(arg0_pDirectory);
        }

        /// <summary>Loads panoramas from a directory in the default one.</summary>
		/// <param name="arg0_pDirectory">Name of the directory</param>
		/// <returns></returns>
        public int Load(string arg0_pDirectory)
        {
            return (int)SourceService["load"].Call(arg0_pDirectory);
        }

        /// <summary>Save the temporary panoramas in a directory from the default one.</summary>
		/// <param name="arg0_pDirectory">Name of the directory</param>
		/// <returns></returns>
        public int Save(string arg0_pDirectory)
        {
            return (int)SourceService["save"].Call(arg0_pDirectory);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsRelocalizationRequired()
        {
            return (bool)SourceService["isRelocalizationRequired"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetDriftPercentages()
        {
            return SourceService["getDriftPercentages"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsDataAvailable()
        {
            return (bool)SourceService["isDataAvailable"].Call();
        }

        /// <summary>Get the robot position in world navigation.</summary>
		/// <returns></returns>
        public QiValue GetRobotPosition()
        {
            return SourceService["getRobotPosition"].Call();
        }

        /// <summary>Get the robot position in world navigation.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetRobotPosition(bool arg0)
        {
            return SourceService["getRobotPosition"].Call(arg0);
        }

        /// <summary>Get the robot orientation.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetRobotOrientation(bool arg0)
        {
            return SourceService["getRobotOrientation"].Call(arg0);
        }

        /// <summary>Get the robot orientation.</summary>
		/// <returns></returns>
        public QiValue GetRobotOrientation()
        {
            return SourceService["getRobotOrientation"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public QiValue IsInGivenZone(float arg0, float arg1, float arg2, float arg3)
        {
            return SourceService["isInGivenZone"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue _launchLocalization()
        {
            return SourceService["_launchLocalization"].Call();
        }

        /// <summary>Go to the robot home.</summary>
		/// <returns></returns>
        public int GoToHome()
        {
            return (int)SourceService["goToHome"].Call();
        }

        /// <summary>Go to a given position.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GoToPosition(IEnumerable<float> arg0)
        {
            return (int)SourceService["goToPosition"].Call(QiList.Create(arg0));
        }

        /// <summary>Return the list of saving directories</summary>
		/// <returns></returns>
        public string[] _getSavingDirectories()
        {
            return (string[])SourceService["_getSavingDirectories"].Call();
        }

        /// <summary>Return the current loaded directory name. Will be empty if there is no active panorama or if it has not been saved to a directory yet</summary>
		/// <returns></returns>
        public string _getLoadedDirectory()
        {
            return (string)SourceService["_getLoadedDirectory"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _handlePush()
        {
            SourceService["_handlePush"].Call();
        }

    }
}