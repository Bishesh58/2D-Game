using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollissionDamage : MonoBehaviour
{

    public PlayerMovement Damage;
    public TimerUI gameOver;
    bool isDamage;
    GameObject gameOverScrn;
    GameObject player;


    public static bool PARTICLE_COLLISION = false;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;


    private void LateUpdate()
    {
        PARTICLE_COLLISION = false;
    }

    void Start()
    {

        gameOverScrn = GameObject.Find("gameOverScreen");
        player = GameObject.Find("Ch-Maui");
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }




    void OnParticleCollision(GameObject collision)
    {

        PARTICLE_COLLISION = true;


        if (collision.transform.tag == "Player" && !isDamage)
        {
            Debug.Log("Damage");
            Damage.takedamage(1);
            isDamage = true;
            Damage.myAnimator.SetLayerWeight(2, 1);
           


            if (Damage.currentHealth <= 0f)
            {
                Debug.Log("player died");
                gameOverScrn.SetActive(true);
                Destroy(player.gameObject);


            }
            else
            {
                //
            }

            PARTICLE_COLLISION = false;
        }

 
    }


    private void Update()
    {
        if (PARTICLE_COLLISION)
        {

            isDamage = false;
            Damage.myAnimator.SetLayerWeight(2, 0);
            // now you can write your code for after collision ends
        }

        if (Damage.currentHealth <= 0f)
        {
            Debug.Log("player died");
            gameOverScrn.SetActive(true);
            Destroy(player.gameObject);


        }
        else
        {
            //
        }
    }



    
    private void OnTriggerExit2D(Collider2D collision)
    {

        isDamage = false;
        Damage.myAnimator.SetLayerWeight(2, 0);
    }
    

}