using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tree1 : MonoBehaviour
{
    //parameters
    private bool playerInRange;
    private bool isAlreadyTalking = false;
    public GameObject firstTree;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    


    public void Start()
    {
        StartCoroutine(Type());
    }

    public void Update()
    {
       
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            firstTree.SetActive(true); //player is ready to start conversation
        }

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    //Box colliders to check if player collides with the tree
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui" && !isAlreadyTalking)
        {
            playerInRange = true; //player is close to the tree1
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            isAlreadyTalking = true;
            playerInRange = false; //player is far from the tree1
        }
    }


    //returns methods after few seconds(conversation letters to be typed accordingly)
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
          
        }
    }

    //method to check if the Dialogue sentence is completed
    public void nextSentences()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
          

        }
        else
        {
            //if dialogue is finished then we stop the deactive the tree1
            textDisplay.text = "";
            stopDialogue(); 
        }
    }

    public void stopDialogue()
    {
        firstTree.SetActive(false);
    }
}
