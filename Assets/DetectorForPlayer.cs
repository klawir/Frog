using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForPlayer : Detector
{
    public string floatingItemTag;
    public string obstacleTag;
    public string areaObstacleTag;
    public string finishPointTag;

    public Collider2D collider;
    public SpriteRenderer finishedState;

    private Transform parentOfDetectedItem;
    private Collider2D water;
    private MovingObject[] movingObjects;

    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == floatingItemTag)
        {
            parentOfDetectedItem = transform.parent;
            transform.SetParent(collision.transform);
            water = GameObject.FindObjectOfType<DetectorForObstacleAreas>().GetComponent<Collider2D>();
            water.enabled = false;
        }
        if (collision.gameObject.tag == obstacleTag)
        {
            Destroy(gameObject);
            spawnerManager.SpawnPlayer();
        }
        if (collision.gameObject.tag == areaObstacleTag)
        {
            movingObjects = GameObject.FindObjectsOfType<MovingObject>();
            for (int a = 0; a < movingObjects.Length; a++)
            {
                if (Physics2D.IsTouching(movingObjects[a].GetComponent<Collider2D>(), collider))
                    break;
                if (a == movingObjects.Length - 1)
                {
                    Destroy(gameObject);
                    spawnerManager.SpawnPlayer();
                }
            }
        }
        if(collision.gameObject.tag == finishPointTag)
        {
            Debug.Log("finishPointTag");
            Instantiate(finishedState, collision.transform);
            spawnerManager.SpawnPlayer();
            Destroy(gameObject);
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
