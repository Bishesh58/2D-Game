using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonHandler : MonoBehaviour
{
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



    public void ShowHangiLayer()
    {
        messageBoxHangi.gameObject.SetActive(false);
        playerInstruct.gameObject.SetActive(true);
        hangiLayerController.gameObject.SetActive(true);
        StartCoroutine(RemoveAfterSeconds(10, playerInstruct.gameObject));
    }
   
    public void showHangiInfo()
    {
        congratulationBox.gameObject.SetActive(false);
        hangiInfo.gameObject.SetActive(true);
        maui.gameObject.SetActive(false);
        hangiImage.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(15);
        obj.SetActive(false);
    }

    public void openLink()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=7kwu6c7rN0I");
    }

    public void playLevel2()
    {
        Destroy(hangiImage.gameObject);
        Destroy(hangiInfo.gameObject);
        continueButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playsong()
    {
        FindObjectOfType<AudioManager>().Play("button_press");
    }

    public void playAudio()
    {
        audioSound.SetActive(true);
    }
}
