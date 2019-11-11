﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGun : Weapon {
    public int radiusExplosion;

    override public void Shoot()
    {
        AmmoLeftInClip--;
        audioSource.PlayOneShot(shootSound);
        GetComponent<CreateGrenade>().GenerateGrenade();
        if (AmmoLeftInClip <= 0)
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
