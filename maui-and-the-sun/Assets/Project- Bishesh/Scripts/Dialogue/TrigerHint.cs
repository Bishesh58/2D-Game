using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerHint : MonoBehaviour
{
    public GameObject DialogueHint;
    public GameObject Maui;
    public bool playerInRange;

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = true;
            DialogueHint.gameObject.SetActive(true);
        }
    }
   

    public void stopDialogue()
    {
        playerInRange = false;
        DialogueHint.gameObject.SetActive(false);

    }

}
