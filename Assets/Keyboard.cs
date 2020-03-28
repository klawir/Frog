using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    private Command right;
    private Command left;
    private Command backward;
    private Command forward;

    void Start()
    {
        right = new Right();
        left = new Left();
        backward = new Backward();
        forward = new Forward();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            right.Execute();
        if (Input.GetKeyDown(KeyCode.A))
            left.Execute();
        if (Input.GetKeyDown(KeyCode.S))
            backward.Execute();
        if (Input.GetKeyDown(KeyCode.W))
            forward.Execute();
    }
}
