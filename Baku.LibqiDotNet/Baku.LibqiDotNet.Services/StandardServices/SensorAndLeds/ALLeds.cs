using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>This module allows you to control NAO's LEDs. It provides simple ways of setting or fading the intensity of single LEDs and groups of LEDs. Groups of LEDs typically include face LEDs, ear LEDs etc. It is also possible to control each LED separately (for example, each of the 8 LEDs in one NAO's eyes).There are three primary colors of LEDs available - red, green and blue, so it is possible to combine them to obtain different colors. The ears contain blue LEDs only.It is possible to control the LED's intensity (between 0 and 100%).</summary>
    public class ALLeds
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALLeds(QiSession session)
        {
            SourceService = session.GetService("ALLeds");
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

        /// <summary>Makes a group name for ease of setting multiple LEDs.</summary>
		/// <param name="arg0_groupName">The name of the group.</param>
		/// <param name="arg1_ledNames">A vector of the names of the LEDs in the group.</param>
		/// <returns></returns>
        public void CreateGroup(string arg0_groupName, IEnumerable<string> arg1_ledNames)
        {
            SourceService["createGroup"].Call(arg0_groupName, QiList.Create(arg1_ledNames));
        }

        /// <summary>An animation to show a direction with the ears.</summary>
		/// <param name="arg0_degrees">The angle you want to show in degrees (int). 0 is up, 90 is forwards, 180 is down and 270 is back.</param>
		/// <param name="arg1_duration">The duration in seconds of the animation.</param>
		/// <param name="arg2_leaveOnAtEnd">If true the last led is left on at the end of the animation.</param>
		/// <returns></returns>
        public void EarLedsSetAngle(int arg0_degrees, float arg1_duration, bool arg2_leaveOnAtEnd)
        {
            SourceService["earLedsSetAngle"].Call(arg0_degrees, arg1_duration, arg2_leaveOnAtEnd);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs within a given time.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <param name="arg2_duration">The duration of the fade in seconds</param>
		/// <returns></returns>
        public void Fade(string arg0_name, float arg1_intensity, float arg2_duration)
        {
            SourceService["fade"].Call(arg0_name, arg1_intensity, arg2_duration);
        }

        /// <summary>Chain a list of color for a device, as the motion.doMove command.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgbList">List of RGB led value, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_timeList">List of time to go to given intensity.</param>
		/// <returns></returns>
        public void FadeListRGB(string arg0_name, QiAnyValue arg1_rgbList, QiAnyValue arg2_timeList)
        {
            SourceService["fadeListRGB"].Call(arg0_name, arg1_rgbList, arg2_timeList);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_red">the intensity of red channel (0-1).</param>
		/// <param name="arg2_green">the intensity of green channel (0-1).</param>
		/// <param name="arg3_blue">the intensity of blue channel (0-1).</param>
		/// <param name="arg4_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, float arg1_red, float arg2_green, float arg3_blue, float arg4_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_red, arg2_green, arg3_blue, arg4_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_colorName">the name of the color (supported colors: &quot;white&quot;, &quot;red&quot;, &quot;green&quot;, &quot;blue&quot;, &quot;yellow&quot;, &quot;magenta&quot;, &quot;cyan&quot;)</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, string arg1_colorName, float arg2_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_colorName, arg2_duration);
        }

        /// <summary>Sets the color of an RGB led.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_rgb">The RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg2_duration">Time used to fade in seconds.</param>
		/// <returns></returns>
        public void FadeRGB(string arg0_name, int arg1_rgb, float arg2_duration)
        {
            SourceService["fadeRGB"].Call(arg0_name, arg1_rgb, arg2_duration);
        }

        /// <summary>Resets the state of the leds to default (for ex, eye LEDs are white and fully on by default).</summary>
		/// <param name="arg0_name">The name of the LED or Group (for now, only &quot;AllLeds&quot; are implemented).</param>
		/// <returns></returns>
        public void Reset(string arg0_name)
        {
            SourceService["reset"].Call(arg0_name);
        }

        /// <summary>Sets an intensity ratio for the leds. If the leds are asked to be set to a specific intensity, the real intensity applied on the leds will be the specific intensity multiplied by this ratio.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity ratio between 0.6 and 1.</param>
		/// <returns></returns>
        public void _setIntensityRatio(string arg0_name, float arg1_intensity)
        {
            SourceService["_setIntensityRatio"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Gets the intensity of a LED or device</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns>The intensity of the LED or Group.</returns>
        public QiValue GetIntensity(string arg0_name)
        {
            return SourceService["getIntensity"].Call(arg0_name);
        }

        /// <summary>Lists the short LED names.</summary>
		/// <returns>A vector of LED names.</returns>
        public string[] ListLEDs()
        {
            return (string[])SourceService["listLEDs"].Call();
        }

        /// <summary>Lists the devices aliased by a short LED name.</summary>
		/// <param name="arg0_name">The name of the LED to list</param>
		/// <returns>A vector of device names.</returns>
        public string[] ListLED(string arg0_name)
        {
            return (string[])SourceService["listLED"].Call(arg0_name);
        }

        /// <summary>Lists the devices in the group.</summary>
		/// <param name="arg0_groupName">The name of the Group.</param>
		/// <returns>A vector of string device names.</returns>
        public string[] ListGroup(string arg0_groupName)
        {
            return (string[])SourceService["listGroup"].Call(arg0_groupName);
        }

        /// <summary>Lists available group names.</summary>
		/// <returns>A vector of group names.</returns>
        public string[] ListGroups()
        {
            return (string[])SourceService["listGroups"].Call();
        }

        /// <summary>Switch to a minimum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public void Off(string arg0_name)
        {
            SourceService["off"].Call(arg0_name);
        }

        /// <summary>Switch to a maximum intensity a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <returns></returns>
        public void On(string arg0_name)
        {
            SourceService["on"].Call(arg0_name);
        }

        /// <summary>Launch a green/yellow/red rasta animation on all body.</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void Rasta(float arg0_duration)
        {
            SourceService["rasta"].Call(arg0_duration);
        }

        /// <summary>Launch a rotation using the leds of the eyes.</summary>
		/// <param name="arg0_rgb">the RGB value led, RGB as seen in hexa-decimal: 0x00RRGGBB.</param>
		/// <param name="arg1_timeForRotation">Approximate time to make one turn.</param>
		/// <param name="arg2_totalDuration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void RotateEyes(int arg0_rgb, float arg1_timeForRotation, float arg2_totalDuration)
        {
            SourceService["rotateEyes"].Call(arg0_rgb, arg1_timeForRotation, arg2_totalDuration);
        }

        /// <summary>Launch a random animation in eyes</summary>
		/// <param name="arg0_duration">Approximate duration of the animation in seconds.</param>
		/// <returns></returns>
        public void RandomEyes(float arg0_duration)
        {
            SourceService["randomEyes"].Call(arg0_duration);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs.</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public void SetIntensity(string arg0_name, float arg1_intensity)
        {
            SourceService["setIntensity"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Make the eyes blink once.</summary>
		/// <returns></returns>
        public void _blink()
        {
            SourceService["_blink"].Call();
        }

        /// <summary>Make the eyes blink once with a eyeshadow color.</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _blink(int arg0)
        {
            SourceService["_blink"].Call(arg0);
        }

        /// <summary>Sets the intensity of a LED or Group of LEDs (even chest LED).</summary>
		/// <param name="arg0_name">The name of the LED or Group.</param>
		/// <param name="arg1_intensity">The intensity of the LED or Group (a value between 0 and 1).</param>
		/// <returns></returns>
        public void _setAnyLedIntensity(string arg0_name, float arg1_intensity)
        {
            SourceService["_setAnyLedIntensity"].Call(arg0_name, arg1_intensity);
        }

        /// <summary>Start passive blinking.</summary>
		/// <returns></returns>
        public void _startPassiveBlinking()
        {
            SourceService["_startPassiveBlinking"].Call();
        }

        /// <summary>Start passive blinking with a eyeshadow color.</summary>
		/// <param name="arg0_eyeShadow">The color of the eye shadow during and after the blink.</param>
		/// <returns></returns>
        public void _startPassiveBlinking(int arg0_eyeShadow)
        {
            SourceService["_startPassiveBlinking"].Call(arg0_eyeShadow);
        }

        /// <summary>Stop passive blinking.</summary>
		/// <returns></returns>
        public void _stopPassiveBlinking()
        {
            SourceService["_stopPassiveBlinking"].Call();
        }

        /// <summary>Set values for minimum and maximum time waited between two passive blinks.</summary>
		/// <param name="arg0_min">The minimum (should be &gt;= 0)</param>
		/// <param name="arg1_max">The maximum (should be &gt;= min)</param>
		/// <returns></returns>
        public void _setTimeBetweenTwoBlinks(float arg0_min, float arg1_max)
        {
            SourceService["_setTimeBetweenTwoBlinks"].Call(arg0_min, arg1_max);
        }

    }
}