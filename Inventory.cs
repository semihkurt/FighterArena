using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();

    public Item[] itemList = new Item[20];
    public ItemSlot[] itemSlots;


    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    
    public void AddItem(Item item)
    {
        bool hasAdded = Add(item);

        if(hasAdded)
        {
            UpdateSlotUI();
        }

        /*if(!item.isDefaultItem)
        {
            items.Add(item);
        }*/
    }

    private bool Add(Item item)
    {
        for(int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == null)
            {
                itemList[i] = item;
                return true;
            }
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    void Start()
    {
        itemSlots = FindObjectsOfType<ItemSlot>();
        UpdateSlotUI();
    }
   
    public void UpdateSlotUI()
    {
        Debug.Log("UpdateSlotUI item slot amount:" + itemSlots.Length);
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].UpdateSlot();
        }
    }
   
   
}
