using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALBasicAwareness
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALBasicAwareness(QiSession session)
        {
            SourceService = session.GetService("ALBasicAwareness");
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

        /// <summary>Population Updated (event: PeoplePerception/PopulationUpdated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_populationUpdated">Boolean value for people detection event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onPeopleDetected(string arg0_name, QiAnyValue arg1_populationUpdated, string arg2_message)
        {
            SourceService["_onPeopleDetected"].Call(arg0_name, arg1_populationUpdated, arg2_message);
        }

        /// <summary>Movement Detected (event: MovementDetection3D/MovementDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onMovementDetected(string arg0_name, QiAnyValue arg1_movementDetected, string arg2_message)
        {
            SourceService["_onMovementDetected"].Call(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Navigation Motion Detected (event: Navigation/MotionDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_movementDetected">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onNavigationMotionDetected(string arg0_name, QiAnyValue arg1_movementDetected, string arg2_message)
        {
            SourceService["_onNavigationMotionDetected"].Call(arg0_name, arg1_movementDetected, arg2_message);
        }

        /// <summary>Close Movement Detected (event: WavingDetection/Waving)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_closeMovementDetected">Boolean value for close movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onCloseMovementDetected(string arg0_name, QiAnyValue arg1_closeMovementDetected, string arg2_message)
        {
            SourceService["_onCloseMovementDetected"].Call(arg0_name, arg1_closeMovementDetected, arg2_message);
        }

        /// <summary>Sound Detected (event: SoundLocated)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_SoundLocated">Boolean value for movement event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onSoundDetected(string arg0_name, QiAnyValue arg1_SoundLocated, string arg2_message)
        {
            SourceService["_onSoundDetected"].Call(arg0_name, arg1_SoundLocated, arg2_message);
        }

        /// <summary>Touch Detected (event: TouchDetection3D/TouchDetected)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_touchDetected">Boolean value for touch event</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onTouchDetected(string arg0_name, QiAnyValue arg1_touchDetected, string arg2_message)
        {
            SourceService["_onTouchDetected"].Call(arg0_name, arg1_touchDetected, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FastPersonTracking)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onFastPersonTracking(string arg0_name, QiAnyValue arg1_tackerValue, string arg2_message)
        {
            SourceService["_onFastPersonTracking"].Call(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>No person found by fast tracking callback (event:ALFastPersonTracking/TrackedPersonNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onNoFastPersonFound(string arg0_name, QiAnyValue arg1_val, string arg2_message)
        {
            SourceService["_onNoFastPersonFound"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>Servoing event callback (event:ALTracker/FindPersonHead)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_tackerValue">Position to track.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadTracking(string arg0_name, QiAnyValue arg1_tackerValue, string arg2_message)
        {
            SourceService["_onHeadTracking"].Call(arg0_name, arg1_tackerValue, arg2_message);
        }

        /// <summary>HeadNotFound event callback (event:ALFindPersonHead/HeadNotFound)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadNotFound(string arg0_name, QiAnyValue arg1_val, string arg2_message)
        {
            SourceService["_onHeadNotFound"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>HeadReached event callback (event:ALFindPersonHead/HeadReached)</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadReached(string arg0_name, QiAnyValue arg1_val, string arg2_message)
        {
            SourceService["_onHeadReached"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>tracking interruption</summary>
		/// <param name="arg0_name">Name of the event</param>
		/// <param name="arg1_val">Content of the event.</param>
		/// <param name="arg2_message">Event message</param>
		/// <returns></returns>
        public void _onHeadTrackingStopped(string arg0_name, QiAnyValue arg1_val, string arg2_message)
        {
            SourceService["_onHeadTrackingStopped"].Call(arg0_name, arg1_val, arg2_message);
        }

        /// <summary>Enable/Disable BasicAwareness.</summary>
		/// <param name="arg0_enabled">True to enable BasicAwareness, False to disable BasicAwareness.</param>
		/// <returns></returns>
        public void SetEnabled(bool arg0_enabled)
        {
            SourceService["setEnabled"].Call(arg0_enabled);
        }

        /// <summary>Return whether BasicAwareness is enabled or not.</summary>
		/// <returns>Boolean value, true if enabled else false</returns>
        public bool IsEnabled()
        {
            return (bool)SourceService["isEnabled"].Call();
        }

        /// <summary>Return whether BasicAwareness is running.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public bool IsRunning()
        {
            return (bool)SourceService["isRunning"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Start Basic Awareness.</summary>
		/// <returns></returns>
        public void StartAwareness()
        {
            SourceService["startAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use setEnabled instead.Stop Basic Awareness.</summary>
		/// <returns></returns>
        public void StopAwareness()
        {
            SourceService["stopAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use isEnabled instead.Get the status (started or not) of the module.</summary>
		/// <returns>Boolean value, true if running else false</returns>
        public bool IsAwarenessRunning()
        {
            return (bool)SourceService["isAwarenessRunning"].Call();
        }

        /// <summary>Pause BasicAwareness.</summary>
		/// <returns></returns>
        public void PauseAwareness()
        {
            SourceService["pauseAwareness"].Call();
        }

        /// <summary>Resume BasicAwareness.</summary>
		/// <returns></returns>
        public void ResumeAwareness()
        {
            SourceService["resumeAwareness"].Call();
        }

        /// <summary>Get the pause status of the module.</summary>
		/// <returns></returns>
        public bool IsAwarenessPaused()
        {
            return (bool)SourceService["isAwarenessPaused"].Call();
        }

        /// <summary>Enable/Disable Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to enable/disable</param>
		/// <param name="arg1_isStimulusDetectionEnabled">Boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetStimulusDetectionEnabled(string arg0_stimulusName, bool arg1_isStimulusDetectionEnabled)
        {
            SourceService["setStimulusDetectionEnabled"].Call(arg0_stimulusName, arg1_isStimulusDetectionEnabled);
        }

        /// <summary>Get status enabled/disabled for Stimulus Detection.</summary>
		/// <param name="arg0_stimulusName">Name of the stimulus to check</param>
		/// <returns>Boolean value for status enabled/disabled</returns>
        public bool IsStimulusDetectionEnabled(string arg0_stimulusName)
        {
            return (bool)SourceService["isStimulusDetectionEnabled"].Call(arg0_stimulusName);
        }

        /// <summary>Set the specified parameter </summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <param name="arg1_newVal">&quot;LookStimulusSpeed&quot; : Float in range [0.01;1] &quot;LookBackSpeed&quot; : Float in range [0.01;1] &quot;NobodyFoundTimeOut&quot; : Float &gt; 0 &quot;MinTimeTracking&quot; : Float in range [0;20] &quot;TimeSleepBeforeResumeMS&quot; : Int &gt; 0 &quot;TimeOutResetHead&quot; : Float in range [0;30] &quot;AmplitudeYawTracking&quot; : Float in range [10;120] &quot;FramerateTracking&quot; : Int in range [1;33] &quot;PeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;SlowPeoplePerceptionPeriod&quot; : Int &gt; 1 &quot;HeadThreshold&quot; : Float in range [0;180] &quot;BodyRotationThreshold&quot; : Float in range [-180;180] &quot;BodyRotationThresholdNao&quot; : Float in range [-180;180] &quot;MoveDistanceX&quot; : Float in range [-5;5] &quot;MoveDistanceY&quot; : Float in range [-5;5] &quot;MoveAngleTheta&quot; : Float in range [-180;180] &quot;MoveThresholdX&quot; : Float in range [0;5] &quot;MoveThresholdY&quot; : Float in range [0;5] &quot;MoveThresholdTheta&quot; : Float in range [-180;180] &quot;MaxDistanceFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxDistanceNotFullyEngaged&quot; : Float in range [0.5;5] &quot;MaxHumanSearchTime&quot; : Float in range [0.1;10] &quot;DeltaPitchComfortZone&quot; : Float in range [0;90] &quot;CenterPitchComfortZone&quot; : Float in range [-90;90] &quot;SoundHeight&quot; : Float in range [0;2] &quot;MoveSpeed&quot; : Float in range [0.1;0.55] &quot;MC_Interactive_MinTime&quot; : Int in range [0;100] &quot;MC_Interactive_MaxOffsetTime&quot; : Int in range [0;100] &quot;MC_Interactive_DistanceXY&quot; : Float in range [0;1] &quot;MC_Interactive_MinTheta&quot; : Float in range [-40;0] &quot;MC_Interactive_MaxTheta&quot; : Float in range [0;40] &quot;MC_Interactive_DistanceHumanRobot&quot; : Float in range [0.1;2] &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Float in range [0.1;3] </param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, QiAnyValue arg1_newVal)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_newVal);
        }

        /// <summary>Reset all parameters, including enabled/disabled stimulus.</summary>
		/// <returns></returns>
        public void ResetAllParameters()
        {
            SourceService["resetAllParameters"].Call();
        }

        /// <summary>Get the specified parameter.</summary>
		/// <param name="arg0_paramName">&quot;LookStimulusSpeed&quot; : Speed of head moves when looking at a stimulus, as fraction of max speed &quot;LookBackSpeed&quot; : Speed of head moves when looking back to previous position, as fraction of max speed &quot;NobodyFoundTimeOut&quot; : timeout to send HumanLost event when no blob is found, in seconds &quot;MinTimeTracking&quot; : Minimum Time for the robot to be focused on someone, without listening to other stimuli, in seconds &quot;TimeSleepBeforeResumeMS&quot; : Slept time before automatically resuming BasicAwareness when an automatic pause has been made, in milliseconds &quot;TimeOutResetHead&quot; : Timeout to reset the head, in seconds &quot;AmplitudeYawTracking&quot; : max absolute value for head yaw in tracking, in degrees &quot;FramerateTracking&quot; : Framerate for FastPersonTracking and FindPersonHead, in frame per second &quot;PeoplePerceptionPeriod&quot; : Period for people perception, in milliseconds &quot;SlowPeoplePerceptionPeriod&quot; : Period for people perception in FullyEngaged mode, in milliseconds &quot;HeadThreshold&quot; : Yaw threshold for tracking, in degrees &quot;BodyRotationThreshold&quot; : Angular threshold for BodyRotation tracking mode, in degrees &quot;BodyRotationThresholdNao&quot; : Angular threshold for BodyRotation tracking mode on Nao, in degrees &quot;MoveDistanceX&quot; : X Distance for the Move tracking mode, in meters &quot;MoveDistanceY&quot; : Y Distance for the Move tracking mode, in meters &quot;MoveAngleTheta&quot; : Angle for the Move tracking mode, in degrees &quot;MoveThresholdX&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdY&quot; : Threshold for the Move tracking mode, in meters &quot;MoveThresholdTheta&quot; : Theta Threshold for the Move tracking mode, in degrees &quot;MaxDistanceFullyEngaged&quot; : Maximum distance for someone to be tracked for FullyEngaged mode, in meters &quot;MaxDistanceNotFullyEngaged&quot; : Maximum distance for someone to be tracked for modes different from FullyEngaged, in meters &quot;MaxHumanSearchTime&quot; : Maximum time to find a human after observing stimulus, in seconds &quot;DeltaPitchComfortZone&quot; : Pitch width of the comfort zone, in degree &quot;CenterPitchComfortZone&quot; : Pitch center of the confort zone, in degree &quot;SoundHeight&quot; : Default Height for sound detection, in meters &quot;MoveSpeed&quot; : Speed of the robot moves &quot;MC_Interactive_MinTime&quot; : Minimum time between 2 contextual moves (when the robot is tracking somebody) &quot;MC_Interactive_MaxOffsetTime&quot; : Maximum time that we can add to MC_Interactive_MinTime (when the robot is tracking somebody) &quot;MC_Interactive_DistanceXY&quot; : Maximum offset distance in X and Y that the robot can apply when he tracks somebody &quot;MC_Interactive_MinTheta&quot; : Minimum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_MaxTheta&quot; : Maximum theta that the robot can apply when he tracks somebody &quot;MC_Interactive_DistanceHumanRobot&quot; : Distance between the human and the robot &quot;MC_Interactive_MaxDistanceHumanRobot&quot; : Maximum distance human robot to allow the robot to move (in MoveContextually mode) </param>
		/// <returns>ALValue format for required parameter</returns>
        public QiValue GetParameter(string arg0_paramName)
        {
            return SourceService["getParameter"].Call(arg0_paramName);
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public void SetEngagementMode(string arg0_modeName)
        {
            SourceService["setEngagementMode"].Call(arg0_modeName);
        }

        /// <summary>Set engagement mode.</summary>
		/// <returns>Name of current engagement mode as a string</returns>
        public string GetEngagementMode()
        {
            return (string)SourceService["getEngagementMode"].Call();
        }

        /// <summary>Set engagement mode.</summary>
		/// <param name="arg0_checkStimWhenFocused">when it is tracking someone, true makes the robot check a stimulus to see if it corresponds to a human, false makes it go back to the current track human just after watching in the stim direction (as in SemiEngaged mode)</param>
		/// <param name="arg1_stimuliWhenNotTracking">stimuli enabled when the robot is tracking, as a stimuli names list</param>
		/// <param name="arg2_stimuliWhenTracking">stimuli enabled when the robot is not tracking, as a stimuli names list</param>
		/// <returns></returns>
        public void _setCustomEngagementMode(bool arg0_checkStimWhenFocused, IEnumerable<string> arg1_stimuliWhenNotTracking, IEnumerable<string> arg2_stimuliWhenTracking)
        {
            SourceService["_setCustomEngagementMode"].Call(arg0_checkStimWhenFocused, QiList.Create(arg1_stimuliWhenNotTracking), QiList.Create(arg2_stimuliWhenTracking));
        }

        /// <summary>Set tracking mode.</summary>
		/// <param name="arg0_modeName">Name of the mode</param>
		/// <returns></returns>
        public void SetTrackingMode(string arg0_modeName)
        {
            SourceService["setTrackingMode"].Call(arg0_modeName);
        }

        /// <summary>Set tracking mode.</summary>
		/// <returns>Name of current tracking mode as a string</returns>
        public string GetTrackingMode()
        {
            return (string)SourceService["getTrackingMode"].Call();
        }

        /// <summary>Force Engage Person.</summary>
		/// <param name="arg0_engagePerson">ID of the person as found in PeoplePerception.</param>
		/// <returns>true if the robot succeeded to engage the person, else false.</returns>
        public bool EngagePerson(int arg0_engagePerson)
        {
            return (bool)SourceService["engagePerson"].Call(arg0_engagePerson);
        }

        /// <summary>Set a new contextual moves type.</summary>
		/// <param name="arg0_contextualMove">The contextual move, can be 'forward', 'backward', 'sides' and 'random'.</param>
		/// <returns></returns>
        public void _setContextualMoveType(string arg0_contextualMove)
        {
            SourceService["_setContextualMoveType"].Call(arg0_contextualMove);
        }

        /// <summary>Trigger a custom stimulus.</summary>
		/// <param name="arg0_stimulusPosition">Position of the stimulus, in Frame World</param>
		/// <returns>If someone was found, return value is its ID, else it's -1</returns>
        public int TriggerStimulus(IEnumerable<float> arg0_stimulusPosition)
        {
            return (int)SourceService["triggerStimulus"].Call(QiList.Create(arg0_stimulusPosition));
        }

        /// <summary>DEPRECATED since 2.4: use pauseAwareness instead.</summary>
		/// <returns></returns>
        public void _pauseAwareness()
        {
            SourceService["_pauseAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use resumeAwareness instead.</summary>
		/// <returns></returns>
        public void _resumeAwareness()
        {
            SourceService["_resumeAwareness"].Call();
        }

        /// <summary>DEPRECATED since 2.4: use isAwarenessPaused instead.</summary>
		/// <returns></returns>
        public bool _isAwarenessPaused()
        {
            return (bool)SourceService["_isAwarenessPaused"].Call();
        }

        /// <summary>Use leds for debug</summary>
		/// <param name="arg0_useLeds">Boolean value: true to use leds.</param>
		/// <returns></returns>
        public void _useLedDebug(bool arg0_useLeds)
        {
            SourceService["_useLedDebug"].Call(arg0_useLeds);
        }

        /// <summary>Set Led group</summary>
		/// <param name="arg0_ledGroupName">Name of the led group.</param>
		/// <returns></returns>
        public void _setLedGroup(string arg0_ledGroupName)
        {
            SourceService["_setLedGroup"].Call(arg0_ledGroupName);
        }

        /// <summary>Use debug display in robot view</summary>
		/// <param name="arg0_useDisplay">Boolean value: true to use debug display in robot view.</param>
		/// <returns></returns>
        public void _displayRobotViewDebug(bool arg0_useDisplay)
        {
            SourceService["_displayRobotViewDebug"].Call(arg0_useDisplay);
        }

        /// <summary>Get parameters documentation</summary>
		/// <returns>Parameters info as string</returns>
        public string _getParametersInfo()
        {
            return (string)SourceService["_getParametersInfo"].Call();
        }

        /// <summary>Allow the robot to detect stimuli coming from behind and to turnthe base up to 180 degrees to watch them. If it's disabled, thestimuli from behind won't be taken into account.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public void _setEnableStimuliFromBehind(bool arg0_enable)
        {
            SourceService["_setEnableStimuliFromBehind"].Call(arg0_enable);
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if stimuli from behind are enabled, else false.</returns>
        public bool _getEnableStimuliFromBehind()
        {
            return (bool)SourceService["_getEnableStimuliFromBehind"].Call();
        }

        /// <summary>Allow the robot to check downwards for low stimuli if nobody's found.</summary>
		/// <param name="arg0_enable">true to enable, false to disable</param>
		/// <returns></returns>
        public void _setEnableCheckLowStimuli(bool arg0_enable)
        {
            SourceService["_setEnableCheckLowStimuli"].Call(arg0_enable);
        }

        /// <summary>To know if the robot can detect stimuli from behind</summary>
		/// <returns>Boolean value: true if low stimuli are enabled, else false.</returns>
        public bool _getEnableCheckLowStimuli()
        {
            return (bool)SourceService["_getEnableCheckLowStimuli"].Call();
        }

        /// <summary>Get the position of home</summary>
		/// <returns>Pose2D as vector: Pose2D of home.</returns>
        public QiValue _getHomeReferencePosition()
        {
            return SourceService["_getHomeReferencePosition"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceUpdated(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onPreferenceUpdated"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceSynchronized(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onPreferenceSynchronized"].Call(arg0, arg1, arg2);
        }

    }
}