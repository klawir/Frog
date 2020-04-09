using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public MovingObject car;
    public MovingObject floatingObj;
    public MovingObject floatingAnimal;

    public List<RectTransform> obstaclesSpawnPoints;
    public List<RectTransform> obstaclesEndSpawnPoints;

    public List<RectTransform> floatingItemsSpawnPoints;
    public List<RectTransform> floatingItemsEndSpawnPoints;

    public List<RectTransform> floatingAnimalSpawnPoints;
    public List<RectTransform> floatingAnimalEndSpawnPoints;

    public string floatingItemTag;
    public GameObject player;
    public Transform playerSpawnPos;
    private ObjectsManager objectsManager;
    public SpriteRenderer finishedState;

    private void Start()
    {
        objectsManager = GameObject.FindObjectOfType<ObjectsManager>();
        SpawnObjects(car, obstaclesSpawnPoints);
        SpawnObjects(floatingObj, floatingItemsSpawnPoints);
        SpawnObjects(floatingAnimal, floatingAnimalSpawnPoints);
        SpawnPlayer();
    }

    /// <summary>
    /// Spawns 1 all objects for each 1 line
    /// </summary>
    public void SpawnObjects(MovingObject obj, List<RectTransform> spawnPos)
    {
        for (int a = 0; a < spawnPos.Count; a++)
        {
            MovingObject spawnedObj = Instantiate(obj, spawnPos[a]);
            spawnedObj.speed = spawnPos[a].GetComponent<SpawnPoint>().startSpeed;
            objectsManager.objects.Add(spawnedObj);
            spawnedObj.sectorNr = a;
        }
    }
    /// <summary>
    /// Creates copy of this object
    /// </summary>
    /// <param name="obj"></param>
    public void SpawnObject(MovingObject obj)
    {
        MovingObject spawnedObj = new MovingObject();

        obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        
        if (obj.name == car.name)
        {
            spawnedObj = Instantiate(car, obstaclesSpawnPoints[obj.sectorNr]);
            spawnedObj.speed = obstaclesSpawnPoints[obj.sectorNr].GetComponent<SpawnPoint>().startSpeed;
        }
        if (obj.name == floatingObj.name)
        {
            spawnedObj = Instantiate(floatingObj, floatingItemsSpawnPoints[obj.sectorNr]);
            spawnedObj.speed = floatingItemsSpawnPoints[obj.sectorNr].GetComponent<SpawnPoint>().startSpeed;
        }
        if (obj.name == floatingAnimal.name)
        {
            spawnedObj = Instantiate(floatingAnimal, floatingAnimalSpawnPoints[obj.sectorNr]);
            spawnedObj.speed = floatingAnimalSpawnPoints[obj.sectorNr].GetComponent<SpawnPoint>().startSpeed;
        }
        objectsManager.objects.Add(spawnedObj);
        spawnedObj.sectorNr = obj.sectorNr;
    }

    /// <summary>
    /// Respawns a car which has been left the map
    /// </summary>
    /// <param name="obj"></param>
    public void RespawnObject(MovingObject obj)
    {
        int itemIndex = objectsManager.objects.IndexOf(obj);
        objectsManager.objects.RemoveAt(itemIndex);
        if(obj.tag == floatingItemTag)
            objectsManager.floatingObject.Remove(obj);
        objectsManager.floatingObject.RemoveAll(item=>item==null);
        SpawnObject(obj);
    }
    public void SpawnPlayer()
    {
        Instantiate(player, playerSpawnPos);
    }
    /// <summary>
    /// Creates player's clone on objective's place
    /// </summary>
    /// <param name="pos"></param>
    public void SpawnPlayerWithoutControl(Collider2D pos)
    {
        Instantiate(finishedState, pos.transform);
    }
   
}
