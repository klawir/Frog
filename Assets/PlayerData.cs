using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public struct PlayerData
{
    public RectTransform rotate;
    public State state;
    public Image model;
    public float height;
    public float width;
}