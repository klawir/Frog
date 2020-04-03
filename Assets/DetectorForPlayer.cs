using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForPlayer : Detector
{
    public string floatingItemTag;
    public string movingObstacleTag;
    public string areaObstacleTag;
    public string finishPointTag;

    public SpriteRenderer finishedState;

    private PlayerManager player;
    private Reward reward;
    private Transform parentOfDetectedItem;
    private Collider2D water;
    
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<PlayerManager>();
        reward = player.GetComponent<Reward>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == areaObstacleTag)
        {
            water = collision.GetComponent<Collider2D>();
            water.enabled = false;
        }
        if (collision.gameObject.tag == floatingItemTag)
        {
            parentOfDetectedItem = transform.parent;
            transform.SetParent(collision.transform);
            
        }
        if (collision.gameObject.tag == movingObstacleTag)
        {
            player.RemoveLife();
            Destroy(gameObject);

            if (!player.hasGameOver)
                spawnerManager.SpawnPlayer();
        }
        
        if(collision.gameObject.tag == finishPointTag)
        {
            Instantiate(finishedState, collision.transform);
            Destroy(gameObject);
            player.ReachGoal(reward);

            if (!player.Won)
                spawnerManager.SpawnPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == floatingItemTag)
        {
            Debug.Log("DetectorForPlayer OnTriggerExit2D");
            water.enabled = true;
            transform.SetParent(parentOfDetectedItem);
        }
    }
}
