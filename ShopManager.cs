using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject itemShop;
    public GameObject fighterShop;

    public void FighterShopClicked()
    {  
        fighterShop.SetActive(!fighterShop.activeSelf);
    }

    public void ItemShopClicked()
    {
        itemShop.SetActive(!itemShop.activeSelf);
        
    }
}
