using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForMovingObjects : Detector
{
    public string spawnTrigger;
    public string endOfMapTag;
    public string limitImmersionInWater;
    public MovingObject obstacle;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == spawnTrigger)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnObject(obstacle);
        }
        if (collision.tag == endOfMapTag)
        {
            spawnerManager.RespawnObject(obstacle);
            Destroy(gameObject);
        }
        if (collision.tag == limitImmersionInWater)
            obstacle.BlockImmersionInWater();
    }
}
