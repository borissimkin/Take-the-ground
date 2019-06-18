using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemy;
    public Transform[] spawnSpots;

    private float timeBtwSpawns;
    [SerializeField]
    private float startTimeBtwSpawns;


    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = UnityEngine.Random.Range(0, spawnSpots.Length - 1);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    private void Instantiate(GameObject enemy, Vector3 position)
    {
        throw new NotImplementedException();
    }
}
