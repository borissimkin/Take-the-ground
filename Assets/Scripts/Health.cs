using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс здоровья. В нем реализуются методы потери здоровья, смерти объекта,
/// короче все что касается здоровья
/// </summary>
public class Health : MonoBehaviour {
    /// <summary>
    /// Здоровье
    /// </summary>
    [SerializeField]
    private int health;

    /// <summary>
    /// Анимация смерти
    /// </summary>
    Animation death;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Death();
        }
	}

    private void Death()
    {
        Destroy(this.gameObject);
        //ТУТ АНИМАЦИЯ И ПОСЛЕ АНИМАЦИИ ДЕСТРОЙ ОБЖЕКТ
        //Возможно анимацию засунуть в корутину
    }

    public void AddDamage(int damage)
    {
        this.health = this.health - damage;
        print(health);
    }
}
