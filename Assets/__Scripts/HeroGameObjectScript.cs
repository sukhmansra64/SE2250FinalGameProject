using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGameObjectScript : MonoBehaviour
{
    public GameObject[] Hero;

    void Awake()
    {
        Hero = GameObject.FindGameObjectsWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Hero[0].GetComponent<Transform>().transform.position.x, Hero[0].GetComponent<Transform>().transform.position.y, Hero[0].GetComponent<Transform>().transform.position.z);
    }
}
