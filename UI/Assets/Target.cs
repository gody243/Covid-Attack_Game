using UnityEngine;

public class Target : MonoBehaviour
{
    public Animator anim;
    public float health = 100f;
    private void Start()
    {
        anim.GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<=0f)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        anim.SetBool("isDead", true);
        Debug.Log("target dead");
    }
}
