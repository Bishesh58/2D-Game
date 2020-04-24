using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //playing sound into the scene
    public Sound[] sounds;
    private Scene scene;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)   
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;         //controlling the clip,volume & pitch
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
       
        if (scene.name == "UI System")
        {
            Play("backgroundMusic");
            Play("kai_karakia");
        }
        if (scene.name == "Cut_Scene")
        {
            Debug.Log(scene.name);
            Play("Opening_scene");
        }
        
        
       
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, Sound => Sound.name == name); 
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }


    // controlling master volume from setting menu
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

}
