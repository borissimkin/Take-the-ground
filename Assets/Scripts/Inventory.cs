using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: реализовать пикапы
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
    private bool[] isPickaped;
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
        isPickaped = new bool[amountTypeWeapon];

        inventory[0] = pistol;
        inventory[1] = assaultRifle;
        inventory[2] = shotgun;
        inventory[3] = grenadeGun;
        activeWeapon = inventory[pointSwitcher];
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            isPickaped[i] = false;
            HideWeapon(inventory[i]);
        }
        UnHideWeapon(activeWeapon);
        isPickaped[0] = true;
    }


    //TODO: Сделать функцию, которая при нажатии на кнопку с цифрой вернет оружие под этим номером

    /// <summary>
    /// Функция смены оружия, при нажатии на Q
    /// </summary>
    public void SwitchWeapon()
    {
        //ToDO: реализоват вдальнейшем переключение когда в середине инвентаря есть какое то оружие
        pointSwitcher++;
        if (pointSwitcher >= amountTypeWeapon)
            pointSwitcher = 0;
        if (isPickaped[pointSwitcher] == false)
            return;
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            HideWeapon(inventory[i]);
        }
        activeWeapon = inventory[pointSwitcher];
        UnHideWeapon(activeWeapon);
    }

    public void Pickaped(TypeWeapon type)
    {
        if (type == TypeWeapon.pistol)
        {
            isPickaped[0] = true;
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            isPickaped[1] = true;
        }
        else if (type == TypeWeapon.shotgun)
        {
            isPickaped[2] = true;
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            isPickaped[3] = true;
        }
    }

    public bool IsTaken(TypeWeapon type)
    {
        bool flag = false;
        if (type == TypeWeapon.pistol)
        {
            return isPickaped[0];
        }
        else if (type == TypeWeapon.assaultRifle)
        {
            return isPickaped[1];
        }
        else if (type == TypeWeapon.shotgun)
        {
            return isPickaped[2];
        }
        else if (type == TypeWeapon.grenadeGun)
        {
            return isPickaped[3];
        }
        return flag;
    }

    void Update()
    {
    }

    //функция прячет оружие вместе с руками
    void HideWeapon(Weapon weapon)
    {
        weapon.active = false;
    }

    //функция делает видимым оружие вместе с руками
    void UnHideWeapon(Weapon weapon)
    {
        weapon.active = true;
    }


}
