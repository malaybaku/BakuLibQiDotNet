using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALVisionRecognition is a module which detects and recognizes learned pictures, like pages of a comic books, faces of objects or even locations.The learning stage is done using the Choregraphe interface. Follow the steps in the green doc that will explain how to create your own database.The output value is written in ALMemory in the PictureDetected variable.It contains an array of tags, with the following format:  [ [ TimeStampField ] [ Picture_info_0 , Picture _info_1, . . . , Picture_info_N-1 ] ]  with as many Picture_info tags as things currently recognized. Picture_info = [[labels_list], matched_keypoints, ratio, [boundary_points]] with labels_list = [label_0, label_1, ..., label_N-1] and label_n belongs to label_n+1 and boundary_points = [[x0,y0], [x1,y1], ..., [xN,yN]]  - Labels are the names given to the picture (e.g. &quot;cover/my book&quot;, or &quot;fridge corner/kitchen/my flat&quot;). - matched_keypoints corresponds to the number of keypoints retrieved in the current frame. - ratio represents the number of keypoints found for the object in the current frame divided by the number of keypoints found during the learning stage. - boundary_points is a list of points coordinates in angle values representing the reprojection in the current image of the boundaries selected during the learning stage. </summary>
    public class ALVisionRecognition
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALVisionRecognition(QiSession session)
        {
            SourceService = session.GetService("ALVisionRecognition");
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

        /// <summary>Sets the extractor framerate for a chosen subscriber</summary>
		/// <param name="arg0_subscriberName">Name of the subcriber</param>
		/// <param name="arg1_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(string arg0_subscriberName, int arg1_framerate)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_subscriberName, arg1_framerate);
        }

        /// <summary>Sets the extractor framerate for all the subscribers</summary>
		/// <param name="arg0_framerate">New framerate</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetFrameRate(int arg0_framerate)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_framerate);
        }

        /// <summary>Sets extractor resolution</summary>
		/// <param name="arg0_resolution">New resolution</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetResolution(int arg0_resolution)
        {
            return (bool)SourceService["setResolution"].Call(arg0_resolution);
        }

        /// <summary>Sets extractor active camera</summary>
		/// <param name="arg0_cameraId">Id of the camera that will become the active camera</param>
		/// <returns>True if the update succeeded, False if not</returns>
        public bool SetActiveCamera(int arg0_cameraId)
        {
            return (bool)SourceService["setActiveCamera"].Call(arg0_cameraId);
        }

        /// <summary>DEPRECATED: Sets pause and resolution</summary>
		/// <param name="arg0_paramName">Name of the parameter to set</param>
		/// <param name="arg1_value">New value</param>
		/// <returns></returns>
        public void SetParameter(string arg0_paramName, QiAnyValue arg1_value)
        {
            SourceService["setParameter"].Call(arg0_paramName, arg1_value);
        }

        /// <summary>Gets extractor framerate</summary>
		/// <returns>Current value of the framerate of the extractor</returns>
        public int GetFrameRate()
        {
            return (int)SourceService["getFrameRate"].Call();
        }

        /// <summary>Gets extractor resolution</summary>
		/// <returns>Current value of the resolution of the extractor</returns>
        public int GetResolution()
        {
            return (int)SourceService["getResolution"].Call();
        }

        /// <summary>Gets extractor active camera</summary>
		/// <returns>Id of the current active camera of the extractor</returns>
        public int GetActiveCamera()
        {
            return (int)SourceService["getActiveCamera"].Call();
        }

        /// <summary>Gets extractor pause status</summary>
		/// <returns>True if the extractor is paused, False if not</returns>
        public bool IsPaused()
        {
            return (bool)SourceService["isPaused"].Call();
        }

        /// <summary>Gets extractor running status</summary>
		/// <returns>True if the extractor is currently processing images, False if not</returns>
        public bool IsProcessing()
        {
            return (bool)SourceService["isProcessing"].Call();
        }

        /// <summary>Changes the pause status of the extractor</summary>
		/// <param name="arg0_paused">New pause satus</param>
		/// <returns></returns>
        public void Pause(bool arg0_paused)
        {
            SourceService["pause"].Call(arg0_paused);
        }

        /// <summary></summary>
		/// <returns></returns>
        public void _run()
        {
            SourceService["_run"].Call();
        }

        /// <summary>By default the database has the name &quot;current&quot; and is on the robot in /home/nao/naoqi/share/naoqi/vision/visionrecognition/ folder. This bound method allows to choose both another name and another folder for the database. </summary>
		/// <param name="arg0_databasePath">Absolute path of the database on the robot, or &quot;&quot; to set default path.</param>
		/// <param name="arg1_databaseName">Name of the database folder, or &quot;&quot; to set default database folder.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public bool ChangeDatabase(string arg0_databasePath, string arg1_databaseName)
        {
            return (bool)SourceService["changeDatabase"].Call(arg0_databasePath, arg1_databaseName);
        }

        /// <summary>Clear the current database, the user has to be warned before calling this function.</summary>
		/// <returns></returns>
        public void ClearCurrentDatabase()
        {
            SourceService["clearCurrentDatabase"].Call();
        }

        /// <summary>Set vision recognition parameters (deprecated in 1.22)</summary>
		/// <param name="arg0_paramName">Name of the parameter to be changed. Only &quot;resolution&quot; can be used.</param>
		/// <param name="arg1_paramValue">Value of the resolution as an integer: 0(QQVGA) 1(QVGA) 2(VGA)</param>
		/// <returns></returns>
        public void SetParam(string arg0_paramName, QiAnyValue arg1_paramValue)
        {
            SourceService["setParam"].Call(arg0_paramName, arg1_paramValue);
        }

        /// <summary>Get some vision recognition parameters.</summary>
		/// <param name="arg0_paramName">The name of the parameter to get. &quot;db_path&quot; and &quot;db_name&quot; can be used.</param>
		/// <returns>Value of the parameter as a string for &quot;db_path&quot; and &quot;db_name&quot;</returns>
        public QiValue GetParam(string arg0_paramName)
        {
            return SourceService["getParam"].Call(arg0_paramName);
        }

        /// <summary>Load an image and interpret it as an object.</summary>
		/// <param name="arg0_filename">The filename of the image that will be interpreted as a planar object.</param>
		/// <param name="arg1_name">The name of the object (used as a unique identifier).</param>
		/// <param name="arg2_tags">A list of tags (as strings) containing any met-data about your object.</param>
		/// <param name="arg3_isWholeImage">indicates if the object occupies the whole image. If set to false, visionrecognition will try to detect the border of the object automatically. This works with unicolor background where object stands out well from the background. By default, this is set to true.</param>
		/// <param name="arg4_forced">indicates if learned object will replace existing object (having the same original name) if any.</param>
		/// <returns>True if the operation succeded, false otherwise.</returns>
        public bool LearnFromFile(string arg0_filename, string arg1_name, IEnumerable<string> arg2_tags, bool arg3_isWholeImage, bool arg4_forced)
        {
            return (bool)SourceService["learnFromFile"].Call(arg0_filename, arg1_name, QiList.Create(arg2_tags), arg3_isWholeImage, arg4_forced);
        }

        /// <summary>Set the maximal number (not more than 10) of detected objects for each detection. By default, this is set to 1.</summary>
		/// <param name="arg0_iMaxOutObjs">number of desired objects to be detected.</param>
		/// <returns></returns>
        public void SetMaxOutObjs(int arg0_iMaxOutObjs)
        {
            SourceService["setMaxOutObjs"].Call(arg0_iMaxOutObjs);
        }

        /// <summary>Get the maximal number of detected objects for each detection.</summary>
		/// <returns>number of maximal objects to be detected.</returns>
        public int GetMaxOutObjs()
        {
            return (int)SourceService["getMaxOutObjs"].Call();
        }

        /// <summary>Get number of objects in the current database.</summary>
		/// <returns>number of objects in the current database.</returns>
        public int GetSize()
        {
            return (int)SourceService["getSize"].Call();
        }

        /// <summary>Remove an obbject with a specific hash from the DB (Attention: All files related to this object will be deleted.)</summary>
		/// <param name="arg0_hash">the hash (as a string) of the object to be deleted.</param>
		/// <returns></returns>
        public void _removeObject(string arg0_hash)
        {
            SourceService["_removeObject"].Call(arg0_hash);
        }

        /// <summary>Load an image and search for known objects.</summary>
		/// <param name="arg0_image">The image that will be searched for known objects.</param>
		/// <returns></returns>
        public void DetectFromFile(string arg0_image)
        {
            SourceService["detectFromFile"].Call(arg0_image);
        }

    }
}