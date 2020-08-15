using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;//wait 3seconds before it blows up
    public float radius = 5f;
    public float force = 700f;


    public GameObject explosionEffect;
    bool hasExploded = false;
    float countdown;
    Transform other;
    public AudioSource throwg;
    // Start is called before the first frame update
    void Start()
    {
        countdown =delay;
        throwg = GetComponent<AudioSource>();
        

    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            StartCoroutine(PlayAudio());
           Explode();
            
            hasExploded = true;
            
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToDestroy)
        {
           
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if(dest!=null)
            {
                
                dest.Destroy();
            }
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToMove)
        {
             Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(force, transform.position, radius);
                        }
        }
       
       
        Debug.Log("Boom!");
            Destroy(gameObject);
        
        
            
        
    }
    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(3f);
        throwg.Play();
    }
   
}

