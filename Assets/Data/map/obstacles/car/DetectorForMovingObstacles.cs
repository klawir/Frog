using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorForMovingObstacles : DetectorForMovingObjects
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        
        
    }
}