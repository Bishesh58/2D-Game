using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//class that handles the dragging of the item
public class Drag_Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); //setting RectTransform component of the this game object
        canvasGroup = GetComponent<CanvasGroup>();  //setting canvas of this game object
    }

    
    private void Start()
    {
        startPosition = rectTransform.anchoredPosition; //starting position where the item is started dragging
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling(); //last sibling will always put item on the top of the other drag items

        canvasGroup.alpha = .6f; // brightness of the item is lower when dragging
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; //follows the pointer position where dragging
    }

    // item is being stop dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startPosition; 
        canvasGroup.blocksRaycasts = true; 
        canvasGroup.alpha = 1f; // brightness of the item is set to default
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
