using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : Command
{
    public override void Execute()
    {
        if (!state.IsForwardState)
        {
            rotate.eulerAngles = Vector2.zero;
            state.SetToForward();
        }
        rotate.anchoredPosition += (Vector2.up * height);
    }
}

