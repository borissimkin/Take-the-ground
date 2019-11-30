using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    private AudioSource audioSource;
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
        audioSource = gameObject.GetComponent<AudioSource>();

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
        Weapon pickupWeapon = collision.gameObject.GetComponent<Weapon>();

        if (inventory.IsTaken(type))
        {
            
            bool isPickup = inventory.PickupAmmunition(pickupWeapon, type);
            if (isPickup)
            {
                audioSource.PlayOneShot(pickupWeapon.pickupSound, 100);
                Destroy(collision.gameObject);
            }
        }
        else
        {
            audioSource.PlayOneShot(pickupWeapon.pickupSound, 100);
            inventory.Pickup(type);
            Destroy(collision.gameObject);
        }
        
    }
}
