using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        theRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsTarget = GameObject.Find("Player").transform;
        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            lookAtPlayer();

        }
        //Attack player
        if (fpsTargetDistance < attackDistance)
        {
            enemyAttack();
        }
    }

    //Checking what to do depending on player distance
    void FixedUpdate()
    {
        
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
