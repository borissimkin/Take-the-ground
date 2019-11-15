using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrenade : MonoBehaviour {
    /// <summary>
    /// Префаб самого патрона
    /// </summary>
    public GameObject grenade;
    /// <summary>
    /// точка спауна пули
    /// </summary>
    public GameObject spawnPoint;
    /// <summary>
    /// Скорость полета пули
    /// </summary>

    public void GenerateGrenade()
    {
        print("ГЕНЕРИРУЕМ ГРАНАТУ");
        Vector3 bulletPosition = spawnPoint.transform.position;
        Vector2 bulletForce;

        float x = spawnPoint.transform.position.x - transform.position.x;
        float y = spawnPoint.transform.position.y - transform.position.y;

        bulletForce = new Vector2(x, y);

        GameObject createdBullet = Instantiate(grenade, bulletPosition, transform.rotation) as GameObject;
        print(createdBullet);
        createdBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce * GetComponent<Weapon>().speedBullet, ForceMode2D.Impulse);
        print(createdBullet.GetComponent<Grenade>().damageExplosion);
        //Debug.Break();
        createdBullet.GetComponent<Grenade>().damageExplosion = GetComponent<Weapon>().damage;
        print(createdBullet.GetComponent<Grenade>().damageExplosion);
        createdBullet.GetComponent<Grenade>().endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Break();
        print(createdBullet.GetComponent<Grenade>().endPoint);
        //Debug.Break();
        print("Доконца");
    }
}
