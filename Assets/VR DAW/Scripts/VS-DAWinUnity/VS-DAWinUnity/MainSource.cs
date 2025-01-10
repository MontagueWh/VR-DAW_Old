using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;
using VS_DAWinUnity;



// Constructor: called when the effect is first created / loaded
public class MyEffect
{
    public MyEffect(/*List<Parameter> parameters, List<Preset> presets)
        : base(parameters, presets*/)
    {
        // Initialise member variables, etc.
    }

    // Destructor: called when the effect is terminated / unloaded
    ~MyEffect()
    {
        // Put your own additional clean up code here (e.g. free memory)
    }

    private void AudioIn_DataAvailable(object? sender, WaveInEventArgs e)
    {
        writer.Write(e.Buffer, 0, e.BytesRecorded);
    }

    // Applies audio processing to a buffer of audio
    // (inputBuffer contains the input audio, and processed samples should be stored in outputBuffer)
    public void Process(float[][] inputBuffers, float[][] outputBuffers, int numSamples)
    {
        //WaveFileWriter writer;
        WaveInEvent wave;


        wave = new WaveInEvent(); // recording audio data
        wave.DeviceNumber = 0; // audio input 1
        wave.WaveFormat = new WaveFormat((int)Math.Round(MainHeader.sampleRate), 16, 1);
        wave.DataAvailable += AudioIn_DataAvailable;

        float in0, in1, out0 = 0, out1 = 0;
        float[] inBuffer0 = inputBuffers[0], inBuffer1 = inputBuffers[1];
        float[] outBuffer0 = outputBuffers[0], outBuffer1 = outputBuffers[1];

        //float gain = parameters[0];

        for (int i = 0; i < numSamples; i++)
        {
            // Get sample from input
            in0 = inBuffer0[i];
            in1 = inBuffer1[i];

  

            // Add your effect processing here
            out0 = in0;
            out1 = in1;

            // Copy result to output
            outBuffer0[i] = out0;
            outBuffer1[i] = out1;
        }
    }
}