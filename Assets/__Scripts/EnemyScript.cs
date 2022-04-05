using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int maxHealth = 100;
    protected int currentHealth;
    public Animator animator;
    protected GameObject Hero;
    public SpriteRenderer spriteRenderer;

    //method for the enemy to take damage
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    //method for the enemy to die
    protected void Die() {

        //make the enemy dead animation
        animator.SetTrigger("Death");
        Invoke("DestroyGO",0.83f);
        GetComponent<Collider2D>().enabled = false;
        if(this.gameObject.tag=="Skeleton"){
            ScoreScript.score+=10;
        }
        if(this.gameObject.tag=="Ghost"){
            ScoreScript.score+=5;
        }
        if (this.gameObject.tag == "Eagle") {
            ScoreScript.score+=15;
        }
    }

    protected void DestroyGO(){
        Destroy(this.gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision){

        GameObject go = collision.gameObject;
        if (go.tag == "HeroProjectile")
        {
            TakeDamage(50);
            Debug.Log("Hit enemy");
            Destroy(go);
        }
    }
}