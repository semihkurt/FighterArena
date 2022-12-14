using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FighterSlot : MonoBehaviour
{
    protected DropArea dropArea;
	private DisableDropCondition disableDropCondition;

    protected virtual void Awake() 
    {
        //GameObject itemButtonGameObject = this.transform.GetChild(0).gameObject;
        //icon = itemButtonGameObject.transform.GetChild(0).gameObject;
        //Debug.Log("NAME: " + icon.name);

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
       // Debug.Log("InventorySlot OnItemDropped");

        //draggable.transform.position = this.transform.position;
		//currentItem = draggable;
		//dropArea.DropConditions.Add(disableDropCondition);
		//draggable.OnBeginDragHandler += CurrentItemOnBeginDrag;

        FighterBase draggableFighterBase = null;
        draggableFighterBase = draggable.gameObject.GetComponent<FighterBase>();  
        if(draggableFighterBase)
        {
            GameObject parentGameObject = this.gameObject.transform.parent.gameObject;

            string draggableGrandparentName = draggable.transform.parent.parent.name;
            string thisParentName = parentGameObject.name;
            //Debug.Log("This name: " + this.gameObject.name + " ,This' Parent : " + thisParentName);
            //Debug.Log("Draggable name: " + draggable.name + " ,Draggable's Parent: " + draggable.transform.parent.name);
            //Debug.Log("Draggable's parent's parent name: " + draggableGrandparentName);
           
            if(thisParentName == "FighterGrid" && draggableGrandparentName == "FighterShopGrid") //It means it is really adding into the inventory and must bought!!
            {
                FighterBase fighterBaseScript = this.gameObject.GetComponentInChildren<FighterBase>();
                if(fighterBaseScript.fighter != null)
                {
                    Debug.Log("This fighter slot is already filled!");
                    draggable.MoveToTheStartPosition();
                    return;
                }

                bool isEnoughCoinWeHave = CoinManager.instance.BuyFighter(draggableFighterBase.fighter);
                if(isEnoughCoinWeHave)
                {
                    GameObject childObject = this.gameObject.transform.GetChild(0).gameObject;
                    Image image = childObject.GetComponentInChildren<Image>();                    
                    fighterBaseScript.fighter = draggableFighterBase.fighter;
                    image.enabled = true;
                    image.sprite = fighterBaseScript.fighter.FighterSprite;

                    draggableFighterBase.fighter = null;
                    Image draggableImage = draggable.gameObject.GetComponent<Image>();
                    if(draggableImage)
                    {
                        draggableImage.sprite = null;
                        draggableImage.enabled = false;
                    }

                    Destroy(draggableFighterBase.fighter);
                }else{
                    draggable.MoveToTheStartPosition();
                }
            }else{ //Draggable item will be moved to anchor position
                draggable.MoveToTheStartPosition();
            }
        }
	}

    public void UpdateSlot()
    {
        /*if(Inventory.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            //icon.GetComponent<Image>().sprite = Inventory.instance.itemList[transform.GetSiblingIndex()].icon;
            //icon.SetActive(true);
        }else
        {
            //icon.SetActive(false);
        }*/
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
