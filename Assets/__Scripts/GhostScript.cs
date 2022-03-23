using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public GameObject Hero;
    public SpriteRenderer spriteRenderer;
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
        }
        if(direction<0){
            spriteRenderer.flipX=true;
        }
    }
}
