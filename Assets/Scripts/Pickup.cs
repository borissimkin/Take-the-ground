using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Pickup : MonoBehaviour {
    private Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<Inventory>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("pickup");
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            //ToDo: проиграть звук пикапа
            case "Pistol":
                inventory.Pickaped(TypeWeapon.pistol);
                break;
            case "M16":
                inventory.Pickaped(TypeWeapon.automat);
                Destroy(collision.gameObject);
                break;
        }
        
    }
}
