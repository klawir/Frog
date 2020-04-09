using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float timer;
    private float elapsedTime;
    public float timeLimit;
    public Text time;

    private void Start()
    {
        timer = timeLimit;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (IsTimeOut)
        {
            TimeOut();
            Debug.Log("IsTimeOut");
        }
        time.text = timer.ToString();
    }
    private void TimeOut()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        player.RemoveLife();
        Destroy(GameObject.FindObjectOfType<Keyboard>().gameObject);
        SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
        if (!player.GameOver)
            spawnManager.SpawnPlayer();
        Start();
    }
    public int ElapsedTime
    {
        get { return (int)elapsedTime; }
    }
    public float APercentOfTimeLimit
    {
        get { return elapsedTime / timeLimit; }
    }
    private bool IsTimeOut
    {
        get { return timer <= 0; }
    }
    public void ResetTime()
    {
        timer = timeLimit;
    }
    public void TimeDifference()
    {
        elapsedTime = timeLimit - timer;
        PlayerData.totalTime += elapsedTime;
    }
}
