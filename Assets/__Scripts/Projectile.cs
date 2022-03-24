using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float secondTime = 0.0f;
    public float secondInterpolationPeriod = 0.5f;

    // Update is called once per frame
    void Update()
    {
        secondTime += Time.deltaTime;

        if (secondTime >= secondInterpolationPeriod / 5)
        {
            secondTime = 0.0f;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
