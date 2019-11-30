using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : Weapon {
    public int radiusExplosion = 30;

    override public void Shoot()
    {
        ammoLeftInClip--;   
        audioSource.PlayOneShot(shootSound);
        GetComponent<CreateGrenade>().GenerateGrenade();
        if (ammoLeftInClip <= 0)
            StartCoroutine(CoroutineReload());
        else
        {
            StartCoroutine(CoroutineShoot());
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
