using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ShootSystem : MonoBehaviour {

    private Inventory inventory;
    //Weapon currentWeapon;

    // Use this for initialization
    void Start () {
        inventory = GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventory.SwitchWeapon();
        }
        if (Input.GetMouseButton(0) & inventory.activeWeapon.canShoot & inventory.activeWeapon.AmmoLeftInClip > 0)
        {
            inventory.activeWeapon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) & inventory.activeWeapon.canShoot && inventory.activeWeapon.AmmoLeftInClip != inventory.activeWeapon.AmmoLeftInStash
            && inventory.activeWeapon.AmmoLeftInClip != inventory.activeWeapon.ClipCapacity)
        {
            inventory.activeWeapon.canShoot = false;
            StartCoroutine(inventory.activeWeapon.CoroutineReload());
        }

    }
}
