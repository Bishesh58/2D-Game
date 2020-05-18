using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public float delay = 10;
    GameObject optionMenu;

    void Start()
    {
       
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
        SceneManager.LoadScene("UI System"); //moving player into the UI system scene
    }
}
