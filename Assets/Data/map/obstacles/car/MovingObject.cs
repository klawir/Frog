using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public RectTransform rect;
    private float translate;
    private float directionOfMovement;
    private Vector2 testPos;
    public int sectorNr;

    private void Start()
    {
        Initial();
    }
    private void Initial()
    {
        translate = rect.rect.height / 10;

        testPos = transform.position;
        testPos += (Vector2.right * translate * speed);

        if (rect.anchoredPosition.x > testPos.x)
            directionOfMovement = 1;
        else
        {
            directionOfMovement = -1;
            rect.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    public void Move()
    {
        rect.anchoredPosition += (Vector2.right * directionOfMovement * translate * speed * Time.deltaTime);
    }
}
