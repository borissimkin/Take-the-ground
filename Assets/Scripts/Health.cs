﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс здоровья. В нем реализуются методы потери здоровья, смерти объекта,
/// короче все что касается здоровья
/// </summary>
public class Health : MonoBehaviour {
    /// <summary>
    /// Здоровье
    /// </summary>
    public int health;
    //TODO: реализовать бронежилет тута

    /// <summary>
    /// Анимация смерти
    /// </summary>
    Animation death;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Death();
        }
	}

    private void Death()
    {
        //ТУТ АНИМАЦИЯ И ПОСЛЕ АНИМАЦИИ ДЕСТРОЙ ОБЖЕКТ
        //Возможно анимацию засунуть в корутину
    }

    public void AddDamage(int damage)
    {
        this.health = this.health - damage;
    }
}
