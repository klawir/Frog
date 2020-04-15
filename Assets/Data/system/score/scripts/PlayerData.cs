using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int totalScores;
    public static int lifes;
    public static float totalTime;
    public static int goalsGained;

    public static void Reset()
    {
        totalScores = 0;
        lifes = 0;
        totalTime = 0;
        goalsGained = 0;
    }
}
