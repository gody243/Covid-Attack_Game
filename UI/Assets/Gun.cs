using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public float reloadTime = 1f;
    public int maxAmmo = 10;
    private int currentAmmo;
    private bool isReloading;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public AudioClip shotsound;
    public AudioClip reloadsound;
    public Animator anim;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        anim.SetBool("isReloading", false);

    }


    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            GetComponent<Animator>().SetTrigger("Fire");
            GetComponent<AudioSource>().PlayOneShot(shotsound);

           // Shoot();
            Debug.Log(currentAmmo);
        }
    }
    void Shoot()
    {
        currentAmmo--;
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range))
        {
           // Debug.Log(hit.transform.name);
           Target target= hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody!=null)
                {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        anim.SetBool("isReloading", true);
        GetComponent<AudioSource>().PlayOneShot(reloadsound);
        yield return new WaitForSeconds(reloadTime - .25f);

        anim.SetBool("isReloading", false);

        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;

    }
}
