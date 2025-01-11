using System;
using System.Security.Cryptography;
using NAudio;
using NAudio.Wave;
//using UnityEngine;
using VS_DAWinUnity;

namespace VS_DAWinUnity
{
    public class MainHeader
    {
        public void Initalise() { }
        
        public static int sampleRate = 44100;

        MainSource mainSource = new MainSource();
    }
}