using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public Text score;
    public Text time;
    public Text _lifes;

    public float timeLimit;
    
    private float timer;
    private float elapsedTime;

    private int points;
    private Player player;

    private void Start()
    {
        timer = timeLimit;

        player = GameObject.FindObjectOfType<Player>();
        if (PlayerData.totalScores != 0)
        {
            points = PlayerData.totalScores;
            score.text = points.ToString();
            player.lifes = PlayerData.lifes;
            _lifes.text = player.lifes.ToString();
        }
        _lifes.text = player.lifes.ToString();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        time.text = timer.ToString();
    }
    public void ResetTime()
    {
        timer = timeLimit;
    }
    public int Points
    {
        get { return points; }
    }
    public void TimeDifference()
    {
        elapsedTime = timeLimit - timer;
        PlayerData.totalTime += elapsedTime;
    }
    public void AddPoints(int value)
    {
        points += value;
        score.text = points.ToString();
    }
    public void PrizeForEnter(Reward reward)
    {
        AddPoints(reward.firstTimeOnAnArea);
    }
    public void Update(int lifes)
    {
        _lifes.text = lifes.ToString();
    }
    public int ElapsedTime
    {
        get { return (int)elapsedTime; }
    }
    public float APercentOfTimeLimit
    {
        get { return elapsedTime / timeLimit; }
    }
}
