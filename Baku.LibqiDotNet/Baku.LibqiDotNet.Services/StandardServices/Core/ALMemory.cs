using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALMemory provides a centralized memory that can be used to store and retrieve named values. It also acts as a hub for the distribution of event notifications.</summary>
    public class ALMemory
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALMemory(QiSession session)
        {
            SourceService = session.GetService("ALMemory");
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

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <returns></returns>
        public void DeclareEvent(string arg0_eventName)
        {
            SourceService["declareEvent"].Call(arg0_eventName);
        }

        /// <summary>Declares an event to allow future subscriptions to the event</summary>
		/// <param name="arg0_eventName">The name of the event</param>
		/// <param name="arg1_extractorName">The name of the extractor capable of creating the event</param>
		/// <returns></returns>
        public void DeclareEvent(string arg0_eventName, string arg1_extractorName)
        {
            SourceService["declareEvent"].Call(arg0_eventName, arg1_extractorName);
        }

        /// <summary>Gets the value of a key-value pair stored in memory</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <returns>The data as an ALValue. This can often be cast transparently into the original type.</returns>
        public QiValue GetData(string arg0_key)
        {
            return SourceService["getData"].Call(arg0_key);
        }

        /// <summary>DEPRECATED - Gets the value of a key-value pair stored in memory. Please use the version of this method with no second parameter.</summary>
		/// <param name="arg0_key">Name of the value.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - This parameter has no effect, but is left for compatibility reason.</param>
		/// <returns>The data as an ALValue</returns>
        public QiValue GetData(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getData"].Call(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>Get an object wrapping a signal bound to the given ALMemory event. Creates the event if it does not exist.</summary>
		/// <param name="arg0_eventName">Name of the ALMemory event</param>
		/// <returns>An AnyObject with a signal named &quot;signal&quot;</returns>
        public QiObject Subscriber(string arg0_eventName)
        {
            return SourceService["subscriber"].CallObject(arg0_eventName);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public QiValue GetTimestamp(string arg0_key)
        {
            return SourceService["getTimestamp"].Call(arg0_key);
        }

        /// <summary>Get data value and timestamp</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public QiValue GetEventHistory(string arg0_key)
        {
            return SourceService["getEventHistory"].Call(arg0_key);
        }

        /// <summary>Gets a list of all key names that contain a given string</summary>
		/// <param name="arg0_filter">A string used as the search term</param>
		/// <returns>A list of all the data key names that contain the given string.</returns>
        public string[] GetDataList(string arg0_filter)
        {
            return (string[])SourceService["getDataList"].Call(arg0_filter);
        }

        /// <summary>Gets the key names for all the key-value pairs in memory</summary>
		/// <returns>A list containing the keys in memory</returns>
        public string[] GetDataListName()
        {
            return (string[])SourceService["getDataListName"].Call();
        }

        /// <summary>DEPRECATED - Blocks the caller until the value of a key changes</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <param name="arg1_deprecatedParameter">DEPRECATED - this parameter has no effect</param>
		/// <returns>an array containing all the retrieved data</returns>
        public QiValue GetDataOnChange(string arg0_key, int arg1_deprecatedParameter)
        {
            return SourceService["getDataOnChange"].Call(arg0_key, arg1_deprecatedParameter);
        }

        /// <summary>Gets a pointer to 32 a bit data item. Beware, the pointer will only be valid during the lifetime of the ALMemory object. Use with care, at initialization, not every loop.</summary>
		/// <param name="arg0_key">Name of the data.</param>
		/// <returns>A pointer converted to int</returns>
        public QiValue GetDataPtr(string arg0_key)
        {
            return SourceService["getDataPtr"].Call(arg0_key);
        }

        /// <summary>Gets a list containing the names of all the declared events</summary>
		/// <returns>A list containing the names of all events</returns>
        public string[] GetEventList()
        {
            return (string[])SourceService["getEventList"].Call();
        }

        /// <summary>Gets the list of all events generated by a given extractor</summary>
		/// <param name="arg0_extractorName">The name of the extractor</param>
		/// <returns>A list containing the names of the events associated with the given extractor</returns>
        public string[] GetExtractorEvent(string arg0_extractorName)
        {
            return (string[])SourceService["getExtractorEvent"].Call(arg0_extractorName);
        }

        /// <summary>Gets the values associated with the given list of keys. This is more efficient than calling getData many times, especially over the network.</summary>
		/// <param name="arg0_keyList">An array containing the key names.</param>
		/// <returns>An array containing all the values corresponding to the given keys.</returns>
        public QiValue GetListData(QiAnyValue arg0_keyList)
        {
            return SourceService["getListData"].Call(arg0_keyList);
        }

        /// <summary>Gets a list containing the names of all the declared micro events</summary>
		/// <returns>A list containing the names of all the microEvents</returns>
        public string[] GetMicroEventList()
        {
            return (string[])SourceService["getMicroEventList"].Call();
        }

        /// <summary>Gets a list containing the names of subscribers to an event.</summary>
		/// <param name="arg0_name">Name of the event or micro-event</param>
		/// <returns>List of subscriber names</returns>
        public string[] GetSubscribers(string arg0_name)
        {
            return (string[])SourceService["getSubscribers"].Call(arg0_name);
        }

        /// <summary>Gets the storage class of the stored data. This is not the underlying POD type.</summary>
		/// <param name="arg0_key">Name of the variable</param>
		/// <returns>String type: Data, Event, MicroEvent</returns>
        public string GetType(string arg0_key)
        {
            return (string)SourceService["getType"].Call(arg0_key);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an int</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The int to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, int arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a float</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The float to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, float arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is a string</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_value">The string to be inserted</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, string arg1_value)
        {
            SourceService["insertData"].Call(arg0_key, arg1_value);
        }

        /// <summary>Inserts a key-value pair into memory, where value is an ALValue</summary>
		/// <param name="arg0_key">Name of the value to be inserted.</param>
		/// <param name="arg1_data">The ALValue to be inserted. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void InsertData(string arg0_key, QiAnyValue arg1_data)
        {
            SourceService["insertData"].Call(arg0_key, arg1_data);
        }

        /// <summary>Inserts a list of key-value pairs into memory.</summary>
		/// <param name="arg0_list">An ALValue list of the form [[Key, Value],...]. Each item will be inserted.</param>
		/// <returns></returns>
        public void InsertListData(QiAnyValue arg0_list)
        {
            SourceService["insertListData"].Call(arg0_list);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void RaiseEvent(string arg0_name, QiAnyValue arg1_value)
        {
            SourceService["raiseEvent"].Call(arg0_name, arg1_value);
        }

        /// <summary>Publishes the given data to all subscribers.</summary>
		/// <param name="arg0_name">Name of the event to raise.</param>
		/// <param name="arg1_value">The data associated with the event. This could contain a basic type, or a more complex array. See the ALValue documentation for more information.</param>
		/// <returns></returns>
        public void RaiseMicroEvent(string arg0_name, QiAnyValue arg1_value)
        {
            SourceService["raiseMicroEvent"].Call(arg0_name, arg1_value);
        }

        /// <summary>Removes a key-value pair from memory</summary>
		/// <param name="arg0_key">Name of the data to be removed.</param>
		/// <returns></returns>
        public void RemoveData(string arg0_key)
        {
            SourceService["removeData"].Call(arg0_key);
        }

        /// <summary>Removes a event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public void RemoveEvent(string arg0_name)
        {
            SourceService["removeEvent"].Call(arg0_name);
        }

        /// <summary>Removes a micro event from memory and unsubscribes any exiting subscribers.</summary>
		/// <param name="arg0_name">Name of the event to remove.</param>
		/// <returns></returns>
        public void RemoveMicroEvent(string arg0_name)
        {
            SourceService["removeMicroEvent"].Call(arg0_name);
        }

        /// <summary>Subscribes to an event and automaticaly launches the module that declared itself as the generator of the event if required.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMethod)
        {
            SourceService["subscribeToEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMethod);
        }

        /// <summary>DEPRECATED Subscribes to event and automaticaly launches the module capable of generating the event if it is not already running. Please use the version without the callbackMessage parameter.</summary>
		/// <param name="arg0_name">The name of the event to subscribe to</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">DEPRECATED Message included in the notification.</param>
		/// <param name="arg3_callbacMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbacMethod)
        {
            SourceService["subscribeToEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbacMethod);
        }

        /// <summary>Subscribes to a microEvent. Subscribed modules are notified on theircallback method whenever the data is updated, even if the new value is the same as the old value.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module to call with notifications</param>
		/// <param name="arg2_callbackMessage">Message included in the notification. This can be used to disambiguate multiple subscriptions.</param>
		/// <param name="arg3_callbackMethod">Name of the module's method to call when a data is changed</param>
		/// <returns></returns>
        public void SubscribeToMicroEvent(string arg0_name, string arg1_callbackModule, string arg2_callbackMessage, string arg3_callbackMethod)
        {
            SourceService["subscribeToMicroEvent"].Call(arg0_name, arg1_callbackModule, arg2_callbackMessage, arg3_callbackMethod);
        }

        /// <summary>Informs ALMemory that a module doesn't exist anymore.</summary>
		/// <param name="arg0_moduleName">Name of the departing module.</param>
		/// <returns></returns>
        public void UnregisterModuleReference(string arg0_moduleName)
        {
            SourceService["unregisterModuleReference"].Call(arg0_moduleName);
        }

        /// <summary>ALMemory performance</summary>
		/// <returns></returns>
        public void _perf()
        {
            SourceService["_perf"].Call();
        }

        /// <summary>Unsubscribes a module from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">The name of the event</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public void UnsubscribeToEvent(string arg0_name, string arg1_callbackModule)
        {
            SourceService["unsubscribeToEvent"].Call(arg0_name, arg1_callbackModule);
        }

        /// <summary>Unsubscribes from the given event. No further notifications will be received.</summary>
		/// <param name="arg0_name">Name of the event.</param>
		/// <param name="arg1_callbackModule">The name of the module that was given when subscribing.</param>
		/// <returns></returns>
        public void UnsubscribeToMicroEvent(string arg0_name, string arg1_callbackModule)
        {
            SourceService["unsubscribeToMicroEvent"].Call(arg0_name, arg1_callbackModule);
        }

        /// <summary>Insert object in ALMemory. Please use ALMemoryFastAccess</summary>
		/// <param name="arg0_name">ALMemory data name</param>
		/// <param name="arg1_buffer">buffer in ALValue</param>
		/// <param name="arg2_bufferSize">buffer size</param>
		/// <returns>return an array of data's string name.</returns>
        public void _insertObject(string arg0_name, QiAnyValue arg1_buffer, int arg2_bufferSize)
        {
            SourceService["_insertObject"].Call(arg0_name, arg1_buffer, arg2_bufferSize);
        }

        /// <summary>Allows modules to change time policy of already subscribed data.</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_nTimePolicy">time of new policy in ms. Default is 0: no time policy: called at every change/insert. If timepolicy &gt; 0, we will not notifiy under timepolicy even if data change under timepolicy frequency</param>
		/// <returns></returns>
        public void _subscribeOnDataSetTimePolicy(string arg0_name, string arg1_callbackModule, int arg2_nTimePolicy)
        {
            SourceService["_subscribeOnDataSetTimePolicy"].Call(arg0_name, arg1_callbackModule, arg2_nTimePolicy);
        }

        /// <summary>Receives notifications in the same order that the event were sent. This is slower than</summary>
		/// <param name="arg0_name">Name of the data.</param>
		/// <param name="arg1_callbackModule">Name of the module.</param>
		/// <param name="arg2_synchronizedResponse">True to receive notifications in the same order as events are sent</param>
		/// <returns></returns>
        public void _subscribeOnDataSetSynchronizeResponse(string arg0_name, string arg1_callbackModule, bool arg2_synchronizedResponse)
        {
            SourceService["_subscribeOnDataSetSynchronizeResponse"].Call(arg0_name, arg1_callbackModule, arg2_synchronizedResponse);
        }

        /// <summary>Describe a key</summary>
		/// <param name="arg0_name">Name of the key.</param>
		/// <param name="arg1_description">The description of the event (text format).</param>
		/// <returns></returns>
        public void SetDescription(string arg0_name, string arg1_description)
        {
            SourceService["setDescription"].Call(arg0_name, arg1_description);
        }

        /// <summary>Descriptions of all given keys</summary>
		/// <param name="arg0_keylist">List of keys. (empty to get all descriptions)</param>
		/// <returns>an array of tuple (name, type, description) describing all keys.</returns>
        public QiValue GetDescriptionList(IEnumerable<string> arg0_keylist)
        {
            return SourceService["getDescriptionList"].Call(QiList.Create(arg0_keylist));
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signal">Name of the signal</param>
		/// <param name="arg2_event">Name of the event</param>
		/// <returns></returns>
        public void AddMapping(string arg0_service, string arg1_signal, string arg2_event)
        {
            SourceService["addMapping"].Call(arg0_service, arg1_signal, arg2_event);
        }

        /// <summary>Add a mapping between signal and event</summary>
		/// <param name="arg0_service">Name of the service</param>
		/// <param name="arg1_signalEvent">A map of signal corresponding to event</param>
		/// <returns></returns>
        public void AddMapping(string arg0_service, QiAnyValue arg1_signalEvent)
        {
            SourceService["addMapping"].Call(arg0_service, arg1_signalEvent);
        }

    }
}