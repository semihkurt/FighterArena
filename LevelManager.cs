using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class LevelManager : MonoBehaviour
{
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;

    public Action GameCompleted;

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
        SceneManager.LoadScene(2);
    }
    public void Lvl3Clicked()
    {
        SceneManager.LoadScene(2);
    }
    public void Lvl4Clicked()
    {
        SceneManager.LoadScene(2);
    }

    private void Start() {
        Debug.Log("Start");
        GameManager.Instance.OnRoundStart += OnRoundStart;
        GameManager.Instance.OnRoundEnd += OnRoundEnd;
    }

    protected virtual void OnRoundStart() 
    { 

    }
    protected virtual void OnRoundEnd(Team winnerTeam) 
    { 
        if(!lvl1Finished)
        {
            if(winnerTeam == Team.Team1)
                lvl1Finished = true;
        }else if(!lvl2Finished)
        {
            if(winnerTeam == Team.Team1)
                lvl2Finished = true;
        }else if(!lvl3Finished)
        {
            if(winnerTeam == Team.Team1)
                lvl3Finished = true;
        }else if(!lvl4Finished)
        {
            if(winnerTeam == Team.Team1)
            {
                lvl4Finished = true;
                GameCompleted?.Invoke();
            }
                
        }
    }

}
