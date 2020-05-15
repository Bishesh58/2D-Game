using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunDamage : MonoBehaviour
{


    [SerializeField]
    GameObject playerWon;
    GameObject player;
    PlayerMovement playerScript;
    GameObject sun;
    GameObject ropeLeft;
    public GameObject RightRope;
    public GameObject Rope1;
    public GameObject Rope2;
    public GameObject Rope3;
    public GameObject Rope4;



    GameObject ropeRight;




    Rigidbody2D rb;
    float dirX, dirY;
    float moveSpeed = 5f;
    public static float healthAmount;

    // Use this for initialization
    void Start()
    {
        healthAmount = 4f;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Ch-Maui");
        playerScript = GameObject.Find("Ch-Maui").GetComponent<PlayerMovement>();
        sun = GameObject.Find("MovingSun");
        playerWon.SetActive(false);
        ropeLeft = GameObject.Find("SunConstraintRopeLeft");
        ropeRight = GameObject.Find("SunConstraintRight");

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;

        if (healthAmount <= 0)                       
        {

            playerWon.SetActive(true);
            Destroy(RightRope.gameObject);
            Destroy(player.gameObject);
            Destroy(sun.gameObject);
            Destroy(Rope1.gameObject);
            Destroy(Rope2.gameObject);
            Destroy(Rope3.gameObject);
            Destroy(Rope4.gameObject);
        }
    }
   
    void FixedUpdate()
    {
        //rb.velocity = new Vector2 (dirX, dirY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PlayerWeapon"))
        {
            if (playerScript.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") ||
                playerScript.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
            {
                healthAmount -= 1f;
                FindObjectOfType<AudioManager>().Play("sun_damage");
            }

        }

    }

}
