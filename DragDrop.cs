using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    public event System.Action<PointerEventData> OnBeginDragHandler;

    public event System.Action<PointerEventData> OnDragHandler;

    public event System.Action<PointerEventData, bool> OnEndDragHandler;

    public bool FollowCursor {get; set; } = true;
    public bool CanDrag {get; set; } = true;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector3 startPosition;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        startPosition = rectTransform.anchoredPosition;
    }

    private void Update() {
        /*if(this.gameObject.GetComponent<ItemBase>().item == null)
        {
            CanDrag = false;          
        }else
        {
            CanDrag = true;
        }*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!CanDrag)
            return;
        Debug.Log("DragDrop OnBeginDrag");
        //canvasGroup.alpha = .6f;
        //canvasGroup.blocksRaycasts = false;

        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!CanDrag)
            return;

        if(FollowCursor)
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        //OnDragHandler.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!CanDrag)
        {
            return;
        }   

        var results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, results);

        DropArea dropArea = null;

		foreach (var result in results)
		{
			dropArea = result.gameObject.GetComponent<DropArea>();

			if (dropArea != null)
			{
				break;
			}
		}

		if (dropArea != null)
		{
			if (dropArea.Accepts(this))
			{
                Debug.Log("Drop!!");
				dropArea.Drop(this);
				OnEndDragHandler?.Invoke(eventData, true);
				return;
			}
		}

        //canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
        Debug.Log("OnEndDrag");
		rectTransform.anchoredPosition = startPosition;
        OnEndDragHandler?.Invoke(eventData, false);
		
    }
}
