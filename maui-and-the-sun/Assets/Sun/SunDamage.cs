using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDamage : MonoBehaviour
{


    [SerializeField]
    GameObject playerWon;
    GameObject player;
    GameObject sun;
    GameObject ropeLeft;

    GameObject ropeRight;




    Rigidbody2D rb;
    //float dirX, dirY;
    //float moveSpeed = 5f;
    public static float healthAmount;

    // Use this for initialization
    void Start()
    {
        healthAmount = 4f;
        rb = GetComponent<Rigidbody2D>();

        playerWon = GameObject.Find("PlayerWonUI");
        player = GameObject.Find("Ch-Maui");
        sun = GameObject.Find("MovingSun");
       // playerWon.SetActive(false);
        ropeLeft = GameObject.Find("SunConstraintRopeLeft");
        ropeRight = GameObject.Find("SunConstraintRight");

    }

    // Update is called once per frame
    void Update()
    {
        //dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        //dirY = Input.GetAxis ("Vertical") * moveSpeed;

        //if (healthAmount <= 0)                         ==> comments to be removed once script is done by Bishesh
        //{

        //    playerWon.SetActive(true);

        //    Destroy(sun.gameObject);

        //    Destroy(player.gameObject);

        //}
    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2 (dirX, dirY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("PlayerWeapon"))
            healthAmount -= 1f;
    }

}
