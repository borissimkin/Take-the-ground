using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    /// <summary>
    /// здоровье
    /// </summary>
    public float health;
    public float speed;
    Rigidbody2D rb;
    public int damage;
    public int rangeAttack;

    private Transform playerPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //здесь был 

    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    public virtual void Attack()
    {
         
    }

    private void Update()
    {
        Move();

    }




}
