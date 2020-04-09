using UnityEngine;

public class Player : MonoBehaviour
{
    public int lifes;
    public LossGameManager lossGameManager;
    public GameLimits gameLimits;

    private int reachedGoals;
    private GameScore score;
    private Reward reward;

    private void Start()
    {
        reachedGoals = 0;

        score = GameObject.FindObjectOfType<GameScore>();
        reward = GameObject.FindObjectOfType<Reward>();
    }
    public void ResetAllData()
    {
        PlayerData.Reset();
    }
    public void AchieveTheGoal()
    {
        reachedGoals++;
        PlayerData.goalsGained++;

        reward.Do(score);
        if (Won)
        {
            PlayerData.lifes = lifes;
            PlayerData.totalScores = score.Points;
            WinGameManager winGameManager = GameLimits.FindObjectOfType<WinGameManager>();
            winGameManager.ShowScores(score);
        }

        score.ResetTime();
    }
    public void RemoveLife()
    {
        lifes--;
        score.Update(lifes);
        score.TimeDifference();

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
