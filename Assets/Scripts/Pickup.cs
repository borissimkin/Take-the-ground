using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    private AudioSource audioSource;
    public float soundVolume = 0f;
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
        TypeWeapon typePickupWeapon = TranslateTag(tag);
        Weapon pickupWeapon = collision.gameObject.GetComponent<Weapon>();

        if (inventory.IsTaken(typePickupWeapon))
        {
            
            bool canPickup = inventory.CanPickupAmmuntion(typePickupWeapon);
            if (canPickup)
            {
                inventory.PickupAmmunition(pickupWeapon, typePickupWeapon);
                audioSource.PlayOneShot(pickupWeapon.pickupSound, this.soundVolume);
                Destroy(collision.gameObject);
            }
        }
        else
        {
            audioSource.PlayOneShot(pickupWeapon.pickupSound, this.soundVolume);
            inventory.Pickup(typePickupWeapon);
            Destroy(collision.gameObject);
        }
        
    }
}
