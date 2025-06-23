using System;
using UnityEngine;

public class RaycastDrawer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;

    public event Action<RaycastHit> RaycastHited;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                RaycastHited?.Invoke(hit);    
            }
        }
    }
}
