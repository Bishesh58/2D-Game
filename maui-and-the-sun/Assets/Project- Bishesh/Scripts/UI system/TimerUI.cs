using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    // code to change after completion of level 2
    public static float countdownStartValue = 0;
    public Text timerUI;
    [SerializeField]
    GameObject gameOverScrn;
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        gameOverScrn = GameObject.Find("gameOverScreen");
        player = GameObject.Find("Ch-Maui");
        gameOverScrn.SetActive(false);                     
        countdownTimer();

    }

    public void countdownTimer()
    {
        if (countdownStartValue>0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countdownStartValue);
            timerUI.text = spanTime.Minutes + ":" + spanTime.Seconds;
            countdownStartValue--;
            Invoke("countdownTimer", 1.0f);
        }

        //uncomment this code after completion of all levels
        //else
        //{
        //    timerUI.text = "Time up!";
        //    gameOverScrn.SetActive(true);
        //    Destroy(player.gameObject);
        //}
    }

   
   
}
