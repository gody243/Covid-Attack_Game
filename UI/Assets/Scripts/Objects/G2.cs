using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2 : MonoBehaviour
{
    public float delay = 3f;
    bool hasExploded = false;
    float countdown;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation); 
        Debug.Log("bOOM");
        Destroy(gameObject);
    }
}
