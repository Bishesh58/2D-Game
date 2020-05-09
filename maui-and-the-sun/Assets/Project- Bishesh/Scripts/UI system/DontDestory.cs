using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
    // Start is called before the first frame update
    CanvasGroup canvasGroup;
    CanvasGroup OptionMenuCanvas;
    public GameObject optionMenu;
    private static GameObject instance;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
       
    }

    void Start()
    {
        OptionMenuCanvas = optionMenu.gameObject.GetComponent<CanvasGroup>();
        OptionMenuCanvas.alpha = 0f;
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "UI System")
        {
            canvasGroup.alpha = 1f;
        }
        else
        {
            canvasGroup.alpha = 0f;
            optionMenu.SetActive(true);
        }
       
    }

    public void showOptionMenu()
    {
        OptionMenuCanvas.alpha = 1f;
    }
}
