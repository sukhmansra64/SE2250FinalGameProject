using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNewSkill : MonoBehaviour {
     GameObject[] gos;
     GameObject[] gos2;

    // Update is called once per frame
    void Update() {
        //finds all skeletons using tags and makes array
        gos = GameObject.FindGameObjectsWithTag("Skeleton");
        //finds all Ghosts using tags and makes array
        gos2 = GameObject.FindGameObjectsWithTag("Ghost");
        //if tab is clicked destroy all method is used
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
        
        //searches through the array and if the name is skeleton, it destroys the object and adds score
        foreach (GameObject skeleton in gos)
        {
        if(skeleton.name.Substring(0,7)=="Skeleto"){               
            Destroy(skeleton);
            UIScript.score+=10;
        }
        }
        
        //searches through the array and if the name is skeleton, it destroys the object and adds score
        foreach (GameObject ghost in gos2)
        {
        if(ghost.name.Substring(0,4)=="Ghos"){
            Destroy(ghost);
            UIScript.score+=5;
        }
        }

        //stops the tab from being used again
        this.enabled = false;
    }
}