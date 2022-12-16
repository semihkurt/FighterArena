using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPageManager : MonoBehaviour
{
    public GameObject fighterPageGameObject;
    public static FighterPageManager instance;

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
