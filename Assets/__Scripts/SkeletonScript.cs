using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : EnemyScript
{
    
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
        //invokes in radius method
        inRadius();
    }
    public void inRadius()
    {
        //sets movement animation in animation contoller by changing speed variable
        animator.SetFloat("Speed", 1);
        //makes skeleton larger
        transform.localScale = new Vector3(2.5f,2.5f,1);
        //moves towards player
        transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, .006f);
        //finds the direction of the hero using it's transform
        float direction = Hero.transform.position.x - transform.position.x;
        //if it's right, then faces right 
        if (direction < 0)
        {
            spriteRenderer.flipX = false;
        }
        //if it's left, then faces left
        if (direction > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
