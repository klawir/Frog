﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    public string playerTag;
    public string endOfMapTag;
    public string spawnTrigger;

    public Obstacle obstacle;
    private SpawnerManager spawnerManager;

    private void Start()
    {
        spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnPlayer();
        }
        if (collision.tag == endOfMapTag)
        {
            spawnerManager.RespawnCar(obstacle); 
            Destroy(gameObject);
        }
        if (collision.tag == spawnTrigger)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnCar(obstacle);
        }
    }
}
