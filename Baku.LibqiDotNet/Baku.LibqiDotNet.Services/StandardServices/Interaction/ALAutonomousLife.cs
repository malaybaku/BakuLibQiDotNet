using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manages the focused Activity and Autonomous Life state</summary>
    public class ALAutonomousLife
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALAutonomousLife(QiSession session)
        {
            SourceService = session.GetService("ALAutonomousLife");
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

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPreferenceChanged(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onPreferenceChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void OnReady(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["onReady"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onRobotHealthChanged(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onRobotHealthChanged"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onPushRecovery(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onPushRecovery"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onFallRecovery(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onFallRecovery"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onRobotMoved(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onRobotMoved"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0_enabled">Enabled/Disable the setState() method.</param>
		/// <returns></returns>
        public void _setStateChangeEnabled(bool arg0_enabled)
        {
            SourceService["_setStateChangeEnabled"].Call(arg0_enabled);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _loadConfigFile(string arg0)
        {
            SourceService["_loadConfigFile"].Call(arg0);
        }

        /// <summary>Programatically control the state of Autonomous Life</summary>
		/// <param name="arg0_state">The possible states of AutonomousLife are: interactive, solitary, safeguard, disabled</param>
		/// <returns></returns>
        public void SetState(string arg0_state)
        {
            SourceService["setState"].Call(arg0_state);
        }

        /// <summary>Returns the current state of AutonomousLife</summary>
		/// <returns>Can be: solitary, interactive, safeguard, disabled</returns>
        public string GetState()
        {
            return (string)SourceService["getState"].Call();
        }

        /// <summary>Returns the currently focused activity</summary>
		/// <returns>The name of the focused activity</returns>
        public string FocusedActivity()
        {
            return (string)SourceService["focusedActivity"].Call();
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <returns></returns>
        public void SwitchFocus(string arg0_activity_name)
        {
            SourceService["switchFocus"].Call(arg0_activity_name);
        }

        /// <summary>Set an activity as running with user focus</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to run</param>
		/// <param name="arg1_flags">Int flags for focus changing. STOP_CURRENT(0) or STOP_AND_STACK_CURRENT(1)</param>
		/// <returns></returns>
        public void SwitchFocus(string arg0_activity_name, int arg1_flags)
        {
            SourceService["switchFocus"].Call(arg0_activity_name, arg1_flags);
        }

        /// <summary>Stops the focused activity. If another activity is stacked it will be started.</summary>
		/// <returns></returns>
        public void StopFocus()
        {
            SourceService["stopFocus"].Call();
        }

        /// <summary>Stops the focused activity and clears stack of activities</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary>Get a value of an ALMemory key that is used in a condition, which is the value at the previous autonomous activity focus.</summary>
		/// <param name="arg0_name">Name of the ALMemory key to get.  Will throw if key is not used in any activity conditions.</param>
		/// <returns>An array of the ALValue of the memory key and timestamp of when it was set: [seconds, microseconds, value]</returns>
        public QiValue GetFocusContext(string arg0_name)
        {
            return SourceService["getFocusContext"].Call(arg0_name);
        }

        /// <summary>Get a list of permissions that would be violated by a given activity in the current context.</summary>
		/// <param name="arg0_name">The name of the activity to check.</param>
		/// <returns>An array of strings of the violated permissions. EG: [&quot;nature&quot;, &quot;canRunOnPod&quot;, &quot;canRunInSleep&quot;]</returns>
        public string[] GetActivityContextPermissionViolations(string arg0_name)
        {
            return (string[])SourceService["getActivityContextPermissionViolations"].Call(arg0_name);
        }

        /// <summary>Returns the nature of an activity</summary>
		/// <param name="arg0_activity_name">The package_name/activity_name to check</param>
		/// <returns>Possible values are: solitary, interactive</returns>
        public string GetActivityNature(string arg0_activity_name)
        {
            return (string)SourceService["getActivityNature"].Call(arg0_activity_name);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetActivityStatistics()
        {
            return SourceService["getActivityStatistics"].Call();
        }

        /// <summary>Get launch count, last completion time, etc for activities with autonomous launch trigger conditions.</summary>
		/// <returns>A map of activity names, with a cooresponding map of  &quot;prevStartTime&quot;, &quot;prevCompletionTime&quot;, &quot;startCount&quot;, &quot;totalDuration&quot;. Times are 0 for unlaunched Activities</returns>
        public QiValue GetAutonomousActivityStatistics()
        {
            return SourceService["getAutonomousActivityStatistics"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetFocusHistory()
        {
            return SourceService["getFocusHistory"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetFocusHistory(int arg0)
        {
            return SourceService["getFocusHistory"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetStateHistory()
        {
            return SourceService["getStateHistory"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetStateHistory(int arg0)
        {
            return SourceService["getStateHistory"].Call(arg0);
        }

        /// <summary>Get the time in seconds as life sees it.  Based on gettimeofday()</summary>
		/// <returns>The int time in seconds as Autonomous Life sees it</returns>
        public int GetLifeTime()
        {
            return (int)SourceService["getLifeTime"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void SetAutonomousAbilityEnabled(string arg0, bool arg1)
        {
            SourceService["setAutonomousAbilityEnabled"].Call(arg0, arg1);
        }

        /// <summary>Know is an Autonomous Ability is enabled or not</summary>
		/// <param name="arg0_autonomousAbility">The Autonomous Ability.</param>
		/// <returns>True if the Autonomous Ability is enabled, False otherwise.</returns>
        public bool GetAutonomousAbilityEnabled(string arg0_autonomousAbility)
        {
            return (bool)SourceService["getAutonomousAbilityEnabled"].Call(arg0_autonomousAbility);
        }

        /// <summary>Get the Autonomous Abilities status (get the autonomous abilities name and booleans to know if they are enabled or running</summary>
		/// <returns>The Autonomous Abilities status. A vector containing a status for each autonomous ability. Each status is composed of the autonomous ability name, a boolean to know if it's enabled and another boolean to know if it's running.</returns>
        public QiValue GetAutonomousAbilitiesStatus()
        {
            return SourceService["getAutonomousAbilitiesStatus"].Call();
        }

        /// <summary>Start monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public void StartMonitoringLaunchpadConditions()
        {
            SourceService["startMonitoringLaunchpadConditions"].Call();
        }

        /// <summary>Stop monitoring ALMemory and reporting conditional triggers with AutonomousLaunchpad.</summary>
		/// <returns></returns>
        public void StopMonitoringLaunchpadConditions()
        {
            SourceService["stopMonitoringLaunchpadConditions"].Call();
        }

        /// <summary>Gets running status of AutonomousLaunchpad</summary>
		/// <returns>True if AutonomousLaunchpad is monitoring ALMemory and reporting conditional triggers.</returns>
        public bool IsMonitoringLaunchpadConditions()
        {
            return (bool)SourceService["isMonitoringLaunchpadConditions"].Call();
        }

        /// <summary>Temporarily enables/disables AutonomousLaunchpad Plugins</summary>
		/// <param name="arg0_plugin_name">The name of the plugin to enable/disable</param>
		/// <param name="arg1_enabled">Whether or not to enable this plugin</param>
		/// <returns></returns>
        public void SetLaunchpadPluginEnabled(string arg0_plugin_name, bool arg1_enabled)
        {
            SourceService["setLaunchpadPluginEnabled"].Call(arg0_plugin_name, arg1_enabled);
        }

        /// <summary>Get a list of enabled AutonomousLaunchpad Plugins.  Enabled plugins will run when AutonomousLaunchpad is started</summary>
		/// <returns>A list of strings of enabled plugins.</returns>
        public string[] GetEnabledLaunchpadPlugins()
        {
            return (string[])SourceService["getEnabledLaunchpadPlugins"].Call();
        }

        /// <summary>Get a list of AutonomousLaunchpad Plugins that belong to specified group</summary>
		/// <param name="arg0_group">The group to search for the plugins</param>
		/// <returns>A list of strings of the plugins belonging to the group.</returns>
        public string[] GetLaunchpadPluginsForGroup(string arg0_group)
        {
            return (string[])SourceService["getLaunchpadPluginsForGroup"].Call(arg0_group);
        }

        /// <summary>Set the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <param name="arg0_offset">The new vertical offset (in meters)</param>
		/// <returns></returns>
        public void SetRobotOffsetFromFloor(float arg0_offset)
        {
            SourceService["setRobotOffsetFromFloor"].Call(arg0_offset);
        }

        /// <summary>Get the vertical offset (in meters) of the base of the robot with respect to the floor</summary>
		/// <returns>Current vertical offset (in meters)</returns>
        public float GetRobotOffsetFromFloor()
        {
            return (float)SourceService["getRobotOffsetFromFloor"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidAutonomousInteractiveStateChange(bool arg0_is_forbidden)
        {
            SourceService["_forbidAutonomousInteractiveStateChange"].Call(arg0_is_forbidden);
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidAutonomousActivityFocusSwitch(bool arg0_is_forbidden)
        {
            SourceService["_forbidAutonomousActivityFocusSwitch"].Call(arg0_is_forbidden);
        }

        /// <summary>Set if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <param name="arg1_enabled">True if life handles the safeguard.</param>
		/// <returns></returns>
        public void SetSafeguardEnabled(string arg0_name, bool arg1_enabled)
        {
            SourceService["setSafeguardEnabled"].Call(arg0_name, arg1_enabled);
        }

        /// <summary>Get if a given safeguard will be handled by Autonomous Life or not.</summary>
		/// <param name="arg0_name">Name of the safeguard to consider: RobotPushed, RobotFell,CriticalDiagnosis, CriticalTemperature</param>
		/// <returns>True if life handles the safeguard.</returns>
        public bool IsSafeguardEnabled(string arg0_name)
        {
            return (bool)SourceService["isSafeguardEnabled"].Call(arg0_name);
        }

        /// <summary>Get if the movedsafeguard will be instantaneous, or end when move is stopped</summary>
		/// <returns>True if safeguard is instantaneous, false if safeguard exited after move stopped.</returns>
        public bool _isMovedSafeguardInstantaneous()
        {
            return (bool)SourceService["_isMovedSafeguardInstantaneous"].Call();
        }

        /// <summary>Set how long to stay in safeguard state if robot pushed.</summary>
		/// <param name="arg0_duration_ms">Time in milliseconds to stay in safeguard state.</param>
		/// <returns></returns>
        public void _setPushRecoverySafeguardDuration(int arg0_duration_ms)
        {
            SourceService["_setPushRecoverySafeguardDuration"].Call(arg0_duration_ms);
        }

        /// <summary>Get how long to stay in safeguard state if robot pushed.</summary>
		/// <returns>Time in milliseconds to stay in safeguard state.</returns>
        public int _getPushRecoverySafeguardDuration()
        {
            return (int)SourceService["_getPushRecoverySafeguardDuration"].Call();
        }

        /// <summary>Put the robot to sleep.</summary>
		/// <returns></returns>
        public void _sleep()
        {
            SourceService["_sleep"].Call();
        }

        /// <summary>Wake the robot up.</summary>
		/// <returns></returns>
        public void _wakeUp()
        {
            SourceService["_wakeUp"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0_is_forbidden"></param>
		/// <returns></returns>
        public void _forbidStopCommands(bool arg0_is_forbidden)
        {
            SourceService["_forbidStopCommands"].Call(arg0_is_forbidden);
        }

    }
}