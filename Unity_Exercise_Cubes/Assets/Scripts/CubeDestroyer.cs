using System;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private RaycastDrawer _raycastDrawer;
    [SerializeField] private Collider _collider;
    //[SerializeField] private float _startingSpawnChance = 100.0f;

    private float _currentSpawnChance;

    public event Action Destroying;
    //public event Action<float> SpawnRateChanged;

    private void Awake()
    {
        //_currentSpawnChance = _startingSpawnChance;
    }

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
            //SpawnRateChanged?.Invoke(_currentSpawnChance / 2);
            Destroy(gameObject);
        }
    }
}
