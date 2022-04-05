using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : EnemyScript
{
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Hero = GameObject.FindGameObjectsWithTag("Hero")[0];
    }

    // Update is called once per frame
    void Update()
    {
        inRadius();
    }
    public void inRadius()
    {
        animator.SetFloat("Speed", 1);
        transform.localScale = new Vector3(2.5f,2.5f,1);
        transform.position = Vector3.MoveTowards(transform.position, Hero.transform.position, .006f);
        float direction = Hero.transform.position.x - transform.position.x;
        if (direction < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (direction > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
