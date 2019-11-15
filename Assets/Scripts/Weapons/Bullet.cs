using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public float speed;
    private Vector2 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        previousPosition = transform.position;
        transform.Translate(0.0f, speed * 100 * Time.deltaTime, 0.0f);
        Vector2 currentPosition = transform.position;
        Vector2 difference = currentPosition - previousPosition;
        RaycastHit2D hit = Physics2D.Raycast(previousPosition, difference.normalized, difference.magnitude);

        if (hit)
        {
            var hitObject = hit.collider.gameObject;
            if (hitObject.tag == "Enemy")
                hitObject.GetComponent<Health>().AddDamage(damage);
            if (hitObject != this.gameObject)
                Destroy(this.gameObject);
        }
    }

}
