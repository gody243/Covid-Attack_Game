using System.Collections;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnnemyMovement : MonoBehaviour
{

    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    static Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
       
        //anim.SetBool("isIdle", true);

    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
            //anim.SetBool("isIdle", false);
            //anim.SetBool("isWalking", true);
            
        }
      /**  else
        {
            anim.SetBool("isAttacking", false);
        }**/
    }
}