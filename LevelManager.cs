using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;


    [SerializeField]
    public bool lvl1Finished = false;
    [SerializeField]
    public bool lvl2Finished = false;
    [SerializeField]
    public bool lvl3Finished = false;
    [SerializeField]
    public bool lvl4Finished = false;


    public static LevelManager instance;

    void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void Lvl1Clicked()
    {
        SceneManager.LoadScene(2); 
    }
    public void Lvl2Clicked()
    {
        //SceneManager.LoadScene(3);
    }
    public void Lvl3Clicked()
    {
        //SceneManager.LoadScene(4);
    }
    public void Lvl4Clicked()
    {
        //SceneManager.LoadScene(5);
    }

}
