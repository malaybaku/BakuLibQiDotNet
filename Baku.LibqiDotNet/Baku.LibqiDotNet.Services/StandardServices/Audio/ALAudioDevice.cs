using System;
using System.Collections.Generic;
using System.Linq;

namespace Baku.LibqiDotNet.Service
{
    /// <summary>The ALAudioDevice module allows other modules to access to the sound data of the nao's microphones, and to send sound toward its loudspeakers  The way to receive or send the audio data depends whether the modules are local (dynamic library) or remote (executable).</summary>
    public class ALAudioDevice
    {
        /// <summary>サービスの取得元セッションを指定してサービスを初期化します。</summary>
        /// <param name="session">サービスの取得元となるセッション</param>
        public ALAudioDevice(QiSession session)
        {
            SourceService = session.GetService("ALAudioDevice");
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

        /// <summary>This function allows a module to subscribe to the ALAudioDevice module.For more informations see the audio part of the red documentation</summary>
		/// <param name="arg0_pModule">Name of the module</param>
		/// <returns></returns>
        public void Subscribe(string arg0_pModule)
        {
            SourceService["subscribe"].Call(arg0_pModule);
        }

        /// <summary>This function allows a module to subscribe to the ALAudioDevice module.For more informations see the audio part of the red documentation</summary>
		/// <param name="arg0_pModule">Name of the module</param>
		/// <returns></returns>
        public void Unsubscribe(string arg0_pModule)
        {
            SourceService["unsubscribe"].Call(arg0_pModule);
        }

        /// <summary>This function allows a local module to send sound onto the nao's loudpseakersYou must pass to this function a pointer to the stereo buffer to send, and the number of frames per channel. The buffer must contain 16bits stereo interleaved samples, and the number of frames does not exceed 16384</summary>
		/// <param name="arg0_nbOfFrames">Number of 16 bits samples per channel to send.</param>
		/// <param name="arg1_pBuffer">Buffer to send</param>
		/// <returns>True if the operation is successfull - False otherwise</returns>
        public bool SendLocalBufferToOutput(int arg0_nbOfFrames, int arg1_pBuffer)
        {
            return (bool)SourceService["sendLocalBufferToOutput"].Call(arg0_nbOfFrames, arg1_pBuffer);
        }

        /// <summary>This function allows a remote module to send sound onto the nao's loudpseakersYou must pass to this function the stereo buffer you want to send as an ALValue converted to binary, and the number of frames per channel. The number of frames does not exceed 16384. For more information please see the red documentation</summary>
		/// <param name="arg0_nbOfFrames">Number of 16 bits samples per channel to send.</param>
		/// <param name="arg1_pBuffer">Buffer to send</param>
		/// <returns>True if the operation is successfull - False otherwise</returns>
        public bool SendRemoteBufferToOutput(int arg0_nbOfFrames, QiAnyValue arg1_pBuffer)
        {
            return (bool)SourceService["sendRemoteBufferToOutput"].Call(arg0_nbOfFrames, arg1_pBuffer);
        }

        /// <summary>This method allows to send sound samples contained in a sound file at the input of ALAudioDevice, instead of the nao's microphones sound data. The sound file must be a .wav file containing 16bits / 4 channels / interleaved samples. Once the file has been read, microphones sound data will again taken as input</summary>
		/// <param name="arg0_pFileName">Name of the input file.</param>
		/// <returns></returns>
        public void SetFileAsInput(string arg0_pFileName)
        {
            SourceService["setFileAsInput"].Call(arg0_pFileName);
        }

        /// <summary>This method sets the specified internal parameter ('outputSampleRate' or 'inputBufferSize')inputBufferSize can bet set to 8192 or 16384. Warning: when speech recognition is running, a buffer size of 8192 is used. Don't change it during the recognition process.outputSampleRate can bet set to 16000 Hz, 22050 Hz, 44100 Hz or 48000 Hz. Warning: if speech synthesis is running, a sample rate of 16000 Hz or 22050 Hz is used (depending of the language). Don't change it during the synthesis process</summary>
		/// <param name="arg0_pParamName">Name of the parameter to set ('outputSampleRate' or 'inputBufferSize').</param>
		/// <param name="arg1_pParamValue">The value to which the specified parameter should be set.</param>
		/// <returns></returns>
        public void SetParameter(string arg0_pParamName, int arg1_pParamValue)
        {
            SourceService["setParameter"].Call(arg0_pParamName, arg1_pParamValue);
        }

        /// <summary>This method returns the specified internal parameter ('outputSampleRate' or 'inputBufferSize'). The value -1 is returned if the specified parameter is not valid.</summary>
		/// <param name="arg0_pParamName">Name of the parameter to get ('outputSampleRate' or 'inputBufferSize').</param>
		/// <returns>value of the specified parameter</returns>
        public int GetParameter(string arg0_pParamName)
        {
            return (int)SourceService["getParameter"].Call(arg0_pParamName);
        }

        /// <summary>This method allows to record the signal collected on the nao's microphones. You can choose to record only the front microphone in a ogg file, or the 4 microphones in a wav file. In this last case the format of the file is 4 channels, 16 bits little endian, 48 KHz</summary>
		/// <param name="arg0_pFileName">Name of the file where to record the sound.</param>
		/// <returns></returns>
        public void StartMicrophonesRecording(string arg0_pFileName)
        {
            SourceService["startMicrophonesRecording"].Call(arg0_pFileName);
        }

        /// <summary>This method stops the recording of the sound collected by the microphones.</summary>
		/// <returns></returns>
        public void StopMicrophonesRecording()
        {
            SourceService["stopMicrophonesRecording"].Call();
        }

        /// <summary>Sets the output sound level of the system.</summary>
		/// <param name="arg0_volume">Volume [0-100].</param>
		/// <returns></returns>
        public void SetOutputVolume(int arg0_volume)
        {
            SourceService["setOutputVolume"].Call(arg0_volume);
        }

        /// <summary>Gets the output sound level of the system.</summary>
		/// <returns>outputVolume of the system</returns>
        public int GetOutputVolume()
        {
            return (int)SourceService["getOutputVolume"].Call();
        }

        /// <summary>Opens the audio device for capture. If you closed the audio inputs with the closeAudioInputs method, you must call this method to be able to access to the sound data of the nao's microphones. </summary>
		/// <returns></returns>
        public void OpenAudioInputs()
        {
            SourceService["openAudioInputs"].Call();
        }

        /// <summary>Opens the audio device for playback. If you closed the audio outputs with the closeAudioOutputs method, you must call this method to ear or send sound onto the nao's loudspeakers.</summary>
		/// <returns></returns>
        public void OpenAudioOutputs()
        {
            SourceService["openAudioOutputs"].Call();
        }

        /// <summary>Closes the audio device for capture. You can call this method if you want to have access to the alsa input buffers in another program than naoqi while naoqi is running (with arecord for example)</summary>
		/// <returns></returns>
        public void CloseAudioInputs()
        {
            SourceService["closeAudioInputs"].Call();
        }

        /// <summary>Closes the audio device for playback. close the audio device for capture. You can call this method if you want to send sound to alsa in another program than naoqi while naoqi is running (with aplay for example)</summary>
		/// <returns></returns>
        public void CloseAudioOutputs()
        {
            SourceService["closeAudioOutputs"].Call();
        }

        /// <summary>Flush the audio device for playback. close the audio device for capture. You can call this method if you want to send sound to alsa in another program than naoqi while naoqi is running (with aplay for example)</summary>
		/// <returns></returns>
        public void FlushAudioOutputs()
        {
            SourceService["flushAudioOutputs"].Call();
        }

        /// <summary>Allows to know if audio ouputs are closed or not</summary>
		/// <returns>True if audio outputs are closed / False otherwise</returns>
        public bool IsOutputClosed()
        {
            return (bool)SourceService["isOutputClosed"].Call();
        }

        /// <summary>Allows to know if audio inputs are closed or not</summary>
		/// <returns>True if audio inputs are closed / False otherwise</returns>
        public bool IsInputClosed()
        {
            return (bool)SourceService["isInputClosed"].Call();
        }

        /// <summary>return the list of available outputs</summary>
		/// <returns>A list of AudioDeviceInfo</returns>
        public QiValue _listOutputs()
        {
            return SourceService["_listOutputs"].Call();
        }

        /// <summary>return the output matching the index</summary>
		/// <param name="arg0_index">The output index</param>
		/// <returns>An AudioDeviceInfo</returns>
        public QiValue _output(uint arg0_index)
        {
            return SourceService["_output"].Call(arg0_index);
        }

        /// <summary>return the default output</summary>
		/// <returns>The default output index</returns>
        public uint _defaultOutput()
        {
            return (uint)SourceService["_defaultOutput"].Call();
        }

        /// <summary>set the default output</summary>
		/// <param name="arg0_index">The output index</param>
		/// <returns></returns>
        public void _setDefaultOutput(uint arg0_index)
        {
            SourceService["_setDefaultOutput"].Call(arg0_index);
        }

        /// <summary>return the list of available inputs</summary>
		/// <returns>A list of AudioDeviceInfo</returns>
        public QiValue _listInputs()
        {
            return SourceService["_listInputs"].Call();
        }

        /// <summary>return the input matching the index</summary>
		/// <param name="arg0_index">The input index</param>
		/// <returns>An AudioDeviceInfo</returns>
        public QiValue _input(uint arg0_index)
        {
            return SourceService["_input"].Call(arg0_index);
        }

        /// <summary>return the default input</summary>
		/// <returns>The default input index</returns>
        public uint _defaultInput()
        {
            return (uint)SourceService["_defaultInput"].Call();
        }

        /// <summary>set the default input</summary>
		/// <param name="arg0_index">The input index</param>
		/// <returns></returns>
        public void _setDefaultInput(uint arg0_index)
        {
            SourceService["_setDefaultInput"].Call(arg0_index);
        }

        /// <summary>Play a sine wave which specified caracteristics.</summary>
		/// <param name="arg0_frequence">Frequence in Hertz</param>
		/// <param name="arg1_gain">Volume Gain between 0 and 100</param>
		/// <param name="arg2_pan">Stereo Pan set to either {-1,0,+1}</param>
		/// <param name="arg3_duration">Duration of the sine wave in seconds</param>
		/// <returns></returns>
        public void PlaySine(int arg0_frequence, int arg1_gain, int arg2_pan, float arg3_duration)
        {
            SourceService["playSine"].Call(arg0_frequence, arg1_gain, arg2_pan, arg3_duration);
        }

        /// <summary>Enables the computation of the energy of each microphone signal</summary>
		/// <returns></returns>
        public void EnableEnergyComputation()
        {
            SourceService["enableEnergyComputation"].Call();
        }

        /// <summary>Disables the computation of the energy of each microphone signal</summary>
		/// <returns></returns>
        public void DisableEnergyComputation()
        {
            SourceService["disableEnergyComputation"].Call();
        }

        /// <summary>Returns the energy of the left microphone signal</summary>
		/// <returns>energy of the left microphone signal</returns>
        public float GetLeftMicEnergy()
        {
            return (float)SourceService["getLeftMicEnergy"].Call();
        }

        /// <summary>Returns the energy of the right microphone signal</summary>
		/// <returns>energy of the right microphone signal</returns>
        public float GetRightMicEnergy()
        {
            return (float)SourceService["getRightMicEnergy"].Call();
        }

        /// <summary>Returns the energy of the front microphone signal</summary>
		/// <returns>energy of the front microphone signal</returns>
        public float GetFrontMicEnergy()
        {
            return (float)SourceService["getFrontMicEnergy"].Call();
        }

        /// <summary>Returns the energy of the rear microphone signal</summary>
		/// <returns>energy of the rear microphone signal</returns>
        public float GetRearMicEnergy()
        {
            return (float)SourceService["getRearMicEnergy"].Call();
        }

        /// <summary>Sets the input level of Nao's microphones.</summary>
		/// <param name="arg0_volume">Volume [0-100].</param>
		/// <returns></returns>
        public void _setInputVolume(int arg0_volume)
        {
            SourceService["_setInputVolume"].Call(arg0_volume);
        }

        /// <summary>Set AudioDevice Client preferences</summary>
		/// <param name="arg0_name">name of the client</param>
		/// <param name="arg1_sampleRate">sample rate of the microphones data sent to the process function - must be 16000 or 48000</param>
		/// <param name="arg2_channelsConfiguration">An int (defined in ALSoundExtractor) indicating which microphones data will be send to the process function. ALLCHANNELS, LEFTCHANNEL, RIGHTCHANNEL, FRONTCHANNEL, REARCHANNEL are the configuration currently supported.</param>
		/// <param name="arg3_deinterleaved">indicates if the microphones data sent to the process function are interleaved or not - 0 : interleaved - 1 : deinterleaved </param>
		/// <returns></returns>
        public void SetClientPreferences(string arg0_name, int arg1_sampleRate, int arg2_channelsConfiguration, int arg3_deinterleaved)
        {
            SourceService["setClientPreferences"].Call(arg0_name, arg1_sampleRate, arg2_channelsConfiguration, arg3_deinterleaved);
        }

        /// <summary>Set AudioDevice Client preferences. This function is deprecated, the use of the alternate 4 arguments setClientPreferences() is now prefered.</summary>
		/// <param name="arg0_name">name of the client</param>
		/// <param name="arg1_sampleRate">sample rate of the microphones data sent to the processSound or processSoundRemote functions - must be 16000 or 48000</param>
		/// <param name="arg2_channelsVector">ALValue containing a vector of int indicating which microphones data will be send to the processSound or processSoundRemote functions</param>
		/// <param name="arg3_deinterleaved">indicates if the microphones data sent to the processSound or processSoundRemote functions are interleaved or not - 0 : interleaved - 1 : deinterleaved </param>
		/// <param name="arg4_timeStamp">parameter indicating if audio timestamps are sent to the processSound or processSoundRemote functions - 0 : no - 1 : yes </param>
		/// <returns></returns>
        public void SetClientPreferences(string arg0_name, int arg1_sampleRate, QiAnyValue arg2_channelsVector, int arg3_deinterleaved, int arg4_timeStamp)
        {
            SourceService["setClientPreferences"].Call(arg0_name, arg1_sampleRate, arg2_channelsVector, arg3_deinterleaved, arg4_timeStamp);
        }

        /// <summary>mute the loudspeakers</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void MuteAudioOut(bool arg0)
        {
            SourceService["muteAudioOut"].Call(arg0);
        }

        /// <summary>mute the microphones</summary>
		/// <param name="arg0"></param>
		/// <returns></returns>
        public void _muteAudioIn(bool arg0)
        {
            SourceService["_muteAudioIn"].Call(arg0);
        }

        /// <summary>check if loudspeakers are muted</summary>
		/// <returns>1 if true / 0 otherwise</returns>
        public bool IsAudioOutMuted()
        {
            return (bool)SourceService["isAudioOutMuted"].Call();
        }

        /// <summary>get the number of microphones</summary>
		/// <returns></returns>
        public int _getNbOfMicrophones()
        {
            return (int)SourceService["_getNbOfMicrophones"].Call();
        }

    }
}