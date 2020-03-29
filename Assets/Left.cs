using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class Left : Command
{
    public override void Execute()
    {
        if (!state.LeftState)
        {
            rotate.eulerAngles = new Vector3(0, 0, 90f);
            state.SetToLeft();
        }
        rotate.anchoredPosition -= (Vector2.right * height);
    }
}
