using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeAbility : MonoBehaviour
{
    public string screen;

    public void ChooseStab()
    {
        PlayerPrefs.SetString("Attack", "Stab");
        SceneManager.LoadScene(screen);
    }

    public void ChooseSlash()
    {
        PlayerPrefs.SetString("Attack", "Slash");
        SceneManager.LoadScene(screen);
    }
}
