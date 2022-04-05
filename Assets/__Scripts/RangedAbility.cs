using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedAbility : MonoBehaviour
{
    public string screen;

    public void ChooseGun()
    {
        PlayerPrefs.SetString("Ranged","Gun");
        SceneManager.LoadScene(screen);
    }

    public void ChooseSplashBomb()
    {
        PlayerPrefs.SetString("Ranged","Bomb");
        SceneManager.LoadScene(screen);
    }

    public void ChooseGrapplingHook()
    {
        PlayerPrefs.SetString("Ranged","Hook");
        SceneManager.LoadScene(screen);
    }
}
