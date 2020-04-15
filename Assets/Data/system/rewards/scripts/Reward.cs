using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int reachedGoal;
    public int firstTimeOnAnArea;

    public void Give(GameScore score, TimeManager time)
    {
        time.TimeDifference();
        float valuePercent = time.APercentOfTimeLimit;
        float value = reachedGoal - (reachedGoal * valuePercent);
        score.AddPoints((int)value);
    }
}
