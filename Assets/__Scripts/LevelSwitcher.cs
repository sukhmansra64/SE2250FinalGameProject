using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {

    //Set the sceneCount to 0. 
    int sceneCount = 0;

    // Update is called once per frame
    void Update(){
        //If the scene count is equal to 0 and the score is equal to 200
        if (sceneCount == 0 && UIScript.score == 200) {
            //Set the sceneCount to 1. 
            sceneCount = 1;
            //Load the midstory scene
            SceneManager.LoadScene("_Midstory");
        }
    }
}
