using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Right : Command
{
    public override void Execute()
    {
        if (!state.IsRightState)
        {
            rotate.eulerAngles = new Vector3(0, 0, -90f);
            state.SetToRight();
        }
        rotate.anchoredPosition += (Vector2.right * height);
    }
}
