using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module embeds a speech synthetizer whose role is to convert text commands into sound waves that are then either sent to Nao's loudspeakers or written into a file. This service supports several languages and some parameters of the synthetizer can be tuned to change each language's synthetic voice.</summary>
    public class ALTextToSpeech
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALTextToSpeech(QiSession session)
        {
            SourceService = session.GetService("ALTextToSpeech");
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

        /// <summary>Performs the text-to-speech operations : it takes a std::string as input and outputs a sound in both speakers. String encoding must be UTF8.</summary>
		/// <param name="arg0_stringToSay">Text to say, encoded in UTF-8.</param>
		/// <returns></returns>
        public void Say(string arg0_stringToSay)
        {
            SourceService["say"].Call(arg0_stringToSay);
        }

        /// <summary>Performs the text-to-speech operations in a specific language: it takes a std::string as input and outputs a sound in both speakers. String encoding must be UTF8. Once the text is said, the language is set back to its initial value.</summary>
		/// <param name="arg0_stringToSay">Text to say, encoded in UTF-8.</param>
		/// <param name="arg1_language">Language used to say the text.</param>
		/// <returns></returns>
        public void Say(string arg0_stringToSay, string arg1_language)
        {
            SourceService["say"].Call(arg0_stringToSay, arg1_language);
        }

        /// <summary>Performs the text-to-speech operations: it takes a std::string as input and outputs the corresponding audio signal in the specified file.</summary>
		/// <param name="arg0_pStringToSay">Text to say, encoded in UTF-8.</param>
		/// <param name="arg1_pFileName">RAW file where to store the generated signal. The signal is encoded with a sample rate of 22050Hz, format S16_LE, 2 channels.</param>
		/// <returns>Id of the task. Can be used to interrupt it.</returns>
        public void SayToFile(string arg0_pStringToSay, string arg1_pFileName)
        {
            SourceService["sayToFile"].Call(arg0_pStringToSay, arg1_pFileName);
        }

        /// <summary>This method stops the current and all the pending tasks immediately.</summary>
		/// <returns></returns>
        public void StopAll()
        {
            SourceService["stopAll"].Call();
        }

        /// <summary>Changes the language used by the Text-to-Speech engine. It automatically changes the voice used since each of them is related to a unique language. If you want that change to take effect automatically after reboot of your robot, refer to the robot web page (setting page).</summary>
		/// <param name="arg0_pLanguage">Language name. Must belong to the languages available in TTS (can be obtained with the getAvailableLanguages method).  It should be an identifier std::string.</param>
		/// <returns></returns>
        public void SetLanguage(string arg0_pLanguage)
        {
            SourceService["setLanguage"].Call(arg0_pLanguage);
        }

        /// <summary>Returns the language currently used by the text-to-speech engine.</summary>
		/// <returns>Language of the current voice.</returns>
        public string GetLanguage()
        {
            return (string)SourceService["getLanguage"].Call();
        }

        /// <summary>Outputs the languages installed on the system.</summary>
		/// <returns>Array of std::string that contains the languages installed on the system.</returns>
        public string[] GetAvailableLanguages()
        {
            return (string[])SourceService["getAvailableLanguages"].Call();
        }

        /// <summary>Outputs all the languages supported (may be installed or not).</summary>
		/// <returns>Array of std::string that contains all the supported languages (may be installed or not).</returns>
        public string[] GetSupportedLanguages()
        {
            return (string[])SourceService["getSupportedLanguages"].Call();
        }

        /// <summary>Changes the parameters of the voice. For now, it is only possible to reset the voice speed.</summary>
		/// <returns>(int) &gt;= 0 if successful, negative error code if failed Vincent : pas sûr que cette fonction balance un truc en sortie</returns>
        public void ResetSpeed()
        {
            SourceService["resetSpeed"].Call();
        }

        /// <summary>Changes the parameters of the voice. The available parameters are:  	 pitchShift: applies a pitch shifting to the voice. The value indicates the ratio between the new fundamental frequencies and the old ones (examples: 2.0: an octave above, 1.5: a quint above). Correct range is (1.0 -- 4), or 0 to disable effect. 	 doubleVoice: adds a second voice to the first one. The value indicates the ratio between the second voice fundamental frequency and the first one. Correct range is (1.0 -- 4), or 0 to disable effect  	 doubleVoiceLevel: the corresponding value is the level of the double voice (1.0: equal to the main voice one). Correct range is (0 -- 4).  	 doubleVoiceTimeShift: the corresponding value is the delay between the double voice and the main one. Correct range is (0 -- 0.5)  If the effect value is not available, the effect parameter remains unchanged.</summary>
		/// <param name="arg0_pEffectName">Name of the parameter.</param>
		/// <param name="arg1_pEffectValue">Value of the parameter.</param>
		/// <returns>(int) &gt;= 0 if successful, negative error code if failed Vincent : pas sûr que cette fonction balance un truc en sortie</returns>
        public void SetParameter(string arg0_pEffectName, float arg1_pEffectValue)
        {
            SourceService["setParameter"].Call(arg0_pEffectName, arg1_pEffectValue);
        }

        /// <summary>Returns the value of one of the voice parameters. The available parameters are: &quot;pitchShift&quot;, &quot;doubleVoice&quot;,&quot;doubleVoiceLevel&quot; and &quot;doubleVoiceTimeShift&quot;</summary>
		/// <param name="arg0_pParameterName">Name of the parameter.</param>
		/// <returns>Value of the specified parameter</returns>
        public float GetParameter(string arg0_pParameterName)
        {
            return (float)SourceService["getParameter"].Call(arg0_pParameterName);
        }

        /// <summary>Changes the voice used by the text-to-speech engine. The voice identifier must belong to the installed voices, that can be listed using the 'getAvailableVoices' method. If the voice is not available, it remains unchanged. No exception is thrown in this case. For the time being, only two voices are available by default : Kenny22Enhanced (English voice) and Julie22Enhanced (French voice)</summary>
		/// <param name="arg0_pVoiceID">The voice (as a std::string).</param>
		/// <returns></returns>
        public void SetVoice(string arg0_pVoiceID)
        {
            SourceService["setVoice"].Call(arg0_pVoiceID);
        }

        /// <summary>Returns the voice currently used by the text-to-speech engine.</summary>
		/// <returns>Name of the current voice</returns>
        public string GetVoice()
        {
            return (string)SourceService["getVoice"].Call();
        }

        /// <summary>Outputs the available voices. The returned list contains the voice IDs.</summary>
		/// <returns> Array of std::string containing the voices installed on the system.</returns>
        public string[] GetAvailableVoices()
        {
            return (string[])SourceService["getAvailableVoices"].Call();
        }

        /// <summary>Sets the volume of text-to-speech output.</summary>
		/// <param name="arg0_volume">Volume (between 0.0 and 1.0).</param>
		/// <returns></returns>
        public void SetVolume(float arg0_volume)
        {
            SourceService["setVolume"].Call(arg0_volume);
        }

        /// <summary>Fetches the current volume the text to speech.</summary>
		/// <returns>Volume (integer between 0 and 100).</returns>
        public float GetVolume()
        {
            return (float)SourceService["getVolume"].Call();
        }

        /// <summary>Get the locale associate to the current language.</summary>
		/// <returns>A string with xx_XX format (region_country)</returns>
        public string Locale()
        {
            return (string)SourceService["locale"].Call();
        }

        /// <summary>Loads a set of voice parameters defined in a xml file contained in the preferences folder.The name of the xml file must begin with ALTextToSpeech_Voice_ </summary>
		/// <param name="arg0_pPreferenceName">Name of the voice preference.</param>
		/// <returns></returns>
        public void LoadVoicePreference(string arg0_pPreferenceName)
        {
            SourceService["loadVoicePreference"].Call(arg0_pPreferenceName);
        }

        /// <summary>Sets a language as the default language for the synthesis engine</summary>
		/// <param name="arg0_Language">The language among those available on your robot as a String</param>
		/// <returns></returns>
        public void _setDefaultLanguage(string arg0_Language)
        {
            SourceService["_setDefaultLanguage"].Call(arg0_Language);
        }

        /// <summary>Sets a voice as the default voice for the corresponding language</summary>
		/// <param name="arg0_Language">The language among those available on your robot as a String</param>
		/// <param name="arg1_Voice">The voice among those available on your robot as a String</param>
		/// <returns></returns>
        public void SetLanguageDefaultVoice(string arg0_Language, string arg1_Voice)
        {
            SourceService["setLanguageDefaultVoice"].Call(arg0_Language, arg1_Voice);
        }

        /// <summary>Sets the default voice for the current language, if there's one.</summary>
		/// <returns></returns>
        public void _setDefaultVoice()
        {
            SourceService["_setDefaultVoice"].Call();
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

        /// <summary>Pause the current synthesis</summary>
		/// <returns></returns>
        public void _pause()
        {
            SourceService["_pause"].Call();
        }

        /// <summary>Resume the current synthesis</summary>
		/// <returns></returns>
        public void _resume()
        {
            SourceService["_resume"].Call();
        }

        /// <summary>Enables the filtering of audio output</summary>
		/// <param name="arg0_enable">activate or not</param>
		/// <returns></returns>
        public void _enableFilter(bool arg0_enable)
        {
            SourceService["_enableFilter"].Call(arg0_enable);
        }

        /// <summary>Load an effect on the voice.</summary>
		/// <param name="arg0_effectPath">path to the file of the effect to load.</param>
		/// <returns></returns>
        public void _loadEffect(string arg0_effectPath)
        {
            SourceService["_loadEffect"].Call(arg0_effectPath);
        }

        /// <summary>Enables the filtering of audio output</summary>
		/// <param name="arg0_effectName">name of the effect</param>
		/// <param name="arg1_enable">activate or not</param>
		/// <returns></returns>
        public void _applyEffect(string arg0_effectName, bool arg1_enable)
        {
            SourceService["_applyEffect"].Call(arg0_effectName, arg1_enable);
        }

        /// <summary>Logs info about the current state of the TTS.</summary>
		/// <returns></returns>
        public void _diagnosis()
        {
            SourceService["_diagnosis"].Call();
        }

        /// <summary>Logs voice settings.</summary>
		/// <returns></returns>
        public void _showVoiceSettings()
        {
            SourceService["_showVoiceSettings"].Call();
        }

        /// <summary>Shows the Dictionary.</summary>
		/// <returns></returns>
        public void ShowDictionary()
        {
            SourceService["showDictionary"].Call();
        }

        /// <summary>Reset ALTextToSpeech to his default state.</summary>
		/// <returns></returns>
        public void Reset()
        {
            SourceService["reset"].Call();
        }

        /// <summary>Unload the dictionary.</summary>
		/// <returns></returns>
        public void _unloadDictionary()
        {
            SourceService["_unloadDictionary"].Call();
        }

        /// <summary>Unload the dictionary.</summary>
		/// <param name="arg0_word">the word you wish to delete, does not have to be in japanese.</param>
		/// <param name="arg1"></param>
		/// <returns>bool: true if succeeded, false if failed</returns>
        public bool DeleteFromDictionary(string arg0_word, string arg1)
        {
            return (bool)SourceService["deleteFromDictionary"].Call(arg0_word, arg1);
        }

        /// <summary>Unload the dictionary.</summary>
		/// <param name="arg0_word">the word you wish to delete, does not have to be in japanese.</param>
		/// <returns>bool: true if succeeded, false if failed</returns>
        public bool DeleteFromDictionary(string arg0_word)
        {
            return (bool)SourceService["deleteFromDictionary"].Call(arg0_word);
        }

        /// <summary>Add a word to the library</summary>
		/// <param name="arg0_type">the type of word you wish to insert, does not have to be in japanese.</param>
		/// <param name="arg1_word">the word you wish to insert, does not have to be in japanese.</param>
		/// <param name="arg2_priority">the priority of the word.</param>
		/// <param name="arg3_phonetic">the phonetic pronouciation in KATAKANA.</param>
		/// <param name="arg4_accent">syllabus and accentuation</param>
		/// <returns>bool: true if succeeded, false if failed</returns>
        public bool AddToDictionary(string arg0_type, string arg1_word, string arg2_priority, string arg3_phonetic, string arg4_accent)
        {
            return (bool)SourceService["addToDictionary"].Call(arg0_type, arg1_word, arg2_priority, arg3_phonetic, arg4_accent);
        }

        /// <summary>Add a word to the library</summary>
		/// <param name="arg0_text">the text you wish to insert.</param>
		/// <param name="arg1_toReplace">text to replace.</param>
		/// <returns>bool: true if succeeded, false if failed</returns>
        public bool AddToDictionary(string arg0_text, string arg1_toReplace)
        {
            return (bool)SourceService["addToDictionary"].Call(arg0_text, arg1_toReplace);
        }

        /// <summary>TODO</summary>
		/// <returns></returns>
        public void _loadDictionary()
        {
            SourceService["_loadDictionary"].Call();
        }

    }
}