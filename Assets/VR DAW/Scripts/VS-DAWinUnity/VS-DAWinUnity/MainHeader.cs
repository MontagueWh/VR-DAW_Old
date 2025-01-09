using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;

namespace VS_DAWinUnity
{
    public class Class1
    {
        public void Record()
        {
            double sampleRate = 44100.0d;

            WaveInEvent wave = new WaveInEvent(); // recording audio data
            wave.DeviceNumber = 0; // audio input 1
            wave.WaveFormat = new WaveFormat((int)Math.Round(sampleRate), 16, 1);
            wave.DataAvailable += AudioIn_DataAvailable;
            wave.RecordingStopped += AudioIn_RecordingStopped;

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "/Audio Recording";
            WaveFileWriter writer = new WaveFileWriter(filePath, wave.WaveFormat);
        }

        private void AudioIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AudioIn_RecordingStopped(object? sender, StoppedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
