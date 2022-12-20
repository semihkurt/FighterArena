using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour
{
    public static FighterManager instance;
    public List<Fighter> fighters = new List<Fighter>();
    public FighterSlot[] fighterSlots;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        fighterSlots = FindObjectsOfType<FighterSlot>();
    }

    public void Add(Fighter fighter)
    {
        fighters.Add(fighter);
    }

    public void Remove(Fighter fighter)
    {
        fighters.Remove(fighter);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
