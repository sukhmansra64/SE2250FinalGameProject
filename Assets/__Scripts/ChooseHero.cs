using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public string screen;
    
    public void ChooseSwordsman()
    {
        PlayerPrefs.SetString("Hero","Swordsman");
        SceneManager.LoadScene(screen);
    }

    public void ChooseKnight()
    {
        PlayerPrefs.SetString("Hero","Knight");
        SceneManager.LoadScene(screen);
    }

    public void ChooseGino()
    {
        PlayerPrefs.SetString("Hero","Gino");
        SceneManager.LoadScene(screen);
    }
}
