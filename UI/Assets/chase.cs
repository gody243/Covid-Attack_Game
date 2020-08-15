using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class chase : MonoBehaviour
{
    
    public Transform player;
     Animator anim;
    public int maxHealth = 100;
    public int currentHealth;
    public healthbar healthBar;
    public AudioSource dead;
    public int allEnnemies;
    public GameObject portal;
    //public AudioSource attack;
    private void Start()
    {
        
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        dead = GetComponent<AudioSource>();
        portal.SetActive(false);
       // attack = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {

        //Debug.Log(other.collider.name);
        //AudioSource audio=GetComponent<AudioSource>();
       
        //if the zombie gets hit by the gun,it'll lose life and even more life with the grenade 
        if (other.collider.tag == "Gun")
        {
           

            TakeDamage(20);

            dead.Play();

        }
        if (other.collider.tag == "Grenade")
        {
            TakeDamage(50);
            dead.Play();


        }
        if (currentHealth <= 50)
        {
            anim.SetBool("isRunning", true);
        }
        if (currentHealth <= 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isDead", true);
            dead.enabled = false;
           ZombieController.reference.Zkilled += 1;
            OnToNextLevel();
        }


    }
    void OnToNextLevel()
    {
        int nextScene=SceneManager.GetActiveScene().buildIndex + 1;
        if (allEnnemies <= ZombieController.reference.Zkilled)
        {
            portal.SetActive(true);
            //SceneManager.LoadScene(nextScene);
        }
    }
    void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    //zombie start following the player at a certain range and attacking him
    private void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 20)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);
             if (direction.magnitude > 1)
            {
               //this.transform.Translate(0, 0, 0.1f);
                anim.SetBool("isWalking",true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
               // attack.Play();
            }
            
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
