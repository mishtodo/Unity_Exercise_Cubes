using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public event Action<Vector3> MouseButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonPressed?.Invoke(Input.mousePosition);
        }
    }
}
