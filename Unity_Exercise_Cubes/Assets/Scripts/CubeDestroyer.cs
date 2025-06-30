using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.CubeHitted += OnRaycastHit;
    }

    private void OnDisable()
    {
        _raycaster.CubeHitted -= OnRaycastHit;
    }

    private void OnRaycastHit(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}