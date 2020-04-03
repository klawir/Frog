using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int lifes;
    public GameManager gameManager;
    public float timeLimit;
    public Text score;
    public Text time;
    public Text _lifes;

    private int reachedGoals;
    private int points;
    private float timer;

    private void Start()
    {
        timer = timeLimit;
        _lifes.text = lifes.ToString();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        time.text = timer.ToString();
    }
    private void AddPoints(int value)
    {
        points += value;
        score.text = points.ToString();
    }
    public void ReachGoal(Reward reward)
    {
        reachedGoals++;
        float valuePercent = (timeLimit - timer) / timeLimit;
        float value = reward.reachedGoal - (reward.reachedGoal * valuePercent);
        AddPoints((int)value);
        
        if (Won)
            gameManager.ShowScores();

        timer = timeLimit;
    }
    public void PrizeForEnter(Reward reward)
    {
        AddPoints(reward.firstTimeOnAnArea);
    }
    public void RemoveLife()
    {
        lifes--;
        _lifes.text = lifes.ToString();
        if (hasGameOver)
            gameManager.GameOver();
    }
    public bool hasGameOver
    {
        get { return lifes <= 0; }
    }
    public bool Won
    {
        get { return reachedGoals >= gameManager.gloalLimit; }
    }
}
