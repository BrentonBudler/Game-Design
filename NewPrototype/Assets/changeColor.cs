using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    public Material[] material;
    public Animation anim; 
    Renderer rend;
    

    IEnumerator ChangeColour()
    {
        rend.sharedMaterial = material[1];
        yield return new WaitForSeconds(0.2f);
        rend.sharedMaterial = material[0];
    }

    private void Start()
    {
        
       
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    public void Changing(float damage)
    {
       
        StartCoroutine(ChangeColour());
        Enemy enemy = GetComponentInParent<Enemy>();
        enemy.TakeDamage(damage);
        anim.Play();
        

    }

    public void Die()
    {
        
    }

}
