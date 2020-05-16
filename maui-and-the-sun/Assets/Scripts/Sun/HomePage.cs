using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public float delay = 10;
    public string NewLevel = "UI System";
    GameObject optionMenu;
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }
}
