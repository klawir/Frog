using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<Obstacle> cars;
    public List<RectTransform> carsSpawnPoints;
    public List<RectTransform> carsEndSpawnPoints;
    public List<GameObject> woods;
    public List<GameObject> woodsSpawnPoints;

    public GameObject player;
    public Transform playerSpawnPos;
    private Obstacles obstacles;

    public void SpawnCars()
    {
        for (int a=0;a< carsSpawnPoints.Count;a++)
        {
            Obstacle spawnedObj = Instantiate(cars[0], carsSpawnPoints[a]);
            obstacles.objects.Add(spawnedObj);
            spawnedObj.sectorNr = a;
        }
    }
    public void SpawnCar(Obstacle obstacle)
    {
        Obstacle spawnedObj = Instantiate(cars[0], carsSpawnPoints[obstacle.sectorNr]);
        obstacles.objects.Add(spawnedObj);
        spawnedObj.sectorNr = obstacle.sectorNr;
    }
    public void RespawnCar(Obstacle obstacle)
    {
        int itemIndex = obstacles.objects.IndexOf(obstacle);
        obstacles.objects.RemoveAt(itemIndex);
        Obstacle spawnedObj = Instantiate(cars[0], carsSpawnPoints[obstacle.sectorNr]);
        obstacles.objects.Add(spawnedObj);
        spawnedObj.sectorNr = obstacle.sectorNr;
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
        SpawnCars();
        SpawnPlayer();
    }
}
