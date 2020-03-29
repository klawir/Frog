using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<Obstacle> cars;
    public List<RectTransform> carsSpawnPoints;
    public List<GameObject> woods;
    public List<GameObject> woodsSpawnPoints;

    public GameObject player;
    public Transform playerSpawnPos;

    private Canvas map;
    private Obstacles obstacles;

    public void SpawnCar()
    {
        Obstacle spawnedObj = Instantiate(cars[0], carsSpawnPoints[0]);
        obstacles.objects.Add(spawnedObj);
    }
    public void SpawnWood()
    {

    }
    public void SpawnPlayer()
    {
        Instantiate(player, playerSpawnPos);
    }
    private void Start()
    {
        obstacles = GameObject.FindObjectOfType<Obstacles>();
        map= GameObject.FindObjectOfType<Canvas>();
        SpawnCar();
        SpawnPlayer();
    }
}
