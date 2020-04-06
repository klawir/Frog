using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public List<MovingObject> objects;
    public List<MovingObject> floatingObject;

    public float frequencyImmersionInWater;
    public string floatingItemTag;
    private int rand;
    public float timeImmersionInWater;

    private float time;
    private bool underwater;
    private MovingObject floatingObj;

    private void Start()
    {
        time = 0;
    }
    void Update()
    {
        Movement();

        if (Time.time > time + frequencyImmersionInWater && !underwater)
        {
            SearchFloatingItem();
            RandomingFloatingObject();
        }

        if (Time.time > time + timeImmersionInWater && underwater)
            Surface();
    }
    private void Surface()
    {
        floatingObj.GetComponent<SpriteRenderer>().enabled = true;
        floatingObj.GetComponent<Collider2D>().enabled = true;
        floatingObj.tag = floatingItemTag;
        underwater = false;
    }
    private void SearchFloatingItem()
    {
        floatingObject.Clear();
        for (int a = 0; a < objects.Count; a++)
        {
            if (objects[a].tag == floatingItemTag &&
                objects[a].transform.childCount == 0)
                floatingObject.Add(objects[a].GetComponent<MovingObject>());
        }
    }
    private void RandomingFloatingObject()
    {
        for (int a = 0; a < objects.Count; a++)
        {
            rand = Random.Range(0, floatingObject.Count - 1);
            if (!floatingObject[rand].IsBlockImmersionInWater)
                floatingObj = floatingObject[rand];
        }
        floatingObj.GetComponent<SpriteRenderer>().enabled = false; 
        floatingObj.GetComponent<Collider2D>().enabled = false;
        time = Time.time;
        underwater = true;
    }
    private void Movement()
    {
        foreach (MovingObject obstacle in objects)
            obstacle.Move();
    }
}
