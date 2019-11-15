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
        
        Vector3 bulletPosition = spawnPoint.transform.position;
        Vector2 bulletForce;

        float x = spawnPoint.transform.position.x - transform.position.x;
        float y = spawnPoint.transform.position.y - transform.position.y;

        bulletForce = new Vector2(x, y);

        GameObject createdBullet = Instantiate(grenade, bulletPosition, transform.rotation) as GameObject;

        createdBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce * GetComponent<Weapon>().speedBullet, ForceMode2D.Impulse);

        createdBullet.GetComponent<Grenade>().damageExplosion = GetComponent<Weapon>().damage;
    }
}
