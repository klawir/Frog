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

    /// <summary>
    /// Changes the navigation's state
    /// </summary>
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

    public bool RightState
    {
        get { return navigationStates == NavigationDirection.right; }
    }
    public bool LeftState
    {
        get { return navigationStates == NavigationDirection.left; }
    }
    public bool ForwardState
    {
        get { return navigationStates == NavigationDirection.forward; }
    }
    public bool BackwardState
    {
        get { return navigationStates == NavigationDirection.backward; }
    }
}