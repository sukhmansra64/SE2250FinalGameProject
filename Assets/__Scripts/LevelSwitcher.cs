using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {

    int sceneCount = 0;

    // Update is called once per frame
    void Update(){
        if (sceneCount == 0 && UIScript.score == 200) {
            sceneCount = 1;
            SceneManager.LoadScene("_Midstory");
        }
    }
}
