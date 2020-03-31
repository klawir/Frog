using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForObstacles : DetectorForMovingItems
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == playerTag)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnPlayer();
        }
        if (collision.tag == spawnTrigger)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnObstacle(obstacle);
        }
        if (collision.tag == endOfMapTag)
        {
            spawnerManager.RespawnObstacle(obstacle);
            Destroy(gameObject);
        }
    }
}