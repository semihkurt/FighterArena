using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        //Enter DB new game
        Debug.Log("New game");
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        //Fetch from DB, last things
        
    }

    public void LoadGame()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
