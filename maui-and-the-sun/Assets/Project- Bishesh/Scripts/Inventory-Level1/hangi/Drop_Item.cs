﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop_Item : MonoBehaviour, IDragHandler
{

    //event for handling drop item
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drop received");
    }
}
