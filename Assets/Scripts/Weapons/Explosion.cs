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
        radius = explosionSprite.size.x; //радиус взрыва равен  размеру спрайта
        GameObject explosion = Instantiate(explosionSprite.gameObject, transform.position, transform.rotation) as GameObject;
        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Health health;
            if (health = hit.GetComponent<Health>())
            {
                health.AddDamage(damage);
            }
        }
        Destroy(explosion, 1);
    }
}
