using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyScript : EnemyScript
{
    // Start is called before the first frame update
    void Start(){

        //sets the enemy health to be maxed by the parent classes max health variable
        currentHealth = maxHealth;
        //find the hero by it's tag and sets it as the hero
        Hero = Hero = GameObject.FindGameObjectsWithTag("Hero")[0];
    }

    // Update is called once per frame
    void Update(){
        //calls update method
        Move();
    }
    public void Move()
    {
        //set's the animator controller's speed variable to 1 so that it knows to trigger the animation 
        //for moving
        animator.SetFloat("Speed", 1);
        //changes the transform's position to follow the enemy
        transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, .006f);
        //finds the hero's x direction
        float direction = Hero.transform.position.x - transform.position.x;

        //if it's further right then it faces right 
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }

        //if it's further left then it faces left
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    //method to handle collisions
    protected override void OnCollisionEnter2D(Collision2D collision) { 

        //if it collides with a hero tag, the enemy dies using the parent die class
        if (collision.gameObject.tag == "Hero") {
            Die();
        }

        //if the game object collides with a hero's bullet, it takes damage using the parent method and
        //destorys the bullet object
        GameObject go = collision.gameObject;
        if (go.tag == "HeroProjectile") {
            TakeDamage(50);
            Destroy(go);
        }
        //if the game object collides with a hero's bomb, it takes damage using the parent method and
        //destorys the bomb object
        if (go.tag == "ThrowableProjectile") {
            TakeDamage(100);
            Destroy(go);
        }
    }
}
