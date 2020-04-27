using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{


    public static AudioClip playerHitSound, JumpSound, gainLifeSound,HakaWarSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");

        JumpSound = Resources.Load<AudioClip>("jump");

        gainLifeSound = Resources.Load<AudioClip>("gainLife");


        audioSrc = GetComponent<AudioSource>();

        HakaWarSound = Resources.Load<AudioClip>("HakaWar");



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound (string clip)
    {

        switch (clip)
        {

            case "playerHit":

                audioSrc.PlayOneShot(playerHitSound);

            break;


            case "jump":

                audioSrc.PlayOneShot(JumpSound);

                break;

            case "gainLife":

                audioSrc.PlayOneShot(gainLifeSound);

                break;

            case "HakaWar":

                audioSrc.PlayOneShot(HakaWarSound);

                break;


        }
    }
}
