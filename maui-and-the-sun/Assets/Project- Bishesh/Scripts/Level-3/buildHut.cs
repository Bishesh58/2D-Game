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

    //when player clicks on the Wood Slot
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (woodIsReadyToUse) //bool ready to use is true which means wood is available to use
        {
            hut.SetActive(true); //hut is build after clicking on wood from the inventory
            hutBlock.SetActive(true); //blocking player from moving forward
            Destroy(useWoodHint); //destorying hint message 
            Destroy(holdMaui); 
            
        }
    }
}
