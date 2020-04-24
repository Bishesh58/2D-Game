using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        image = transform.Find("image").GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
        UI_ItemDrag.Instance.Show(items);
    }

    public void OnDrag(PointerEventData eventData)
    {
       // rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
       
    }

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
