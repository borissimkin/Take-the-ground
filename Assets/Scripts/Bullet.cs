using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
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
    //TODO: сделать так чтоб переменные настраивалась из класса weapon
    //TODO: дописать функцию столкновения с объектом, нанесения урона.
    public float speed;

    void GenerateBullet()
    {
        Vector3 bulletPosition = spawnPoint.transform.position;
        Vector2 bulletForce;

        float x = spawnPoint.transform.position.x - transform.position.x;
        float y = spawnPoint.transform.position.y - transform.position.y;

        bulletForce = new Vector2(x, y);

        GameObject createdBullet = Instantiate(bullet, bulletPosition, transform.rotation) as GameObject;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //НАПИСАНО ВРЕМЕННО ДЛЯ ПРОВЕРКИ
        if (Input.GetMouseButtonDown(0))
            GenerateBullet();
	}
}
