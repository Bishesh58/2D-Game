using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement Damage;
    public TimerUI gameOver;
    bool isDamage;
  
    GameObject gameOverScrn;
    GameObject player;

    void Start()
    {

        gameOverScrn = GameObject.Find("gameOverScreen");
        player = GameObject.Find("Ch-Maui");
        //part = GetComponent<ParticleSystem>();
       // collisionEvents = new List<ParticleCollisionEvent>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isDamage)
        {
            //FindObjectOfType<AudioManager>().Play("button_press"); //playing sound
            isDamage = true;
            Damage.takedamage(1);

            Damage.myAnimator.SetLayerWeight(2, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        isDamage = false;
        Damage.myAnimator.SetLayerWeight(2, 0);
    }
}
