using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALDialog is the dialog module. It allows loading a dialog file (.top), starts/stops/loads/unloads the dialog</summary>
    public class ALDialog
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALDialog(QiSession session)
        {
            SourceService = session.GetService("ALDialog");
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

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds) if relevant.</param>
		/// <param name="arg2_precision">Precision of the extractor if relevant.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name, int arg1_period, float arg2_precision)
        {
            SourceService["subscribe"].Call(arg0_name, arg1_period, arg2_precision);
        }

        /// <summary>Subscribes to the extractor. This causes the extractor to start writing information to memory using the keys described by getOutputNames(). These can be accessed in memory using ALMemory.getData(&quot;keyName&quot;). In many cases you can avoid calling subscribe on the extractor by just calling ALMemory.subscribeToEvent() supplying a callback method. This will automatically subscribe to the extractor for you.</summary>
		/// <param name="arg0_name">Name of the module which subscribes.</param>
		/// <returns></returns>
        public void Subscribe(string arg0_name)
        {
            SourceService["subscribe"].Call(arg0_name);
        }

        /// <summary>Unsubscribes from the extractor.</summary>
		/// <param name="arg0_name">Name of the module which had subscribed.</param>
		/// <returns></returns>
        public void Unsubscribe(string arg0_name)
        {
            SourceService["unsubscribe"].Call(arg0_name);
        }

        /// <summary>Updates the period if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_period">Refresh period (in milliseconds).</param>
		/// <returns></returns>
        public void UpdatePeriod(string arg0_name, int arg1_period)
        {
            SourceService["updatePeriod"].Call(arg0_name, arg1_period);
        }

        /// <summary>Updates the precision if relevant.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <param name="arg1_precision">Precision of the extractor.</param>
		/// <returns></returns>
        public void UpdatePrecision(string arg0_name, float arg1_precision)
        {
            SourceService["updatePrecision"].Call(arg0_name, arg1_precision);
        }

        /// <summary>Gets the current period.</summary>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetCurrentPeriod()
        {
            return (int)SourceService["getCurrentPeriod"].Call();
        }

        /// <summary>Gets the current precision.</summary>
		/// <returns>Precision of the extractor.</returns>
        public float GetCurrentPrecision()
        {
            return (float)SourceService["getCurrentPrecision"].Call();
        }

        /// <summary>Gets the period for a specific subscription.</summary>
		/// <param name="arg0_name">Name of the module which has subscribed.</param>
		/// <returns>Refresh period (in milliseconds).</returns>
        public int GetMyPeriod(string arg0_name)
        {
            return (int)SourceService["getMyPeriod"].Call(arg0_name);
        }

        /// <summary>Gets the precision for a specific subscription.</summary>
		/// <param name="arg0_name">name of the module which has subscribed</param>
		/// <returns>precision of the extractor</returns>
        public float GetMyPrecision(string arg0_name)
        {
            return (float)SourceService["getMyPrecision"].Call(arg0_name);
        }

        /// <summary>Gets the parameters given by the module.</summary>
		/// <returns>Array of names and parameters of all subscribers.</returns>
        public QiValue GetSubscribersInfo()
        {
            return SourceService["getSubscribersInfo"].Call();
        }

        /// <summary>Get the list of values updated in ALMemory.</summary>
		/// <returns>Array of values updated by this extractor in ALMemory</returns>
        public string[] GetOutputNames()
        {
            return (string[])SourceService["getOutputNames"].Call();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetEventList()
        {
            return (string[])SourceService["getEventList"].Call();
        }

        /// <summary>Get the list of events updated in ALMemory.</summary>
		/// <returns>Array of events updated by this extractor in ALMemory</returns>
        public string[] GetMemoryKeyList()
        {
            return (string[])SourceService["getMemoryKeyList"].Call();
        }

        /// <summary>Callback when speech recognition recognized a word</summary>
		/// <param name="arg0_unsuned">callback unused parameter</param>
		/// <param name="arg1_value">word recognized value</param>
		/// <param name="arg2_message">unused message</param>
		/// <returns></returns>
        public void _wordRecognized(string arg0_unsuned, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_wordRecognized"].Call(arg0_unsuned, arg1_value, arg2_message);
        }

        /// <summary>Is engine stoppable</summary>
		/// <returns>Is engine stoppable</returns>
        public bool GetStoppable()
        {
            return (bool)SourceService["getStoppable"].Call();
        }

        /// <summary>Is engine stoppable</summary>
		/// <param name="arg0_stoppable">set if engine can be stopped by user session</param>
		/// <returns></returns>
        public void SetStoppable(bool arg0_stoppable)
        {
            SourceService["setStoppable"].Call(arg0_stoppable);
        }

        /// <summary>Is engine stoppable</summary>
		/// <param name="arg0_stoppable">set if engine can be stopped by user session</param>
		/// <returns></returns>
        public string[] RunTopics(IEnumerable<string> arg0_stoppable)
        {
            return (string[])SourceService["runTopics"].Call(QiList.Create(arg0_stoppable));
        }

        /// <summary>Is engine stoppable</summary>
		/// <param name="arg0_stoppable">set if engine can be stopped by user session</param>
		/// <returns></returns>
        public void StopTopics(IEnumerable<string> arg0_stoppable)
        {
            SourceService["stopTopics"].Call(QiList.Create(arg0_stoppable));
        }

        /// <summary>Set sentence phonetic</summary>
		/// <param name="arg0_source">source sentence</param>
		/// <param name="arg1_source">source sentence</param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _setPhonetic(string arg0_source, string arg1_source, string arg2)
        {
            SourceService["_setPhonetic"].Call(arg0_source, arg1_source, arg2);
        }

        /// <summary>Pause/unpause dialog engine and asr</summary>
		/// <param name="arg0_enable">true to pause</param>
		/// <returns></returns>
        public void _pauseEngine(bool arg0_enable)
        {
            SourceService["_pauseEngine"].Call(arg0_enable);
        }

        /// <summary>say a sentence from a topic</summary>
		/// <param name="arg0_stoppable">set if engine can be stopped by user session</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void Say(string arg0_stoppable, string arg1)
        {
            SourceService["say"].Call(arg0_stoppable, arg1);
        }

        /// <summary>ResetLanguage</summary>
		/// <returns></returns>
        public void ResetLanguage()
        {
            SourceService["resetLanguage"].Call();
        }

        /// <summary>The event will stop current TSS</summary>
		/// <param name="arg0_eventName">Event name</param>
		/// <returns></returns>
        public void AddBlockingEvent(string arg0_eventName)
        {
            SourceService["addBlockingEvent"].Call(arg0_eventName);
        }

        /// <summary>The event will removed from the blocking list</summary>
		/// <param name="arg0_eventName">Event name</param>
		/// <returns></returns>
        public void RemoveBlockingEvent(string arg0_eventName)
        {
            SourceService["removeBlockingEvent"].Call(arg0_eventName);
        }

        /// <summary>Asr callback for recognized words</summary>
		/// <param name="arg0_grammar">recognized grammar</param>
		/// <param name="arg1_utteranceSize">Utterance size</param>
		/// <returns></returns>
        public void WordsRecognizedCallback(QiAnyValue arg0_grammar, int arg1_utteranceSize)
        {
            SourceService["wordsRecognizedCallback"].Call(arg0_grammar, arg1_utteranceSize);
        }

        /// <summary>End of utterance asr callback</summary>
		/// <returns>true if reprocess buffer</returns>
        public bool EndOfUtteranceCallback()
        {
            return (bool)SourceService["endOfUtteranceCallback"].Call();
        }

        /// <summary>Experimental: release engine after call of controlEngine</summary>
		/// <returns></returns>
        public void _releaseEngine()
        {
            SourceService["_releaseEngine"].Call();
        }

        /// <summary>Experimental: controlEngine and say a tag</summary>
		/// <param name="arg0_topicName">topic name</param>
		/// <param name="arg1_tagName">tag name</param>
		/// <returns>Robot answer list</returns>
        public string[] _controlEngine(string arg0_topicName, string arg1_tagName)
        {
            return (string[])SourceService["_controlEngine"].Call(arg0_topicName, arg1_tagName);
        }

        /// <summary>hasPreference</summary>
		/// <returns>true if has preference</returns>
        public bool _hasPreference()
        {
            return (bool)SourceService["_hasPreference"].Call();
        }

        /// <summary>Callback when dialog received a event</summary>
		/// <param name="arg0_eventName">event name received</param>
		/// <param name="arg1_eventValue">event value</param>
		/// <param name="arg2_message">unused event message</param>
		/// <returns></returns>
        public void _eventReceived(string arg0_eventName, QiAnyValue arg1_eventValue, string arg2_message)
        {
            SourceService["_eventReceived"].Call(arg0_eventName, arg1_eventValue, arg2_message);
        }

        /// <summary>Callback when ASR status changes</summary>
		/// <param name="arg0_internalCallBackEvent">unused</param>
		/// <param name="arg1_internalCallbackValue">unused</param>
		/// <param name="arg2_message">unused</param>
		/// <returns></returns>
        public void _statusChanged(string arg0_internalCallBackEvent, QiAnyValue arg1_internalCallbackValue, string arg2_message)
        {
            SourceService["_statusChanged"].Call(arg0_internalCallBackEvent, arg1_internalCallbackValue, arg2_message);
        }

        /// <summary>Callback when ASR status changes</summary>
		/// <param name="arg0_topicName">topic name</param>
		/// <param name="arg1_tagName">tag name</param>
		/// <returns></returns>
        public void GotoTag(string arg0_topicName, string arg1_tagName)
        {
            SourceService["gotoTag"].Call(arg0_topicName, arg1_tagName);
        }

        /// <summary>noPick</summary>
		/// <param name="arg0_topicName">Topic name</param>
		/// <returns></returns>
        public void NoPick(string arg0_topicName)
        {
            SourceService["noPick"].Call(arg0_topicName);
        }

        /// <summary>Callback when remote connection changes</summary>
		/// <param name="arg0_internalCallBackEvent">unused</param>
		/// <param name="arg1_internalCallbackValue">unused</param>
		/// <param name="arg2_message">unused</param>
		/// <returns></returns>
        public void _connectionChanged(string arg0_internalCallBackEvent, QiAnyValue arg1_internalCallbackValue, string arg2_message)
        {
            SourceService["_connectionChanged"].Call(arg0_internalCallBackEvent, arg1_internalCallbackValue, arg2_message);
        }

        /// <summary>compile all for ASR</summary>
		/// <returns></returns>
        public void CompileAll()
        {
            SourceService["compileAll"].Call();
        }

        /// <summary>compile all for ASR</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void CompileBundle(string arg0)
        {
            SourceService["compileBundle"].Call(arg0);
        }

        /// <summary>Create a context</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void CreateContext(string arg0, string arg1, string arg2)
        {
            SourceService["createContext"].Call(arg0, arg1, arg2);
        }

        /// <summary>Load a topic</summary>
		/// <param name="arg0_topicPath">topic full path and filename</param>
		/// <returns>Topic path and filename</returns>
        public string LoadTopic(string arg0_topicPath)
        {
            return (string)SourceService["loadTopic"].Call(arg0_topicPath);
        }

        /// <summary>Load a topic</summary>
		/// <param name="arg0_topicContent">topic content</param>
		/// <returns>Topic name</returns>
        public string LoadTopicContent(string arg0_topicContent)
        {
            return (string)SourceService["loadTopicContent"].Call(arg0_topicContent);
        }

        /// <summary>Activate a topic</summary>
		/// <param name="arg0_topicName">topic name</param>
		/// <returns></returns>
        public void DeactivateTopic(string arg0_topicName)
        {
            SourceService["deactivateTopic"].Call(arg0_topicName);
        }

        /// <summary>Activate a topic</summary>
		/// <param name="arg0_topicName">topic name</param>
		/// <returns></returns>
        public void ActivateTopic(string arg0_topicName)
        {
            SourceService["activateTopic"].Call(arg0_topicName);
        }

        /// <summary>unload a dialog</summary>
		/// <param name="arg0_topicName">topic name</param>
		/// <returns></returns>
        public void UnloadTopic(string arg0_topicName)
        {
            SourceService["unloadTopic"].Call(arg0_topicName);
        }

        /// <summary>Get a proposal</summary>
		/// <returns></returns>
        public void ForceOutput()
        {
            SourceService["forceOutput"].Call();
        }

        /// <summary>Give a sentence to the dialog and get the answer</summary>
		/// <param name="arg0_input">input string that simulate humain sentence</param>
		/// <returns></returns>
        public void ForceInput(string arg0_input)
        {
            SourceService["forceInput"].Call(arg0_input);
        }

        /// <summary>Give a sentence to the dialog and get the answer</summary>
		/// <param name="arg0_input">input string that simulate humain sentence</param>
		/// <returns></returns>
        public void Tell(string arg0_input)
        {
            SourceService["tell"].Call(arg0_input);
        }

        /// <summary>Set the minimum confidence required to recognize words. Better to use confidence by asr model</summary>
		/// <param name="arg0_threshold">input string that simulate humain sentence</param>
		/// <returns></returns>
        public void SetASRConfidenceThreshold(float arg0_threshold)
        {
            SourceService["setASRConfidenceThreshold"].Call(arg0_threshold);
        }

        /// <summary>Get the minimum confidence required to recognize words</summary>
		/// <returns>current asr confidence</returns>
        public float GetASRConfidenceThreshold()
        {
            return (float)SourceService["getASRConfidenceThreshold"].Call();
        }

        /// <summary>Set the confidence threshold</summary>
		/// <param name="arg0_strategy">Name of the concept</param>
		/// <param name="arg1_confidence">Language of the concept</param>
		/// <returns></returns>
        public void SetConfidenceThreshold(string arg0_strategy, float arg1_confidence)
        {
            SourceService["setConfidenceThreshold"].Call(arg0_strategy, arg1_confidence);
        }

        /// <summary>Set the confidence threshold</summary>
		/// <param name="arg0_strategy">Name of the concept</param>
		/// <param name="arg1_confidence">Language of the concept</param>
		/// <param name="arg2_language">language of the threshold</param>
		/// <returns></returns>
        public void SetConfidenceThreshold(string arg0_strategy, float arg1_confidence, string arg2_language)
        {
            SourceService["setConfidenceThreshold"].Call(arg0_strategy, arg1_confidence, arg2_language);
        }

        /// <summary>Get all the confidence thresholds</summary>
		/// <returns></returns>
        public QiValue GetAllConfidenceThresholds()
        {
            return SourceService["getAllConfidenceThresholds"].Call();
        }

        /// <summary>Get all the confidence thresholds</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public float GetConfidenceThreshold(string arg0, string arg1)
        {
            return (float)SourceService["getConfidenceThreshold"].Call(arg0, arg1);
        }

        /// <summary>Remove all language specific confidence thresholds</summary>
		/// <returns></returns>
        public void RemoveAllLanguageThresholds()
        {
            SourceService["removeAllLanguageThresholds"].Call();
        }

        /// <summary>Set the minimum confidence required to recognize words for a strategy</summary>
		/// <param name="arg0_strategy">BNF or SLM</param>
		/// <param name="arg1_threshold">threshold [0,1]</param>
		/// <returns></returns>
        public void _setConfidence(string arg0_strategy, float arg1_threshold)
        {
            SourceService["_setConfidence"].Call(arg0_strategy, arg1_threshold);
        }

        /// <summary>Get the minimum confidence required to recognize words of a strategy</summary>
		/// <param name="arg0_strategy">BNF or SLM</param>
		/// <returns>current asr confidence for model</returns>
        public float _getConfidence(string arg0_strategy)
        {
            return (float)SourceService["_getConfidence"].Call(arg0_strategy);
        }

        /// <summary>Open a session</summary>
		/// <param name="arg0_id">user id</param>
		/// <returns></returns>
        public void OpenSession(int arg0_id)
        {
            SourceService["openSession"].Call(arg0_id);
        }

        /// <summary>Get backend</summary>
		/// <returns></returns>
        public string _getBackend()
        {
            return (string)SourceService["_getBackend"].Call();
        }

        /// <summary>Open a test session</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <param name="arg5"></param>
		/// <returns></returns>
        public string _openTestSession(string arg0, string arg1, bool arg2, bool arg3, string arg4, string arg5)
        {
            return (string)SourceService["_openTestSession"].Call(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>close a test session</summary>
		/// <returns></returns>
        public void _closeTestSession()
        {
            SourceService["_closeTestSession"].Call();
        }

        /// <summary>Open a test session</summary>
		/// <param name="arg0_tot">tot file to test</param>
		/// <returns></returns>
        public QiValue _runTotTest(string arg0_tot)
        {
            return SourceService["_runTotTest"].Call(arg0_tot);
        }

        /// <summary>Open a test session</summary>
		/// <param name="arg0_tot">tot file to test</param>
		/// <param name="arg1_wavMode">input wav mode</param>
		/// <returns></returns>
        public QiValue _runTotTest(string arg0_tot, string arg1_wavMode)
        {
            return SourceService["_runTotTest"].Call(arg0_tot, arg1_wavMode);
        }

        /// <summary>Close the current session</summary>
		/// <returns></returns>
        public void CloseSession()
        {
            SourceService["closeSession"].Call();
        }

        /// <summary>Close the test session</summary>
		/// <returns></returns>
        public void CloseTestSession()
        {
            SourceService["closeTestSession"].Call();
        }

        /// <summary>deprecated</summary>
		/// <param name="arg0_name">name</param>
		/// <param name="arg1_topic">topic</param>
		/// <param name="arg2_language">language</param>
		/// <param name="arg3_destination">destination</param>
		/// <returns></returns>
        public void _generateBNF(string arg0_name, string arg1_topic, string arg2_language, string arg3_destination)
        {
            SourceService["_generateBNF"].Call(arg0_name, arg1_topic, arg2_language, arg3_destination);
        }

        /// <summary>change event's delay</summary>
		/// <param name="arg0_eventName">Event name</param>
		/// <param name="arg1_Delay">Delay in second</param>
		/// <returns></returns>
        public void SetDelay(string arg0_eventName, int arg1_Delay)
        {
            SourceService["setDelay"].Call(arg0_eventName, arg1_Delay);
        }

        /// <summary>Set how many scopes remains open</summary>
		/// <param name="arg0_numberOfScope">number of scope</param>
		/// <returns></returns>
        public void SetNumberOfScopes(int arg0_numberOfScope)
        {
            SourceService["setNumberOfScopes"].Call(arg0_numberOfScope);
        }

        /// <summary>Set the content of a dynamic concept</summary>
		/// <param name="arg0_conceptName">Name of the concept</param>
		/// <param name="arg1_language">Language of the concept</param>
		/// <param name="arg2_content">content of the concept</param>
		/// <returns></returns>
        public void SetConcept(string arg0_conceptName, string arg1_language, IEnumerable<string> arg2_content)
        {
            SourceService["setConcept"].Call(arg0_conceptName, arg1_language, QiList.Create(arg2_content));
        }

        /// <summary>Set the content of a dynamic concept</summary>
		/// <param name="arg0_conceptName">Name of the concept</param>
		/// <param name="arg1_language">Language of the concept</param>
		/// <param name="arg2_content">content of the concept</param>
		/// <param name="arg3_store">determine if the concept will be save in the database</param>
		/// <returns></returns>
        public void SetConcept(string arg0_conceptName, string arg1_language, IEnumerable<string> arg2_content, bool arg3_store)
        {
            SourceService["setConcept"].Call(arg0_conceptName, arg1_language, QiList.Create(arg2_content), arg3_store);
        }

        /// <summary>set the content of a dynamic concept</summary>
		/// <param name="arg0_conceptName">concept name</param>
		/// <param name="arg1_language">language</param>
		/// <param name="arg2_content">concept content</param>
		/// <returns></returns>
        public void SetConceptKeepInCache(string arg0_conceptName, string arg1_language, IEnumerable<string> arg2_content)
        {
            SourceService["setConceptKeepInCache"].Call(arg0_conceptName, arg1_language, QiList.Create(arg2_content));
        }

        /// <summary>add to the content of a dynamic concept</summary>
		/// <param name="arg0_conceptName">Name of the concept</param>
		/// <param name="arg1_language">Language of the concept</param>
		/// <param name="arg2_content">content of the concept</param>
		/// <returns></returns>
        public void AddToConcept(string arg0_conceptName, string arg1_language, IEnumerable<string> arg2_content)
        {
            SourceService["addToConcept"].Call(arg0_conceptName, arg1_language, QiList.Create(arg2_content));
        }

        /// <summary>get the content of a dynamic concept</summary>
		/// <param name="arg0_conceptName">Name of the concept</param>
		/// <param name="arg1_language">Language of the concept</param>
		/// <returns></returns>
        public string[] GetConcept(string arg0_conceptName, string arg1_language)
        {
            return (string[])SourceService["getConcept"].Call(arg0_conceptName, arg1_language);
        }

        /// <summary>Set push mode. Frequence of robot question</summary>
		/// <param name="arg0_pushMode">Push mode from 0 to 4</param>
		/// <returns></returns>
        public void _setPushMode(int arg0_pushMode)
        {
            SourceService["_setPushMode"].Call(arg0_pushMode);
        }

        /// <summary>enableTriggerSentences</summary>
		/// <param name="arg0_enableTriggerSentences">Enable trigger sentences if true</param>
		/// <returns></returns>
        public void EnableTriggerSentences(bool arg0_enableTriggerSentences)
        {
            SourceService["enableTriggerSentences"].Call(arg0_enableTriggerSentences);
        }

        /// <summary>enableCategory</summary>
		/// <param name="arg0_enableCategory">Enable category if true</param>
		/// <returns></returns>
        public void EnableCategory(bool arg0_enableCategory)
        {
            SourceService["enableCategory"].Call(arg0_enableCategory);
        }

        /// <summary>Start push mode</summary>
		/// <returns></returns>
        public void StartPush()
        {
            SourceService["startPush"].Call();
        }

        /// <summary>Stop push mode</summary>
		/// <returns></returns>
        public void StopPush()
        {
            SourceService["stopPush"].Call();
        }

        /// <summary>Set the configuration of animated speech for the current dialog.</summary>
		/// <param name="arg0_animatedSpeechConfiguration">See animated speech documentation</param>
		/// <returns></returns>
        public void SetAnimatedSpeechConfiguration(QiAnyValue arg0_animatedSpeechConfiguration)
        {
            SourceService["setAnimatedSpeechConfiguration"].Call(arg0_animatedSpeechConfiguration);
        }

        /// <summary>Get the configuration of animated speech for the current dialog.</summary>
		/// <returns>See animated speech documentation</returns>
        public QiValue GetAnimatedSpeechConfiguration()
        {
            return SourceService["getAnimatedSpeechConfiguration"].Call();
        }

        /// <summary>Black list a list of application</summary>
		/// <param name="arg0_applicationList">List of applications that cannot be launched by dialog</param>
		/// <returns></returns>
        public void ApplicationBlackList(IEnumerable<string> arg0_applicationList)
        {
            SourceService["applicationBlackList"].Call(QiList.Create(arg0_applicationList));
        }

        /// <summary>True if new content was installed</summary>
		/// <returns>True if content was updated since last compilation</returns>
        public bool IsContentNeedsUpdate()
        {
            return (bool)SourceService["isContentNeedsUpdate"].Call();
        }

        /// <summary>private method to be able to set in specific include dir</summary>
		/// <param name="arg0_topicPathName">Topic path and filename</param>
		/// <param name="arg1_includeDirectory">Root of the behavior</param>
		/// <returns>Topic name (not filename)</returns>
        public string _addDialogFromTopicBox(string arg0_topicPathName, string arg1_includeDirectory)
        {
            return (string)SourceService["_addDialogFromTopicBox"].Call(arg0_topicPathName, arg1_includeDirectory);
        }

        /// <summary>Clean event stack</summary>
		/// <returns></returns>
        public void _cleanEventStack()
        {
            SourceService["_cleanEventStack"].Call();
        }

        /// <summary>Connect to custom AI client</summary>
		/// <param name="arg0_libraryPath">library path</param>
		/// <returns></returns>
        public void _updateAIClient(string arg0_libraryPath)
        {
            SourceService["_updateAIClient"].Call(arg0_libraryPath);
        }

        /// <summary>Create a user group</summary>
		/// <param name="arg0_groupName">User group name</param>
		/// <param name="arg1_topicNameList">Topic to add in group</param>
		/// <returns></returns>
        public void _addTopicsInGroup(string arg0_groupName, IEnumerable<string> arg1_topicNameList)
        {
            SourceService["_addTopicsInGroup"].Call(arg0_groupName, QiList.Create(arg1_topicNameList));
        }

        /// <summary>Group to activate</summary>
		/// <param name="arg0_groupName">group name</param>
		/// <returns></returns>
        public void _activateGroup(string arg0_groupName)
        {
            SourceService["_activateGroup"].Call(arg0_groupName);
        }

        /// <summary>private method to be able to set in specific include dir</summary>
		/// <param name="arg0_groupName">group name</param>
		/// <returns></returns>
        public void _deactivateGroup(string arg0_groupName)
        {
            SourceService["_deactivateGroup"].Call(arg0_groupName);
        }

        /// <summary>suggest next topic</summary>
		/// <param name="arg0_topicName">group name</param>
		/// <param name="arg1_suggestionValidity">Suggestion validity in second</param>
		/// <returns></returns>
        public void _suggestNextTopic(string arg0_topicName, int arg1_suggestionValidity)
        {
            SourceService["_suggestNextTopic"].Call(arg0_topicName, arg1_suggestionValidity);
        }

        /// <summary>suggest next topic</summary>
		/// <param name="arg0_topicName">group name</param>
		/// <param name="arg1_suggestionValidity">Suggestion validity in second</param>
		/// <param name="arg2_userID">Suggestion validity for userID</param>
		/// <returns></returns>
        public void _suggestUserNextTopic(string arg0_topicName, int arg1_suggestionValidity, int arg2_userID)
        {
            SourceService["_suggestUserNextTopic"].Call(arg0_topicName, arg1_suggestionValidity, arg2_userID);
        }

        /// <summary>preload main dialog</summary>
		/// <returns></returns>
        public void _preloadMain()
        {
            SourceService["_preloadMain"].Call();
        }

        /// <summary>Define only language to use</summary>
		/// <param name="arg0_languageName">monoLanguageName</param>
		/// <returns></returns>
        public void _mainLanguage(string arg0_languageName)
        {
            SourceService["_mainLanguage"].Call(arg0_languageName);
        }

        /// <summary>run main dialog without speaking</summary>
		/// <returns></returns>
        public void _runMainNoActivation()
        {
            SourceService["_runMainNoActivation"].Call();
        }

        /// <summary>run main dialog</summary>
		/// <returns></returns>
        public void _runMain()
        {
            SourceService["_runMain"].Call();
        }

        /// <summary>run main dialog</summary>
		/// <param name="arg0_engagementMode">engagementMode</param>
		/// <returns></returns>
        public void _startDialog(string arg0_engagementMode)
        {
            SourceService["_startDialog"].Call(arg0_engagementMode);
        }

        /// <summary>change engagement mode</summary>
		/// <param name="arg0_engagementMode">engagementMode</param>
		/// <returns></returns>
        public void _setEngagementMode(string arg0_engagementMode)
        {
            SourceService["_setEngagementMode"].Call(arg0_engagementMode);
        }

        /// <summary>change engagement mode</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void Pause(bool arg0)
        {
            SourceService["pause"].Call(arg0);
        }

        /// <summary>change engagement mode</summary>
		/// <returns></returns>
        public void _endPause()
        {
            SourceService["_endPause"].Call();
        }

        /// <summary>run main dialog</summary>
		/// <returns></returns>
        public void RunDialog()
        {
            SourceService["runDialog"].Call();
        }

        /// <summary>reset preload settings</summary>
		/// <returns></returns>
        public void _resetPreload()
        {
            SourceService["_resetPreload"].Call();
        }

        /// <summary>stop main dialog</summary>
		/// <returns></returns>
        public void _stopMain()
        {
            SourceService["_stopMain"].Call();
        }

        /// <summary>stop main dialog</summary>
		/// <returns></returns>
        public void StopDialog()
        {
            SourceService["stopDialog"].Call();
        }

        /// <summary>load a strategy configuration</summary>
		/// <param name="arg0_strategyFile">Strategy path and filename</param>
		/// <returns></returns>
        public void _loadStrategyConfiguration(string arg0_strategyFile)
        {
            SourceService["_loadStrategyConfiguration"].Call(arg0_strategyFile);
        }

        /// <summary>setVariablePath redifine a variable name on the fly</summary>
		/// <param name="arg0_topic">Source topic name</param>
		/// <param name="arg1_event">Event name</param>
		/// <param name="arg2_path">New event name</param>
		/// <returns></returns>
        public void SetVariablePath(string arg0_topic, string arg1_event, string arg2_path)
        {
            SourceService["setVariablePath"].Call(arg0_topic, arg1_event, arg2_path);
        }

        /// <summary>register IO</summary>
		/// <param name="arg0_boxName">Box name</param>
		/// <param name="arg1_topicName">Topic name</param>
		/// <param name="arg2_inputList">Input list</param>
		/// <param name="arg3_outputList">Output list</param>
		/// <returns></returns>
        public void _registerIO(string arg0_boxName, string arg1_topicName, IEnumerable<string> arg2_inputList, IEnumerable<string> arg3_outputList)
        {
            SourceService["_registerIO"].Call(arg0_boxName, arg1_topicName, QiList.Create(arg2_inputList), QiList.Create(arg3_outputList));
        }

        /// <summary>unregister IO</summary>
		/// <param name="arg0_boxName">Box name</param>
		/// <param name="arg1_topicName">Topic name</param>
		/// <returns></returns>
        public void _unregisterIO(string arg0_boxName, string arg1_topicName)
        {
            SourceService["_unregisterIO"].Call(arg0_boxName, arg1_topicName);
        }

        /// <summary>Send a message input</summary>
		/// <param name="arg0_boxName">Box name</param>
		/// <param name="arg1_topicName">Topic name</param>
		/// <param name="arg2_variableName">Variable name</param>
		/// <param name="arg3_value">Value</param>
		/// <returns></returns>
        public void _messageIn(string arg0_boxName, string arg1_topicName, string arg2_variableName, QiAnyValue arg3_value)
        {
            SourceService["_messageIn"].Call(arg0_boxName, arg1_topicName, arg2_variableName, arg3_value);
        }

        /// <summary>setLanguage</summary>
		/// <param name="arg0_Language">Set dialog language (frf, enu, jpj...)</param>
		/// <returns></returns>
        public void SetLanguage(string arg0_Language)
        {
            SourceService["setLanguage"].Call(arg0_Language);
        }

        /// <summary>getLanguage</summary>
		/// <returns>get the dialog language</returns>
        public string GetLanguage()
        {
            return (string)SourceService["getLanguage"].Call();
        }

        /// <summary>startUpdate</summary>
		/// <param name="arg0_variableName">variable name</param>
		/// <param name="arg1_variableValue">variable value</param>
		/// <param name="arg2_message">message</param>
		/// <returns></returns>
        public void _startUpdate(string arg0_variableName, QiAnyValue arg1_variableValue, string arg2_message)
        {
            SourceService["_startUpdate"].Call(arg0_variableName, arg1_variableValue, arg2_message);
        }

        /// <summary>startUpdate</summary>
		/// <param name="arg0_variableName">variable name</param>
		/// <param name="arg1_variableValue">variable value</param>
		/// <param name="arg2_message">message</param>
		/// <returns></returns>
        public void _startApp(string arg0_variableName, QiAnyValue arg1_variableValue, string arg2_message)
        {
            SourceService["_startApp"].Call(arg0_variableName, arg1_variableValue, arg2_message);
        }

        /// <summary>packageInstalled</summary>
		/// <param name="arg0_variableName">variable name</param>
		/// <param name="arg1_variableValue">variable value</param>
		/// <param name="arg2_message">message</param>
		/// <returns></returns>
        public void _packageInstalled(string arg0_variableName, QiAnyValue arg1_variableValue, string arg2_message)
        {
            SourceService["_packageInstalled"].Call(arg0_variableName, arg1_variableValue, arg2_message);
        }

        /// <summary>dialogAnswered</summary>
		/// <param name="arg0_variableName">variable name</param>
		/// <param name="arg1_variableValue">variable value</param>
		/// <param name="arg2_message">message</param>
		/// <returns></returns>
        public void DialogAnswered(string arg0_variableName, QiAnyValue arg1_variableValue, string arg2_message)
        {
            SourceService["dialogAnswered"].Call(arg0_variableName, arg1_variableValue, arg2_message);
        }

        /// <summary>compilationFinished</summary>
		/// <param name="arg0_variableName">variable name</param>
		/// <param name="arg1_variableValue">variable value</param>
		/// <param name="arg2_message">message</param>
		/// <returns></returns>
        public void _compilationFinished(string arg0_variableName, QiAnyValue arg1_variableValue, string arg2_message)
        {
            SourceService["_compilationFinished"].Call(arg0_variableName, arg1_variableValue, arg2_message);
        }

        /// <summary>Give focus to a dialog</summary>
		/// <param name="arg0_topicName">Topic name</param>
		/// <returns></returns>
        public void SetFocus(string arg0_topicName)
        {
            SourceService["setFocus"].Call(arg0_topicName);
        }

        /// <summary>Give focus to a dialog</summary>
		/// <returns>Current focus name</returns>
        public string GetFocus()
        {
            return (string)SourceService["getFocus"].Call();
        }

        /// <summary>Set the focus to a topic and make a proposal</summary>
		/// <param name="arg0_topicName">Topic name</param>
		/// <returns></returns>
        public void GotoTopic(string arg0_topicName)
        {
            SourceService["gotoTopic"].Call(arg0_topicName);
        }

        /// <summary>Enable AI System</summary>
		/// <param name="arg0_enableFullBNF">Add all possible sentences in speech recognition</param>
		/// <returns></returns>
        public void _enableOneBNFActivated(bool arg0_enableFullBNF)
        {
            SourceService["_enableOneBNFActivated"].Call(arg0_enableFullBNF);
        }

        /// <summary>Enable AI System</summary>
		/// <param name="arg0_enableAISystem">Enable AI system</param>
		/// <returns></returns>
        public void _enableAISystem(bool arg0_enableAISystem)
        {
            SourceService["_enableAISystem"].Call(arg0_enableAISystem);
        }

        /// <summary>Add a fallback plugin</summary>
		/// <param name="arg0_language">The language of the plugin</param>
		/// <param name="arg1_name">The name of the plugin</param>
		/// <returns></returns>
        public void AddFallback(string arg0_language, string arg1_name)
        {
            SourceService["addFallback"].Call(arg0_language, arg1_name);
        }

        /// <summary>Remove a fallback plugin</summary>
		/// <param name="arg0_language">The language of the plugin</param>
		/// <param name="arg1_name">The name of the plugin</param>
		/// <returns></returns>
        public void RemoveFallback(string arg0_language, string arg1_name)
        {
            SourceService["removeFallback"].Call(arg0_language, arg1_name);
        }

        /// <summary>Load precompiled file</summary>
		/// <param name="arg0_filepath">File path and filename</param>
		/// <param name="arg1_bundleName">Bundle name</param>
		/// <param name="arg2_language">Language name</param>
		/// <returns></returns>
        public void _loadPrecompiledFile(string arg0_filepath, string arg1_bundleName, string arg2_language)
        {
            SourceService["_loadPrecompiledFile"].Call(arg0_filepath, arg1_bundleName, arg2_language);
        }

        /// <summary>Load SLM</summary>
		/// <param name="arg0_SLMFile">SLM path and filename</param>
		/// <param name="arg1_language">Language name</param>
		/// <returns></returns>
        public void _loadSLM(string arg0_SLMFile, string arg1_language)
        {
            SourceService["_loadSLM"].Call(arg0_SLMFile, arg1_language);
        }

        /// <summary>List loaded topics</summary>
		/// <param name="arg0_language">Language name</param>
		/// <returns>List of loaded topics</returns>
        public string[] GetLoadedTopics(string arg0_language)
        {
            return (string[])SourceService["getLoadedTopics"].Call(arg0_language);
        }

        /// <summary>List loaded topics independent of language</summary>
		/// <returns>List of loaded topics</returns>
        public string[] GetAllLoadedTopics()
        {
            return (string[])SourceService["getAllLoadedTopics"].Call();
        }

        /// <summary>Get activated topics</summary>
		/// <returns>List of activated topics</returns>
        public string[] GetActivatedTopics()
        {
            return (string[])SourceService["getActivatedTopics"].Call();
        }

        /// <summary>fast behavior start</summary>
		/// <param name="arg0_Event">Event name</param>
		/// <returns></returns>
        public void _setBehaviorEvent(string arg0_Event)
        {
            SourceService["_setBehaviorEvent"].Call(arg0_Event);
        }

        /// <summary>triggers and proposal are activated in the model at compilation time</summary>
		/// <param name="arg0_enable">Enable fast activation</param>
		/// <returns></returns>
        public void _fastModelActivation(bool arg0_enable)
        {
            SourceService["_fastModelActivation"].Call(arg0_enable);
        }

        /// <summary>byPass fast approximative matching</summary>
		/// <param name="arg0_fastApproximative">enable fast approximative matching</param>
		/// <returns></returns>
        public void _byPassFastApproximateMatching(bool arg0_fastApproximative)
        {
            SourceService["_byPassFastApproximateMatching"].Call(arg0_fastApproximative);
        }

        /// <summary>activate a tag</summary>
		/// <param name="arg0_tagName">tag name</param>
		/// <param name="arg1_topicName">topic name</param>
		/// <returns></returns>
        public void ActivateTag(string arg0_tagName, string arg1_topicName)
        {
            SourceService["activateTag"].Call(arg0_tagName, arg1_topicName);
        }

        /// <summary>deactivate a tag</summary>
		/// <param name="arg0_tagName">tag name</param>
		/// <param name="arg1_topicName">topic name</param>
		/// <returns></returns>
        public void DeactivateTag(string arg0_tagName, string arg1_topicName)
        {
            SourceService["deactivateTag"].Call(arg0_tagName, arg1_topicName);
        }

        /// <summary>fallback (experimentatl)</summary>
		/// <param name="arg0_Question">User question</param>
		/// <param name="arg1_Language">Language</param>
		/// <returns></returns>
        public string _fallback(string arg0_Question, string arg1_Language)
        {
            return (string)SourceService["_fallback"].Call(arg0_Question, arg1_Language);
        }

        /// <summary>Reset all engine</summary>
		/// <returns></returns>
        public void ResetAll()
        {
            SourceService["resetAll"].Call();
        }

        /// <summary>set Synchronicity</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setSynchronicity(bool arg0)
        {
            SourceService["_setSynchronicity"].Call(arg0);
        }

        /// <summary>get Synchronicity</summary>
		/// <returns></returns>
        public bool _getSynchronicity()
        {
            return (bool)SourceService["_getSynchronicity"].Call();
        }

        /// <summary>insert user data into dialog database</summary>
		/// <param name="arg0_variableName">Variable name</param>
		/// <param name="arg1_variableValue">Variable value</param>
		/// <param name="arg2_UserID">User ID</param>
		/// <returns></returns>
        public void InsertUserData(string arg0_variableName, string arg1_variableValue, int arg2_UserID)
        {
            SourceService["insertUserData"].Call(arg0_variableName, arg1_variableValue, arg2_UserID);
        }

        /// <summary>get user data from dialog database</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] _magicGet(string arg0)
        {
            return (string[])SourceService["_magicGet"].Call(arg0);
        }

        /// <summary>get user data from dialog database</summary>
		/// <param name="arg0_variableName">Variable name</param>
		/// <param name="arg1_UserID">User ID</param>
		/// <returns>Value</returns>
        public string GetUserData(string arg0_variableName, int arg1_UserID)
        {
            return (string)SourceService["getUserData"].Call(arg0_variableName, arg1_UserID);
        }

        /// <summary>get user data list from dialog database</summary>
		/// <param name="arg0_UserID">User ID</param>
		/// <returns>Variable list</returns>
        public string[] GetUserDataList(int arg0_UserID)
        {
            return (string[])SourceService["getUserDataList"].Call(arg0_UserID);
        }

        /// <summary>get user list from dialog database</summary>
		/// <returns>User list</returns>
        public int[] GetUserList()
        {
            return (int[])SourceService["getUserList"].Call();
        }

        /// <summary>remove a user from the database</summary>
		/// <param name="arg0_UserID">User ID</param>
		/// <returns></returns>
        public void RemoveUserData(int arg0_UserID)
        {
            SourceService["removeUserData"].Call(arg0_UserID);
        }

        /// <summary>clear concepts in DB</summary>
		/// <returns></returns>
        public void ClearConcepts()
        {
            SourceService["clearConcepts"].Call();
        }

        /// <summary>callback</summary>
		/// <returns></returns>
        public void _speechDetected()
        {
            SourceService["_speechDetected"].Call();
        }

        /// <summary>let the robot send log the cloud</summary>
		/// <param name="arg0_EnableLog">Enable log</param>
		/// <returns></returns>
        public void EnableSendingLogToCloud(bool arg0_EnableLog)
        {
            SourceService["enableSendingLogToCloud"].Call(arg0_EnableLog);
        }

        /// <summary>encrypt the logs sent tothe cloud</summary>
		/// <param name="arg0_EnableLog">Remove user log</param>
		/// <returns></returns>
        public void _encryptLog(bool arg0_EnableLog)
        {
            SourceService["_encryptLog"].Call(arg0_EnableLog);
        }

        /// <summary>check if the robot is sending the log to the cloud</summary>
		/// <returns>True if currently logging</returns>
        public bool IsSendingLogToCloud()
        {
            return (bool)SourceService["isSendingLogToCloud"].Call();
        }

        /// <summary>check if the robot is encrypting the log sent to the cloud</summary>
		/// <returns>True if currently encrypt logging</returns>
        public bool _isEncryptingLog()
        {
            return (bool)SourceService["_isEncryptingLog"].Call();
        }

        /// <summary>enable sending log audio (recorded conversation) to the cloud</summary>
		/// <param name="arg0"></param>
		/// <returns>Enable audio log</returns>
        public void EnableLogAudio(bool arg0)
        {
            SourceService["enableLogAudio"].Call(arg0);
        }

        /// <summary>The deletion cost (deleting from the sentence to match the model)</summary>
		/// <param name="arg0_MatchingDeletionCost">Deletion cost</param>
		/// <returns></returns>
        public void _setDeletionCost(float arg0_MatchingDeletionCost)
        {
            SourceService["_setDeletionCost"].Call(arg0_MatchingDeletionCost);
        }

        /// <summary>The insertion cost (inserting in the sentence to match the model)</summary>
		/// <param name="arg0_MatchingInsertCost">Insert cost</param>
		/// <returns></returns>
        public void _setInsertionCost(float arg0_MatchingInsertCost)
        {
            SourceService["_setInsertionCost"].Call(arg0_MatchingInsertCost);
        }

        /// <summary>The substitution cost</summary>
		/// <param name="arg0_MatchingSubstitutionCost">Substitution cost</param>
		/// <returns></returns>
        public void _setSubstitutionCost(float arg0_MatchingSubstitutionCost)
        {
            SourceService["_setSubstitutionCost"].Call(arg0_MatchingSubstitutionCost);
        }

        /// <summary>The cost of matching an open element (such as _*)</summary>
		/// <param name="arg0_MatchingStarCost">Wildcard cost</param>
		/// <returns></returns>
        public void _setStarCost(float arg0_MatchingStarCost)
        {
            SourceService["_setStarCost"].Call(arg0_MatchingStarCost);
        }

        /// <summary>The approximate matching threshold</summary>
		/// <param name="arg0_MatchingThreshold">Matching threshold</param>
		/// <returns></returns>
        public void _setApproximateMatchingThreshold(float arg0_MatchingThreshold)
        {
            SourceService["_setApproximateMatchingThreshold"].Call(arg0_MatchingThreshold);
        }

        /// <summary>Tell to the model to use acrobatic matching</summary>
		/// <param name="arg0_EnableAccrobatic">Enable accrobatic matching</param>
		/// <returns></returns>
        public void _useAcrobaticMatching(bool arg0_EnableAccrobatic)
        {
            SourceService["_useAcrobaticMatching"].Call(arg0_EnableAccrobatic);
        }

        /// <summary>Tell to the model to use statistical matching</summary>
		/// <param name="arg0_EnableSemantic">Enable semantic matching</param>
		/// <returns></returns>
        public void _enableStatisticalMatching(bool arg0_EnableSemantic)
        {
            SourceService["_enableStatisticalMatching"].Call(arg0_EnableSemantic);
        }

        /// <summary>Tell to the model to use phonetic matching</summary>
		/// <param name="arg0_EnablePhonetic">Enable phonetic matching</param>
		/// <returns></returns>
        public void _enablePhoneticMatching(bool arg0_EnablePhonetic)
        {
            SourceService["_enablePhoneticMatching"].Call(arg0_EnablePhonetic);
        }

        /// <summary>Specify the directory and language of the statistical model</summary>
		/// <param name="arg0_semanticPath">Semantic matching data path</param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _setSemanticModel(string arg0_semanticPath, string arg1)
        {
            SourceService["_setSemanticModel"].Call(arg0_semanticPath, arg1);
        }

        /// <summary>Is one pass enabled</summary>
		/// <returns>Enable only one speech recognition</returns>
        public bool _isOnePassEnabled()
        {
            return (bool)SourceService["_isOnePassEnabled"].Call();
        }

        /// <summary>set SLM High treshold</summary>
		/// <param name="arg0_SLMUpper">SLM Upper Threshold</param>
		/// <returns></returns>
        public void _setSLMUpperThreshold(float arg0_SLMUpper)
        {
            SourceService["_setSLMUpperThreshold"].Call(arg0_SLMUpper);
        }

        /// <summary>enable use of serialized models</summary>
		/// <param name="arg0_enableSerialization">Enable serialization</param>
		/// <returns></returns>
        public void _enableSerialization(bool arg0_enableSerialization)
        {
            SourceService["_enableSerialization"].Call(arg0_enableSerialization);
        }

        /// <summary>delete serializations files .ser .ini .bnf .lcf</summary>
		/// <returns></returns>
        public void DeleteSerializationFiles()
        {
            SourceService["deleteSerializationFiles"].Call();
        }

        /// <summary>mute dialog</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void Mute(bool arg0)
        {
            SourceService["mute"].Call(arg0);
        }

        /// <summary>Set if the input concepts are copied</summary>
		/// <param name="arg0_copyInput">False to optimize</param>
		/// <returns></returns>
        public void _copyInputConcepts(bool arg0_copyInput)
        {
            SourceService["_copyInputConcepts"].Call(arg0_copyInput);
        }

        /// <summary>Set if the input concepts are copied</summary>
		/// <param name="arg0_copyOutput">False to optimize</param>
		/// <returns></returns>
        public void _copyOutputConcepts(bool arg0_copyOutput)
        {
            SourceService["_copyOutputConcepts"].Call(arg0_copyOutput);
        }

        /// <summary>Generate sentences</summary>
		/// <param name="arg0_destination">file destination</param>
		/// <param name="arg1_topic">source topic</param>
		/// <param name="arg2_language">source language</param>
		/// <returns></returns>
        public void GenerateSentences(string arg0_destination, string arg1_topic, string arg2_language)
        {
            SourceService["generateSentences"].Call(arg0_destination, arg1_topic, arg2_language);
        }

        /// <summary>Set the sentence length to apply -after star optimization- in matching</summary>
		/// <param name="arg0_length">set length</param>
		/// <returns></returns>
        public void _setLengthForAfterStarOptimization(int arg0_length)
        {
            SourceService["_setLengthForAfterStarOptimization"].Call(arg0_length);
        }

        /// <summary>Set the sentence length to apply -before star optimization- in matching</summary>
		/// <param name="arg0_length">set length</param>
		/// <returns></returns>
        public void _setLengthForBeforeStarOptimization(int arg0_length)
        {
            SourceService["_setLengthForBeforeStarOptimization"].Call(arg0_length);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onUserSessionFocused(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onUserSessionFocused"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _onUserDeleted(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_onUserDeleted"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public QiValue _us_getUserData(string arg0, string arg1, string arg2)
        {
            return SourceService["_us_getUserData"].Call(arg0, arg1, arg2);
        }

        /// <summary>Query if dialog sessions are controlled by ALUserSession</summary>
		/// <param name="arg0_is_obeyed">Bool. True if dialog should open/close sessions according to ALUserSession</param>
		/// <returns></returns>
        public void _setUserSessionObeyed(bool arg0_is_obeyed)
        {
            SourceService["_setUserSessionObeyed"].Call(arg0_is_obeyed);
        }

        /// <summary>Query if dialog sessions are controlled by ALUserSession</summary>
		/// <returns>Bool. True if dialog will open/close sessions according to ALUserSession</returns>
        public bool _isUserSessionObeyed()
        {
            return (bool)SourceService["_isUserSessionObeyed"].Call();
        }

        /// <summary>get language map ISO to NU format</summary>
		/// <returns>get language map ISO to NU format</returns>
        public QiValue GetLanguageListISOToNU()
        {
            return SourceService["getLanguageListISOToNU"].Call();
        }

        /// <summary>get language map NU to ISO format</summary>
		/// <returns>get language map NU to ISO format</returns>
        public QiValue GetLanguageListNUToISO()
        {
            return SourceService["getLanguageListNUToISO"].Call();
        }

        /// <summary>get language map Long to NU format</summary>
		/// <returns>get language map Long to NU format</returns>
        public QiValue GetLanguageListLongToNU()
        {
            return SourceService["getLanguageListLongToNU"].Call();
        }

        /// <summary>get language map NU to Long format</summary>
		/// <returns>get language map NU to Long format</returns>
        public QiValue GetLanguageListNUToLong()
        {
            return SourceService["getLanguageListNUToLong"].Call();
        }

        /// <summary>convert language from NU format to Long format</summary>
		/// <param name="arg0_Language">language in NU format</param>
		/// <returns>language in Long format </returns>
        public string ConvertNUToLong(string arg0_Language)
        {
            return (string)SourceService["convertNUToLong"].Call(arg0_Language);
        }

        /// <summary>convert language from Long format to NU format</summary>
		/// <param name="arg0_Language">language in Long format</param>
		/// <returns>language in NU format </returns>
        public string ConvertLongToNU(string arg0_Language)
        {
            return (string)SourceService["convertLongToNU"].Call(arg0_Language);
        }

        /// <summary>convert language from ISO format to NU format</summary>
		/// <param name="arg0_Language">language in ISO format</param>
		/// <returns>language in NU format </returns>
        public string ConvertISOToNU(string arg0_Language)
        {
            return (string)SourceService["convertISOToNU"].Call(arg0_Language);
        }

        /// <summary>convert language from NU format to ISO format</summary>
		/// <param name="arg0_Language">language in NU format</param>
		/// <returns>language in ISO format </returns>
        public string ConvertNUToISO(string arg0_Language)
        {
            return (string)SourceService["convertNUToISO"].Call(arg0_Language);
        }

        /// <summary>Define if applications will be launched or not</summary>
		/// <param name="arg0_simulateApps">set simulated apps</param>
		/// <returns></returns>
        public void EnableSimulatedApps(bool arg0_simulateApps)
        {
            SourceService["enableSimulatedApps"].Call(arg0_simulateApps);
        }

    }
}