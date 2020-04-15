using UnityEngine;

public class Player : MonoBehaviour
{
    public int lifes;
    public LossGameManager lossGameManager;
    public GameLimits gameLimits;

    private int reachedGoals;
    private GameScore score;
    private Reward reward;
    private TimeManager timeManager;

    private void Start()
    {
        reachedGoals = 0;

        score = GameObject.FindObjectOfType<GameScore>();
        reward = GameObject.FindObjectOfType<Reward>();
        timeManager= GameObject.FindObjectOfType<TimeManager>();
    }
    public void ResetAllData()
    {
        PlayerData.Reset();
    }
    public void AchieveGoal()
    {
        reachedGoals++;
        PlayerData.goalsGained++;

        reward.Give(score, timeManager);
        if (Won)
        {
            PlayerData.lifes = lifes;
            PlayerData.totalScores = score.Points;
            WinGameManager winGameManager = GameLimits.FindObjectOfType<WinGameManager>();
            winGameManager.ShowScores(score);
        }
        else
        {
            SpawnManager spawnManager= GameLimits.FindObjectOfType<SpawnManager>();
            spawnManager.SpawnPlayer();
        }
        timeManager.ResetTime();
    }
    public void RemoveLife()
    {
        lifes--;
        score.UpdateLifes(lifes);
        timeManager.TimeDifference();

        if (GameOver)
            lossGameManager.GameOver();
    }
    public bool GameOver
    {
        get { return lifes <= 0; }
    }
    public bool Won
    {
        get { return reachedGoals == gameLimits.gloals; }
    }
}
