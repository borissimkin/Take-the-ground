﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    /// <summary>
    /// Сам спрайт оружия
    /// </summary>
    public SpriteRenderer spriteWeapon;
    public SpriteRenderer spriteHands;

    /// <summary>
    /// Родитель хотя возможно стоит просто добавлять по тэгу и эта переменная не нужна
    /// </summary>
    public GameObject player;
    public Transform placePlayer;
    /// <summary>
    /// скорость полета пули
    /// </summary>
    public float speedBullet;

    /// <summary>
    /// Вместительность магазина.
    /// </summary>
    public int ClipCapacity;

    /// <summary>
    /// Вместительность запаса патронов.
    /// </summary>
    public int StashCapacity;

    /// <summary>
    /// Количество оставшихся патронов в магазине.
    /// </summary>
    public int AmmoLeftInClip;

    /// <summary>
    /// Количество оставшихся патронов в запасе.
    /// </summary>
    public int AmmoLeftInStash;

    /// <summary>
    /// Урон от оружия
    /// </summary>
    public int damage;

    /// <summary>
    /// дальность выстрела
    /// </summary>
    public float range;

    /// <summary>
    /// Темп стрельбы, чем больше, тем больше задержка между выстрелами
    /// </summary>
    public float timeout;

    /// <summary>
    /// Время перезарядки(смены магазина)
    /// </summary>
    public float reloadTime;

    /// <summary>
    /// Компонент звука
    /// </summary>
    protected AudioSource audioSource;

    /// <summary>
    /// Звук выстрела
    /// </summary>
    public AudioClip shootSound;

    public bool canShoot;

    public bool active
    {
        get { return this.spriteHands.enabled && this.spriteWeapon.enabled; }
        set
        {
            this.spriteWeapon.enabled = value;
            this.spriteHands.enabled = value;
            if (value)
            {
                if (AmmoLeftInClip == 0 && AmmoLeftInStash != 0)
                    Reload();
            }
            else
            {
                StopCoroutine("CoroutineReload");
            }
        }
    }

    protected void Start()
    {
        canShoot = true;

    }

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Shoot()
    {

        AmmoLeftInClip--;
        audioSource.PlayOneShot(shootSound);
        GetComponent<CreateBullet>().GenerateBullet();
        if (AmmoLeftInClip <= 0)
            Reload();
        else
        {
            StartCoroutine("CoroutineShoot");
        }

    }

    public IEnumerator CoroutineShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeout);
        canShoot = true;
        yield break;
    }

    public void Reload()
    {
        StartCoroutine("CoroutineReload");
    }

    public IEnumerator CoroutineReload()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);

        // она служит для красоты перезарядки)
        var ammo = 0;
        // если у нас были патроны в магазине то нашей временной переменной присваиваем значение оставшихся патронов
        if (AmmoLeftInClip > 0)
        {
            ammo = AmmoLeftInClip;
            AmmoLeftInClip = 0;
        }
        // (условие №2)если дополнительных патронов меньше чем максимальная емкость магазина...
        if (AmmoLeftInStash < ClipCapacity)
        {
            // (условие №3) если количество дополнительных патронов + оставшихся в магазине больше максимальной емкости магазина...
            if (AmmoLeftInStash + ammo > ClipCapacity)
            {

                // то кладем в магазин патроны в количестве максимального его объема
                AmmoLeftInClip = ClipCapacity;
                // а дополнительные патроны считаем по формуле: дополнительные патроны = дополнительные патроны + оставшиеся патроны - объем магазина
                AmmoLeftInStash = AmmoLeftInStash + ammo - ClipCapacity;
            }
            else
            {// если условие №3 не выполняется...
             // то кладем в магазин патроны в количетсве равное дополнительные патроны + те что остались
                AmmoLeftInClip = AmmoLeftInStash + ammo;
                // а дополнительные патроны приравниваем нулю
                AmmoLeftInStash = 0;
            }
        }
        else
        {// если условие №2 не выполняется...
         // то кладем в магазин патроны в количестве максимального его объема
            AmmoLeftInClip = ClipCapacity;
            // а дополнительные патроны считаем по формуле: дополнительные патроны = дополнительные патроны - объем магазина + оставшиеся
            AmmoLeftInStash = AmmoLeftInStash - ClipCapacity + ammo;
        }
        // включаем триггер (стрелять можно)
        canShoot = true;
    }


}
