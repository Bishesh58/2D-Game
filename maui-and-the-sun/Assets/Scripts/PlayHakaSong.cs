using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHakaSong : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  SoundManagerScript.PlaySound("HakaWar");


        FindObjectOfType<AudioManager>().Play("HakaWar"); //playing sound


    }
}


