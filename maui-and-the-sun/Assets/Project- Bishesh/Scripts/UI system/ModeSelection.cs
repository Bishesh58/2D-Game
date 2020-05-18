using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour
{
    //field for toggle
    public Toggle easy;
    public Toggle intermediate;
    public Toggle hard;


   
    //checking what toggle is being active 
    public void logToggle()
    {
        activeToggle(); //method
    }
    public void activeToggle()
    {
        if (easy.isOn) //checking if easy toggle is active
        {
            TimerUI.countdownStartValue = 600; //setting up starting time
        }
        else if (intermediate.isOn) //checking if intermediate toggle is active
        {
            TimerUI.countdownStartValue = 300; //setting up starting time
        }
        else if (hard.isOn) //checking if hard toggle is active
        {
            TimerUI.countdownStartValue = 150; //setting up starting time
        }
    }
   
}
