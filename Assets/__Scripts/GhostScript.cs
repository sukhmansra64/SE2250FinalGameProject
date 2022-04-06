using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : EnemyScript
{
    //Adding projectile to enemy
    public GameObject projectilePrefab;
    public float projectileSpeed = 0.0005f;
    public float time = 0.0f;
    public float interpolationPeriod = 2f;
    public string choice;

    // Start is called before the first frame update
    void Start()
    {
        //create full health ghost and finds hero using it's tag
        currentHealth = maxHealth;
        Hero = GameObject.FindGameObjectsWithTag("Hero")[0];
    }

    // Update is called once per frame
    void Update()
    {
        //finds the direction of the hero using it's transform
        float direction = Hero.transform.position.x - transform.position.x;
        //if it's right, then faces right 
        if(direction>0){
            spriteRenderer.flipX=false;
            choice = "right";
        }
        //if it's left, then faces left
        if(direction<0){
            spriteRenderer.flipX=true;
            choice = "left";
        }

        //Spawn enemyProjectile every 2 seconds
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            //invokes fire method
            Fire(choice);
        }
    }

    void Fire(string choice)
    {
        //creates the bullet prefab 
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        //moves the game object
        projGO.transform.position = transform.position;
        //gets rigid body
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();

        //Change this later depending on whether or not the enemy is facing the hero
        if (choice.Equals("right"))
        {
            //fires the bullet right
            rigidB.velocity = Vector3.right * projectileSpeed * 0.25f;
        }
        else if (choice.Equals("left"))
        {
            //fires bullet left
            rigidB.velocity = Vector3.left * projectileSpeed * 0.25f;
        }
    }
}
