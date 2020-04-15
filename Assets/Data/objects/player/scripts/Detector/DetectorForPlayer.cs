using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForPlayer : Detector
{
    public string floatingItemTag;
    public string movingObstacleTag;
    public string areaObstacleTag;
    public string finishPointTag;
    public string firstTimeEntranceToArea;

    private Player player;
    private Transform parentOfDetectedItem;
    private Collider2D water;
    
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<Player>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == areaObstacleTag)
        {
            water = collision.GetComponent<Collider2D>();
            water.enabled = false;
        }
        if (collision.gameObject.tag == floatingItemTag)
        {
            parentOfDetectedItem = transform.parent;
            transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag == firstTimeEntranceToArea)
        {
            MovingObject[] movingObjects = GameObject.FindObjectsOfType<MovingObject>();
            for (int a = 0; a < movingObjects.Length; a++)
            {
                if (!Physics2D.IsTouching(movingObjects[a].GetComponent<Collider2D>(), collider))
                {
                    if (!collision.GetComponent<DetectorForAreas>().inWater)
                    {
                        GameScore gameScore = GameObject.FindObjectOfType<GameScore>();
                        Reward reward = GameObject.FindObjectOfType<Reward>();
                        gameScore.PrizeForEnter(reward);
                        collision.GetComponent<DetectorForAreas>().Disable();
                        break;
                    }
                }
            }
        }
        if (collision.gameObject.tag == movingObstacleTag)
        {
            player.RemoveLife();
            Destroy(gameObject);
            if (!player.GameOver)
                spawnerManager.SpawnPlayer();
        }
        if (collision.gameObject.tag == finishPointTag)
        {
            spawnerManager.SpawnPlayerWithoutControl(collision);
            Destroy(gameObject);
            player.AchieveGoal();
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == floatingItemTag)
        {
            water.enabled = true;
            transform.SetParent(parentOfDetectedItem);
        }
    }
}
