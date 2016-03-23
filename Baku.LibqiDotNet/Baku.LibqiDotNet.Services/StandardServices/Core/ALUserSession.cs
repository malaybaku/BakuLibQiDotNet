using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALUserSession
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALUserSession(QiSession session)
        {
            SourceService = session.GetService("ALUserSession");
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

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesUserExist(int arg0)
        {
            return (bool)SourceService["doesUserExist"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoUsersExist(IEnumerable<int> arg0)
        {
            return (bool)SourceService["doUsersExist"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetUserList()
        {
            return (int[])SourceService["getUserList"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetNumUsers()
        {
            return (int)SourceService["getNumUsers"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetFocusedUser()
        {
            return (int)SourceService["getFocusedUser"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetOpenUserSessions()
        {
            return (int[])SourceService["getOpenUserSessions"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsUserSessionOpen(int arg0)
        {
            return (bool)SourceService["isUserSessionOpen"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool AreUserSessionsOpen(IEnumerable<int> arg0)
        {
            return (bool)SourceService["areUserSessionsOpen"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsUserPermanent(int arg0)
        {
            return (bool)SourceService["isUserPermanent"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool AreUsersPermanent(IEnumerable<int> arg0)
        {
            return (bool)SourceService["areUsersPermanent"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetPermanentUserList()
        {
            return (int[])SourceService["getPermanentUserList"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _rememberUserPermanently(int arg0)
        {
            return (bool)SourceService["_rememberUserPermanently"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _forgetPermanentUser(int arg0)
        {
            return (bool)SourceService["_forgetPermanentUser"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetBindingList()
        {
            return (string[])SourceService["getBindingList"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesBindingExist(string arg0)
        {
            return (bool)SourceService["doesBindingExist"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public string GetUserBinding(int arg0, string arg1)
        {
            return (string)SourceService["getUserBinding"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetUserBindings(int arg0)
        {
            return SourceService["getUserBindings"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int[] FindUsersWithBinding(string arg0, string arg1)
        {
            return (int[])SourceService["findUsersWithBinding"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetUsidFromPpid(int arg0)
        {
            return (int)SourceService["getUsidFromPpid"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetPpidFromUsid(int arg0)
        {
            return (int)SourceService["getPpidFromUsid"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _checkPhotoForIdentification(string arg0)
        {
            return (int)SourceService["_checkPhotoForIdentification"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _reinforceIdentificationFromPhoto(int arg0, string arg1)
        {
            return (bool)SourceService["_reinforceIdentificationFromPhoto"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _createUserFromPhoto(string arg0)
        {
            return (int)SourceService["_createUserFromPhoto"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _setFocusedUser(int arg0)
        {
            SourceService["_setFocusedUser"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _createUsers(int arg0)
        {
            return (int[])SourceService["_createUsers"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _deleteUser(int arg0)
        {
            return (bool)SourceService["_deleteUser"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _deleteUsers(IEnumerable<int> arg0)
        {
            return (bool)SourceService["_deleteUsers"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _openUserSessions(IEnumerable<int> arg0)
        {
            return (int[])SourceService["_openUserSessions"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _closeUserSessions(IEnumerable<int> arg0)
        {
            return (int[])SourceService["_closeUserSessions"].Call(QiList.Create(arg0));
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _bindUser(int arg0, string arg1, string arg2)
        {
            return (bool)SourceService["_bindUser"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unbindUser(int arg0, string arg1)
        {
            return (bool)SourceService["_unbindUser"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int _getDatabaseVersion()
        {
            return (int)SourceService["_getDatabaseVersion"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool _deleteAllUsers()
        {
            return (bool)SourceService["_deleteAllUsers"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetBindingSources()
        {
            return (string[])SourceService["getBindingSources"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesBindingSourceExist(string arg0)
        {
            return (bool)SourceService["doesBindingSourceExist"].Call(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetUserDataSources()
        {
            return (string[])SourceService["getUserDataSources"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesUserDataSourceExist(string arg0)
        {
            return (bool)SourceService["doesUserDataSourceExist"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void _registerUserDataSource(string arg0, string arg1)
        {
            SourceService["_registerUserDataSource"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _unregisterUserDataSource(string arg0)
        {
            SourceService["_unregisterUserDataSource"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public QiValue GetUserData(int arg0, string arg1, string arg2)
        {
            return SourceService["getUserData"].Call(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public QiValue GetUserData(int arg0, string arg1)
        {
            return SourceService["getUserData"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public void SetUserData(int arg0, string arg1, string arg2, QiAnyValue arg3)
        {
            SourceService["setUserData"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetUserCreationDate(int arg0)
        {
            return (string)SourceService["getUserCreationDate"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetFirstEncounterDate(int arg0)
        {
            return (string)SourceService["getFirstEncounterDate"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetCurrentEncounterDate(int arg0)
        {
            return (string)SourceService["getCurrentEncounterDate"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetLastEncounterDate(int arg0)
        {
            return (string)SourceService["getLastEncounterDate"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetSecondsSinceLastEncounter(int arg0)
        {
            return (int)SourceService["getSecondsSinceLastEncounter"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _getSecondsSinceUserCreation(int arg0)
        {
            return (int)SourceService["_getSecondsSinceUserCreation"].Call(arg0);
        }

    }
}