using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    AudioSource audio;
    public static float[] samples = new float[512];
    public static float[] freqBands = new float[8];
    public static float[] buffer = new float [8];
    float[] bufferDecrease = new float[8]; 

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource() {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer() {
        for (int g=0; g < 8; ++g) {
            if (freqBands[g] > buffer [g]) {
                buffer[g] = freqBands[g];
                bufferDecrease[g] = 0.005f;
            }

            if (freqBands[g] < buffer[g]) {
                buffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands() {
        // 44100hz /512 samples = 86 hz/ sample
        // 8 bands, so 8 divisions

        /* 20 - 60hz - Sub-bass
        * 60 - 250 - Bass
        * 250-500 - Low mids
        * 500 - 2000 Midrange
        * 2000 - 4000 high mids
        * 4000 - 6000 prescence
        * 6000 - 16000 brilliance
        */

        // 0 - 1 = 86 hz
        // 1 - 2 = 172 hz = 87 - 258
        // 2 - 4 = 344hz = 259 - 602
        // 3 - 15 = 1978 = 603 - 1290
        // 4 - 32
        // 5 - 
        // 6
        // 7

        int count = 0;

        for (int i=0; i < 8; i++) {
           
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i==7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++) {
                average += samples[count] * (count + 1) ;
                count++;
            }

            average /= count;
            freqBands[i] = average * 10;
        }

    }
}
