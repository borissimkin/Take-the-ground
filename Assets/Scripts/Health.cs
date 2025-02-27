﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс здоровья. В нем реализуются методы потери здоровья, смерти объекта,
/// короче все что касается здоровья
/// </summary>
public abstract class Health : MonoBehaviour
{
    /// <summary>
    /// Здоровье
    /// </summary>
    [SerializeField]
    public int maxHealth;

     [HideInInspector] public int health;
    bool checkDeath = false;
    /// <summary>
    /// Анимация смерти
    /// </summary>
    Animation death;

    // Use this for initialization
    protected void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (health <= 0 && !checkDeath)
        {
            Death();
            checkDeath = true;
        }
    }

    public virtual void Death()
    {
        var dropSystem = GetComponent<DropSystem>();
        if (dropSystem)
        {
            dropSystem.CalculateLoot();
        }
        Destroy(this.gameObject);

        //ТУТ АНИМАЦИЯ И ПОСЛЕ АНИМАЦИИ ДЕСТРОЙ ОБЖЕКТ
        //Возможно анимацию засунуть в корутину
    }

    public void AddDamage(int damage)
    {
        if (this.health > 0)
        {
            this.health = this.health - damage;
            if (this.tag == "Player")
                print(health);
        }
        else this.health = 0;
    }
}
