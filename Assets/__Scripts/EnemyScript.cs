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

        //checks to see if the health is low enough to die then invokes death method 
        if (currentHealth <= 0) {
            Die();
        }
    }

    //method for the enemy to die
    protected void Die() {

        //make the enemy dead animation
        animator.SetTrigger("Death");
        //lets animation play out, then destroys the game object by invoking the destroy GO method
        Invoke("DestroyGO",0.83f);

        //disables the collider
        GetComponent<Collider2D>().enabled = false;

        //checks the tag for the enemy and awards the app
        if(this.gameObject.tag == "Skeleton"){
            UIScript.score+=10;
        }
        if(this.gameObject.tag == "Ghost"){
            UIScript.score+=5;
        }
        if (this.gameObject.tag == "Eagle") {
            UIScript.score+=15;
        }
    }

    //invokes destory method
    protected void DestroyGO(){
        Destroy(this.gameObject);
    }

    //collision method 
    protected virtual void OnCollisionEnter2D(Collision2D collision){
        //checks if the collision involves a bullet 
        GameObject go = collision.gameObject;
        if (go.tag == "HeroProjectile")
        {
            //takes the 50 damage using the damage method 
            TakeDamage(50);
            //destroys the bullet
            Destroy(go);
        }
        //checks if the collision involves a bullet 
        if (go.tag == "ThrowableProjectile")
        {
            //takes the 100 damage using the damage method 
            TakeDamage(100);
            //destroys the bullet
            Destroy(go);
        }
    }
}