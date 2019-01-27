﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField]
    private weaponhandler[] weapons;

    private int current_weapon_index;


    // Start is called before the first frame update
    void Start()
    {
        current_weapon_index = 0;
        weapons[current_weapon_index].gameObject.SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TurnOnSelectedWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TurnOnSelectedWeapon(5);
        }

        void TurnOnSelectedWeapon(int weaponIndex)
        {
            if (current_weapon_index == weaponIndex)
            {
                return;
            }
            weapons[current_weapon_index].gameObject.SetActive(false);

            weapons[weaponIndex].gameObject.SetActive(true);

            current_weapon_index = weaponIndex;
        }
    }

    public weaponhandler GetCurrentSelectWeapon()
    {
        return weapons[current_weapon_index];

    }
}
