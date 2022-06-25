using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    //checking distance to objects
    public float MaxDistance;
    public float boulderMax;
    public float woodMax;
    public GameObject player;

    //plunger interactions
    public GameObject plungerText;
    public GameObject plunger;
    public float plungerDistance;

    //DART INTERACTIONS
    public GameObject dartText;
    public GameObject dart;
    public float dartDistance;

    //morale level 2 barrier
    public GameObject clearText;
    public GameObject clearText2;
    public GameObject morale2;
    public GameObject wood;
    public float woodDistance;

    //morale level 3 Barrier
    public GameObject morale3;
    public GameObject boulder;
    public float boulderDistance;

    //weapons for inventory
    public GameObject inventoryKnife;
    public GameObject inventoryPlunger;
    public GameObject inventoryDarts;
    public GameObject inventoryScythe;
    public GameObject inventoryAxe;
    public GameObject inventorySpear;

    //Sprite Handling
    public GameObject HUD;
    public Sprite scytheSprite;
    public Sprite spearSprite;
    public Sprite plungerSprite;
    public Sprite knifeSprite;
    public Sprite axeSprite;
    public Sprite dartSprite;

    //audio controls
    public int stepTimer = 25;
    public AudioClip walk;
    public AudioClip run;
    public GameObject combineNoise;
    public GameObject pickupNoise;
    public GameObject barrierNoise;

    //escape
    public GameObject escape;
    public GameObject escapeText;
    public float escapeDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(stepTimer < 0)
        {
            stepTimer = 0;
        }
        //Creates sounds on movement
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (stepTimer == 0)
            {
                if(Input.GetButton("Fire3"))
                {
                    player.GetComponent<AudioSource>().clip = run;
                }
                else
                {
                    player.GetComponent<AudioSource>().clip = walk;
                }
                player.GetComponent<AudioSource>().Play();
                stepTimer = 25;
            }
        }
        else
        {
            player.GetComponent<AudioSource>().Stop();
        }
        stepTimer--;

        //Dart
        if (dart.activeSelf)
        {
            dartDistance = Vector3.Distance(player.transform.position, dart.transform.position);
            if (dartDistance < MaxDistance)
            {
                dartText.SetActive(true);

                //combinations
                if (Input.GetButtonDown("Combine"))
                {
                    combineNoise.GetComponent<AudioSource>().Play();
                    //Create Axe
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon1.activeSelf)
                    {
                        dart.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1 = inventoryAxe;
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1.SetActive(true);
                        dartText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 1/Item").GetComponent<Image>().sprite = axeSprite;
                    }

                    //Creates Spear
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon2.activeSelf)
                    {
                        dart.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2 = inventorySpear;
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2.SetActive(true);
                        dartText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 2/Item").GetComponent<Image>().sprite = spearSprite;
                        GameObject.Find("HUD/Inventory/Slot 2/Item").SetActive(true);
                    }
                }

                //pickup without combining
                if (Input.GetButtonDown("Pickup"))
                {
                    pickupNoise.GetComponent<AudioSource>().Play();
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon2 == inventoryPlunger)
                    {
                        dart.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon3 = inventoryDarts;
                        dartText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 3/Item").GetComponent<Image>().sprite = dartSprite;
                        GameObject.Find("HUD/Inventory/Slot 3/Item").SetActive(true);
                    }
                    else
                    {
                        dart.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2 = inventoryDarts;
                        dartText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 2/Item").GetComponent<Image>().sprite = dartSprite;
                        GameObject.Find("HUD/Inventory/Slot 2/Item").SetActive(true);
                    }
                }
            }
            else
            {
                dartText.SetActive(false);
            }
        }
        else
        {
            dartText.SetActive(false);
        }


        //Plunger
        if (plunger.activeSelf)
        {
            plungerDistance = Vector3.Distance(player.transform.position, plunger.transform.position);
            if (plungerDistance < MaxDistance)
            {
                plungerText.SetActive(true);

                //combinations
                if (Input.GetButtonDown("Combine"))
                {
                    combineNoise.GetComponent<AudioSource>().Play();
                    //Creates Scythe
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon1.activeSelf)
                    {
                        plunger.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1 = inventoryScythe;
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon1.SetActive(true);
                        plungerText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 1/Item").GetComponent<Image>().sprite = scytheSprite;
                    }

                    //Creates Spear
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon2.activeSelf)
                    {
                        plunger.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2 = inventorySpear;
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2.SetActive(true);
                        plungerText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 2/Item").GetComponent<Image>().sprite = spearSprite;
                        GameObject.Find("HUD/Inventory/Slot 2/Item").SetActive(true);
                    }
                }

                //pickup without combining
                if (Input.GetButtonDown("Pickup"))
                {
                    pickupNoise.GetComponent<AudioSource>().Play();
                    if (GameObject.Find("Player").GetComponent<Weapon>().Weapon2 == inventoryDarts)
                    {
                        plunger.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon3 = inventoryPlunger;
                        plungerText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 3/Item").GetComponent<Image>().sprite = plungerSprite;
                        GameObject.Find("HUD/Inventory/Slot 3/Item").SetActive(true);
                    }
                    else
                    {
                        plunger.SetActive(false);
                        GameObject.Find("Player").GetComponent<Weapon>().Weapon2 = inventoryPlunger;
                        plungerText.SetActive(false);
                        GameObject.Find("HUD/Inventory/Slot 2/Item").GetComponent<Image>().sprite = plungerSprite;
                        GameObject.Find("HUD/Inventory/Slot 2/Item").SetActive(true);
                    }
                }
            }
            else
            {
                plungerText.SetActive(false);
            }
        }
        else
        {
            plungerText.SetActive(false);
        }










        //boulder barrier
        if (boulder.activeSelf)
        {
            boulderDistance = Vector3.Distance(player.transform.position, boulder.transform.position);
            if (boulderDistance < boulderMax)
            {
                if (GameObject.Find("Player").GetComponent<PlayerHealth>().morale >= 3)
                {
                    clearText.SetActive(true);
                    morale3.SetActive(false);
                    if (Input.GetButtonDown("Interact"))
                    {
                        barrierNoise.GetComponent<AudioSource>().Play();
                        boulder.SetActive(false);
                        clearText.SetActive(false);
                    }
                }
                else
                {
                    morale3.SetActive(true);
                    clearText.SetActive(false);
                }
            }
            else
            {
                clearText.SetActive(false);
                morale3.SetActive(false);
            }
        }

        //wood barrier
        if (wood.activeSelf)
        {
            woodDistance = Vector3.Distance(player.transform.position, wood.transform.position);
            if (woodDistance < woodMax)
            {
                if (GameObject.Find("Player").GetComponent<PlayerHealth>().morale >= 2)
                {
                    clearText2.SetActive(true);
                    morale2.SetActive(false);
                    if (Input.GetButtonDown("Interact"))
                    {
                        barrierNoise.GetComponent<AudioSource>().Play();
                        wood.SetActive(false);
                        clearText2.SetActive(false);
                    }
                }
                else
                {
                    morale2.SetActive(true);
                    clearText2.SetActive(false);
                }
            }
            else
            {
                clearText2.SetActive(false);
                morale2.SetActive(false);
            }
        }

        //escape method
        if (escape.activeSelf)
        {
            escapeDistance = Vector3.Distance(player.transform.position, escape.transform.position);
            if (escapeDistance < woodMax)
            {
                if (GameObject.Find("Player").GetComponent<PlayerHealth>().morale >= 3)
                {
                    escapeText.SetActive(true);
                    if (Input.GetButtonDown("Interact"))
                    {
                        escapeText.SetActive(false);
                        SceneManager.LoadScene("Victory");
                    }
                }
                else
                {
                    escapeText.SetActive(false);
                }
            }
            else
            {
                escapeText.SetActive(false);
            }
        }
    }
 }
