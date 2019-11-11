using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo: спрайт или анимация
public class Explosion : MonoBehaviour {
    public float radius;
    public int damage;

    public void Boom()
    {
        Vector2 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Health health;
            if (health = hit.GetComponent<Health>())
            {
                health.AddDamage(damage);
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
