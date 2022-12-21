using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour
{
    public static FighterManager instance;
    public List<FighterBase> fighters = new List<FighterBase>();
    public FighterSlot[] fighterSlots;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        fighterSlots = FindObjectsOfType<FighterSlot>();
    }

    public void Add(FighterBase fighter)
    {
        fighters.Add(fighter);
    }

    public void Remove(FighterBase fighter)
    {
        fighters.Remove(fighter);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
