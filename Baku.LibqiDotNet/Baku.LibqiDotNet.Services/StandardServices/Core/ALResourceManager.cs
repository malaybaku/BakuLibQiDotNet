using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Manage robot resources: Synchronize movement, led, sound. Run specific actions when another behavior wants your resources</summary>
    public class ALResourceManager
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALResourceManager(QiSession session)
        {
            SourceService = session.GetService("ALResourceManager");
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

        /// <summary>Wait resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void WaitForResource(string arg0_resourceName, string arg1_ownerName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["waitForResource"].Call(arg0_resourceName, arg1_ownerName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait and acquire a resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void AcquireResource(string arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["acquireResource"].Call(arg0_resourceName, arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait resource</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public string[] WaitForOptionalResourcesTree(IEnumerable<string> arg0, string arg1, string arg2, int arg3, IEnumerable<string> arg4)
        {
            return (string[])SourceService["waitForOptionalResourcesTree"].Call(QiList.Create(arg0), arg1, arg2, arg3, QiList.Create(arg4));
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void WaitForResourcesTree(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["waitForResourcesTree"].Call(QiList.Create(arg0_resourceName), arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>Wait for resource tree. Parent and children are not in conflict. Local function</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_moduleName">Module name</param>
		/// <param name="arg2_callbackName">callback name</param>
		/// <param name="arg3_timeoutSeconds">Timeout in seconds</param>
		/// <returns></returns>
        public void AcquireResourcesTree(IEnumerable<string> arg0_resourceName, string arg1_moduleName, string arg2_callbackName, int arg3_timeoutSeconds)
        {
            SourceService["acquireResourcesTree"].Call(QiList.Create(arg0_resourceName), arg1_moduleName, arg2_callbackName, arg3_timeoutSeconds);
        }

        /// <summary>True if all the specified resources are owned by the owner</summary>
		/// <param name="arg0_resourceNameList">Resource name</param>
		/// <param name="arg1_ownerName">Owner pointer with hierarchy</param>
		/// <returns>True if all the specify resources are owned by the owner</returns>
        public bool AreResourcesOwnedBy(IEnumerable<string> arg0_resourceNameList, string arg1_ownerName)
        {
            return (bool)SourceService["areResourcesOwnedBy"].Call(QiList.Create(arg0_resourceNameList), arg1_ownerName);
        }

        /// <summary>Release resource</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <param name="arg1_ownerName">Existing owner name</param>
		/// <returns></returns>
        public void ReleaseResource(string arg0_resourceName, string arg1_ownerName)
        {
            SourceService["releaseResource"].Call(arg0_resourceName, arg1_ownerName);
        }

        /// <summary>Release  resources list</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <param name="arg1_ownerName">Owner name</param>
		/// <returns></returns>
        public void ReleaseResources(IEnumerable<string> arg0_resourceNames, string arg1_ownerName)
        {
            SourceService["releaseResources"].Call(QiList.Create(arg0_resourceNames), arg1_ownerName);
        }

        /// <summary>Enable or disable a state resource</summary>
		/// <param name="arg0_resourceName">The name of the resource that you wish enable of disable. e.g. Standing</param>
		/// <param name="arg1_enabled">True to enable, false to disable</param>
		/// <returns></returns>
        public void EnableStateResource(string arg0_resourceName, bool arg1_enabled)
        {
            SourceService["enableStateResource"].Call(arg0_resourceName, arg1_enabled);
        }

        /// <summary>check if all the state resource in the list are free</summary>
		/// <param name="arg0_resourceName">Resource name</param>
		/// <returns></returns>
        public bool CheckStateResourceFree(IEnumerable<string> arg0_resourceName)
        {
            return (bool)SourceService["checkStateResourceFree"].Call(QiList.Create(arg0_resourceName));
        }

        /// <summary>True if all resources are free</summary>
		/// <param name="arg0_resourceNames">Resource names</param>
		/// <returns>True if all the specify resources are free</returns>
        public bool AreResourcesFree(IEnumerable<string> arg0_resourceNames)
        {
            return (bool)SourceService["areResourcesFree"].Call(QiList.Create(arg0_resourceNames));
        }

        /// <summary>True if the resource is free</summary>
		/// <param name="arg0_resourceNames">Resource name</param>
		/// <returns>True if the specify resources is free</returns>
        public bool IsResourceFree(string arg0_resourceNames)
        {
            return (bool)SourceService["isResourceFree"].Call(arg0_resourceNames);
        }

        /// <summary>Create a resource</summary>
		/// <param name="arg0_resourceName">Resource name to create</param>
		/// <param name="arg1_parentResourceName">Parent resource name or empty string for root resource</param>
		/// <returns></returns>
        public void CreateResource(string arg0_resourceName, string arg1_parentResourceName)
        {
            SourceService["createResource"].Call(arg0_resourceName, arg1_parentResourceName);
        }

        /// <summary>Delete a root resource</summary>
		/// <param name="arg0_resourceName">Resource name to delete</param>
		/// <param name="arg1_deleteChildResources">DEPRECATED: Delete child resources if true</param>
		/// <returns></returns>
        public void DeleteResource(string arg0_resourceName, bool arg1_deleteChildResources)
        {
            SourceService["deleteResource"].Call(arg0_resourceName, arg1_deleteChildResources);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public bool IsInGroup(string arg0_resourceGroupName, string arg1_resourceName)
        {
            return (bool)SourceService["isInGroup"].Call(arg0_resourceGroupName, arg1_resourceName);
        }

        /// <summary>True if a resource is in another parent resource</summary>
		/// <param name="arg0_resourceGroupName">Group name. Ex: Arm</param>
		/// <param name="arg1_resourceName">Resource name</param>
		/// <returns></returns>
        public void CreateResourcesList(IEnumerable<string> arg0_resourceGroupName, string arg1_resourceName)
        {
            SourceService["createResourcesList"].Call(QiList.Create(arg0_resourceGroupName), arg1_resourceName);
        }

        /// <summary>Get tree of resources</summary>
		/// <returns></returns>
        public QiValue GetResources()
        {
            return SourceService["getResources"].Call();
        }

        /// <summary>The tree of the resources owners.</summary>
		/// <returns></returns>
        public QiValue OwnersGet()
        {
            return SourceService["ownersGet"].Call();
        }

    }
}