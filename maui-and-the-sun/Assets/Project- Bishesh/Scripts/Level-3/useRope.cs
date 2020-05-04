using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class useRope : MonoBehaviour, IPointerClickHandler
{
    //setting up fields for game objects
    public static bool isReadyToUse = false;
    public GameObject hintRope;
    public GameObject ropeTrigger;
    public GameObject BrotherHoldingRope;
    public GameObject Rope;
    public GameObject Rope1;
    public GameObject Rope2;
    public GameObject Rope3;
    public GameObject movedBrothers;


    //when player clicks on to Rope slot
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isReadyToUse) //bool ready to use is true which means rope is available to use
        {
            movedBrothers.gameObject.SetActive(false); //deactivating moved brothers
            hintRope.SetActive(false); // hint message is disappered after using rope
            Destroy(ropeTrigger); // destorying the rope trigger game object
            Rope.SetActive(true); //showing the rope 
            Rope1.SetActive(true); //showing the rope
            Rope2.SetActive(true); //showing the rope
            Rope3.SetActive(true); //showing the rope
            BrotherHoldingRope.SetActive(true); //showing brothers holding rope

        }
    }
}
