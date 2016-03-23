using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module controls the People Perception flow and pushes information about detected people in ALMemory.</summary>
    public class ALPeoplePerception
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALPeoplePerception(QiSession session)
        {
            SourceService = session.GetService("ALPeoplePerception");
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
		/// <returns></returns>
        public void Subscribe(string arg0_name)
        {
            SourceService["subscribe"].Call(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public void Unsubscribe(string arg0_name)
        {
            SourceService["unsubscribe"].Call(arg0_name);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public void UpdatePeriod(string arg0_name, int arg1_period)
        {
            SourceService["updatePeriod"].Call(arg0_name, arg1_period);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public void UpdatePrecision(string arg0_name, float arg1_precision)
        {
            SourceService["updatePrecision"].Call(arg0_name, arg1_precision);
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetCurrentPeriod()
        {
            return (int)SourceService["getCurrentPeriod"].Call();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public float GetCurrentPrecision()
        {
            return (float)SourceService["getCurrentPrecision"].Call();
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetMyPeriod(string arg0_name)
        {
            return (int)SourceService["getMyPeriod"].Call(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public float GetMyPrecision(string arg0_name)
        {
            return (float)SourceService["getMyPrecision"].Call(arg0_name);
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public QiValue GetSubscribersInfo()
        {
            return SourceService["getSubscribersInfo"].Call();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public string[] GetOutputNames()
        {
            return (string[])SourceService["getOutputNames"].Call();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetEventList()
        {
            return (string[])SourceService["getEventList"].Call();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetMemoryKeyList()
        {
            return (string[])SourceService["getMemoryKeyList"].Call();
        }

        /// <summary>Gets extractor pause status</summary>
		/// <returns>True if the extractor is paused, False if not</returns>
        public bool IsPaused()
        {
            return (bool)SourceService["isPaused"].Call();
        }

        /// <summary>Changes the pause status of the extractor</summary>
		/// <param name="arg0_status">New pause satus</param>
		/// <returns></returns>
        public void Pause(bool arg0_status)
        {
            SourceService["pause"].Call(arg0_status);
        }

        /// <summary>Gets extractor running status</summary>
		/// <returns>True if the extractor is currently processing images, False if not</returns>
        public bool IsProcessing()
        {
            return (bool)SourceService["isProcessing"].Call();
        }

        /// <summary>Gets the current maximum detection and tracking range.</summary>
		/// <returns>Maximum range in meters.</returns>
        public float GetMaximumDetectionRange()
        {
            return (float)SourceService["getMaximumDetectionRange"].Call();
        }

        /// <summary>Gets the current minimum body height used for human detection (3D mode only).</summary>
		/// <returns>Minimum height in meters.</returns>
        public float GetMinimumBodyHeight()
        {
            return (float)SourceService["getMinimumBodyHeight"].Call();
        }

        /// <summary>Gets the current maximum body height used for human detection (3D mode only).</summary>
		/// <returns>Maximum height in meters.</returns>
        public float GetMaximumBodyHeight()
        {
            return (float)SourceService["getMaximumBodyHeight"].Call();
        }

        /// <summary>Gets the time after which a person, supposed not to be in the field of view of the camera disappears if it has not been detected.</summary>
		/// <returns>Time in seconds.</returns>
        public float GetTimeBeforePersonDisappears()
        {
            return (float)SourceService["getTimeBeforePersonDisappears"].Call();
        }

        /// <summary>Gets the time after which a person, supposed to be in the field of view of the camera disappears if it has not been detected.</summary>
		/// <returns>Time in seconds.</returns>
        public float GetTimeBeforeVisiblePersonDisappears()
        {
            return (float)SourceService["getTimeBeforeVisiblePersonDisappears"].Call();
        }

        /// <summary>Gets the current status of face detection.</summary>
		/// <returns>True if face detection is enabled, False otherwise.</returns>
        public bool IsFaceDetectionEnabled()
        {
            return (bool)SourceService["isFaceDetectionEnabled"].Call();
        }

        /// <summary>Gets the current status of fast mode.</summary>
		/// <returns>True if fast mode is enabled, False otherwise.</returns>
        public bool IsFastModeEnabled()
        {
            return (bool)SourceService["isFastModeEnabled"].Call();
        }

        /// <summary>Gets the current status of graphical display in Choregraphe.</summary>
		/// <returns>True if graphical display is enabled, False otherwise.</returns>
        public bool IsGraphicalDisplayEnabled()
        {
            return (bool)SourceService["isGraphicalDisplayEnabled"].Call();
        }

        /// <summary>Gets the current status of movement detection in Choregraphe.</summary>
		/// <returns>True if movement detection is enabled, False otherwise.</returns>
        public bool IsMovementDetectionEnabled()
        {
            return (bool)SourceService["isMovementDetectionEnabled"].Call();
        }

        /// <summary>Empties the tracked population.</summary>
		/// <returns></returns>
        public void ResetPopulation()
        {
            SourceService["resetPopulation"].Call();
        }

        /// <summary>Turns fast mode on or off.</summary>
		/// <param name="arg0_enable">True to turn it on, False to turn it off.</param>
		/// <returns></returns>
        public void SetFastModeEnabled(bool arg0_enable)
        {
            SourceService["setFastModeEnabled"].Call(arg0_enable);
        }

        /// <summary>Turns graphical display in Choregraphe on or off.</summary>
		/// <param name="arg0_enable">True to turn it on, False to turn it off.</param>
		/// <returns></returns>
        public void SetGraphicalDisplayEnabled(bool arg0_enable)
        {
            SourceService["setGraphicalDisplayEnabled"].Call(arg0_enable);
        }

        /// <summary>Sets the maximum range for human detection and tracking.</summary>
		/// <param name="arg0_range">Maximum range in meters.</param>
		/// <returns></returns>
        public void SetMaximumDetectionRange(float arg0_range)
        {
            SourceService["setMaximumDetectionRange"].Call(arg0_range);
        }

        /// <summary>Sets the minimum human body height (3D mode only).</summary>
		/// <param name="arg0_height">Minimum height in meters.</param>
		/// <returns></returns>
        public void SetMinimumBodyHeight(float arg0_height)
        {
            SourceService["setMinimumBodyHeight"].Call(arg0_height);
        }

        /// <summary>Sets the maximum human body height (3D mode only).</summary>
		/// <param name="arg0_height">Maximum height in meters.</param>
		/// <returns></returns>
        public void SetMaximumBodyHeight(float arg0_height)
        {
            SourceService["setMaximumBodyHeight"].Call(arg0_height);
        }

        /// <summary>Turns movement detection on or off.</summary>
		/// <param name="arg0_enable">True to turn it on, False to turn it off.</param>
		/// <returns></returns>
        public void SetMovementDetectionEnabled(bool arg0_enable)
        {
            SourceService["setMovementDetectionEnabled"].Call(arg0_enable);
        }

        /// <summary>Sets the time after which a person, supposed not to be in the field of view of the camera disappears if it has not been detected.</summary>
		/// <param name="arg0_seconds">Time in seconds.</param>
		/// <returns></returns>
        public void SetTimeBeforePersonDisappears(float arg0_seconds)
        {
            SourceService["setTimeBeforePersonDisappears"].Call(arg0_seconds);
        }

        /// <summary>Sets the time after which a person, supposed to be in the field of view of the camera disappears if it has not been detected.</summary>
		/// <param name="arg0_seconds">Time in seconds.</param>
		/// <returns></returns>
        public void SetTimeBeforeVisiblePersonDisappears(float arg0_seconds)
        {
            SourceService["setTimeBeforeVisiblePersonDisappears"].Call(arg0_seconds);
        }

        /// <summary>Gets the mode (2D/3D) used for the people detection.</summary>
		/// <returns>Current mode.</returns>
        public string _getDetectionMode()
        {
            return (string)SourceService["_getDetectionMode"].Call();
        }

        /// <summary>Sets the mode (2D/3D) used for the people detection.</summary>
		/// <param name="arg0_mode">Mode to use.</param>
		/// <returns></returns>
        public void _setDetectionMode(string arg0_mode)
        {
            SourceService["_setDetectionMode"].Call(arg0_mode);
        }

        /// <summary>Turns face detection on or off.</summary>
		/// <param name="arg0_enable">True to turn it on, False to turn it off.</param>
		/// <returns></returns>
        public void SetFaceDetectionEnabled(bool arg0_enable)
        {
            SourceService["setFaceDetectionEnabled"].Call(arg0_enable);
        }

    }
}