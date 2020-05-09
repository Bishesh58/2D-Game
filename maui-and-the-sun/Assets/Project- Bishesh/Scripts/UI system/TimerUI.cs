using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerUI : MonoBehaviour
{
    // code to change after completion of level 2
    public static float countdownStartValue = 0; //global variable
    public Text timerUI;
    [SerializeField]
    GameObject gameOverScrn;
    GameObject player;
    ModeSelection toggleGroup;
    




    // Start is called before the first frame update
    void Start()
    {
        
        toggleGroup = GameObject.Find("Toggle Group").GetComponent<ModeSelection>();
        toggleGroup.logToggle();
        gameOverScrn = GameObject.Find("gameOverScreen");
        player = GameObject.Find("Ch-Maui");
        gameOverScrn.SetActive(false); //hiding game over screen on starting the game                    
        countdownTimer(); //method

    }

    //setting up timer
    public void countdownTimer()
    {
        if (countdownStartValue>0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countdownStartValue);
            timerUI.text = spanTime.Minutes + ":" + spanTime.Seconds;
            countdownStartValue--;
            Invoke("countdownTimer", 1.0f);
        }

        //when time is up game over screen is active
        else
        {
            timerUI.text = "Time up!";
            gameOverScrn.SetActive(true);
            Destroy(player.gameObject);
        }
    }

   
   
}
