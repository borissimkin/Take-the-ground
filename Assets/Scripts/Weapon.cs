using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    /// <summary>
    /// Разброс
    /// </summary>
    public float spreading;
    /// <summary>
    /// Урон
    /// </summary>
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
    public float damage;

    /// <summary>
    /// дальность выстрела
    /// </summary>
    public float range;

    /// <summary>
    /// Темп стрельбы
    /// </summary>
    public float timeout;

    /// <summary>
    /// Время перезарядки(смены магазина)
    /// </summary>
    public float reloadTime;

    public bool canShoot; // для отключения стрельбы во время перезаряда(в дальнейшем и когда только достал оружие и идет анимация(наверно))

    public void Shoot()
    {
        AmmoLeftInClip--;
        

        if (AmmoLeftInClip <= 0)
            StartCoroutine(CoroutineReload());
        else
        {
            StartCoroutine(CoroutineShoot());
        }

    }

    // сопрограмма стрельбы
    public IEnumerator CoroutineShoot()
    {
        // небольшая задержка
        yield return new WaitForSeconds(timeout);
        // разрешаем стрелять
        canShoot = true;
        // выходим с сопрограммы
        yield break;

    }

    // сопрограмма перезарядки
    public IEnumerator CoroutineReload()
    {
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
