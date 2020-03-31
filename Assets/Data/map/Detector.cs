using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    public string playerTag;
    public string endOfMapTag;
    public string spawnTrigger;

    public MovingObject obstacle;
    protected SpawnerManager spawnerManager;

    protected virtual void Start()
    {
        spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();
    }
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
