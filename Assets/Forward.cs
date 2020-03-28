using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : Command
{
    public override void Execute()
    {
        if (!state.ForwardState)
        {
            rotate.eulerAngles = new Vector3(0, 0, 0);
            state.SetToForward();
        }
        rotate.anchoredPosition += (Vector2.up * height);
    }
}

