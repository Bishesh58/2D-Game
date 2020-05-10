using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tree3 : MonoBehaviour
{
    bool playerInRange;
    public GameObject thirdTree;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject wood;


    public void Start()
    {
        StartCoroutine(Type());
    }

    public void Update()
    {
        //checking if player is close to tree and keyword 'T' is pressed or not
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            thirdTree.SetActive(true);
        }
    }
    //Box colliders to check if player collides with the tree
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = true; //player is close to the tree3
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = false; //player is far from the tree3
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
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            //if dialogue is finished then we stop the deactive the tree3
            textDisplay.text = "";
            stopDialogue();
        }
    }

    public void stopDialogue()
    {
        thirdTree.SetActive(false);
        wood.SetActive(true);

    }
}
