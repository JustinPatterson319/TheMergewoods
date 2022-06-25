using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Health healthBar;
    public int interval = 1;
    public float nextTime = 0;
    public int morale = 1;
    public int moraleCounter = 0;
    public GameObject morale2;
    public GameObject morale3;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(moraleCounter == 9)
        {
            morale = 2;
            morale2.SetActive(true);
        }
        if(moraleCounter == 24)
        {
            morale = 3;
            morale3.SetActive(true);
        }
        //keeps health at or above 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("Death");
        }

        // health regenrates slowly every second
        if (Time.time >= nextTime)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 5;
                healthBar.SetHealth(currentHealth);
            }
            nextTime += interval;
        }

        // hurts self for testing purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(0);
        }

        
    }

    // causes the player to take damage
    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);
    }


}
