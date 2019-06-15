
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D body;
    float horizontal;
    float vertical;
    /// <summary>
    /// Ограничение на диагональное движение
    /// </summary>
    float moveLimiter = 0.7f;
    [SerializeField] private float runSpeed = 20f;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 лево
        vertical = Input.GetAxisRaw("Vertical"); // -1 вниз
    }
    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) //диагональное движение
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}