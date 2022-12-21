using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item[] items;

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
    public int getIndex(ItemSlot pSlot)
    {
        if(pSlot != null)
        {
            for(int i = 0; i < itemSlots.Length; i++)
            {
                if(pSlot == itemSlots[i])
                    return i;
            }
        }else{
            Debug.Log("pSlot is null");
        }
        return -1;
    }

    public void Add(Item item,int index)
    {
        items[index] = item;
    }

    public void Add(Item item,ItemSlot pSlot)
    {
        int index = getIndex(pSlot);
        if(index != -1)
            items[index] = item;
        else
            Debug.Log("Item slot index returned null while adding!!");
    }

    public void Remove(ItemSlot pSlot)
    {
        int index = getIndex(pSlot);
        if(index != -1)
            items[index] = null;
        else
           Debug.Log("Item slot index returned null while removing!!"); 
    }

    public void Remove(int index)
    {
        items[index] = null;
    }

    void Start()
    {
        itemSlots = FindObjectsOfType<ItemSlot>();
        items = new Item[itemSlots.Length];

    }
   
   
}
