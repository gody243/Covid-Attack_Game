using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public static ZombieController reference;
    public int Zkilled;


    private void Awake()
    {
        reference = this;
    }
    
}
