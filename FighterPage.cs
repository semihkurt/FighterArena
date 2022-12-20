using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterPage : MonoBehaviour
{
    public static FighterPage instance;

    [SerializeField] public Fighter fighter;
    [SerializeField] public Item item1;
    [SerializeField] public Item item2;
    [SerializeField] public Item item3;

    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void CloseButtonClicked()
    {
        fighter = null;
        item1 = null;
        item2 = null;
        item3 = null;

        /*FighterBase fighterBase = this.GetComponentInChildren<FighterBase>();
        fighterBase.fighter = null;
        Image fighterImage = fighterBase.gameObject.GetComponent<Image>();
        if(fighterImage != null)
        {
            fighterImage.sprite = null;
            fighterImage.enabled = false;
        }

        ItemBase[] itemBaseArray = this.GetComponentsInChildren<ItemBase>();

        DisableImage(itemBaseArray[0]);
        DisableImage(itemBaseArray[1]);
        DisableImage(itemBaseArray[2]);

        this.gameObject.SetActive(false);*/
    }

    private void DisableImage(ItemBase itemBase)
    {
        if(itemBase != null)
        {
            Image image = itemBase.GetComponent<Image>();
            image.sprite = null;
            image.enabled = false;

            itemBase.item = null;
        }
    }
}
