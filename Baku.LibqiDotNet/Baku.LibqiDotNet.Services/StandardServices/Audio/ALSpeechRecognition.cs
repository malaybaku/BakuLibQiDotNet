using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALSpeechRecognition gives access to the embedded voice recognition system. It can be dynamically modified. This class allows user to load the current words list that should be recognized. The result of the recognition engine is located in the ALMemory's key: &quot;WordRecognized&quot;. The structure of the result is an array :  [ (string) word , (float) confidence ]</summary>
    public class ALSpeechRecognition
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALSpeechRecognition(QiSession session)
        {
            SourceService = session.GetService("ALSpeechRecognition");
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

        /// <summary>Enables or disables the leds animations showing the state of the recognition engine during the recognition process.</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public void SetVisualExpression(bool arg0_setOrNot)
        {
            SourceService["setVisualExpression"].Call(arg0_setOrNot);
        }

        /// <summary>Sets the LED animation mode</summary>
		/// <param name="arg0_mode">animation mode: 0: deactivated, 1: eyes, 2: ears, 3: full</param>
		/// <returns></returns>
        public void SetVisualExpressionMode(int arg0_mode)
        {
            SourceService["setVisualExpressionMode"].Call(arg0_mode);
        }

        /// <summary>Enables or disables the playing of sounds indicating the state of the recognition engine. If this option is enabled, a sound is played at the beginning of the recognition process (after a call to the subscribe method), and a sound is played when the user call the unsubscribe method</summary>
		/// <param name="arg0_setOrNot">Enable (true) or disable it (false).</param>
		/// <returns></returns>
        public void SetAudioExpression(bool arg0_setOrNot)
        {
            SourceService["setAudioExpression"].Call(arg0_setOrNot);
        }

        /// <summary>To check if audio expression is enabled or disabled.</summary>
		/// <returns></returns>
        public bool GetAudioExpression()
        {
            return (bool)SourceService["getAudioExpression"].Call();
        }

        /// <summary>Sets the language used by the speech recognition engine. The list of the available languages can be collected through the getAvailableLanguages method. If you want to set a language as the default language (loading automatically at module launch), please refer to the web page of the robot.</summary>
		/// <param name="arg0_languageName">Name of the language in English.</param>
		/// <returns></returns>
        public void SetLanguage(string arg0_languageName)
        {
            SourceService["setLanguage"].Call(arg0_languageName);
        }

        /// <summary>Set a language as the default language for the Speech Recognition engine</summary>
		/// <param name="arg0_pLanguage">The language among those available on your robot as a String</param>
		/// <returns></returns>
        public void _setDefaultLanguage(string arg0_pLanguage)
        {
            SourceService["_setDefaultLanguage"].Call(arg0_pLanguage);
        }

        /// <summary>Returns the current language used by the speech recognition system.</summary>
		/// <returns>Current language used by the speech recognition engine.</returns>
        public string GetLanguage()
        {
            return (string)SourceService["getLanguage"].Call();
        }

        /// <summary>Returns the list of the languages installed on the system.</summary>
		/// <returns>Array of strings that contains the list of the installed languages.</returns>
        public string[] GetAvailableLanguages()
        {
            return (string[])SourceService["getAvailableLanguages"].Call();
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, float arg1_paramValue)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Sets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be set.The parameters that can be set and the corresponding values are:&quot;Sensitivity&quot; - Values : range is [0.0; 1.0].&quot;Timeout&quot; - Values :  default values 3000 ms. Timeout for the remote recognition&quot;MinimumTrailingSilence&quot; : Values : 0 (no) or 1 (yes) - Applies a High-Pass filter on the input signal - default value is 0.</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <param name="arg1_paramValue">Value of the parameter.</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, bool arg1_paramValue)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Gets a parameter of the speech recognition engine. Note that when the ASR engine language is set to Chinese, no parameter can be retrieved</summary>
		/// <param name="arg0_paramName">Name of the parameter.</param>
		/// <returns>Value of the parameter.</returns>
        public float GetParameter(string arg0_paramName)
        {
            return (float)SourceService["getParameter"].Call(arg0_paramName);
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <returns></returns>
        public void SetWordListAsVocabulary(IEnumerable<string> arg0_vocabulary)
        {
            SourceService["setWordListAsVocabulary"].Call(QiList.Create(arg0_vocabulary));
        }

        /// <summary>Sets the list of words (vocabulary) that should be recognized by the speech recognition engine.</summary>
		/// <param name="arg0_vocabulary">List of words that should be recognized</param>
		/// <param name="arg1_enabledWordSpotting">If disabled, the engine expects to hear one of the specified words, nothing more, nothing less. If enabled, the specified words can be pronounced in the middle of a whole speech stream, the engine will try to spot them.</param>
		/// <returns></returns>
        public void SetVocabulary(IEnumerable<string> arg0_vocabulary, bool arg1_enabledWordSpotting)
        {
            SourceService["setVocabulary"].Call(QiList.Create(arg0_vocabulary), arg1_enabledWordSpotting);
        }

        /// <summary>Stops and restarts the speech recognition engine according to the input parameter This can be used to add contexts, activate or deactivate rules of a contex, add a words to a slot.</summary>
		/// <param name="arg0_pause">Boolean to enable or disable pause of the speech recognition engine.</param>
		/// <returns></returns>
        public void Pause(bool arg0_pause)
        {
            SourceService["pause"].Call(arg0_pause);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void Compile(string arg0, string arg1, string arg2)
        {
            SourceService["compile"].Call(arg0, arg1, arg2);
        }

        /// <summary>Add a context from a LCF file.</summary>
		/// <param name="arg0_pathToLCFFile">Path to a LCF file. This LCF file contains the set of rules that should be recognized by the speech recognition engine.</param>
		/// <param name="arg1_contextName">Name of the context of your choice.</param>
		/// <returns></returns>
        public void AddContext(string arg0_pathToLCFFile, string arg1_contextName)
        {
            SourceService["addContext"].Call(arg0_pathToLCFFile, arg1_contextName);
        }

        /// <summary>Remove one context from the speech recognition engine.</summary>
		/// <param name="arg0_contextName">Name of the context to remove from the speech recognition engine.</param>
		/// <returns></returns>
        public void RemoveContext(string arg0_contextName)
        {
            SourceService["removeContext"].Call(arg0_contextName);
        }

        /// <summary>Remove all contexts from the speech recognition engine.</summary>
		/// <returns></returns>
        public void RemoveAllContext()
        {
            SourceService["removeAllContext"].Call();
        }

        /// <summary>Disable current contexts of the speech recognition engine and save them in a  stack.</summary>
		/// <returns></returns>
        public void PushContexts()
        {
            SourceService["pushContexts"].Call();
        }

        /// <summary>Disable current contexts and restore saved contexts of the speech recognition engine.</summary>
		/// <returns></returns>
        public void PopContexts()
        {
            SourceService["popContexts"].Call();
        }

        /// <summary>Save current context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which to save</param>
		/// <returns></returns>
        public bool SaveContextSet(string arg0_saveName)
        {
            return (bool)SourceService["saveContextSet"].Call(arg0_saveName);
        }

        /// <summary>Load a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public void LoadContextSet(string arg0_saveName)
        {
            SourceService["loadContextSet"].Call(arg0_saveName);
        }

        /// <summary>Erase a saved context set of the speech recognition engine</summary>
		/// <param name="arg0_saveName">Name under which the context set is saved</param>
		/// <returns></returns>
        public void EraseContextSet(string arg0_saveName)
        {
            SourceService["eraseContextSet"].Call(arg0_saveName);
        }

        /// <summary>Activate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to activate.</param>
		/// <returns></returns>
        public void ActivateRule(string arg0_contextName, string arg1_ruleName)
        {
            SourceService["activateRule"].Call(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Deactivate a rule contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_ruleName">Name of the rule to deactivate.</param>
		/// <returns></returns>
        public void DeactivateRule(string arg0_contextName, string arg1_ruleName)
        {
            SourceService["deactivateRule"].Call(arg0_contextName, arg1_ruleName);
        }

        /// <summary>Activate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public void ActivateAllRules(string arg0_contextName)
        {
            SourceService["activateAllRules"].Call(arg0_contextName);
        }

        /// <summary>Deactivate all rules contained in the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <returns></returns>
        public void DeactivateAllRules(string arg0_contextName)
        {
            SourceService["deactivateAllRules"].Call(arg0_contextName);
        }

        /// <summary>Set the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to change</param>
		/// <param name="arg2_value">New parameter value</param>
		/// <returns></returns>
        public void SetContextParam(string arg0_contextName, string arg1_paramName, float arg2_value)
        {
            SourceService["setContextParam"].Call(arg0_contextName, arg1_paramName, arg2_value);
        }

        /// <summary>Get the given parameter for the specified context.</summary>
		/// <param name="arg0_contextName">Name of the context</param>
		/// <param name="arg1_paramName">Name of the parameter to get</param>
		/// <returns>Value of the fetched parameter</returns>
        public float GetContextParam(string arg0_contextName, string arg1_paramName)
        {
            return (float)SourceService["getContextParam"].Call(arg0_contextName, arg1_paramName);
        }

        /// <summary>Add a list of words in a slot. A slot is a part of a context which can be modified. You can add a list of words that should be recognized by the speech recognition engine</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <param name="arg2_wordList">List of words to insert in the slot.</param>
		/// <returns></returns>
        public void AddWordListToSlot(string arg0_contextName, string arg1_slotName, IEnumerable<string> arg2_wordList)
        {
            SourceService["addWordListToSlot"].Call(arg0_contextName, arg1_slotName, QiList.Create(arg2_wordList));
        }

        /// <summary>Remove all words from a slot.</summary>
		/// <param name="arg0_contextName">Name of the context to modify.</param>
		/// <param name="arg1_slotName">Name of the slot to modify.</param>
		/// <returns></returns>
        public void RemoveWordListFromSlot(string arg0_contextName, string arg1_slotName)
        {
            SourceService["removeWordListFromSlot"].Call(arg0_contextName, arg1_slotName);
        }

        /// <summary>Get all rules contained for a specific context.</summary>
		/// <param name="arg0_contextName">Name of the context to analyze.</param>
		/// <param name="arg1_typeName">Type of the required rules.</param>
		/// <returns></returns>
        public string[] GetRules(string arg0_contextName, string arg1_typeName)
        {
            return (string[])SourceService["getRules"].Call(arg0_contextName, arg1_typeName);
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns>Boolean indicating whether free speech to text is available for the current language</returns>
        public bool _isFreeSpeechToTextAvailable()
        {
            return (bool)SourceService["_isFreeSpeechToTextAvailable"].Call();
        }

        /// <summary>Enable free speech to text.</summary>
		/// <returns></returns>
        public void _enableFreeSpeechToText()
        {
            SourceService["_enableFreeSpeechToText"].Call();
        }

        /// <summary>Disable free speech to text.</summary>
		/// <returns></returns>
        public void _disableFreeSpeechToText()
        {
            SourceService["_disableFreeSpeechToText"].Call();
        }

        /// <summary>Get a remote consumption speed change recommendation.</summary>
		/// <returns>Integer indicating whether to increase, decrease or keep the remote consumption speed</returns>
        public int _remoteConsumptionOk()
        {
            return (int)SourceService["_remoteConsumptionOk"].Call();
        }

        /// <summary>Loads the vocabulary to recognized contained in a .lxd file. This method is not available with the ASR engine language set to Chinese. For more informations see the red documentation</summary>
		/// <param name="arg0_vocabularyFile">Name of the lxd file containing the vocabulary</param>
		/// <returns></returns>
        public void LoadVocabulary(string arg0_vocabularyFile)
        {
            SourceService["loadVocabulary"].Call(arg0_vocabularyFile);
        }

        /// <summary>reload the engine if new application installed is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _naoStoreApplicationInstalled(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_naoStoreApplicationInstalled"].Call(arg0, arg1, arg2);
        }

        /// <summary>reload the engine if application uninstalled is a language</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _naoStoreApplicationUninstalled(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_naoStoreApplicationUninstalled"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _systemSoundSetChanged()
        {
            SourceService["_systemSoundSetChanged"].Call();
        }

        /// <summary>Set the ASR_Recognizer thread to real time priority. Be careful this could change the scheduling of the robot.</summary>
		/// <param name="arg0_isRealTime">True or False to enable or disable real time priority.</param>
		/// <returns></returns>
        public void _enableRealTimeThread(bool arg0_isRealTime)
        {
            SourceService["_enableRealTimeThread"].Call(arg0_isRealTime);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _silentNextBipOn()
        {
            SourceService["_silentNextBipOn"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _silentNextBipOff()
        {
            SourceService["_silentNextBipOff"].Call();
        }

        /// <summary>Enable audio dumps.</summary>
		/// <param name="arg0_path">Path to write the dump files to. Pass an empty string to deactivate audio logging</param>
		/// <returns></returns>
        public void _enableAudioLogging(string arg0_path)
        {
            SourceService["_enableAudioLogging"].Call(arg0_path);
        }

        /// <summary>Enable beamformer.</summary>
		/// <returns></returns>
        public void _enableBeamformer()
        {
            SourceService["_enableBeamformer"].Call();
        }

        /// <summary>Disable beamformer.</summary>
		/// <returns></returns>
        public void _disableBeamformer()
        {
            SourceService["_disableBeamformer"].Call();
        }

        /// <summary>Get beamformer status.</summary>
		/// <returns>Whether the beamformer is enabled or not</returns>
        public bool _beamformerEnabled()
        {
            return (bool)SourceService["_beamformerEnabled"].Call();
        }

        /// <summary>get vocon version</summary>
		/// <returns>Version</returns>
        public string _getVersion()
        {
            return (string)SourceService["_getVersion"].Call();
        }

    }
}