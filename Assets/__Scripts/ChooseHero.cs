using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseHero : MonoBehaviour
{
    public string screen;
    
    public void ChooseSwordsman()
    {
        SceneManager.LoadScene(screen);
    }

    public void ChooseKnight()
    {
        SceneManager.LoadScene(screen);
    }

    public void ChooseGino()
    {
        SceneManager.LoadScene(screen);
    }
}
