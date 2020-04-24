using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class gameOverMenu : MonoBehaviour
{
    private ToggleGroup mode;

   
    public void Quit()
    {
        Debug.Log("application quite!");
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        mode.GetComponent<ModeSelection>().activeToggle();
    }
}
