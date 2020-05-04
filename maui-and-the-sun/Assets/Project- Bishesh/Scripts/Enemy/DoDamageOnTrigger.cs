using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;

public class DoDamageOnTrigger : MonoBehaviour
{
    public PlayerMovement Damage;
    public TimerUI gameOver;
    bool isDamage;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player will take damage if it collides with the spikes 
        if (collision.gameObject.name == "Ch-Maui" && !isDamage)
        {
            FindObjectOfType<AudioManager>().Play("hurt"); //method call for playing sound
            isDamage = true;
            Damage.takedamage(1); //taking 1 damage each time.

            Damage.myAnimator.SetLayerWeight(2, 1); //playing hurt animation
        }
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        isDamage = false; //damage is not take unless player exits the collider
        Damage.myAnimator.SetLayerWeight(2, 0); //stopping hurt animation when player exits the collider
    }


}
