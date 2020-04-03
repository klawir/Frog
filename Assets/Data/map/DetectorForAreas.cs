using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForAreas : Detector
{
    public string playerTag;

    public Collider2D collider;

    private PlayerManager player;
    private Reward reward;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindObjectOfType<PlayerManager>();
        reward = player.GetComponent<Reward>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            player.PrizeForEnter(reward);
            Disable();
        }
    }
    public void Enable()
    {
        collider.enabled = true;
    }
    private void Disable()
    {
        collider.enabled = false;
    }
}
