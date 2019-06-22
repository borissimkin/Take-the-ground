using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //здесь был 
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        RotateToPlayer();
	}
}
