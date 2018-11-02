using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

    // loads up the main game screen.
    //**Right now it only loads a test environment. 
    //  This will be where we call our procedural generation of the level.**
	public void LoadGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Loads the load game screen
    public void LoadLoadMenu()
    {
        SceneManager.LoadScene("LoadMenu");
    }

    // This quits the application.
    public void ExitGame()
    {
        Application.Quit();
    }

    // This returns you to the main menu. 
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
