using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObstacles : MonoBehaviour
{
    public List<MovingObject> objects;

    void FixedUpdate()
    {
        foreach (MovingObject obstacle in objects)
            obstacle.Move();
    }
}
