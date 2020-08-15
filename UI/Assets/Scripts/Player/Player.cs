using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool GameOver = false;
    public GameObject canvasInfected;
    public int maxHealth = 100;
    public int currentHealth;

    public AudioSource pain;

    public healthbar healthBar;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pain = GetComponent<AudioSource>();
        canvasInfected.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(currentHealth);
        if (other.gameObject.tag == "Ennemy")
        {
            TakeDamage(10);
          //  Debug.Log("Player " + currentHealth);
        }
        if(other.gameObject.tag=="BigEnnemy")
        {
            TakeDamage(50);
        }
        if(other.gameObject.tag=="Grenade")
        {
            TakeDamage(30);
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void Update()
    {
        if (currentHealth == 50)
        {
            pain.Play();
        }
        if (currentHealth <= 0)
        {
            Debug.Log("YOU ARE NOW INFECTED");
            canvasInfected.SetActive(true);
            //Time.timeScale = 0f;
            GameOver = true;

            SceneManager.LoadScene("Level01", LoadSceneMode.Single);
        }
    }
}
