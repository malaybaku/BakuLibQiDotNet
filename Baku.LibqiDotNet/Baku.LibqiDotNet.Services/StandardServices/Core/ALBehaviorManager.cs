using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module is intended to manage behaviors. With this module, you can load, start, stop behaviors, add default behaviors or remove them. </summary>
    public class ALBehaviorManager
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALBehaviorManager(QiSession session)
        {
            SourceService = session.GetService("ALBehaviorManager");
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

        /// <summary>Load a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it was successfully loaded.</returns>
        public bool PreloadBehavior(string arg0_behavior)
        {
            return (bool)SourceService["preloadBehavior"].Call(arg0_behavior);
        }

        /// <summary>Starts a behavior, returns when started.</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void StartBehavior(string arg0_behavior)
        {
            SourceService["startBehavior"].Call(arg0_behavior);
        }

        /// <summary>Runs a behavior, returns when finished</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void RunBehavior(string arg0_behavior)
        {
            SourceService["runBehavior"].Call(arg0_behavior);
        }

        /// <summary>Stop a behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void StopBehavior(string arg0_behavior)
        {
            SourceService["stopBehavior"].Call(arg0_behavior);
        }

        /// <summary>Stop all behaviors</summary>
		/// <returns></returns>
        public void StopAllBehaviors()
        {
            SourceService["stopAllBehaviors"].Call();
        }

        /// <summary>Tell if supplied name corresponds to a behavior that has been installed</summary>
		/// <param name="arg0_name">The behavior directory name</param>
		/// <returns>Returns true if it is a valid behavior</returns>
        public bool IsBehaviorInstalled(string arg0_name)
        {
            return (bool)SourceService["isBehaviorInstalled"].Call(arg0_name);
        }

        /// <summary>Tell if the supplied namecorresponds to an existing behavior.</summary>
		/// <param name="arg0_prefixedBehavior">Prefixed behavior or just behavior's name (latter usage deprecated, in this case the behavior is searched for amongst user's behaviors, then in system behaviors) DEPRECATED in favor of ALBehaviorManager.isBehaviorInstalled.</param>
		/// <returns>Returns true if it is an existing behavior</returns>
        public bool IsBehaviorPresent(string arg0_prefixedBehavior)
        {
            return (bool)SourceService["isBehaviorPresent"].Call(arg0_prefixedBehavior);
        }

        /// <summary>Get behaviors</summary>
		/// <returns>Returns the list of behaviors prefixed by their type (User/ or System/). DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetBehaviorNames()
        {
            return (string[])SourceService["getBehaviorNames"].Call();
        }

        /// <summary>Get user's behaviors</summary>
		/// <returns>Returns the list of user's behaviors prefixed by User/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetUserBehaviorNames()
        {
            return (string[])SourceService["getUserBehaviorNames"].Call();
        }

        /// <summary>Get system behaviors</summary>
		/// <returns>Returns the list of system behaviors prefixed by System/. DEPRECATED in favor of ALBehaviorManager.getInstalledBehaviors.</returns>
        public string[] GetSystemBehaviorNames()
        {
            return (string[])SourceService["getSystemBehaviorNames"].Call();
        }

        /// <summary>Get installed behaviors directories names</summary>
		/// <returns>Returns the behaviors list</returns>
        public string[] GetInstalledBehaviors()
        {
            return (string[])SourceService["getInstalledBehaviors"].Call();
        }

        /// <summary>Get installed behaviors directories names and filter it by tag.</summary>
		/// <param name="arg0_tag">A tag to filter the list with.</param>
		/// <returns>Returns the behaviors list</returns>
        public string[] GetBehaviorsByTag(string arg0_tag)
        {
            return (string[])SourceService["getBehaviorsByTag"].Call(arg0_tag);
        }

        /// <summary>Tell if supplied name corresponds to a running behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a running behavior</returns>
        public bool IsBehaviorRunning(string arg0_behavior)
        {
            return (bool)SourceService["isBehaviorRunning"].Call(arg0_behavior);
        }

        /// <summary>Tell if supplied name corresponds to a loaded behavior</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns>Returns true if it is a loaded behavior</returns>
        public bool IsBehaviorLoaded(string arg0_behavior)
        {
            return (bool)SourceService["isBehaviorLoaded"].Call(arg0_behavior);
        }

        /// <summary>Get running behaviors</summary>
		/// <returns>Return running behaviors</returns>
        public string[] GetRunningBehaviors()
        {
            return (string[])SourceService["getRunningBehaviors"].Call();
        }

        /// <summary>Get loaded behaviors</summary>
		/// <returns>Return loaded behaviors</returns>
        public string[] GetLoadedBehaviors()
        {
            return (string[])SourceService["getLoadedBehaviors"].Call();
        }

        /// <summary>Get tags found on installed behaviors.</summary>
		/// <returns>The list of tags found.</returns>
        public string[] GetTagList()
        {
            return (string[])SourceService["getTagList"].Call();
        }

        /// <summary>Get tags found on the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The list of tags found.</returns>
        public string[] GetBehaviorTags(string arg0_behavior)
        {
            return (string[])SourceService["getBehaviorTags"].Call(arg0_behavior);
        }

        /// <summary>Get the nature of the given behavior.</summary>
		/// <param name="arg0_behavior">The local path towards a behavior or a directory.</param>
		/// <returns>The nature of the behavior.</returns>
        public string GetBehaviorNature(string arg0_behavior)
        {
            return (string)SourceService["getBehaviorNature"].Call(arg0_behavior);
        }

        /// <summary>Get the relative path of a running behavior inside its package.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The relative path of the behavior.</returns>
        public string _getBehaviorRelativePath(string arg0_behaviorId)
        {
            return (string)SourceService["_getBehaviorRelativePath"].Call(arg0_behaviorId);
        }

        /// <summary>Get the package UID of a running behavior.</summary>
		/// <param name="arg0_behaviorId">The ID of the behavior.</param>
		/// <returns>The package UID of the behavior.</returns>
        public string _getPackageUid(string arg0_behaviorId)
        {
            return (string)SourceService["_getPackageUid"].Call(arg0_behaviorId);
        }

        /// <summary>Set the given behavior as default</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void AddDefaultBehavior(string arg0_behavior)
        {
            SourceService["addDefaultBehavior"].Call(arg0_behavior);
        }

        /// <summary>Remove the given behavior from the default behaviors</summary>
		/// <param name="arg0_behavior">Behavior name </param>
		/// <returns></returns>
        public void RemoveDefaultBehavior(string arg0_behavior)
        {
            SourceService["removeDefaultBehavior"].Call(arg0_behavior);
        }

        /// <summary>Get default behaviors</summary>
		/// <returns>Return default behaviors</returns>
        public string[] GetDefaultBehaviors()
        {
            return (string[])SourceService["getDefaultBehaviors"].Call();
        }

        /// <summary>Play default behaviors</summary>
		/// <returns></returns>
        public void PlayDefaultProject()
        {
            SourceService["playDefaultProject"].Call();
        }

        /// <summary>Be notified when something we have subscribe to has changed in ALMemory</summary>
		/// <param name="arg0_dataName">name of the data</param>
		/// <param name="arg1_dataValue">value of the data</param>
		/// <param name="arg2_message">callback message</param>
		/// <returns></returns>
        public void _onDataChanged(string arg0_dataName, QiAnyValue arg1_dataValue, string arg2_message)
        {
            SourceService["_onDataChanged"].Call(arg0_dataName, arg1_dataValue, arg2_message);
        }

        /// <summary>get the FrameManagerID. INTERNAL</summary>
		/// <param name="arg0_name">name of choregraphe project</param>
		/// <returns></returns>
        public string _getBehaviorFrameManagerId(string arg0_name)
        {
            return (string)SourceService["_getBehaviorFrameManagerId"].Call(arg0_name);
        }

        /// <summary>Find out the actual &lt;package&gt;/&lt;behavior&gt; path behind a behavior name.</summary>
		/// <param name="arg0_name">name of a behavior</param>
		/// <returns>The actual &lt;package&gt;/&lt;behavior&gt; path if found, else an empty string. Throws an ALERROR if two behavior names conflicted.</returns>
        public string ResolveBehaviorName(string arg0_name)
        {
            return (string)SourceService["resolveBehaviorName"].Call(arg0_name);
        }

    }
}