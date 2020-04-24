using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class vege4 : MonoBehaviour, IDropHandler
{
    private Image checkedImage;
    private int dropCount;

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

    private void Start()
    {
        checkedImage = transform.Find("checkedVege4").GetComponent<Image>();
    }

    public class OnItemDroppedEventArgs : EventArgs
    {
        public items items;
    }

    public void OnDrop(PointerEventData eventData)
    {
        items items = UI_ItemDrag.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { items = items });
        if (items.itemType == items.ItemType.vege1 || items.itemType == items.ItemType.vege2 ||
            items.itemType == items.ItemType.vege3 || items.itemType == items.ItemType.vege4 ||
            items.itemType == items.ItemType.vege5)
        {
            dropCount++;
            UI_Item d = eventData.pointerDrag.GetComponent<UI_Item>();
            if (eventData.pointerDrag != null)
            {
                d.parentToReturn = this.transform;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                checkedImage.gameObject.SetActive(true);
                if (dropCount <= 1)
                {
                    Hangi_layerController.checkmarkCount++;
                }
            }
            eventData.pointerDrag = null;
            UI_ItemDrag.Instance.Hide();
        }
        else
        {
            dropCount = 0;
        }


    }
}
