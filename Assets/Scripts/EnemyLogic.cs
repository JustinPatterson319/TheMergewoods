using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies--;
            GameObject.Find("Player").GetComponent<PlayerHealth>().moraleCounter++;
            Dead();
        }
    }

    void ApplyDamage(int Damage)
    {
        health = health - Damage;
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
