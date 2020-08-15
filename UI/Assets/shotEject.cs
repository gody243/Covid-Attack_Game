using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotEject : MonoBehaviour
{
   
    public Rigidbody bulletCasing;
    public int ejectSpeed = 100;
    private float nextFire = 0f;
    public float fireRate = 0.5f;
    private bool fullAuto = false;

    public int clip = 30;
    public int maxclip = 30;

public int reserve = 300;
public int minreserve = 0;

    public AudioClip shotsound;
        public AudioClip reloadsound  ;
        public bool MunMax = true;
public bool reloadsoundplay = false;
 
public bool automatic = true;
    public GameObject fireshot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")&& Time.deltaTime > nextFire)
        {
            if (clip >= 1)
            {
                nextFire = Time.deltaTime + fireRate;
                Rigidbody bullet;
                bullet = Instantiate(bulletCasing, transform.position, transform.rotation);
                clip -= 1;
                GetComponent<AudioSource>().PlayOneShot(shotsound);
                bullet.velocity = transform.TransformDirection(Vector3.left * ejectSpeed);
                Instantiate(fireshot, transform.position, transform.rotation);
            }
        }
        if (automatic == true)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                fullAuto = !fullAuto;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (reloadsoundplay == true)
            {
                GetComponent<AudioSource>().PlayOneShot(reloadsound);
            }
            if (reserve > 30)
            {
                RemoveReserve();
                clip += maxclip - clip;
            }
            if (reserve < 30)
            {
                clip += reserve;
                RemoveReserve();
            }
        }
        if (clip == maxclip)
        {
            reloadsoundplay = false;
        }
        if (clip < maxclip)
        {
            reloadsoundplay = true;
        }
        if (reserve == 0)
        {
            reloadsoundplay = false;
        }
        if (automatic == false)
        {
            fireRate = 0.7f;
        }
    }
  
    void RemoveReserve()
    {
        reserve -= maxclip - clip;
    }
}
