using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    protected SpawnerManager spawnerManager;

    protected virtual void Start()
    {
        spawnerManager = GameObject.FindObjectOfType<SpawnerManager>();
    }
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
