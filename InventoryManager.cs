using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> items = new List<Item>();

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
    
    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    void Start()
    {
        itemSlots = FindObjectsOfType<ItemSlot>();
    }
   
   
}
