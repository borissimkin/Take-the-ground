using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ToDo: спрайт гранаты
public class Grenade : MonoBehaviour {
    public int damageExplosion;

	// Use this for initialization
	void Start () {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Explosion>().Boom();
        Destroy(this.gameObject);
    }
}
