using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEnemyScript : MonoBehaviour
{
    public ArrayList enemies;
    public GameObject parrot;
    public int parrotCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //finds all enemies in enemy layer
        enemies = FindGameObjectsInLayer(7);
    }

    // Update is called once per frame
    void Update()
    {
        //uses try catch to see when array doesn't have reference to decide that there are no enemies
        try{
            enemies = FindGameObjectsInLayer(7);
            if(enemies.Count==0){
            }
        }catch(Exception e){
            //instantiates the parrot once
            if(parrotCount==0){
                parrotCount = 1;
                Instantiate(parrot);
            }
            
        }
    }

    //method to iterate through all gameobjects and see if it is in layer 7
    ArrayList FindGameObjectsInLayer(int layer)
    {
        //fans all game objects
    var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    //makes it a list
    var goList = new System.Collections.Generic.List<GameObject>();
    //iterates through all game objects  and see if layer matches then adds to lllist
    for (int i = 0; i < goArray.Length; i++)
    {
        if (goArray[i].layer == layer)
        {
            goList.Add(goArray[i]);
        }
    }
    //returns null if there is no enemies
    if (goList.Count == 0)
    {
        return null;
    }
    //return list
    return new ArrayList(goList);
    }
}
