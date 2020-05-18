using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // controlling master volume from setting menu by exposing the parameters from audio Mixture
    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);  //"volume" represents parameter from audioMixture
    }

    //controlling music volume from setting menu

    public void setVolumeMusic(float volume)
    {
        audioMixer.SetFloat("volume-music", volume);  //"volume" represents parameter from audioMixture
    }

    public void setSoundEffects(float volume)
    {
        audioMixer.SetFloat("soundEffect", volume);
    }
}
