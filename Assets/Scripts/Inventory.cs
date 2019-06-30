using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: реализовать пикапы
public enum TypeWeapon {pistol, automat}

public class Inventory : MonoBehaviour {
    private int amountTypeWeapon = 2;

    /// <summary>
    /// пока что три оружия: пистолет, автомат, дробовик
    /// </summary>
    public Weapon[] inventory;
    /// <summary>
    /// так как все оружия изначально есть на персонаже, надо проверять подобрал
    /// ли он их для разблокировки
    /// </summary>
    public bool[] isPickaped;
    //Dictionary<TypeWeapon, Weapon> inventory;
    public Weapon activeWeapon;
    public Pistol pistol;
    public SMG automat;
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
        inventory[1] = automat;
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
        else if (type == TypeWeapon.automat)
        {
            isPickaped[1] = true;
        }
    }

    public bool IsTaken(TypeWeapon type)
    {
        bool flag = false;
        if (type == TypeWeapon.pistol)
        {
            return isPickaped[0];
        }
        else if (type == TypeWeapon.automat)
        {
            return isPickaped[1];
        }
        return flag;
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
