using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Frame manager is used to play choregraphe projects in naoqi. It needs Choregraphe projects in input and will return an ID for each project. It can also only read a given box/timeline in a complex behavior.</summary>
    public class ALFrameManager
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALFrameManager(QiSession session)
        {
            SourceService = session.GetService("ALFrameManager");
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

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot. DEPRECATED since 2.3</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_behName"></param>
		/// <returns>return a unique identifier for the created box (the box URI), that can be used by playBehavior</returns>
        public string NewBehaviorFromFile(string arg0_xmlFilePath, string arg1_behName)
        {
            return (string)SourceService["newBehaviorFromFile"].Call(arg0_xmlFilePath, arg1_behName);
        }

        /// <summary>Creates a new behavior, from a box found in an xml file stored in the robot.</summary>
		/// <param name="arg0_packageDir"> the base directory of the behavior's package, eg: &quot;/home/myApp&quot;.</param>
		/// <param name="arg1_behaviorPath">the relative path of the behavior inside the package, eg: &quot;/behavior_1/behavior.xar&quot;.</param>
		/// <param name="arg2_behName"></param>
		/// <returns>return a unique identifier for the created box, that can be used by playBehavior</returns>
        public string CreateBehavior(string arg0_packageDir, string arg1_behaviorPath, string arg2_behName)
        {
            return (string)SourceService["createBehavior"].Call(arg0_packageDir, arg1_behaviorPath, arg2_behName);
        }

        /// <summary>Creates a new behavior, from the current Choregraphe behavior 0(uploaded to /tmp/currentChoregrapheBehavior/behavior.xar). DEPRECATED since 1.14</summary>
		/// <returns>return a unique identifier for the created behavior (the box URI)</returns>
        public string NewBehaviorFromChoregraphe()
        {
            return (string)SourceService["newBehaviorFromChoregraphe"].Call();
        }

        /// <summary>It will play a behavior and block until the behavior is finished. Note that it can block forever if the behavior output is never called.</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void CompleteBehavior(string arg0_id)
        {
            SourceService["completeBehavior"].Call(arg0_id);
        }

        /// <summary>Deletes a behavior (meaning a box). Stop the whole behavior contained in this box first.</summary>
		/// <param name="arg0_id">The id of the box to delete (the box URI).</param>
		/// <returns></returns>
        public void DeleteBehavior(string arg0_id)
        {
            SourceService["deleteBehavior"].Call(arg0_id);
        }

        /// <summary>Starts a behavior</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void PlayBehavior(string arg0_id)
        {
            SourceService["playBehavior"].Call(arg0_id);
        }

        /// <summary>Exit the reading of a timeline contained in a given box</summary>
		/// <param name="arg0_id">The id of the box (the box URI).</param>
		/// <returns></returns>
        public void ExitBehavior(string arg0_id)
        {
            SourceService["exitBehavior"].Call(arg0_id);
        }

        /// <summary>Tells whether the behavior is running</summary>
		/// <param name="arg0_id">The id of the behavior to check (The URI of the root box).</param>
		/// <returns>True if the behavior is running, false otherwise</returns>
        public bool IsBehaviorRunning(string arg0_id)
        {
            return (bool)SourceService["isBehaviorRunning"].Call(arg0_id);
        }

        /// <summary>Stop playing any behavior in FrameManager, and delete all of them.</summary>
		/// <returns></returns>
        public void CleanBehaviors()
        {
            SourceService["cleanBehaviors"].Call();
        }

        /// <summary>Returns a playing behavior absolute path.</summary>
		/// <param name="arg0_id">The id of the behavior (The URI of the root box).</param>
		/// <returns>Returns the absolute path of given behavior.</returns>
        public string GetBehaviorPath(string arg0_id)
        {
            return (string)SourceService["getBehaviorPath"].Call(arg0_id);
        }

        /// <summary>Creates a timeline.</summary>
		/// <param name="arg0_timelineContent">The timeline content (in XML format).</param>
		/// <returns>return a unique identifier for the created box that contains the timeline. You must call deleteBehavior on it at some point. DEPRECATED since 1.14</returns>
        public string CreateTimeline(string arg0_timelineContent)
        {
            return (string)SourceService["createTimeline"].Call(arg0_timelineContent);
        }

        /// <summary>Starts playing a timeline contained in a given box. If the box is a flow diagram, it will look for the first onStart input of type Bang, and stimulate it ! DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public void PlayTimeline(string arg0_id)
        {
            SourceService["playTimeline"].Call(arg0_id);
        }

        /// <summary>Stops playing a timeline contained in a given box, at the current frame. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns></returns>
        public void StopTimeline(string arg0_id)
        {
            SourceService["stopTimeline"].Call(arg0_id);
        }

        /// <summary>Sets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <param name="arg1_fps">The FPS to set.</param>
		/// <returns></returns>
        public void SetTimelineFps(string arg0_id, int arg1_fps)
        {
            SourceService["setTimelineFps"].Call(arg0_id, arg1_fps);
        }

        /// <summary>Gets the FPS of a given timeline. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the timeline (the URI of the box).</param>
		/// <returns>Returns the timeline's FPS.</returns>
        public int GetTimelineFps(string arg0_id)
        {
            return (int)SourceService["getTimelineFps"].Call(arg0_id);
        }

        /// <summary>Returns in seconds, the duration of a given movement stored in a box. Returns 0 if the behavior has no motion layers.  DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box (the URI of the box).</param>
		/// <returns>Returns the time in seconds.</returns>
        public float GetMotionLength(string arg0_id)
        {
            return (float)SourceService["getMotionLength"].Call(arg0_id);
        }

        /// <summary>List all behaviors currently handled by the frame manager.</summary>
		/// <returns>a set listing all behavior ids</returns>
        public string[] Behaviors()
        {
            return (string[])SourceService["behaviors"].Call();
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public void GotoAndStop(string arg0_id, string arg1_frame)
        {
            SourceService["gotoAndStop"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and pause. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public void GotoAndStop(string arg0_id, int arg1_frame)
        {
            SourceService["gotoAndStop"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The behavior frame name we want the timeline to go to. If will jump to the starting index of the name given.</param>
		/// <returns></returns>
        public void GotoAndPlay(string arg0_id, string arg1_frame)
        {
            SourceService["gotoAndPlay"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Goes to a certain frame and continue playing. DEPRECATED since 1.14</summary>
		/// <param name="arg0_id">The id of the box containing the box (the URI of the box).</param>
		/// <param name="arg1_frame">The frame we want the timeline to go to.</param>
		/// <returns></returns>
        public void GotoAndPlay(string arg0_id, int arg1_frame)
        {
            SourceService["gotoAndPlay"].Call(arg0_id, arg1_frame);
        }

        /// <summary>Called by ALMemory when subcription data is updated. INTERNAL</summary>
		/// <param name="arg0_dataName">Name of the subscribed data.</param>
		/// <param name="arg1_data">Value of the the subscribed data</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public void _dataChanged(string arg0_dataName, QiAnyValue arg1_data, string arg2_message)
        {
            SourceService["_dataChanged"].Call(arg0_dataName, arg1_data, arg2_message);
        }

        /// <summary>method called by almemory to inform framemanager that a box is subscribing to an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_message">the associated message</param>
		/// <param name="arg3_callback">the name of the box's callback to call</param>
		/// <param name="arg4_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public void _subscribeBoxToEvent(string arg0_eventName, string arg1_boxName, string arg2_message, string arg3_callback, bool arg4_micro)
        {
            SourceService["_subscribeBoxToEvent"].Call(arg0_eventName, arg1_boxName, arg2_message, arg3_callback, arg4_micro);
        }

        /// <summary>method called by almemory to inform framemanager that a box is unsubscribing from an event</summary>
		/// <param name="arg0_eventName">the name of the event</param>
		/// <param name="arg1_boxName">the name of the box requesting it (the URI of the box).</param>
		/// <param name="arg2_micro">true if the subscription is to a micro event</param>
		/// <returns></returns>
        public void _unsubscribeBoxToEvent(string arg0_eventName, string arg1_boxName, bool arg2_micro)
        {
            SourceService["_unsubscribeBoxToEvent"].Call(arg0_eventName, arg1_boxName, arg2_micro);
        }

        /// <summary></summary>
		/// <param name="arg0_eventName"></param>
		/// <param name="arg1_value"></param>
		/// <param name="arg2_message"></param>
		/// <returns></returns>
        public void _boxDataChanged(string arg0_eventName, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_boxDataChanged"].Call(arg0_eventName, arg1_value, arg2_message);
        }

        /// <summary>Start recording some performance data.</summary>
		/// <returns></returns>
        public void _startBenchmark()
        {
            SourceService["_startBenchmark"].Call();
        }

        /// <summary>Stop performance data recording, and return a summary.</summary>
		/// <returns>Returns a textual report of the recorded performance data.</returns>
        public string _stopBenchmark()
        {
            return (string)SourceService["_stopBenchmark"].Call();
        }

        /// <summary>Creates a new box found in an xml file stored in the robot, without loading it, and without auto-delete on stop. (used by link box)</summary>
		/// <param name="arg0_xmlFilePath">Path to Xml file, ex : &quot;/home/youhou/mybehavior.xar&quot;.</param>
		/// <param name="arg1_path">The path to reach the box to instantiate in the project (&quot;&quot; if root).</param>
		/// <returns>return a unique identifier for the created box (the URI of the box), that can be used by playBehavior</returns>
        public string _newBoxFromFile(string arg0_xmlFilePath, string arg1_path)
        {
            return (string)SourceService["_newBoxFromFile"].Call(arg0_xmlFilePath, arg1_path);
        }

        /// <summary>wait for a previously started behavior is stopped</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior to wait for (the URI of the root box)</param>
		/// <returns></returns>
        public void _waitForStopped(string arg0_fmid)
        {
            SourceService["_waitForStopped"].Call(arg0_fmid);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public void _onPreferenceUpdated(string arg0_key, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_onPreferenceUpdated"].Call(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>callback for changes in the preference manager</summary>
		/// <param name="arg0_key">ignored, used by ALMemory</param>
		/// <param name="arg1_value">the domain and the key of the preference that changed</param>
		/// <param name="arg2_message">ignored, used by ALMemory</param>
		/// <returns></returns>
        public void _onPreferencesSynchronized(string arg0_key, QiAnyValue arg1_value, string arg2_message)
        {
            SourceService["_onPreferencesSynchronized"].Call(arg0_key, arg1_value, arg2_message);
        }

        /// <summary>called by behaviors when an error occured</summary>
		/// <param name="arg0_fmid">the unique identifier of the behavior that failed (the URI of the root box)</param>
		/// <param name="arg1_boxid">the identifier of the box that failed (the URI of the box).</param>
		/// <param name="arg2_error">the error message</param>
		/// <returns></returns>
        public void _reportError(string arg0_fmid, string arg1_boxid, string arg2_error)
        {
            SourceService["_reportError"].Call(arg0_fmid, arg1_boxid, arg2_error);
        }

        /// <summary>get an object tracking transitions in a behavior</summary>
		/// <param name="arg0_behavior">name of the behavior (the URI of the root box)</param>
		/// <returns></returns>
        public QiObject GetBehaviorDebuggerFor(string arg0_behavior)
        {
            return SourceService["getBehaviorDebuggerFor"].CallObject(arg0_behavior);
        }

        /// <summary>get a box as an object</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <returns></returns>
        public QiObject GetBox(string arg0_box)
        {
            return SourceService["getBox"].CallObject(arg0_box);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box).</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg">input argument</param>
		/// <returns></returns>
        public QiValue CallBoxInput(string arg0_box, string arg1_method, QiAnyValue arg2_arg)
        {
            return SourceService["callBoxInput"].Call(arg0_box, arg1_method, arg2_arg);
        }

        /// <summary>call an input on a box</summary>
		/// <param name="arg0_box">name of the box (the URI of the box). A box URI is of the format 'behavior_name:/diagram_1/box_2'</param>
		/// <param name="arg1_method">name of the method</param>
		/// <param name="arg2_arg1">input argument</param>
		/// <param name="arg3_arg2">input argument</param>
		/// <returns></returns>
        public QiValue CallBoxInput(string arg0_box, string arg1_method, QiAnyValue arg2_arg1, QiAnyValue arg3_arg2)
        {
            return SourceService["callBoxInput"].Call(arg0_box, arg1_method, arg2_arg1, arg3_arg2);
        }

    }
}