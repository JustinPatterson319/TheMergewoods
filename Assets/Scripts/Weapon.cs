using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject swapNoise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("3"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
        }

        if (Input.GetKeyDown("4"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("5"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("6"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("7"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("8"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown("9"))
        {
            swapNoise.GetComponent<AudioSource>().Play();
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }
    }
}
