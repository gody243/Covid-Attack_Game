using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("picked up");
        }
        else
        {
            return;

        }
    }
}