using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNewSkill : MonoBehaviour {
     GameObject[] gos;
     GameObject[] gos2;
    // Update is called once per frame

    void Awake(){
        
    }

    void Update() {
        gos = GameObject.FindGameObjectsWithTag("Skeleton");
        gos2 = GameObject.FindGameObjectsWithTag("Ghost");
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
            ScoreScript.score+=10;
        }
        }
        
        
        foreach (GameObject ghost in gos2)
        {
        if(ghost.name.Substring(0,4)=="Ghos"){
            Destroy(ghost);
            ScoreScript.score+=5;
        }
        }
        
        //insert code to destroy all the enemies on screen

        this.enabled = false;
    }
}