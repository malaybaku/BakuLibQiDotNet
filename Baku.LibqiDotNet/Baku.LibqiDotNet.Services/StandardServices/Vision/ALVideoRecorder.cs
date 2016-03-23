using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module provides methods to record videos and store them on disk.</summary>
    public class ALVideoRecorder
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALVideoRecorder(QiSession session)
        {
            SourceService = session.GetService("ALVideoRecorder");
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

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <returns></returns>
        public void StartRecording(string arg0_folderPath, string arg1_fileName)
        {
            SourceService["startRecording"].Call(arg0_folderPath, arg1_fileName);
        }

        /// <summary>Starts recording a video. Please note that only one record at a time can be made.</summary>
		/// <param name="arg0_folderPath">Folder where the video is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the video.</param>
		/// <param name="arg2_overwrite">If false and the filename already exists, an exception is thrown.</param>
		/// <returns></returns>
        public void StartRecording(string arg0_folderPath, string arg1_fileName, bool arg2_overwrite)
        {
            SourceService["startRecording"].Call(arg0_folderPath, arg1_fileName, arg2_overwrite);
        }

        /// <summary>Stops a video record that was launched with startRecording(). The function returns the number of frames that were recorded, as well as the video absolute file name.</summary>
		/// <returns>Array of two elements [numRecordedFrames, recordAbsolutePath]</returns>
        public QiValue StopRecording()
        {
            return SourceService["stopRecording"].Call();
        }

        /// <summary>Are we currently recording a video</summary>
		/// <returns>True/False</returns>
        public bool IsRecording()
        {
            return (bool)SourceService["isRecording"].Call();
        }

        /// <summary>private</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _recordVideo(string arg0)
        {
            SourceService["_recordVideo"].Call(arg0);
        }

        /// <summary>Sets camera ID.</summary>
		/// <param name="arg0_cameraID">ID of the camera to use.</param>
		/// <returns></returns>
        public void SetCameraID(int arg0_cameraID)
        {
            SourceService["setCameraID"].Call(arg0_cameraID);
        }

        /// <summary>Sets resolution.</summary>
		/// <param name="arg0_resolution">New frame resolution.</param>
		/// <returns></returns>
        public void SetResolution(int arg0_resolution)
        {
            SourceService["setResolution"].Call(arg0_resolution);
        }

        /// <summary>Sets color space.</summary>
		/// <param name="arg0_colorSpace">New color space.</param>
		/// <returns></returns>
        public void SetColorSpace(int arg0_colorSpace)
        {
            SourceService["setColorSpace"].Call(arg0_colorSpace);
        }

        /// <summary>Sets frame rate.</summary>
		/// <param name="arg0_frameRate">New frame rate.</param>
		/// <returns></returns>
        public void SetFrameRate(float arg0_frameRate)
        {
            SourceService["setFrameRate"].Call(arg0_frameRate);
        }

        /// <summary>Sets video format.</summary>
		/// <param name="arg0_videoFormat">New video format.</param>
		/// <returns></returns>
        public void SetVideoFormat(string arg0_videoFormat)
        {
            SourceService["setVideoFormat"].Call(arg0_videoFormat);
        }

        /// <summary>Returns current camera ID.</summary>
		/// <returns>Current camera ID.</returns>
        public int GetCameraID()
        {
            return (int)SourceService["getCameraID"].Call();
        }

        /// <summary>Returns current resolution.</summary>
		/// <returns>Current resolution.</returns>
        public int GetResolution()
        {
            return (int)SourceService["getResolution"].Call();
        }

        /// <summary>Returns current color space.</summary>
		/// <returns>Current color space.</returns>
        public int GetColorSpace()
        {
            return (int)SourceService["getColorSpace"].Call();
        }

        /// <summary>Returns current frame rate.</summary>
		/// <returns>Current frame rate.</returns>
        public int GetFrameRate()
        {
            return (int)SourceService["getFrameRate"].Call();
        }

        /// <summary>Returns current video format.</summary>
		/// <returns>Current video format.</returns>
        public string GetVideoFormat()
        {
            return (string)SourceService["getVideoFormat"].Call();
        }

    }
}