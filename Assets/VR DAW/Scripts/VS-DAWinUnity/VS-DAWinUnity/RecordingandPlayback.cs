using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;
using VS_DAWinUnity;


    public class ReadandWrite
    {
        WaveFileWriter writer;
        //WaveInEvent wave;

        public ReadandWrite()
        {
            Record();
        }

        public void Record()
        {
            //wave = new WaveInEvent(); // recording audio data
            //wave.DeviceNumber = 0; // audio input 1
            //wave.WaveFormat = new WaveFormat((int)Math.Round(MainHeader.sampleRate), 16, 1);
            //wave.DataAvailable += AudioIn_DataAvailable;
            wave.RecordingStopped += AudioIn_RecordingStopped;

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath += "/Audio Recording.wav";
            writer = new WaveFileWriter(filePath, wave.WaveFormat);
        }
         
        // Setup Unity to stop recording when a 'stop' button is pressed
        public void StopRecording()
        {
            wave.StopRecording();
        }

        private void AudioIn_RecordingStopped(object? sender, StoppedEventArgs e)
        {
            writer.Dispose();
        }
    }
