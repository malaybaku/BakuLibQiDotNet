using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALTracker module to make the robot track an object or a person with head and arms or not.</summary>
    public class ALTracker
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALTracker(QiSession session)
        {
            SourceService = session.GetService("ALTracker");
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

        /// <summary>Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <param name="arg0_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public QiValue GetTargetPosition(int arg0_pFrame)
        {
            return SourceService["getTargetPosition"].Call(arg0_pFrame);
        }

        /// <summary>Only work with LandMarks target name. Returns the [x, y, z, wx, wy, wz] position of the robot in coordinate system setted with setMap API. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 6 floats corresponding to the robot position 6D.</returns>
        public QiValue GetRobotPosition()
        {
            return SourceService["getRobotPosition"].Call();
        }

        /// <summary>Return true if Tracker is running.</summary>
		/// <returns>True if Tracker is running.</returns>
        public bool IsActive()
        {
            return (bool)SourceService["isActive"].Call();
        }

        /// <summary>Return true if a new target was detected.</summary>
		/// <returns>True if a new target was detected since the last getTargetPosition().</returns>
        public bool IsNewTargetDetected()
        {
            return (bool)SourceService["isNewTargetDetected"].Call();
        }

        /// <summary>Set the robot position relative to target in Move mode.</summary>
		/// <param name="arg0_target">Set the final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</param>
		/// <returns></returns>
        public void SetRelativePosition(QiAnyValue arg0_target)
        {
            SourceService["setRelativePosition"].Call(arg0_target);
        }

        /// <summary>Get the robot position relative to target in Move mode.</summary>
		/// <returns>The final goal of the tracking. Could be [distance, thresholdX, thresholdY] or with LandMarks target name [coordX, coordY, coordWz, thresholdX, thresholdY, thresholdWz].</returns>
        public QiValue GetRelativePosition()
        {
            return SourceService["getRelativePosition"].Call();
        }

        /// <summary>Only work with LandMarks target name. Set objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <param name="arg0_pCoord">objects coordinates.</param>
		/// <returns></returns>
        public void SetTargetCoordinates(QiAnyValue arg0_pCoord)
        {
            SourceService["setTargetCoordinates"].Call(arg0_pCoord);
        }

        /// <summary>Only work with LandMarks target name. Get objects coordinates. Could be [[first object coordinate], [second object coordinate]] [[x1, y1, z1], [x2, y2, z2]]</summary>
		/// <returns>objects coordinates.</returns>
        public QiValue GetTargetCoordinates()
        {
            return SourceService["getTargetCoordinates"].Call();
        }

        /// <summary>Set the tracker in the predefined mode.Could be &quot;Head&quot;, &quot;WholeBody&quot; or &quot;Move&quot;.</summary>
		/// <param name="arg0_pMode">a predefined mode.</param>
		/// <returns></returns>
        public void SetMode(string arg0_pMode)
        {
            SourceService["setMode"].Call(arg0_pMode);
        }

        /// <summary>Get the tracker current mode.</summary>
		/// <returns>The current tracker mode.</returns>
        public string GetMode()
        {
            return (string)SourceService["getMode"].Call();
        }

        /// <summary>Get the list of predefined mode.</summary>
		/// <returns>List of predefined mode.</returns>
        public string[] GetAvailableModes()
        {
            return (string[])SourceService["getAvailableModes"].Call();
        }

        /// <summary>Enables/disables the target search process. Target search process occurs only when the target is lost.</summary>
		/// <param name="arg0_pSearch">If true and if the target is lost, the robot moves the head in order to find the target. If false and if the target is lost the robot does not move.</param>
		/// <returns></returns>
        public void ToggleSearch(bool arg0_pSearch)
        {
            SourceService["toggleSearch"].Call(arg0_pSearch);
        }

        /// <summary>Set search process fraction max speed.</summary>
		/// <param name="arg0_pFractionMaxSpeed">a fraction max speed.</param>
		/// <returns></returns>
        public void SetSearchFractionMaxSpeed(float arg0_pFractionMaxSpeed)
        {
            SourceService["setSearchFractionMaxSpeed"].Call(arg0_pFractionMaxSpeed);
        }

        /// <summary>Get search process fraction max speed.</summary>
		/// <returns>a fraction max speed.</returns>
        public float GetSearchFractionMaxSpeed()
        {
            return (float)SourceService["getSearchFractionMaxSpeed"].Call();
        }

        /// <summary>Return true if the target search process is enabled.</summary>
		/// <returns>If true the target search process is enabled.</returns>
        public bool IsSearchEnabled()
        {
            return (bool)SourceService["isSearchEnabled"].Call();
        }

        /// <summary>Stop the tracker.</summary>
		/// <returns></returns>
        public void StopTracker()
        {
            SourceService["stopTracker"].Call();
        }

        /// <summary>Return true if the target was lost.</summary>
		/// <returns>True if the target was lost.</returns>
        public bool IsTargetLost()
        {
            return (bool)SourceService["isTargetLost"].Call();
        }

        /// <summary>Set the predefided target to track and start the tracking process if not started.</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void Track(string arg0_pTarget)
        {
            SourceService["track"].Call(arg0_pTarget);
        }

        /// <summary>Track event and start the tracking process if not started.</summary>
		/// <param name="arg0_pEventName">a event name to track.</param>
		/// <returns></returns>
        public void TrackEvent(string arg0_pEventName)
        {
            SourceService["trackEvent"].Call(arg0_pEventName);
        }

        /// <summary>Register a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public void RegisterTarget(string arg0_pTarget, QiAnyValue arg1_pParams)
        {
            SourceService["registerTarget"].Call(arg0_pTarget, arg1_pParams);
        }

        /// <summary>Set a period for the corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pPeriod">a period in milliseconds</param>
		/// <returns></returns>
        public void SetExtractorPeriod(string arg0_pTarget, int arg1_pPeriod)
        {
            SourceService["setExtractorPeriod"].Call(arg0_pTarget, arg1_pPeriod);
        }

        /// <summary>Get the period of corresponding target name extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target name.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns>a period in milliseconds</returns>
        public int GetExtractorPeriod(string arg0_pTarget)
        {
            return (int)SourceService["getExtractorPeriod"].Call(arg0_pTarget);
        }

        /// <summary>Unregister target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void UnregisterTarget(string arg0_pTarget)
        {
            SourceService["unregisterTarget"].Call(arg0_pTarget);
        }

        /// <summary>Unregister a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void UnregisterTargets(IEnumerable<string> arg0_pTarget)
        {
            SourceService["unregisterTargets"].Call(QiList.Create(arg0_pTarget));
        }

        /// <summary>Unregister all targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public void UnregisterAllTargets()
        {
            SourceService["unregisterAllTargets"].Call();
        }

        /// <summary>Return active target name.</summary>
		/// <returns>Tracked target name.</returns>
        public string GetActiveTarget()
        {
            return (string)SourceService["getActiveTarget"].Call();
        }

        /// <summary>Return a list of supported targets names.</summary>
		/// <returns>Supported targets names.</returns>
        public string[] GetSupportedTargets()
        {
            return (string[])SourceService["getSupportedTargets"].Call();
        }

        /// <summary>Return a list of registered targets names.</summary>
		/// <returns>Registered targets names.</returns>
        public string[] GetRegisteredTargets()
        {
            return (string[])SourceService["getRegisteredTargets"].Call();
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg3_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void LookAt(IEnumerable<float> arg0_pPosition, int arg1_pFrame, float arg2_pFractionMaxSpeed, bool arg3_pUseWholeBody)
        {
            SourceService["lookAt"].Call(QiList.Create(arg0_pPosition), arg1_pFrame, arg2_pFractionMaxSpeed, arg3_pUseWholeBody);
        }

        /// <summary>Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public void PointAt(string arg0_pEffector, IEnumerable<float> arg1_pPosition, int arg2_pFrame, float arg3_pFractionMaxSpeed)
        {
            SourceService["pointAt"].Call(arg0_pEffector, QiList.Create(arg1_pPosition), arg2_pFrame, arg3_pFractionMaxSpeed);
        }

        /// <summary>Get the config for move modes.</summary>
		/// <returns>ALMotion GaitConfig</returns>
        public QiValue GetMoveConfig()
        {
            return SourceService["getMoveConfig"].Call();
        }

        /// <summary>set a config for move modes.</summary>
		/// <param name="arg0_config">ALMotion GaitConfig</param>
		/// <returns></returns>
        public void SetMoveConfig(QiAnyValue arg0_config)
        {
            SourceService["setMoveConfig"].Call(arg0_config);
        }

        /// <summary>get the timeout parameter for target lost.</summary>
		/// <returns>time in milliseconds.</returns>
        public int GetTimeOut()
        {
            return (int)SourceService["getTimeOut"].Call();
        }

        /// <summary>set the timeout parameter for target lost.</summary>
		/// <param name="arg0_pTimeMs">time in milliseconds.</param>
		/// <returns></returns>
        public void SetTimeOut(int arg0_pTimeMs)
        {
            SourceService["setTimeOut"].Call(arg0_pTimeMs);
        }

        /// <summary>get the maximum distance for target detection in meter.</summary>
		/// <returns>The maximum distance for target detection in meter.</returns>
        public float GetMaximumDistanceDetection()
        {
            return (float)SourceService["getMaximumDistanceDetection"].Call();
        }

        /// <summary>set the maximum target detection distance in meter.</summary>
		/// <param name="arg0_pMaxDistance">The maximum distance for target detection in meter.</param>
		/// <returns></returns>
        public void SetMaximumDistanceDetection(float arg0_pMaxDistance)
        {
            SourceService["setMaximumDistanceDetection"].Call(arg0_pMaxDistance);
        }

        /// <summary>Get active effector.</summary>
		/// <returns>Active effector name. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </returns>
        public string GetEffector()
        {
            return (string)SourceService["getEffector"].Call();
        }

        /// <summary>Set an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot; or &quot;None&quot;. </param>
		/// <returns></returns>
        public void SetEffector(string arg0_pEffector)
        {
            SourceService["setEffector"].Call(arg0_pEffector);
        }

        /// <summary>Initialize tracker parameters with default values.</summary>
		/// <returns></returns>
        public void Initialize()
        {
            SourceService["initialize"].Call();
        }

        /// <summary>Set the maximum velocity for tracking.</summary>
		/// <param name="arg0_pVelocity">The maximum velocity in rad.s-1 .</param>
		/// <returns></returns>
        public void SetMaximumVelocity(float arg0_pVelocity)
        {
            SourceService["setMaximumVelocity"].Call(arg0_pVelocity);
        }

        /// <summary>Get the maximum velocity for tracking.</summary>
		/// <returns>The maximum velocity in rad.s-1 .</returns>
        public float GetMaximumVelocity()
        {
            return (float)SourceService["getMaximumVelocity"].Call();
        }

        /// <summary>Set the maximum acceleration for tracking.</summary>
		/// <param name="arg0_pAcceleration">The maximum acceleration in rad.s-2 .</param>
		/// <returns></returns>
        public void SetMaximumAcceleration(float arg0_pAcceleration)
        {
            SourceService["setMaximumAcceleration"].Call(arg0_pAcceleration);
        }

        /// <summary>Get the maximum acceleration for tracking.</summary>
		/// <returns>The maximum acceleration in rad.s-2 .</returns>
        public float GetMaximumAcceleration()
        {
            return (float)SourceService["getMaximumAcceleration"].Call();
        }

        /// <summary>DEPRECATED. Use lookAt with frame instead. Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void LookAt(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody)
        {
            SourceService["lookAt"].Call(QiList.Create(arg0_pPosition), arg1_pFractionMaxSpeed, arg2_pUseWholeBody);
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Point at the target position with arms.</summary>
		/// <param name="arg0_pEffector">effector name. Could be &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;.</param>
		/// <param name="arg1_pPosition">position 3D [x, y, z] to point in FRAME_TORSO. x position must be striclty positif.</param>
		/// <param name="arg2_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <returns></returns>
        public void PointAt(string arg0_pEffector, IEnumerable<float> arg1_pPosition, float arg2_pFractionMaxSpeed)
        {
            SourceService["pointAt"].Call(arg0_pEffector, QiList.Create(arg1_pPosition), arg2_pFractionMaxSpeed);
        }

        /// <summary>DEPRECATED. Use pointAt with frame instead. Returns the [x, y, z] position of the target in FRAME_TORSO. This is done assuming an average target size, so it might not be very accurate.</summary>
		/// <returns>Vector of 3 floats corresponding to the target position 3D. </returns>
        public QiValue GetTargetPosition()
        {
            return SourceService["getTargetPosition"].Call();
        }

        /// <summary>DEPRECATED. Use getSupportedTargets() instead. Return a list of targets names.</summary>
		/// <returns>Valid targets names.</returns>
        public string[] GetTargetNames()
        {
            return (string[])SourceService["getTargetNames"].Call();
        }

        /// <summary>DEPRECATED. Use getRegisteredTargets() instead. Return a list of managed targets names.</summary>
		/// <returns>Managed targets names.</returns>
        public string[] GetManagedTargets()
        {
            return (string[])SourceService["getManagedTargets"].Call();
        }

        /// <summary>DEPRECATED. Use registerTarget() instead. Add a predefined target. Subscribe to corresponding extractor if Tracker is running..</summary>
		/// <param name="arg0_pTarget">a predefined target to track.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <param name="arg1_pParams">a target parameters. (RedBall : set diameter of ball.</param>
		/// <returns></returns>
        public void AddTarget(string arg0_pTarget, QiAnyValue arg1_pParams)
        {
            SourceService["addTarget"].Call(arg0_pTarget, arg1_pParams);
        }

        /// <summary>DEPRECATED. Use unregisterTarget() instead. Remove target name and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void RemoveTarget(string arg0_pTarget)
        {
            SourceService["removeTarget"].Call(arg0_pTarget);
        }

        /// <summary>DEPRECATED. Use unregisterTargets() instead. Remove a list of target names and stop corresponding extractor.</summary>
		/// <param name="arg0_pTarget">a predefined target list to remove.Could be &quot;RedBall&quot;, &quot;Face&quot;, &quot;LandMark&quot;, &quot;LandMarks&quot;, &quot;People&quot; or &quot;Sound&quot;.</param>
		/// <returns></returns>
        public void RemoveTargets(IEnumerable<string> arg0_pTarget)
        {
            SourceService["removeTargets"].Call(QiList.Create(arg0_pTarget));
        }

        /// <summary>DEPRECATED. Use unregisterAllTargets() instead. Remove all managed targets except active target and stop corresponding extractor.</summary>
		/// <returns></returns>
        public void RemoveAllTargets()
        {
            SourceService["removeAllTargets"].Call();
        }

        /// <summary>DEPRECATED. Use setEffector instead. Add an end-effector to move for tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public void AddEffector(string arg0_pEffector)
        {
            SourceService["addEffector"].Call(arg0_pEffector);
        }

        /// <summary>DEPRECATED. Use setEffector(&quot;None&quot;) instead. Remove an end-effector from tracking.</summary>
		/// <param name="arg0_pEffector">Name of effector. Could be: &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;. </param>
		/// <returns></returns>
        public void RemoveEffector(string arg0_pEffector)
        {
            SourceService["removeEffector"].Call(arg0_pEffector);
        }

        /// <summary>Pause the tracking process.</summary>
		/// <returns></returns>
        public void _pause()
        {
            SourceService["_pause"].Call();
        }

        /// <summary>Restart the tracking process.</summary>
		/// <returns></returns>
        public void _restart()
        {
            SourceService["_restart"].Call();
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void _setTrackerConfig(QiAnyValue arg0_config)
        {
            SourceService["_setTrackerConfig"].Call(arg0_config);
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>map contraining all the information.</returns>
        public QiValue _getTrackerConfig()
        {
            return SourceService["_getTrackerConfig"].Call();
        }

        /// <summary>Get the tracker configuration.</summary>
		/// <returns>string contraining all the information.</returns>
        public string _getTrackerConfigStr()
        {
            return (string)SourceService["_getTrackerConfigStr"].Call();
        }

        /// <summary>Lost event callback.</summary>
		/// <returns></returns>
        public void _lostEvent()
        {
            SourceService["_lostEvent"].Call();
        }

        /// <summary>Detected event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _detectedEvent(string arg0, QiAnyValue arg1)
        {
            SourceService["_detectedEvent"].Call(arg0, arg1);
        }

        /// <summary>Active debug in choregraphe 3D view.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDebugInView3D(bool arg0)
        {
            SourceService["_setDebugInView3D"].Call(arg0);
        }

        /// <summary>debug event callback.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _debugCallbackEvent(string arg0, QiAnyValue arg1)
        {
            SourceService["_debugCallbackEvent"].Call(arg0, arg1);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] to look in FRAME_TORSO.x position must be striclty positif.</param>
		/// <param name="arg1_pFractionMaxSpeed">The fraction of maximum speed to use.Must be between 0 and 1.</param>
		/// <param name="arg2_pUseWholeBody">If true, use whole body constraints.</param>
		/// <param name="arg3_pUseMove">If true, use move to look at target behind.</param>
		/// <returns></returns>
        public void _lookAtWithMove(IEnumerable<float> arg0_pPosition, float arg1_pFractionMaxSpeed, bool arg2_pUseWholeBody, bool arg3_pUseMove)
        {
            SourceService["_lookAtWithMove"].Call(QiList.Create(arg0_pPosition), arg1_pFractionMaxSpeed, arg2_pUseWholeBody, arg3_pUseMove);
        }

        /// <summary>Look at the target position with head.</summary>
		/// <param name="arg0_pPosition">position 3D [x, y, z] x position must be striclty positif.</param>
		/// <param name="arg1_pFrame">target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pEffectorId">effector id {Middle of eyes = 0, Camera Top = 1, Camera Bottom = 2}.</param>
		/// <param name="arg3_pFractionMaxSpeed">The fraction of maximum speed to use. Must be between 0 and 1.</param>
		/// <param name="arg4_pUseWholeBody">If true, use whole body constraints.</param>
		/// <returns></returns>
        public void _lookAtWithEffector(IEnumerable<float> arg0_pPosition, int arg1_pFrame, int arg2_pEffectorId, float arg3_pFractionMaxSpeed, bool arg4_pUseWholeBody)
        {
            SourceService["_lookAtWithEffector"].Call(QiList.Create(arg0_pPosition), arg1_pFrame, arg2_pEffectorId, arg3_pFractionMaxSpeed, arg4_pUseWholeBody);
        }

        /// <summary>Stop current look at</summary>
		/// <returns></returns>
        public void _stopLookAt()
        {
            SourceService["_stopLookAt"].Call();
        }

        /// <summary>Stop current point at</summary>
		/// <returns></returns>
        public void _stopPointAt()
        {
            SourceService["_stopPointAt"].Call();
        }

        /// <summary>Enable whole body look at during search</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _searcherSetUseWholeBodyLookAt(bool arg0)
        {
            SourceService["_searcherSetUseWholeBodyLookAt"].Call(arg0);
        }

        /// <summary>Set a specific event for move.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setMoveEvent(string arg0)
        {
            SourceService["_setMoveEvent"].Call(arg0);
        }

        /// <summary>Set move hysteresis.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setMoveHysteresis(IEnumerable<float> arg0)
        {
            SourceService["_setMoveHysteresis"].Call(QiList.Create(arg0));
        }

        /// <summary>Get move hysteresis.</summary>
		/// <returns></returns>
        public QiValue _getMoveHysteresis()
        {
            return SourceService["_getMoveHysteresis"].Call();
        }

    }
}