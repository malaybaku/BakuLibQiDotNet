using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>Use ALRobotPosture module to make the robot go tothe asked posture.</summary>
    public class ALRobotPosture
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALRobotPosture(QiSession session)
        {
            SourceService = session.GetService("ALRobotPosture");
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

        /// <summary>Returns the posture family for example Standing, LyingBelly,...</summary>
		/// <returns>Returns the posture family, e.g. Standing.</returns>
        public string GetPostureFamily()
        {
            return (string)SourceService["getPostureFamily"].Call();
        }

        /// <summary>Make the robot go to the choosenposture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public bool GoToPosture(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return (bool)SourceService["goToPosture"].Call(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Set the angle of the joints of the  robot to the choosen posture.</summary>
		/// <param name="arg0_postureName">Name of the desired posture. Use getPostureList to get the list of posture name available.</param>
		/// <param name="arg1_maxSpeedFraction">A fraction.</param>
		/// <returns>Returns if the posture was reached or not.</returns>
        public bool ApplyPosture(string arg0_postureName, float arg1_maxSpeedFraction)
        {
            return (bool)SourceService["applyPosture"].Call(arg0_postureName, arg1_maxSpeedFraction);
        }

        /// <summary>Stop the posture move.</summary>
		/// <returns></returns>
        public void StopMove()
        {
            SourceService["stopMove"].Call();
        }

        /// <summary>Get the list of posture names available.</summary>
		/// <returns></returns>
        public string[] GetPostureList()
        {
            return (string[])SourceService["getPostureList"].Call();
        }

        /// <summary>Get the list of posture family names available.</summary>
		/// <returns></returns>
        public string[] GetPostureFamilyList()
        {
            return (string[])SourceService["getPostureFamilyList"].Call();
        }

        /// <summary>Set maximum of tries ongoToPosture fail.</summary>
		/// <param name="arg0_pMaxTryNumber">Number of retry if goToPosture fail.</param>
		/// <returns></returns>
        public void SetMaxTryNumber(int arg0_pMaxTryNumber)
        {
            SourceService["setMaxTryNumber"].Call(arg0_pMaxTryNumber);
        }

        /// <summary>Determine posture.</summary>
		/// <returns></returns>
        public string GetPosture()
        {
            return (string)SourceService["getPosture"].Call();
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public QiValue _isRobotInPosture(string arg0, float arg1, float arg2)
        {
            return SourceService["_isRobotInPosture"].Call(arg0, arg1, arg2);
        }

        /// <summary>Articular distance</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _isRobotInPostureId(int arg0, float arg1, float arg2)
        {
            return (bool)SourceService["_isRobotInPostureId"].Call(arg0, arg1, arg2);
        }

        /// <summary>Determine posture id.</summary>
		/// <returns></returns>
        public QiValue _getPosture()
        {
            return SourceService["_getPosture"].Call();
        }

        /// <summary>Set the angle of the joints.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setPostureId(int arg0, float arg1)
        {
            return (bool)SourceService["_setPostureId"].Call(arg0, arg1);
        }

        /// <summary>Set the angle of thejoints and of the inertial unit</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _goToPostureId(int arg0, float arg1)
        {
            return (bool)SourceService["_goToPostureId"].Call(arg0, arg1);
        }

        /// <summary>Name posture from id.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _namePosture(int arg0, string arg1)
        {
            return (bool)SourceService["_namePosture"].Call(arg0, arg1);
        }

        /// <summary>Rename posture from name.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _renamePosture(string arg0, string arg1)
        {
            return (bool)SourceService["_renamePosture"].Call(arg0, arg1);
        }

        /// <summary>Resave posture joints, inertial, family. Keep neighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _resavePosture(int arg0)
        {
            return (bool)SourceService["_resavePosture"].Call(arg0);
        }

        /// <summary>Set slow factorbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _setSlowFactor(int arg0, int arg1, float arg2)
        {
            return (bool)SourceService["_setSlowFactor"].Call(arg0, arg1, arg2);
        }

        /// <summary>Set anti collisionbetween two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setAntiCollision(int arg0, bool arg1)
        {
            return (bool)SourceService["_setAntiCollision"].Call(arg0, arg1);
        }

        /// <summary>Enables/Disables anti collision management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable anticollision management.</param>
		/// <returns></returns>
        public void _setUseAntiCollision(bool arg0_enable)
        {
            SourceService["_setUseAntiCollision"].Call(arg0_enable);
        }

        /// <summary>Enables/Disables auto balance management by RobotPosture.</summary>
		/// <param name="arg0_enable">A bool that enable auto balance management.</param>
		/// <returns></returns>
        public void _setUseAutoBalance(bool arg0_enable)
        {
            SourceService["_setUseAutoBalance"].Call(arg0_enable);
        }

        /// <summary>Set cost between two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _setCost(int arg0, float arg1)
        {
            return (bool)SourceService["_setCost"].Call(arg0, arg1);
        }

        /// <summary>Save current posture.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _saveCurrentPosture(int arg0)
        {
            return (bool)SourceService["_saveCurrentPosture"].Call(arg0);
        }

        /// <summary>Save with a namecurrent posture.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _saveCurrentPostureWithName(int arg0, string arg1)
        {
            return (bool)SourceService["_saveCurrentPostureWithName"].Call(arg0, arg1);
        }

        /// <summary>Apply postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public bool _applyPostures(IEnumerable<int> arg0, float arg1, bool arg2, bool arg3)
        {
            return (bool)SourceService["_applyPostures"].Call(QiList.Create(arg0), arg1, arg2, arg3);
        }

        /// <summary>Erase all postures.</summary>
		/// <returns></returns>
        public bool _eraseAllPostures()
        {
            return (bool)SourceService["_eraseAllPostures"].Call();
        }

        /// <summary>Bind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public bool _bindPostures(int arg0, int arg1, float arg2, float arg3)
        {
            return (bool)SourceService["_bindPostures"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary>Add a neighbour to a postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _addNeighbourToPosture(int arg0, int arg1, float arg2)
        {
            return (bool)SourceService["_addNeighbourToPosture"].Call(arg0, arg1, arg2);
        }

        /// <summary>Remove a neighbour from postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _removeNeighbourFromPosture(int arg0, int arg1)
        {
            return (bool)SourceService["_removeNeighbourFromPosture"].Call(arg0, arg1);
        }

        /// <summary>Unbind two postures.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unBindPostures(int arg0, int arg1)
        {
            return (bool)SourceService["_unBindPostures"].Call(arg0, arg1);
        }

        /// <summary>Erase the posture and unBind theneighbours.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _erasePosture(int arg0)
        {
            return (bool)SourceService["_erasePosture"].Call(arg0);
        }

        /// <summary>Get library size.</summary>
		/// <returns></returns>
        public int _getLibrarySize()
        {
            return (int)SourceService["_getLibrarySize"].Call();
        }

        /// <summary>Load a new library file.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _loadPostureLibraryFromName(string arg0)
        {
            return (bool)SourceService["_loadPostureLibraryFromName"].Call(arg0);
        }

        /// <summary>Get current graph path.</summary>
		/// <returns></returns>
        public QiValue _getCurrentPath()
        {
            return SourceService["_getCurrentPath"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _isStandCallBack(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_isStandCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _savePostureLibrary(string arg0)
        {
            return (bool)SourceService["_savePostureLibrary"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public float _getArticularDistanceToPosture(int arg0)
        {
            return (float)SourceService["_getArticularDistanceToPosture"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getCartesianDistanceToPosture(int arg0)
        {
            return SourceService["_getCartesianDistanceToPosture"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getCartesianDistanceVector(int arg0)
        {
            return SourceService["_getCartesianDistanceVector"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public int[] _getPostureIdList()
        {
            return (int[])SourceService["_getPostureIdList"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _isReachable(int arg0)
        {
            return (bool)SourceService["_isReachable"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public void _generateCartesianMap()
        {
            SourceService["_generateCartesianMap"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _getPostureZ(float arg0)
        {
            return SourceService["_getPostureZ"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <returns></returns>
        public QiValue _getPostureNoZ()
        {
            return SourceService["_getPostureNoZ"].Call();
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _getIdFromName(string arg0)
        {
            return (int)SourceService["_getIdFromName"].Call(arg0);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public void _activeDiagnosisCallBack(string arg0, QiAnyValue arg1, string arg2)
        {
            SourceService["_activeDiagnosisCallBack"].Call(arg0, arg1, arg2);
        }

        /// <summary>.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _eraseFamily(string arg0)
        {
            return (bool)SourceService["_eraseFamily"].Call(arg0);
        }

    }
}