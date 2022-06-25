using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidbody;


    //Getting components
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody>();
    }


    //Checking what to do depending on player distance
    void FixedUpdate()
    {
        fpsTarget = GameObject.Find("Player").transform;
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            lookAtPlayer();
            print("Player is in range");
        }
        //Attack player
        if (fpsTargetDistance < attackDistance)
        {
            enemyAttack();
            print("Enemy is attacking");
        }
    }

    //Enemy rotates toward player
    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    //Enemy moves toward player
    void enemyAttack()
    {
        theRigidbody.AddForce(transform.forward * enemyMovementSpeed);
    }
}
