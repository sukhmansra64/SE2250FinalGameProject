using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeAbility : MonoBehaviour
{
    //String which will hold the screen variable
    public string screen;

    //Will be called when the player selects stab
    public void ChooseStab()
    {
        //Sets the string to the following values.
        PlayerPrefs.SetString("Attack", "Stab");
        //Loads the new scene.
        SceneManager.LoadScene(screen);
    }

    //Will be called when the player selects slash.
    public void ChooseSlash()
    {
        //Sets the string to the following values. 
        PlayerPrefs.SetString("Attack", "Slash");
        //Loads the new scene
        SceneManager.LoadScene(screen);
    }
}
