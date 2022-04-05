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
        enemies = FindGameObjectsInLayer(7);
    }

    // Update is called once per frame
    void Update()
    {
        try{
            enemies = FindGameObjectsInLayer(7);
            if(enemies.Count==0){
                Debug.Log("hit");
            }
        }catch(Exception e){
            if(parrotCount==0){
                parrotCount = 1;
                Instantiate(parrot);
            }
            
        }
    }
    ArrayList FindGameObjectsInLayer(int layer)
    {
    var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    var goList = new System.Collections.Generic.List<GameObject>();
    for (int i = 0; i < goArray.Length; i++)
    {
        if (goArray[i].layer == layer)
        {
            goList.Add(goArray[i]);
        }
    }
    if (goList.Count == 0)
    {
        return null;
    }
    return new ArrayList(goList);
    }
}
