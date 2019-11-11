using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс HUD здоровья.
/// </summary>
public class HealthHUD : MonoBehaviour {
    [SerializeField]
    private Text health_text;
    [SerializeField]
    private  GameObject heltheableObject;
    private int health;

	// Use this for initialization
	void Start () {
        this.ShowHealth();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.ShowHealth();
    }

    void ShowHealth()
    {
        health = heltheableObject.GetComponent<Health>().health;
        this.health_text.text = this.health.ToString();
    }
}
