using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> Clicked;

    private void Update()
    {
        int button = 0;

        if (Input.GetMouseButtonDown(button))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}
