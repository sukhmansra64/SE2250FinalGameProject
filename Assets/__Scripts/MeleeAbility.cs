using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeAbility : MonoBehaviour
{
    public string screen;

    public void ChooseStab()
    {
        SceneManager.LoadScene(screen);
    }

    public void ChooseSlash()
    {
        SceneManager.LoadScene(screen);
    }
}
