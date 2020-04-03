using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForObstacleAreas : Detector
{
    public string playerTag; 

    private MovingObject[] movingObjects;

    public Collider2D collider;
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            movingObjects = GameObject.FindObjectsOfType<MovingObject>();
            for (int a = 0; a < movingObjects.Length; a++)
            {
                if (Physics2D.IsTouching(movingObjects[a].GetComponent<Collider2D>(), collision))
                    break;
                if (a == movingObjects.Length - 1)
                {
                    PlayerManager player = GameObject.FindObjectOfType<PlayerManager>();
                    player.RemoveLife();

                    if (!player.hasGameOver)
                    {
                        collider.enabled = true;
                        spawnerManager.SpawnPlayer();
                    }
                    Debug.Log("DetectorForObstacleAreas OnTriggerEnter2D");
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
