using System.Collections;
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
    /// Родитель
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
    public int clipCapacity;

    /// <summary>
    /// Вместительность запаса патронов.
    /// </summary>
    public int stashCapacity;

    /// <summary>
    /// Количество оставшихся патронов в магазине.
    /// </summary>
    public int ammoLeftInClip;

    /// <summary>
    /// Количество оставшихся патронов в запасе.
    /// </summary>
    public int ammoLeftInStash;

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

    public AudioClip pickupSound;

    public float soundVolume = 0.3f;

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
                if (ammoLeftInClip == 0 && ammoLeftInStash != 0)
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

        ammoLeftInClip--;
        audioSource.PlayOneShot(shootSound, soundVolume);
        GetComponent<CreateBullet>().GenerateBullet();
        if (ammoLeftInClip <= 0)
        {
            Reload();
        }
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

    public bool IsStashFull()
    {
        if (this.ammoLeftInStash == this.stashCapacity)
        {
            return true;
        }
        else
        {
            return false;
        }
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
        if (ammoLeftInClip > 0)
        {
            ammo = ammoLeftInClip;
            ammoLeftInClip = 0;
        }
        // (условие №2)если дополнительных патронов меньше чем максимальная емкость магазина...
        if (ammoLeftInStash < clipCapacity)
        {
            // (условие №3) если количество дополнительных патронов + оставшихся в магазине больше максимальной емкости магазина...
            if (ammoLeftInStash + ammo > clipCapacity)
            {

                // то кладем в магазин патроны в количестве максимального его объема
                ammoLeftInClip = clipCapacity;
                // а дополнительные патроны считаем по формуле: дополнительные патроны = дополнительные патроны + оставшиеся патроны - объем магазина
                ammoLeftInStash = ammoLeftInStash + ammo - clipCapacity;
            }
            else
            {// если условие №3 не выполняется...
             // то кладем в магазин патроны в количетсве равное дополнительные патроны + те что остались
                ammoLeftInClip = ammoLeftInStash + ammo;
                // а дополнительные патроны приравниваем нулю
                ammoLeftInStash = 0;
            }
        }
        else
        {// если условие №2 не выполняется...
         // то кладем в магазин патроны в количестве максимального его объема
            ammoLeftInClip = clipCapacity;
            // а дополнительные патроны считаем по формуле: дополнительные патроны = дополнительные патроны - объем магазина + оставшиеся
            ammoLeftInStash = ammoLeftInStash - clipCapacity + ammo;
        }
        // включаем триггер (стрелять можно)
        canShoot = true;
    }


}
