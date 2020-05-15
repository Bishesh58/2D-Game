using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//class to handle all the button click
public class ButtonHandler : MonoBehaviour
{
    //field fo the game object
    public GameObject hangiLayerController;
    public GameObject messageBoxHangi;
    public GameObject playerInstruct;
    public GameObject hangiInfo;
    public GameObject congratulationBox;
    public GameObject maui;
    public GameObject hangiImage;
    public MainMenu MainMenu;
    public GameObject continueButton;
    public GameObject audioSound;


    //showing hangi layers on method call
    public void ShowHangiLayer()
    {
        messageBoxHangi.gameObject.SetActive(false); 
        playerInstruct.gameObject.SetActive(true); // player instruct message box is shown
        hangiLayerController.gameObject.SetActive(true); // hangi inventory is active
        StartCoroutine(RemoveAfterSeconds(10, playerInstruct.gameObject)); //removes game object after 10 seconds
    }
   
    //showing up hangi information game object
    public void showHangiInfo()
    {
        congratulationBox.gameObject.SetActive(false);
        hangiInfo.gameObject.SetActive(true);
        maui.gameObject.SetActive(false); // removing the player from the scene
        hangiImage.gameObject.SetActive(true); //showing hangi image
        continueButton.gameObject.SetActive(true); //showing continue button
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(15);
        obj.SetActive(false);
    }

    //on method call, opens given link into the browser
    public void openLink()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=984UPAEdKbs&feature=youtu.be");
    }

    
    public void playLevel2()
    {
        Destroy(hangiImage.gameObject);
        Destroy(hangiInfo.gameObject);
        continueButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loading level 2 
    }

    public void playsong()
    {
        FindObjectOfType<AudioManager>().Play("button_press"); //playing sound for button press
    }

    public void playAudio()
    {
        audioSound.SetActive(true); //playing sound
    }
}
