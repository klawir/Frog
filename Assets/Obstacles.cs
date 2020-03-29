using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public List<Obstacle> objects;

    void FixedUpdate()
    {
        foreach (Obstacle rect in objects)
            rect.Move();
    }
}
