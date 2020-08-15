using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public healthbar h;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (h.currentHealth<=0)
        {
            dieZombie();
            Debug.Log("Zombie is dead");
        }
    }
    void dieZombie()
    {
        anim.SetBool("die", true);
    }
}
