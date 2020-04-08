using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForAreas : Detector
{
    public string playerTag;
    public string waterTag;

    public Collider2D collider;

    public PlayerManager player;
    public Reward reward;
    public bool inWater;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<PlayerManager>();
        reward = GameObject.FindObjectOfType<Reward>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            MovingObject[] movingObjects = GameObject.FindObjectsOfType<MovingObject>();
            for (int a = 0; a < movingObjects.Length; a++)
            {
                if (Physics2D.IsTouching(movingObjects[a].GetComponent<Collider2D>(), collision))
                {
                    if (inWater)
                    {
                        player.PrizeForEnter(reward);
                        Disable();
                    }
                }
            }
        }
    }
    public void Enable()
    {
        collider.enabled = true;
    }
    public void Disable()
    {
        collider.enabled = false;
    }
}
