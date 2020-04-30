using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
   // public GameObject impactEffect;

    public Camera fpsCam;
    public cameraShake cameraShake;
    
       
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        StartCoroutine(cameraShake.Shake(0.1f,0.1f));

        RaycastHit hitinfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitinfo, range))
        {
            Debug.Log(hitinfo.transform.name);

            Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                //Instantiate(impactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));

            }

        }
        

    }
}
