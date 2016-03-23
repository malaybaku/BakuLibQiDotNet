using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary></summary>
    public class ALTactileGesture
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALTactileGesture(QiSession session)
        {
            SourceService = session.GetService("ALTactileGesture");
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

        /// <summary>        Computes 'Hamming distance' between the binary representations of        numbers in pair        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _bit_distance(QiAnyValue arg0)
        {
            return SourceService["_bit_distance"].Call(arg0);
        }

        /// <summary>Cancel all futures</summary>
		/// <returns></returns>
        public QiValue _cancel_futures()
        {
            return SourceService["_cancel_futures"].Call();
        }

        /// <summary>        Given a gesture, check if the active sequence matches it.        Algorithm:        1. Create a list of overlapping pairs from each gesture's sequence        2. Loop through each pair (a,b):           3. If the active sequence matches 'a' in the pair:              4. Check if the active sequence contains the 'b' in the pair                 5a. If True, check if it is within n-1 positions from where 'a'                     was (Where 'n' is the number of bits changed between 'a'                     and 'b')                     6a. If True: goto Step 2 [if last pair; goto Step 7)                     6b. Else: break; fullfill promise as None                 5b. Else: break; fullfill promise as None        7. If all pairs check out and they used all of the active sequence           8. Fullfill promise with the gesture and the difference in length between the              inputted sequence and the matched sequence (i.e. the number of              excess frames)        </summary>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <returns></returns>
        public QiValue _check_sequence(QiAnyValue arg0, QiAnyValue arg1, QiAnyValue arg2, QiAnyValue arg3)
        {
            return SourceService["_check_sequence"].Call(arg0, arg1, arg2, arg3);
        }

        /// <summary>Clean up/reset after a sequence has been completed</summary>
		/// <returns></returns>
        public QiValue _clean_up()
        {
            return SourceService["_clean_up"].Call();
        }

        /// <summary>Clean up/reset after a hold sequence has been completed</summary>
		/// <returns></returns>
        public QiValue _clean_up_hold()
        {
            return SourceService["_clean_up_hold"].Call();
        }

        /// <summary>Connect to all services required by ALTactileGesture</summary>
		/// <returns></returns>
        public QiValue _connect_services()
        {
            return SourceService["_connect_services"].Call();
        }

        /// <summary>Init qi.Signals and memory events (for compatibility)</summary>
		/// <returns></returns>
        public QiValue _connect_signals()
        {
            return SourceService["_connect_signals"].Call();
        }

        /// <summary>Create gesture name from sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _create_gesture_name(QiAnyValue arg0)
        {
            return SourceService["_create_gesture_name"].Call(arg0);
        }

        /// <summary>        Once the hold time has expired:          - Evaluate if the current sequence is a valid hold gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public QiValue _eval_hold()
        {
            return SourceService["_eval_hold"].Call();
        }

        /// <summary>        Once the sequence time has expired:          - Evaluate if the current sequence is a valid gesture          - Fire gesture signal (if valid)          - Reset for next touch input        </summary>
		/// <returns></returns>
        public QiValue _eval_sequence()
        {
            return SourceService["_eval_sequence"].Call();
        }

        /// <summary>Fire signal linked to gesture</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _fire_gesture_signal(QiAnyValue arg0)
        {
            return SourceService["_fire_gesture_signal"].Call(arg0);
        }

        /// <summary>Fire signal linked to release of sensors</summary>
		/// <returns></returns>
        public QiValue _fire_release_signal()
        {
            return SourceService["_fire_release_signal"].Call();
        }

        /// <summary>        On any head sensor change, acquire lock and starts e_sim (settling)        timer.        Note: Only the first signal starts the timer and all others are        debounced.        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _on_sensor_change(QiAnyValue arg0)
        {
            return SourceService["_on_sensor_change"].Call(arg0);
        }

        /// <summary>        Once the settling time (e_sim) is over:          - Read from head sensors.          - Store pattern          - Start hold and sequential timers        </summary>
		/// <returns></returns>
        public QiValue _read_sensors()
        {
            return SourceService["_read_sensors"].Call();
        }

        /// <summary>        Compare inputted sequence to all gestures to find match        Algorithm:        1. async call _check_sequence on for all gestures           (i.e. gestures that match the current hold status and are not unset custom gestures)              -&gt; _check_sequence() will fullfill promise with the gesture if matched; else None        2. Build list of all futures whose value is a matched sequence        3. Return the gesture whose match is the closest the sequence prototype           it matched (i.e. smallest difference)        </summary>
		/// <returns></returns>
        public QiValue _search_gestures()
        {
            return SourceService["_search_gestures"].Call();
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _set_hold_time(QiAnyValue arg0)
        {
            return SourceService["_set_hold_time"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _set_sequence_time(QiAnyValue arg0)
        {
            return SourceService["_set_sequence_time"].Call(arg0);
        }

        /// <summary></summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _set_settle_time(QiAnyValue arg0)
        {
            return SourceService["_set_settle_time"].Call(arg0);
        }

        /// <summary>Start subscriptions to head sensors</summary>
		/// <returns></returns>
        public QiValue _start()
        {
            return SourceService["_start"].Call();
        }

        /// <summary>Starts a timer that waits for the hold period to evaluate if there is a        valid hold sequence</summary>
		/// <returns></returns>
        public QiValue _start_d_hold_timer()
        {
            return SourceService["_start_d_hold_timer"].Call();
        }

        /// <summary>Starts a timer that determines if events in a sequence happen soon        enough for them to be considered in teh current sequence.</summary>
		/// <returns></returns>
        public QiValue _start_e_seq_timer()
        {
            return SourceService["_start_e_seq_timer"].Call();
        }

        /// <summary>Starts timer that waits for a setteling time before reading the sensors</summary>
		/// <returns></returns>
        public QiValue _start_e_sim_timer()
        {
            return SourceService["_start_e_sim_timer"].Call();
        }

        /// <summary>Unsubscribe from head sensors</summary>
		/// <returns></returns>
        public QiValue _stop()
        {
            return SourceService["_stop"].Call();
        }

        /// <summary>Sync with preferences. This includes: Settle Time, Hold Time and Sequence Time</summary>
		/// <returns></returns>
        public QiValue _sync_preferences()
        {
            return SourceService["_sync_preferences"].Call();
        }

        /// <summary>Validate a requested gesture sequence</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue _validate_sequence(QiAnyValue arg0)
        {
            return SourceService["_validate_sequence"].Call(arg0);
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: List of strings that represent the        sequence of the desired gesture. For example, SingleFront        would be the following: ['000', '100', '000']. NOTE: All        sequences must start with '000' and all non-hold sequences        must end with '000'. Hold gestures should end with the touch        sequence you will be holding. For example, a SingleFrontHold        would be the following: ['000', '100'].        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string CreateGesture(IEnumerable<string> arg0)
        {
            return (string)SourceService["createGesture"].Call(QiList.Create(arg0));
        }

        /// <summary>Define touch gesture.        :param sensor_sequence: Comma-separated string that represents        the sequence of the desired gesture. For example, SingleFront        would be the following: &quot;000,100,000&quot;. NOTE: All sequences        must start with '000' and all non-hold sequences must end with        '000'. Hold gestures should end with the touch sequence you        will be holding. For example, a SingleFrontHold would be the        following: &quot;000,100&quot;.        :returns: If sequence is valid, the name of gesture to listen        for, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string CreateGesture(string arg0)
        {
            return (string)SourceService["createGesture"].Call(arg0);
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetGesture(IEnumerable<string> arg0)
        {
            return SourceService["getGesture"].Call(QiList.Create(arg0));
        }

        /// <summary>Get the sequence associated with a gesture name        :param sequence: Sequence you want the gesture name of        :returns: Sequence (as list of strings) if it exists, None otherwise</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public QiValue GetGesture(string arg0)
        {
            return SourceService["getGesture"].Call(arg0);
        }

        /// <summary>Get all gestures that have been defined in the system        :returns: Dictionary (Map&lt;String, List&lt;String&gt;&gt;) of all gestures</summary>
		/// <returns></returns>
        public QiValue GetGestures()
        {
            return SourceService["getGestures"].Call();
        }

        /// <summary>Get the sequence associated with a gesture name        :param gesture_name: Name of gesture you want the sequence of        :returns: Sequence (as list of strings) if it exists, None otherwise        </summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public string[] GetSequence(string arg0)
        {
            return (string[])SourceService["getSequence"].Call(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetHoldTime(float arg0)
        {
            return (bool)SourceService["setHoldTime"].Call(arg0);
        }

        /// <summary>Set length of hold time.        :param hold_time: Desired hold time, in seconds (Default: 0.8s)        :returns: True if hold time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetHoldTime(string arg0)
        {
            return (bool)SourceService["setHoldTime"].Call(arg0);
        }

        /// <summary>Update length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSequenceTime(float arg0)
        {
            return (bool)SourceService["setSequenceTime"].Call(arg0);
        }

        /// <summary>Set length of sequence time.        :param sequence_time: Desired sequence time, in seconds (Default: 0.2s)        :returns: True if sequence time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSequenceTime(string arg0)
        {
            return (bool)SourceService["setSequenceTime"].Call(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSettleTime(float arg0)
        {
            return (bool)SourceService["setSettleTime"].Call(arg0);
        }

        /// <summary>Update length of settling time.        :param settle_time: Desired settling time, in seconds (Default: 0.04s)        :returns: True if settle time successfully updated, RuntimeError otherwise.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public bool SetSettleTime(string arg0)
        {
            return (bool)SourceService["setSettleTime"].Call(arg0);
        }

    }
}