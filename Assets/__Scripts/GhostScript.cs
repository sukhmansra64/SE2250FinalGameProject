using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public GameObject Hero;
    public SpriteRenderer spriteRenderer;

    //Adding projectile to enemy
    public GameObject projectilePrefab;
    public float projectileSpeed = 0.0005f;
    public float time = 0.0f;
    public float interpolationPeriod = 2f;
    public string choice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Hero.transform.position.x - transform.position.x;
        if(direction>0){
            spriteRenderer.flipX=false;
            choice = "right";
        }
        if(direction<0){
            spriteRenderer.flipX=true;
            choice = "left";
        }

        //Spawn enemyProjectile every 2 seconds
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            Fire(choice);
        }
    }

    void Fire(string choice)
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();



        //Change this later depending on whether or not the enemy is facing the hero
        if (choice.Equals("right"))
        {
            rigidB.velocity = Vector3.right * projectileSpeed * 0.25f;
        }
        else if (choice.Equals("left"))
        {
            rigidB.velocity = Vector3.left * projectileSpeed * 0.25f;
        }
    }
}
