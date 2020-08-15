using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigexplo : MonoBehaviour
{
    public AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<AudioSource>();
        Destroy(gameObject, 2f);
        explosion.Play();
    }

  
}
