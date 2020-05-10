using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    public Animator myAnimator;

    [SerializeField]
    private float MovementSpeed;

    private bool attack;
    private bool slide;

    private bool facingRight;

    [SerializeField]
    private Transform[] groundChecks;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;

    private bool jump;
    private bool jumpAttack;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    //point system
    [SerializeField]
    private TextMeshProUGUI healtpotionCounter, flaxplantCounter, woodCounter;
    private int healtpotionAmount, flaxplantAmount, woodAmount;

    //healthbar
    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthbar;
    public GameObject gamoverScreen;
   
   
    //inventory system
    private Inventory inventory;
    [SerializeField]
    private UI_Inventory uiInventory;
    
    private Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene(); //getting the active scene
        if (scene.name == "Level-2") //inventory is set on to level 1
        {
            inventory = new Inventory(UseItem, 25);
            uiInventory.SetInventory(inventory);
        }
    }

  
    void Start()
    {
        facingRight = true;   //player always face on right direction
        myRigidbody = GetComponent<Rigidbody2D>();  //referencing the rigidbody2d component of the player
        myAnimator = GetComponent<Animator>();     //referencing the Animator component of the player
        currentHealth = maxHealth;
       
        if (scene.name == "Level-2" || scene.name == "Level 2 v1.0")
        {
            healthbar.setMaxHealth(maxHealth);   //setting max health for player
        }
       

        //collectables
        if (scene.name == "Level 2 v1.0")
        {
            healtpotionAmount = 0;
            flaxplantAmount = 0;
            woodAmount = 0;
        }
        if (scene.name == "Level 3 v1.0")
        {
            healtpotionAmount = 0;
        }

    }


    private void Update() 
    {
        HandleInput(); //method call
        
        if (scene.name == "Level 2 v1.0") //setting up text amount for inventory item on level 2 
        {
            //update amount of collectables
            healtpotionCounter.text = "" + healtpotionAmount;
            flaxplantCounter.text = "" + flaxplantAmount;
            woodCounter.text = "" + woodAmount;
            Debug.Log(healtpotionAmount);
        }
        if (scene.name == "Level 3 v1.0") // collecting health potion on level 3 
        {
            healtpotionCounter.text = "" + healtpotionAmount;
        }

    }

    //setting up slots for inventory
    public void UseItem(items inventoryItem)
    {
        GetInventory(); 
    }
    public Inventory GetInventory()
    {
        return inventory;
    }

    //collecting Ingredients
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        
        if (itemWorld != null) //player collecting items when colliding on it
        {
            FindObjectOfType<AudioManager>().Play("collect"); //playing sound for collecting item
            inventory.addItem(itemWorld.GetItem()); //adding items into the inventory
            itemWorld.DestroySelf(); //removing item from the scene

        }
        //collecting helath potion, wood and flax plant
        if (collision.GetComponent<HealthPotion>())
        {
            healtpotionAmount += 1;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<FlaxPlant>())
        {
            flaxplantAmount += 1;
            Destroy(collision.gameObject);
        }
        if (collision.GetComponent<Wood>())
        {
            woodAmount += 1;
            Destroy(collision.gameObject);
        }

    }

    private bool count;

    //method to use health potion
    public void useHealthPotion()
    {
        
        if (!(healtpotionAmount <= 0))
        {
            count = true;
            healtpotionAmount -= 1; //decreasing health potion from the inventory on using
            increaseHealth(1); //increasing the health of the player
        }
        if (healtpotionAmount <= 0) //player can not use health potion when health potion is zero
        {
            healtpotionAmount = 0;
            count = false;
        }
        //if (count == false)
        //{
           
        //}
    }


    void FixedUpdate()    //fixedUpdate updates on fixed amount of time, regardless of frames  
    {
        float horizontal = Input.GetAxis("Horizontal"); // geting x-axis values

        isGrounded = IsGrounded();

        HandleMovement(horizontal);  //method call
        Flip(horizontal);            //method call
        HandleAttack();              //method call
        HandleLayers();              //method call
        ResetValues();               //method call
    }

    private void HandleMovement(float horizontal) //Controlling the player Movement
    {
        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true); //landing animation is set when player is not jumping
        }
    
        if (!myAnimator.GetBool("slide") &&!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (isGrounded || airControl)) // if player is not(!) attacking 
        {
            myRigidbody.velocity = new Vector2(horizontal * MovementSpeed, myRigidbody.velocity.y);   //moving player with velocity
        }

        if (isGrounded && jump) //player is jumping
        {
            isGrounded = false; //player is not on ground
            myRigidbody.AddForce(new Vector2(0, jumpForce)); //moving player up with give velocity
            myAnimator.SetTrigger("jump"); //showing jumping animation


        }

        if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("slide")) //player is sliding
        {
            myAnimator.SetBool("slide", true); //sliding animation is shown
        }
        else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("slide")) // slide is name of slide animation
        {
            myAnimator.SetBool("slide", false); // slide parameters bool
        }


        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));  // running player depending on the speed parameter which returns >0.01||<0.01 for which Mathf.Abs is needed
    }

    private void HandleAttack() //handling the attacks of the player
    {
        if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) // attacking is not starting after the original attack is done
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;  // (reseting the velocity after affacting)
        }

        if (jumpAttack && !isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", true); //showing the player attacking while on air
        }
        if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", false);
        }

        
    }

    //handing keypress
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true; //player can jump if 'space' is pressed
        }

        if (Input.GetKeyDown(KeyCode.Q))   // checking if 'Q' is pressed of keyboard
        {
            attack = true; //player can attack if 'Q' is pressed
            jumpAttack = true; //player can attack on air if 'Q' is pressed
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            slide = true; //player is sliding on 'E' press
        }
       
    }

    private void Flip(float horizontal)   //flipping the player in left and right direction along x-axis
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight; //player facing y-axis

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; 
        }
    }

    private void ResetValues() // resetting values to default
    {
        attack = false;
        slide = false;
        jump = false;
        jumpAttack = false;
    }

    private bool IsGrounded()   //checking if player is landed on ground
    {
        if (isGrounded == true)
        {
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("land", false);

        }
        return  transform.Find("groundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    //handling different layer of the animator, e.g land & air
    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }

    }

    // player taking damage on collision with spikes
    public void takedamage(int damage)
    {
        currentHealth -= damage; //health is being decreade by 1
        healthbar.setHealth(currentHealth); //setting up current health after damage is taken
       
        //checking if player's health is zero
        if (currentHealth<0)
        {
            myAnimator.SetLayerWeight(2, 1); //death animation is active
            myAnimator.SetTrigger("dead");  //playing death animation when player's health is less than zero
            StartCoroutine("wait");   //method waits for give seconds
            gamoverScreen.SetActive(true);
           
            
        }
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);  //Destorying player
        GameObject.Find("Timer").SetActive(false);

    }
    //player can use health potions to increase health
    public void increaseHealth(int healthPlus)
    {
        currentHealth += healthPlus; //health is increaded on using health Potion
        healthbar.setHealth(currentHealth);
    }

}
