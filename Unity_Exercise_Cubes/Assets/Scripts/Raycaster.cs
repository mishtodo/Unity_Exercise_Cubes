using System;
using UnityEngine;

[RequireComponent(typeof(Camera), typeof(MouseInput))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private MouseInput _mouseInput;

    public event Action<RaycastHit> RaycastHited;

    private void OnEnable()
    {
        _mouseInput.MouseButtonPressed += CastRay;
    }

    private void OnDisable()
    {
        _mouseInput.MouseButtonPressed -= CastRay;
    }

    private void CastRay(Vector3 mousePosition)
    {
        _ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            RaycastHited?.Invoke(hit);    
        }
    }
}