using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module provides methods to take pictures and store them on disk.</summary>
    public class ALPhotoCapture
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALPhotoCapture(QiSession session)
        {
            SourceService = session.GetService("ALPhotoCapture");
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

        /// <summary>Enables or disables the half-press mode.</summary>
		/// <param name="arg0_enable">True to enable, false to disable.</param>
		/// <returns></returns>
        public void SetHalfPressEnabled(bool arg0_enable)
        {
            SourceService["setHalfPressEnabled"].Call(arg0_enable);
        }

        /// <summary>Manually (un)subscribes to ALVideoDevice.</summary>
		/// <returns>True if eveything went well, False otherwise.</returns>
        public bool HalfPress()
        {
            return (bool)SourceService["halfPress"].Call();
        }

        /// <summary>Takes one picture.</summary>
		/// <param name="arg0_folderPath">Folder where the picture is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the picture.</param>
		/// <returns>Full file name of the picture saved on the disk: [filename]</returns>
        public QiValue TakePicture(string arg0_folderPath, string arg1_fileName)
        {
            return SourceService["takePicture"].Call(arg0_folderPath, arg1_fileName);
        }

        /// <summary>Takes one picture.</summary>
		/// <param name="arg0_folderPath">Folder where the picture is saved.</param>
		/// <param name="arg1_fileName">Filename used to save the picture.</param>
		/// <param name="arg2_overwrite">If false and the filename already exists, an error is thrown.</param>
		/// <returns>Full file name of the picture saved on the disk: [filename]</returns>
        public QiValue TakePicture(string arg0_folderPath, string arg1_fileName, bool arg2_overwrite)
        {
            return SourceService["takePicture"].Call(arg0_folderPath, arg1_fileName, arg2_overwrite);
        }

        /// <summary>Takes several pictures as quickly as possible</summary>
		/// <param name="arg0_numberOfPictures">Number of pictures to take</param>
		/// <param name="arg1_folderPath">Folder where the pictures are saved.</param>
		/// <param name="arg2_fileName">Filename used to save the pictures.</param>
		/// <returns>List of all saved files: [[filename1, filename2...]]</returns>
        public QiValue TakePictures(int arg0_numberOfPictures, string arg1_folderPath, string arg2_fileName)
        {
            return SourceService["takePictures"].Call(arg0_numberOfPictures, arg1_folderPath, arg2_fileName);
        }

        /// <summary>Takes several pictures as quickly as possible</summary>
		/// <param name="arg0_numberOfPictures">Number of pictures to take</param>
		/// <param name="arg1_folderPath">Folder where the pictures are saved.</param>
		/// <param name="arg2_fileName">Filename used to save the pictures.</param>
		/// <param name="arg3_overwrite">If false and the filename already exists, an error is thrown.</param>
		/// <returns>List of all saved files: [[filename1, filename2...]]</returns>
        public QiValue TakePictures(int arg0_numberOfPictures, string arg1_folderPath, string arg2_fileName, bool arg3_overwrite)
        {
            return SourceService["takePictures"].Call(arg0_numberOfPictures, arg1_folderPath, arg2_fileName, arg3_overwrite);
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

        /// <summary>Sets delay between two captures.</summary>
		/// <param name="arg0_captureInterval">New delay (in ms) between two pictures.</param>
		/// <returns></returns>
        public void SetCaptureInterval(int arg0_captureInterval)
        {
            SourceService["setCaptureInterval"].Call(arg0_captureInterval);
        }

        /// <summary>Sets picture extension.</summary>
		/// <param name="arg0_pictureFormat">New extension used to save pictures.</param>
		/// <returns></returns>
        public void SetPictureFormat(string arg0_pictureFormat)
        {
            SourceService["setPictureFormat"].Call(arg0_pictureFormat);
        }

        /// <summary>Returns current camera ID.</summary>
		/// <returns>Current camera ID.</returns>
        public int GetCameraID()
        {
            return (int)SourceService["getCameraID"].Call();
        }

        /// <summary>Returns current resolution.</summary>
		/// <returns>Current frame resolution.</returns>
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

        /// <summary>Returns current delay between captures.</summary>
		/// <returns>Current delay (in ms) between two pictures.</returns>
        public int GetCaptureInterval()
        {
            return (int)SourceService["getCaptureInterval"].Call();
        }

        /// <summary>Returns current picture format.</summary>
		/// <returns>Current picture format.</returns>
        public string GetPictureFormat()
        {
            return (string)SourceService["getPictureFormat"].Call();
        }

        /// <summary>Returns True if the &quot;half press&quot; mode is on.</summary>
		/// <returns>True or False.</returns>
        public bool IsHalfPressEnabled()
        {
            return (bool)SourceService["isHalfPressEnabled"].Call();
        }

        /// <summary>Returns True if the &quot;half press&quot; mode is on.</summary>
		/// <returns>True or False.</returns>
        public bool IsHalfPressed()
        {
            return (bool)SourceService["isHalfPressed"].Call();
        }

    }
}