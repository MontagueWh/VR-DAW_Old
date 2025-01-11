using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    public int sampleWindow = 128;
    private AudioClip audioInClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioInClip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AudioInClip()
    {
        // Audio inputs
        string audioIn1 = Microphone.devices[0];
        audioInClip = Microphone.Start(audioIn1, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromAudioIn()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), audioInClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) return 0; 
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0f;

        for (int tL = 0; tL < sampleWindow; tL++)
        {
            totalLoudness += Mathf.Abs(waveData[tL]);
        }

        return totalLoudness / sampleWindow; // average (mean) loudness
    }
}
