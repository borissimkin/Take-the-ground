﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ShootSystem : MonoBehaviour
{

    private Inventory inventory;
    public bool fire = true;
    //Weapon currentWeapon;

    void Start()
    {
        inventory = GetComponent<Inventory>();

    }

    void Update()
    {
        if (!fire) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.SwitchWeapon();
        }
        if (Input.GetMouseButton(0) & inventory.activeWeapon.canShoot & inventory.activeWeapon.ammoLeftInClip > 0)
        {
            inventory.activeWeapon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && inventory.activeWeapon.ammoLeftInClip != inventory.activeWeapon.clipCapacity)
        {
            inventory.activeWeapon.Reload();
        }

    }
}
