using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeWeapon {
    Pistol, SMG, Shotgun
}

//TODO: реализовать пикапы
//TODO: сделать возможность быть безоружным

public class Inventory : MonoBehaviour {
    private int amountTypeWeapon = 2;

    /// <summary>
    /// пока что три оружия: пистолет, автомат, дробовик
    /// </summary>
    public Weapon[] inventory;
    //Dictionary<TypeWeapon, Weapon> inventory;
    public Weapon activeWeapon;
    public Pistol pistol;
    public SMG smg;
    /// <summary>
    /// Переменая указатель на текущее оружие. Инкрементриуется при нажатии Q
    /// </summary>
    private int pointSwitcher;

    void Start()
    {
        pointSwitcher = 0;
        inventory = new Weapon[amountTypeWeapon];
        //TODO: ЗАСУНУТЬ ПИСТОЛЕТ В 0!!!
        
        inventory[0] = pistol;
        inventory[1] = smg;
        activeWeapon = inventory[pointSwitcher];
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            HideWeapon(inventory[i]);
        }
        UnHideWeapon(activeWeapon);
    }
	

    //TODO: Сделать функцию, которая при нажатии на кнопку с цифрой вернет оружие под этим номером

    /// <summary>
    /// Функция смены оружия, при нажатии на Q
    /// </summary>
    public void SwitchWeapon()
    {
        pointSwitcher++;
        if (pointSwitcher >= amountTypeWeapon)
            pointSwitcher = 0;
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            HideWeapon(inventory[i]);
        }
        activeWeapon = inventory[pointSwitcher];
        UnHideWeapon(activeWeapon);
    }
    

	void Update () {
	}

    //функция прячет оружие вместе с руками
    void HideWeapon(Weapon weapon)
    {
        weapon.spriteWeapon.enabled = false;
        weapon.spriteHands.enabled = false;
    }

    //функция делает видимым оружие вместе с руками
    void UnHideWeapon(Weapon weapon)
    {
        weapon.spriteWeapon.enabled = true;
        weapon.spriteHands.enabled = true;
    }

    
}
