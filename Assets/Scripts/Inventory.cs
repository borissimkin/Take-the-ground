using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeWeapon { pistol, assaultRifle, shotgun, grenadeGun }

public class Inventory : MonoBehaviour
{
    private int amountTypeWeapon = 4;

    /// <summary>
    /// пока что четыре оружия: пистолет, автомат, дробовик, гранатомет
    /// </summary>
    private Weapon[] inventory;
    /// <summary>
    /// так как все оружия изначально есть на персонаже, надо проверять подобрал
    /// ли он их для разблокировки
    /// </summary>
    private bool[] isPickup;
    public Weapon activeWeapon;
    public Pistol pistol;
    public AssaultRifle assaultRifle;
    public Shotgun shotgun;
    public GrenadeGun grenadeGun;

    /// <summary>
    /// Переменая указатель на текущее оружие. Инкрементриуется при нажатии Q
    /// </summary>
    private int pointSwitcher;

    void Start()
    {
        pointSwitcher = 0;
        inventory = new Weapon[amountTypeWeapon];
        isPickup = new bool[amountTypeWeapon];

        inventory[0] = pistol;
        inventory[1] = assaultRifle;
        inventory[2] = shotgun;
        inventory[3] = grenadeGun;
        activeWeapon = inventory[pointSwitcher];
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            isPickup[i] = false;
            HideWeapon(inventory[i]);
        }
        UnHideWeapon(activeWeapon);
        isPickup[0] = true;
    }

    /// <summary>
    /// Функция смены оружия, при нажатии на Q
    /// </summary>
    public void SwitchWeapon()
    {
        pointSwitcher++;
        if (pointSwitcher >= amountTypeWeapon)
            pointSwitcher = 0;
        if (isPickup[pointSwitcher] == false)
            return;
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            HideWeapon(inventory[i]);
        }
        activeWeapon = inventory[pointSwitcher];
        UnHideWeapon(activeWeapon);
    }

    public void Pickup(TypeWeapon type)
    {
        if (type == TypeWeapon.pistol)
        {
            isPickup[0] = true;
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            isPickup[1] = true;
        }
        else if (type == TypeWeapon.shotgun)
        {
            isPickup[2] = true;
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            isPickup[3] = true;
        }
    }

    public bool PickupAmmunition(Weapon pickupWeapon, TypeWeapon typePickupWeapon)
    {
        Weapon weaponInInventory = this.GetWeapon(typePickupWeapon);
        if (weaponInInventory.IsFullStash())
        {
            return false;
        }
        this.ExchangeStashWeapons(pickupWeapon, weaponInInventory);
        return true;
    }

    private void ExchangeStashWeapons(Weapon pickupWeapon, Weapon inventoryWeapon)
    {
        int stashAmmoPickupWeapon = pickupWeapon.ammoLeftInStash;
        inventoryWeapon.ammoLeftInStash += stashAmmoPickupWeapon;
        if (inventoryWeapon.ammoLeftInStash > inventoryWeapon.stashCapacity)
        {
            inventoryWeapon.ammoLeftInStash = inventoryWeapon.stashCapacity;
        }
    }

    public Weapon GetWeapon(TypeWeapon type)
    {
        if (type == TypeWeapon.pistol)
        {
            return this.inventory[0];
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            return this.inventory[1];
        }
        else if (type == TypeWeapon.shotgun)
        {
            return this.inventory[2];
        }
        else
        {
            return this.inventory[3];
        }

    }

    public bool IsTaken(TypeWeapon type)
    {
        bool flag = false;
        if (type == TypeWeapon.pistol)
        {
            return isPickup[0];
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            return isPickup[1];
        }
        else if (type == TypeWeapon.shotgun)
        {
            return isPickup[2];
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            return isPickup[3];
        }
        return flag;
    }

    void Update()
    {
    }

    void HideWeapon(Weapon weapon)
    {
        weapon.active = false;
    }

    void UnHideWeapon(Weapon weapon)
    {
        weapon.active = true;
    }


}
