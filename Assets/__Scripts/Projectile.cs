using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 LaunchOffset;
    

    private void Start()
    {
        if (PlayerPrefs.GetString("Ranged")=="Bomb")
        {
            var direction = -transform.right + Vector3.down;
            GetComponent<Rigidbody2D>().AddForce(direction * 8, ForceMode2D.Impulse);
        }
        //transform.Translate(LaunchOffset);
        Destroy(gameObject, 0.5f);
    }

    public void Update()
    {
        
    }
}
