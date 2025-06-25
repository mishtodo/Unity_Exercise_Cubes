using UnityEngine;

public class CubeExploder: MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.RaycastHited += OnRaycastHit;
    }

    private void OnDisable()
    {
        _raycaster.RaycastHited -= OnRaycastHit;
    }

    private void OnRaycastHit(RaycastHit hit)
    {
        Destroy(hit.collider.gameObject);
    }
}