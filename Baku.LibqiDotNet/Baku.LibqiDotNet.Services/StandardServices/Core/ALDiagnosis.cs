using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module is dedicated to Aldebaran Robots Diagnosis.</summary>
    public class ALDiagnosis
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALDiagnosis(QiSession session)
        {
            SourceService = session.GetService("ALDiagnosis");
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

        /// <summary>The actual state of the passive diagnosis.</summary>
		/// <returns>Return the passive diagnosis last result.</returns>
        public QiValue GetPassiveDiagnosis()
        {
            return SourceService["getPassiveDiagnosis"].Call();
        }

        /// <summary>The actual state of the active diagnosis.</summary>
		/// <returns>Return the active diagnosis last result.</returns>
        public QiValue GetActiveDiagnosis()
        {
            return SourceService["getActiveDiagnosis"].Call();
        }

        /// <summary>The actual state of the active and passive diagnosis.</summary>
		/// <returns>Return the active and passive last result.</returns>
        public QiValue GetDiagnosisStatus()
        {
            return SourceService["getDiagnosisStatus"].Call();
        }

        /// <summary>Enable / Disable diagnosis notification.</summary>
		/// <param name="arg0_enable">If True enable diagnosis notification. If False disable diagnosis notification.</param>
		/// <returns></returns>
        public void SetEnableNotification(bool arg0_enable)
        {
            SourceService["setEnableNotification"].Call(arg0_enable);
        }

        /// <summary>Return true if notification is active.</summary>
		/// <returns>Return True if notifications is active.</returns>
        public bool IsNotificationEnabled()
        {
            return (bool)SourceService["isNotificationEnabled"].Call();
        }

        /// <summary>This function runs the diagnosis.</summary>
		/// <returns></returns>
        public bool _run()
        {
            return (bool)SourceService["_run"].Call();
        }

        /// <summary>This function runs the diagnosis.</summary>
		/// <param name="arg0_diagnosisFamily">The family of tests to be run by the diagnosis.</param>
		/// <returns></returns>
        public bool _run(string arg0_diagnosisFamily)
        {
            return (bool)SourceService["_run"].Call(arg0_diagnosisFamily);
        }

        /// <summary>Returns a vector of available diagnosis families</summary>
		/// <returns></returns>
        public string[] _getFamilyNames()
        {
            return (string[])SourceService["_getFamilyNames"].Call();
        }

        /// <summary>The summary of the active diagnosis.This Hide API is dedicated for RhM.</summary>
		/// <returns></returns>
        public QiValue _getActiveDiagnosisSummary()
        {
            return SourceService["_getActiveDiagnosisSummary"].Call();
        }

        /// <summary>The summary of the passive diagnosis.This Hide API is dedicated for RhM.</summary>
		/// <param name="arg0_clearBuffers">If True buffers are cleared.</param>
		/// <returns></returns>
        public QiValue _getPassiveDiagnosisSummary(bool arg0_clearBuffers)
        {
            return SourceService["_getPassiveDiagnosisSummary"].Call(arg0_clearBuffers);
        }

        /// <summary>Callback method at wakeUp started.</summary>
		/// <returns></returns>
        public void _wakeUpStartedCallBack()
        {
            SourceService["_wakeUpStartedCallBack"].Call();
        }

        /// <summary>Callback method at wakeUp finished.</summary>
		/// <returns></returns>
        public void _wakeUpFinishedCallBack()
        {
            SourceService["_wakeUpFinishedCallBack"].Call();
        }

        /// <summary>Callback method at rest started.</summary>
		/// <returns></returns>
        public void _restStartedCallBack()
        {
            SourceService["_restStartedCallBack"].Call();
        }

        /// <summary>Callback method at rest finished.</summary>
		/// <returns></returns>
        public void _restFinishedCallBack()
        {
            SourceService["_restFinishedCallBack"].Call();
        }

        /// <summary>Callback method at naoqi ready.</summary>
		/// <returns></returns>
        public void _naoqiReadyCallBack()
        {
            SourceService["_naoqiReadyCallBack"].Call();
        }

        /// <summary>Callback method at robot is falling.</summary>
		/// <returns></returns>
        public void _robotIsFallingCallBack()
        {
            SourceService["_robotIsFallingCallBack"].Call();
        }

        /// <summary>Clear all active diagnosis.</summary>
		/// <returns></returns>
        public void _clearActiveDiagnosis()
        {
            SourceService["_clearActiveDiagnosis"].Call();
        }

        /// <summary>Enables/Disables file logging active diagnosis.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setLogToFileEnabled(bool arg0)
        {
            SourceService["_setLogToFileEnabled"].Call(arg0);
        }

        /// <summary>Run the passive diagnosis tests once.</summary>
		/// <returns></returns>
        public void _runPassiveDiagnosis()
        {
            SourceService["_runPassiveDiagnosis"].Call();
        }

    }
}