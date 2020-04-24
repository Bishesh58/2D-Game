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
        if (collision.gameObject.name == "Ch-Maui" && !isDamage)
        {
            FindObjectOfType<AudioManager>().Play("button_press"); //playing sound
            isDamage = true;
            Damage.takedamage(1);

            Damage.myAnimator.SetLayerWeight(2, 1);
        }
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
      
        isDamage = false;
        Damage.myAnimator.SetLayerWeight(2, 0);
    }


}
