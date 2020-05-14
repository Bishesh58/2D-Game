using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chanting : MonoBehaviour
{  
    //setting up fields
    public GameObject dialogueBox;
    public GameObject Rope;
    public GameObject KarakiaDialogue;
    public GameObject NextLevel;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    
    public void Start()
    {
        StartCoroutine(Type()); //method to start function after given time
    }
    public void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    public void DestoryInfo() //destorying information box and showing karakia Dialogue Box
    {
        Destroy(dialogueBox.gameObject);
       
        KarakiaDialogue.gameObject.SetActive(true);
    }

    IEnumerator Type() // method to type each letters on given typing speed
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); 
        }
    }

    //method to check if one sentence is finished typing
    public void nextSentences()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            if (index == 4)
            {
                Rope.gameObject.SetActive(true); // setting the brighter rope game object active to indicate it's being chanted
            }
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            stopDialogue();  //stopping dialogue when typing is finished
            NextLevel.gameObject.SetActive(true);
        }
    }
    public void stopDialogue()
    {
        KarakiaDialogue.SetActive(false); //deactivationg karakia Dialogue box
    }

    public void playNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // player moving into the next scene
    }


}
