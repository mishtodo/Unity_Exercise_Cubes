using System;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;
    [SerializeField] private Collider _collider;

    public event Action Destroying;

    private void OnEnable()
    {
        _raycastDrawer.RaycastHited += OnRaycastHit;
    }

    private void OnDisable()
    {
        _raycastDrawer.RaycastHited -= OnRaycastHit;
    }

    private void OnRaycastHit(RaycastHit hit)
    {
        _collider = GetComponent<Collider>();

        if (hit.collider == _collider)
        {
            Destroying?.Invoke();
            Destroy(gameObject);
        }
    }
}
