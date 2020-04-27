﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class meat : MonoBehaviour, IDropHandler
{
   
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    private Image checkedImage;
    private int dropCount;

    private void Start()
    {
        checkedImage = transform.Find("checkedMeat").GetComponent<Image>();
    }
    public class OnItemDroppedEventArgs : EventArgs
    {
        public items items;
    }

    public void OnDrop(PointerEventData eventData)
    {
        items items = UI_ItemDrag.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { items = items });
        if (items.itemType == items.ItemType.meat)
        {
            dropCount++;
            UI_Item d = eventData.pointerDrag.GetComponent<UI_Item>();
            if (eventData.pointerDrag != null)
            {
                d.parentToReturn = this.transform;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                checkedImage.gameObject.SetActive(true);
                if (dropCount <=1)
                {
                    Hangi_layerController.checkmarkCount++;
                }
            }
            eventData.pointerDrag = null;
            UI_ItemDrag.Instance.Hide();
        }
       
    }
}