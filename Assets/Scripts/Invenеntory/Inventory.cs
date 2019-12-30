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
    private bool[] isPickedUp;
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
        isPickedUp = new bool[amountTypeWeapon];

        inventory[0] = pistol;
        inventory[1] = assaultRifle;
        inventory[2] = shotgun;
        inventory[3] = grenadeGun;
        activeWeapon = inventory[pointSwitcher];
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            isPickedUp[i] = false;
            HideWeapon(inventory[i]);
        }
        UnHideWeapon(activeWeapon);
        isPickedUp[0] = true;
    }

    /// <summary>
    /// Функция смены оружия, при нажатии на Q
    /// </summary>
    public void SwitchWeapon()
    {
        pointSwitcher++;
        if (pointSwitcher >= amountTypeWeapon)
            pointSwitcher = 0;
        if (isPickedUp[pointSwitcher] == false)
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
            isPickedUp[0] = true;
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            isPickedUp[1] = true;
        }
        else if (type == TypeWeapon.shotgun)
        {
            isPickedUp[2] = true;
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            isPickedUp[3] = true;
        }
    }

    public bool CanPickupAmmuntion(TypeWeapon typePickupWeapon)
    {
        Weapon weaponInInventory = this.GetWeapon(typePickupWeapon);
        if (weaponInInventory.IsStashFull())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void PickupAmmunition(Weapon pickupWeapon, TypeWeapon typePickupWeapon)
    {
        Weapon weaponInInventory = this.GetWeapon(typePickupWeapon);
        this.ExchangeStashWeapons(pickupWeapon, weaponInInventory);
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
            return isPickedUp[0];
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            return isPickedUp[1];
        }
        else if (type == TypeWeapon.shotgun)
        {
            return isPickedUp[2];
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            return isPickedUp[3];
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
