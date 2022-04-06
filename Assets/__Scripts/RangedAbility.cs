using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedAbility : MonoBehaviour
{
    //String to hold the name of the next scene
    public string screen;

    //Called when the gun button is selected
    public void ChooseGun()
    {
        //Sets the players ranged ability to gun
        PlayerPrefs.SetString("Ranged","Gun");
        //Goes to the next scene
        SceneManager.LoadScene(screen);
    }

    //Called when the bomb button is selected
    public void ChooseSplashBomb()
    {
        //Sets the players ranged ability to bomb
        PlayerPrefs.SetString("Ranged","Bomb");
        //Goes to the next scene
        SceneManager.LoadScene(screen);
    }
}
