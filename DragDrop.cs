using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] public Item item;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;


    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dragdrop OnDrop");
        Debug.Log ("DragDrop: OnPointerEnter="+eventData.pointerEnter.transform.parent.name);
        Debug.Log ("DragDrop: OnPointerEnter="+eventData.pointerEnter.transform.parent.parent.name);
        Debug.Log ("DragDrop: OnPointerEnter="+eventData.pointerDrag.transform.parent.name);
        Debug.Log ("DragDrop: OnPointerEnter="+eventData.pointerDrag.transform.parent.parent.name);
            
        //We dont want to implement drop on here, but instead of item slot. So lets make a new script
        throw new System.NotImplementedException();
    }
}
