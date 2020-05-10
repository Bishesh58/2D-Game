using UnityEngine.Audio;
using UnityEngine;

// creating a sound class to access different sounds
[System.Serializable]
public class Sound 
{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
