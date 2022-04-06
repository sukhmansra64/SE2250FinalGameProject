using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //declares a transform to be used 
    public Transform target;

    void Start()
    {
        //finds the hero by it's tag and assigns it to be the target
        target = GameObject.FindGameObjectsWithTag("Hero")[0].GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        //follows the hero's position
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
