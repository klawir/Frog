using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static int scores;
    public static int lifes;

    public static void Reset()
    {
        scores = 0;
        lifes = 0;
    }
}
