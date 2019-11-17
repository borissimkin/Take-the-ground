using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo: спрайт или анимация
public class Explosion : MonoBehaviour {
    public float radius;
    public int damage;
    public SpriteRenderer explosionSprite;

    public AudioSource audioSource;

    public AudioClip explosionSound;

    public void Boom()
    {
        radius = explosionSprite.size.x; //радиус взрыва равен  размеру спрайта
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSound, 10);
        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {
            Health health = hit.GetComponent<Health>();
            if (health)
            {
                health.AddDamage(damage);
            }
        }
        Destroy(gameObject, 1);
    }
}
