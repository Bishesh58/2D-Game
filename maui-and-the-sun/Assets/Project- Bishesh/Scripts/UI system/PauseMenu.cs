using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false; //global variable
    public GameObject PauseMenuUI;
    GameObject optionMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //if player pressed 'Escape'
        {
            if (GameIsPause)
            {
                Resume(); //method call
            }
            else
            {
                Pause(); //method call
            }
        }
    }

    void Pause() 
    {
        PauseMenuUI.SetActive(true);  //showing Pause Menu UI
        Time.timeScale = 0f; //time is being frozen
        GameIsPause = true; //game is on pause state
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false); //destroying Pause Menu UI
        Time.timeScale = 1f; //time started again from where it was frozen
        GameIsPause = false; //game is not on pause state
    }

    public void loadMenu()
    {
        Time.timeScale = 1f; //Time is being set as default
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
        SceneManager.LoadScene("UI System"); //moving player into the UI system scene
    }
    public void quitGame()
    {
        Application.Quit(); //Stopping the game and exiting
        Debug.Log("game end!");
    }

}
