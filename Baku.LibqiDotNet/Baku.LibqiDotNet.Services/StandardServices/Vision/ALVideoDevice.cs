using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>ALVideoDevice, formerly called Video Input systemis architectured in order to provide every module related to vision, called vision module, a direct access to raw images from video source, or an access to images transformed in the requested format.  Extension name of the methods providing images depends on wether modules are local (dynamic library) or remote (executable).</summary>
    public class ALVideoDevice
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALVideoDevice(QiSession session)
        {
            SourceService = session.GetService("ALVideoDevice");
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

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <param name="arg2_resolution">Resolution requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpace">Colorspace requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public string SubscribeCamera(string arg0_name, int arg1_cameraIndex, int arg2_resolution, int arg3_colorSpace, int arg4_fps)
        {
            return (string)SourceService["subscribeCamera"].Call(arg0_name, arg1_cameraIndex, arg2_resolution, arg3_colorSpace, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <param name="arg2_resolutions">Resolutions requested.{0=kQQVGA, 1=kQVGA, 2=kVGA, 3=k4VGA}</param>
		/// <param name="arg3_colorSpaces">Colorspaces requested.{0=kYuv, 9=kYUV422, 10=kYUV, 11=kRGB, 12=kHSY, 13=kBGR}</param>
		/// <param name="arg4_fps">Fps (frames per second) requested.{5, 10, 15, 30}</param>
		/// <returns>Name under which the vision module is known from ALVideoDevice</returns>
        public string SubscribeCameras(string arg0_name, QiAnyValue arg1_cameraIndexes, QiAnyValue arg2_resolutions, QiAnyValue arg3_colorSpaces, int arg4_fps)
        {
            return (string)SourceService["subscribeCameras"].Call(arg0_name, arg1_cameraIndexes, arg2_resolutions, arg3_colorSpaces, arg4_fps);
        }

        /// <summary></summary>
		/// <param name="arg0_nameId">Name under which the vision module is known from ALVideoDevice.</param>
		/// <returns>True if success, false otherwise</returns>
        public bool Unsubscribe(string arg0_nameId)
        {
            return (bool)SourceService["unsubscribe"].Call(arg0_nameId);
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetSubscribers()
        {
            return SourceService["getSubscribers"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public QiValue GetCameraIndexes()
        {
            return SourceService["getCameraIndexes"].Call();
        }

        /// <summary>Tells which camera is the default one</summary>
		/// <returns> 0: top camera - 1: bottom camera</returns>
        public int GetActiveCamera()
        {
            return (int)SourceService["getActiveCamera"].Call();
        }

        /// <summary>Set the active camera</summary>
		/// <param name="arg0_activeCamera"> 0: top camera - 1: bottom camera</param>
		/// <returns></returns>
        public bool SetActiveCamera(int arg0_activeCamera)
        {
            return (bool)SourceService["setActiveCamera"].Call(arg0_activeCamera);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns> 1(kOV7670): VGA camera - 2(kMT9M114): HD camera</returns>
        public int GetCameraModel(int arg0_cameraIndex)
        {
            return (int)SourceService["getCameraModel"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>CameraTop - CameraBottom - CameraDepth</returns>
        public string GetCameraName(int arg0_cameraIndex)
        {
            return (string)SourceService["getCameraName"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetFrameRate(int arg0_cameraIndex)
        {
            return (int)SourceService["getFrameRate"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetResolution(int arg0_cameraIndex)
        {
            return (int)SourceService["getResolution"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetColorSpace(int arg0_cameraIndex)
        {
            return (int)SourceService["getColorSpace"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetHorizontalFOV(int arg0_cameraIndex)
        {
            return (float)SourceService["getHorizontalFOV"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetVerticalFOV(int arg0_cameraIndex)
        {
            return (float)SourceService["getVerticalFOV"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetParameter(int arg0_cameraIndex, int arg1_parameterId)
        {
            return (int)SourceService["getParameter"].Call(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue GetParameterRange(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterRange"].Call(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue GetParameterInfo(int arg0_cameraIndex, int arg1_parameterId)
        {
            return SourceService["getParameterInfo"].Call(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public bool SetParameter(int arg0_cameraIndex, int arg1_parameterId, int arg2_value)
        {
            return (bool)SourceService["setParameter"].Call(arg0_cameraIndex, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public bool SetParameterToDefault(int arg0_cameraIndex, int arg1_parameterId)
        {
            return (bool)SourceService["setParameterToDefault"].Call(arg0_cameraIndex, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool SetAllParametersToDefault(int arg0_cameraIndex)
        {
            return (bool)SourceService["setAllParametersToDefault"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool OpenCamera(int arg0)
        {
            return (bool)SourceService["openCamera"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool CloseCamera(int arg0)
        {
            return (bool)SourceService["closeCamera"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsCameraOpen(int arg0)
        {
            return (bool)SourceService["isCameraOpen"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool StartCamera(int arg0)
        {
            return (bool)SourceService["startCamera"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool StopCamera(int arg0)
        {
            return (bool)SourceService["stopCamera"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsCameraStarted(int arg0)
        {
            return (bool)SourceService["isCameraStarted"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool ResetCamera(int arg0)
        {
            return (bool)SourceService["resetCamera"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool StartFrameGrabber(int arg0_cameraIndex)
        {
            return (bool)SourceService["startFrameGrabber"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool StopFrameGrabber(int arg0_cameraIndex)
        {
            return (bool)SourceService["stopFrameGrabber"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool IsFrameGrabberOff(int arg0_cameraIndex)
        {
            return (bool)SourceService["isFrameGrabberOff"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool HasDepthCamera()
        {
            return (bool)SourceService["hasDepthCamera"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetFrameRate(string arg0_name)
        {
            return (int)SourceService["getFrameRate"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_frameRate">Frame Rate requested.</param>
		/// <returns></returns>
        public bool SetFrameRate(string arg0_name, int arg1_frameRate)
        {
            return (bool)SourceService["setFrameRate"].Call(arg0_name, arg1_frameRate);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetActiveCamera(string arg0_name)
        {
            return (int)SourceService["getActiveCamera"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public bool SetActiveCamera(string arg0_name, int arg1_cameraIndex)
        {
            return (bool)SourceService["setActiveCamera"].Call(arg0_name, arg1_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetResolution(string arg0_name)
        {
            return (int)SourceService["getResolution"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolution">Resolution requested.</param>
		/// <returns></returns>
        public bool SetResolution(string arg0_name, int arg1_resolution)
        {
            return (bool)SourceService["setResolution"].Call(arg0_name, arg1_resolution);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public int GetColorSpace(string arg0_name)
        {
            return (int)SourceService["getColorSpace"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpace">Color Space requested.</param>
		/// <returns></returns>
        public bool SetColorSpace(string arg0_name, int arg1_colorSpace)
        {
            return (bool)SourceService["setColorSpace"].Call(arg0_name, arg1_colorSpace);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetCameraParameter(string arg0_name, int arg1_parameterId)
        {
            return (int)SourceService["getCameraParameter"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue GetCameraParameterRange(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterRange"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue GetCameraParameterInfo(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCameraParameterInfo"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_value">value requested.</param>
		/// <returns></returns>
        public bool SetCameraParameter(string arg0_name, int arg1_parameterId, int arg2_value)
        {
            return (bool)SourceService["setCameraParameter"].Call(arg0_name, arg1_parameterId, arg2_value);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public bool SetCameraParameterToDefault(string arg0_name, int arg1_parameterId)
        {
            return (bool)SourceService["setCameraParameterToDefault"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public bool SetAllCameraParametersToDefault(string arg0_name)
        {
            return (bool)SourceService["setAllCameraParametersToDefault"].Call(arg0_name);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public QiValue GetDirectRawImageLocal(string arg0_name)
        {
            return SourceService["getDirectRawImageLocal"].Call(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public QiValue GetDirectRawImageRemote(string arg0_name)
        {
            return SourceService["getDirectRawImageRemote"].Call(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImageLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public bool ReleaseDirectRawImage(string arg0_name)
        {
            return (bool)SourceService["releaseDirectRawImage"].Call(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public QiValue GetImageLocal(string arg0_name)
        {
            return SourceService["getImageLocal"].Call(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public QiValue GetImageRemote(string arg0_name)
        {
            return SourceService["getImageRemote"].Call(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public bool ReleaseImage(string arg0_name)
        {
            return (bool)SourceService["releaseImage"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public QiValue GetActiveCameras(string arg0_name)
        {
            return SourceService["getActiveCameras"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_cameraIndexes">Cameras requested.</param>
		/// <returns></returns>
        public QiValue SetActiveCameras(string arg0_name, QiAnyValue arg1_cameraIndexes)
        {
            return SourceService["setActiveCameras"].Call(arg0_name, arg1_cameraIndexes);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public QiValue GetResolutions(string arg0_name)
        {
            return SourceService["getResolutions"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_resolutions">Resolutions requested.</param>
		/// <returns></returns>
        public QiValue SetResolutions(string arg0_name, QiAnyValue arg1_resolutions)
        {
            return SourceService["setResolutions"].Call(arg0_name, arg1_resolutions);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns></returns>
        public QiValue GetColorSpaces(string arg0_name)
        {
            return SourceService["getColorSpaces"].Call(arg0_name);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_colorSpaces">Color Spaces requested.</param>
		/// <returns></returns>
        public QiValue SetColorSpaces(string arg0_name, QiAnyValue arg1_colorSpaces)
        {
            return SourceService["setColorSpaces"].Call(arg0_name, arg1_colorSpaces);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue GetCamerasParameter(string arg0_name, int arg1_parameterId)
        {
            return SourceService["getCamerasParameter"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <param name="arg2_values">values requested.</param>
		/// <returns></returns>
        public QiValue SetCamerasParameter(string arg0_name, int arg1_parameterId, QiAnyValue arg2_values)
        {
            return SourceService["setCamerasParameter"].Call(arg0_name, arg1_parameterId, arg2_values);
        }

        /// <summary></summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <param name="arg1_parameterId">Camera parameter requested.</param>
		/// <returns></returns>
        public QiValue SetCamerasParameterToDefault(string arg0_name, int arg1_parameterId)
        {
            return SourceService["setCamerasParameterToDefault"].Call(arg0_name, arg1_parameterId);
        }

        /// <summary>Retrieves the latest image from the video source and returns a pointer to the locked ALImage, with data array pointing directly to raw data. There is no format conversion and no copy of the raw buffer.Warning: When image is not necessary anymore, a call to releaseDirectRawImage() is requested.Warning: When using this mode for several vision module, if they need raw data for more than 25ms check that you have strictly less modules in this mode than the amount of kernel buffers!!Warning: Release all kernel buffers before any action requesting a modification in camera running mode (e.g. resolution, switch between cameras).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer to the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public QiValue GetDirectRawImagesLocal(string arg0_name)
        {
            return SourceService["getDirectRawImagesLocal"].Call(arg0_name);
        }

        /// <summary>Fills an ALValue with data coming directly from raw buffer (no format conversion).</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public QiValue GetDirectRawImagesRemote(string arg0_name)
        {
            return SourceService["getDirectRawImagesRemote"].Call(arg0_name);
        }

        /// <summary>Release image buffer locked by getDirectRawImagesLocal().</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public QiValue ReleaseDirectRawImages(string arg0_name)
        {
            return SourceService["releaseDirectRawImages"].Call(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and returns a pointer to a locked ALImage.When image is not necessary anymore, a call to releaseImage() is requested.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array of pointer of the locked image buffer, NULL if error.Warning, image pointer is valid only for C++ dynamic library.</returns>
        public QiValue GetImagesLocal(string arg0_name)
        {
            return SourceService["getImagesLocal"].Call(arg0_name);
        }

        /// <summary>Applies transformations to the last image from video source and fills pFrameOut.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>Array containing image informations :     [0] : width;    [1] : height;    [2] : number of layers;    [3] : ColorSpace;    [4] : time stamp (highest 32 bits);    [5] : time stamp (lowest 32 bits);    [6] : array of size height * width * nblayers containing image data;    [7] : cameraID;    [8] : left angle;    [9] : top angle;    [10] : right angle;    [11] : bottom angle;</returns>
        public QiValue GetImagesRemote(string arg0_name)
        {
            return SourceService["getImagesRemote"].Call(arg0_name);
        }

        /// <summary>Release image buffer locked by getImageLocal().If G.V.M. had no locked image buffer, does nothing.</summary>
		/// <param name="arg0_name">Name of the subscribing vision module</param>
		/// <returns>true if success</returns>
        public QiValue ReleaseImages(string arg0_name)
        {
            return SourceService["releaseImages"].Call(arg0_name);
        }

        /// <summary>Background record of an .arv raw format video from the images processed by a vision moduleActualy it take picture each time the vision module call getDirectRawImageRemote().</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from the V.I.M.</param>
		/// <param name="arg1_path">path/name of the video to be recorded</param>
		/// <param name="arg2_totalNumber">number of images to be recorded. 0xFFFFFFFF for &quot;unlimited&quot;</param>
		/// <param name="arg3_period">one image recorded every pPeriod images</param>
		/// <returns>true if success</returns>
        public bool RecordVideo(string arg0_id, string arg1_path, int arg2_totalNumber, int arg3_period)
        {
            return (bool)SourceService["recordVideo"].Call(arg0_id, arg1_path, arg2_totalNumber, arg3_period);
        }

        /// <summary>Stop writing the video sequence</summary>
		/// <param name="arg0_id">Name under which the G.V.M. is known from ALVideoDevice.</param>
		/// <returns>true if success</returns>
        public bool StopVideo(string arg0_id)
        {
            return (bool)SourceService["stopVideo"].Call(arg0_id);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetAngularPositionFromImagePosition(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularPositionFromImagePosition"].Call(arg0, QiList.Create(arg1));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetImagePositionFromAngularPosition(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImagePositionFromAngularPosition"].Call(arg0, QiList.Create(arg1));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetAngularSizeFromImageSize(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getAngularSizeFromImageSize"].Call(arg0, QiList.Create(arg1));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetImageSizeFromAngularSize(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageSizeFromAngularSize"].Call(arg0, QiList.Create(arg1));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetImageInfoFromAngularInfo(int arg0, IEnumerable<float> arg1)
        {
            return SourceService["getImageInfoFromAngularInfo"].Call(arg0, QiList.Create(arg1));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public QiValue GetImageInfoFromAngularInfoWithResolution(int arg0, IEnumerable<float> arg1, int arg2)
        {
            return SourceService["getImageInfoFromAngularInfoWithResolution"].Call(arg0, QiList.Create(arg1), arg2);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <param name="arg1_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg2_height">int height of image</param>
		/// <param name="arg3_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public bool PutImage(int arg0_cameraIndex, int arg1_width, int arg2_height, QiAnyValue arg3_imageBuffer)
        {
            return (bool)SourceService["putImage"].Call(arg0_cameraIndex, arg1_width, arg2_height, arg3_imageBuffer);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public QiValue GetExpectedImageParameters(int arg0_cameraIndex)
        {
            return SourceService["getExpectedImageParameters"].Call(arg0_cameraIndex);
        }

        /// <summary>Get average environment luminance.</summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns>The average brightness luminance == (15680-Texposure)*256+AverageLuminance</returns>
        public int _getExternalBrightness(int arg0_cameraIndex)
        {
            return (int)SourceService["_getExternalBrightness"].Call(arg0_cameraIndex);
        }

        /// <summary>Callback when client is disconnected</summary>
		/// <param name="arg0_eventName">The echoed event name</param>
		/// <param name="arg1_eventContents">The name of the client that has disconnected</param>
		/// <param name="arg2_message">The message give when subscribing.</param>
		/// <returns></returns>
        public void OnClientDisconnected(string arg0_eventName, QiAnyValue arg1_eventContents, string arg2_message)
        {
            SourceService["onClientDisconnected"].Call(arg0_eventName, arg1_eventContents, arg2_message);
        }

        /// <summary>Register to ALVideoDevice (formerly Video Input Module/V.I.M.). When a General Video Module(G.V.M.) registers to ALVideoDevice, a buffer of the requested image format is added to the buffers list.Returns the name under which the G.V.M. is registered to ALVideoDevice (useful when two G.V.M. try to register using the same name</summary>
		/// <param name="arg0_gvmName">Name of the subscribing G.V.M.</param>
		/// <param name="arg1_resolution">Resolution requested. { 0 = kQQVGA, 1 = kQVGA, 2 = kVGA } </param>
		/// <param name="arg2_colorSpace">Colorspace requested. { 0 = kYuv, 9 = kYUV422, 10 = kYUV, 11 = kRGB, 12 = kHSY, 13 = kBGR } </param>
		/// <param name="arg3_fps">Fps (frames per second) requested. { 5, 10, 15, 30 } </param>
		/// <returns>Name under which the G.V.M. is known from ALVideoDevice, 0 if failed.</returns>
        public string Subscribe(string arg0_gvmName, int arg1_resolution, int arg2_colorSpace, int arg3_fps)
        {
            return (string)SourceService["subscribe"].Call(arg0_gvmName, arg1_resolution, arg2_colorSpace, arg3_fps);
        }

        /// <summary>Used to unsubscribe all instances for a given G.V.M. (e.g. VisionModule and VisionModule_5) from ALVideoDevice.</summary>
		/// <param name="arg0_id">Root name of the G.V.M. (e.g. with the example above this will be VisionModule).</param>
		/// <returns></returns>
        public void UnsubscribeAllInstances(string arg0_id)
        {
            SourceService["unsubscribeAllInstances"].Call(arg0_id);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMResolution()
        {
            return (int)SourceService["getVIMResolution"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMColorSpace()
        {
            return (int)SourceService["getVIMColorSpace"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetVIMFrameRate()
        {
            return (int)SourceService["getVIMFrameRate"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMResolution(string arg0)
        {
            return (int)SourceService["getGVMResolution"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMColorSpace(string arg0)
        {
            return (int)SourceService["getGVMColorSpace"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetGVMFrameRate(string arg0)
        {
            return (int)SourceService["getGVMFrameRate"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetCameraModelID()
        {
            return (int)SourceService["getCameraModelID"].Call();
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <returns></returns>
        public void SetParam(int arg0_pParam, int arg1_pNewValue)
        {
            SourceService["setParam"].Call(arg0_pParam, arg1_pNewValue);
        }

        /// <summary>Sets the value of a specific parameter for the video source.</summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pNewValue">value requested.</param>
		/// <param name="arg2_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public void SetParam(int arg0_pParam, int arg1_pNewValue, int arg2_pCameraIndex)
        {
            SourceService["setParam"].Call(arg0_pParam, arg1_pNewValue, arg2_pCameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <returns></returns>
        public int GetParam(int arg0_pParam)
        {
            return (int)SourceService["getParam"].Call(arg0_pParam);
        }

        /// <summary></summary>
		/// <param name="arg0_pParam">Camera parameter requested.</param>
		/// <param name="arg1_pCameraIndex">Camera requested.</param>
		/// <returns></returns>
        public int GetParam(int arg0_pParam, int arg1_pCameraIndex)
        {
            return (int)SourceService["getParam"].Call(arg0_pParam, arg1_pCameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void SetParamDefault(int arg0)
        {
            SourceService["setParamDefault"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetAngPosFromImgPos(IEnumerable<float> arg0)
        {
            return SourceService["getAngPosFromImgPos"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetImgPosFromAngPos(IEnumerable<float> arg0)
        {
            return SourceService["getImgPosFromAngPos"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetAngSizeFromImgSize(IEnumerable<float> arg0)
        {
            return SourceService["getAngSizeFromImgSize"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetImgSizeFromAngSize(IEnumerable<float> arg0)
        {
            return SourceService["getImgSizeFromAngSize"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetImgInfoFromAngInfo(IEnumerable<float> arg0)
        {
            return SourceService["getImgInfoFromAngInfo"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetImgInfoFromAngInfoWithRes(IEnumerable<float> arg0, int arg1)
        {
            return SourceService["getImgInfoFromAngInfoWithRes"].Call(QiList.Create(arg0), arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue ResolutionToSizes(int arg0)
        {
            return SourceService["resolutionToSizes"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int SizesToResolution(int arg0, int arg1)
        {
            return (int)SourceService["sizesToResolution"].Call(arg0, arg1);
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <returns>ALValue of expected parameters, [int resolution, int framerate]</returns>
        public QiValue GetExpectedImageParameters()
        {
            return SourceService["getExpectedImageParameters"].Call();
        }

        /// <summary>called by the simulator to know expected image parameters</summary>
		/// <param name="arg0_width">int width of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <param name="arg1_height">int height of image among 1280*960, 640*480, 320*240, 240*160</param>
		/// <returns>true if setSize worked</returns>
        public bool SetSimCamInputSize(int arg0_width, int arg1_height)
        {
            return (bool)SourceService["setSimCamInputSize"].Call(arg0_width, arg1_height);
        }

        /// <summary>Allow image buffer pushing</summary>
		/// <param name="arg0_imageBuffer">Image buffer in bitmap form</param>
		/// <returns>true if the put succeeded</returns>
        public bool PutImage(QiAnyValue arg0_imageBuffer)
        {
            return (bool)SourceService["putImage"].Call(arg0_imageBuffer);
        }

        /// <summary>Advanced method that opens and initialize video source device if it was not before.Note that the first module subscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public bool StartFrameGrabber()
        {
            return (bool)SourceService["startFrameGrabber"].Call();
        }

        /// <summary>Advanced method that close video source device.Note that the last module unsubscribing to ALVideoDevice will launch it automatically.</summary>
		/// <returns>true if success</returns>
        public bool StopFrameGrabber()
        {
            return (bool)SourceService["stopFrameGrabber"].Call();
        }

        /// <summary>Advanced method that asks if the framegrabber is off.</summary>
		/// <returns>true if off</returns>
        public int IsFrameGrabberOff()
        {
            return (int)SourceService["isFrameGrabberOff"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetHorizontalAperture(int arg0_cameraIndex)
        {
            return (float)SourceService["getHorizontalAperture"].Call(arg0_cameraIndex);
        }

        /// <summary></summary>
		/// <param name="arg0_cameraIndex">Camera requested.</param>
		/// <returns></returns>
        public float GetVerticalAperture(int arg0_cameraIndex)
        {
            return (float)SourceService["getVerticalAperture"].Call(arg0_cameraIndex);
        }

    }
}