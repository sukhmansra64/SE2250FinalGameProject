using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public string screen;
    
    public void ChooseSwordsman()
    {
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Swordsman");
        SceneManager.LoadScene(screen);
    }

    public void ChooseKnight()
    {
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Knight");
        SceneManager.LoadScene(screen);
    }

    public void ChooseGino()
    {
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Gino");
        SceneManager.LoadScene(screen);
    }
}
