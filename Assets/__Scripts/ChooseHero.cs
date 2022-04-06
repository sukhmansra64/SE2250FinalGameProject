using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    //takes the screen as a variable
    public string screen;
    
    //invokes when the swordsman is clicked on title screen
    public void ChooseSwordsman()
    {
        //set's memory to initialize a the swordsman with full health 
        PlayerPrefs.SetFloat("Health",150f);
        //sets score to 0
        UIScript.score = 0;
        //set's memory to remember which character to use, in this case swordsman
        PlayerPrefs.SetString("Hero","Swordsman");
        //loads the next screen
        SceneManager.LoadScene(screen);
    }

    //invokes when the knight is clicked on title screen
    public void ChooseKnight()
    {
        //set's memory to initialize a the knight with full health 
        PlayerPrefs.SetFloat("Health",100f);
        //sets score to 0
        UIScript.score = 0;
        //set's memory to remember which character to use, in this case knight
        PlayerPrefs.SetString("Hero","Knight");
        //loads the next screen
        SceneManager.LoadScene(screen);
    }

    public void ChooseGino()
    {
        //set's memory to initialize a gino with full health 
        PlayerPrefs.SetFloat("Health",80f);
        //sets score to 0
        UIScript.score = 0;
        //set's memory to remember which character to use, in this case Gino
        PlayerPrefs.SetString("Hero","Gino");
        //loads the next screen
        SceneManager.LoadScene(screen);
    }
}
