using System;
using System.Security.Cryptography;
using UnityEngine;
using VS_DAWinUnity;

public class ReadandWrite
{
    //WaveFileWriter writer;
    //WaveInEvent wave;

    public int sampleWindow = 128; // The amount of the data before an audio clip is read

    public ReadandWrite()
    {
        //Record();
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) return 0; // Prevents negative values (and potential errors)
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0.0f;

        for (int tl = 0; tl < sampleWindow; tl++)
        {
            totalLoudness += Mathf.Abs(waveData[tl]);
        }

        return totalLoudness / sampleWindow;
    }

    /*public void Record()
    {
        wave = new WaveInEvent(); // recording audio data
        wave.DeviceNumber = 0; // audio input 1
        wave.WaveFormat = new WaveFormat(MainHeader.sampleRate, 16, 1);
        wave.DataAvailable += AudioIn_DataAvailable;
        wave.RecordingStopped += AudioIn_RecordingStopped;

        string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = pathToDesktop + "/AudioRecording.wav";
        writer = new WaveFileWriter(filePath, wave.WaveFormat);
    }*/

    /*// Setup Unity to stop recording when a 'stop' button is pressed
    public void StopRecording()
    {
        wave.StopRecording();
    }*/

    /*private void AudioIn_DataAvailable(object? sender, WaveInEventArgs e)
    {
        writer.Write(e.Buffer, 0, e.BytesRecorded);
    }*/

    /*private void AudioIn_RecordingStopped(object? sender, StoppedEventArgs e)
    {
        writer.Dispose();
    }*/
}
