using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    private NavigationDirection navigationStates;

    private enum NavigationDirection { right, left, forward, backward }

    void Start()
    {
        SetToForward();
    }

    public void SetToRight()
    {
        navigationStates = NavigationDirection.right;
    }
    public void SetToLeft()
    {
        navigationStates = NavigationDirection.left;
    }
    public void SetToForward()
    {
        navigationStates = NavigationDirection.forward;
    }
    public void SetToBackward()
    {
        navigationStates = NavigationDirection.backward;
    }

    public bool IsRightState
    {
        get { return navigationStates == NavigationDirection.right; }
    }
    public bool IsLeftState
    {
        get { return navigationStates == NavigationDirection.left; }
    }
    public bool IsForwardState
    {
        get { return navigationStates == NavigationDirection.forward; }
    }
    public bool IsBackwardState
    {
        get { return navigationStates == NavigationDirection.backward; }
    }
}