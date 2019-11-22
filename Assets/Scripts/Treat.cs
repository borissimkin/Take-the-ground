using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour {
	 [HideInInspector]public int addHealth;

	public bool Cure(GameObject curebleObject)
	{
		Health health = curebleObject.GetComponent<Health>();
		if (!health)
		{
			return false;
		}
		if (health.health == health.maxHealth)
		{
			return false;
		}
		health.health += addHealth;
		if (health.health > health.maxHealth)
		{
			health.health = health.maxHealth;
		}
		return true;
	}
}
