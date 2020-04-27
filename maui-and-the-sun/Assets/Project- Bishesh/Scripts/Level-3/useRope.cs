using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class useRope : MonoBehaviour, IPointerClickHandler
{
    public static bool isReadyToUse = false;
    public GameObject hintRope;
    public GameObject ropeTrigger;
    public GameObject BrotherHoldingRope;
    public GameObject Rope;
    public GameObject Rope1;
    public GameObject Rope2;
    public GameObject Rope3;
    public GameObject movedBrothers;



    public void OnPointerClick(PointerEventData eventData)
    {
        if (isReadyToUse)
        {
            Destroy(movedBrothers);
            hintRope.SetActive(false);
            Destroy(ropeTrigger);
            Rope.SetActive(true);
            Rope1.SetActive(true);
            Rope2.SetActive(true);
            Rope3.SetActive(true);
            BrotherHoldingRope.SetActive(true);

        }
    }
}
