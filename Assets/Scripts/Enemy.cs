using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    /// <summary>
    /// здоровье
    /// </summary>
    public float health;
    public float speed;
    public float speedRotation;
    protected Rigidbody2D rb;
    public int damage;
    public int rangeAttack;

    protected Transform playerPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 

    }

    public virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }


    public void RotateToPlayer()
    {
        Vector2 direction = transform.position - playerPos.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speedRotation * Time.deltaTime);
    }

    public virtual void Attack()
    {
         
    }

    private void Update()
    {
        Move();

    }




}
