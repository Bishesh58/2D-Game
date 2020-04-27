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
        if (playerInRange)
        {
            DialogueBox.SetActive(true);
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

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

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
            stopDialogue();
            gameObject.SetActive(false);
        }
    }

    public void stopDialogue()
    {
        DialogueBox.SetActive(false);
        Brothers.SetActive(true);
        useWoodHint.SetActive(true);
        buildHut.woodIsReadyToUse = true;


    }

}
