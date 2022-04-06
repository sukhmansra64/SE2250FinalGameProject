using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Create an instance of Vector3. 
    public Vector3 LaunchOffset;
    

    private void Start()
    {
        //If the "Ranged" is equal to "Bomb" then the following code will run. 
        if (PlayerPrefs.GetString("Ranged")=="Bomb")
        {
            //Set the direction. 
            var direction = -transform.right + Vector3.down;
            //Add the corresponding force. 
            GetComponent<Rigidbody2D>().AddForce(direction * 8, ForceMode2D.Impulse);
        }
        //Destory the game object. 
        Destroy(gameObject, 0.5f);
    }

}
