using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject itemShop;
    public GameObject fighterShop;
    public FighterSlot[] fighterSlots;
    public ItemSlot[] itemSlots;

    private void Awake() {
        fighterSlots = FindObjectsOfType<FighterSlot>();
        itemSlots = FindObjectsOfType<ItemSlot>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FighterShopClicked()
    {  
        fighterShop.SetActive(!fighterShop.activeSelf);
    }

    public void ItemShopClicked()
    {
        itemShop.SetActive(!itemShop.activeSelf);
        
    }
}
