using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour
{
    public static FighterManager instance;
    public Fighter[] fighters;
    public FighterSlot[] fighterSlots;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        fighterSlots = FindObjectsOfType<FighterSlot>();
        fighters = new Fighter[fighterSlots.Length];


        DontDestroyOnLoad(this);

    }

    public int getIndex(FighterSlot pSlot)
    {
        if(pSlot != null)
        {
            for(int i = 0; i < fighterSlots.Length; i++)
            {
                if(pSlot == fighterSlots[i])
                    return i;
            }
        }
        return -1;
    }

    public void Add(Fighter fighter,int index)
    {
        fighters[index] = fighter;
    }

    public void Add(Fighter fighter,FighterSlot pSlot)
    {
        int index = getIndex(pSlot);
        if(index != -1)
            fighters[index] = fighter;
        else
            Debug.Log("Fighter slot index returned null!!");
    }

    public void Remove(Fighter fighter, int index)
    {
        Destroy(fighters[index]);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
