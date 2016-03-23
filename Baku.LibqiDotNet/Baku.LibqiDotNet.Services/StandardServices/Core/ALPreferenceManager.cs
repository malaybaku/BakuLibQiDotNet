using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALPreferenceManager
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALPreferenceManager(QiSession session)
        {
            SourceService = session.GetService("ALPreferenceManager");
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

        /// <summary>Get specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns>corresponding preferences value</returns>
        public QiValue GetValue(string arg0_domain, string arg1_setting)
        {
            return SourceService["getValue"].Call(arg0_domain, arg1_setting);
        }

        /// <summary>Set specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public void SetValue(string arg0_domain, string arg1_setting, QiAnyValue arg2_value)
        {
            SourceService["setValue"].Call(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Get preferences names and values for a given domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns>a list of preferences names and values associated to the domain</returns>
        public QiValue GetValueList(string arg0_domain)
        {
            return SourceService["getValueList"].Call(arg0_domain);
        }

        /// <summary>Get available preferences domain</summary>
		/// <returns>a list containing all the available domain names</returns>
        public string[] GetDomainList()
        {
            return (string[])SourceService["getDomainList"].Call();
        }

        /// <summary>Remove specified preference</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <returns></returns>
        public void RemoveValue(string arg0_domain, string arg1_setting)
        {
            SourceService["removeValue"].Call(arg0_domain, arg1_setting);
        }

        /// <summary>Add many values at once.</summary>
		/// <param name="arg0_values">A map (domain as index) of map (setting name as index) of values.</param>
		/// <returns></returns>
        public void SetValues(QiAnyValue arg0_values)
        {
            SourceService["setValues"].Call(arg0_values);
        }

        /// <summary>Remove an entire preference domain</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <returns></returns>
        public void RemoveDomainValues(string arg0_domain)
        {
            SourceService["removeDomainValues"].Call(arg0_domain);
        }

        /// <summary>Import a preferences XML file</summary>
		/// <param name="arg0_domain">Preference domain: all preferences values found in XML file will be imported in that domain.</param>
		/// <param name="arg1_applicationName">Application name: will be used to search for preference file on disk (in location of type &lt;configurationdirectory&gt;/applicationName/filename).</param>
		/// <param name="arg2_filename">Preference XML filename</param>
		/// <param name="arg3_override">Set this to true if you want to override preferences that already exist with preferences in imported XML file</param>
		/// <returns></returns>
        public void ImportPrefFile(string arg0_domain, string arg1_applicationName, string arg2_filename, bool arg3_override)
        {
            SourceService["importPrefFile"].Call(arg0_domain, arg1_applicationName, arg2_filename, arg3_override);
        }

        /// <summary>Synchronizes local preferences with preferences stored on a server.</summary>
		/// <returns></returns>
        public void Update()
        {
            SourceService["update"].Call();
        }

        /// <summary>Update local preference from version store on Cloud (usefull when preference was updated on Cloud)</summary>
		/// <param name="arg0_domain">Preference domain</param>
		/// <param name="arg1_setting">Preference setting</param>
		/// <param name="arg2_value">Preference value</param>
		/// <returns></returns>
        public void _setFromCloud(string arg0_domain, string arg1_setting, QiAnyValue arg2_value)
        {
            SourceService["_setFromCloud"].Call(arg0_domain, arg1_setting, arg2_value);
        }

        /// <summary>Restart preferences module</summary>
		/// <param name="arg0_url">Preference server url</param>
		/// <param name="arg1_path">Path to sqlite database</param>
		/// <returns></returns>
        public void _restart(string arg0_url, string arg1_path)
        {
            SourceService["_restart"].Call(arg0_url, arg1_path);
        }

        /// <summary>Internal callback.</summary>
		/// <param name="arg0_string">variable</param>
		/// <param name="arg1_string">value</param>
		/// <param name="arg2_string">message</param>
		/// <returns></returns>
        public void _onConnectivityChanged(string arg0_string, QiAnyValue arg1_string, string arg2_string)
        {
            SourceService["_onConnectivityChanged"].Call(arg0_string, arg1_string, arg2_string);
        }

    }
}