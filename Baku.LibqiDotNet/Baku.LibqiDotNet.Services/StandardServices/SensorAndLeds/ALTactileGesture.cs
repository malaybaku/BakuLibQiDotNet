using System;

using System.Collections.Generic;
using System.Linq;

//NOTE: This Source was automatically generated using "Baku.LibqiDotNet.ServiceCodeGenerator" project.

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALTactileGesture
	{
		internal ALTactileGesture(IQiSession session)
		{
			Session = session;
		}

        /// <summary>サービスの取得元セッションを指定してサービスを取得します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTactileGesture CreateService(IQiSession session)
		{
			var result = new ALTactileGesture(session);
			result.InitializeService();
			return result;
		}

        /// <summary>
		/// 内部情報が未初期化のサービスを取得します。初期化は<see ref="StartInitialize"/>関数で行います。
		///</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
		public static ALTactileGesture CreateUninitializedService(IQiSession session)
		{
			return new ALTactileGesture(session);
		}

		/// <summary>同期的にネットワーク経由でサービス情報を取得し、初期化します。</summary>
		public void InitializeService()
		{
			if (!IsInitialized)
			{
			    SourceService = Session.GetService("ALTactileGesture");
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

        /// <summary>        Computes 'Hamming distance' between the binary representations of        numbers in pair        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _bit_distance(object arg0)
        {
            return SourceService["_bit_distance"].Call<IQiResult>(arg0);
        }

        /// <summary>        Computes 'Hamming distance' between the binary representations of        numbers in pair        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _bit_distanceAsync(object arg0)
        {
            return SourceService["_bit_distance"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Cancel all futures</summary>
		/// <returns></returns>
        public IQiResult _cancel_futures()
        {
            return SourceService["_cancel_futures"].Call<IQiResult>();
        }

        /// <summary>Cancel all futures</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _cancel_futuresAsync()
        {
            return SourceService["_cancel_futures"].CallAsync<IQiResult>();
        }

        /// <summary>        Given a gesture, check if the active sequence matches it.        Algorithm:        1. Create a list of overlapping pairs from each gesture's sequence        2. Loop through each pair (a,b):           3. If the active sequence matches 'a' in the pair:              4. Check if the active sequence contains the 'b' in the pair                 5a. If True, check if it is within n-1 positions from where 'a'                     was (Where 'n' is the number of bits changed between 'a'                     and 'b')                     6a. If True: goto Step 2 [if last pair; goto Step 7)                     6b. Else: break; fullfill promise as None                 5b. Else: break; fullfill promise as None        7. If all pairs check out and they used all of the active sequence           8. Fullfill promise with the gesture and the difference in length between the              inputted sequence and the matched sequence (i.e. the number of              excess frames)        </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiResult _check_sequence(object arg0, object arg1, object arg2, object arg3)
        {
            return SourceService["_check_sequence"].Call<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary>        Given a gesture, check if the active sequence matches it.        Algorithm:        1. Create a list of overlapping pairs from each gesture's sequence        2. Loop through each pair (a,b):           3. If the active sequence matches 'a' in the pair:              4. Check if the active sequence contains the 'b' in the pair                 5a. If True, check if it is within n-1 positions from where 'a'                     was (Where 'n' is the number of bits changed between 'a'                     and 'b')                     6a. If True: goto Step 2 [if last pair; goto Step 7)                     6b. Else: break; fullfill promise as None                 5b. Else: break; fullfill promise as None        7. If all pairs check out and they used all of the active sequence           8. Fullfill promise with the gesture and the difference in length between the              inputted sequence and the matched sequence (i.e. the number of              excess frames)        </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _check_sequenceAsync(object arg0, object arg1, object arg2, object arg3)
        {
            return SourceService["_check_sequence"].CallAsync<IQiResult>(arg0, arg1, arg2, arg3);
        }

        /// <summary>Clean up/reset after a sequence has been completed</summary>
		/// <returns></returns>
        public IQiResult _clean_up()
        {
            return SourceService["_clean_up"].Call<IQiResult>();
        }

        /// <summary>Clean up/reset after a sequence has been completed</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _clean_upAsync()
        {
            return SourceService["_clean_up"].CallAsync<IQiResult>();
        }

        /// <summary>Clean up/reset after a hold sequence has been completed</summary>
		/// <returns></returns>
        public IQiResult _clean_up_hold()
        {
            return SourceService["_clean_up_hold"].Call<IQiResult>();
        }

        /// <summary>Clean up/reset after a hold sequence has been completed</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _clean_up_holdAsync()
        {
            return SourceService["_clean_up_hold"].CallAsync<IQiResult>();
        }

        /// <summary>Connect to all services required by ALTactileGesture</summary>
		/// <returns></returns>
        public IQiResult _connect_services()
        {
            return SourceService["_connect_services"].Call<IQiResult>();
        }

        /// <summary>Connect to all services required by ALTactileGesture</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _connect_servicesAsync()
        {
            return SourceService["_connect_services"].CallAsync<IQiResult>();
        }

        /// <summary>Init qi.Signals and memory events (for compatibility)</summary>
		/// <returns></returns>
        public IQiResult _connect_signals()
        {
            return SourceService["_connect_signals"].Call<IQiResult>();
        }

        /// <summary>Init qi.Signals and memory events (for compatibility)</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _connect_signalsAsync()
        {
            return SourceService["_connect_signals"].CallAsync<IQiResult>();
        }

        /// <summary>Create gesture name from sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _create_gesture_name(object arg0)
        {
            return SourceService["_create_gesture_name"].Call<IQiResult>(arg0);
        }

        /// <summary>Create gesture name from sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _create_gesture_nameAsync(object arg0)
        {
            return SourceService["_create_gesture_name"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>        Once the hold time has expired:          - Evaluate if the current sequence is a valid hold gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public IQiResult _eval_hold()
        {
            return SourceService["_eval_hold"].Call<IQiResult>();
        }

        /// <summary>        Once the hold time has expired:          - Evaluate if the current sequence is a valid hold gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _eval_holdAsync()
        {
            return SourceService["_eval_hold"].CallAsync<IQiResult>();
        }

        /// <summary>        Once the sequence time has expired:          - Evaluate if the current sequence is a valid gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public IQiResult _eval_sequence()
        {
            return SourceService["_eval_sequence"].Call<IQiResult>();
        }

        /// <summary>        Once the sequence time has expired:          - Evaluate if the current sequence is a valid gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _eval_sequenceAsync()
        {
            return SourceService["_eval_sequence"].CallAsync<IQiResult>();
        }

        /// <summary>Fire signal linked to gesture</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _fire_gesture_signal(object arg0)
        {
            return SourceService["_fire_gesture_signal"].Call<IQiResult>(arg0);
        }

        /// <summary>Fire signal linked to gesture</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _fire_gesture_signalAsync(object arg0)
        {
            return SourceService["_fire_gesture_signal"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Fire signal linked to release of sensors</summary>
		/// <returns></returns>
        public IQiResult _fire_release_signal()
        {
            return SourceService["_fire_release_signal"].Call<IQiResult>();
        }

        /// <summary>Fire signal linked to release of sensors</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _fire_release_signalAsync()
        {
            return SourceService["_fire_release_signal"].CallAsync<IQiResult>();
        }

        /// <summary>        On any head sensor change, acquire lock and starts e_sim (settling)        timer.        Note: Only the first signal starts the timer and all others are        debounced.        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _on_sensor_change(object arg0)
        {
            return SourceService["_on_sensor_change"].Call<IQiResult>(arg0);
        }

        /// <summary>        On any head sensor change, acquire lock and starts e_sim (settling)        timer.        Note: Only the first signal starts the timer and all others are        debounced.        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _on_sensor_changeAsync(object arg0)
        {
            return SourceService["_on_sensor_change"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>        Once the settling time (e_sim) is over:          - Read from head sensors.          - Store pattern          - Start hold and sequential timers        </summary>
		/// <returns></returns>
        public IQiResult _read_sensors()
        {
            return SourceService["_read_sensors"].Call<IQiResult>();
        }

        /// <summary>        Once the settling time (e_sim) is over:          - Read from head sensors.          - Store pattern          - Start hold and sequential timers        </summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _read_sensorsAsync()
        {
            return SourceService["_read_sensors"].CallAsync<IQiResult>();
        }

        /// <summary>        Compare inputted sequence to all gestures to find match        Algorithm:        1. async call _check_sequence on for all gestures           (i.e. gestures that match the current hold status and are not unset custom gestures)              -&gt; _check_sequence() will fullfill promise with the gesture if matched; else None        2. Build list of all futures whose value is a matched sequence        3. Return the gesture whose match is the closest the sequence prototype           it matched (i.e. smallest difference)        </summary>
		/// <returns></returns>
        public IQiResult _search_gestures()
        {
            return SourceService["_search_gestures"].Call<IQiResult>();
        }

        /// <summary>        Compare inputted sequence to all gestures to find match        Algorithm:        1. async call _check_sequence on for all gestures           (i.e. gestures that match the current hold status and are not unset custom gestures)              -&gt; _check_sequence() will fullfill promise with the gesture if matched; else None        2. Build list of all futures whose value is a matched sequence        3. Return the gesture whose match is the closest the sequence prototype           it matched (i.e. smallest difference)        </summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _search_gesturesAsync()
        {
            return SourceService["_search_gestures"].CallAsync<IQiResult>();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _set_hold_time(object arg0)
        {
            return SourceService["_set_hold_time"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _set_hold_timeAsync(object arg0)
        {
            return SourceService["_set_hold_time"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _set_sequence_time(object arg0)
        {
            return SourceService["_set_sequence_time"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _set_sequence_timeAsync(object arg0)
        {
            return SourceService["_set_sequence_time"].CallAsync<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _set_settle_time(object arg0)
        {
            return SourceService["_set_settle_time"].Call<IQiResult>(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _set_settle_timeAsync(object arg0)
        {
            return SourceService["_set_settle_time"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Start subscriptions to head sensors</summary>
		/// <returns></returns>
        public IQiResult _start()
        {
            return SourceService["_start"].Call<IQiResult>();
        }

        /// <summary>Start subscriptions to head sensors</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _startAsync()
        {
            return SourceService["_start"].CallAsync<IQiResult>();
        }

        /// <summary>Starts a timer that waits for the hold period to evaluate if there is a        valid hold sequence</summary>
		/// <returns></returns>
        public IQiResult _start_d_hold_timer()
        {
            return SourceService["_start_d_hold_timer"].Call<IQiResult>();
        }

        /// <summary>Starts a timer that waits for the hold period to evaluate if there is a        valid hold sequence</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _start_d_hold_timerAsync()
        {
            return SourceService["_start_d_hold_timer"].CallAsync<IQiResult>();
        }

        /// <summary>Starts a timer that determines if events in a sequence happen soon        enough for them to be considered in teh current sequence.</summary>
		/// <returns></returns>
        public IQiResult _start_e_seq_timer()
        {
            return SourceService["_start_e_seq_timer"].Call<IQiResult>();
        }

        /// <summary>Starts a timer that determines if events in a sequence happen soon        enough for them to be considered in teh current sequence.</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _start_e_seq_timerAsync()
        {
            return SourceService["_start_e_seq_timer"].CallAsync<IQiResult>();
        }

        /// <summary>Starts timer that waits for a setteling time before reading the sensors</summary>
		/// <returns></returns>
        public IQiResult _start_e_sim_timer()
        {
            return SourceService["_start_e_sim_timer"].Call<IQiResult>();
        }

        /// <summary>Starts timer that waits for a setteling time before reading the sensors</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _start_e_sim_timerAsync()
        {
            return SourceService["_start_e_sim_timer"].CallAsync<IQiResult>();
        }

        /// <summary>Unsubscribe from head sensors</summary>
		/// <returns></returns>
        public IQiResult _stop()
        {
            return SourceService["_stop"].Call<IQiResult>();
        }

        /// <summary>Unsubscribe from head sensors</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _stopAsync()
        {
            return SourceService["_stop"].CallAsync<IQiResult>();
        }

        /// <summary>Sync with preferences. This includes: Settle Time, Hold Time and Sequence Time</summary>
		/// <returns></returns>
        public IQiResult _sync_preferences()
        {
            return SourceService["_sync_preferences"].Call<IQiResult>();
        }

        /// <summary>Sync with preferences. This includes: Settle Time, Hold Time and Sequence Time</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> _sync_preferencesAsync()
        {
            return SourceService["_sync_preferences"].CallAsync<IQiResult>();
        }

        /// <summary>Validate a requested gesture sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult _validate_sequence(object arg0)
        {
            return SourceService["_validate_sequence"].Call<IQiResult>(arg0);
        }

        /// <summary>Validate a requested gesture sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> _validate_sequenceAsync(object arg0)
        {
            return SourceService["_validate_sequence"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: List of strings that represent the        sequence of the desired gesture. For example, SingleFront        would be the following: ['000', '100', '000']. NOTE: All        sequences must start with '000' and all non-hold sequences        must end with '000'. Hold gestures should end with the touch        sequence you will be holding. For example, a SingleFrontHold        would be the following: ['000', '100'].        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string CreateGesture(IEnumerable<string> arg0)
        {
            return SourceService["createGesture"].Call<string>(arg0);
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: List of strings that represent the        sequence of the desired gesture. For example, SingleFront        would be the following: ['000', '100', '000']. NOTE: All        sequences must start with '000' and all non-hold sequences        must end with '000'. Hold gestures should end with the touch        sequence you will be holding. For example, a SingleFrontHold        would be the following: ['000', '100'].        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> CreateGestureAsync(IEnumerable<string> arg0)
        {
            return SourceService["createGesture"].CallAsync<string>(arg0);
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: Comma-separated string that represents        the sequence of the desired gesture. For example, SingleFront        would be the following: &quot;000,100,000&quot;. NOTE: All sequences        must start with '000' and all non-hold sequences must end with        '000'. Hold gestures should end with the touch sequence you        will be holding. For example, a SingleFrontHold would be the        following: &quot;000,100&quot;.        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string CreateGesture(string arg0)
        {
            return SourceService["createGesture"].Call<string>(arg0);
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: Comma-separated string that represents        the sequence of the desired gesture. For example, SingleFront        would be the following: &quot;000,100,000&quot;. NOTE: All sequences        must start with '000' and all non-hold sequences must end with        '000'. Hold gestures should end with the touch sequence you        will be holding. For example, a SingleFrontHold would be the        following: &quot;000,100&quot;.        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string> CreateGestureAsync(string arg0)
        {
            return SourceService["createGesture"].CallAsync<string>(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetGesture(IEnumerable<string> arg0)
        {
            return SourceService["getGesture"].Call<IQiResult>(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetGestureAsync(IEnumerable<string> arg0)
        {
            return SourceService["getGesture"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiResult GetGesture(string arg0)
        {
            return SourceService["getGesture"].Call<IQiResult>(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetGestureAsync(string arg0)
        {
            return SourceService["getGesture"].CallAsync<IQiResult>(arg0);
        }

        /// <summary>Get all gestures that have been defined in the system        :returns: Dictionary (Map&lt;String, List&lt;String&gt;&gt;) of all gestures</summary>
		/// <returns></returns>
        public IQiResult GetGestures()
        {
            return SourceService["getGestures"].Call<IQiResult>();
        }

        /// <summary>Get all gestures that have been defined in the system        :returns: Dictionary (Map&lt;String, List&lt;String&gt;&gt;) of all gestures</summary>
		/// <returns></returns>
        public IQiFuture<IQiResult> GetGesturesAsync()
        {
            return SourceService["getGestures"].CallAsync<IQiResult>();
        }

        /// <summary>Get the sequence associated with a gesture name        :param gesture_name: Name of gesture you want the sequence of        :returns: Sequence (as list of strings) if it exists, None otherwise        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetSequence(string arg0)
        {
            return SourceService["getSequence"].Call<string[]>(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param gesture_name: Name of gesture you want the sequence of        :returns: Sequence (as list of strings) if it exists, None otherwise        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<string[]> GetSequenceAsync(string arg0)
        {
            return SourceService["getSequence"].CallAsync<string[]>(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetHoldTime(float arg0)
        {
            return SourceService["setHoldTime"].Call<bool>(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetHoldTimeAsync(float arg0)
        {
            return SourceService["setHoldTime"].CallAsync<bool>(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetHoldTime(string arg0)
        {
            return SourceService["setHoldTime"].Call<bool>(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetHoldTimeAsync(string arg0)
        {
            return SourceService["setHoldTime"].CallAsync<bool>(arg0);
        }

        /// <summary>Update length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSequenceTime(float arg0)
        {
            return SourceService["setSequenceTime"].Call<bool>(arg0);
        }

        /// <summary>Update length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetSequenceTimeAsync(float arg0)
        {
            return SourceService["setSequenceTime"].CallAsync<bool>(arg0);
        }

        /// <summary>Set length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSequenceTime(string arg0)
        {
            return SourceService["setSequenceTime"].Call<bool>(arg0);
        }

        /// <summary>Set length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetSequenceTimeAsync(string arg0)
        {
            return SourceService["setSequenceTime"].CallAsync<bool>(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSettleTime(float arg0)
        {
            return SourceService["setSettleTime"].Call<bool>(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetSettleTimeAsync(float arg0)
        {
            return SourceService["setSettleTime"].CallAsync<bool>(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSettleTime(string arg0)
        {
            return SourceService["setSettleTime"].Call<bool>(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public IQiFuture<bool> SetSettleTimeAsync(string arg0)
        {
            return SourceService["setSettleTime"].CallAsync<bool>(arg0);
        }

    }
}