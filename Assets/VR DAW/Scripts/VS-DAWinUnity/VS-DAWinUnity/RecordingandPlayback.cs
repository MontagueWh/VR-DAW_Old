using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;
using VS_DAWinUnity;

namespace VS_DAWinUnity
{
    public class Class1
    {
        WaveFileWriter writer;
        WaveInEvent wave;

        /*public Example()
        {
            Record();
        }*/

        public void Record()
        {
            double sampleRate = 44100.0d;

            wave = new WaveInEvent(); // recording audio data
            wave.DeviceNumber = 0; // audio input 1
            wave.WaveFormat = new WaveFormat((int)Math.Round(sampleRate), 16, 1);
            wave.DataAvailable += AudioIn_DataAvailable;
            wave.RecordingStopped += AudioIn_RecordingStopped;

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "/Audio Recording.wav";
            writer = new WaveFileWriter(filePath, wave.WaveFormat);
        }

        // Setup Unity to stop recording when a 'stop' button is pressed
        public void StopRecording()
        {

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
}
