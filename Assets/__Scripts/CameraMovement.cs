using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Hero")[0].GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
