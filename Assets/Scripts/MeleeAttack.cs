using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int Damage = 50;
    public float Distance;
    public float MaxDistance;
    public GameObject knife;
    public GameObject plunger;
    public GameObject dart;
    public GameObject scythe;
    public GameObject spear;
    public GameObject axe;
    public GameObject equippedWeapon;
    public string weaponAnimation;
    public int canMelee = 80;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //change damage based on weapon
        if (knife.activeSelf)
        {
            Damage = 50;
            equippedWeapon = knife;
            weaponAnimation = "KnifeAttack";
        }
        else if (plunger.activeSelf)
        {
            Damage = 25;
            equippedWeapon = plunger;
            weaponAnimation = "PlungerAttack";
        }
        else if (dart.activeSelf)
        {
            Damage = 10;
            equippedWeapon = dart;
            weaponAnimation = "DartAttack";
        }
        else if (scythe.activeSelf)
        {
            Damage = 150;
            equippedWeapon = scythe;
            weaponAnimation = "ScytheAttack";
        }
        else if (spear.activeSelf)
        {
            Damage = 75;
            equippedWeapon = spear;
            weaponAnimation = "SpearAttack";
        }
        else if (axe.activeSelf)
        {
            Damage = 100;
            equippedWeapon = axe;
            weaponAnimation = "AxeAttack";
        }
        else
        {
            Damage = 00;
        }

        //does melee
        if (Input.GetButtonDown("Fire1"))
        {
            if (canMelee <= 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    Distance = hit.distance;
                    if (Distance < MaxDistance)
                    {
                        equippedWeapon.GetComponent<Animation>().Play();
                        equippedWeapon.GetComponent<AudioSource>().Play();
                        hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
                       //Sets a timer on melee for frequency
                        canMelee = 80;
                    }
                }
            }
        }
        canMelee--;
        if(canMelee < 0)
        {
            canMelee = 0;
        }

        //removes morale barriers
        if(Input.GetButtonDown("Interact"))
        {
            if (GameObject.Find("Player").GetComponent<PlayerHealth>().morale >= 3)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    Distance = hit.distance;
                    if (Distance < MaxDistance)
                    {
                        hit.transform.SendMessage("Remove", Damage, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
