using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySetting : MonoBehaviour
{
   [SerializeField] AudioSource[] audioSources;
   private float[] originalVolumes;

    void Start()
    {
        //RenderSettings.ambientIntensity = 0f;
        originalVolumes = new float[audioSources.Length];
        for (int i = 0; i < audioSources.Length; i++)
        {
            originalVolumes[i] = audioSources[i].volume;
        }
    }
    public void SoundSlider(float SoundValue)
    {
       for(int i = 0; i< audioSources.Length; i++)
        {

            audioSources[i].volume = originalVolumes[i] * SoundValue;
        }
        
    }
    public void Lightslider(float LightValue)
    {
       
        RenderSettings.ambientIntensity =  LightValue;
    }
}
