using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField]
    private int _coin;
    public int Coin
    {
        get { return _coin; }
        set { _coin = Coin;          
        }
    }

    private TMP_Text coinText = null;

    // Start is called before the first frame update
    void Start()
    {              
        coinText = GameObject.Find("UI/CoinUI/CoinText").GetComponent<TMP_Text>();
        if(coinText)
        {
            Debug.Log("Coin is not null: " + _coin);
            coinText.text = _coin.ToString();
        }
    }

    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool BuyItem(Item item)
    {
        Debug.Log("We have: " + _coin + " in our pockets, and item " + item.ItemName + " costs us: " + item.ItemPrice);            
        if(_coin > item.ItemPrice)
        {
            _coin -= item.ItemPrice;
            coinText.text = _coin.ToString();
            Inventory.instance.AddItem(item);
            return true;      
        }
        return false;
    }

    public bool BuyFighter(Fighter fighter)
    {
        Debug.Log("We have: " + _coin + " in our pockets, and fighter " + fighter.FighterName + " costs us: " + fighter.FighterPrice);            
        if(_coin > fighter.FighterPrice)
        {
            _coin -= fighter.FighterPrice;
            coinText.text = _coin.ToString();
           // Inventory.instance.AddItem(fighter);
            return true;      
        }
        return false;
    }
}
