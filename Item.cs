using UnityEngine;

[CreateAssetMenu(fileName= "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public int price = 0;

    public enum Type { Default, Consumable, Weapon}

    public Type type = Type.Default;

    public bool isDefaultItem = false;


}
