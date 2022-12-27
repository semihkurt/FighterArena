using UnityEngine;

[CreateAssetMenu(fileName= "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemID;
    [SerializeField] private string itemName;
    [SerializeField] private int itemLevel;
    [SerializeField] private int itemPrice;
    //[SerializeField] enum Type { Default, Consumable, Weapon, Armor}
    //[SerializeField] Type type = Type.Default;
    [SerializeField] private Sprite itemSprite;

    //#region Getters and Setters
    public string ItemID { get => itemID; set => itemID = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public int ItemPrice { get => itemPrice; set => itemPrice = value; }
    public int ItemLevel { get => itemLevel; set => itemLevel = value; }
    public Sprite ItemSprite { get => itemSprite; set => itemSprite = value; }
}
