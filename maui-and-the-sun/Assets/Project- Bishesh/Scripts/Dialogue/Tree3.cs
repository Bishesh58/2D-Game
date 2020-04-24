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


    public void Start()
    {
        StartCoroutine(Type());
    }

    public void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.T))
        {
            thirdTree.SetActive(true);
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
        }
    }

    public void stopDialogue()
    {
        thirdTree.SetActive(false);
    }
}
