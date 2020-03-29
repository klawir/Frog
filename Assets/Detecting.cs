using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    public string playerTag;
    public string endOfMapTag;

    private Obstacles obstacles;
    public Obstacle obstacle;
    private SpawnerManager spawnerManager;

    private void Start()
    {
        obstacles = GameObject.FindObjectOfType<Obstacles>();
        spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            Destroy(collision.gameObject);
            spawnerManager.SpawnPlayer();
        }
        if (collision.tag == endOfMapTag)
        {
            obstacles.objects.RemoveAt(obstacles.objects.IndexOf(obstacle));
            spawnerManager.SpawnCar();
            Destroy(gameObject);
        }
    }
}
