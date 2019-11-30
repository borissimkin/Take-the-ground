using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    // Use this for initialization
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();

    }

    void Update()
    {

    }

    TypeWeapon TranslateTag(string tag)
    {
        TypeWeapon type = new TypeWeapon();
        switch (tag)
        {
            case "Pistol":
                type = TypeWeapon.pistol;
                break;
            case "AssaultRifle":
                type = TypeWeapon.assaultRifle;
                break;
            case "Shotgun":
                type = TypeWeapon.shotgun;
                break;
            case "GrenadeGun":
                type = TypeWeapon.grenadeGun;
                break;
        }
        return type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        TypeWeapon type = TranslateTag(tag);

        if (inventory.IsTaken(type))
        {
            Weapon pickupWeapon = collision.gameObject.GetComponent<Weapon>();
            bool isPickup = inventory.PickupAmmunition(pickupWeapon, type);
            if (isPickup)
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            inventory.Pickup(type);
            Destroy(collision.gameObject);
        }
        
    }
}
