using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerHealth>().morale == 1)
        {
            if (GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies < 3)
            {
                randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length - 1));
                Instantiate(enemy, spawnPoints[randomNumber].transform.position, Quaternion.identity);
                GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies++;
            }
        }
        else if(GameObject.Find("Player").GetComponent<PlayerHealth>().morale == 2)
        {
            if (GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies < 4)
            {
                randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length - 1));
                Instantiate(enemy, spawnPoints[randomNumber].transform.position, Quaternion.identity);
                GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies++;
            }
        }
        else
        {
            if(GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies < 5)
            {
                randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length - 1));
                Instantiate(enemy, spawnPoints[randomNumber].transform.position, Quaternion.identity);
                GameObject.Find("Player").GetComponent<EnemyCounter>().totalEnemies++;
            }
        }
    }
}
