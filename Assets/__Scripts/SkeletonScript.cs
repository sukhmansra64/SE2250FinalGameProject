using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public GameObject hero;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

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
        transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, .006f);
        float direction = hero.transform.position.x - transform.position.x;
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
