using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGameObjectScript : MonoBehaviour
{
    //Array of type GameObject. 
    public GameObject[] Hero;

    //Awake will be called first
    void Awake()
    {
        //Set the array equal to game objects with the tag "Hero". 
        Hero = GameObject.FindGameObjectsWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        //Hold the position of the vector. 
        transform.position = new Vector3(Hero[0].GetComponent<Transform>().transform.position.x, Hero[0].GetComponent<Transform>().transform.position.y, Hero[0].GetComponent<Transform>().transform.position.z);
    }
}
