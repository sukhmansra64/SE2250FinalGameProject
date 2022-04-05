using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyScript : EnemyScript
{
    // Start is called before the first frame update
    void Start(){

        currentHealth = maxHealth;
        Hero = Hero = GameObject.FindGameObjectsWithTag("Hero")[0];
    }

    // Update is called once per frame
    void Update(){
        Move();
    }
    public void Move()
    {
        animator.SetFloat("Speed", 1);
        transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, .006f);
        float direction = Hero.transform.position.x - transform.position.x;
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    //method to handle collisions
    protected override void OnCollisionEnter2D(Collision2D collision) { 

        if (collision.gameObject.tag == "Hero") {
            Die();
        }

        GameObject go = collision.gameObject;
        if (go.tag == "HeroProjectile") {
            TakeDamage(50);
            Debug.Log("Hit enemy");
            Destroy(go);
        }
    }
}
