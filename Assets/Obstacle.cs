using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public RectTransform rect;
    private float translate;

    private void Start()
    {
        translate = rect.rect.height/ 10;
    }
    public void Move()
    {
        rect.anchoredPosition += (Vector2.right * translate * speed * Time.deltaTime);
    }
}
