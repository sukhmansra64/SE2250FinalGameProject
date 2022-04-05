using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backstory : MonoBehaviour
{
    public string screen;

    public void PressOk()
    {
        SceneManager.LoadScene(screen);
    }
}
