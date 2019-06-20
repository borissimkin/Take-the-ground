﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour {
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
    //TODO: дописать функцию столкновения с объектом, нанесения урона.
    GameObject createdBullet;
    public void GenerateBullet()
    {
        Vector3 bulletPosition = spawnPoint.transform.position;
        Vector2 bulletForce;

        float x = spawnPoint.transform.position.x - transform.position.x;
        float y = spawnPoint.transform.position.y - transform.position.y;

        bulletForce = new Vector2(x, y);

        createdBullet = Instantiate(bullet, bulletPosition, transform.rotation) as GameObject;

        createdBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce * GetComponent<Weapon>().speedBullet, ForceMode2D.Impulse);
        Destroy(createdBullet, 5);
    }
}
