using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    // public GameObject impactEffect; 
    public float impactForce = 30f;

    public int maxAmmo = 6;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator anim;
    int totalAmmo = 12;
    int remainingAmmo = 1;

    public Text currentAmmoText;
    public Text remainingAmmoText;

    public Camera fpsCam;
    public cameraShake cameraShake;

    public AudioSource shot;
    public AudioSource reload;
    public AudioSource noAmmo;
    public AudioSource pickUp;

    private float nextTimeToFire = 0f;

   

    void Start()
    {
        currentAmmo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        if (remainingAmmo != 0) { remainingAmmo = totalAmmo - maxAmmo; }
   
        currentAmmoText.text = currentAmmo.ToString();
        remainingAmmoText.text = remainingAmmo.ToString();

        if (isReloading)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.R) && remainingAmmo > 0)
        {
            totalAmmo = totalAmmo - (maxAmmo - currentAmmo);
            if (totalAmmo - 6 <= 0)
            {
                remainingAmmo = 0;
                currentAmmo = totalAmmo;
                StartCoroutine(Reload2());
            }
            else {
                StartCoroutine(Reload());
                return;
            }

        }


        if (currentAmmo <= 0 && Input.GetButtonDown("Fire1"))
        {
            noAmmo.Play(0);
           
        }

        if (currentAmmo <= 0)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        
    }

    IEnumerator Reload()
    {
    
        reload.Play(0);
        anim.SetBool("reloading", true);
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        anim.SetBool("reloading", false);
    }


    IEnumerator Reload2()
    {
      
        reload.Play(0);
        anim.SetBool("reloading", true);
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        anim.SetBool("reloading", false);
    }

    void Shoot()
    {
        StartCoroutine(Shooting());
        currentAmmo--;

        StartCoroutine(cameraShake.Shake(0.1f, 0.05f));

        RaycastHit hitinfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitinfo, range))
        {


            changeColor change = hitinfo.transform.GetComponent<changeColor>();
            if (change != null)
            {
                change.Changing(damage);
            }

            if (hitinfo.rigidbody != null)
            {
                hitinfo.rigidbody.AddForce(-hitinfo.normal * impactForce);
            }

            



        }
    }

    IEnumerator Shooting()
    {
        anim.SetBool("shot", true);
        shot.Play(0);
        yield return new WaitForSeconds(0.05f);
        anim.SetBool("shot", false);
    }


    public void pickupAmmo()
    {
        pickUp.Play(0);


        if (remainingAmmo == 0)
        {
            remainingAmmo = 1;
        }
            totalAmmo = totalAmmo + 6;
    
        
        Debug.Log("Ammo Picked Up");
    }
}
