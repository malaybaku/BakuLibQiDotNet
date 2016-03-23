using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module is dedicated to inform if the robot is touched [joints or button]</summary>
    public class ALTouch
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALTouch(QiSession session)
        {
            SourceService = session.GetService("ALTouch");
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

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void _setTouchConfig(QiAnyValue arg0_config)
        {
            SourceService["_setTouchConfig"].Call(arg0_config);
        }

        /// <summary>Return the list of sensors managed by touch module and return by TouchChangedevent.</summary>
		/// <returns>A vector&lt;std::string&gt; of sensor names manage by ALTouch.</returns>
        public string[] GetSensorList()
        {
            return (string[])SourceService["getSensorList"].Call();
        }

        /// <summary>Return the current status of all Touch groups.</summary>
		/// <returns>A vector of pair [name, bool], similar to TouchChanged event.</returns>
        public QiValue GetStatus()
        {
            return SourceService["getStatus"].Call();
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_groupName">The name of the group to create.</param>
		/// <param name="arg1_jointNames">A vector of joint and actuator names constituting the group.</param>
		/// <returns>true if the group was created, false otherwise.</returns>
        public bool _createGroup(string arg0_groupName, IEnumerable<string> arg1_jointNames)
        {
            return (bool)SourceService["_createGroup"].Call(arg0_groupName, QiList.Create(arg1_jointNames));
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_groupName">The name of the group to delete</param>
		/// <returns>true if the group was deleted, false otherwise</returns>
        public bool _deleteGroup(string arg0_groupName)
        {
            return (bool)SourceService["_deleteGroup"].Call(arg0_groupName);
        }

        /// <summary>Internal Use.</summary>
		/// <returns>The list of groups used for sending touch events</returns>
        public string[] _getGroupList()
        {
            return (string[])SourceService["_getGroupList"].Call();
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_type">Touch detection type enum</param>
		/// <returns>The name of a touch detection type</returns>
        public string _getDetectionTypeName(int arg0_type)
        {
            return (string)SourceService["_getDetectionTypeName"].Call(arg0_type);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_groupName">The name of the touched group</param>
		/// <returns></returns>
        public void _triggerMotionReflex(string arg0_groupName)
        {
            SourceService["_triggerMotionReflex"].Call(arg0_groupName);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_groupName">The name of the touched group</param>
		/// <returns></returns>
        public void _notifyTouchStopped(string arg0_groupName)
        {
            SourceService["_notifyTouchStopped"].Call(arg0_groupName);
        }

        /// <summary>Callback when robot is falling</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _robotFallingCallback(string arg0, QiAnyValue arg1, QiAnyValue arg2)
        {
            SourceService["_robotFallingCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>Callback when robot has fallen</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _robotFallenCallback(string arg0, QiAnyValue arg1, QiAnyValue arg2)
        {
            SourceService["_robotFallenCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>Callback when diagnosis change.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _diagnosisCallback(string arg0, QiAnyValue arg1, QiAnyValue arg2)
        {
            SourceService["_diagnosisCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>Callback when temperature diagnosis change.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _temperatureCallback(string arg0, QiAnyValue arg1, QiAnyValue arg2)
        {
            SourceService["_temperatureCallback"].Call(arg0, arg1, arg2);
        }

    }
}