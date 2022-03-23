using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNewSkill : MonoBehaviour {
     GameObject[] gos;
    // Update is called once per frame

    void Awake(){
        gos = GameObject.FindGameObjectsWithTag("Skeleton");
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Tab)) {
            DestroyAll();
        }
    }

    //activates the script
    public void Activate() {
        this.enabled = true;
    }

    //destroys all the enemies on the screen
    void DestroyAll() {
        foreach (GameObject skeleton in gos)
        {
            if(skeleton.name.Substring(0,7)=="Skeleto"){
                
                Destroy(skeleton);
            }

        }
        //insert code to destroy all the enemies on screen

        this.enabled = false;
    }
}