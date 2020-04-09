using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int reachedGoal;
    public int firstTimeOnAnArea;

    public void Do(GameScore score)
    {
        score.TimeDifference();
        float valuePercent = score.APercentOfTimeLimit;
        float value = reachedGoal - (reachedGoal * valuePercent);
        score.AddPoints((int)value);
    }
}
