using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Command
{
    protected RectTransform rotate;
    protected State state;
    protected Image model;
    protected float height;
    protected float width;

    public Command()
    {
        state = GameObject.FindObjectOfType<State>();
        rotate = state.GetComponent<RectTransform>();
        model = rotate.GetComponent<Image>();
        height = rotate.rect.height;
        width = rotate.rect.width;
    }
    public abstract void Execute();
}