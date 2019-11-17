using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy {
	public GameObject explosionPrefub;

	public int damageExplosion;


	override public void Attack()
	{
		GameObject explosion = Instantiate(explosionPrefub, transform.position, transform.rotation) as GameObject;
		explosion.GetComponent<Explosion>().damage = this.damageExplosion;
		explosion.GetComponent<Explosion>().Boom();
	}

}
