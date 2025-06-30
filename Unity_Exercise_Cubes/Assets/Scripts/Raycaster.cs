using System;
using UnityEngine;

[RequireComponent(typeof(Camera), typeof(InputReader))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHitted;

    private void OnEnable()
    {
        _inputReader.Clicked += CastRay;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= CastRay;
    }

    private void CastRay(Vector3 mousePosition)
    {
        _ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Cube cube = hit.collider.gameObject.GetComponent<Cube>();
            CubeHitted?.Invoke(cube);
        }
    }
}