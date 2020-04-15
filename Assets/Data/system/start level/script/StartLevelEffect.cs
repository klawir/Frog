using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelEffect : MonoBehaviour
{
    public Text levelName;
    public float fade;

    private void Start()
    {
        Destroy(levelName, fade);
    }
}
