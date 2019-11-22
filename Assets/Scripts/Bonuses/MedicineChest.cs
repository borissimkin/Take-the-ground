using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Treat))]
public class MedicineChest : MonoBehaviour {
	public int addHealth;
	private Treat treat;

	void Start()
	{
		treat = GetComponent<Treat>();
		treat.addHealth = addHealth;
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Player")
		{
			bool isCured = treat.Cure(collision.gameObject);
			if (isCured)
			{
				Destroy(gameObject);
			}
			
		}
    }
}
