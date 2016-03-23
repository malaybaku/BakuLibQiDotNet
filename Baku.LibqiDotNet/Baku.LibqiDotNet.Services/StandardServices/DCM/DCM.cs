using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manage link with devices (sensors and actuators). See specific documentation.</summary>
    public class DCM
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public DCM(QiSession session)
        {
            SourceService = session.GetService("DCM");
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

        /// <summary>Call this function to send a timed-command list to an actuator</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public void Set(QiAnyValue arg0_commands)
        {
            SourceService["set"].Call(arg0_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators)</summary>
		/// <param name="arg0_commands">AL::ALValue with all data</param>
		/// <returns></returns>
        public void SetAlias(QiAnyValue arg0_commands)
        {
            SourceService["setAlias"].Call(arg0_commands);
        }

        /// <summary>Call this function to send timed-command list to an alias (list of actuators) with &quot;ClearAll&quot; merge startegy</summary>
		/// <param name="arg0_name">alias name</param>
		/// <param name="arg1_time">time for the timed command</param>
		/// <param name="arg2_commands">std::vector&lt;float&gt; with all commands</param>
		/// <returns></returns>
        public void SetAlias(string arg0_name, int arg1_time, IEnumerable<float> arg2_commands)
        {
            SourceService["setAlias"].Call(arg0_name, arg1_time, QiList.Create(arg2_commands));
        }

        /// <summary>Return the DCM time</summary>
		/// <param name="arg0_offset">optional time in ms (signed) to add/remove</param>
		/// <returns>An integer (could be signed) with the DCM time</returns>
        public int GetTime(int arg0_offset)
        {
            return (int)SourceService["getTime"].Call(arg0_offset);
        }

        /// <summary>Create or change an alias (list of actuators)</summary>
		/// <param name="arg0_alias">Alias name and description</param>
		/// <returns>Same as pParams, but with the name removed if the actuator is not found</returns>
        public QiValue CreateAlias(QiAnyValue arg0_alias)
        {
            return SourceService["createAlias"].Call(arg0_alias);
        }

        /// <summary>Return the STM base name</summary>
		/// <returns>the STM base name for all device/sensors (1st string in the array) and all devices (2nd string in the array)</returns>
        public QiValue GetPrefix()
        {
            return SourceService["getPrefix"].Call();
        }

        /// <summary>Special DCM commands</summary>
		/// <param name="arg0_result">one string and could be Reset, Version, Chain, Diagnostic, Config</param>
		/// <returns></returns>
        public void Special(string arg0_result)
        {
            SourceService["special"].Call(arg0_result);
        }

        /// <summary>Calibration of a joint</summary>
		/// <param name="arg0_calibrationInput">A complex ALValue. See red documentation</param>
		/// <returns></returns>
        public void Calibration(QiAnyValue arg0_calibrationInput)
        {
            SourceService["calibration"].Call(arg0_calibrationInput);
        }

        /// <summary>Save updated value from DCM in XML pref file</summary>
		/// <param name="arg0_action">string : 'Save' 'Load' 'Add'</param>
		/// <param name="arg1_target">string : 'Chest' 'Head' 'Main' 'All' </param>
		/// <param name="arg2_keyName">The name of the key if action = 'Add'.</param>
		/// <param name="arg3_keyValue">The ALVAlue of the key to add</param>
		/// <returns>Nothing</returns>
        public int Preferences(string arg0_action, string arg1_target, string arg2_keyName, QiAnyValue arg3_keyValue)
        {
            return (int)SourceService["preferences"].Call(arg0_action, arg1_target, arg2_keyName, arg3_keyValue);
        }

        /// <summary>Add or update data for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <param name="arg1_values">list of values (float, could be cast in int)</param>
		/// <returns>bool : false on error, true if ok</returns>
        public bool _injectionAdd(IEnumerable<string> arg0_key, IEnumerable<float> arg1_values)
        {
            return (bool)SourceService["_injectionAdd"].Call(QiList.Create(arg0_key), QiList.Create(arg1_values));
        }

        /// <summary>Stop datas injection</summary>
		/// <returns>Nothing</returns>
        public void _injectionStop()
        {
            SourceService["_injectionStop"].Call();
        }

        /// <summary>Remove datas for injection</summary>
		/// <param name="arg0_key">List of key name</param>
		/// <returns>Nothing</returns>
        public void _injectionRemove(IEnumerable<string> arg0_key)
        {
            SourceService["_injectionRemove"].Call(QiList.Create(arg0_key));
        }

    }
}