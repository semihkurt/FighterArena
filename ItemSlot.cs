using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    protected DropArea dropArea;
	private DisableDropCondition disableDropCondition;

    protected virtual void Awake() 
    {
        dropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
		dropArea.OnDropHandler += OnItemDropped;
		//disableDropCondition = new DisableDropCondition();
    }

    public void Initialize(DragDrop currentItem)
	{
		if (currentItem == null)
		{
			Debug.LogError("Tried to initialize the slot with an null item!");
			return;
		}

		OnItemDropped(currentItem);
	}

    private void OnItemDropped(DragDrop draggable)
	{
        ItemBase draggableItemBase = null;
        draggableItemBase = draggable.gameObject.GetComponent<ItemBase>();  
        if(draggableItemBase)
        {
            GameObject parentGameObject = this.gameObject.transform.parent.gameObject;

            string draggableGrandparentName = draggable.transform.parent.parent.name;
            string thisParentName = parentGameObject.name;
  
            Debug.Log("Draggable grand parent name: " + draggableGrandparentName + " , thisParentName: " + thisParentName);
            if(thisParentName == "InventoryGrid" && draggableGrandparentName == "ItemShopGrid") //It means it is really adding into the inventory and must bought!!
            {
                ItemBase itemBaseScript = this.gameObject.GetComponentInChildren<ItemBase>();
                if(itemBaseScript.item != null)
                {
                    Debug.Log("This slot is already filled!");
                    draggable.MoveToTheStartPosition();
                    return;
                }

                bool isEnoughCoinWeHave = CoinManager.instance.BuyItem(draggableItemBase.item);
                if(isEnoughCoinWeHave)
                {
                    GameObject childObject = this.gameObject.transform.GetChild(0).gameObject;
                    Image image = childObject.GetComponentInChildren<Image>();                    
                    itemBaseScript.item = draggableItemBase.item;
                    image.enabled = true;
                    image.sprite = itemBaseScript.item.ItemSprite;

                    draggableItemBase.item = null;
                    Image draggableImage = draggable.gameObject.GetComponent<Image>();
                    if(draggableImage)
                    {
                        draggableImage.sprite = null;
                        draggableImage.enabled = false;
                    }

                    Destroy(draggableItemBase.item);
                }else{
                    draggable.MoveToTheStartPosition();
                }
            }else if(thisParentName == "FighterPage" && draggableGrandparentName == "InventoryGrid")
            {
                Debug.Log("Item is worn by Fighter");

                ItemBase itemBaseScript = this.gameObject.GetComponentInChildren<ItemBase>();
                Debug.Log("This gameobject name: " + this.gameObject.name);
                if(itemBaseScript.item != null)
                {
                    Debug.Log("This slot is already filled!");
                    draggable.MoveToTheStartPosition();
                    return;
                }

                GameObject childObject = this.gameObject.transform.GetChild(0).gameObject;
                Image image = childObject.GetComponentInChildren<Image>();                    
                itemBaseScript.item = draggableItemBase.item;
                image.enabled = true;
                image.sprite = itemBaseScript.item.ItemSprite;

                draggableItemBase.item = null;
                Image draggableImage = draggable.gameObject.GetComponent<Image>();
                if(draggableImage)
                {
                    draggableImage.sprite = null;
                    draggableImage.enabled = false;
                }

                Destroy(draggableItemBase.item);
                
                FighterPageManager.instance.WearItemToFighter(itemBaseScript);
            }
            else{ //Draggable item will be moved to anchor position
                draggable.MoveToTheStartPosition();
            }
        }
	}

    //Current item is being dragged so we listen for the EndDrag event
	/*private void CurrentItemOnBeginDrag(PointerEventData eventData)
	{
        Debug.Log("InventorySlot CurrentItemBeginOnDrag");
		currentItem.OnEndDragHandler += CurrentItemEndDragHandler;
	}*/

	/*private void CurrentItemEndDragHandler(PointerEventData eventData, bool dropped)
	{
        Debug.Log("InventorySlot CurrentitemEndDrag");
		currentItem.OnEndDragHandler -= CurrentItemEndDragHandler;

		if (!dropped)
		{
			return;
		}

		dropArea.DropConditions.Remove(disableDropCondition); //We dropped the component in another slot so we can remove the DisableDropCondition
		currentItem.OnBeginDragHandler -= CurrentItemOnBeginDrag; //We make sure to remove this listener as the item is no longer in this slot
		currentItem = null; //We no longer have an item in this slot, so we remove the refference
	}*/
}
