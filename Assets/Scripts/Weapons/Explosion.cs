using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo: спрайт или анимация
public class Explosion : MonoBehaviour {
    public float radius;
    public int damage;
    public SpriteRenderer explosionSprite;

    public void Boom()
    {
        Vector2 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Health health;
            if (health = hit.GetComponent<Health>())
            {
                GameObject createdBullet = Instantiate(explosionSprite.gameObject, transform.position, transform.rotation) as GameObject;
                health.AddDamage(damage);
            }

        }
    }
}
