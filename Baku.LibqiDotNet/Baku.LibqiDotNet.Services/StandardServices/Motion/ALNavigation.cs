using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALNavigation module to make the robot go safely to the asked pose2D.</summary>
    public class ALNavigation
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALNavigation(QiSession session)
        {
            SourceService = session.GetService("ALNavigation");
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

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y)
        {
            return (bool)SourceService["navigateTo"].Call(arg0_x, arg1_y);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, QiAnyValue arg2_config)
        {
            return (bool)SourceService["navigateTo"].Call(arg0_x, arg1_y, arg2_config);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            return (bool)SourceService["navigateTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot navigate to a relative metrical target pose2D expressed in FRAME_ROBOT. The robot computes a path to avoid obstacles.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">Orientation of the robot (rad).</param>
		/// <param name="arg3_config">Configuration ALValue. For example, [[&quot;SpeedFactor&quot;, 0.5]] sets speedFactor to 0.5</param>
		/// <returns></returns>
        public bool NavigateTo(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_config)
        {
            return (bool)SourceService["navigateTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_config);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given position.This is a blocking call.</summary>
		/// <param name="arg0_x">The position along x axis [m].</param>
		/// <param name="arg1_y">The position along y axis [m].</param>
		/// <param name="arg2_theta">The angle around z axis [rad].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveTo(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["moveTo"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in S.I. units. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [m.s-1].</param>
		/// <param name="arg1_y">The speed along y axis [m.s-1].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [rad.s-1].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void Move(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["move"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta);
        }

        /// <summary>Makes the robot move at the given speed in normalized speed fraction. This is a blocking call.</summary>
		/// <param name="arg0_x">The speed along x axis [0.0-1.0].</param>
		/// <param name="arg1_y">The speed along y axis [0.0-1.0].</param>
		/// <param name="arg2_theta">The anglular speed around z axis [0.0-1.0].</param>
		/// <param name="arg3_moveConfig">An ALValue with custom move configuration.</param>
		/// <returns></returns>
        public void MoveToward(float arg0_x, float arg1_y, float arg2_theta, QiAnyValue arg3_moveConfig)
        {
            SourceService["moveToward"].Call(arg0_x, arg1_y, arg2_theta, arg3_moveConfig);
        }

        /// <summary>Internal Use.</summary>
		/// <param name="arg0_config">Internal: An array of ALValues [i][0]: name, [i][1]: value</param>
		/// <returns></returns>
        public void _setNavigationConfig(QiAnyValue arg0_config)
        {
            SourceService["_setNavigationConfig"].Call(arg0_config);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetSecurityDistance(float arg0)
        {
            SourceService["setSecurityDistance"].Call(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public float GetSecurityDistance()
        {
            return (float)SourceService["getSecurityDistance"].Call();
        }

        /// <summary>Stops the navigateTo.</summary>
		/// <returns></returns>
        public void StopNavigateTo()
        {
            SourceService["stopNavigateTo"].Call();
        }

        /// <summary>Stops the navigateTo but no stop move.</summary>
		/// <returns></returns>
        public void _stopNavigateToWithoutStopMove()
        {
            SourceService["_stopNavigateToWithoutStopMove"].Call();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setTangentialSecurityDistance(float arg0)
        {
            SourceService["_setTangentialSecurityDistance"].Call(arg0);
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public float _getTangentialSecurityDistance()
        {
            return (float)SourceService["_getTangentialSecurityDistance"].Call();
        }

        /// <summary>Distance in meters fromwhich the robot should stop if there is an obstacle.</summary>
		/// <returns></returns>
        public int _getNavigateToStatus()
        {
            return (int)SourceService["_getNavigateToStatus"].Call();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are the one used by the secure navigator</summary>
		/// <returns></returns>
        public QiValue _getObstacleData()
        {
            return SourceService["_getObstacleData"].Call();
        }

        /// <summary>Get the requested occupancy grid formatted as a ROS navigation stack message.</summary>
		/// <param name="arg0_client">Internal: 'Secure' for SecureNavigator or 'Local' for LocalNavigator.</param>
		/// <returns></returns>
        public QiValue _getOccupancyGrid(string arg0_client)
        {
            return SourceService["_getOccupancyGrid"].Call(arg0_client);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <returns></returns>
        public QiValue _getSensorData()
        {
            return SourceService["_getSensorData"].Call();
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getSensorData(string arg0)
        {
            return SourceService["_getSensorData"].Call(arg0);
        }

        /// <summary>Obstacles data.ALArray formatted as follow for each ALValue : [0]:familyName[1]:name[2]:Array containing [x, y] arrays of points in robot frame.Those obstacles are taken from sensors</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getSensorData(IEnumerable<string> arg0)
        {
            return SourceService["_getSensorData"].Call(QiList.Create(arg0));
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _subscribeToAll(string arg0)
        {
            return (bool)SourceService["_subscribeToAll"].Call(arg0);
        }

        /// <summary>Start active sensors.The client needs to specify its name to register.If the client is the only one to register, the sensors are turned on, otherwise they are already started.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _subscribe(string arg0_clientName, IEnumerable<string> arg1)
        {
            return (bool)SourceService["_subscribe"].Call(arg0_clientName, QiList.Create(arg1));
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _unsubscribeFromAll(string arg0)
        {
            return (bool)SourceService["_unsubscribeFromAll"].Call(arg0);
        }

        /// <summary>Stop active sensors.The client needs to specify its name to unregister.The active sensors are actually stopped if not client is registered anymore.</summary>
		/// <param name="arg0_clientName">The client name.</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unsubscribe(string arg0_clientName, IEnumerable<string> arg1)
        {
            return (bool)SourceService["_unsubscribe"].Call(arg0_clientName, QiList.Create(arg1));
        }

        /// <summary>Add a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public bool _addSensor(string arg0_sensor)
        {
            return (bool)SourceService["_addSensor"].Call(arg0_sensor);
        }

        /// <summary>Remove a sensor family or a sensor.</summary>
		/// <param name="arg0_sensor">The sensor family name or name.</param>
		/// <returns></returns>
        public bool _removeSensor(string arg0_sensor)
        {
            return (bool)SourceService["_removeSensor"].Call(arg0_sensor);
        }

        /// <summary>Get trajectory from local navigator.ALArray containing successively x, y and theta coordinates.</summary>
		/// <returns></returns>
        public QiValue _getTrajectory()
        {
            return SourceService["_getTrajectory"].Call();
        }

        /// <summary>Set speed factor for local navigator</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setSpeedFactor(float arg0)
        {
            SourceService["_setSpeedFactor"].Call(arg0);
        }

        /// <summary>Get obstacle Map from localnavigator. ALValue formatted as follow for each sensor :[[SensorName1 [[x1 y1] [x2 y2] [x3 y3] ...]] [SensorName2 [[x1 y1] [x2 y2] [x3 y3] ...]] ... ]</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getObstacleMap(string arg0)
        {
            return SourceService["_getObstacleMap"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSensorDebug(bool arg0)
        {
            SourceService["_enableSensorDebug"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _useHeadChecking(bool arg0)
        {
            SourceService["_useHeadChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _usePathChecking(bool arg0)
        {
            SourceService["_usePathChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSpeedFactor(bool arg0)
        {
            SourceService["_enableSpeedFactor"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearObstacleMap()
        {
            SourceService["_clearObstacleMap"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _useClearNavigationMap(bool arg0)
        {
            SourceService["_useClearNavigationMap"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearNavigationMap()
        {
            SourceService["_clearNavigationMap"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getSensorSubscribers()
        {
            return SourceService["_getSensorSubscribers"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getSensorList()
        {
            return SourceService["_getSensorList"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getSensorListBySubscriber(string arg0)
        {
            return SourceService["_getSensorListBySubscriber"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getActiveSensorList()
        {
            return SourceService["_getActiveSensorList"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isSensorEnabled(string arg0)
        {
            return (bool)SourceService["_isSensorEnabled"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getSecureNavSensors()
        {
            return SourceService["_getSecureNavSensors"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableLogger(bool arg0)
        {
            SourceService["_enableLogger"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setController(int arg0)
        {
            SourceService["_setController"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeTree()
        {
            SourceService["_writeTree"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public bool MoveAlong(QiAnyValue arg0_trajectory)
        {
            return (bool)SourceService["moveAlong"].Call(arg0_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0_moveAlongScale">a scale factor</param>
		/// <param name="arg1_allowMove">true if the robot should do any move at all</param>
		/// <param name="arg2_trajectory">An ALValue describing a trajectory.</param>
		/// <returns></returns>
        public bool _moveAlong(float arg0_moveAlongScale, bool arg1_allowMove, QiAnyValue arg2_trajectory)
        {
            return (bool)SourceService["_moveAlong"].Call(arg0_moveAlongScale, arg1_allowMove, arg2_trajectory);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableSafety(bool arg0)
        {
            SourceService["_enableSafety"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isSafetyEnabled()
        {
            return (bool)SourceService["_isSafetyEnabled"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isSafetyLoopRunning()
        {
            return (bool)SourceService["_isSafetyLoopRunning"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _wakeUpCallBack()
        {
            SourceService["_wakeUpCallBack"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _restCallBack(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_restCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getFreeZoneCenter(double arg0)
        {
            return SourceService["_getFreeZoneCenter"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getFreeZoneWithConstraints(float arg0)
        {
            return SourceService["_getFreeZoneWithConstraints"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _updateFreeZone()
        {
            return (int)SourceService["_updateFreeZone"].Call();
        }

        /// <summary> Starts a loop to update the mapping of the free space around the robot. </summary>
		/// <returns></returns>
        public void StartFreeZoneUpdate()
        {
            SourceService["startFreeZoneUpdate"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startFreeZoneUpdateWithTimeout(int arg0)
        {
            SourceService["_startFreeZoneUpdateWithTimeout"].Call(arg0);
        }

        /// <summary>Stops and returns free zone.</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public QiValue StopAndComputeFreeZone(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["stopAndComputeFreeZone"].Call(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeFreeZone()
        {
            SourceService["_writeFreeZone"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _clearFreeZone()
        {
            SourceService["_clearFreeZone"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getFreeZoneMap()
        {
            return SourceService["_getFreeZoneMap"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue _computeFreeZone(float arg0, float arg1)
        {
            return SourceService["_computeFreeZone"].Call(arg0, arg1);
        }

        /// <summary>Returns [errorCode, result radius[centerWorldMotionX, centerWorldMotionY]]</summary>
		/// <param name="arg0_desiredRadius">The radius of the space we want in meters [m].</param>
		/// <param name="arg1_maximumDisplacement">The max distance we accept to move toreach the found place [m].</param>
		/// <returns>Returns [errorCode, result radius (m), [worldMotionToRobotCenterX (m), worldMotionToRobotCenterY (m)]]</returns>
        public QiValue FindFreeZone(float arg0_desiredRadius, float arg1_maximumDisplacement)
        {
            return SourceService["findFreeZone"].Call(arg0_desiredRadius, arg1_maximumDisplacement);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _moveToFreeZoneCenter()
        {
            SourceService["_moveToFreeZoneCenter"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _stopFreeZoneTasks()
        {
            SourceService["_stopFreeZoneTasks"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _writeDilatedMaps()
        {
            SourceService["_writeDilatedMaps"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startDiagnosis(IEnumerable<string> arg0)
        {
            SourceService["_startDiagnosis"].Call(QiList.Create(arg0));
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _stopDiagnosis()
        {
            return SourceService["_stopDiagnosis"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _passiveDiagnosisCallBack(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_passiveDiagnosisCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _activeDiagnosisCallBack(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_activeDiagnosisCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setTimeChecking(bool arg0)
        {
            SourceService["_setTimeChecking"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onTouchChanged(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onTouchChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setSafetyMemoryTime(uint arg0)
        {
            SourceService["_setSafetyMemoryTime"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public uint _getSafetyMemoryTime()
        {
            return (uint)SourceService["_getSafetyMemoryTime"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getCollisionObstacleDistance()
        {
            return (float)SourceService["_getCollisionObstacleDistance"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setCollisionObstacleDistance(float arg0)
        {
            SourceService["_setCollisionObstacleDistance"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public float _getCollisionObstacleRadius()
        {
            return (float)SourceService["_getCollisionObstacleRadius"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setCollisionObstacleRadius(float arg0)
        {
            SourceService["_setCollisionObstacleRadius"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setBlindZoneSensorMode(int arg0)
        {
            SourceService["_setBlindZoneSensorMode"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _getBlindZoneSensorMode()
        {
            return (int)SourceService["_getBlindZoneSensorMode"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public string _get3DMap()
        {
            return (string)SourceService["_get3DMap"].Call();
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _eventMoveFailedCallback()
        {
            SourceService["_eventMoveFailedCallback"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFreeZoneTimeout(int arg0)
        {
            SourceService["_setFreeZoneTimeout"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFreeZoneThreshold(float arg0)
        {
            SourceService["_setFreeZoneThreshold"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setObstaclesNumber(uint arg0)
        {
            SourceService["_setObstaclesNumber"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int _getObstaclesNumber()
        {
            return (int)SourceService["_getObstaclesNumber"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _enableTouchType(int arg0)
        {
            SourceService["_enableTouchType"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _disableTouchType(int arg0)
        {
            SourceService["_disableTouchType"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int[] _getEnabledTouchTypes()
        {
            return (int[])SourceService["_getEnabledTouchTypes"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDataTooOldThresholdMs(uint arg0)
        {
            SourceService["_setDataTooOldThresholdMs"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public uint _getDataTooOldThresholdMs()
        {
            return (uint)SourceService["_getDataTooOldThresholdMs"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setDiagnosisLogEnabled(bool arg0)
        {
            SourceService["_setDiagnosisLogEnabled"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public bool _isDiagnosisLogEnabled()
        {
            return (bool)SourceService["_isDiagnosisLogEnabled"].Call();
        }

    }
}