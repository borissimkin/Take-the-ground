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

    TypeWeapon TranslateTag(string tag)
    {
        TypeWeapon type = new TypeWeapon();
        switch (tag)
        {
            case "Pistol":
                type = TypeWeapon.pistol;
                break;
            case "M16":
                type = TypeWeapon.automat;
                break;
        }
        return type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("pickup");
        string tag = collision.gameObject.tag;
        TypeWeapon type = TranslateTag(tag);

        if (inventory.IsTaken(type))
            return;
        //ToDo: прогирать звук пикапа
        inventory.Pickaped(type);
        Destroy(collision.gameObject);
        //switch(tag)
        //{
        //    //ToDo: проиграть звук пикапа
        //    case "Pistol":
        //        inventory.Pickaped(TypeWeapon.pistol);
        //        break;
        //    case "M16":
        //        inventory.Pickaped(TypeWeapon.automat);
        //        Destroy(collision.gameObject);
        //        break;
        //}
        
    }
}
