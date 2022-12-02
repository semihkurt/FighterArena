using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        //Debug.Log("Picking up " + item.name);
        //Add to inventory
        //Inventory.instance.Add(item);
        //Destroy(gameObject);
    }

}
