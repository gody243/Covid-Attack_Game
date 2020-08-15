 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrower : MonoBehaviour
{
    public float throwForce = 40F;
    public GameObject grenadePrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }
    void ThrowGrenade()
    {
        //grenade NOT MADE YET,YOU HAVE TO CREATE THE GRENADE THEN PUT IT IN THE PREFAB
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
