using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backward : Command
{
    public override void Execute()
    {
        if (!state.IsBackwardState)
        {
            rotate.eulerAngles = new Vector3(0, 0, 180);
            state.SetToBackward();
        }
        rotate.anchoredPosition -= (Vector2.up * height);
    }
}
