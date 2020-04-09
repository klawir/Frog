using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForObstacleAreas : Detector
{
    public string playerTag; 

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            MovingObject[] movingObjects = GameObject.FindObjectsOfType<MovingObject>();
            for (int a = 0; a < movingObjects.Length; a++)
            {
                if (Physics2D.IsTouching(movingObjects[a].GetComponent<Collider2D>(), collision))
                    break;
                if (a == movingObjects.Length - 1)
                {
                    Player player = GameObject.FindObjectOfType<Player>();
                    player.RemoveLife();

                    if (!player.GameOver)
                    {
                        collider.enabled = true;
                        spawnerManager.SpawnPlayer();
                    }
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
