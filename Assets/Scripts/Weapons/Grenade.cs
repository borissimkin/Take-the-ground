using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ToDo: спрайт гранаты
public class Grenade : MonoBehaviour {
    public int damageExplosion;
    public GameObject explosionPrefub;

	// Use this for initialization
	void Start () {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(explosionPrefub, transform.position, transform.rotation) as GameObject;
        explosion.GetComponent<Explosion>().damage = damageExplosion;
        explosion.GetComponent<Explosion>().Boom();
        Destroy(this.gameObject);
    }
}
