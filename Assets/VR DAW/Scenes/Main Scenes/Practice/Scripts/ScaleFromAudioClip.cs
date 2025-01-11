using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection loudnessMeter;

    public float loudSense = 100f;
    public float thresh = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = loudnessMeter.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudSense;
        if (loudness < thresh) loudness = 0;

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
