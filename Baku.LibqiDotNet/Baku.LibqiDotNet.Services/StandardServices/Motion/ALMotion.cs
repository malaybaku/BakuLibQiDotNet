using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALMotion provides methods that help make Nao move. It contains commands for manipulating joint angles, joint stiffness, and a higher level API for controling walks.</summary>
    public class ALMotion
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALMotion(QiSession session)
        {
            SourceService = session.GetService("ALMotion");
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

        /// <summary>The robot will wake up: set Motor ON and go to initial position if needed</summary>
		/// <returns></returns>
        public void WakeUp()
        {
            SourceService["wakeUp"].Call();
        }

        /// <summary>The robot will rest: go to a relax and safe position and set Motor OFF</summary>
		/// <returns></returns>
        public void Rest()
        {
            SourceService["rest"].Call();
        }

        /// <summary>The robot will rest: go to a relax and safe position on the chain and set Motor OFF</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void Rest(string arg0)
        {
            SourceService["rest"].Call(arg0);
        }

        /// <summary>The robot will rest: go to a relax and safe position on the chain and set Motor OFF</summary>
		/// <param name="arg0_chainName">The name of the chain to rest.</param>
		/// <returns></returns>
        public void _rest(string arg0_chainName)
        {
            SourceService["_rest"].Call(arg0_chainName);
        }

        /// <summary>The robot will immediately unstiffness the chain.</summary>
		/// <param name="arg0_chainName">The name of the chain to rest. Can be &quot;LArm&quot;, &quot;RArm&quot;, or &quot;Arms&quot;.</param>
		/// <returns></returns>
        public void _stopChain(string arg0_chainName)
        {
            SourceService["_stopChain"].Call(arg0_chainName);
        }

        /// <summary>The robot propose several adapted rest.</summary>
		/// <param name="arg0_whyString">A string describing the root cause of the request.</param>
		/// <param name="arg1_stateList">An ALValue [[[name list], a string or array of angles], ...].</param>
		/// <returns></returns>
        public void _restReflex(string arg0_whyString, QiAnyValue arg1_stateList)
        {
            SourceService["_restReflex"].Call(arg0_whyString, arg1_stateList);
        }

        /// <summary>Go to a stable rest posture given the blocked joints</summary>
		/// <returns></returns>
        public void _blockedLegReflex()
        {
            SourceService["_blockedLegReflex"].Call();
        }

        /// <summary>The robot will rest: wakeUp is not allowed anymore.</summary>
		/// <returns></returns>
        public void _shutdown()
        {
            SourceService["_shutdown"].Call();
        }

        /// <summary>Returns true if the chain is going to rest or is already in rest</summary>
		/// <param name="arg0_chainName">The chain name</param>
		/// <returns></returns>
        public bool _isChainGoToOrInRest(string arg0_chainName)
        {
            return (bool)SourceService["_isChainGoToOrInRest"].Call(arg0_chainName);
        }

        /// <summary>Set the reference posture for fallmanager, stand init, idle posture, breath, etc.</summary>
		/// <param name="arg0_postureName">The posture name</param>
		/// <param name="arg1_bodyAngles">The body angles. Use getBodyNames api with parameter JointActuators.</param>
		/// <returns>Success to set the desired motion posture.</returns>
        public bool _setMotionPosture(string arg0_postureName, IEnumerable<float> arg1_bodyAngles)
        {
            return (bool)SourceService["_setMotionPosture"].Call(arg0_postureName, QiList.Create(arg1_bodyAngles));
        }

        /// <summary></summary>
		/// <param name="arg0_postureName">The posture name</param>
		/// <returns>Use getBodyNames api with parameter JointActuators.</returns>
        public QiValue _getMotionPosture(string arg0_postureName)
        {
            return SourceService["_getMotionPosture"].Call(arg0_postureName);
        }

        /// <summary></summary>
		/// <returns>All the postures in motion posture library</returns>
        public string[] _getMotionPostureList()
        {
            return (string[])SourceService["_getMotionPostureList"].Call();
        }

        /// <summary>return true if the robot is already wakeUp</summary>
		/// <returns>True if the robot is already wakeUp.</returns>
        public bool RobotIsWakeUp()
        {
            return (bool)SourceService["robotIsWakeUp"].Call();
        }

        /// <summary>Interpolates one or multiple joints to a target stiffness or along timed trajectories of stiffness. This is a blocking call.</summary>
		/// <param name="arg0_names">Name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <param name="arg1_stiffnessLists">An stiffness, list of stiffnesses or list of list of stiffnesses</param>
		/// <param name="arg2_timeLists">A time, list of times or list of list of times.</param>
		/// <returns></returns>
        public void StiffnessInterpolation(QiAnyValue arg0_names, QiAnyValue arg1_stiffnessLists, QiAnyValue arg2_timeLists)
        {
            SourceService["stiffnessInterpolation"].Call(arg0_names, arg1_stiffnessLists, arg2_timeLists);
        }

        /// <summary>Sets the stiffness of one or more joints. This is a non-blocking call.</summary>
		/// <param name="arg0_names">Names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <param name="arg1_stiffnesses">One or more stiffnesses between zero and one.</param>
		/// <returns></returns>
        public void SetStiffnesses(QiAnyValue arg0_names, QiAnyValue arg1_stiffnesses)
        {
            SourceService["setStiffnesses"].Call(arg0_names, arg1_stiffnesses);
        }

        /// <summary>Sets the stiffness of one or more joints. This is a non-blocking call.</summary>
		/// <param name="arg0_names">Names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <param name="arg1_stiffnesses">One or more stiffnesses between zero and one.</param>
		/// <returns></returns>
        public void _setStiffnesses(QiAnyValue arg0_names, QiAnyValue arg1_stiffnesses)
        {
            SourceService["_setStiffnesses"].Call(arg0_names, arg1_stiffnesses);
        }

        /// <summary>Set the custom stiffnesses to maintain on the given joints and actuators to ensure safety. </summary>
		/// <param name="arg0_jointIndexes">Vector of joint indexes</param>
		/// <param name="arg1_actuatorIndexes">Vector of actuator indexes</param>
		/// <param name="arg2_stiffness">The stiffness to maintain between zero and one.</param>
		/// <returns></returns>
        public void _setSafeStiffnesses(IEnumerable<uint> arg0_jointIndexes, IEnumerable<uint> arg1_actuatorIndexes, float arg2_stiffness)
        {
            SourceService["_setSafeStiffnesses"].Call(QiList.Create(arg0_jointIndexes), QiList.Create(arg1_actuatorIndexes), arg2_stiffness);
        }

        /// <summary>Disable the safe stiffnesses set for the given joints and actuators.</summary>
		/// <param name="arg0_jointIndexes">Vector of joint indexes</param>
		/// <param name="arg1_actuatorIndexes">Vector of actuator indexes</param>
		/// <returns></returns>
        public void _disableSafeStiffnesses(IEnumerable<uint> arg0_jointIndexes, IEnumerable<uint> arg1_actuatorIndexes)
        {
            SourceService["_disableSafeStiffnesses"].Call(QiList.Create(arg0_jointIndexes), QiList.Create(arg1_actuatorIndexes));
        }

        /// <summary>Gets stiffness of a joint or group of joints</summary>
		/// <param name="arg0_jointName">Name of the joints, chains, &quot;Body&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <returns>One or more stiffnesses. 1.0 indicates maximum stiffness. 0.0 indicated minimum stiffness</returns>
        public QiValue GetStiffnesses(QiAnyValue arg0_jointName)
        {
            return SourceService["getStiffnesses"].Call(arg0_jointName);
        }

        /// <summary>Interpolates one or multiple joints to a target angle or along timed trajectories. This is a blocking call.</summary>
		/// <param name="arg0_names">Name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <param name="arg1_angleLists">An angle, list of angles or list of list of angles in radians</param>
		/// <param name="arg2_timeLists">A time, list of times or list of list of times in seconds</param>
		/// <param name="arg3_isAbsolute">If true, the movement is described in absolute angles, else the angles are relative to the current angle.</param>
		/// <returns></returns>
        public void AngleInterpolation(QiAnyValue arg0_names, QiAnyValue arg1_angleLists, QiAnyValue arg2_timeLists, bool arg3_isAbsolute)
        {
            SourceService["angleInterpolation"].Call(arg0_names, arg1_angleLists, arg2_timeLists, arg3_isAbsolute);
        }

        /// <summary>Interpolates one or multiple joints to a target angle, using a fraction of max speed. Only one target angle is allowed for each joint. This is a blocking call.</summary>
		/// <param name="arg0_names">Name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <param name="arg1_targetAngles">An angle, or list of angles in radians</param>
		/// <param name="arg2_maxSpeedFraction">A fraction.</param>
		/// <returns></returns>
        public void AngleInterpolationWithSpeed(QiAnyValue arg0_names, QiAnyValue arg1_targetAngles, float arg2_maxSpeedFraction)
        {
            SourceService["angleInterpolationWithSpeed"].Call(arg0_names, arg1_targetAngles, arg2_maxSpeedFraction);
        }

        /// <summary>Interpolates a sequence of timed angles for several motors using bezier control points. This is a blocking call.</summary>
		/// <param name="arg0_jointNames">A vector of joint names</param>
		/// <param name="arg1_times">An ragged ALValue matrix of floats. Each line corresponding to a motor, and column element to a control point.</param>
		/// <param name="arg2_controlPoints">An ALValue array of arrays each containing [float angle, Handle1, Handle2], where Handle is [int InterpolationType, float dAngle, float dTime] descibing the handle offsets relative to the angle and time of the point. The first bezier param describes the handle that controls the curve preceeding the point, the second describes the curve following the point.</param>
		/// <returns></returns>
        public void AngleInterpolationBezier(IEnumerable<string> arg0_jointNames, QiAnyValue arg1_times, QiAnyValue arg2_controlPoints)
        {
            SourceService["angleInterpolationBezier"].Call(QiList.Create(arg0_jointNames), arg1_times, arg2_controlPoints);
        }

        /// <summary>Interpolates a sequence of timed angles for several motors using bezier control points. This is a blocking call.</summary>
		/// <param name="arg0_jointNames">A vector of joint names</param>
		/// <param name="arg1_times">An ragged ALValue matrix of floats. Each line corresponding to a motor, and column element to a control point.</param>
		/// <param name="arg2_controlPoints">An ALValue array of arrays each containing [float angle, Handle1, Handle2], where Handle is [int InterpolationType, float dAngle, float dTime] descibing the handle offsets relative to the angle and time of the point. The first bezier param describes the handle that controls the curve preceeding the point, the second describes the curve following the point.</param>
		/// <param name="arg3_isAbsolute">A bool or a vector of bool. If true, the movement is described in absolute angles, else the angles are relative to the current angle.</param>
		/// <param name="arg4_supportSequence">An alvalue containing a list of [nameEffector, timeList, isActiveList].</param>
		/// <returns></returns>
        public void Animation(IEnumerable<string> arg0_jointNames, QiAnyValue arg1_times, QiAnyValue arg2_controlPoints, QiAnyValue arg3_isAbsolute, QiAnyValue arg4_supportSequence)
        {
            SourceService["animation"].Call(QiList.Create(arg0_jointNames), arg1_times, arg2_controlPoints, arg3_isAbsolute, arg4_supportSequence);
        }

        /// <summary>Sets angles. This is a non-blocking call.</summary>
		/// <param name="arg0_names">The name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <param name="arg1_angles">One or more angles in radians</param>
		/// <param name="arg2_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <returns></returns>
        public void SetAngles(QiAnyValue arg0_names, QiAnyValue arg1_angles, float arg2_fractionMaxSpeed)
        {
            SourceService["setAngles"].Call(arg0_names, arg1_angles, arg2_fractionMaxSpeed);
        }

        /// <summary>Sets angles. This is a non-blocking call.</summary>
		/// <param name="arg0_names">The name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <param name="arg1_angles">One or more angles in radians</param>
		/// <param name="arg2_fractionMaxSpeeds">The vector of fraction of maximum speed to use</param>
		/// <returns></returns>
        public void SetAngles(QiAnyValue arg0_names, QiAnyValue arg1_angles, IEnumerable<float> arg2_fractionMaxSpeeds)
        {
            SourceService["setAngles"].Call(arg0_names, arg1_angles, QiList.Create(arg2_fractionMaxSpeeds));
        }

        /// <summary>Changes Angles. This is a non-blocking call.</summary>
		/// <param name="arg0_names">The name or names of joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <param name="arg1_changes">One or more changes in radians</param>
		/// <param name="arg2_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <returns></returns>
        public void ChangeAngles(QiAnyValue arg0_names, QiAnyValue arg1_changes, float arg2_fractionMaxSpeed)
        {
            SourceService["changeAngles"].Call(arg0_names, arg1_changes, arg2_fractionMaxSpeed);
        }

        /// <summary>Gets the angles of the joints</summary>
		/// <param name="arg0_names">Names the joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <param name="arg1_useSensors">If true, sensor angles will be returned</param>
		/// <returns>Joint angles in radians.</returns>
        public QiValue GetAngles(QiAnyValue arg0_names, bool arg1_useSensors)
        {
            return SourceService["getAngles"].Call(arg0_names, arg1_useSensors);
        }

        /// <summary>NAO stiffens the motors of desired hand. Then, he opens the hand, then cuts motor current to conserve energy. This is a blocking call.</summary>
		/// <param name="arg0_handName">The name of the hand. Could be: &quot;RHand or &quot;LHand&quot;</param>
		/// <returns></returns>
        public void OpenHand(string arg0_handName)
        {
            SourceService["openHand"].Call(arg0_handName);
        }

        /// <summary>NAO stiffens the motors of desired hand. Then, he closes the hand, then cuts motor current to conserve energy. This is a blocking call.</summary>
		/// <param name="arg0_handName">The name of the hand. Could be: &quot;RHand&quot; or &quot;LHand&quot;</param>
		/// <returns></returns>
        public void CloseHand(string arg0_handName)
        {
            SourceService["closeHand"].Call(arg0_handName);
        }

        /// <summary>Makes the robot move at the given velocity. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The velocity along x axis [m.s-1].</param>
		/// <param name="arg1_y">The velocity along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The velocity around z axis [rd.s-1].</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given velocity. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The velocity along x axis [m.s-1].</param>
		/// <param name="arg1_y">The velocity along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The velocity around z axis [rd.s-1].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given normalized velocity. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The normalized velocity along x axis (between -1 and 1).</param>
		/// <param name="arg1_y">The normalized velocity along y axis (between -1 and 1).</param>
		/// <param name="arg2_theta">The normalized velocity around z axis (between -1 and 1).</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given normalized velocity. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The normalized velocity along x axis (between -1 and 1).</param>
		/// <param name="arg1_y">The normalized velocity along y axis (between -1 and 1).</param>
		/// <param name="arg2_theta">The normalized velocity around z axis (between -1 and 1).</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>DEPRECATED. Use moveToward() function instead.</summary>
		/// <param name="arg0_x">Fraction of MaxStepX. Use negative for backwards. [-1.0 to 1.0]</param>
		/// <param name="arg1_y">Fraction of MaxStepY. Use negative for right. [-1.0 to 1.0]</param>
		/// <param name="arg2_theta">Fraction of MaxStepTheta. Use negative for clockwise [-1.0 to 1.0]</param>
		/// <param name="arg3_frequency">Fraction of MaxStepFrequency [0.0 to 1.0]</param>
		/// <returns></returns>
        public void SetWalkTargetVelocity(float arg0_x, float arg1_y, float arg2_theta, float arg3_frequency)
        {
            SourceService["setWalkTargetVelocity"].Call(arg0_x, arg1_y, arg2_theta, arg3_frequency);
        }

        /// <summary>DEPRECATED. Use moveToward() function instead.</summary>
		/// <param name="arg0_x">Fraction of MaxStepX. Use negative for backwards. [-1.0 to 1.0]</param>
		/// <param name="arg1_y">Fraction of MaxStepY. Use negative for right. [-1.0 to 1.0]</param>
		/// <param name="arg2_theta">Fraction of MaxStepTheta. Use negative for clockwise [-1.0 to 1.0]</param>
		/// <param name="arg3_frequency">Fraction of MaxStepFrequency [0.0 to 1.0]</param>
		/// <param name="arg4_feetGaitConfig">An ALValue with the custom gait configuration for both feet</param>
		/// <returns></returns>
        public void SetWalkTargetVelocity(float arg0_x, float arg1_y, float arg2_theta, float arg3_frequency, QiAnyValue arg4_feetGaitConfig)
        {
            SourceService["setWalkTargetVelocity"].Call(arg0_x, arg1_y, arg2_theta, arg3_frequency, arg4_feetGaitConfig);
        }

        /// <summary>DEPRECATED. Use moveToward() function instead.</summary>
		/// <param name="arg0_x">Fraction of MaxStepX. Use negative for backwards. [-1.0 to 1.0]</param>
		/// <param name="arg1_y">Fraction of MaxStepY. Use negative for right. [-1.0 to 1.0]</param>
		/// <param name="arg2_theta">Fraction of MaxStepTheta. Use negative for clockwise [-1.0 to 1.0]</param>
		/// <param name="arg3_frequency">Fraction of MaxStepFrequency [0.0 to 1.0]</param>
		/// <param name="arg4_leftFootMoveConfig">An ALValue with custom move configuration for the left foot</param>
		/// <param name="arg5_rightFootMoveConfig">An ALValue with custom move configuration for the right foot</param>
		/// <returns></returns>
        public void SetWalkTargetVelocity(float arg0_x, float arg1_y, float arg2_theta, float arg3_frequency, QiAnyValue arg4_leftFootMoveConfig, QiAnyValue arg5_rightFootMoveConfig)
        {
            SourceService["setWalkTargetVelocity"].Call(arg0_x, arg1_y, arg2_theta, arg3_frequency, arg4_leftFootMoveConfig, arg5_rightFootMoveConfig);
        }

        /// <summary>Makes the robot move at the given position. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given position in fixed time. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <param name="arg3_time">The time to reach the target position [s].</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta, float arg3_time)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_time);
        }

        /// <summary>Makes the robot move at the given position. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given position in fixed time. This is a non-blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <param name="arg3_time">The time to reach the target position [s].</param>
		/// <param name="arg4_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta, float arg3_time, QiAnyValue arg4_moveConfig)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_time, arg4_moveConfig);
        }

        /// <summary>Makes the robot move to the given relative positions. This is a blocking call.</summary>
		/// <param name="arg0_controlPoint">An ALValue with the control points in FRAME_ROBOT.Each control point is relative to the previous one. [[x1, y1, theta1], ..., [xN, yN, thetaN]</param>
		/// <returns></returns>
        public void MoveTo(QiAnyValue arg0_controlPoint)
        {
            SourceService["moveTo"].Call(arg0_controlPoint);
        }

        /// <summary>Makes the robot move to the given relative positions. This is a blocking call.</summary>
		/// <param name="arg0_controlPoint">An ALValue with all the control points in FRAME_ROBOT.Each control point is relative to the previous one. [[x1, y1, theta1], ..., [xN, yN, thetaN]</param>
		/// <param name="arg1_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveTo(QiAnyValue arg0_controlPoint, QiAnyValue arg1_moveConfig)
        {
            SourceService["moveTo"].Call(arg0_controlPoint, arg1_moveConfig);
        }

        /// <summary>Makes the robot move at the given position, without taking into account ENABLE_MOVE_PROTECTION config</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <returns></returns>
        public void _moveToPod(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["_moveToPod"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given position, without taking into account ENABLE_MOVE_PROTECTION config</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The position around z axis [rd].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void _moveToPod(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["_moveToPod"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot follow a given path. This is a non-blocking call.</summary>
		/// <param name="arg0_path">An ALValue describing a 2D path.</param>
		/// <param name="arg1_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void _followPath(QiAnyValue arg0_path, QiAnyValue arg1_moveConfig)
        {
            SourceService["_followPath"].Call(arg0_path, arg1_moveConfig);
        }

        /// <summary>Makes the robot follow a given path. This is a non-blocking call.</summary>
		/// <param name="arg0_path">An ALValue describing a 2D path.</param>
		/// <returns></returns>
        public void _followPath(QiAnyValue arg0_path)
        {
            SourceService["_followPath"].Call(arg0_path);
        }

        /// <summary>Makes the robot follow a given path, in world frame. This is a non-blocking call.</summary>
		/// <param name="arg0_poseStart">A Pose2D setting the start frame of the path, in World.</param>
		/// <param name="arg1_path">An ALValue describing a 2D Path.</param>
		/// <param name="arg2_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void _followPathInWorld(QiAnyValue arg0_poseStart, QiAnyValue arg1_path, QiAnyValue arg2_moveConfig)
        {
            SourceService["_followPathInWorld"].Call(arg0_poseStart, arg1_path, arg2_moveConfig);
        }

        /// <summary>Makes the robot follow a given path, in world frame. This is a non-blocking call.</summary>
		/// <param name="arg0_poseStart">A Pose2D setting the start frame of the path, in World.</param>
		/// <param name="arg1_path">An ALValue describing a 2D Path.</param>
		/// <returns></returns>
        public void _followPathInWorld(QiAnyValue arg0_poseStart, QiAnyValue arg1_path)
        {
            SourceService["_followPathInWorld"].Call(arg0_poseStart, arg1_path);
        }

        /// <summary>Changes the reference speed for trajectory following</summary>
		/// <param name="arg0_speedFactor">Between 0 and 1, relative to max speed</param>
		/// <returns></returns>
        public void _setFollowPathSpeedFactor(float arg0_speedFactor)
        {
            SourceService["_setFollowPathSpeedFactor"].Call(arg0_speedFactor);
        }

        /// <summary>Move along a trajectory</summary>
		/// <param name="arg0_trajectory">An ALValue describing a trajectory.</param>
		/// <returns>The id of the trajectory that was started, as an int</returns>
        public int _moveAlong(QiAnyValue arg0_trajectory)
        {
            return (int)SourceService["_moveAlong"].Call(arg0_trajectory);
        }

        /// <summary>Move along a trajectory</summary>
		/// <param name="arg0_trajectory">An ALValue describing a trajectory.</param>
		/// <param name="arg1_scaleFactor">A float between 0 and 1 scaling the trajectory.</param>
		/// <returns>The id of the trajectory that was started, as an int</returns>
        public int _moveAlong(QiAnyValue arg0_trajectory, float arg1_scaleFactor)
        {
            return (int)SourceService["_moveAlong"].Call(arg0_trajectory, arg1_scaleFactor);
        }

        /// <summary>Get the id of the current trajectory, if any</summary>
		/// <returns></returns>
        public int _getTrajectoryId()
        {
            return (int)SourceService["_getTrajectoryId"].Call();
        }

        /// <summary>Stop current trajectory, then resync</summary>
		/// <returns></returns>
        public void _stopAndStitchMoveAlong()
        {
            SourceService["_stopAndStitchMoveAlong"].Call();
        }

        /// <summary>Get a vector of samples along the current path</summary>
		/// <param name="arg0_sampleStep">Distance between two samples, in m</param>
		/// <returns>vector of samples along trajectory</returns>
        public QiValue _getRemainingPath(float arg0_sampleStep)
        {
            return SourceService["_getRemainingPath"].Call(arg0_sampleStep);
        }

        /// <summary>Get a vector of samples along the current trajectory</summary>
		/// <param name="arg0_timeStep">Time between two samples, in s</param>
		/// <param name="arg1_preview">Duration of the preview, in s</param>
		/// <returns>vector of samples along trajectory</returns>
        public QiValue _getRemainingTrajectory(float arg0_timeStep, float arg1_preview)
        {
            return SourceService["_getRemainingTrajectory"].Call(arg0_timeStep, arg1_preview);
        }

        /// <summary>Get the ratio of executed trajectory, between 0 and 1</summary>
		/// <returns>float between 0 and 1</returns>
        public float _getTrajectoryCompletion()
        {
            return (float)SourceService["_getTrajectoryCompletion"].Call();
        }

        /// <summary>DEPRECATED. Use moveTo() function instead.</summary>
		/// <param name="arg0_x">Distance along the X axis in meters.</param>
		/// <param name="arg1_y">Distance along the Y axis in meters.</param>
		/// <param name="arg2_theta">Rotation around the Z axis in radians [-3.1415 to 3.1415].</param>
		/// <returns></returns>
        public void WalkTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["walkTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>DEPRECATED. Use moveTo() function instead.</summary>
		/// <param name="arg0_x">Distance along the X axis in meters.</param>
		/// <param name="arg1_y">Distance along the Y axis in meters.</param>
		/// <param name="arg2_theta">Rotation around the Z axis in radians [-3.1415 to 3.1415].</param>
		/// <param name="arg3_feetGaitConfig">An ALValue with the custom gait configuration for both feet.</param>
		/// <returns></returns>
        public void WalkTo(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_feetGaitConfig)
        {
            SourceService["walkTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_feetGaitConfig);
        }

        /// <summary>DEPRECATED. Use moveTo() function instead.</summary>
		/// <param name="arg0_controlPoint">An ALValue with all the control point in NAO SPACE[[x1,y1,theta1], ..., [xN,yN,thetaN]</param>
		/// <returns></returns>
        public void WalkTo(QiAnyValue arg0_controlPoint)
        {
            SourceService["walkTo"].Call(arg0_controlPoint);
        }

        /// <summary>DEPRECATED. Use moveTo() function instead.</summary>
		/// <param name="arg0_controlPoint">An ALValue with all the control point in NAO SPACE[[x1,y1,theta1], ..., [xN,yN,thetaN]</param>
		/// <param name="arg1_feetGaitConfig">An ALValue with the custom gait configuration for both feet</param>
		/// <returns></returns>
        public void WalkTo(QiAnyValue arg0_controlPoint, QiAnyValue arg1_feetGaitConfig)
        {
            SourceService["walkTo"].Call(arg0_controlPoint, arg1_feetGaitConfig);
        }

        /// <summary>Makes Nao do foot step planner. This is a non-blocking call.</summary>
		/// <param name="arg0_legName">name of the leg to move('LLeg'or 'RLeg')</param>
		/// <param name="arg1_footSteps">[x, y, theta], [Position along X/Y, Orientation round Z axis] of the leg relative to the other Leg in [meters, meters, radians]. Must be less than [MaxStepX, MaxStepY, MaxStepTheta]</param>
		/// <param name="arg2_timeList">time list of each foot step</param>
		/// <param name="arg3_clearExisting">Clear existing foot steps.</param>
		/// <returns></returns>
        public void SetFootSteps(IEnumerable<string> arg0_legName, QiAnyValue arg1_footSteps, IEnumerable<float> arg2_timeList, bool arg3_clearExisting)
        {
            SourceService["setFootSteps"].Call(QiList.Create(arg0_legName), arg1_footSteps, QiList.Create(arg2_timeList), arg3_clearExisting);
        }

        /// <summary>Makes Nao do foot step planner with speed. This is a blocking call.</summary>
		/// <param name="arg0_legName">name of the leg to move('LLeg'or 'RLeg')</param>
		/// <param name="arg1_footSteps">[x, y, theta], [Position along X/Y, Orientation round Z axis] of the leg relative to the other Leg in [meters, meters, radians]. Must be less than [MaxStepX, MaxStepY, MaxStepTheta]</param>
		/// <param name="arg2_fractionMaxSpeed">speed of each foot step. Must be between 0 and 1.</param>
		/// <param name="arg3_clearExisting">Clear existing foot steps.</param>
		/// <returns></returns>
        public void SetFootStepsWithSpeed(IEnumerable<string> arg0_legName, QiAnyValue arg1_footSteps, IEnumerable<float> arg2_fractionMaxSpeed, bool arg3_clearExisting)
        {
            SourceService["setFootStepsWithSpeed"].Call(QiList.Create(arg0_legName), arg1_footSteps, QiList.Create(arg2_fractionMaxSpeed), arg3_clearExisting);
        }

        /// <summary>Get the foot steps. This is a non-blocking call.</summary>
		/// <returns>Give two list of foot steps. The first one give the unchangeable foot step. The second list give the changeable foot steps. Il you use setFootSteps or setFootStepsWithSpeed with clearExisting parmater equal true, walk engine execute unchangeable foot step and remove the other.</returns>
        public QiValue GetFootSteps()
        {
            return SourceService["getFootSteps"].Call();
        }

        /// <summary>DEPRECATED. Use moveInit function instead.</summary>
		/// <returns></returns>
        public void WalkInit()
        {
            SourceService["walkInit"].Call();
        }

        /// <summary>Initialize the move process. Check the robot pose and take a right posture. This is blocking called.</summary>
		/// <returns></returns>
        public void MoveInit()
        {
            SourceService["moveInit"].Call();
        }

        /// <summary>DEPRECATED. Use waitUntilMoveIsFinished function instead.</summary>
		/// <returns></returns>
        public void WaitUntilWalkIsFinished()
        {
            SourceService["waitUntilWalkIsFinished"].Call();
        }

        /// <summary>Waits until the move process is finished: This method can be used to block your script/code execution until the move task is totally finished.</summary>
		/// <returns></returns>
        public void WaitUntilMoveIsFinished()
        {
            SourceService["waitUntilMoveIsFinished"].Call();
        }

        /// <summary>DEPRECATED. Use moveIsActive function instead.</summary>
		/// <returns></returns>
        public bool WalkIsActive()
        {
            return (bool)SourceService["walkIsActive"].Call();
        }

        /// <summary>Check if the move process is actif.</summary>
		/// <returns>True if move is active</returns>
        public bool MoveIsActive()
        {
            return (bool)SourceService["moveIsActive"].Call();
        }

        /// <summary>DEPRECATED. Use stopMove function instead.</summary>
		/// <returns></returns>
        public void StopWalk()
        {
            SourceService["stopWalk"].Call();
        }

        /// <summary>Stop Move task safely as fast as possible. The move task is ended less brutally than killMove but more quickly than move(0.0, 0.0, 0.0).This is a blocking call.</summary>
		/// <returns></returns>
        public void StopMove()
        {
            SourceService["stopMove"].Call();
        }

        /// <summary>DEPRECATED. Use getMoveConfig function instead.Gets the foot Gait config (&quot;MaxStepX&quot;, &quot;MaxStepY&quot;, &quot;MaxStepTheta&quot;,  &quot;MaxStepFrequency&quot;, &quot;StepHeight&quot;, &quot;TorsoWx&quot;, &quot;TorsoWy&quot;) </summary>
		/// <param name="arg0_config">a string should be &quot;Max&quot;, &quot;Min&quot;, &quot;Default&quot;</param>
		/// <returns>An ALvalue with the following form :[[&quot;MaxStepX&quot;, value], [&quot;MaxStepY&quot;, value], [&quot;MaxStepTheta&quot;, value], [&quot;MaxStepFrequency&quot;, value], [&quot;StepHeight&quot;, value], [&quot;TorsoWx&quot;, value], [&quot;TorsoWy&quot;, value]]</returns>
        public QiValue GetFootGaitConfig(string arg0_config)
        {
            return SourceService["getFootGaitConfig"].Call(arg0_config);
        }

        /// <summary>Gets the move config.</summary>
		/// <param name="arg0_config">a string should be &quot;Max&quot;, &quot;Min&quot;, &quot;Default&quot;</param>
		/// <returns>An ALvalue with the move config</returns>
        public QiValue GetMoveConfig(string arg0_config)
        {
            return SourceService["getMoveConfig"].Call(arg0_config);
        }

        /// <summary>Gets the World Absolute Robot Position.</summary>
		/// <param name="arg0_useSensors">If true, use the sensor values</param>
		/// <returns>A vector containing the World Absolute Robot Position. (Absolute Position X, Absolute Position Y, Absolute Angle Z)</returns>
        public QiValue GetRobotPosition(bool arg0_useSensors)
        {
            return SourceService["getRobotPosition"].Call(arg0_useSensors);
        }

        /// <summary>Gets the World Absolute next Robot Position.In fact in the walk algorithm some foot futur foot step are incompressible due to preview control, so this function give the next robot position which is incompressible.If the robot doesn't walk this function is equivalent to getRobotPosition(false)</summary>
		/// <returns>A vector containing the World Absolute next Robot position.(Absolute Position X, Absolute Position Y, Absolute Angle Z)</returns>
        public QiValue GetNextRobotPosition()
        {
            return SourceService["getNextRobotPosition"].Call();
        }

        /// <summary>Get the relative position of the robot if stop move is called now.</summary>
		/// <returns>A vector containing the Relative Position. (Position X, Position Y, Angle Z)</returns>
        public QiValue _getStopMovePosition()
        {
            return SourceService["_getStopMovePosition"].Call();
        }

        /// <summary>Gets the World Absolute Robot Velocity.</summary>
		/// <returns>A vector containing the World Absolute Robot Velocity. (Absolute Velocity Translation X [m.s-1], Absolute Velocity Translation Y[m.s-1], Absolute Velocity Rotation WZ [rd.s-1])</returns>
        public QiValue GetRobotVelocity()
        {
            return SourceService["getRobotVelocity"].Call();
        }

        /// <summary>Get the absolute cumulated displacement since robot is up, in robot frame.</summary>
		/// <returns>A vector containing the absolute cumulated displacement, in robot frame. (Absolute Displacement X [m], Absolute Displacement Y[m], Absolute Displacement Theta [rd])</returns>
        public QiValue _getCumulatedDisplacement()
        {
            return SourceService["_getCumulatedDisplacement"].Call();
        }

        /// <summary>DEPRECATED. Gets if Arms Motions are enabled during the Walk Process.</summary>
		/// <returns>True Arm Motions are controlled by the Walk Task.</returns>
        public QiValue GetWalkArmsEnabled()
        {
            return SourceService["getWalkArmsEnabled"].Call();
        }

        /// <summary>DEPRECATED. Sets if Arms Motions are enabled during the Walk Process.</summary>
		/// <param name="arg0_leftArmEnabled">if true Left Arm motions are controlled by the Walk Task</param>
		/// <param name="arg1_rightArmEnabled">if true Right Arm mMotions are controlled by the Walk Task</param>
		/// <returns></returns>
        public void SetWalkArmsEnabled(bool arg0_leftArmEnabled, bool arg1_rightArmEnabled)
        {
            SourceService["setWalkArmsEnabled"].Call(arg0_leftArmEnabled, arg1_rightArmEnabled);
        }

        /// <summary>Gets if Arms Motions are enabled during the Move Process.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;LArm&quot;, &quot;RArm&quot; or &quot;Arms&quot;</param>
		/// <returns>For LArm and RArm true if the corresponding arm is enabled. For Arms, true if both are enabled. False otherwise.</returns>
        public bool GetMoveArmsEnabled(string arg0_chainName)
        {
            return (bool)SourceService["getMoveArmsEnabled"].Call(arg0_chainName);
        }

        /// <summary>Sets if Arms Motions are enabled during the Move Process.</summary>
		/// <param name="arg0_leftArmEnabled">if true Left Arm motions are controlled by the Move Task</param>
		/// <param name="arg1_rightArmEnabled">if true Right Arm mMotions are controlled by the Move Task</param>
		/// <returns></returns>
        public void SetMoveArmsEnabled(bool arg0_leftArmEnabled, bool arg1_rightArmEnabled)
        {
            SourceService["setMoveArmsEnabled"].Call(arg0_leftArmEnabled, arg1_rightArmEnabled);
        }

        /// <summary>DEPRECATED. Use positionInterpolations function instead.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot; </param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_path">Vector of 6D position arrays (x,y,z,wx,wy,wz) in meters and radians</param>
		/// <param name="arg3_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_durations">Vector of times in seconds corresponding to the path points</param>
		/// <param name="arg5_isAbsolute">If true, the movement is absolute else relative</param>
		/// <returns></returns>
        public void PositionInterpolation(string arg0_chainName, int arg1_space, QiAnyValue arg2_path, int arg3_axisMask, QiAnyValue arg4_durations, bool arg5_isAbsolute)
        {
            SourceService["positionInterpolation"].Call(arg0_chainName, arg1_space, arg2_path, arg3_axisMask, arg4_durations, arg5_isAbsolute);
        }

        /// <summary>DEPRECATED. Use the other positionInterpolations function instead.</summary>
		/// <param name="arg0_effectorNames">Vector of chain names. Could be: &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot; </param>
		/// <param name="arg1_taskSpaceForAllPaths">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_paths">Vector of 6D position arrays (x,y,z,wx,wy,wz) in meters and radians</param>
		/// <param name="arg3_axisMasks">Vector of Axis Masks. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_relativeTimes">Vector of times in seconds corresponding to the path points</param>
		/// <param name="arg5_isAbsolute">If true, the movement is absolute else relative</param>
		/// <returns></returns>
        public void PositionInterpolations(IEnumerable<string> arg0_effectorNames, int arg1_taskSpaceForAllPaths, QiAnyValue arg2_paths, QiAnyValue arg3_axisMasks, QiAnyValue arg4_relativeTimes, bool arg5_isAbsolute)
        {
            SourceService["positionInterpolations"].Call(QiList.Create(arg0_effectorNames), arg1_taskSpaceForAllPaths, arg2_paths, arg3_axisMasks, arg4_relativeTimes, arg5_isAbsolute);
        }

        /// <summary>Moves end-effectors to the given positions and orientations over time. This is a blocking call.</summary>
		/// <param name="arg0_effectorNames">Vector of chain names. Could be: &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot; </param>
		/// <param name="arg1_taskSpaceForAllPaths">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_paths">Vector of 6D position arrays (x,y,z,wx,wy,wz) in meters and radians</param>
		/// <param name="arg3_axisMasks">Vector of Axis Masks. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_relativeTimes">Vector of times in seconds corresponding to the path points</param>
		/// <returns></returns>
        public void PositionInterpolations(QiAnyValue arg0_effectorNames, QiAnyValue arg1_taskSpaceForAllPaths, QiAnyValue arg2_paths, QiAnyValue arg3_axisMasks, QiAnyValue arg4_relativeTimes)
        {
            SourceService["positionInterpolations"].Call(arg0_effectorNames, arg1_taskSpaceForAllPaths, arg2_paths, arg3_axisMasks, arg4_relativeTimes);
        }

        /// <summary>Moves an end-effector to DEPRECATED. Use setPositions function instead.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;Head&quot;, &quot;LArm&quot;,&quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_position">6D position array (x,y,z,wx,wy,wz) in meters and radians</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void SetPosition(string arg0_chainName, int arg1_space, IEnumerable<float> arg2_position, float arg3_fractionMaxSpeed, int arg4_axisMask)
        {
            SourceService["setPosition"].Call(arg0_chainName, arg1_space, QiList.Create(arg2_position), arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>Moves multiple end-effectors to the given position and orientation position6d. This is a non-blocking call.</summary>
		/// <param name="arg0_names">The name or names of effector.</param>
		/// <param name="arg1_spaces">The task frame or task frames {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_positions">Position6D arrays</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void SetPositions(QiAnyValue arg0_names, QiAnyValue arg1_spaces, QiAnyValue arg2_positions, float arg3_fractionMaxSpeed, QiAnyValue arg4_axisMask)
        {
            SourceService["setPositions"].Call(arg0_names, arg1_spaces, arg2_positions, arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>DEPRECATED. Use setPositions function instead.</summary>
		/// <param name="arg0_effectorName">Name of the effector.</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_positionChange">6D position change array (xd, yd, zd, wxd, wyd, wzd) in meters and radians</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void ChangePosition(string arg0_effectorName, int arg1_space, IEnumerable<float> arg2_positionChange, float arg3_fractionMaxSpeed, int arg4_axisMask)
        {
            SourceService["changePosition"].Call(arg0_effectorName, arg1_space, QiList.Create(arg2_positionChange), arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>Gets a Position relative to the FRAME. Axis definition: the x axis is positive toward Nao's front, the y from right to left and the z is vertical. The angle convention of Position6D is Rot_z(wz).Rot_y(wy).Rot_x(wx).</summary>
		/// <param name="arg0_name">Name of the item. Could be: Head, LArm, RArm, LLeg, RLeg, Torso, CameraTop, CameraBottom, MicroFront, MicroRear, MicroLeft, MicroRight, Accelerometer, Gyrometer, Laser, LFsrFR, LFsrFL, LFsrRR, LFsrRL, RFsrFR, RFsrFL, RFsrRR, RFsrRL, USSensor1, USSensor2, USSensor3, USSensor4. Use getSensorNames for the list of sensors supported on your robot.</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_useSensorValues">If true, the sensor values will be used to determine the position.</param>
		/// <returns>Vector containing the Position6D using meters and radians (x, y, z, wx, wy, wz)</returns>
        public QiValue GetPosition(string arg0_name, int arg1_space, bool arg2_useSensorValues)
        {
            return SourceService["getPosition"].Call(arg0_name, arg1_space, arg2_useSensorValues);
        }

        /// <summary>DEPRECATED. Use the other transformInterpolations function instead.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;Head&quot;, &quot;LArm&quot;,&quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_path">Vector of Transform arrays</param>
		/// <param name="arg3_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_duration">Vector of times in seconds corresponding to the path points</param>
		/// <param name="arg5_isAbsolute">If true, the movement is absolute else relative</param>
		/// <returns></returns>
        public void TransformInterpolation(string arg0_chainName, int arg1_space, QiAnyValue arg2_path, int arg3_axisMask, QiAnyValue arg4_duration, bool arg5_isAbsolute)
        {
            SourceService["transformInterpolation"].Call(arg0_chainName, arg1_space, arg2_path, arg3_axisMask, arg4_duration, arg5_isAbsolute);
        }

        /// <summary>DEPRECATED. Use the other transformInterpolations function instead.</summary>
		/// <param name="arg0_effectorNames">Vector of chain names. Could be: &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot; </param>
		/// <param name="arg1_taskSpaceForAllPaths">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_paths">Vector of transforms arrays.</param>
		/// <param name="arg3_axisMasks">Vector of Axis Masks. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_relativeTimes">Vector of times in seconds corresponding to the path points</param>
		/// <param name="arg5_isAbsolute">If true, the movement is absolute else relative</param>
		/// <returns></returns>
        public void TransformInterpolations(IEnumerable<string> arg0_effectorNames, int arg1_taskSpaceForAllPaths, QiAnyValue arg2_paths, QiAnyValue arg3_axisMasks, QiAnyValue arg4_relativeTimes, bool arg5_isAbsolute)
        {
            SourceService["transformInterpolations"].Call(QiList.Create(arg0_effectorNames), arg1_taskSpaceForAllPaths, arg2_paths, arg3_axisMasks, arg4_relativeTimes, arg5_isAbsolute);
        }

        /// <summary>Moves end-effectors to the given positions and orientations over time. This is a blocking call.</summary>
		/// <param name="arg0_effectorNames">Vector of chain names. Could be: &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot; </param>
		/// <param name="arg1_taskSpaceForAllPaths">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_paths">Vector of 6D position arrays (x,y,z,wx,wy,wz) in meters and radians</param>
		/// <param name="arg3_axisMasks">Vector of Axis Masks. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <param name="arg4_relativeTimes">Vector of times in seconds corresponding to the path points</param>
		/// <returns></returns>
        public void TransformInterpolations(QiAnyValue arg0_effectorNames, QiAnyValue arg1_taskSpaceForAllPaths, QiAnyValue arg2_paths, QiAnyValue arg3_axisMasks, QiAnyValue arg4_relativeTimes)
        {
            SourceService["transformInterpolations"].Call(arg0_effectorNames, arg1_taskSpaceForAllPaths, arg2_paths, arg3_axisMasks, arg4_relativeTimes);
        }

        /// <summary>Moves an end-effector to DEPRECATED. Use setTransforms function instead.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;Head&quot;, &quot;LArm&quot;,&quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_transform">Transform arrays</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void SetTransform(string arg0_chainName, int arg1_space, IEnumerable<float> arg2_transform, float arg3_fractionMaxSpeed, int arg4_axisMask)
        {
            SourceService["setTransform"].Call(arg0_chainName, arg1_space, QiList.Create(arg2_transform), arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>Moves multiple end-effectors to the given position and orientation transforms. This is a non-blocking call.</summary>
		/// <param name="arg0_names">The name or names of effector.</param>
		/// <param name="arg1_spaces">The task frame or task frames {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_transforms">Transform arrays</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void SetTransforms(QiAnyValue arg0_names, QiAnyValue arg1_spaces, QiAnyValue arg2_transforms, float arg3_fractionMaxSpeed, QiAnyValue arg4_axisMask)
        {
            SourceService["setTransforms"].Call(arg0_names, arg1_spaces, arg2_transforms, arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>DEPRECATED. Use setTransforms function instead.</summary>
		/// <param name="arg0_chainName">Name of the chain. Could be: &quot;Head&quot;, &quot;LArm&quot;,&quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_transform">Transform arrays</param>
		/// <param name="arg3_fractionMaxSpeed">The fraction of maximum speed to use</param>
		/// <param name="arg4_axisMask">Axis mask. True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both </param>
		/// <returns></returns>
        public void ChangeTransform(string arg0_chainName, int arg1_space, IEnumerable<float> arg2_transform, float arg3_fractionMaxSpeed, int arg4_axisMask)
        {
            SourceService["changeTransform"].Call(arg0_chainName, arg1_space, QiList.Create(arg2_transform), arg3_fractionMaxSpeed, arg4_axisMask);
        }

        /// <summary>Gets an Homogenous Transform relative to the FRAME. Axis definition: the x axis is positive toward Nao's front, the y from right to left and the z is vertical.</summary>
		/// <param name="arg0_name">Name of the item. Could be: any joint or chain or sensor (Head, LArm, RArm, LLeg, RLeg, Torso, HeadYaw, ..., CameraTop, CameraBottom, MicroFront, MicroRear, MicroLeft, MicroRight, Accelerometer, Gyrometer, Laser, LFsrFR, LFsrFL, LFsrRR, LFsrRL, RFsrFR, RFsrFL, RFsrRR, RFsrRL, USSensor1, USSensor2, USSensor3, USSensor4. Use getSensorNames for the list of sensors supported on your robot.</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_useSensorValues">If true, the sensor values will be used to determine the position.</param>
		/// <returns>Vector of 16 floats corresponding to the values of the matrix, line by line.</returns>
        public QiValue GetTransform(string arg0_name, int arg1_space, bool arg2_useSensorValues)
        {
            return SourceService["getTransform"].Call(arg0_name, arg1_space, arg2_useSensorValues);
        }

        /// <summary>Gets an Homogenous Transform in World. </summary>
		/// <param name="arg0_sensorName">Name of the sensor</param>
		/// <param name="arg1_time">A qi::ClockTimePoint</param>
		/// <returns>Vector of 16 floats corresponding to the values of the matrix, line by line.</returns>
        public QiValue _getSensorTransformAtTime(string arg0_sensorName, ulong arg1_time)
        {
            return SourceService["_getSensorTransformAtTime"].Call(arg0_sensorName, arg1_time);
        }

        /// <summary>UserFriendly Whole Body API: enable Whole Body Balancer. It's a Generalized Inverse Kinematics which deals with cartesian control, balance, redundancy and task priority. The main goal is to generate and stabilized consistent motions without precomputed trajectories and adapt nao's behaviour to the situation. The generalized inverse kinematic problem takes in account equality constraints (keep foot fix), inequality constraints (joint limits, balance, ...) and quadratic minimization (cartesian / articular desired trajectories). We solve each step a quadratic programming on the robot.</summary>
		/// <param name="arg0_isEnabled">Active / Disactive Whole Body Balancer.</param>
		/// <returns></returns>
        public void WbEnable(bool arg0_isEnabled)
        {
            SourceService["wbEnable"].Call(arg0_isEnabled);
        }

        /// <summary>Enable autobalance on your robot.</summary>
		/// <param name="arg0_isEnabled">Enable or Disable autobalance.</param>
		/// <returns>Success to enable autobalance.</returns>
        public bool _enableAutoBalance(bool arg0_isEnabled)
        {
            return (bool)SourceService["_enableAutoBalance"].Call(arg0_isEnabled);
        }

        /// <summary>Change the support mode to keep balance on a define leg..</summary>
		/// <param name="arg0_isEnabled">Active / Disactive Whole Body Balancer.</param>
		/// <param name="arg1_name">The name of the support leg (&quot;Legs&quot;, &quot;LLeg&quot; or &quot;RLeg&quot;.</param>
		/// <returns>Successfully changed support mode.</returns>
        public bool _changeSupportMode(bool arg0_isEnabled, string arg1_name)
        {
            return (bool)SourceService["_changeSupportMode"].Call(arg0_isEnabled, arg1_name);
        }

        /// <summary>UserFriendly Whole Body API: set the foot state: fixed foot, constrained in a plane or free.</summary>
		/// <param name="arg0_stateName">Name of the foot state. &quot;Fixed&quot; set the foot fixed. &quot;Plane&quot; constrained the Foot in the plane. &quot;Free&quot; set the foot free.</param>
		/// <param name="arg1_supportLeg">Name of the foot. &quot;LLeg&quot;, &quot;RLeg&quot; or &quot;Legs&quot;.</param>
		/// <returns></returns>
        public void WbFootState(string arg0_stateName, string arg1_supportLeg)
        {
            SourceService["wbFootState"].Call(arg0_stateName, arg1_supportLeg);
        }

        /// <summary>UserFriendly Whole Body API: enable to keep balance in support polygon.</summary>
		/// <param name="arg0_isEnable">Enable Robot to keep balance.</param>
		/// <param name="arg1_supportLeg">Name of the support leg: &quot;Legs&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;.</param>
		/// <returns></returns>
        public void WbEnableBalanceConstraint(bool arg0_isEnable, string arg1_supportLeg)
        {
            SourceService["wbEnableBalanceConstraint"].Call(arg0_isEnable, arg1_supportLeg);
        }

        /// <summary>Advanced Whole Body API: &quot;Com&quot; go to a desired support polygon. This is a blocking call.</summary>
		/// <param name="arg0_supportLeg">Name of the support leg: &quot;Legs&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;.</param>
		/// <param name="arg1_duration">Time in seconds. Must be upper 0.5 s.</param>
		/// <returns>A boolean of the success of the go to balance.</returns>
        public bool WbGoToBalance(string arg0_supportLeg, float arg1_duration)
        {
            return (bool)SourceService["wbGoToBalance"].Call(arg0_supportLeg, arg1_duration);
        }

        /// <summary>Advanced Whole Body API: &quot;Com&quot; go to a desired support polygon. This is a blocking call.</summary>
		/// <param name="arg0_supportLeg">Name of the support leg: &quot;Legs&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;.</param>
		/// <param name="arg1_fractionMaxSpeed">The fraction of maximum speed to use.</param>
		/// <returns>A boolean of the success of the go to balance.</returns>
        public bool WbGoToBalanceWithSpeed(string arg0_supportLeg, float arg1_fractionMaxSpeed)
        {
            return (bool)SourceService["wbGoToBalanceWithSpeed"].Call(arg0_supportLeg, arg1_fractionMaxSpeed);
        }

        /// <summary>UserFriendly Whole Body API: enable whole body cartesian control of an effector.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;Head&quot;, &quot;LArm&quot; or &quot;RArm&quot;. Nao goes to posture init. He manages his balance and keep foot fix. &quot;Head&quot; is controlled in rotation. &quot;LArm&quot; and &quot;RArm&quot; are controlled in position.</param>
		/// <param name="arg1_isEnabled">Active / Disactive Effector Control.</param>
		/// <returns></returns>
        public void WbEnableEffectorControl(string arg0_effectorName, bool arg1_isEnabled)
        {
            SourceService["wbEnableEffectorControl"].Call(arg0_effectorName, arg1_isEnabled);
        }

        /// <summary>UserFriendly Whole Body API: set new target for controlled effector. This is a non-blocking call.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;Head&quot;, &quot;LArm&quot; or &quot;RArm&quot;. Nao goes to posture init. He manages his balance and keep foot fix. &quot;Head&quot; is controlled in rotation. &quot;LArm&quot; and &quot;RArm&quot; are controlled in position.</param>
		/// <param name="arg1_targetCoordinate">&quot;Head&quot; is controlled in rotation (WX, WY, WZ). &quot;LArm&quot; and &quot;RArm&quot; are controlled in position (X, Y, Z). TargetCoordinate must be absolute and expressed in FRAME_ROBOT. If the desired position/orientation is unfeasible, target is resize to the nearest feasible motion.</param>
		/// <returns></returns>
        public void WbSetEffectorControl(string arg0_effectorName, QiAnyValue arg1_targetCoordinate)
        {
            SourceService["wbSetEffectorControl"].Call(arg0_effectorName, arg1_targetCoordinate);
        }

        /// <summary>Advanced Whole Body API: enable to control an effector as an optimization.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;All&quot;, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <param name="arg1_isActive">if true, the effector control is taken in acount in the optimization criteria.</param>
		/// <returns></returns>
        public void WbEnableEffectorOptimization(string arg0_effectorName, bool arg1_isActive)
        {
            SourceService["wbEnableEffectorOptimization"].Call(arg0_effectorName, arg1_isActive);
        }

        /// <summary>UserFriendly Whole Body API: get Whole Body Balance State.</summary>
		/// <returns>Name of the Whole Body Balance State (&quot;None&quot;, &quot;LLeg&quot;, &quot;RLeg&quot; or &quot;Legs&quot;). </returns>
        public string _wbGetBalanceState()
        {
            return (string)SourceService["_wbGetBalanceState"].Call();
        }

        /// <summary>UserFriendly Whole Body API: get Whole Body is active.</summary>
		/// <returns>Get Whole Body is active.</returns>
        public bool _wbIsActive()
        {
            return (bool)SourceService["_wbIsActive"].Call();
        }

        /// <summary>UserFriendly Whole Body API: reset the default Whole Body Configuration.</summary>
		/// <returns></returns>
        public void _wbDefaultConfiguration()
        {
            SourceService["_wbDefaultConfiguration"].Call();
        }

        /// <summary>UserFriendly Whole Body API: get the foot state: fixed foot, constrained in a plane or free.</summary>
		/// <param name="arg0_supportLeg">Name of the foot. &quot;LLeg&quot;, &quot;RLeg&quot; or &quot;Legs&quot;.</param>
		/// <returns>Name of the foot state. &quot;Fixed&quot; set the foot fixed. &quot;Plane&quot; constrained the Foot in the plane. &quot;Free&quot; set the foot free.</returns>
        public string _wbGetFootState(string arg0_supportLeg)
        {
            return (string)SourceService["_wbGetFootState"].Call(arg0_supportLeg);
        }

        /// <summary>Advanced Whole Body API: weighting of Joint used in Whole Body Optimization criteria. It is the priority of Joint motion in front of all the other motion task in the quadratic programming optimization.</summary>
		/// <param name="arg0_jointNames">Name or names of joints, chains, &quot;Body&quot; or &quot;Joints&quot;.</param>
		/// <param name="arg1_weightings">Weight used in the Whole Body Articular Optimization.Limits : 0 &amp;lt; weighting &amp;lt;= 1000.0. &quot;articularControl&quot; default value : 1000.0.</param>
		/// <returns></returns>
        public void _wbSetJointWeighting(string arg0_jointNames, float arg1_weightings)
        {
            SourceService["_wbSetJointWeighting"].Call(arg0_jointNames, arg1_weightings);
        }

        /// <summary>Advanced Whole Body API: stiffness of Joint used in Whole Body Optimization criteria. It is the stiffness of Joint motion control used in the quadratic programming optimization.</summary>
		/// <param name="arg0_jointName">Name or names of joints, chains, &quot;Body&quot; or &quot;Joints&quot;.</param>
		/// <param name="arg1_stiffness">Stiffness used in the Whole Body Articular Optimization.Limits : 0 &amp;lt; stiffness &amp;lt;= 100.0.&quot;articularControl&quot; default value : 30.0.</param>
		/// <returns></returns>
        public void _wbSetJointStiffness(string arg0_jointName, float arg1_stiffness)
        {
            SourceService["_wbSetJointStiffness"].Call(arg0_jointName, arg1_stiffness);
        }

        /// <summary>Advanced Whole Body API: preview of Joint Inequality Constraint. It constraint the max joint velocity computed by the quadratic programming. If preview = 1, joint limits can be achieved in 1 step. If preview = 5, joint limits can be achieved in 5 steps. The more preview is, the less desired motion is realised. But the more preview is, the motion safety is increased.</summary>
		/// <param name="arg0_jointName">Name or names of joints, chains, &quot;Body&quot; or &quot;Joints&quot;.</param>
		/// <param name="arg1_preview">Preview used in the Whole Body Inequality Constraints. Between [1 50].articularControl&quot; default value : 1.</param>
		/// <returns></returns>
        public void _wbSetArticularLimitPreview(string arg0_jointName, int arg1_preview)
        {
            SourceService["_wbSetArticularLimitPreview"].Call(arg0_jointName, arg1_preview);
        }

        /// <summary>Advanced Whole Body API: enable to control an effector as a constraint.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;All&quot;, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <param name="arg1_isActive">if true, the effector control is taken in acount in the optimization criteria.</param>
		/// <param name="arg2_axisMask">True for axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both.</param>
		/// <returns></returns>
        public void _wbEnableEffectorConstraint(string arg0_effectorName, bool arg1_isActive, int arg2_axisMask)
        {
            SourceService["_wbEnableEffectorConstraint"].Call(arg0_effectorName, arg1_isActive, arg2_axisMask);
        }

        /// <summary>Advanced Whole Body API: get effector constraint state.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <returns>[isActive, axisMask].</returns>
        public QiValue _wbGetEffectorConstraint(string arg0_effectorName)
        {
            return SourceService["_wbGetEffectorConstraint"].Call(arg0_effectorName);
        }

        /// <summary>Advanced Whole Body API: enable to set the axis mask of an effector.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;All&quot;, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <param name="arg1_isOptimized">if true, the optimized effector axis mask is setting, else it is the constrained effector axis mask.</param>
		/// <param name="arg2_axisMask">Axes that you wish to control. e.g. 7 for position only, 56 for rotation only and 63 for both.</param>
		/// <returns></returns>
        public void _wbAxisMaskEffector(string arg0_effectorName, bool arg1_isOptimized, int arg2_axisMask)
        {
            SourceService["_wbAxisMaskEffector"].Call(arg0_effectorName, arg1_isOptimized, arg2_axisMask);
        }

        /// <summary>Advanced Whole Body API: enable to control a joint as an optimization.</summary>
		/// <param name="arg0_jointName"> &quot;Body&quot;, name of the chain (&quot;LLeg&quot;,...) or name of the joint : &quot;HeadYaw&quot;, &quot;LKneePitch&quot;.</param>
		/// <param name="arg1_isActive">if true, the joint control is taken in acount in the optimization criteria.</param>
		/// <returns></returns>
        public void _wbEnableJointOptimization(string arg0_jointName, bool arg1_isActive)
        {
            SourceService["_wbEnableJointOptimization"].Call(arg0_jointName, arg1_isActive);
        }

        /// <summary>Advanced Whole Body API: get effector constraint state.</summary>
		/// <param name="arg0_effectorName">Name of the effector : &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <returns>[isActive, axisMask].</returns>
        public QiValue _wbGetEffectorOptimization(string arg0_effectorName)
        {
            return SourceService["_wbGetEffectorOptimization"].Call(arg0_effectorName);
        }

        /// <summary>Advanced Whole Body API: set Effector Weighting in the Whole Body Optimization. It is the priority of Effector motion in front of all the other motion task in the quadratic programming optimization.</summary>
		/// <param name="arg0_effectorName">&quot;All&quot;, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <param name="arg1_weightingList">Weighting used in the Whole Body Cartesian Optimization. Limits : 0 &amp;lt; weighting &amp;lt;= 1000.0. Default value is 1000.0. We can give the 6 weights corresponding to the 6 degree of freedom of cartesian motion. (WeightX, WeightY, WeightZ, WeightWX, WeightWY, WeightWZ). We can give 2 weights corresponding to translation and rotation axis (WeightTranslation, WeightTranslation, WeightTranslation, WeightRotation, WeightRotation, WeightRotation). We can give 1 weight, it is the same weight for all the axis (Weight, Weight, Weight, Weight, Weight, Weight).</param>
		/// <returns></returns>
        public void _wbSetEffectorWeight(string arg0_effectorName, QiAnyValue arg1_weightingList)
        {
            SourceService["_wbSetEffectorWeight"].Call(arg0_effectorName, arg1_weightingList);
        }

        /// <summary>Advanced Whole Body API: set Effector Stiffness in Cartesian Control.</summary>
		/// <param name="arg0_effectorName">&quot;All&quot;, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Head&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;LLeg&quot;, &quot;RLeg&quot;, &quot;Torso&quot;, &quot;Com&quot;.</param>
		/// <param name="arg1_stiffnessList">Stiffness used in the Whole Body Cartesian Optimization. Limits : 0 &amp;lt; stiffness &amp;lt;= 100.0. Default value is 10.0. We can give the 6 stiffnesses corresponding to the 6 degree of freedom of cartesian motion. (StiffnessX, StiffnessY, StiffnessZ, StiffnessWX, StiffnessWY, StiffnessWZ). We can give 2 weights corresponding to translation and rotation axis (StiffnessTranslation, StiffnessTranslation, StiffnessTranslation, StiffnessRotation, StiffnessRotation, StiffnessRotation). We can give 1 stiffness, it is the same stiffness for all the axis (Stiffness, Stiffness, Stiffness, Stiffness, Stiffness, Stiffness).</param>
		/// <returns></returns>
        public void _wbSetEffectorStiffness(string arg0_effectorName, QiAnyValue arg1_stiffnessList)
        {
            SourceService["_wbSetEffectorStiffness"].Call(arg0_effectorName, arg1_stiffnessList);
        }

        /// <summary>Enable Anticollision protection of the arms of the robot. Use api isCollision to know if a chain is in collision and can be disactivated.</summary>
		/// <param name="arg0_pChainName">The chain name {&quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <param name="arg1_pEnable">Activate or disactivate the anticollision of the desired Chain.</param>
		/// <returns>A bool which return always true.</returns>
        public bool SetCollisionProtectionEnabled(string arg0_pChainName, bool arg1_pEnable)
        {
            return (bool)SourceService["setCollisionProtectionEnabled"].Call(arg0_pChainName, arg1_pEnable);
        }

        /// <summary>Allow to know if the collision protection is activated on the given chain.</summary>
		/// <param name="arg0_pChainName">The chain name {&quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <returns>Return true is the collision protection of the given Arm is activated.</returns>
        public bool GetCollisionProtectionEnabled(string arg0_pChainName)
        {
            return (bool)SourceService["getCollisionProtectionEnabled"].Call(arg0_pChainName);
        }

        /// <summary>Enable Anticollision protection of the arms and base move  of the robot with external environment.</summary>
		/// <param name="arg0_pName">The name {&quot;All&quot;, &quot;Move&quot;, &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <param name="arg1_pEnable">Activate or disactivate the anticollision of the desired name.</param>
		/// <returns></returns>
        public void SetExternalCollisionProtectionEnabled(string arg0_pName, bool arg1_pEnable)
        {
            SourceService["setExternalCollisionProtectionEnabled"].Call(arg0_pName, arg1_pEnable);
        }

        /// <summary>Enable/Disable physical interaction on a chain without disabling safety completely</summary>
		/// <param name="arg0_pChain">The chain name {&quot;LArm&quot;, &quot;RArm&quot;, &quot;Arms&quot;}</param>
		/// <param name="arg1_pEnabled">True/False</param>
		/// <returns></returns>
        public void _enablePhysicalInteractionForChain(string arg0_pChain, bool arg1_pEnabled)
        {
            SourceService["_enablePhysicalInteractionForChain"].Call(arg0_pChain, arg1_pEnabled);
        }

        /// <summary>Gets chain closest obstacle Position .</summary>
		/// <param name="arg0_pName">The Chain name {&quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <param name="arg1_space">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <returns>Vector containing the Position3D in meters (x, y, z)</returns>
        public QiValue GetChainClosestObstaclePosition(string arg0_pName, int arg1_space)
        {
            return SourceService["getChainClosestObstaclePosition"].Call(arg0_pName, arg1_space);
        }

        /// <summary>Allow to know if the external collision protection is activated on the given name.</summary>
		/// <param name="arg0_pName">The name {&quot;All&quot;, &quot;Move&quot;, &quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <returns>Return true is the external collision protection of the given name is activated.</returns>
        public bool GetExternalCollisionProtectionEnabled(string arg0_pName)
        {
            return (bool)SourceService["getExternalCollisionProtectionEnabled"].Call(arg0_pName);
        }

        /// <summary>Defines the orthogonal security distance used with external collision protection &quot;Move&quot;.</summary>
		/// <param name="arg0_securityDistance">The orthogonal security distance.</param>
		/// <returns></returns>
        public void SetOrthogonalSecurityDistance(float arg0_securityDistance)
        {
            SourceService["setOrthogonalSecurityDistance"].Call(arg0_securityDistance);
        }

        /// <summary>Gets the current orthogonal security distance.</summary>
		/// <returns>The current orthogonal security distance.</returns>
        public float GetOrthogonalSecurityDistance()
        {
            return (float)SourceService["getOrthogonalSecurityDistance"].Call();
        }

        /// <summary>Defines the tangential security distance used with external collision protection &quot;Move&quot;.</summary>
		/// <param name="arg0_securityDistance">The tangential security distance.</param>
		/// <returns></returns>
        public void SetTangentialSecurityDistance(float arg0_securityDistance)
        {
            SourceService["setTangentialSecurityDistance"].Call(arg0_securityDistance);
        }

        /// <summary>Gets the current tangential security distance.</summary>
		/// <returns>The current tangential security distance.</returns>
        public float GetTangentialSecurityDistance()
        {
            return (float)SourceService["getTangentialSecurityDistance"].Call();
        }

        /// <summary>Give the collision state of a chain. If a chain has a collision state &quot;none&quot; or &quot;near&quot;, it could be desactivated. </summary>
		/// <param name="arg0_pChainName">The chain name {&quot;Arms&quot;, &quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <returns>A string which notice the collision state: &quot;none&quot; there are no collision, &quot;near&quot; the collision is taking in account in the anti-collision algorithm, &quot;collision&quot; the chain is in contact with an other body. If the chain asked is &quot;Arms&quot; the most unfavorable result is given. </returns>
        public string IsCollision(string arg0_pChainName)
        {
            return (string)SourceService["isCollision"].Call(arg0_pChainName);
        }

        /// <summary>Allow to know if the collision protection is activated on the given chain  and if stiffness of all chain joint is stricly positif.</summary>
		/// <param name="arg0_pChainName">The chain name {&quot;LArm&quot; or &quot;RArm&quot;}.</param>
		/// <returns>Return true is the collision protection of the given Arm is activated.</returns>
        public bool _getCollisionStateForObstacleSummary(string arg0_pChainName)
        {
            return (bool)SourceService["_getCollisionStateForObstacleSummary"].Call(arg0_pChainName);
        }

        /// <summary>DEPRECATED: use _getCollisionShapes. Gets the list of collision supported on your robot.</summary>
		/// <returns>Vector of collision names, radius, parent joint name and parentjoint position.</returns>
        public string[] _getCollisionNames()
        {
            return (string[])SourceService["_getCollisionNames"].Call();
        }

        /// <summary>Gets the list of dynamic collisions in torso frame.</summary>
		/// <param name="arg0_pName">The name {&quot;static&quot; or &quot;dynamic&quot;}.</param>
		/// <returns>Vector of collisions name, radius, parent joint name andparent joint position.</returns>
        public QiValue _getCollisionShapes(string arg0_pName)
        {
            return SourceService["_getCollisionShapes"].Call(arg0_pName);
        }

        /// <summary>Set dynamic collision shape for people collision avoidance</summary>
		/// <param name="arg0_pNameList">A vector of names.</param>
		/// <param name="arg1_pPairList">A vector of names. &quot;All&quot;, &quot;Sphere&quot;, &quot;Pill&quot; or the collision nameof LArm or RArm.</param>
		/// <param name="arg2_pBodyList">A vector of body names. Dynamic collision is attached to this body.</param>
		/// <param name="arg3_pTypeList">A vector of names. &quot;Sphere&quot;, &quot;Plan&quot;, &quot;Pill&quot; or &quot;Tab&quot;.</param>
		/// <param name="arg4_pShapeList">A vector of shape data.</param>
		/// <param name="arg5_pPositionList">An ALValue containing a list of position of the shape.</param>
		/// <returns></returns>
        public void _setCollisionShapes(IEnumerable<string> arg0_pNameList, IEnumerable<string> arg1_pPairList, IEnumerable<string> arg2_pBodyList, IEnumerable<string> arg3_pTypeList, QiAnyValue arg4_pShapeList, QiAnyValue arg5_pPositionList)
        {
            SourceService["_setCollisionShapes"].Call(QiList.Create(arg0_pNameList), QiList.Create(arg1_pPairList), QiList.Create(arg2_pBodyList), QiList.Create(arg3_pTypeList), arg4_pShapeList, arg5_pPositionList);
        }

        /// <summary>Deprecated: Use setCollisionShapes with typeList. Set dynamic collision shape for people collision avoidance</summary>
		/// <param name="arg0_pNameList">A vector of names.</param>
		/// <param name="arg1_pPairList">A vector of names. &quot;All&quot;, &quot;Sphere&quot;, &quot;Pill&quot; or the collision nameof LArm or RArm.</param>
		/// <param name="arg2_pShapeList">A vector of shape data.</param>
		/// <param name="arg3_pPositionList">An ALValue containing a list of position of the shape.</param>
		/// <returns></returns>
        public void _setCollisionShapes(IEnumerable<string> arg0_pNameList, IEnumerable<string> arg1_pPairList, QiAnyValue arg2_pShapeList, QiAnyValue arg3_pPositionList)
        {
            SourceService["_setCollisionShapes"].Call(QiList.Create(arg0_pNameList), QiList.Create(arg1_pPairList), arg2_pShapeList, arg3_pPositionList);
        }

        /// <summary>Gets the list of detected collisions supported on your robot.</summary>
		/// <param name="arg0_pMinimumDistance">Distance to take into account collision pair.</param>
		/// <returns>Vector of collisions: [nameShape1, nameShape2, distance].</returns>
        public QiValue _getDetectedCollisions(float arg0_pMinimumDistance)
        {
            return SourceService["_getDetectedCollisions"].Call(arg0_pMinimumDistance);
        }

        /// <summary>Gets the list of detected collisions supported on your robot.</summary>
		/// <returns>Vector of collisions: [nameShape1, nameShape2, distance].</returns>
        public QiValue _getDetectedCollisionsFull()
        {
            return SourceService["_getDetectedCollisionsFull"].Call();
        }

        /// <summary>Gets the polygon checked for safety during move.</summary>
		/// <returns>A vector of Position2D.</returns>
        public QiValue _getDangerousRegion()
        {
            return SourceService["_getDangerousRegion"].Call();
        }

        /// <summary>Enable The fall manager protection for the robot. When a fall is detected the robot adopt a joint configuration to protect himself and cut the stiffness.. An memory event called &quot;robotHasFallen&quot; is generated when the fallManager have been activated.</summary>
		/// <param name="arg0_pEnable">Activate or disactivate the smart stiffness.</param>
		/// <returns></returns>
        public void SetFallManagerEnabled(bool arg0_pEnable)
        {
            SourceService["setFallManagerEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Give the state of the fall manager.</summary>
		/// <returns>Return true is the fall manager is activated. </returns>
        public bool GetFallManagerEnabled()
        {
            return (bool)SourceService["getFallManagerEnabled"].Call();
        }

        /// <summary>Enable The push recovery protection for the robot. </summary>
		/// <param name="arg0_pEnable">Enable the push recovery.</param>
		/// <returns></returns>
        public void SetPushRecoveryEnabled(bool arg0_pEnable)
        {
            SourceService["setPushRecoveryEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Enable The push recovery protection for the robot. </summary>
		/// <param name="arg0_pEnable">Enable the push recovery.</param>
		/// <returns></returns>
        public void _setPushRecoveryEnabled(bool arg0_pEnable)
        {
            SourceService["_setPushRecoveryEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Give the state of the push recovery.</summary>
		/// <returns>Return true is the push recovery is activated. </returns>
        public bool GetPushRecoveryEnabled()
        {
            return (bool)SourceService["getPushRecoveryEnabled"].Call();
        }

        /// <summary>Enable Smart Stiffness for all the joints (True by default), the update take one motion cycle for updating. The smart Stiffness is a gestion of joint maximum torque. More description is available on the red documentation of ALMotion module.</summary>
		/// <param name="arg0_pEnable">Activate or disactivate the smart stiffness.</param>
		/// <returns></returns>
        public void SetSmartStiffnessEnabled(bool arg0_pEnable)
        {
            SourceService["setSmartStiffnessEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Give the state of the smart Stiffness.</summary>
		/// <returns>Return true is the smart Stiffnes is activated. </returns>
        public bool GetSmartStiffnessEnabled()
        {
            return (bool)SourceService["getSmartStiffnessEnabled"].Call();
        }

        /// <summary>Enable or disable the diagnosis effect into ALMotion</summary>
		/// <param name="arg0_pEnable">Enable or disable the diagnosis effect.</param>
		/// <returns></returns>
        public void SetDiagnosisEffectEnabled(bool arg0_pEnable)
        {
            SourceService["setDiagnosisEffectEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Give the state of the diagnosis effect.</summary>
		/// <returns>Return true is the diagnosis reflex is activated. </returns>
        public bool GetDiagnosisEffectEnabled()
        {
            return (bool)SourceService["getDiagnosisEffectEnabled"].Call();
        }

        /// <summary>DEPRECATED. Use getBodyNames function instead.</summary>
		/// <param name="arg0_name">Name of a chain, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Body&quot;, &quot;Chains&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <returns>Vector of strings, one for each joint in the collection</returns>
        public string[] GetJointNames(string arg0_name)
        {
            return (string[])SourceService["getJointNames"].Call(arg0_name);
        }

        /// <summary>Gets the names of all the joints and actuators in the collection.</summary>
		/// <param name="arg0_name">Name of a chain, &quot;Arms&quot;, &quot;Legs&quot;, &quot;Body&quot;, &quot;Chains&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;.</param>
		/// <returns>Vector of strings, one for each joint and actuator in the collection</returns>
        public string[] GetBodyNames(string arg0_name)
        {
            return (string[])SourceService["getBodyNames"].Call(arg0_name);
        }

        /// <summary>Gets the list of sensors supported on your robot.</summary>
		/// <returns>Vector of sensor names</returns>
        public string[] GetSensorNames()
        {
            return (string[])SourceService["getSensorNames"].Call();
        }

        /// <summary>Get the minAngle (rad), maxAngle (rad), and maxVelocity (rad.s-1) for a given joint or actuator in the body.</summary>
		/// <param name="arg0_name">Name of a joint, chain, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <returns>Array of ALValue arrays containing the minAngle, maxAngle, maxVelocity and maxTorque for all the bodies specified.</returns>
        public QiValue GetLimits(string arg0_name)
        {
            return SourceService["getLimits"].Call(arg0_name);
        }

        /// <summary>Get the minAngle (rad), maxAngle (rad), and maxVelocity (rad.s-1) for a given joint or actuator in the body.</summary>
		/// <param name="arg0_name">Name of a joint, chain, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <returns>Array of ALValue arrays containing the minAngle, maxAngle, maxVelocity, maxTorque, Kc, reduction, efficiency and maxCurrent for all the bodies specified.</returns>
        public QiValue _getFullLimits(string arg0_name)
        {
            return SourceService["_getFullLimits"].Call(arg0_name);
        }

        /// <summary>Get the motion cycle time in milliseconds.</summary>
		/// <returns>Expressed in milliseconds</returns>
        public int GetMotionCycleTime()
        {
            return (int)SourceService["getMotionCycleTime"].Call();
        }

        /// <summary>Get the motion cycle number in int.</summary>
		/// <returns>Expressed in int.</returns>
        public int _getMotionCycleNumber()
        {
            return (int)SourceService["_getMotionCycleNumber"].Call();
        }

        /// <summary>Get the robot configuration. DEPRECATED. use ALRobotModel</summary>
		/// <returns>ALValue arrays containing the robot parameter names and the robot parameter values.</returns>
        public QiValue GetRobotConfig()
        {
            return SourceService["getRobotConfig"].Call();
        }

        /// <summary>Returns a string representation of the Model's state</summary>
		/// <returns>A formated string</returns>
        public string GetSummary()
        {
            return (string)SourceService["getSummary"].Call();
        }

        /// <summary>Returns a string representation of the Model's state</summary>
		/// <returns>A formated string</returns>
        public string _getSummary()
        {
            return (string)SourceService["_getSummary"].Call();
        }

        /// <summary>Gets the mass of a joint, chain, &quot;Body&quot; or &quot;Joints&quot;.</summary>
		/// <param name="arg0_pName">Name of the body which we want the mass. &quot;Body&quot;, &quot;Joints&quot; and &quot;Com&quot; give the total mass of nao. For the chain, it gives the total mass of the chain.</param>
		/// <returns>The mass in kg.</returns>
        public float GetMass(string arg0_pName)
        {
            return (float)SourceService["getMass"].Call(arg0_pName);
        }

        /// <summary>Gets the COM of a joint, chain, &quot;Body&quot; or &quot;Joints&quot;.</summary>
		/// <param name="arg0_pName">Name of the body which we want the mass. In chain name case, this function give the com of the chain.</param>
		/// <param name="arg1_pSpace">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pUseSensorValues">If true, the sensor values will be used to determine the position.</param>
		/// <returns>The COM position (meter).</returns>
        public QiValue GetCOM(string arg0_pName, int arg1_pSpace, bool arg2_pUseSensorValues)
        {
            return SourceService["getCOM"].Call(arg0_pName, arg1_pSpace, arg2_pUseSensorValues);
        }

        /// <summary>Gets the support polygon</summary>
		/// <param name="arg0_pSpace">Task frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg1_pUseSensorValues">If true, the sensor values will be used to determine the position.</param>
		/// <returns>A vector containing the x,y coordinates of each of the outer points of the support polygon in specified frame.</returns>
        public QiValue GetSupportPolygon(int arg0_pSpace, bool arg1_pUseSensorValues)
        {
            return SourceService["getSupportPolygon"].Call(arg0_pSpace, arg1_pUseSensorValues);
        }

        /// <summary>Gets the support polygon</summary>
		/// <param name="arg0_pName">LLeg or RLeg</param>
		/// <returns>A vector containing the x,y coordinates of each of the outer points of the support polygon in specified frame.</returns>
        public QiValue _getSupportPolygonBipedDebug(string arg0_pName)
        {
            return SourceService["_getSupportPolygonBipedDebug"].Call(arg0_pName);
        }

        /// <summary>Gets the torque of the joints</summary>
		/// <param name="arg0_names">Names the joints, chains, &quot;Body&quot;, &quot;Joints&quot;. </param>
		/// <param name="arg1_useSensor">If true, return the sensor torque.</param>
		/// <returns>Torques in N.m.</returns>
        public QiValue _getTorque(QiAnyValue arg0_names, bool arg1_useSensor)
        {
            return SourceService["_getTorque"].Call(arg0_names, arg1_useSensor);
        }

        /// <summary>Gets the inertia matrice of a joint or &quot;Torso&quot;.</summary>
		/// <param name="arg0_pName">Name of the joint or &quot;Torso&quot;. Inertia is given in the COM of the body, in poseZero orientation.</param>
		/// <returns>The inertia matrix (kg.m2).</returns>
        public QiValue _getInertia(string arg0_pName)
        {
            return SourceService["_getInertia"].Call(arg0_pName);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void SetMotionConfig(QiAnyValue arg0_config)
        {
            SourceService["setMotionConfig"].Call(arg0_config);
        }

        /// <summary>Callback naoqi is ready.</summary>
		/// <returns></returns>
        public void _naoqiIsReadyCallback()
        {
            SourceService["_naoqiIsReadyCallback"].Call();
        }

        /// <summary>Callback preferences changed.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _preferenceUpdatedCallback(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_preferenceUpdatedCallback"].Call(arg0, arg1, arg2);
        }

        /// <summary>Interpolate with head with prediction.This function is mainly use by the tracker modules.</summary>
		/// <param name="arg0_pNames">list of Joints Names.</param>
		/// <param name="arg1_pTargetPositions">list of Joints angles.</param>
		/// <param name="arg2_pLimits">list of Joints limits.</param>
		/// <returns></returns>
        public void _trackerLookAt(IEnumerable<string> arg0_pNames, IEnumerable<float> arg1_pTargetPositions, QiAnyValue arg2_pLimits)
        {
            SourceService["_trackerLookAt"].Call(QiList.Create(arg0_pNames), QiList.Create(arg1_pTargetPositions), arg2_pLimits);
        }

        /// <summary>lookAt in Whole Body mode.</summary>
		/// <param name="arg0_pTargetWy">The target position wy in FRAME_ROBOT</param>
		/// <param name="arg1_pTargetWz">The target position wz in FRAME_ROBOT</param>
		/// <returns></returns>
        public void _lookAtWb(float arg0_pTargetWy, float arg1_pTargetWz)
        {
            SourceService["_lookAtWb"].Call(arg0_pTargetWy, arg1_pTargetWz);
        }

        /// <summary>lookAt in Whole Body mode.</summary>
		/// <param name="arg0_pTargetWy">The target position wy in FRAME_ROBOT</param>
		/// <param name="arg1_pTargetWz">The target position wz in FRAME_ROBOT</param>
		/// <param name="arg2_pMaxSpeedFraction">fraction max speed.</param>
		/// <returns></returns>
        public void _lookAtWbWithSpeed(float arg0_pTargetWy, float arg1_pTargetWz, float arg2_pMaxSpeedFraction)
        {
            SourceService["_lookAtWbWithSpeed"].Call(arg0_pTargetWy, arg1_pTargetWz, arg2_pMaxSpeedFraction);
        }

        /// <summary>Interpolate with hands with prediction.This function is mainly use by the tracker modules.</summary>
		/// <param name="arg0_pNames">list of Joints Names.</param>
		/// <param name="arg1_pTargetPositions">list of Joints angles.</param>
		/// <returns></returns>
        public void _trackerPointAt(IEnumerable<string> arg0_pNames, IEnumerable<float> arg1_pTargetPositions)
        {
            SourceService["_trackerPointAt"].Call(QiList.Create(arg0_pNames), QiList.Create(arg1_pTargetPositions));
        }

        /// <summary>Interpolate with speed without prediction.</summary>
		/// <param name="arg0_pNames">list of Joints Names.</param>
		/// <param name="arg1_pTargetPositions">list of Joints angles.</param>
		/// <param name="arg2_pTimeSinceDetectionMs">The time in Ms since the target was detected</param>
		/// <param name="arg3_pMaxSpeedFraction">fraction max speed list.</param>
		/// <param name="arg4_pUseOfWholeBody">If true, the target is follow in cartesian space by the Head with whole Body constraints.</param>
		/// <returns></returns>
        public void _trackerWithSpeed(IEnumerable<string> arg0_pNames, IEnumerable<float> arg1_pTargetPositions, IEnumerable<float> arg2_pTimeSinceDetectionMs, bool arg3_pMaxSpeedFraction, bool arg4_pUseOfWholeBody)
        {
            SourceService["_trackerWithSpeed"].Call(QiList.Create(arg0_pNames), QiList.Create(arg1_pTargetPositions), QiList.Create(arg2_pTimeSinceDetectionMs), arg3_pMaxSpeedFraction, arg4_pUseOfWholeBody);
        }

        /// <summary>lookAt</summary>
		/// <param name="arg0_pTargetPosition">position 3D to look at.</param>
		/// <param name="arg1_pFrame">Target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pMaxSpeedFraction">fraction max speed.</param>
		/// <returns></returns>
        public void _lookAt(IEnumerable<float> arg0_pTargetPosition, int arg1_pFrame, float arg2_pMaxSpeedFraction)
        {
            SourceService["_lookAt"].Call(QiList.Create(arg0_pTargetPosition), arg1_pFrame, arg2_pMaxSpeedFraction);
        }

        /// <summary>lookAt</summary>
		/// <param name="arg0_pTargetPosition">position 3D to look at.</param>
		/// <param name="arg1_pFrame">Target frame {FRAME_TORSO = 0, FRAME_WORLD = 1, FRAME_ROBOT = 2}.</param>
		/// <param name="arg2_pEffectorId">effector id {Middle of eyes = 0, Camera Top = 1, Camera Bottom = 2}.</param>
		/// <param name="arg3_pMaxSpeedFraction">fraction max speed.</param>
		/// <returns></returns>
        public void _lookAt(IEnumerable<float> arg0_pTargetPosition, int arg1_pFrame, int arg2_pEffectorId, float arg3_pMaxSpeedFraction)
        {
            SourceService["_lookAt"].Call(QiList.Create(arg0_pTargetPosition), arg1_pFrame, arg2_pEffectorId, arg3_pMaxSpeedFraction);
        }

        /// <summary>Stop lookAt taskThis function is mainly use by the tracker modules.</summary>
		/// <param name="arg0_pWithSpeed">if True stop lookAtWithSpeed task.</param>
		/// <returns></returns>
        public void _stopLookAt(bool arg0_pWithSpeed)
        {
            SourceService["_stopLookAt"].Call(arg0_pWithSpeed);
        }

        /// <summary>Stop PointAt taskThis function is mainly use by the tracker modules.</summary>
		/// <param name="arg0_pWithSpeed">if True stop pointAtWithSpeed task.</param>
		/// <returns></returns>
        public void _stopPointAt(bool arg0_pWithSpeed)
        {
            SourceService["_stopPointAt"].Call(arg0_pWithSpeed);
        }

        /// <summary>Update obstacles</summary>
		/// <param name="arg0_obstacles">List of closest obstacles [[x, y, z]...]</param>
		/// <param name="arg1_blindZones">List of blind zones [[Position2D, Position2D...]...]</param>
		/// <returns></returns>
        public void _updateObstacles(QiAnyValue arg0_obstacles, QiAnyValue arg1_blindZones)
        {
            SourceService["_updateObstacles"].Call(arg0_obstacles, arg1_blindZones);
        }

        /// <summary>This function starts or stops breathing animation on a chain.Chain name can be &quot;Body&quot;, &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;Legs&quot; or &quot;Head&quot;.Head breathing animation will work only if Leg animation is active.</summary>
		/// <param name="arg0_pChain">Chain name.</param>
		/// <param name="arg1_pIsEnabled">Enables / disables the chain.</param>
		/// <returns></returns>
        public void SetBreathEnabled(string arg0_pChain, bool arg1_pIsEnabled)
        {
            SourceService["setBreathEnabled"].Call(arg0_pChain, arg1_pIsEnabled);
        }

        /// <summary>This function gets the status of breathing animation on a chain.Chain name can be &quot;Body&quot;, &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;Legs&quot; or &quot;Head&quot;.</summary>
		/// <param name="arg0_pChain">Chain name.</param>
		/// <returns>True if breathing animation is enabled on the chain.</returns>
        public bool GetBreathEnabled(string arg0_pChain)
        {
            return (bool)SourceService["getBreathEnabled"].Call(arg0_pChain);
        }

        /// <summary>This function configures the breathing animation.</summary>
		/// <param name="arg0_pConfig">Breath configuration.An ALValue of the form [[&quot;Bpm&quot;, pBpm], [&quot;Amplitude&quot;, pAmplitude]].pBpm is a float between 10 and 50 setting the breathing frequency in beats per minute.pAmplitude is a float between 0 and 1 setting the amplitude of the breathing animation.</param>
		/// <returns></returns>
        public void SetBreathConfig(QiAnyValue arg0_pConfig)
        {
            SourceService["setBreathConfig"].Call(arg0_pConfig);
        }

        /// <summary>This function gets the current breathing configuration.</summary>
		/// <returns>An ALValue of the form [[&quot;Bpm&quot;, bpm], [&quot;Amplitude&quot;, amplitude]].bpm is the breathing frequency in beats per minute.amplitude is the normalized amplitude of the breathing animation, between 0 and 1.</returns>
        public QiValue GetBreathConfig()
        {
            return SourceService["getBreathConfig"].Call();
        }

        /// <summary>Starts or stops idle posture management on a chain.Chain name can be &quot;Body&quot;, &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;Legs&quot; or &quot;Head&quot;.</summary>
		/// <param name="arg0_pChain">Chain name.</param>
		/// <param name="arg1_pIsEnabled">Enables / disables the chain.</param>
		/// <returns></returns>
        public void SetIdlePostureEnabled(string arg0_pChain, bool arg1_pIsEnabled)
        {
            SourceService["setIdlePostureEnabled"].Call(arg0_pChain, arg1_pIsEnabled);
        }

        /// <summary>This function gets the status of idle posture management on a chain.Chain name can be &quot;Body&quot;, &quot;Arms&quot;, &quot;LArm&quot;, &quot;RArm&quot;, &quot;Legs&quot; or &quot;Head&quot;.</summary>
		/// <param name="arg0_pChain">Chain name.</param>
		/// <returns>True if breathing animation is enabled on the chain.</returns>
        public bool GetIdlePostureEnabled(string arg0_pChain)
        {
            return (bool)SourceService["getIdlePostureEnabled"].Call(arg0_pChain);
        }

        /// <summary>Gets an ALValue structure describing the tasks in the Task List</summary>
		/// <returns>An ALValue containing an ALValue for each task. The inner ALValue contains: Name, MotionID</returns>
        public QiValue GetTaskList()
        {
            return SourceService["getTaskList"].Call();
        }

        /// <summary>Returns true if all the desired resources are available. Only motion API's' blocking call takes resources.</summary>
		/// <param name="arg0_resourceNames">A vector of resource names such as joints. Use getBodyNames(&quot;Body&quot;) to have the list of the available joint for your robot.</param>
		/// <returns>True if the resources are available</returns>
        public bool AreResourcesAvailable(IEnumerable<string> arg0_resourceNames)
        {
            return (bool)SourceService["areResourcesAvailable"].Call(QiList.Create(arg0_resourceNames));
        }

        /// <summary>Kills a motion task.</summary>
		/// <param name="arg0_motionTaskID">TaskID of the motion task you want to kill.</param>
		/// <returns>Return true if the specified motionTaskId has been killed.</returns>
        public bool KillTask(int arg0_motionTaskID)
        {
            return (bool)SourceService["killTask"].Call(arg0_motionTaskID);
        }

        /// <summary>Kills all tasks that use any of the resources given. Only motion API's' blocking call takes resources and can be killed. Use getBodyNames(&quot;Body&quot;) to have the list of the available joint for your robot.</summary>
		/// <param name="arg0_resourceNames">A vector of resource joint names</param>
		/// <returns></returns>
        public void KillTasksUsingResources(IEnumerable<string> arg0_resourceNames)
        {
            SourceService["killTasksUsingResources"].Call(QiList.Create(arg0_resourceNames));
        }

        /// <summary>DEPRECATED. Use killMove function instead.</summary>
		/// <returns></returns>
        public void KillWalk()
        {
            SourceService["killWalk"].Call();
        }

        /// <summary>Emergency Stop on Move task: This method will end the move task brutally, without attempting to return to a balanced state. The robot could easily fall.</summary>
		/// <returns></returns>
        public void KillMove()
        {
            SourceService["killMove"].Call();
        }

        /// <summary>Kills all tasks.</summary>
		/// <returns></returns>
        public void KillAll()
        {
            SourceService["killAll"].Call();
        }

        /// <summary>Enable / Disable notifications.</summary>
		/// <param name="arg0_enable">If True enable notifications. If False disable notifications.</param>
		/// <returns></returns>
        public void SetEnableNotifications(bool arg0_enable)
        {
            SourceService["setEnableNotifications"].Call(arg0_enable);
        }

        /// <summary>Return true if notifications are active.</summary>
		/// <returns>Return True if notifications are active.</returns>
        public bool AreNotificationsEnabled()
        {
            return (bool)SourceService["areNotificationsEnabled"].Call();
        }

        /// <summary>Gets the list of collision with the ground.</summary>
		/// <returns>Vector of collision names and position in torso frame</returns>
        public QiValue _getGroundCollision()
        {
            return SourceService["_getGroundCollision"].Call();
        }

        /// <summary>Gets the list of collision with the ground.</summary>
		/// <returns>Vector of collision names and position in torso frame</returns>
        public QiValue _getGroundCollisionForForceContact()
        {
            return SourceService["_getGroundCollisionForForceContact"].Call();
        }

        /// <summary>Gets the list of collision with the ground.</summary>
		/// <returns>Vector of collision names and position in torso frame</returns>
        public QiValue _getGroundCollisionForFallManager()
        {
            return SourceService["_getGroundCollisionForFallManager"].Call();
        }

        /// <summary>Gets the ground plane transform in torso frame.</summary>
		/// <returns>the ground plane transform in torso frame</returns>
        public QiValue _getGroundPlaneTf()
        {
            return SourceService["_getGroundPlaneTf"].Call();
        }

        /// <summary>Gets the Normal Force Contact.</summary>
		/// <returns>Vector of normal Force contact</returns>
        public QiValue _getNormalForceContact()
        {
            return SourceService["_getNormalForceContact"].Call();
        }

        /// <summary>It's a getPosition on Torso with inertial Information.This function is used in chorgraphe in 3D View</summary>
		/// <returns>a transform of the Torso position</returns>
        public QiValue _getRealTorsoInWorld()
        {
            return SourceService["_getRealTorsoInWorld"].Call();
        }

        /// <summary></summary>
		/// <returns>Array of ALValue arrays containing the sphere position2D and radius.</returns>
        public QiValue _getRobotGroundConvexHullDebug()
        {
            return SourceService["_getRobotGroundConvexHullDebug"].Call();
        }

        /// <summary>Get the robot convex hull projected on the ground in the ROBOT_FRAME.</summary>
		/// <returns>Array of ALValue arrays containing the position2D of each convex hull points.</returns>
        public QiValue _getRobotGroundConvexHull()
        {
            return SourceService["_getRobotGroundConvexHull"].Call();
        }

        /// <summary>Gets if the joints is moving</summary>
		/// <param name="arg0_useSensors">If true, sensor information will be returned</param>
		/// <returns>a vector of boolean.</returns>
        public int[] _getJointIsMoving(bool arg0_useSensors)
        {
            return (int[])SourceService["_getJointIsMoving"].Call(arg0_useSensors);
        }

        /// <summary>Gets if the chain is moving</summary>
		/// <param name="arg0_useSensors">If true, sensor information will be returned</param>
		/// <returns>a vector of boolean.</returns>
        public int[] _getChainIsMoving(bool arg0_useSensors)
        {
            return (int[])SourceService["_getChainIsMoving"].Call(arg0_useSensors);
        }

        /// <summary>In fact, it's an hide way to allow the fall manager to disable the fall manager. Note, it's inverse (true set fall to false)</summary>
		/// <param name="arg0_pEnable">Activate or disactivate the animation Mode.</param>
		/// <returns></returns>
        public void _setAnimationModeEnabled(bool arg0_pEnable)
        {
            SourceService["_setAnimationModeEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Get the motion configuration.</summary>
		/// <param name="arg0_pName">&quot;All&quot;, &quot;State&quot;, &quot;Mode&quot;, &quot;Protection&quot;, &quot;Collision&quot;, &quot;Basic&quot;, &quot;Move&quot;, &quot;Tracker&quot;, &quot;Walk&quot;, &quot;OmniWheel&quot;, &quot;Log&quot;, &quot;RobotState&quot;, &quot;Duration&quot;, &quot;Control&quot;, &quot;SmartStiffness&quot;,&quot;WB&quot;, &quot;FallManager&quot;.</param>
		/// <returns>string contraining all the information.</returns>
        public string _getMotionConfig(string arg0_pName)
        {
            return (string)SourceService["_getMotionConfig"].Call(arg0_pName);
        }

        /// <summary>Gets the center of the support polygon in frame robot.</summary>
		/// <returns>A vector containing the x,y coordinates of the center of the support polygon</returns>
        public QiValue _getSupportPolygonCenter()
        {
            return SourceService["_getSupportPolygonCenter"].Call();
        }

        /// <summary>Gets the support polygon</summary>
		/// <returns>A Position3D (x,y,z) coordinates of com in World Space</returns>
        public QiValue _getComWorld()
        {
            return SourceService["_getComWorld"].Call();
        }

        /// <summary>Gets the support polygon</summary>
		/// <returns>A Rotation3D (wx,wy,0) coresponding to world rotation</returns>
        public QiValue _getWorldRotation()
        {
            return SourceService["_getWorldRotation"].Call();
        }

        /// <summary>Activate the fall task</summary>
		/// <param name="arg0_pFallAngle">The fall angle in degree.</param>
		/// <returns></returns>
        public void _fall(float arg0_pFallAngle)
        {
            SourceService["_fall"].Call(arg0_pFallAngle);
        }

        /// <summary>Activate the omniwheel task to recover balance.</summary>
		/// <returns></returns>
        public void _balanceRecovery()
        {
            SourceService["_balanceRecovery"].Call();
        }

        /// <summary>A patch to avoid to consume too much current after a SitDown.</summary>
		/// <returns></returns>
        public void _relaxMotorsWhenSitting()
        {
            SourceService["_relaxMotorsWhenSitting"].Call();
        }

        /// <summary>Relax a chain.</summary>
		/// <param name="arg0_chainName">The name of the chain to relax.</param>
		/// <param name="arg1_delayInSeconds">The duration the low stiffness time.</param>
		/// <returns></returns>
        public void _relax(QiAnyValue arg0_chainName, float arg1_delayInSeconds)
        {
            SourceService["_relax"].Call(arg0_chainName, arg1_delayInSeconds);
        }

        /// <summary>Reset to false the bool Cartesian Unfeasible: used for testing motion.</summary>
		/// <returns></returns>
        public void _resetCartesianUnfeasible()
        {
            SourceService["_resetCartesianUnfeasible"].Call();
        }

        /// <summary>et to true the bool Cartesian Unfeasible: used for testing motion.</summary>
		/// <returns></returns>
        public void _setCartesianUnfeasible()
        {
            SourceService["_setCartesianUnfeasible"].Call();
        }

        /// <summary>Get the Cartesian Unfeasible state since last reset: used for testing motion.</summary>
		/// <returns>True if there are one cartesian unfeasible during one motion cycle since last reset.</returns>
        public int _getCartesianUnfeasible()
        {
            return (int)SourceService["_getCartesianUnfeasible"].Call();
        }

        /// <summary>Save current whole body dump</summary>
		/// <returns></returns>
        public void _saveWholeBodyDump()
        {
            SourceService["_saveWholeBodyDump"].Call();
        }

        /// <summary>Reset the number of joint command discontinuous updates.</summary>
		/// <returns></returns>
        public void _resetNumJointCommandDiscontinuities()
        {
            SourceService["_resetNumJointCommandDiscontinuities"].Call();
        }

        /// <summary>Get the number of joint command discontinuous updates since last reset.</summary>
		/// <returns>The number of discontinuities since last reset.</returns>
        public uint _getNumJointCommandDiscontinuities()
        {
            return (uint)SourceService["_getNumJointCommandDiscontinuities"].Call();
        }

        /// <summary>Usefull function to resynchronize ALMotion and DCM In fact we set motion command model with sensors information</summary>
		/// <param name="arg0_pName">Names the joints, chains, &quot;Body&quot;, &quot;JointActuators&quot;, &quot;Joints&quot; or &quot;Actuators&quot;. </param>
		/// <returns></returns>
        public void _resetMotionCommandModelToSensors(QiAnyValue arg0_pName)
        {
            SourceService["_resetMotionCommandModelToSensors"].Call(arg0_pName);
        }

        /// <summary>Usefull function to change motion mode to simulation</summary>
		/// <param name="arg0_pEnable">Enable or Disable motion simulation mode.</param>
		/// <returns></returns>
        public void _setSimulationModeEnabled(bool arg0_pEnable)
        {
            SourceService["_setSimulationModeEnabled"].Call(arg0_pEnable);
        }

        /// <summary>Get motion to dcm commands</summary>
		/// <returns></returns>
        public QiValue _getMotionToDCM()
        {
            return SourceService["_getMotionToDCM"].Call();
        }

        /// <summary>Get the blind zones convex polygon.</summary>
		/// <returns>the blind zones [[[x, y], ..., [x, y]]...]</returns>
        public QiValue _getBlindZones()
        {
            return SourceService["_getBlindZones"].Call();
        }

        /// <summary>Freeze chain movement.</summary>
		/// <param name="arg0_pChainName">Name of the chain to freeze.</param>
		/// <param name="arg1_pDuration">Freeze duration in seconds.</param>
		/// <returns>A cancellable future to unfreeze the chain.</returns>
        public void _freeze(string arg0_pChainName, float arg1_pDuration)
        {
            SourceService["_freeze"].Call(arg0_pChainName, arg1_pDuration);
        }

    }
}