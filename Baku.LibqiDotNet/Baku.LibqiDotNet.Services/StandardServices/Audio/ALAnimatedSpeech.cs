using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>The Animated Speech module makes NAO interpret a text annotated with behaviors.</summary>
    public class ALAnimatedSpeech
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALAnimatedSpeech(QiSession session)
        {
            SourceService = session.GetService("ALAnimatedSpeech");
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

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <returns></returns>
        public void Say(string arg0_text)
        {
            SourceService["say"].Call(arg0_text);
        }

        /// <summary>Say the annotated text given in parameter and animate it with animations inserted in the text.</summary>
		/// <param name="arg0_text">An annotated text (for example: &quot;Hello. ^start(Hey_1) My name is NAO&quot;).</param>
		/// <param name="arg1_configuration">The animated speech configuration.</param>
		/// <returns></returns>
        public void Say(string arg0_text, QiAnyValue arg1_configuration)
        {
            SourceService["say"].Call(arg0_text, arg1_configuration);
        }

        /// <summary>Reset the Animated Speech configuration.</summary>
		/// <returns></returns>
        public void _reset()
        {
            SourceService["_reset"].Call();
        }

        /// <summary>Stop all the speeches.</summary>
		/// <param name="arg0_blocking">If this method wait for the end of the speeches.</param>
		/// <returns></returns>
        public void _stopAll(bool arg0_blocking)
        {
            SourceService["_stopAll"].Call(arg0_blocking);
        }

        /// <summary>Know if animated speech is running.</summary>
		/// <returns>True, if animated speech is running, False otherwise.</returns>
        public bool _isRunning()
        {
            return (bool)SourceService["_isRunning"].Call();
        }

        /// <summary>DEPRECATED since 1.18: use setBodyLanguageMode instead.Enable or disable the automatic body talk on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetBodyTalkEnabled(bool arg0_enable)
        {
            SourceService["setBodyTalkEnabled"].Call(arg0_enable);
        }

        /// <summary>DEPRECATED since 1.22: use setBodyLanguageMode instead.Enable or disable the automatic body language on the speech.If it is enabled, anywhere you have not annotate your text with animation,the robot will fill the gap with automatically calculated gestures.If it is disabled, the robot will move only where you annotate it withanimations.</summary>
		/// <param name="arg0_enable">The boolean value: true to enable, false to disable.</param>
		/// <returns></returns>
        public void SetBodyLanguageEnabled(bool arg0_enable)
        {
            SourceService["setBodyLanguageEnabled"].Call(arg0_enable);
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_stringBodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public void SetBodyLanguageModeFromStr(string arg0_stringBodyLanguageMode)
        {
            SourceService["setBodyLanguageModeFromStr"].Call(arg0_stringBodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <param name="arg0_bodyLanguageMode">The choosen body language mode.</param>
		/// <returns></returns>
        public void SetBodyLanguageMode(uint arg0_bodyLanguageMode)
        {
            SourceService["setBodyLanguageMode"].Call(arg0_bodyLanguageMode);
        }

        /// <summary>Set the current body language mode.3 modes exist: &quot;disabled&quot;, &quot;random&quot; and &quot;contextual&quot;(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public string GetBodyLanguageModeToStr()
        {
            return (string)SourceService["getBodyLanguageModeToStr"].Call();
        }

        /// <summary>Set the current body language mode.3 modes exist: SPEAKINGMOVEMENT_MODE_DISABLED,SPEAKINGMOVEMENT_MODE_RANDOM and SPEAKINGMOVEMENT_MODE_CONTEXTUAL(see BodyLanguageMode enum for more details)</summary>
		/// <returns>The current body language mode.</returns>
        public uint GetBodyLanguageMode()
        {
            return (uint)SourceService["getBodyLanguageMode"].Call();
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareAnimationsPackage instead.Add a new package that contains animations.</summary>
		/// <param name="arg0_animationsPackage">The new package that contains animations.</param>
		/// <returns></returns>
        public void DeclareAnimationsPackage(string arg0_animationsPackage)
        {
            SourceService["declareAnimationsPackage"].Call(arg0_animationsPackage);
        }

        /// <summary>Change the pause's time before the speech.</summary>
		/// <param name="arg0_pause">The pause's time in milliseconds before the speech.</param>
		/// <returns></returns>
        public void _setMSPauseBeforeSpeech(int arg0_pause)
        {
            SourceService["_setMSPauseBeforeSpeech"].Call(arg0_pause);
        }

        /// <summary>Get the pause's time before the speech.</summary>
		/// <returns>The pause's time in milliseconds before the speech.</returns>
        public uint _getMSPauseBeforeSpeech()
        {
            return (uint)SourceService["_getMSPauseBeforeSpeech"].Call();
        }

        /// <summary>If we need to check the execution times.</summary>
		/// <returns>True, if we need to check the execution times, False otherwise.</returns>
        public bool _isCheckExecutionTimesEnabled()
        {
            return (bool)SourceService["_isCheckExecutionTimesEnabled"].Call();
        }

        /// <summary>Set if we need to check the execution times.</summary>
		/// <param name="arg0_pause">If we need to check the execution times.</param>
		/// <returns></returns>
        public void _setCheckExecutionTimes(bool arg0_pause)
        {
            SourceService["_setCheckExecutionTimes"].Call(arg0_pause);
        }

        /// <summary>Add some new links between tags and words.</summary>
		/// <param name="arg0_tagsToWords">Map of tags to words.</param>
		/// <returns></returns>
        public void AddTagsToWords(QiAnyValue arg0_tagsToWords)
        {
            SourceService["addTagsToWords"].Call(arg0_tagsToWords);
        }

        /// <summary>DEPRECATED since 2.2: use ALAnimationPlayer.declareTagForAnimations instead.Declare some tags with the associated animations.</summary>
		/// <param name="arg0_tagsToAnimations">Map of Tags to Animations.</param>
		/// <returns></returns>
        public void DeclareTagForAnimations(QiAnyValue arg0_tagsToAnimations)
        {
            SourceService["declareTagForAnimations"].Call(arg0_tagsToAnimations);
        }

        /// <summary>Print many debug informations about the current state of animated speech.</summary>
		/// <returns></returns>
        public void _diagnosis()
        {
            SourceService["_diagnosis"].Call();
        }

        /// <summary>DEPRECATED since 1.18: use getBodyLanguageMode instead.Indicate if the body talk is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public bool IsBodyTalkEnabled()
        {
            return (bool)SourceService["isBodyTalkEnabled"].Call();
        }

        /// <summary>DEPRECATED since 1.22: use getBodyLanguageMode instead.Indicate if the body language is enabled or not.</summary>
		/// <returns>The boolean value: true means it is enabled, false means it is disabled.</returns>
        public bool IsBodyLanguageEnabled()
        {
            return (bool)SourceService["isBodyLanguageEnabled"].Call();
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get tags found on installed animations which are in &quot;animation library&quot;.</summary>
		/// <returns>The list of tags found.</returns>
        public string[] _getTagList()
        {
            return (string[])SourceService["_getTagList"].Call();
        }

        /// <summary>DEPRECATED since 2.2: will be remove soon.Get all installed animations for a tag. Currently: animations = &quot;behaviors of the animation library.&quot;</summary>
		/// <param name="arg0_tag">A tag to filter the list of animations with.</param>
		/// <returns>The animation list.</returns>
        public string[] _getAnimationsByTag(string arg0_tag)
        {
            return (string[])SourceService["_getAnimationsByTag"].Call(arg0_tag);
        }

        /// <summary>Callback for ALMemory subscription for speech bookmark tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _speechBookMarkCallback(string arg0_memoryKey, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_speechBookMarkCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Method called by the tts when &quot;mrkpause&quot; bookmark is reached.This method is blocking until the action is finish.</summary>
		/// <param name="arg0_pBookmark">Id of the bookmark.</param>
		/// <returns></returns>
        public void _mrkpauseCallback(uint arg0_pBookmark)
        {
            SourceService["_mrkpauseCallback"].Call(arg0_pBookmark);
        }

        /// <summary>Callback for ALMemory subscription for speech status tracking.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _speechStatusCallback(string arg0_memoryKey, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_speechStatusCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

        /// <summary>Callback for ALMemory subscription to postureFamilyChanged.</summary>
		/// <param name="arg0_memoryKey">The subscribed memory key which changed.</param>
		/// <param name="arg1_value">The new value of the memory key.</param>
		/// <param name="arg2_message">The message that comes with the callback.</param>
		/// <returns></returns>
        public void _postureFamilyChangedCallback(string arg0_memoryKey, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_postureFamilyChangedCallback"].Call(arg0_memoryKey, arg1_value, arg2_message);
        }

    }
}