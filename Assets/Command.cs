using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs;

public abstract class Command
{
    protected RectTransform rotate;
    protected State state;
    protected Image model;
    protected float height;
    protected float width;

    public Command()
    {
        rotate = GameObject.FindObjectOfType<State>().GetComponent<RectTransform>();
        state = GameObject.FindObjectOfType<State>();
        model = rotate.GetComponent<Image>();
        height = rotate.rect.height;
        width = rotate.rect.width;
    }
    public abstract void Execute();
}