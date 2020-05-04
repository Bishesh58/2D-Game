using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject DialogueBox;
    public GameObject useWoodHint;
    public GameObject Brothers;
    public GameObject hut;
    public GameObject hutBlock;
    bool playerInRange;


    public void Start()
    {
        StartCoroutine(Type());
    }
    public void Update()
    {
        if (playerInRange) // when player collides with this game object
        {
            DialogueBox.SetActive(true); //Showing dialogue Box
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            playerInRange = false;
        }
    }

    //method for typing speed for letters of the dialogue
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //method to check if one sentence is completed and moving onto the next sentence
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
            textDisplay.text = "";
            stopDialogue(); //stopping the dialogue when all sentence is completed
            gameObject.SetActive(false);
        }
    }

    public void stopDialogue()
    {
        DialogueBox.SetActive(false); //removing dialogue box
        Brothers.SetActive(true); //showing up Brothers
        useWoodHint.SetActive(true); //hint is shown
        buildHut.woodIsReadyToUse = true; //player can click on wood for use
    }

}
