using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerDeath : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject gameOver;
    private TimerUI timer;

    //finding the player fom the scene to get the PlayerMovement script attached with it
    // finding timer gameObject from the scene to get the TimerUI script attached with it
    private void Start()
    {
        player = GameObject.Find("Ch-Maui").GetComponent<PlayerMovement>();
        timer = GameObject.Find("Timer").GetComponent<TimerUI>();

    }
    // if the player collides with this object,
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ch-Maui")
        {
            player.myAnimator.SetLayerWeight(2, 1); //death animation is active
            player.myAnimator.SetTrigger("dead"); //triggeing death 
            StartCoroutine("wait");   //method waits for give seconds
            Destroy(timer);      // destorying the timer
            gameOver.gameObject.SetActive(true); //showing game over screen
        }
    }
    //method 
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        Destroy(GameObject.Find("Ch-Maui"));  //Destorying player
    }


}
