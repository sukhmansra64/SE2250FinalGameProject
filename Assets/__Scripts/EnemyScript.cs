using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    // Start is called before the first frame update
    void Start() {

        currentHealth = maxHealth;
    }

    //method for the enemy to take damage
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    //method for the enemy to die
    void Die() {

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
    }

    void DestroyGO(){
        Destroy(this.gameObject);
    }
}