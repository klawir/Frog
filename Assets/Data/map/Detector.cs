using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    protected SpawnManager spawnerManager;

    protected virtual void Start()
    {
        spawnerManager = GameObject.FindObjectOfType<SpawnManager>();
    }
    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
