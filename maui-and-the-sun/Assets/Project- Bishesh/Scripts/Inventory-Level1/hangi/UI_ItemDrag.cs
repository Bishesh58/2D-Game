using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ItemDrag : MonoBehaviour
{
    //global instance for getting and setting dragged item
    public static UI_ItemDrag Instance { get; private set; }

    private Canvas canvas;
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private items item;

    private void Awake()
    {
        Instance = this;

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("image").GetComponent<Image>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

        Hide(); //method to hide item
    }

    private void Update()
    {
        UpdatePosition(); 
    }

    //method to update the position of the item when it is dropped on the slot
    private void UpdatePosition()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }

    //getting and setting items
    public items GetItem()
    {
        return item;
    }

    public void SetItem(items item)
    {
        this.item = item;
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
    //method to hide items
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    //method to show item
    public void Show(items item)
    {
        gameObject.SetActive(true);

        SetItem(item);
        SetSprite(item.GetSprite());
        UpdatePosition();
    }
   
}
