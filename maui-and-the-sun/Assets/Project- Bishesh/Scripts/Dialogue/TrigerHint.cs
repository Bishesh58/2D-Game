using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerHint : MonoBehaviour
{
    //setting up parameters
    public GameObject DialogueHint;
    public GameObject Maui;
    public bool playerInRange;

    
    //If player collides with the Plant then we show hint Dialogue
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = true; 
            DialogueHint.gameObject.SetActive(true);
        }
    }
   
    //Dialogue is stop when player exit the collider
    public void stopDialogue()
    {
        playerInRange = false; 
        DialogueHint.gameObject.SetActive(false);

    }

}
