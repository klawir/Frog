using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForFloatingItems : DetectorForMovingItems
{
    private Transform parentOfDetectedItem;
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == playerTag)
        {
            parentOfDetectedItem = collision.transform.parent;
            collision.transform.SetParent(transform);
        }
        if (collision.tag == spawnTrigger)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnFloatingItem(obstacle);
        }
        if (collision.tag == endOfMapTag)
        {
            spawnerManager.RespawnFloatingItem(obstacle);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
            collision.transform.SetParent(parentOfDetectedItem);
    }
}
