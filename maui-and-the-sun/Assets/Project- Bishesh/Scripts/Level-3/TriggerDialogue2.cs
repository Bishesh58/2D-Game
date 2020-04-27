using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerDialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject DialogueBox2;
    public GameObject Brothers;
    public GameObject MovedBrothers;
    bool playerInRange;


    public void Start()
    {
        StartCoroutine(Type());
    }
    public void Update()
    {
        if (playerInRange)
        {
            DialogueBox2.SetActive(true);
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
        Destroy(DialogueBox2);
        Destroy(Brothers.gameObject);
        MovedBrothers.SetActive(true);
    }

}
