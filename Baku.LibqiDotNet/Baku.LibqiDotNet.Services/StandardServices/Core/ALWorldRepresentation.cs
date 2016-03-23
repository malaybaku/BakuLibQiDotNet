using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALWorldRepresentation
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALWorldRepresentation(QiSession session)
        {
            SourceService = session.GetService("ALWorldRepresentation");
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

        /// <summary>Add an attribute to a category.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int AddAttributeToCategory(string arg0, string arg1, QiAnyValue arg2)
        {
            return (int)SourceService["addAttributeToCategory"].Call(arg0, arg1, arg2);
        }

        /// <summary>Clear an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int ClearObject(string arg0)
        {
            return (int)SourceService["clearObject"].Call(arg0);
        }

        /// <summary>Clear recording of old positions.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int ClearOldPositions(string arg0, int arg1)
        {
            return (int)SourceService["clearOldPositions"].Call(arg0, arg1);
        }

        /// <summary>Create a new object category</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int CreateObjectCategory(string arg0, bool arg1)
        {
            return (int)SourceService["createObjectCategory"].Call(arg0, arg1);
        }

        /// <summary>Remove an object category</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int RemoveObjectCategory(string arg0)
        {
            return (int)SourceService["removeObjectCategory"].Call(arg0);
        }

        /// <summary>Tells if an object category exists</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ObjectCategoryExists(string arg0)
        {
            return (bool)SourceService["objectCategoryExists"].Call(arg0);
        }

        /// <summary>Delete an object attribute</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int DeleteObjectAttribute(string arg0, string arg1, string arg2)
        {
            return (int)SourceService["deleteObjectAttribute"].Call(arg0, arg1, arg2);
        }

        /// <summary>Check that an object is present.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool FindObject(string arg0)
        {
            return (bool)SourceService["findObject"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int Load()
        {
            return (int)SourceService["load"].Call();
        }

        /// <summary>Get all attributes from a category if it exists.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetAttributesFromCategory(string arg0)
        {
            return SourceService["getAttributesFromCategory"].Call(arg0);
        }

        /// <summary>Get the direct children of an object.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetChildrenNames(string arg0)
        {
            return (string[])SourceService["getChildrenNames"].Call(arg0);
        }

        /// <summary>Get the name of the objects.</summary>
		/// <returns></returns>
        public string[] GetObjectNames()
        {
            return (string[])SourceService["getObjectNames"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetObjectAttributes(string arg0)
        {
            return SourceService["getObjectAttributes"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public QiValue GetObjectAttributeValues(string arg0, string arg1, int arg2)
        {
            return SourceService["getObjectAttributeValues"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetObjectLatestAttributes(string arg0, int arg1)
        {
            return SourceService["getObjectLatestAttributes"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetObjectParentName(string arg0)
        {
            return (string)SourceService["getObjectParentName"].Call(arg0);
        }

        /// <summary>Get the name of the objects stored in the database.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetObjectsInCategory(string arg0)
        {
            return (string[])SourceService["getObjectsInCategory"].Call(arg0);
        }

        /// <summary>Get the name of the database where the object is stored.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetObjectCategory(string arg0)
        {
            return (string)SourceService["getObjectCategory"].Call(arg0);
        }

        /// <summary>Get the position of an object with quaternion / translation.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetPosition(string arg0, string arg1)
        {
            return SourceService["getPosition"].Call(arg0, arg1);
        }

        /// <summary>Get the position from one object to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetPosition6D(string arg0, string arg1)
        {
            return SourceService["getPosition6D"].Call(arg0, arg1);
        }

        /// <summary>Get the interpolated position of an object</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public QiValue GetPosition6DAtTime(string arg0, string arg1, int arg2, int arg3)
        {
            return SourceService["getPosition6DAtTime"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string GetRootName()
        {
            return (string)SourceService["getRootName"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int Save()
        {
            return (int)SourceService["save"].Call();
        }

        /// <summary>Select information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public QiValue Select(string arg0, string arg1, string arg2, string arg3)
        {
            return SourceService["select"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary>Select ordered information from a database.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public QiValue SelectWithOrder(string arg0, string arg1, string arg2, string arg3, string arg4)
        {
            return SourceService["selectWithOrder"].Call(arg0, arg1, arg2, arg3, arg4);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <returns></returns>
        public int StoreObject(string arg0, string arg1, IEnumerable<float> arg2, string arg3, QiAnyValue arg4)
        {
            return (int)SourceService["storeObject"].Call(arg0, arg1, QiList.Create(arg2), arg3, arg4);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public int StoreObjectWithReference(string arg0, string arg1, string arg2, IEnumerable<float> arg3, string arg4, QiAnyValue arg5)
        {
            return (int)SourceService["storeObjectWithReference"].Call(arg0, arg1, arg2, QiList.Create(arg3), arg4, arg5);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int StoreObjectAttribute(string arg0, string arg1, QiAnyValue arg2)
        {
            return (int)SourceService["storeObjectAttribute"].Call(arg0, arg1, arg2);
        }

        /// <summary>Update the position of an object.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public int UpdatePosition(string arg0, IEnumerable<float> arg1, bool arg2)
        {
            return (int)SourceService["updatePosition"].Call(arg0, QiList.Create(arg1), arg2);
        }

        /// <summary>Update the position of an object relative to another.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public int UpdatePositionWithReference(string arg0, string arg1, IEnumerable<float> arg2, bool arg3)
        {
            return (int)SourceService["updatePositionWithReference"].Call(arg0, arg1, QiList.Create(arg2), arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public int UpdateAttribute(string arg0, string arg1, string arg2, QiAnyValue arg3)
        {
            return (int)SourceService["updateAttribute"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _startMemoryCheck(int arg0)
        {
            SourceService["_startMemoryCheck"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _stopMemoryCheck()
        {
            SourceService["_stopMemoryCheck"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _beginTransaction(string arg0)
        {
            return (int)SourceService["_beginTransaction"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _endTransaction(string arg0)
        {
            return (int)SourceService["_endTransaction"].Call(arg0);
        }

    }
}