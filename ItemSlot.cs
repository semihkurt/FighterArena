using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    protected DropArea dropArea;

    protected virtual void Awake() 
    {
        dropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
		dropArea.OnDropHandler += OnItemDropped;
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
            if(thisParentName == "InventoryGrid" && draggableGrandparentName == "ItemShopGrid") //Item is dragged from ItemShop to Inventory
            {
                ItemBase itemBaseScript = this.gameObject.GetComponentInChildren<ItemBase>();
                if(itemBaseScript.item != null)
                {
                    Debug.Log("This slot is already filled!");
                    draggable.MoveToTheStartPosition();
                    return;
                }

                bool isEnoughCoinWeHave = CoinManager.instance.BuyItem(draggableItemBase.item);
                if(isEnoughCoinWeHave)  //Item is purchased
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

                    ItemSlot slot = this.gameObject.GetComponent<ItemSlot>();
                    InventoryManager.instance.Add(itemBaseScript.item, slot);

                    Destroy(draggableItemBase.item);
                }else{
                    draggable.MoveToTheStartPosition();
                }
            }else if(thisParentName == "FighterPage" && draggableGrandparentName == "InventoryGrid") //Item is worn by Fighter.
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

                ItemSlot slot = draggable.gameObject.GetComponentInParent<ItemSlot>();
                InventoryManager.instance.Remove(slot);
                FighterPageManager.instance.WearItemToFighter(itemBaseScript);

                Destroy(draggableItemBase.item);         
            }else if(thisParentName == "InventoryGrid" && draggableGrandparentName == "FighterPage") //Item is removed from Fighter
            {
                Debug.Log("Item is removed from Fighter");
                ItemBase itemBaseScript = this.gameObject.GetComponentInChildren<ItemBase>();
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


                ItemSlot slot = this.gameObject.GetComponent<ItemSlot>();
                InventoryManager.instance.Add(itemBaseScript.item, slot);
                FighterPageManager.instance.RemoveItemFromFighter(draggableItemBase);

                Destroy(draggableItemBase.item);
            }
            else{ //Draggable item will be moved to anchor position
                draggable.MoveToTheStartPosition();
            }
        }
	}

}
