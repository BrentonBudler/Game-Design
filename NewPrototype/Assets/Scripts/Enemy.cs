using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public Animator leftArm;
    public Animator rightArm;
    public Animator leftLeg;
    public Animator rightLeg;
    public Animator body;
    public Animator head;
    public AudioSource fallingBones;
    public Animator GhostBod;
    public Animator GhostLeftArm;
    public Animator GhostRightArm;


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
        followPlayer follow = GetComponentInParent<followPlayer>();
        if (follow!=null)
        {
            fallingBones.Play();
            follow.Stop();
            leftArm.SetBool("stopped", true);
            rightArm.SetBool("stopped", true);
            leftLeg.SetBool("stopped", true);
            rightLeg.SetBool("stopped", true);
            body.SetBool("stopped", true);
            head.SetBool("stopped", true);
            Destroy(gameObject, 2f);
        }
        else
        {
            Ghost ghost = GetComponentInParent<Ghost>();
            ghost.Stop();
            GhostBod.SetBool("dead",true);
            GhostLeftArm.SetBool("dead", true);
            GhostRightArm.SetBool("dead", true);

            Destroy(gameObject,0.75f);
        }
       
    }

  


    
}
