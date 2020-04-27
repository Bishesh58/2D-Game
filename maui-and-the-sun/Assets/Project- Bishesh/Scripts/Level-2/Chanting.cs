using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chanting : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject Rope;
    public GameObject KarakiaDialogue;
    public GameObject NextLevel;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    





    public void Start()
    {
        StartCoroutine(Type());
    }
    public void DestoryInfo()
    {
        Destroy(dialogueBox.gameObject);
       
        KarakiaDialogue.gameObject.SetActive(true);
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
            if (index == 5)
            {
                Rope.gameObject.SetActive(true);
            }
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            stopDialogue();
            NextLevel.gameObject.SetActive(true);
        }
    }
    public void stopDialogue()
    {
        KarakiaDialogue.SetActive(false);
    }

    public void playNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
