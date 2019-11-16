
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{

    public SpriteRenderer legs;
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public bool isdead = false;
    /// <summary>
    /// Ограничение на диагональное движение
    /// </summary>
    float moveLimiter = 0.7f;
    [SerializeField] private float runSpeed;

    private bool running = false;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        legs.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 лево
            vertical = Input.GetAxisRaw("Vertical"); // -1 вниз
        }
        
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) //диагональное движение
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (Mathf.Abs(body.velocity.x) > 0 || Mathf.Abs(body.velocity.y) > 0)
        {
            if (!running)
            {
                legs.enabled = true;
                StartCoroutine("WalkingAnimation");
                running = true;
            }
        }
        else if (running)
        {
            StopCoroutine("WalkingAnimation");
            running = false;
            legs.enabled = false;
        }
    }

    private IEnumerator WalkingAnimation()
    {
        while (true)
        {
            legs.flipX = !legs.flipX;
            yield return new WaitForSeconds(1 / runSpeed);
        }
    }
}