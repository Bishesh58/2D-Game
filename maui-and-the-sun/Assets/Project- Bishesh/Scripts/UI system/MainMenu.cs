using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject InfoBox;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager. GetActiveScene().buildIndex + 1); //loading up next scene index
        Hangi_layerController.checkmarkCount = 0;
    }
    public void QuiteGame()
    {
        Debug.Log("Quite!");
        Application.Quit(); //player can exit from the application
    }

    public void DestoryObject()
    {
        Destroy(InfoBox); //destorying Information message box
    }
}
