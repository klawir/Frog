using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<MovingObject> movingObjects;
    public List<RectTransform> obstaclesSpawnPoints;
    public List<RectTransform> obstaclesEndSpawnPoints;

    public List<RectTransform> floatingItemsSpawnPoints;
    public List<RectTransform> floatingItemsEndSpawnPoints;

    public string floatingItemTag;
    public GameObject player;
    public Transform playerSpawnPos;
    private ObjectsManager managerObstacles;

    /// <summary>
    /// Spawns 1 car for each 1 line
    /// </summary>
    public void SpawnCars()
    {
        for (int a=0;a< obstaclesSpawnPoints.Count;a++)
        {
            MovingObject spawnedObj = Instantiate(movingObjects[0], obstaclesSpawnPoints[a]);
            spawnedObj.speed = obstaclesSpawnPoints[a].GetComponent<SpawnPoint>().startSpeed;
            managerObstacles.objects.Add(spawnedObj);
            spawnedObj.sectorNr = a;
        }
    }
    /// <summary>
    /// Spawns 1 floating item for each 1 line
    /// </summary>
    public void SpawnFloatingItems()
    {
        for (int a = 0; a < floatingItemsSpawnPoints.Count; a++)
        {
            MovingObject spawnedObj = Instantiate(movingObjects[1], floatingItemsSpawnPoints[a]);
            spawnedObj.speed = floatingItemsSpawnPoints[a].GetComponent<SpawnPoint>().startSpeed;
            managerObstacles.objects.Add(spawnedObj);
            spawnedObj.sectorNr = a;
        }
    }
    /// <summary>
    /// Spawns a car at line based on the argument
    /// </summary>
    /// <param name="obstacle"></param>
    public void SpawnObject(MovingObject obstacle)
    {
        int itemIndex = 0;
        MovingObject spawnedObj;

        obstacle.gameObject.name = obstacle.gameObject.name.Replace("(Clone)", "");
        foreach (MovingObject _obstacle in movingObjects)
            if (obstacle.name == _obstacle.name)
                itemIndex = movingObjects.IndexOf(_obstacle);

        switch (itemIndex)
        {
            case 0:
                spawnedObj = Instantiate(movingObjects[itemIndex], obstaclesSpawnPoints[obstacle.sectorNr]);
                spawnedObj.speed = obstaclesSpawnPoints[obstacle.sectorNr].GetComponent<SpawnPoint>().startSpeed;
                managerObstacles.objects.Add(spawnedObj);
                spawnedObj.sectorNr = obstacle.sectorNr;
                break;
            case 1:
                spawnedObj = Instantiate(movingObjects[itemIndex], floatingItemsSpawnPoints[obstacle.sectorNr]);
                spawnedObj.speed = floatingItemsSpawnPoints[obstacle.sectorNr].GetComponent<SpawnPoint>().startSpeed;
                managerObstacles.objects.Add(spawnedObj);
                spawnedObj.sectorNr = obstacle.sectorNr;
                break;
        }
    }

    /// <summary>
    /// Respawns a car which has been left the map
    /// </summary>
    /// <param name="obstacle"></param>
    public void RespawnObject(MovingObject obstacle)
    {
        int itemIndex = managerObstacles.objects.IndexOf(obstacle);
        managerObstacles.objects.RemoveAt(itemIndex);
        if(obstacle.tag == floatingItemTag)
            managerObstacles.floatingObject.Remove(obstacle);
        managerObstacles.floatingObject.RemoveAll(item=>item==null);
        SpawnObject(obstacle);
    }
    public void SpawnPlayer()
    {
        Instantiate(player, playerSpawnPos);
    }
    private void Start()
    {
        managerObstacles = GameObject.FindObjectOfType<ObjectsManager>();
        SpawnCars();
        SpawnFloatingItems();
        SpawnPlayer();
    }
}
