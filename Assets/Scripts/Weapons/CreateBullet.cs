using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    /// <summary>
    /// Префаб самого патрона
    /// </summary>
    public GameObject bullet;
    /// <summary>
    /// точка спауна пули
    /// </summary>
    public GameObject spawnPoint;
    /// <summary>
    /// Скорость полета пули
    /// </summary>

    public void GenerateBullet()
    {
        Vector3 bulletPosition = spawnPoint.transform.position;
        GameObject createdBullet = Instantiate(bullet, bulletPosition, transform.rotation) as GameObject;

        createdBullet.GetComponent<Bullet>().damage = GetComponent<Weapon>().damage;
        createdBullet.GetComponent<Bullet>().speed = GetComponent<Weapon>().speedBullet;
        Destroy(createdBullet, 5);
    }


}
