using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//class to handle when item is being dragged 
public class UI_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private items items;
    public Transform parentToReturn = null;
   
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("image").GetComponent<Image>(); //getting image component of the drag item
    }


    //event when item is started for dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturn = this.transform.parent; //when dropped on the slot, item position is parent to dropped slot
        this.transform.SetParent(this.transform.parent.parent);
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
        UI_ItemDrag.Instance.Show(items); // showing what item is being dragged
    }

    public void OnDrag(PointerEventData eventData)
    {
       // rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
       
    }

    //event when item is finished dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        UI_ItemDrag.Instance.Hide();
        this.transform.SetParent(parentToReturn);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    //getters and setters for sprite of the item
    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetItem(items items)
    {
        this.items = items;
        SetSprite(items.GetSprite(items.itemType));
    }
}
