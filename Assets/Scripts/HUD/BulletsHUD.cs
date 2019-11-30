using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс HUD'a патронов текущего оружия в руках персонажа
/// </summary>
public class BulletsHUD : MonoBehaviour {
    [SerializeField]
    private Text textBullets;

    [SerializeField]
    private GameObject person;

    private Weapon activeWeapon;

	// Use this for initialization
	void Start () {

        ShowText();
	}

	// Update is called once per frame
	void Update () {
        ShowText();
    }
    void ShowText()
    {
        activeWeapon = person.GetComponent<Inventory>().activeWeapon;
        this.textBullets.text = this.GetTextBullets(activeWeapon);
    }

    string GetTextBullets(Weapon activeWeapon)
    {
        string ammoLeftInClip = activeWeapon.ammoLeftInClip.ToString();
        string ammoLeftInStash = activeWeapon.ammoLeftInStash.ToString();
        return string.Format("{0} / {1}", ammoLeftInClip, ammoLeftInStash);
    }

}
