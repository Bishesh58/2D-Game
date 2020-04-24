using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hangi_LayerSlot : MonoBehaviour, IDropHandler
{

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    public class OnItemDroppedEventArgs : EventArgs
    {
        public items items;
    }
   
    public void OnDrop(PointerEventData eventData)
    {

        items items = UI_ItemDrag.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { items = items });
        UI_Item d = eventData.pointerDrag.GetComponent<UI_Item>();
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            UI_ItemDrag.Instance.Hide();
            d.parentToReturn = this.transform;

        }

    }
}


