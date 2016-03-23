using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALSegmentation3D
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALSegmentation3D(QiSession session)
        {
            SourceService = session.GetService("ALSegmentation3D");
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

        /// <summary>Sets extractor framerate</summary>
		/// <param name="arg0_value">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(int arg0_value)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_value);
        }

        /// <summary>Gets extractor framerate</summary>
		/// <returns>Current value of the framerate of the extractor</returns>
        public int GetFrameRate()
        {
            return (int)SourceService["getFrameRate"].Call();
        }

        /// <summary>Sets extractor resolution</summary>
		/// <param name="arg0_resolution">New resolution</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetResolution(int arg0_resolution)
        {
            return (bool)SourceService["setResolution"].Call(arg0_resolution);
        }

        /// <summary>Gets extractor resolution</summary>
		/// <returns>Current value of the resolution of the extractor</returns>
        public int GetResolution()
        {
            return (int)SourceService["getResolution"].Call();
        }

        /// <summary>Sets extractor active camera</summary>
		/// <param name="arg0_cameraId">Id of the camera that will become the active camera</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetActiveCamera(int arg0_cameraId)
        {
            return (bool)SourceService["setActiveCamera"].Call(arg0_cameraId);
        }

        /// <summary>Gets extractor active camera</summary>
		/// <returns>Id of the current active camera of the extractor</returns>
        public int GetActiveCamera()
        {
            return (int)SourceService["getActiveCamera"].Call();
        }

        /// <summary>Returns the position of the top of the blob most in the center of the depth image, at the given distance, in the given frame.</summary>
		/// <param name="arg0_distance">Estimation of the distance (in meters) of the blob or -1 for the nearest blob</param>
		/// <param name="arg1_frame">Frame in which to return the position (-1: FRAME_IMAGE, 0: FRAME_TORSO, 1: FRAME_WORLD, 2: FRAME_ROBOT</param>
		/// <param name="arg2_applyVerticalOffset">True to apply the VerticalOffset when computing the position, False otherwise</param>
		/// <returns>Position of the top of the corresponding blob (if one is found) in the given frame (Format: [yaw,pitch,distance] in FRAME_IMAGE, [x,y,z] in the other frame).</returns>
        public QiValue GetTopOfBlob(float arg0_distance, int arg1_frame, bool arg2_applyVerticalOffset)
        {
            return SourceService["getTopOfBlob"].Call(arg0_distance, arg1_frame, arg2_applyVerticalOffset);
        }

        /// <summary>Turn the blob tracker on or off. When the blob tracker is running, events containing the position of the top of the tracked blob are raised.</summary>
		/// <param name="arg0_status">True to turn it on, False to turn it off.</param>
		/// <returns></returns>
        public void SetBlobTrackingEnabled(bool arg0_status)
        {
            SourceService["setBlobTrackingEnabled"].Call(arg0_status);
        }

        /// <summary>Gets the current status of the blob tracker. When the blob tracker is running, events containing the position of the top of the tracked blob are raised.</summary>
		/// <returns>True if the blob tracker is enabled, False otherwise.</returns>
        public bool IsBlobTrackingEnabled()
        {
            return (bool)SourceService["isBlobTrackingEnabled"].Call();
        }

        /// <summary>Sets the distance (in meters) for the blob tracker</summary>
		/// <param name="arg0_distance">New value (in meters)</param>
		/// <returns></returns>
        public void SetBlobTrackingDistance(float arg0_distance)
        {
            SourceService["setBlobTrackingDistance"].Call(arg0_distance);
        }

        /// <summary>Gets the distance (in meters) for the blob tracker</summary>
		/// <returns></returns>
        public float GetBlobTrackingDistance()
        {
            return (float)SourceService["getBlobTrackingDistance"].Call();
        }

        /// <summary>Sets the value of vertical offset (in meters) for the blob tracker</summary>
		/// <param name="arg0_value">New vertical offset (in meters), added if positive, substracted if negative</param>
		/// <returns></returns>
        public void SetVerticalOffset(float arg0_value)
        {
            SourceService["setVerticalOffset"].Call(arg0_value);
        }

        /// <summary>Sets the value of vertical offset (in meters) for the blob tracker</summary>
		/// <returns>Current vertical offset of the blob tracker</returns>
        public float GetVerticalOffset()
        {
            return (float)SourceService["getVerticalOffset"].Call();
        }

        /// <summary>Sets the value of the depth threshold (in meters) used for the segmentation</summary>
		/// <param name="arg0_value">New depth threshold (in meters) for the segmentation</param>
		/// <returns></returns>
        public void SetDeltaDepthThreshold(float arg0_value)
        {
            SourceService["setDeltaDepthThreshold"].Call(arg0_value);
        }

        /// <summary>Gets the value of the depth threshold (in meters) used for the segmentation</summary>
		/// <returns>Current depth threshold (in meters)</returns>
        public float GetDeltaDepthThreshold()
        {
            return (float)SourceService["getDeltaDepthThreshold"].Call();
        }

    }
}