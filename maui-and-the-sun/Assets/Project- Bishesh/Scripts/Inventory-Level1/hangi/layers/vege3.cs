using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//class to handle vegetable 3 slot
public class vege3 : MonoBehaviour, IDropHandler
{
    private Image checkedImage;
    private int dropCount;
    CanvasGroup canvasGroup;
    //event to check if item is dropped
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

    private void Start()
    {
        checkedImage = transform.Find("checkedVege3").GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public class OnItemDroppedEventArgs : EventArgs
    {
        public items items; // getting the item from class items
    }

    // event handler for item is being dropped on this layer
    public void OnDrop(PointerEventData eventData)
    {
        items items = UI_ItemDrag.Instance.GetItem(); // getting dragged item from the UI_ItemDrag class
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { items = items });  //checking if dropped item is match with right slot between availabe 5 slot
        if (items.itemType == items.ItemType.vege1 || items.itemType == items.ItemType.vege2 ||
            items.itemType == items.ItemType.vege3 || items.itemType == items.ItemType.vege4 ||
            items.itemType == items.ItemType.vege5)
        {
            dropCount++; //counting dropped item on each time it is being dropped into the slot
            UI_Item d = eventData.pointerDrag.GetComponent<UI_Item>();
            //checking if cursor is dragging something
            if (eventData.pointerDrag != null)
            {
                d.parentToReturn = this.transform; //setting current slot as parent slot for the dropped item
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;  //snapping the item onto the slot
                canvasGroup.blocksRaycasts = false;
                checkedImage.gameObject.SetActive(true); //correct item is dropped and green checkmark is shown 
                if (dropCount <= 1)
                {
                    Hangi_layerController.checkmarkCount++; //global int to count how many green checkmark are active
                }
            }
            eventData.pointerDrag = null; // player can not drag item anymore
            UI_ItemDrag.Instance.Hide(); //making sure instance of drag item are hiding after the dropped
        }
        else
        {
            dropCount = 0; // count is zero if dropped item is not the right item
        }
    }
}
