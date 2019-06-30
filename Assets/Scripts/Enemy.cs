using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    /// <summary>
    /// здоровье
    /// </summary>
    public float health;
    /// <summary>
    /// Скорость движения
    /// </summary>
    public float speed;
    /// <summary>
    /// Скорость поворота
    /// </summary>
    public float speedRotation;
    protected Rigidbody2D rb;
    /// <summary>
    /// Урона
    /// </summary>
    public int damage;
    /// <summary>
    /// расстояние атаки
    /// </summary>
    public int rangeAttack;

    /// <summary>
    /// скорость атаки
    /// </summary>
    public float speedAttack;

    protected float tempSpeed;  

    protected Transform playerPos;

    public bool canAttack;
    public bool canMove;

    protected Health playerHealth;
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        tempSpeed = speed;
        canAttack = true;
        canMove = true;

    }

    protected void Update()
    {
        if (canMove)
        {
            Move();
        }
        
        RotateToPlayer();
        var heading = GetComponent<Transform>().position - playerPos.position;
        if (heading.sqrMagnitude < rangeAttack * rangeAttack)
        {
            print("in distance");
            
            if (canAttack)
            {
                Attack();
            }


        }
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
        //ВОЗМОЖНО ЗДЕСЬ АНИМАЦИЯ АТАКИ
        playerHealth.AddDamage(damage);
        StartCoroutine(CoroutineAttack()); //CoroutineAttack();
        
    }

    public IEnumerator CoroutineAttack()
    {
        canAttack = false;
        canMove = false;
        // небольшая задержка
        yield return new WaitForSeconds(speedAttack);
        // разрешаем стрелять
        canAttack = true;
        canMove = true;
        // выходим с сопрограммы
        yield break;
    }

    public void Die()
    {
        print("СМЕРТЬ");
        GetComponent<DropSystem>().CalculateLoot();
        //СМЕРТЬ
    }

    protected void StopMoving()
    {
        speed = 0;
    }

    protected void ContinueMove()
    {
        speed = tempSpeed;
    }

}
