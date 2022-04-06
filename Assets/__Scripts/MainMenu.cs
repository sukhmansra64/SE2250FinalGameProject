using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //String which will hold the screen variable
    public string screen;

    //Will be called when the player wants to start the game
    public void StartGame()
    {
        //Load the screen to start the game. 
        SceneManager.LoadScene(screen);
    }

    //Will be called when the player wants to quit the game. 
    public void QuitGame()
    {
        //Quit the application
        Application.Quit();
    }
}
