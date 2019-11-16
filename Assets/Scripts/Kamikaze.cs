using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy {
	public SpriteRenderer explosionSprite;

	public int damageExplosion;


	override public void Attack()
	{
		gameObject.GetComponent<Explosion>().damage = this.damageExplosion;
		gameObject.GetComponent<Explosion>().Boom();
		//Destroy(this.gameObject);
	}

}
