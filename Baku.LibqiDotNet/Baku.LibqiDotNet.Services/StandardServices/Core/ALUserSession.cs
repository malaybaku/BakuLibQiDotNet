using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALUserSession
	{
		internal ALUserSession(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALUserSession CreateService(IQiSession session)
		{
			var result = new ALUserSession(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALUserSession CreateUninitializedService(IQiSession session)
		{
			return new ALUserSession(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALUserSession");
			}
		}

		/// <summary>
		/// ネットワーク経由でサービス情報を取得し、初期化する処理を非同期的に開始します。
		/// 初期化の完了は<see ref="IsInitialized"/>プロパティあるいは<see ref="Initialized"/>イベントを通じて行います。
		///</summary>
		public void StartInitializeService()
		{
			if (!IsInitialized)
			{

#if NET35
                new System.Threading.Thread(this.InitializeService).Start();
#else
                new System.Threading.Tasks.Task(this.InitializeService).Start();
#endif
			}
		}

		private readonly object _sourceServiceLock = new object();
		private IQiObject _sourceService;

        /// <summary>コード生成によってラップされる前のサービスを表すオブジェクトを取得します。</summary>
        public IQiObject SourceService 
		{ 
			get { lock (_sourceServiceLock) { return _sourceService; } }
			private set 
			{ 
				lock (_sourceServiceLock) 
				{ 
					_sourceService = value; 
				}
				if (value != null)
				{
					IsInitialized = true;
					Initialized?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>このサービスに関連付けられたセッション情報を取得します。</summary>
		public IQiSession Session { get; }

		/// <summary>このサービスが初期化済みであるかを取得します。</summary>
		public bool IsInitialized { get; private set; }

		/// <summary>このサービスの初期化が完了すると発生します。</summary>
		public event EventHandler Initialized;

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public ulong RegisterEvent(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["registerEvent"].Call<ulong>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<ulong> RegisterEventAsync(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["registerEvent"].CallAsync<ulong>(arg0, arg1, arg2);
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
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture UnregisterEventAsync(uint arg0, uint arg1, ulong arg2)
        {
            return SourceService["unregisterEvent"].CallAsync(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult MetaObject(uint arg0)
        {
            return SourceService["metaObject"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> MetaObjectAsync(uint arg0)
        {
            return SourceService["metaObject"].CallAsync<IQiResult>(arg0);
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
        public IQiFuture TerminateAsync(uint arg0)
        {
            return SourceService["terminate"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult Property(object arg0)
        {
            return SourceService["property"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> PropertyAsync(object arg0)
        {
            return SourceService["property"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public void SetProperty(object arg0, object arg1)
        {
            SourceService["setProperty"].Call(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture SetPropertyAsync(object arg0, object arg1)
        {
            return SourceService["setProperty"].CallAsync(arg0, arg1);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] Properties()
        {
            return SourceService["properties"].Call<string[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string[]> PropertiesAsync()
        {
            return SourceService["properties"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public ulong RegisterEventWithSignature(uint arg0, uint arg1, ulong arg2, string arg3)
        {
            return SourceService["registerEventWithSignature"].Call<ulong>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<ulong> RegisterEventWithSignatureAsync(uint arg0, uint arg1, ulong arg2, string arg3)
        {
            return SourceService["registerEventWithSignature"].CallAsync<ulong>(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsStatsEnabled()
        {
            return SourceService["isStatsEnabled"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> IsStatsEnabledAsync()
        {
            return SourceService["isStatsEnabled"].CallAsync<bool>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void EnableStats(bool arg0)
        {
            SourceService["enableStats"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture EnableStatsAsync(bool arg0)
        {
            return SourceService["enableStats"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiResult Stats()
        {
            return SourceService["stats"].Call<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> StatsAsync()
        {
            return SourceService["stats"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public void ClearStats()
        {
            SourceService["clearStats"].Call();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture ClearStatsAsync()
        {
            return SourceService["clearStats"].CallAsync();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool IsTraceEnabled()
        {
            return SourceService["isTraceEnabled"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> IsTraceEnabledAsync()
        {
            return SourceService["isTraceEnabled"].CallAsync<bool>();
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
        public IQiFuture EnableTraceAsync(bool arg0)
        {
            return SourceService["enableTrace"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesUserExist(int arg0)
        {
            return SourceService["doesUserExist"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> DoesUserExistAsync(int arg0)
        {
            return SourceService["doesUserExist"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoUsersExist(IEnumerable<int> arg0)
        {
            return SourceService["doUsersExist"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> DoUsersExistAsync(IEnumerable<int> arg0)
        {
            return SourceService["doUsersExist"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetUserList()
        {
            return SourceService["getUserList"].Call<int[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int[]> GetUserListAsync()
        {
            return SourceService["getUserList"].CallAsync<int[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetNumUsers()
        {
            return SourceService["getNumUsers"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetNumUsersAsync()
        {
            return SourceService["getNumUsers"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int GetFocusedUser()
        {
            return SourceService["getFocusedUser"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> GetFocusedUserAsync()
        {
            return SourceService["getFocusedUser"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetOpenUserSessions()
        {
            return SourceService["getOpenUserSessions"].Call<int[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int[]> GetOpenUserSessionsAsync()
        {
            return SourceService["getOpenUserSessions"].CallAsync<int[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsUserSessionOpen(int arg0)
        {
            return SourceService["isUserSessionOpen"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> IsUserSessionOpenAsync(int arg0)
        {
            return SourceService["isUserSessionOpen"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool AreUserSessionsOpen(IEnumerable<int> arg0)
        {
            return SourceService["areUserSessionsOpen"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> AreUserSessionsOpenAsync(IEnumerable<int> arg0)
        {
            return SourceService["areUserSessionsOpen"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool IsUserPermanent(int arg0)
        {
            return SourceService["isUserPermanent"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> IsUserPermanentAsync(int arg0)
        {
            return SourceService["isUserPermanent"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool AreUsersPermanent(IEnumerable<int> arg0)
        {
            return SourceService["areUsersPermanent"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> AreUsersPermanentAsync(IEnumerable<int> arg0)
        {
            return SourceService["areUsersPermanent"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int[] GetPermanentUserList()
        {
            return SourceService["getPermanentUserList"].Call<int[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int[]> GetPermanentUserListAsync()
        {
            return SourceService["getPermanentUserList"].CallAsync<int[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _rememberUserPermanently(int arg0)
        {
            return SourceService["_rememberUserPermanently"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _rememberUserPermanentlyAsync(int arg0)
        {
            return SourceService["_rememberUserPermanently"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _forgetPermanentUser(int arg0)
        {
            return SourceService["_forgetPermanentUser"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _forgetPermanentUserAsync(int arg0)
        {
            return SourceService["_forgetPermanentUser"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetBindingList()
        {
            return SourceService["getBindingList"].Call<string[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetBindingListAsync()
        {
            return SourceService["getBindingList"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesBindingExist(string arg0)
        {
            return SourceService["doesBindingExist"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> DoesBindingExistAsync(string arg0)
        {
            return SourceService["doesBindingExist"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public string GetUserBinding(int arg0, string arg1)
        {
            return SourceService["getUserBinding"].Call<string>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<string> GetUserBindingAsync(int arg0, string arg1)
        {
            return SourceService["getUserBinding"].CallAsync<string>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetUserBindings(int arg0)
        {
            return SourceService["getUserBindings"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetUserBindingsAsync(int arg0)
        {
            return SourceService["getUserBindings"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public int[] FindUsersWithBinding(string arg0, string arg1)
        {
            return SourceService["findUsersWithBinding"].Call<int[]>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<int[]> FindUsersWithBindingAsync(string arg0, string arg1)
        {
            return SourceService["findUsersWithBinding"].CallAsync<int[]>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetUsidFromPpid(int arg0)
        {
            return SourceService["getUsidFromPpid"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetUsidFromPpidAsync(int arg0)
        {
            return SourceService["getUsidFromPpid"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetPpidFromUsid(int arg0)
        {
            return SourceService["getPpidFromUsid"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetPpidFromUsidAsync(int arg0)
        {
            return SourceService["getPpidFromUsid"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _checkPhotoForIdentification(string arg0)
        {
            return SourceService["_checkPhotoForIdentification"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _checkPhotoForIdentificationAsync(string arg0)
        {
            return SourceService["_checkPhotoForIdentification"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _reinforceIdentificationFromPhoto(int arg0, string arg1)
        {
            return SourceService["_reinforceIdentificationFromPhoto"].Call<bool>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _reinforceIdentificationFromPhotoAsync(int arg0, string arg1)
        {
            return SourceService["_reinforceIdentificationFromPhoto"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _createUserFromPhoto(string arg0)
        {
            return SourceService["_createUserFromPhoto"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _createUserFromPhotoAsync(string arg0)
        {
            return SourceService["_createUserFromPhoto"].CallAsync<int>(arg0);
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
        public IQiFuture _setFocusedUserAsync(int arg0)
        {
            return SourceService["_setFocusedUser"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _createUsers(int arg0)
        {
            return SourceService["_createUsers"].Call<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int[]> _createUsersAsync(int arg0)
        {
            return SourceService["_createUsers"].CallAsync<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _deleteUser(int arg0)
        {
            return SourceService["_deleteUser"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _deleteUserAsync(int arg0)
        {
            return SourceService["_deleteUser"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool _deleteUsers(IEnumerable<int> arg0)
        {
            return SourceService["_deleteUsers"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> _deleteUsersAsync(IEnumerable<int> arg0)
        {
            return SourceService["_deleteUsers"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _openUserSessions(IEnumerable<int> arg0)
        {
            return SourceService["_openUserSessions"].Call<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int[]> _openUserSessionsAsync(IEnumerable<int> arg0)
        {
            return SourceService["_openUserSessions"].CallAsync<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int[] _closeUserSessions(IEnumerable<int> arg0)
        {
            return SourceService["_closeUserSessions"].Call<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int[]> _closeUserSessionsAsync(IEnumerable<int> arg0)
        {
            return SourceService["_closeUserSessions"].CallAsync<int[]>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public bool _bindUser(int arg0, string arg1, string arg2)
        {
            return SourceService["_bindUser"].Call<bool>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<bool> _bindUserAsync(int arg0, string arg1, string arg2)
        {
            return SourceService["_bindUser"].CallAsync<bool>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public bool _unbindUser(int arg0, string arg1)
        {
            return SourceService["_unbindUser"].Call<bool>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<bool> _unbindUserAsync(int arg0, string arg1)
        {
            return SourceService["_unbindUser"].CallAsync<bool>(arg0, arg1);
        }

        /// <summary></summary>
		/// <returns></returns>
        public int _getDatabaseVersion()
        {
            return SourceService["_getDatabaseVersion"].Call<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<int> _getDatabaseVersionAsync()
        {
            return SourceService["_getDatabaseVersion"].CallAsync<int>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public bool _deleteAllUsers()
        {
            return SourceService["_deleteAllUsers"].Call<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<bool> _deleteAllUsersAsync()
        {
            return SourceService["_deleteAllUsers"].CallAsync<bool>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetBindingSources()
        {
            return SourceService["getBindingSources"].Call<string[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetBindingSourcesAsync()
        {
            return SourceService["getBindingSources"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesBindingSourceExist(string arg0)
        {
            return SourceService["doesBindingSourceExist"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> DoesBindingSourceExistAsync(string arg0)
        {
            return SourceService["doesBindingSourceExist"].CallAsync<bool>(arg0);
        }

        /// <summary></summary>
		/// <returns></returns>
        public string[] GetUserDataSources()
        {
            return SourceService["getUserDataSources"].Call<string[]>();
        }

        /// <summary></summary>
		/// <returns></returns>
        public IQiFuture<string[]> GetUserDataSourcesAsync()
        {
            return SourceService["getUserDataSources"].CallAsync<string[]>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool DoesUserDataSourceExist(string arg0)
        {
            return SourceService["doesUserDataSourceExist"].Call<bool>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> DoesUserDataSourceExistAsync(string arg0)
        {
            return SourceService["doesUserDataSourceExist"].CallAsync<bool>(arg0);
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
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture _registerUserDataSourceAsync(string arg0, string arg1)
        {
            return SourceService["_registerUserDataSource"].CallAsync(arg0, arg1);
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
		/// <returns></returns>
        public IQiFuture _unregisterUserDataSourceAsync(string arg0)
        {
            return SourceService["_unregisterUserDataSource"].CallAsync(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiResult GetUserData(int arg0, string arg1, string arg2)
        {
            return SourceService["getUserData"].Call<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetUserDataAsync(int arg0, string arg1, string arg2)
        {
            return SourceService["getUserData"].CallAsync<IQiResult>(arg0, arg1, arg2);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiResult GetUserData(int arg0, string arg1)
        {
            return SourceService["getUserData"].Call<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetUserDataAsync(int arg0, string arg1)
        {
            return SourceService["getUserData"].CallAsync<IQiResult>(arg0, arg1);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public void SetUserData(int arg0, string arg1, string arg2, object arg3)
        {
            SourceService["setUserData"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture SetUserDataAsync(int arg0, string arg1, string arg2, object arg3)
        {
            return SourceService["setUserData"].CallAsync(arg0, arg1, arg2, arg3);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetUserCreationDate(int arg0)
        {
            return SourceService["getUserCreationDate"].Call<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetUserCreationDateAsync(int arg0)
        {
            return SourceService["getUserCreationDate"].CallAsync<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetFirstEncounterDate(int arg0)
        {
            return SourceService["getFirstEncounterDate"].Call<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetFirstEncounterDateAsync(int arg0)
        {
            return SourceService["getFirstEncounterDate"].CallAsync<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetCurrentEncounterDate(int arg0)
        {
            return SourceService["getCurrentEncounterDate"].Call<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetCurrentEncounterDateAsync(int arg0)
        {
            return SourceService["getCurrentEncounterDate"].CallAsync<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string GetLastEncounterDate(int arg0)
        {
            return SourceService["getLastEncounterDate"].Call<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> GetLastEncounterDateAsync(int arg0)
        {
            return SourceService["getLastEncounterDate"].CallAsync<string>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int GetSecondsSinceLastEncounter(int arg0)
        {
            return SourceService["getSecondsSinceLastEncounter"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> GetSecondsSinceLastEncounterAsync(int arg0)
        {
            return SourceService["getSecondsSinceLastEncounter"].CallAsync<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public int _getSecondsSinceUserCreation(int arg0)
        {
            return SourceService["_getSecondsSinceUserCreation"].Call<int>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<int> _getSecondsSinceUserCreationAsync(int arg0)
        {
            return SourceService["_getSecondsSinceUserCreation"].CallAsync<int>(arg0);
        }

    }
}