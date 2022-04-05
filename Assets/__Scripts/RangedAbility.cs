using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedAbility : MonoBehaviour
{
    public string screen;

    public void ChooseGun()
    {
        SceneManager.LoadScene(screen);
    }

    public void ChooseSplashBomb()
    {
        SceneManager.LoadScene(screen);
    }

    public void ChooseGrapplingHook()
    {
        SceneManager.LoadScene(screen);
    }
}
