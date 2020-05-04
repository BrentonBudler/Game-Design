using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health<=0f)
        {
            Die();
        }
    }

    void Die()
    {
        followPlayer followP = GetComponentInParent<followPlayer>();
        followP.Stop();
        StartCoroutine(Dead());
       // Destroy(gameObject);

    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        changeColor change = GetComponentInChildren<changeColor>();
        change.Die();
    }

    
}
