using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALRecharge
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALRecharge(QiSession session)
        {
            SourceService = session.GetService("ALRecharge");
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

        /// <summary>.</summary>
		/// <returns></returns>
        public void GoToStation()
        {
            SourceService["goToStation"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int LeaveStation()
        {
            return (int)SourceService["leaveStation"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue GetStationPosition()
        {
            return SourceService["getStationPosition"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void Subscribe()
        {
            SourceService["subscribe"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void Unsubscribe()
        {
            SourceService["unsubscribe"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int GetStatus()
        {
            return (int)SourceService["getStatus"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue LookForStation()
        {
            return SourceService["lookForStation"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int MoveInFrontOfStation()
        {
            return (int)SourceService["moveInFrontOfStation"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int DockOnStation()
        {
            return (int)SourceService["dockOnStation"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetUseTrackerSearcher(bool arg0)
        {
            SourceService["setUseTrackerSearcher"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool GetUseTrackerSearcher()
        {
            return (bool)SourceService["getUseTrackerSearcher"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetMaxNumberOfTries(int arg0)
        {
            SourceService["setMaxNumberOfTries"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int GetMaxNumberOfTries()
        {
            return (int)SourceService["getMaxNumberOfTries"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int AdjustDockingPosition(QiAnyValue arg0)
        {
            return (int)SourceService["adjustDockingPosition"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getConfidenceIndex()
        {
            return (float)SourceService["_getConfidenceIndex"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _allowTrackerNavigateTo(bool arg0)
        {
            SourceService["_allowTrackerNavigateTo"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachDistance(float arg0)
        {
            SourceService["_setFinalApproachDistance"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalApproachDistance()
        {
            return (float)SourceService["_getFinalApproachDistance"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachYOffset(float arg0)
        {
            SourceService["_setFinalApproachYOffset"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalApproachYOffset()
        {
            return (float)SourceService["_getFinalApproachYOffset"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalApproachThreshold(IEnumerable<float> arg0)
        {
            SourceService["_setFinalApproachThreshold"].Call(QiList.Create(arg0));
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getFinalApproachThreshold()
        {
            return SourceService["_getFinalApproachThreshold"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setStationDetectionConfidenceThreshold(float arg0)
        {
            SourceService["_setStationDetectionConfidenceThreshold"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getStationDetectionConfidenceThreshold()
        {
            return (float)SourceService["_getStationDetectionConfidenceThreshold"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _startLogging()
        {
            SourceService["_startLogging"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _stopLogging()
        {
            SourceService["_stopLogging"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getFinalConnectionMoves()
        {
            return SourceService["_getFinalConnectionMoves"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalConnectionMoves(QiAnyValue arg0)
        {
            SourceService["_setFinalConnectionMoves"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFinalConnectionMovesDelay(float arg0)
        {
            SourceService["_setFinalConnectionMovesDelay"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getFinalConnectionMovesDelay()
        {
            return (float)SourceService["_getFinalConnectionMovesDelay"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setEnableCheckDisconnectionTask(bool arg0)
        {
            SourceService["_setEnableCheckDisconnectionTask"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _getEnableCheckDisconnectionTask()
        {
            return (bool)SourceService["_getEnableCheckDisconnectionTask"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _updateStationDetection(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_updateStationDetection"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerSearcherLoopCallback()
        {
            SourceService["_eventTrackerSearcherLoopCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerTargetReachedCallback()
        {
            SourceService["_eventTrackerTargetReachedCallback"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventTrackerTargetLostCallback()
        {
            SourceService["_eventTrackerTargetLostCallback"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventTrackerActiveTargetChangedCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_eventTrackerActiveTargetChangedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventMoveFailedCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_eventMoveFailedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventBatteryConnectedToChargingStationCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_eventBatteryConnectedToChargingStationCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventNavigationStatusChangedCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_eventNavigationStatusChangedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _eventSlopeDetectedChangedCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_eventSlopeDetectedChangedCallback"].Call(arg0, arg1, arg2);
        }

    }
}