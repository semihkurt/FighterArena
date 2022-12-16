using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FighterSlot : MonoBehaviour, IPointerClickHandler
{
    protected DropArea dropArea;
	private DisableDropCondition disableDropCondition;

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
        FighterBase draggableFighterBase = null;
        draggableFighterBase = draggable.gameObject.GetComponent<FighterBase>();  
        if(draggableFighterBase)
        {
            GameObject parentGameObject = this.gameObject.transform.parent.gameObject;

            string draggableGrandparentName = draggable.transform.parent.parent.name;
            string thisParentName = parentGameObject.name;
           
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(this.gameObject.transform.parent.gameObject.name == "FighterGrid")
        {
            FighterBase fighterBaseScript = this.gameObject.GetComponentInChildren<FighterBase>();
            if(fighterBaseScript.fighter != null)
            {
                GameObject fighterPageGameObject = FighterPageManager.instance.fighterPageGameObject;
                fighterPageGameObject.SetActive(true);

                Debug.Log("Fighter character info will be opened! " + fighterPageGameObject.name);
                
            }
        }
        //throw new System.NotImplementedException();
    }

}
