using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPageManager : MonoBehaviour
{
    public GameObject fighterPageGameObject;
    public static FighterPageManager instance;

    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        //DontDestroyOnLoad(this);
    }

    public void RemoveItemFromFighter(ItemBase itemBase)
    {
        if(fighterPageGameObject != null)
        {
            FighterPage fighterPage = fighterPageGameObject.GetComponent<FighterPage>();
            if(fighterPage != null)
            {
                //Debug.Log("Fighter page is not null");
                FighterBase fighterBase = fighterPage.GetComponentInChildren<FighterBase>();
                if(fighterBase != null)
                {
                    //Debug.Log("Fighter base is not null");
                    if(fighterBase.fighter != null)
                    {
                        //Debug.Log("Fighter is not null");   
                        ItemBase[] itemBaseArray = fighterPageGameObject.GetComponentsInChildren<ItemBase>();
                        if(itemBaseArray[0] == itemBase)
                        {      
                            Debug.Log("Fighter removes item1: " + itemBase.item);  
                            fighterBase.fighter.Item1 = null;
                        }
                        else if(itemBaseArray[1] == itemBase)
                        {                         
                            Debug.Log("Fighter removes item2: " + itemBase.item);
                            fighterBase.fighter.Item2 = null;  
                        }
                        else if(itemBaseArray[2] == itemBase)
                        {
                            Debug.Log("Fighter removes item3: " + itemBase.item);  
                            fighterBase.fighter.Item3 = null;
                        }                                  
                    }   
                }   
            }         
        }
    }

    public void WearItemToFighter(ItemBase itemBase)
    {     
        if(fighterPageGameObject != null)
        {
            FighterPage fighterPage = fighterPageGameObject.GetComponent<FighterPage>();
            if(fighterPage != null)
            {
                //Debug.Log("Fighter page is not null");
                FighterBase fighterBase = fighterPage.GetComponentInChildren<FighterBase>();
                if(fighterBase != null)
                {
                    //Debug.Log("Fighter base is not null");
                    if(fighterBase.fighter != null)
                    {
                        //Debug.Log("Fighter is not null");   
                        ItemBase[] itemBaseArray = fighterPageGameObject.GetComponentsInChildren<ItemBase>();
                        if(itemBaseArray[0] == itemBase)
                        {
                            fighterBase.fighter.Item1 = itemBase.item;
                            Debug.Log("Fighter has item1: " + fighterPage.fighter.Item1.name);  
                        }
                        else if(itemBaseArray[1] == itemBase)
                        {
                            fighterBase.fighter.Item2 = itemBase.item;
                            Debug.Log("Fighter has item2: " + fighterPage.fighter.Item2.name);  
                        }
                        else if(itemBaseArray[2] == itemBase)
                        {
                            fighterBase.fighter.Item3 = itemBase.item;
                            Debug.Log("Fighter has item3: " + fighterPage.fighter.Item3.name);  
                        }                                  
                    }   
                }   
            }         
        }
    }

}
