using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private GameObject icon;
    private Item item;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("InventorySlot OnDrop");
        if(eventData.pointerDrag != null)
        {
           /* Debug.Log ("InventorySlot: OnPointerEnter="+eventData.pointerEnter.transform.parent.name);
            Debug.Log ("InventorySlot: OnPointerEnter="+eventData.pointerEnter.transform.parent.parent.name);
            Debug.Log ("InventorySlot: OnPointerEnter="+eventData.pointerDrag.transform.parent.name);
            Debug.Log ("InventorySlot: OnPointerEnter="+eventData.pointerDrag.transform.parent.parent.name);
            Debug.Log("ItemSlot Drop  pointerDrag is not null");*/

            //Debug.Log("Child name: " + this.transform.GetChild(0).gameObject.name);
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
            GameObject pItem = eventData.pointerDrag.gameObject;
            Debug.Log("pItem name:" + pItem.name);
          
            GameObject pIcon = eventData.pointerDrag.transform.GetChild(1).gameObject;
            //Debug.Log("pIcon name:" + pIcon.name);
   
            icon.GetComponent<Image>().sprite = pIcon.GetComponent<Image>().sprite;
            icon.GetComponent<Image>().enabled = true;

            GameObject scipt = pItem.GetComponent("DragDrop").gameObject;
            Debug.Log("script: " + scipt.name);

            Debug.Log(pItem.GetComponent<ScriptableObject>().name);


           // eventData.pointerDrag.GetComponent<Image> 
            //Inventory.instance.AddItem();
        }
    }

    public void UpdateSlot()
    {
        if(Inventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            //icon.GetComponent<Image>().sprite = Inventory.instance.itemList[transform.GetSiblingIndex()].icon;
            //icon.SetActive(true);
        }else
        {
            //icon.SetActive(false);
        }
    }

    private void Awake() 
    {
        GameObject itemButtonGameObject = this.transform.GetChild(0).gameObject;
        icon = itemButtonGameObject.transform.GetChild(0).gameObject;
        //Debug.Log("NAME: " + icon.name);
    }
}
