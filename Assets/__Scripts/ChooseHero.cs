using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public string screen;
    
    public void ChooseSwordsman()
    {
        PlayerPrefs.SetFloat("Health",150f);
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Swordsman");
        SceneManager.LoadScene(screen);
    }

    public void ChooseKnight()
    {
        PlayerPrefs.SetFloat("Health",100f);
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Knight");
        SceneManager.LoadScene(screen);
    }

    public void ChooseGino()
    {
        PlayerPrefs.SetFloat("Health",80f);
        UIScript.score = 0;
        PlayerPrefs.SetString("Hero","Gino");
        SceneManager.LoadScene(screen);
    }
}
