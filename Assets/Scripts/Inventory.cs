using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeWeapon {
    Pistol, SMG, Shotgun
}

//TODO: реализовать пикапы
//TODO: сделать возможность быть безоружным

public class Inventory : MonoBehaviour {
    private int amountTypeWeapon = 3;

    /// <summary>
    /// пока что три оружия: пистолет, автомат, дробовик
    /// </summary>
    public Weapon[] inventory;
    //Dictionary<TypeWeapon, Weapon> inventory;
    public Weapon activeWeapon;
    /// <summary>
    /// Переменая указатель на текущее оружие. Инкрементриуется при нажатии Q
    /// </summary>
    private int pointSwitcher;

    void Start()
    {
        pointSwitcher = 0;
        inventory = new Weapon[amountTypeWeapon];
        for (int i = 0; i < amountTypeWeapon; i++)
        {
            inventory[i] = null;
        }
        //TODO: ЗАСУНУТЬ ПИСТОЛЕТ В 0!!!
        activeWeapon = inventory[pointSwitcher];
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
        if (inventory[pointSwitcher] == null)
        {
            pointSwitcher--;
            return;
        }
        activeWeapon = inventory[pointSwitcher];
    }
    

	void Update () {
		
	}

    
}
