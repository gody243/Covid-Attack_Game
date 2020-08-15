using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killZ : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthbar healthBar;
    public AudioSource dead;
    public int allEnnemies;
    EnnemyMovement ennemy;
    private int nextScene;
     Animator animator;
    public Transform character;
    public GameObject portal;
    
    void Start()
    {
       
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        dead = GetComponent<AudioSource>();
        ennemy = GetComponent<EnnemyMovement>();
         portal.SetActive(false);
        //animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        
        //Debug.Log(other.collider.name);
        //AudioSource audio=GetComponent<AudioSource>();
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
        if (currentHealth<=50)
        {
            animator.SetBool("isRunning", true);
        }
        if (currentHealth == 0)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isDead", true);
            dead.enabled = false;
            ennemy.enabled=false;
            //Destroy(gameObject);
            ZombieController.reference.Zkilled += 1;
            OnToNextLevel();
            
          }
        
       

    }
    void OnToNextLevel()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
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
    private void Update()
    {
        //when the zombie gets close to the character, the zombie attacks.
        if (Vector3.Distance(character.position, this.transform.position) < 1)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
           
        }
       else
        // if(Vector3.Distance(character.position, this.transform.position) > 1)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
        }
      
    }
    
  
}
