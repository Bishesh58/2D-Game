using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buildHut : MonoBehaviour, IPointerClickHandler
{
    public GameObject hut;
    public GameObject hutBlock;
    public GameObject useWoodHint;
    public GameObject holdMaui;
    public static bool woodIsReadyToUse = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (woodIsReadyToUse)
        {
            hut.SetActive(true);
            hutBlock.SetActive(true);
            Destroy(useWoodHint);
            Destroy(holdMaui);
            
        }
    }
}
