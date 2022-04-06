using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScreen : MonoBehaviour
{
    //The string holds the variable for the name of the scene that is going to be changed to
    public string screen;

    //Method gets called when the button is clicked
    public void PressOk()
    {
        //Switches scene based on the string value that is defined in Unity
        SceneManager.LoadScene(screen);
    }
}
