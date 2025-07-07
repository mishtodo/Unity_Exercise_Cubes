using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _button = 0;

    public event Action<Vector3> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_button))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}