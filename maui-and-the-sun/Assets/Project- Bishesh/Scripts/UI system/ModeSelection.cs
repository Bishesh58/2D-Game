using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour
{

    public Toggle easy;
    public Toggle intermediate;
    public Toggle hard;
    


    public void logToggle()
    {
        activeToggle();
    }
    public void activeToggle()
    {
        if (easy.isOn)
        {
            TimerUI.countdownStartValue = 600;
        }
        else if (intermediate.isOn)
        {
            TimerUI.countdownStartValue = 300;
        }
        else if (hard.isOn)
        {
            TimerUI.countdownStartValue = 150;
        }
    }
   
   
}
