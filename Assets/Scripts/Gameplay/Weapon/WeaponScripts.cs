using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScripts : MonoBehaviour
{
    int totalWeapon = 1;
    public int currentWeaponIndex;

    public PlayerAttack PL;
    public GameObject[] weapon;
    public GameObject weaponHolder;
    public GameObject currentweapon;

    void Start()
    {
        totalWeapon = weaponHolder.transform.childCount;
        weapon = new GameObject[totalWeapon];

        for (int i = 0; i < totalWeapon; i++)
        {
            weapon[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapon[i].SetActive(false);
        }

        weapon[0].SetActive(true);
        currentweapon = weapon[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        if (PL.changedBlocked == false)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(currentWeaponIndex < totalWeapon-1)
                {
                    weapon[currentWeaponIndex].SetActive(false);
                    currentWeaponIndex += 1;
                    weapon[currentWeaponIndex].SetActive(true);
                    currentweapon = weapon[currentWeaponIndex];
                }
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                if(currentWeaponIndex > 0)
                {
                    weapon[currentWeaponIndex].SetActive(false);
                    currentWeaponIndex -= 1;
                    weapon[currentWeaponIndex].SetActive(true);
                    currentweapon = weapon[currentWeaponIndex];
                }
            }
        }
    }
}
