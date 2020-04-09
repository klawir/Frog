using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public Text score;
   
    public Text _lifes;

    public SpawnManager spawnManager;
    
    private int points;
    private Player player;

    private void Start()
    {
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
    
    public int Points
    {
        get { return points; }
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
    public void UpdateLifes(int value)
    {
        _lifes.text = value.ToString();
    }
   
}
