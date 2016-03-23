using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALVisualCompass
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALVisualCompass(QiSession session)
        {
            SourceService = session.GetService("ALVisualCompass");
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

        /// <summary>Sets the extractor framerate for a chosen subscriber</summary>
		/// <param name="arg0_subscriberName">Name of the subcriber</param>
		/// <param name="arg1_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(string arg0_subscriberName, int arg1_framerate)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_subscriberName, arg1_framerate);
        }

        /// <summary>Sets the extractor framerate for all the subscribers</summary>
		/// <param name="arg0_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(int arg0_framerate)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_framerate);
        }

        /// <summary>Sets extractor resolution</summary>
		/// <param name="arg0_resolution">New resolution</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetResolution(int arg0_resolution)
        {
            return (bool)SourceService["setResolution"].Call(arg0_resolution);
        }

        /// <summary>Sets extractor active camera</summary>
		/// <param name="arg0_cameraId">Id of the camera that will become the active camera</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetActiveCamera(int arg0_cameraId)
        {
            return (bool)SourceService["setActiveCamera"].Call(arg0_cameraId);
        }

        /// <summary>DEPRECATED: Sets pause and resolution</summary>
		/// <param name="arg0_paramName">Name of the parameter to set</param>
		/// <param name="arg1_value">New value</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, QiAnyValue arg1_value)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_value);
        }

        /// <summary>Gets extractor framerate</summary>
		/// <returns>Current value of the framerate of the extractor</returns>
        public int GetFrameRate()
        {
            return (int)SourceService["getFrameRate"].Call();
        }

        /// <summary>Gets extractor resolution</summary>
		/// <returns>Current value of the resolution of the extractor</returns>
        public int GetResolution()
        {
            return (int)SourceService["getResolution"].Call();
        }

        /// <summary>Gets extractor active camera</summary>
		/// <returns>Id of the current active camera of the extractor</returns>
        public int GetActiveCamera()
        {
            return (int)SourceService["getActiveCamera"].Call();
        }

        /// <summary>Gets extractor pause status</summary>
		/// <returns>True if the extractor is paused, False if not</returns>
        public bool IsPaused()
        {
            return (bool)SourceService["isPaused"].Call();
        }

        /// <summary>Gets extractor running status</summary>
		/// <returns>True if the extractor is currently processing images, False if not</returns>
        public bool IsProcessing()
        {
            return (bool)SourceService["isProcessing"].Call();
        }

        /// <summary>Changes the pause status of the extractor</summary>
		/// <param name="arg0_paused">New pause satus</param>
		/// <returns></returns>
        public void Pause(bool arg0_paused)
        {
            SourceService["pause"].Call(arg0_paused);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _run()
        {
            SourceService["_run"].Call();
        }

        /// <summary>Returns an ALValue containing the image used as a reference.</summary>
		/// <returns>Reference image (formatted as the ALValue from getImageRemote of ALVideoDevice)</returns>
        public QiValue GetReferenceImage()
        {
            return SourceService["getReferenceImage"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0_refresh">True if the reference is automatically refreshed at extractor startup; false to use the manually set reference image.</param>
		/// <returns></returns>
        public void EnableReferenceRefresh(bool arg0_refresh)
        {
            SourceService["enableReferenceRefresh"].Call(arg0_refresh);
        }

        /// <summary>Returns the reliability of the matching and the compass deviation computations.</summary>
		/// <returns>[0]: Percentage of the matched keypoints that are used to compute the deviation (significant if over 50%)  [1]: Number of keypoints matching.</returns>
        public QiValue GetMatchingQuality()
        {
            return SourceService["getMatchingQuality"].Call();
        }

        /// <summary>Sets the reference image for the compass.</summary>
		/// <returns>True if the reference image has been successfully set</returns>
        public bool SetCurrentImageAsReference()
        {
            return (bool)SourceService["setCurrentImageAsReference"].Call();
        }

        /// <summary>Go to input pose (in robot referential).</summary>
		/// <param name="arg0_x">Distance along the X axis in meters.</param>
		/// <param name="arg1_y">Distance along the Y axis in meters.</param>
		/// <param name="arg2_theta">Rotation around the Z axis in radians [-3.1415 to 3.1415].</param>
		/// <returns></returns>
        public bool MoveTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            return (bool)SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Move along the robot X axis.</summary>
		/// <param name="arg0_x">Algebric distance along the X axis in meters.</param>
		/// <returns></returns>
        public bool MoveStraightTo(float arg0_x)
        {
            return (bool)SourceService["moveStraightTo"].Call(arg0_x);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _xOnMoveFailed()
        {
            SourceService["_xOnMoveFailed"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _xOnFootContactChanged(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_xOnFootContactChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary>Stops the robot</summary>
		/// <returns></returns>
        public void _stopControllers()
        {
            SourceService["_stopControllers"].Call();
        }

        /// <summary>Stops the robot</summary>
		/// <param name="arg0_resumeControllers">Resume after stopping</param>
		/// <returns></returns>
        public void _resumeControllers(bool arg0_resumeControllers)
        {
            SourceService["_resumeControllers"].Call(arg0_resumeControllers);
        }

        /// <summary>Allows the robot to resume after stopping.</summary>
		/// <returns></returns>
        public void _resume()
        {
            SourceService["_resume"].Call();
        }

        /// <summary>Set the rotation controller parameters.</summary>
		/// <param name="arg0_pCoefficient">Proportional gain of the controller.</param>
		/// <param name="arg1_thetaThreshold">Threshold to consider the gap on theta as error.</param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public void _setTranslationParameters(float arg0_pCoefficient, float arg1_thetaThreshold, float arg2, float arg3)
        {
            SourceService["_setTranslationParameters"].Call(arg0_pCoefficient, arg1_thetaThreshold, arg2, arg3);
        }

        /// <summary>Set the rotation controller parameters.</summary>
		/// <param name="arg0_pCoefficient">Proportional gain of the controller.</param>
		/// <param name="arg1_maxRotationSpeed">Max robot rotation speed.</param>
		/// <param name="arg2_thetaThreshold">Threshold to consider the gap on theta as an error.</param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public void _setRotationParameters(QiAnyValue arg0_pCoefficient, float arg1_maxRotationSpeed, float arg2_thetaThreshold, float arg3, float arg4, int arg5)
        {
            SourceService["_setRotationParameters"].Call(arg0_pCoefficient, arg1_maxRotationSpeed, arg2_thetaThreshold, arg3, arg4, arg5);
        }

        /// <summary>Block the current thread until the target is reached.</summary>
		/// <returns></returns>
        public void WaitUntilTargetReached()
        {
            SourceService["waitUntilTargetReached"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setOdometryMode(bool arg0)
        {
            SourceService["_setOdometryMode"].Call(arg0);
        }

    }
}