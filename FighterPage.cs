using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
