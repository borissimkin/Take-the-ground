using System.Collections;
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
    
    public void GenerateBullet()
    {
        Vector3 bulletPosition = spawnPoint.transform.position;
        Vector2 bulletForce;

        float spreading = GetComponent<Weapon>().spreading;

        float x = spawnPoint.transform.position.x - transform.position.x;
        float y = spawnPoint.transform.position.y - transform.position.y;

        float spreadingX = Random.Range((spreading * -1), spreading);
        //float spreadingX = Random.Range(0, spreading);
        float spreadingY = Random.Range((spreading * -1), spreading);

        bulletForce = new Vector2(x + spreadingX, y);

        GameObject createdBullet = Instantiate(bullet, bulletPosition, transform.rotation) as GameObject;

        createdBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce * GetComponent<Weapon>().speedBullet, ForceMode2D.Impulse);
        createdBullet.GetComponent<Bullet>().damage = GetComponent<Weapon>().damage;
        if (createdBullet != null)
            Destroy(createdBullet, 5);
    }

    
}
