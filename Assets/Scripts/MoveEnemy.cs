using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    public GameObject player;
    public Animator mAnimator;
    public float strikeDistance;
    public int timer;
    public AudioClip attack;
    public AudioClip run;
    public GameObject attackNoise;
    public GameObject damageNoise;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        mAnimator = GetComponent<Animator>();
        mAnimator.SetTrigger("Run");
        timer = 0;
    }

    void Update()
    {
        strikeDistance = Vector3.Distance(transform.position, player.transform.position);
        if (strikeDistance < 4)
        {
            if (timer == 0)
            {
                mAnimator.SetTrigger("Attack");
                attackNoise.GetComponent<AudioSource>().Play();
                timer = 250;
                player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().currentHealth - 25;
                damageNoise.GetComponent<AudioSource>().Play();
            }
        }
        if (timer > 0)
        {
            timer--;
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
        //transform.position += transform.forward * 3f * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * 4f * Time.deltaTime);

    }
}