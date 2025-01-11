using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;
using VS_DAWinUnity;

public class ReadandWrite
{
    WaveFileWriter writer;
    WaveInEvent wave;

    public ReadandWrite()
    {
        Record();
    }

    public void Record()
    {
        wave = new WaveInEvent(); // recording audio data
        wave.DeviceNumber = 0; // audio input 1
        wave.WaveFormat = new WaveFormat(MainHeader.sampleRate, 16, 1);
        wave.DataAvailable += AudioIn_DataAvailable;
        wave.RecordingStopped += AudioIn_RecordingStopped;

        string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = pathToDesktop + "/AudioRecording.wav";
        writer = new WaveFileWriter(filePath, wave.WaveFormat);
    }

    // Setup Unity to stop recording when a 'stop' button is pressed
    public void StopRecording()
    {
        wave.StopRecording();
    }

    private void AudioIn_DataAvailable(object? sender, WaveInEventArgs e)
    {
        writer.Write(e.Buffer, 0, e.BytesRecorded);
    }

    private void AudioIn_RecordingStopped(object? sender, StoppedEventArgs e)
    {
        writer.Dispose();
    }
}
